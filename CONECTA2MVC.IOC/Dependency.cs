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
using CONECTA2MVC.Entidad.Models.Opciones;
using Microsoft.Extensions.Options;

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
            serv.AddScoped<IBase64IMGService, Base64IMGService>();

            // --------------------------------------
            // CONFIGURACIONES (Options Pattern)
            // Configuración general de rutas, tamaños y formatos
            // para almacenamiento de imágenes, videos y archivos.
            // --------------------------------------
            serv.Configure<storageOptions>(opt =>
            {
                // Url base
                opt.PublicBaseUrl = "/CONECTA2IMGS";
                
                opt.RutasBase = new Dictionary<string, string> 
                {

                    {"imagen-usuario", @"C:\Users\Jonathan\...\Usuarios" },
                    {"imagen-curso", @"C:\Users\Jonathan\...\Curso" },
                    {"video-tutoriales", @"C:\Users\Jonathan\...\Tutoriales"},
                    { "recurso-unidad", @"C:\Users\Jonathan\...\Unidad" }

                };

                opt.FormatosPermitidos = new Dictionary<string, string[]>
                {

                    {"imagen-usuario", new [] { "jpg", "jpeg", "svg", "png" } },
                    { "video-curso", new [] {"mp4", "webm"} },
                    { "video-tutoriales", new [] {"mp4", "webm"} },
                    { "recurso-unidad", new [] {"pdf", "docx"} }

                };

                opt.TamañosMaximosMb = new Dictionary<string, int>
                {

                    { "imagen-usuario", 10 },
                    { "video-curso", 500 },
                    { "video-tutorial", 350 },
                    { "recurso-unidad", 20 }

                };

            });

        }
    }
}
