using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
namespace CapaLogicaNegocio.RecoverData
{
    public class ProducData
    {
        private ProductData productData = new ProductData();
        public Product dataProduct(int id)
        {
            return productData.dataProductByIdProduct(id);
        }
    }
}
