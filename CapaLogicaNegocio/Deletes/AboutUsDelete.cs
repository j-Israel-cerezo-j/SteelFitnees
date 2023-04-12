using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Deletes
{
    public class AboutUsDelete
    {
        private AboutUsData aboutUsData=new AboutUsData();
        public bool delete(string ids)
        {
            return aboutUsData.delete(ids);
        }
    }
}
