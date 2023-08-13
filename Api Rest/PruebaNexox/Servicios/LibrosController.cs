using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PruebaNexox.Entidades.ELibros;
using PruebaNexox.Entidades.Api;
using PruebaNexox.Interfaces.ILibros;
using PruebaNexox.Controllers;

namespace PruebaNexox.Servicios
{
    [RoutePrefix("api/libros")]
    public class LibrosController : ApiController
    {
        ILibro Ilibro;
        IGeneros IGeneros = new Generos();
        Response response;


        [Route("ListarGeneros")]
        [HttpGet]
        public Response ListarGeneros()
        {
            
            CGeneros Listar = new CGeneros(IGeneros);
            response = Listar.ListarGeneros();
            return response;
        }

        [Route("ListarLibro")]
        [HttpGet]
        public Response ListarLibros(int IdLibro = 0)
        {
            Ilibro = new Libro("", 0, 0, 0, new List<Autor>());
            GuardarArticulo guardar = new GuardarArticulo(Ilibro);
            response = guardar.ListarLibros(IdLibro);
            return response;
        }


        [Route("InsertarLibro")]
        [HttpPost]
        public Response InsertarLibro(Libro LibroGuardar)
        {
            Ilibro = LibroGuardar;
            GuardarArticulo guardar = new GuardarArticulo(Ilibro);
            response = guardar.ValidarLibros();
            if ((bool)response.response)
            {
                response = guardar.GuardarLibro();
            }
            return response;
        }
    }
}
