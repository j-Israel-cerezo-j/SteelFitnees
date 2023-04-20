using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Lists
{
    public class AboutUsList
    {
        private AboutUsData aboutUsData=new AboutUsData();
        public List<AboutUs> listAboutUs()
        {
            return aboutUsData.listAboutUs();
        }
    }
}
