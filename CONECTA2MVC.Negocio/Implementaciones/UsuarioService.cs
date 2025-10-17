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

        public async Task<Usuario> Crear(Usuario entidad)
        {
            
            var existe = (await _rep.Consultar(u => u.Nombreusuario == entidad.Nombreusuario)).Any();

            if(existe)
            {
                throw new Exception("Este usuario ya existe");
            }
            else
            {

                return await _rep.Crear(entidad);

            }


        }

        public async Task<bool> Editar(Usuario entidad)
        {
            return await _rep.Editar(entidad);
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {

                Usuario usuario_encontrado = await _rep.Obtener(u => u.Id == id); 

                if(usuario_encontrado == null)
                {

                    throw new TaskCanceledException("El usuario no existe");

                }

                bool repuesta = await _rep.Eliminar(usuario_encontrado);

                return repuesta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Inhabilitar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> Lista()
        {
            try
            {

                IQueryable<Usuario> query = await _rep.Consultar();
                return query.Include(r => r.IdrolNavigation).ToList();

            }
            catch (Exception ex) 
            { 
                throw new NotImplementedException(); 
            }
        }

        public Task<Usuario> ObtenerPorNombre(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Usuario>> ObtenerTodo()
        {
            throw new NotImplementedException();
        }
    }
}
