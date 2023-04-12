using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.RecoverData
{
    public class ProductBranchRecoverData
    {
        private ProductBrancheData productBrancheData = new ProductBrancheData();
        public ProductBranch dataProductBranchByIdRecord(int id)
        {
            return productBrancheData.dataProductBrachByIdRegistro(id);
        }
    }
}
