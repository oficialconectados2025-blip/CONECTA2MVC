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
    public class TutorialesService : ITutorialesService
    {
        private readonly IGenericRepository<Tutoriale> _rep;

        public TutorialesService(IGenericRepository<Tutoriale> rep)
        {
            _rep = rep;
        }

        public  Task<Tutoriale> Crear(Tutoriale entidad)
        {
            //try
            //{
            throw new NotImplementedException();
            //}
            //catch(Exception ex) 
            //{
            //    throw ex.Message;
            //}
        }

        public Task<bool> Editar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tutoriale>> Lista()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Tutoriale>> ListaTodos()
        {
            throw new NotImplementedException();
        }

        public Task<Tutoriale> ObtenerPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
