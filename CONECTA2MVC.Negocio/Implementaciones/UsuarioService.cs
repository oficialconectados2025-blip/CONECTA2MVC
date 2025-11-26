using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using CONECTA2MVC.Negocio.Interfaces;
using CONECTA2MVC.Datos.Interfaces;
using CONECTA2MVC.Entidad;
using CONECTA2MVC.Entidad.Models;
using System.Security.Cryptography;
using System.Linq.Expressions;

namespace CONECTA2MVC.Negocio.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _rep;
        private readonly IBase64IMGService _bs64img;

        public UsuarioService(IGenericRepository<Usuario> rep, IBase64IMGService bs64img)
        {
            _rep = rep;
            _bs64img = bs64img;
        }

        // ============================
        // Private Helpers
        // ============================

        private string HashSha256(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(text);
            var hash = sha.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }

        // ============================
        // Public Methods
        // ============================

        public async Task<List<Usuario>> Lista()
        {

            try
            {

                IQueryable<Usuario> query = await _rep.Consultar();

                return await query
                    .Include(u => u.IdrolNavigation)
                    .Include(u => u.IdidiomaNavigation)
                    .ToListAsync();

            }
            catch(Exception ex)
            {
                throw new Exception($"Error al listar usuarios: {ex.Message}", ex);
            }

        }

        public async Task<Usuario?> Registrar(Usuario entidad, Stream? img = null, string? nombreArchivoImg = null)
        {

            try
            {

                if (entidad == null) return null;

                // ¿Exist?

                var usuarioExist = await _rep.Obtener(

                    u => u.Nombreusuario == entidad.Nombreusuario

                );

                // Password hash
                entidad.Contrasenia = HashSha256(entidad.Contrasenia);

                // Imagen Usuario (Opcional)
                if(img != null && img.Length > 0 && !string.IsNullOrEmpty(nombreArchivoImg))
                {
                    string url = await _bs64img.GuardarImagen(
                        img,
                        "imagen-usuario",
                        nombreArchivoImg
                    );

                    if(!url.StartsWith("Error") && !url.StartsWith("No existe configuracion"))
                    {
                        entidad.Imgusuario = url;
                    }

                }

                entidad.Fecharegistro = DateTime.UtcNow;
                entidad.Fechamodificacion = DateTime.UtcNow;

                var creado = await _rep.Crear(entidad );
                return creado;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al registrar ususario: {ex.Message}", ex);
            }

        }

        public async Task<Usuario?> Actualizar(Usuario entidad, Stream? img = null, string? nombreArchivoImg = null)
        {

            try
            {

                if (entidad == null) return null;
                var usuarioDB = await _rep.Obtener(u => u.Id == entidad.Id);

                if(usuarioDB == null) return null;

                // Actualizamos campos basicos sin tocar contraseña
                usuarioDB.Primernombre = entidad.Primernombre;
                usuarioDB.Segundonombre = entidad.Segundonombre;
                usuarioDB.Primerapellido = entidad.Primerapellido;
                usuarioDB.Segundoapellido = entidad.Segundoapellido;
                usuarioDB.Nombreusuario = entidad.Nombreusuario;
                usuarioDB.Telefono = entidad.Telefono;
                usuarioDB.Descripcion = entidad.Descripcion;
                usuarioDB.Idrol = entidad.Idrol;
                usuarioDB.Ididioma = entidad.Ididioma;
                usuarioDB.Fechamodificacion = DateTime.UtcNow;

                // IMAGEN
                if(img != null && img.Length > 0 && !string.IsNullOrWhiteSpace(nombreArchivoImg))
                {
                    string nombreAnterior = Path.GetFileName(usuarioDB.Imgusuario);
                    await _bs64img.EliminarStorage("imagen-usuario", nombreAnterior);
                }

                string url = await _bs64img.GuardarImagen(
                    img,
                    "imagen-usuario",
                    nombreArchivoImg
                );

                if(!url.StartsWith("Error") && !url.StartsWith("No existe la configuracion."))
                {
                    usuarioDB.Imgusuario = url;
                }

                bool resp = await _rep.Editar(usuarioDB);
                return resp ? usuarioDB : null;

            }
            catch (Exception ex)
            {
                throw new Exception ($"Error a la hora de actualizar el usuario: {ex.Message}", ex);
            }

        }

        public async Task<bool> Eliminar(int id)
        {

            try
            {

                var usuarioDB = await _rep.Obtener(u => u.Id == id);

                if(!string.IsNullOrWhiteSpace(usuarioDB.Imgusuario))
                {
                    string nombreArchivo = Path.GetFileName(usuarioDB.Imgusuario);
                    await _bs64img.EliminarStorage("imagen-usuario", nombreArchivo);
                }

                return await _rep.Eliminar(usuarioDB);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar usuario: {ex.Message}");
            }

        }

        public async Task<Usuario?> Login(string nombreUsuario, string password)
        {

            try
            {

                string hash = HashSha256(password);

                var usuario = await _rep.Obtener(u => u.Nombreusuario == nombreUsuario && u.Contrasenia == hash);

                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar logearse: {ex.Message}", ex);
            }

        }

        public async Task<Usuario?> ObtenerPorId(int id)
        {

            try
            {

                return await _rep.Obtener(u => u.Id == id);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuario por ID: {ex.Message}");
            }

        }

        public async Task<Usuario?> ObtenerPorNombreUsuario(string nombreUsuario)
        {

            try
            {

                if (string.IsNullOrWhiteSpace(nombreUsuario)) return null;

                return await _rep.Obtener(u => u.Nombreusuario == nombreUsuario);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuario por nombre: {ex.Message}");
            }

        }

    }
}
