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

        Task<List<Usuario>> Lista();
        Task<Usuario> Crear(Usuario entidad);
        Task<bool> Editar(Usuario entidad);
        Task<bool> Eliminar(int id);
        Task<IQueryable<Usuario>> ObtenerTodo();

        Task<Usuario> ObtenerPorNombre(string nombre);
        //Task<bool> Inhabilitar(int id); // esto es para futuro

    }
}
