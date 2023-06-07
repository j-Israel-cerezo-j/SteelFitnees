using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Adds
{
    public class PromotionAdd
    {
        private PromotionData promotionData=new PromotionData();
        public int addPromotion(Promotion promotion)
        {
            return promotionData.add(promotion);
        }
        public bool addPromotionBranch(int idBranche,int idPromotion)
        {
            return promotionData.addPromotionBranch(idBranche,idPromotion);
        }
    }
}
