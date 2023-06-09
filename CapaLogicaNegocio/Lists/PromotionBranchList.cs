using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Lists
{
    public class PromotionBranchList
    {
        PromotionData promotionData = new PromotionData();
        public List<PromotionBranch> listPromotionsBranch()
        {
            return promotionData.listPromotionBranch();
        }
    }
}
