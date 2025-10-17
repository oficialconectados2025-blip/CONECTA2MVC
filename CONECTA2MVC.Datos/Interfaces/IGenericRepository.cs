using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace CONECTA2MVC.Datos.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filt);
        Task<TEntity> Crear(TEntity entidad);
        Task<bool> Eliminar(TEntity entidad);
        Task<bool> Editar(TEntity entidad);
        Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filt = null);
    }
}
