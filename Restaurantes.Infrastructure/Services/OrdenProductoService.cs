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
    public class OrdenProductoService : IOrdenProductoService
    {
        public AppDbContext _context;
        public OrdenProductoService(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(OrdenTieneProducto prod)
        {
            _context.OrdenTieneProducto.Add(prod);
            _context.SaveChanges();
         
        }

        public void Editar(OrdenTieneProducto prod)
        {
            var otp = Obtener(prod.OrdenId, prod.ProductoId);
            otp.Cantidad = prod.Cantidad;
            _context.SaveChanges();
        }

        public void Eliminar(int ordenId, int productoId)
        {
            var otp = Obtener(ordenId, productoId);
            _context.OrdenTieneProducto.Remove(otp);
            _context.SaveChanges();
        }

        public OrdenTieneProducto Obtener(int ordenId, int productoId)
        {
            return _context.OrdenTieneProducto.FirstOrDefault(c => c.OrdenId.Equals(ordenId) && c.ProductoId.Equals(productoId));
        }

        public List<OrdenTieneProducto> ObtenerTodas(int ordenId)
        {
            return _context.OrdenTieneProducto.Where(c => c.OrdenId.Equals(ordenId)).ToList();
        }
    }
}
