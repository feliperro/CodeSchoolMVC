using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class ProductosController : Controller
    {

        private IProductoService _productoService;
        public ProductosController(IProductoService productoService)
        {

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

        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("_AgregarEditarProducto", new ProductoDTO());
        }


    }
}