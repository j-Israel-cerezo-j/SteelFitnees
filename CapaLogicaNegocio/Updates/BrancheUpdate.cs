using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Updates
{
    public class BrancheUpdate
    {
        private BrancheData brancheData = new BrancheData();
        public bool update(Branche branche)
        {
            return brancheData.update(branche);
        }
    }
}
