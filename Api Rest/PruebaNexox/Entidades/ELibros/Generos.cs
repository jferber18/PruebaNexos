using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaNexox.Interfaces.ILibros;
using PruebaNexox.Entidades.Api;
using PruebaNexox.DTOs.Libros;

namespace PruebaNexox.Entidades.ELibros
{
    public class Generos : IGeneros
    {
        public Response ListarGeneros()
        {
            Response response = new Response();
            DTOLibros dTOLibros = new DTOLibros();
            response = dTOLibros.ListarGeneros();
            return response;
        }
    }
}