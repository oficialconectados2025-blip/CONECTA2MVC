using CONECTA2MVC.Datos.Interfaces;
using CONECTA2MVC.Entidad.Models;
using CONECTA2MVC.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONECTA2MVC.Negocio.Implementaciones
{
    public class RolService : IRolService
    {

        private readonly IGenericRepository<Rol> _rep;

        public RolService(IGenericRepository<Rol> rep)
        {
            _rep = rep;
        }

        public async Task<List<Rol>> Lista()
        {

            IQueryable<Rol> query = await _rep.Consultar();
            return query.ToList();

        }
    }
}
