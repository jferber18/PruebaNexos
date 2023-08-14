using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEndLibros.Models.ViewModel
{
    public class AutorViewModel
    {
        public int IdAutorLibro { get; set; }
        public int IdLibro { get; set; }
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }
        [Required]
        [Display(Name = "Ciudad de procedencia")]
        public string CiudadProcedencia { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}