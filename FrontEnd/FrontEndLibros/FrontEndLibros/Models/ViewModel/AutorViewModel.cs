using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndLibros.Models.ViewModel
{
    public class AutorViewModel
    {
        public int IdAutorLibro { get; set; }
        public int IdLibro { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string Email { get; set; }
    }
}