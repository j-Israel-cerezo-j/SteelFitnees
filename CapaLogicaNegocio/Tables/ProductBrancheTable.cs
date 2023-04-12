using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogicaNegocio.Tables
{
    public class ProductBrancheTable
    {
        private ProductBrancheData productBrancheData = new ProductBrancheData();
        public DataTable table()
        {
            return productBrancheData.tableProductBranches();
        }
        public DataTable ByIdProduct(int id)
        {
            return productBrancheData.tableProductBranchesByIdProduct(id);
        }
        public DataTable ByIdBranche(int id)
        {
            return productBrancheData.tableProductBranchesByIdBranche(id);
        }
        public DataTable ByCharacters(string characters)
        {
            return productBrancheData.tableProductBranchesByCharacters(characters);
        }
    }
}
