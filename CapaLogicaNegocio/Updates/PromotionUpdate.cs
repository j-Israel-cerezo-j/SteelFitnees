using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Updates
{
    public class PromotionUpdate
    {
        private PromotionData promotionData = new PromotionData();
        public bool update(int id,bool checkPromotion)
        {
            return promotionData.update(id, checkPromotion);
        }
        public bool updateBrancheInPromotionBranchByPromotion(int idPromotion, int idBranch)
        {
            return promotionData.updatePromotionBranchByPromotion(idPromotion, idBranch);
        }
    }
}
