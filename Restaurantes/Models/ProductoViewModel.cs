using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string Ingredientes { get; set; }

    }
}
