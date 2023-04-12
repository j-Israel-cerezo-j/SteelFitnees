using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Updates
{
    public  class AboutUsUpdate
    {
        AboutUsData aboutUsData=new AboutUsData();  
        public bool update(AboutUs aboutUs)
        {
            return aboutUsData.update(aboutUs);
        }
    }
}
