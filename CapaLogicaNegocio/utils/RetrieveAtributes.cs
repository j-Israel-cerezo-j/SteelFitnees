using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.utils
{
    public class RetrieveAtributes
    {
        public static string values(Dictionary<string, string> request, string campo)
        {                        
            return request.Keys.Contains(campo) ? request[campo] : "";
        }
    }
}
