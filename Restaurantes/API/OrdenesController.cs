using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : Controller
    {

        private readonly IordenService _ordenService;
        private readonly IProductoService _productoService;
        private readonly IOrdenProductoService _ordenProductoService;
        private readonly IMapper _mapper;
        public OrdenesController(IordenService ordenService, IProductoService productoService, IOrdenProductoService ordenProductoService, IMapper mapper)
        {
            _ordenService = ordenService;
            _productoService = productoService;
            _ordenProductoService = ordenProductoService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OrdenViewModel>> Get(int id)
        {

            //ViewData["resId"] = id;
            var ord = _ordenService.ObtenerOrdenes(id);
            var model = new List<OrdenViewModel>();

            

            _mapper.Map(ord, model);
            return model;
        }

        [HttpPost]
        [Route("AgregarOrden")]
        public IActionResult Post([FromForm]string orden)
        {

            var r = (dynamic)Newtonsoft.Json.JsonConvert.DeserializeObject(orden);
            var id = Convert.ToInt32(r.Id.Value);

            var t = 0;

            if (id == 0)
            {
                var ord = new Orden();
                ord.RestauranteId = Convert.ToInt32(r.ResId.Value);
                ord.FechaAlta = DateTime.Now;
                ord.Estatus = 1;
                ord.Total = 0;
                id = _ordenService.Agregar(ord);
            }

            foreach (var p in r.Productos)
            {
                var pId = Convert.ToInt32(p.productoId.Value);
                var cantidad = Convert.ToInt32(p.cantidad.Value);
                var prod = _productoService.Obtener(pId);
                var otpTmp = _ordenProductoService.Obtener(pId, id);
                if (otpTmp == null)
                {
                    var otp = new OrdenTieneProducto();
                    otp.OrdenId = id;
                    otp.ProductoId = pId;
                    otp.Cantidad = cantidad;
                    otp.Subtotal = cantidad * (int)prod.Precio;
                    _ordenProductoService.Agregar(otp);
                    t += otp.Subtotal;
                }
                else
                {
                    otpTmp.Cantidad = cantidad;
                    _ordenProductoService.Editar(otpTmp);
                }
            }
            var newOrder = _ordenService.Obtener(id);
            newOrder.Total = t;
            _ordenService.Editar(newOrder);
            return Ok(id);
            }

    }
}