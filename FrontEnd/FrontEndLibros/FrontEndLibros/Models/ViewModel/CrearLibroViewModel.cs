using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEndLibros.Models.ViewModel
{
    public class CrearLibroViewModel
    {
        public int IdLibro { get; set; }
        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Año")]
        public int Año { get; set; }
        [Required]
        [Display(Name = "Género")]
        public int NombreGenero { get; set; }
        [Required]
        [Display(Name = "Número páginas")]
        public int NumeroPaginas { get; set; }
        [Required]
        [Display(Name = "Autores")]
        public List<AutorViewModel> LisAut { get; set; }
    }
}