using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.DTO
{
    public class PromotionDTO
    {
        public string id { get; set; }
        public string promotionName { get; set; }
        public List<string> branches { get; set; }
        public string check { get; set; }
    }
}
