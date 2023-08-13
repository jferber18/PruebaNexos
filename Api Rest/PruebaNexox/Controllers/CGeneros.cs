using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaNexox.Interfaces.ILibros;
using PruebaNexox.Entidades.Api;
using PruebaNexox.Entidades.ELibros;
using PruebaNexox.DTOs.Libros;

namespace PruebaNexox.Controllers
{
    public class CGeneros
    {
        IGeneros G;

        public CGeneros(IGeneros generos)
        {
            this.G = generos;
        }
        public Response ListarGeneros()
        {
            return this.G.ListarGeneros();
        }
    }
}