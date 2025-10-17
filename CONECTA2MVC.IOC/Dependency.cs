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
using CONECTA2MVC.Negocio.Interfaces;
using CONECTA2MVC.Negocio.Implementaciones;

namespace CONECTA2MVC.IOC
{
    public static class Dependency
    {
        public static void InyectarDependencia(this IServiceCollection serv, IConfiguration config)
        {

            //Dependencia de conexion de Base de Datos
            serv.AddDbContext<DBContextConecta2>(options =>
            {

                options.UseNpgsql(config.GetConnectionString("CadenaPgAdmin"));

            });

            //Dependencia generica CRUD general
            serv.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Dependencias CRUD personalizadas
            serv.AddScoped<IRolService, RolService>();

        }
    }
}
