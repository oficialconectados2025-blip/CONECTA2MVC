using CONECTA2MVC.Entidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONECTA2MVC.Negocio.Interfaces
{
    public interface IUsuarioService
    {
        // CRUD básico
        Task<List<Usuario>> Lista();                      // Read: lista
        Task<Usuario?> Registrar(Usuario entidad, Stream? img = null, string? nombreArchivoImg = null); // Create
        Task<Usuario?> Actualizar(Usuario entidad, Stream? img = null, string? nombreArchivoImg = null); // Update
        Task<bool> Eliminar(int id);                      // Delete

        // Lecturas específicas
        Task<Usuario?> ObtenerPorId(int id);
        Task<Usuario?> ObtenerPorNombreUsuario(string nombreUsuario);

        // Autenticación básica (sin 2FA todavía)
        Task<Usuario?> Login(string nombreUsuario, string password);
        //Task<bool> Inhabilitar(int id); // esto es para futuro

    }
}
