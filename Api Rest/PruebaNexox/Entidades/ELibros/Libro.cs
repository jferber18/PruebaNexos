using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaNexox.Interfaces.ILibros;
using PruebaNexox.Entidades.ELibros;
using PruebaNexox.Entidades.Api;
using PruebaNexox.DTOs.Libros;

namespace PruebaNexox.Entidades.ELibros
{
    public class Libro : ILibro
    {
        public int? id { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public int IdGenero { get; set; }
        public int NumeroPaginas { get; set; }
        public List<Autor> autores { get; set; }

        public Libro(string Titulo, int Año, int IdGenero, int NumeroPaginas, List<Autor> autores, int id = 0)
        {
            this.Titulo = Titulo;
            this.Año = Año;
            this.IdGenero = IdGenero;
            this.NumeroPaginas = NumeroPaginas;
            this.autores = autores;
            this.id = id;
        }

        public Response ValidarLibros()
        {
            Response response = new Response();
            try
            {
                response.response = true;
                if (string.IsNullOrEmpty(this.Titulo))
                {
                    response.mensaje = "El campo Titulo no puede estár vacío";
                    response.Estado = "Fallido";
                    response.response = false;
                }else if (this.Año == 0)
                {
                    response.mensaje = "El campo Año no puede estar vacío o ser cero";
                    response.Estado = "Fallido";
                    response.response = false;
                }else if (this.IdGenero == 0)
                {
                    response.mensaje = "El campo Genero no puede estar vacío";
                    response.Estado = "Fallido";
                    response.response = false;
                }else if (this.NumeroPaginas == 0)
                {
                    response.mensaje = "El campo NumeroPaginas no puede estar vacío o ser cero";
                    response.Estado = "Fallido";
                    response.response = false;
                }else if (this.autores.Count == 0)
                {
                    response.mensaje = "El campo autores no puede estar vacío";
                    response.Estado = "Fallido";
                    response.response = false;
                }else if (this.autores.Count > 0)
                {
                    foreach (var item in this.autores)
                    {
                        int pocision = this.autores.IndexOf(item);
                        if (string.IsNullOrEmpty(item.Nombres))
                        {
                            response.mensaje = $"El campo autores.Nombre de autores.[{pocision.ToString()}] no puede estar vacío";
                            response.Estado = "Fallido";
                            response.response = false;
                            return response;
                        } else if (string.IsNullOrEmpty(item.Apellidos))
                        {
                            response.mensaje = $"El campo autores.Apellido de autores.[{pocision.ToString()}] no puede estar vacío";
                            response.Estado = "Fallido";
                            response.response = false;
                            return response;
                        } else if (string.IsNullOrEmpty(item.FechaNacimiento))
                        {
                            response.mensaje = $"El campo autores.FechaNacimiento de autores.[{pocision.ToString()}] no puede estar vacío";
                            response.Estado = "Fallido";
                            response.response = false;
                            return response;
                        } else if (string.IsNullOrEmpty(item.Apellidos))
                        {
                            response.mensaje = $"El campo autores.Apellido de autores.[{pocision.ToString()}] no puede estar vacío";
                            response.Estado = "Fallido";
                            response.response = false;
                            return response;
                        } else if (string.IsNullOrEmpty(item.CiudadProcedencia))
                        {
                            response.mensaje = $"El campo autores.CiudadProcedencia de autores.[{pocision.ToString()}] no puede estar vacío";
                            response.Estado = "Fallido";
                            response.response = false;
                            return response;
                        } else if (string.IsNullOrEmpty(item.Email))
                        {
                            response.mensaje = $"El campo autores.Apellido de autores.[{pocision.ToString()}] no puede estar vacío";
                            response.Estado = "Fallido";
                            response.response = false;
                            return response;
                        }
                    }
                    
                }

                return response;
            }
            catch (Exception ex)
            {
                response.mensaje = "Error al validar los datos básicos del libro";
                response.excepcion = ex.InnerException.Message;
                response.Estado = "Fallido";
                return response;
            }
        }

        public Response GuardarLibro()
        {
            Response response = new Response();
            DTOLibros dTOLibros = new DTOLibros();
            response = dTOLibros.InsertarLibro(this.Titulo,this.Año,this.IdGenero,this.NumeroPaginas,this.autores);
            return response;
        }

        public Response ListarLibro(int Id)
        {
            Response response = new Response();
            DTOLibros dTOLibros = new DTOLibros();
            response = dTOLibros.ListarLibro(Id);
            return response;
        }
    }
}