using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class OrdenesController : Controller
    {

        private IordenService _ordenService;
        private IProductoService _productoService;
        public OrdenesController(IordenService ordenService, IProductoService productoService)
        {
            _ordenService = ordenService;
            _productoService = productoService;
        }

        public IActionResult Index(int id)
        {
            ViewData["id"] = id;
            return View("Index");
        }

        public IActionResult New(int id)
        {
            ViewData["id"] = id;
            OrdenViewModel orden = new OrdenViewModel();
            orden.RestauranteId = id;
            var productos = _productoService.ObtenerProductos(id);
            orden.ListaProductos = productos;
            return View("OrdenesNuevas", orden);
        }



    }
}