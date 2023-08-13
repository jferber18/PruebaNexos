using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaNexox.Interfaces.ILibros;
using PruebaNexox.Entidades.ELibros;
using PruebaNexox.Entidades.Api;

namespace PruebaNexox.Controllers
{
    public class GuardarArticulo
    {
        ILibro Libro;

        public GuardarArticulo(ILibro libro)
        {
            this.Libro = libro;
        }

        public Response GuardarLibro()
        {
           return this.Libro.GuardarLibro();
        }

        public Response ValidarLibros()
        {
            return this.Libro.ValidarLibros();
        }

        public Response ListarLibros(int Id)
        {
            return this.Libro.ListarLibro(Id);
        }
    }
}