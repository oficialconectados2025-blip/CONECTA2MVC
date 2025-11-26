using CONECTA2MVC.Entidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONECTA2MVC.Negocio.Interfaces
{
    public interface ITutorialesService
    {

        Task<List<Tutoriale>> Lista();
        Task<Tutoriale> Crear(Tutoriale entidad);
        Task<bool> Editar(int id);
        Task<bool> Eliminar(int id);
        Task<IQueryable<Tutoriale>> ListaTodos();
        Task<Tutoriale> ObtenerPorNombre(string nombre);

    }
}
