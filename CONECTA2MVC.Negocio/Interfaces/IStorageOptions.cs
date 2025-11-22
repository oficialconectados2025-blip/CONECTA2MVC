using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONECTA2MVC.Negocio.Interfaces
{
    public interface IStorageOptions
    {

        public Dictionary<string, string> RutasBase { get; set; } = new();
        public Dictionary<string, string[]> FormatosPermitidos { get; set; } = new();
        public Dictionary<string, int> TamañosMaximosMb { get; set; } = new();
        public string? PublicBaseUrl { get; set; }

    }
}
