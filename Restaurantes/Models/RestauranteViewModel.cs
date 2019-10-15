﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class RestauranteViewModel
    {
        [Required(ErrorMessage ="Nombre es requerido")]
        public string Nombre { get; set; }
        [Required]
        public string Domicilio { get; set; }
        [Phone]
        public string Telefono { get; set; }
        [Display(Name = "Página Web")]
        [Url]
        public string PaginaWeb { get; set; }
        [Range(100, 2000)]
        public int HoraDeCierre { get; set; }

        public string Logo { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public List<int> Ordenes { get; set; }
        public List<int> Mesas { get; set; }
        public List<int> Productos { get; set; }
        public bool EsEditar { get; set; }
        public int Id { get; set; }
    }
}
