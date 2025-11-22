using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONECTA2MVC.Negocio.Interfaces
{
    public interface IStorageOptions
    {
        Dictionary<string, string> RutasBase { get; set; }
        Dictionary<string, string[]> FormatosPermitidos { get; set; }
        Dictionary<string, int> TamañosMaximosMb { get; set; }
        string? PublicBaseUrl { get; set; }
    }
}
