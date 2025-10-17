using CONECTA2MVC.Entidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONECTA2MVC.Negocio.Interfaces
{
    public interface IRolService
    {

        Task<List<Rol>> Lista();

    }
}
