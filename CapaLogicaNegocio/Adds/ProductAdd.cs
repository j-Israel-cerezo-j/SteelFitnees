using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
namespace CapaLogicaNegocio.Adds
{
    public class ProductAdd
    {
        private ProductData productData = new ProductData();
        public bool add(Product product)
        {
            return productData.add(product);
        }
    }
}
