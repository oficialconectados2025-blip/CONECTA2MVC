using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONECTA2MVC.Negocio.Interfaces
{
    public interface IBase64IMGService
    {
        Task<string> GuardarImagen(Stream archivoStream, string tipoRecurso, string nombreArchivo);
        Task<string> ConvertToBase64(string tipoRecurso, string nombreArchivo);
        Task<string> ActualizarImagen(Stream archivoStream, string tipoRecurso, string nombreArchivo);
        Task<string> EliminarStorage(string tipoRecurso, string nombreArchivo);

    }
}
