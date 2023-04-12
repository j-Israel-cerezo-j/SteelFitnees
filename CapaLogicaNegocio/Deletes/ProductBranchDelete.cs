using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Deletes
{
    public class ProductBranchDelete
    {
        private ProductBrancheData productBrancheData = new ProductBrancheData();
        public bool delete(string ids)
        {
            return productBrancheData.delete(ids);
        }
    }
}
