using CapaLogicaNegocio.Tables;
using CapaLogicaNegocio.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ExceptionDao;
using CapaLogicaNegocio.Exceptions;
using System.IO;
using CapaEntidades;

namespace CapaLogicaNegocio.Services
{
    public class SearchService
    {   private SearchTable searchTable= new SearchTable(); 
        public List<string> onkeyupSearchList(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            return Converter.ToList(searchTable.searchCoincidencesPrincipal(caracteres));

        }
        public string urlRederictByCharacterSought(string caracteres)
        {
            var response = new Dictionary<string, string>();
            try
            {                
                var idBranche= searchTable.idBrancheByCharacteres(caracteres);                
                response.Add("url", "showBranchesDetails.aspx?id="+idBranche);
                return Converter.ToJson(response);
            }catch (ExceptionDao ed)
            {
                try
                {
                    var idProduct=searchTable.idProductByCharacteres(caracteres);
                    response.Add("url", "productsByBranche.aspx?id=" + idProduct);
                    return Converter.ToJson(response);
                }
                catch (ExceptionDao ex) {
                    throw new ServiceException(ex.getMessage());
                }

            }
        }
    }
}
