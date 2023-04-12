using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Tables
{
    public class SearchTable
    {
        SearchData searchData = new SearchData();
        public DataTable searchCoincidencesPrincipal(string characters)
        {
            return searchData.searchCoincidencesPrincipal(characters);
        }
        public int idBrancheByCharacteres(string characters)
        {
            return searchData.idBrancheByCharacteres(characters);
        }
        public int idProductByCharacteres(string characters)
        {
            return searchData.idProductByCharacteres(characters);
        }
    }
}
