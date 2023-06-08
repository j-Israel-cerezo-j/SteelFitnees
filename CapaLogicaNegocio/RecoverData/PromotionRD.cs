using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.RecoverData
{
    public class PromotionRD
    {
        private PromotionData promotionData = new PromotionData();
        public int idBrancheByPromotion(int id)
        {
            return promotionData.idBrancheByIdPromotions(id);
        }
    }
}
