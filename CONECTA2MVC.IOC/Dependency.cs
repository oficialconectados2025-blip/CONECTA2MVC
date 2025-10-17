using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CONECTA2MVC.Datos.DBContextCONECTA2;
using Microsoft.EntityFrameworkCore;
using CONECTA2MVC.Datos.Interfaces;
using CONECTA2MVC.Datos.Implementaciones;

namespace CONECTA2MVC.IOC
{
    public static class Dependency
    {
        public static void InyectarDependencia(this IServiceCollection serv, IConfiguration config)
        {

            serv.AddDbContext<DBContextConecta2>(options =>
            {

                options.UseNpgsql(config.GetConnectionString("CadenaPgAdmin"));

            });

            serv.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }
    }
}
