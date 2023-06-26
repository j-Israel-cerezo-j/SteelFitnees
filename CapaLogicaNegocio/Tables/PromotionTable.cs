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
        public DataTable tableAllVisibility(int visibility)
        {
            return promotionData.lisAllPromotionsVisibility(visibility);
        }
        public DataTable tableVisivilityByBranche(int idBranche,int visivility)
        {
            return promotionData.lisAllPromotionsVisivilityByBranche(idBranche, visivility);
        }
        public DataTable listAllPromotionsByCharacteres(string characteres)
        {
            return promotionData.listAllPromotionsByCharacteres(characteres);
        }
        public DataTable tableByBranche(int idBranche)
        {
            return promotionData.lisAllPromotionsByBranche(idBranche);
        }
        public DataTable tableNoBranche()
        {
            return promotionData.lisAllPromotionsNoBranche();
        }

    }
}
