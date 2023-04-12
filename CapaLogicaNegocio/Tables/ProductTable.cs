using CapaDatos;
using CapaLogicaNegocio.RecoverData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Tables
{
    public  class ProductTable
    {
        private ProductData producData =new ProductData();
        public DataTable ByIdBranche(int id) {
            return producData.tableProductsByIdBranche(id);
        }
        public DataTable ByIdBrancheAndCharacteres(int id,string characteres)
        {
            return producData.tableProductsByIdBrancheAndCharacteres(id, characteres);
        }
        public DataTable listPorducrsByCharacters(string characters)
        {
            return producData.listProductsByCharacters(characters);
        }
        public DataTable listProductsByCharactersAndIdBranche(string characters,int id)
        {
            return producData.listProductsByCharactersAndIdBranche(characters, id);
        }
    }
}
