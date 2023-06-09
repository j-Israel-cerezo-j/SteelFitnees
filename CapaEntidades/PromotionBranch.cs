using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;

namespace CapaEntidades
{
    public class PromotionBranch
    {
        public int fkBranche { get; set; }
        public int fkPromotion { get; set; }

        public PromotionBranch()
        {

        }
        public PromotionBranch(SqlDataReader renglon)
        {
            this.fkBranche = (int)(Validation.getValue(renglon, "fkBranche") ?? 0);
            this.fkPromotion = (int)(Validation.getValue(renglon, "fkPromotion") ?? 0);

        }

        override
        public string ToString()
        {
            return
                "fkBranche:'" + fkBranche + "', " +
                "fkPromotion:'" + fkPromotion + "'";                
        }
    }
}
