using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class OrdenViewModel
    {
        public int Id { get; set; }
        public ICollection<OrdenTieneProducto> Productos { get; set; }
        public ICollection<Producto> ListaProductos { get; set; }
        public int EmpleadoId { get; set; }
        public int RestauranteId { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Estatus { get; set; }
        public decimal Total { get; set; }
    }

    public enum OrdenEstatus
    {  
        Cerrado,
        Abierto
    }
}
