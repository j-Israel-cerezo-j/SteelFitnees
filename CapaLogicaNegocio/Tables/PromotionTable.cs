using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Tables
{
    public class PromotionTable
    {
        private PromotionData promotionData=new PromotionData();

        public DataTable table()
        {
            return promotionData.lisAllPromotions();
        }
        public DataTable tableAllVisibles()
        {
            return promotionData.lisAllPromotionsVisibles();
        }
        public DataTable tableVisiblesByBranche(int idBranche)
        {
            return promotionData.lisAllPromotionsVisiblesByBranche(idBranche);
        }
        public DataTable tableByBranche(int idBranche)
        {
            return promotionData.lisAllPromotionsByBranche(idBranche);
        }

    }
}
