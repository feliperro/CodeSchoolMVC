using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class RegistrarseViewModel
    {
        [Required(ErrorMessage= "El usuario es requerido")]
        [EmailAddress(ErrorMessage = "El usuario tiene que ser un correo electronico valido")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Contrasena", ErrorMessage = "La contraseña no coincide")]
        public string ConfirmPassword { get; set; }
    }

}
