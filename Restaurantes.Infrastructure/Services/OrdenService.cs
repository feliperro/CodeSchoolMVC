using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class OrdenService : IordenService
    {
        public AppDbContext _context;

        public OrdenService(AppDbContext context)
        {
            _context = context;
        }

        public int Agregar(Orden orden)
        {
            _context.Ordenes.Add(orden);
            _context.SaveChanges();
            return orden.Id;
        }

        public void Editar(Orden orden)
        {
            _context.Update(orden);
            _context.SaveChanges();
        }

        public int Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Orden Obtener(int id)
        {
            return _context.Ordenes.FirstOrDefault(c => c.Id == id);
        }

        public List<Orden> ObtenerOrdenes(int id)
        {
            return _context.Ordenes.Where(c => c.RestauranteId == id).ToList();
            
        }

        
    }
}
