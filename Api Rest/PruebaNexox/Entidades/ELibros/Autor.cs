using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaNexox.Interfaces.ILibros;
using PruebaNexox.Entidades.Api;

namespace PruebaNexox.Entidades.ELibros
{
    public class Autor
    {
        public int? id { get; set; }
        public int? IdLibro { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string Email { get; set; }

        public Autor(string Nombres, string Apellidos, string FechaNacimiento,string CiudadProcedencia, string Email, int IdLibro = 0)
        {
            this.IdLibro = IdLibro;
            this.Nombres = Nombres;
            this.Apellidos = Apellidos;
            this.FechaNacimiento = FechaNacimiento;
            this.CiudadProcedencia = CiudadProcedencia;
            this.Email = Email;
        }
    }
}