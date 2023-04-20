using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
namespace CapaLogicaNegocio.Updates
{
    public class ProductUpdate
    {
        private ProductData productData = new ProductData();
        public bool productUpdate(Product product)
        {
            return productData.update(product);
        }
    }
}
