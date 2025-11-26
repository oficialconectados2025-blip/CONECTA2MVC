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

namespace CONECTA2MVC.Negocio.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _rep;

        public UsuarioService(IGenericRepository<Usuario> rep)
        {
            _rep = rep;
        }

        public Task<Usuario?> Actualizar(Usuario entidad, Stream? img = null, string? nombreArchivoImg = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> Lista()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> Login(string nombreUsuario, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> ObtenerPorNombreUsuario(string nombreUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> Registrar(Usuario entidad, Stream? img = null, string? nombreArchivoImg = null)
        {
            throw new NotImplementedException();
        }
    }
}
