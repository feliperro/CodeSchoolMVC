using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IProductoService _productoService;
        private readonly IMapper _mapper;
        public ProductosController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }





        // [HttpGet]
        [HttpGet("{id}")]
        public ActionResult<List<ProductoDTO>> Get( int id)
        {   
            System.Diagnostics.Debug.WriteLine("here GET PRODUCTOS");
            System.Diagnostics.Debug.WriteLine(id);
            var prods = _productoService.ObtenerProductos(id);
            var model = new List<ProductoDTO>();

            _mapper.Map(prods, model);
            return model;
        }




        [HttpPost]
        public void Post([FromBody] ProductoDTO model)
        {
            var prod = new Producto();
            _mapper.Map(model, prod);
            _productoService.Agregar(prod);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, ProductoViewModel model)
        {
            var prod = _productoService.Obtener(id);

            if (prod == null)
                return BadRequest();

            prod.Nombre = model.Nombre;
            prod.Cantidad = model.Cantidad;

            _productoService.Editar(prod);

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var restaurante = _productoService.Obtener(id);

            if (restaurante == null)
                return BadRequest();

            _productoService.Eliminar(id);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {

            _productoService.Eliminar(ids);

            return Ok();

        }
    }
}