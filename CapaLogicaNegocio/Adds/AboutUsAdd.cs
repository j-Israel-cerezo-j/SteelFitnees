using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Adds
{
    internal class AboutUsAdd
    {
        private AboutUsData aboutUsData = new AboutUsData();
        public bool add(AboutUs aboutUs)
        {
            return aboutUsData.add(aboutUs);
        }
    }
}
