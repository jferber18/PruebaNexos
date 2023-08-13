using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaNexox.Entidades.ELibros;
using PruebaNexox.Entidades.Api;
using PruebaNexox.DTOs.DBPruebaNexos;

namespace PruebaNexox.DTOs.Libros
{
    public class DTOLibros
    {
        public Response InsertarLibro(string Titulo, int Año, int IdGenero, int NumeroPaginas, List<Autor> autores)
        {
            Response response = new Response();
            try
            {
                response = ValidarCantidad();

                if ((bool)response.response)
                {
                    PruebaNexosEntities DB = new PruebaNexosEntities();
                    TblLibros tblLibros = new TblLibros();
                    List<TblAutoresLibros> AutoresLibro = new List<TblAutoresLibros>();

                    tblLibros.Titulo = Titulo;
                    tblLibros.Año = Año;
                    tblLibros.IdGenero = IdGenero;
                    tblLibros.NumeroPaginas = NumeroPaginas;
                    tblLibros.FechaCreacion = DateTime.Now;

                    DB.TblLibros.Add(tblLibros);
                    DB.SaveChanges();
                    int IdLibro = tblLibros.IdLibro;

                    foreach (Autor item in autores)
                    {
                        TblAutoresLibros registro = new TblAutoresLibros();

                        registro.IdLibro = IdLibro;
                        registro.Nombres = item.Nombres;
                        registro.Apellidos = item.Apellidos;
                        registro.FechaNacimiento = Convert.ToDateTime(item.FechaNacimiento);
                        registro.CiudadProcedencia = item.CiudadProcedencia;
                        registro.Email = item.Email;
                        registro.FechaCreación = DateTime.Now;
                        AutoresLibro.Add(registro);
                    }

                    DB.TblAutoresLibros.AddRange(AutoresLibro);
                    DB.SaveChanges();

                    object ObjetoRespuesta = ListarLibro(tblLibros.IdLibro).response;

                    response.mensaje = "Se creó el libro exitosamente";
                    response.Estado = "Correcto";
                    response.response = ObjetoRespuesta;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.mensaje = "No se pudo guardar el libro";
                response.excepcion = ex.Message;
                response.Estado = "Fallido";
                return response;
            }
        }

        public Response ListarLibro(int Id)
        {
            Response response = new Response();
            try
            {
                PruebaNexosEntities DB = new PruebaNexosEntities();
                List<object> consultados = new List<object>();
                List<TblLibros> Lista = DB.TblLibros.Where(x => x.IdLibro == (Id == 0 ? x.IdLibro : Id)).ToList();

                foreach (TblLibros item in Lista)
                {
                    object LisAut = item.TblAutoresLibros.Where(z => z.IdLibro == item.IdLibro).Select(x =>
                         new { x.IdAutorLibro, x.IdLibro, x.Nombres, x.Apellidos, x.FechaNacimiento, x.Email }
                    ).ToList();

                    object Lislib = new { item.IdLibro, item.Titulo, item.Año, item.TblGeneros.NombreGenero, item.NumeroPaginas, LisAut };

                    consultados.Add(Lislib);
                };

                response.mensaje = consultados.Count > 0 ? "Consulta exitosa" : "No se encontraron registros";
                response.Estado = "Correcto";
                response.response = consultados;
                return response;
            }
            catch (Exception ex)
            {
                response.mensaje = "No se pudo listar los libros";
                response.excepcion = ex.Message;
                response.Estado = "Fallido";
                return response;
            }
        }

        public Response ValidarCantidad()
        {
            Response response = new Response();
            try
            {
                PruebaNexosEntities DB = new PruebaNexosEntities();

                var CantidadPermitida = DB.TblConfigLimit.Where(x => x.IdConfig == 1).FirstOrDefault();
                var Registrados = DB.TblLibros.ToList();
                if (Registrados.Count <= CantidadPermitida.Limite)
                {
                    response.mensaje = "Puede agregar más libros";
                    response.Estado = "Correcto";
                    response.response = true;
                }
                else
                {
                    response.mensaje = "No se puede registrar el libro, se alcanzó el máximo permitido";
                    response.Estado = "Fallido";
                    response.response = false;
                }

                return response;
            }
            catch (Exception ex)
            {
                response.mensaje = "No se pudo validar la cantidad permitida";
                response.excepcion = ex.Message;
                response.Estado = "Fallido";
                response.response = false;
                return response;
            }
        }

        public Response ListarGeneros()
        {
            Response response = new Response();
            try
            {
                PruebaNexosEntities DB = new PruebaNexosEntities();
                object Generos = DB.TblGeneros.Where(z=> z.Activo == true).Select(x=> new { x.IdGenero,x.NombreGenero }).ToList();
                response.mensaje = "Se listaron los Géneros correctamente";
                response.Estado = "Correcto";
                response.response = Generos;
                return response;
            }
            catch (Exception ex)
            {
                response.mensaje = "No se pudo listar los Géneros";
                response.excepcion = ex.Message;
                response.Estado = "Fallido";
                response.response = false;
                return response;
            }
        }
    }
}