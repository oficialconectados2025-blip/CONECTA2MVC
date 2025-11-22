using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CONECTA2MVC.Datos;
using CONECTA2MVC.Negocio;
using CONECTA2MVC.Entidad;
using CONECTA2MVC.Negocio.Interfaces;
using CONECTA2MVC.Datos.DBContextCONECTA2;
using CONECTA2MVC.Datos.Interfaces;
using CONECTA2MVC.Entidad.Models.Opciones;
using Microsoft.Extensions.Options;
using CONECTA2MVC.Entidad.Models;
using Microsoft.Extensions.Logging;

namespace CONECTA2MVC.Negocio.Implementaciones
{
    public class Base64IMGService : IBase64IMGService
    {

        private readonly storageOptions _opt;

        public Base64IMGService(IOptions<storageOptions> options)
        {
            _opt = options.Value;
        }

        public async Task<string> GuardarImagen(Stream StreamArchivo, string tipoRecurso, string NombreArchivo)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(tipoRecurso) || !_opt.RutasBase.ContainsKey(tipoRecurso)){
                    return $"No existe configuracion para el recurso: {tipoRecurso}";
                }

                // Get baseRoute
                string rutaBase = _opt.RutasBase[tipoRecurso];

                // Size validation
                long maxBytes = long.MaxValue;
                if (_opt.TamañosMaximosMb != null && _opt.TamañosMaximosMb.ContainsKey(tipoRecurso))
                {
                    maxBytes = (long)_opt.TamañosMaximosMb[tipoRecurso] * 1024L * 1024L;
                }

                // Extension validation
                string[] formatos = Array.Empty<string>();
                if(_opt.FormatosPermitidos != null && _opt.FormatosPermitidos.ContainsKey(tipoRecurso))
                {
                    formatos = _opt.FormatosPermitidos[tipoRecurso];
                }

                // Normalize stream (in case it's not seekable)
                Stream streamParaGuardar = StreamArchivo;
                long lenght;
                if (StreamArchivo.CanSeek)
                {
                    lenght = StreamArchivo.Length;
                    StreamArchivo.Seek(0, SeekOrigin.Begin);
                } 
                else
                {
                    var ms = new MemoryStream();
                    await StreamArchivo.CopyToAsync(ms);
                    lenght = ms.Length;
                    ms.Position = 0;
                    streamParaGuardar = ms;
                }

                if(lenght > maxBytes)
                {
                    return $"El arhivo excede el tamaño maximo permitido.";
                }

                if (formatos.Length > 0)
                {
                    string ext = Path.GetExtension(NombreArchivo)?.TrimStart('.').ToLowerInvariant() ?? string.Empty;
                    if (!formatos.Any(f => string.Equals(f, ext, StringComparison.OrdinalIgnoreCase)))
                    {
                        return $"El formato '{ext}' no esta permitido para el recurso '{tipoRecurso}'. ";
                    }
                }

                Directory.CreateDirectory(rutaBase);

                string nombreSeguro = Path.GetFileName(NombreArchivo);
                string rutaFisica = Path.Combine(rutaBase, nombreSeguro);

                if(streamParaGuardar.CanSeek) streamParaGuardar.Seek(0, SeekOrigin.Begin);

                using (var fs = new FileStream(rutaFisica, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await streamParaGuardar.CopyToAsync(fs);
                }

                string basePublica = 

            }
            catch (Exception ex)
            {
                return $"Error al guardar la imagen: {ex.Message}";
            }
        }

        public Task<string> ActualizarImagen(Stream StreamArchivo, string CarpetaDestiono, string NombreArchivo)
        {
            throw new NotImplementedException();
        }

        public Task<string> ConvertToBase64(string CarpetaDestino, string NombreArchivo)
        {
            throw new NotImplementedException();
        }

        public Task<string> EliminarStorage(string CarpetaDestino, string NombreArchivo)
        {
            throw new NotImplementedException();
        }

    }
}
