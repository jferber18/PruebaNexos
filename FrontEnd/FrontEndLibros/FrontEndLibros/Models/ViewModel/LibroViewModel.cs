using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontEndLibros.Models.ViewModel;

namespace FrontEndLibros.Models.ViewModel
{
    public class LibroViewModel
    {
        public int? IdLibro { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public string NombreGenero { get; set; }
        public int NumeroPaginas { get; set; }
        public List<AutorViewModel> LisAut { get; set; }
    }
}