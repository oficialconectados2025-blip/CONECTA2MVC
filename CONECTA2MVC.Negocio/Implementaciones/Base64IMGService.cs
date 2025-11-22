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

                string basePublica = (_opt.PublicBaseUrl ?? string.Empty).TrimEnd('/');
                string url = string.IsNullOrWhiteSpace(basePublica)
                    ? $"/{tipoRecurso}/{nombreSeguro}"
                    : $"/{basePublica}/{tipoRecurso}/{nombreSeguro}";

                return url;

            }
            catch (Exception ex)
            {
                return $"Error al guardar la imagen: {ex.Message}";
            }
        }

        public async Task<string> ConvertToBase64(string tipoRecurso, string nombreArchivo)
        {
            try
            {

                if(string.IsNullOrWhiteSpace(tipoRecurso) || !_opt.RutasBase.ContainsKey(tipoRecurso))
                {

                    return $"No existe configuracion para el recurso: '{tipoRecurso}'.";

                }

                string rutaBase = _opt.RutasBase[tipoRecurso];
                string rutaFisica = Path.Combine(rutaBase, nombreArchivo);

                if (!File.Exists(rutaFisica))
                {

                    return "El archivo no existe";

                }

                byte[] bytes = await File.ReadAllBytesAsync(rutaFisica);
                return Convert.ToBase64String(bytes);

            }
            catch (Exception ex)
            {

                return $"Error al convertir la imagen a base64: {ex.Message}";
            
            }
        }

        public  Task<string> ActualizarImagen(Stream archivoStream, string tipoRecurso, string nombreArchivo)
        {

            // First try to delete the img (if doesn't exist it isn't critical)
            //await EliminarStorage(tipoRecurso, nombreArchivo);
            throw new NotImplementedException();
            // Save again
            //return await GuardarImagen


        }

        public Task<string> EliminarStorage(string CarpetaDestino, string NombreArchivo)
        {
            throw new NotImplementedException();
        }

    }
}
