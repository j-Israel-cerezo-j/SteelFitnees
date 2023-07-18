using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaLogicaNegocio.utils
{
    public  class Pathh
    {
        public static string pathImag()
        {
            string pathRelative = "../../../gentelella-master/production/images/perzonalizadas/";
            return HttpContext.Current.Server.MapPath(pathRelative);
        }
        
    }
}
