using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaNexox.Entidades.ELibros;
using PruebaNexox.Entidades.Api;

namespace PruebaNexox.Interfaces.ILibros
{
    public interface ILibro
    {
        Response ValidarLibros();
        Response GuardarLibro();
        Response ListarLibro(int Id);
    }
}
