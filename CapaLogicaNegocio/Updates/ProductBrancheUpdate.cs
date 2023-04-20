using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Updates
{
    public class ProductBrancheUpdate
    {
        private ProductBrancheData productBrancheData = new ProductBrancheData();
        public bool update(ProductBranch productoBranche)
        {
            return productBrancheData.update(productoBranche);
        }
    }
}
