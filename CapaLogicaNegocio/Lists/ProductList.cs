using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Lists
{
    public class ProductList
    {
        ProductData productData = new ProductData();
        ProductBrancheData productBrancheData = new ProductBrancheData();

        public List<Product> listProduct()
        {
            return productData.listProduct();
        }
        public List<ProductBranch> listProductBranches() {
            return productBrancheData.listProductBranches();
        }
        public List<Product> listProductByCharacters(string characters)
        {
            return productData.listProductByCharacters(characters);
        }
    }
}
