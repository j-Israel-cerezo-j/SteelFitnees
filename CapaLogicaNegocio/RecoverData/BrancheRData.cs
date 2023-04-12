using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos ;
namespace CapaLogicaNegocio.RecoverData
{
    public class BrancheRData
    {
        private BrancheData brancheData = new BrancheData();

        public Branche dataBrancheByIdBranche(int id)
        {
            return brancheData.dataBrancheByIdBranche(id);
        }
    }
}
