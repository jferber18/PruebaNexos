using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaNexox.Entidades.Api
{
    public class Response 
    {
        public string mensaje { get; set; }
        public string Estado { get; set; }
        public string excepcion { get; set; }
        public object response { get; set; }

        //public Response(string mensaje, string Estado, object response)
        //{
        //    this.mensaje = mensaje;
        //    this.Estado = Estado;
        //    this.response = response;
        //}
    }
}