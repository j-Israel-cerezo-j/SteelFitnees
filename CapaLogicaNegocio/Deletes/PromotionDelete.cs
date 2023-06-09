using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Deletes
{
    public class PromotionDelete
    {
        private PromotionData promotionData = new PromotionData();
        public bool delete(string strIds)
        {
            return promotionData.delete(strIds);
        }

        public bool promotionBrachByidPromotionDelete(int idPromotion)
        {
            return promotionData.deletePrmotionsBranche(idPromotion);
        }
    }
}
