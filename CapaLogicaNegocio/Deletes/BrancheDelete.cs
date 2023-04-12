using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Deletes
{
    public class BrancheDelete
    {
        private BrancheData brancheData = new BrancheData();
        public bool delete(string strIds)
        {
            return brancheData.delete(strIds);
        }
    }
}
