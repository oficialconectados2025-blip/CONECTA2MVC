using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CONECTA2MVC.Datos.DBContextCONECTA2;
using CONECTA2MVC.Datos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CONECTA2MVC.Datos.Implementaciones
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly DBContextConecta2 _context;

        public GenericRepository(DBContextConecta2 context)
        {

            _context = context;
            
        }

        public async Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filt = null)
        {

            IQueryable<TEntity> queryEntidad = filt == null ? _context.Set<TEntity>() : _context.Set<TEntity>().Where(filt);
            return queryEntidad;

        }

        public async Task<TEntity> Crear(TEntity entidad)
        {

            try
            {

                _context.Set<TEntity>().Add(entidad);
                await _context.SaveChangesAsync();
                return entidad;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> Editar(TEntity entidad)
        {
            try
            {

                _context.Update(entidad);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(TEntity entidad)
        {
            try
            {

                _context.Remove(entidad);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filt)
        {
            try
            {
                TEntity entidad = await _context.Set<TEntity>().FirstOrDefaultAsync(filt);
                return entidad;
            }  
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}

