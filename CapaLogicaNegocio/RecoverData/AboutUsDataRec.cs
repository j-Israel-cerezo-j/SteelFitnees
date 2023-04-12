using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.RecoverData
{
    public class AboutUsDataRec
    {
        private AboutUsData aboutUsData=new AboutUsData();
        public AboutUs dataProductBranchByIdRecord(int id)
        {
            return aboutUsData.dataAboudUsByIdRecord(id);
        }
    }
}
