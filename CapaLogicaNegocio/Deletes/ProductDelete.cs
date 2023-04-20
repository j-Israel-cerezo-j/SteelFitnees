using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
namespace CapaLogicaNegocio.Deletes
{
    public class ProductDelete
    {
        private ProductData productData = new ProductData();
        public bool delete(string ids)
        {
            return productData.delete(ids);
        }
    }
}
