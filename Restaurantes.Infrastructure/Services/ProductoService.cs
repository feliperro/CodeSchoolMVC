using Microsoft.EntityFrameworkCore;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class ProductoService : IProductoService
    {
        public AppDbContext _context;
        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public Producto Obtener(int id)
        {
            return _context.Productos.FirstOrDefault(c => c.Id == id);
        }

        public List<Producto> ObtenerProductos(int resId)
        {
            return _context.Productos.Where(c => c.RestauranteId == resId).ToList();
        }

        public int Agregar(Producto producto)
        {
            _context.Add(producto);
            _context.SaveChanges();

            return producto.Id;
        }

        public void Editar(Producto producto)
        {
            _context.Update(producto);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var prod = _context.Productos.FirstOrDefault(c => c.Id == id);

            _context.Remove(prod);
            _context.SaveChanges();
        }


        public void Eliminar(int[] ids)
        {
            
            foreach (var i in ids)
            {
                var prod = _context.Productos.FirstOrDefault(c => c.Id == i);

                _context.Remove(prod);

            }
            _context.SaveChanges();

        }
    }
}
