using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontEndLibros.Models.ViewModel;

namespace FrontEndLibros.Models.ViewModel
{
    public class ResponseViewModel
    {
        public string mensaje { get; set; }
        public string Estado { get; set; }
        public string excepcion { get; set; }
        public List<LibroViewModel> response { get; set; }
    }
}