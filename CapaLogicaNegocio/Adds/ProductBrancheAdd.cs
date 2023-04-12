using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Adds
{
    public class ProductBrancheAdd
    {
        private ProductBrancheData productBrancheData = new ProductBrancheData();
        public bool add(ProductBranch productBranch)
        {
            return productBrancheData.add(productBranch);
        }

    }
}
