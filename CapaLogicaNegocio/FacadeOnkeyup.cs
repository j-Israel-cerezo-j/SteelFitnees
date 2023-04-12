using CapaLogicaNegocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.Exceptions;
namespace CapaLogicaNegocio
{
    public class FacadeOnkeyup
    {
        private BrancheSerevice brancheSerevice = new BrancheSerevice();
        private DayService dayService = new DayService();
        private HoursService hoursService = new HoursService();
        private ProductService productService = new ProductService();
        private ProductBranchService branchService = new ProductBranchService();
        private SearchService searchService = new SearchService();  
        public List<string> coincidences(string catalogo, string caracteres,string strId="")
        {
            char[] charsToTrim = { ' ' };
            string result = caracteres.Trim(charsToTrim);            
            switch (catalogo)
            {
                case "sucursales":
                    return brancheSerevice.onkeyupSearchList(result);
                case "dias":
                    return dayService.onkeyupSearchList(result);
                case "horas":
                    return hoursService.onkeyupSearchList(result);
                case "productos":
                    return productService.onkeyupSearchList(result);
                case "productBranche":
                    return branchService.onkeyupSearchList(result);
                case "productsByBrancheAndCharacteres":
                    return productService.onkeyupSearchListByCharacteresAndIdBranche(result,strId);
                case "searchMaster":
                    return searchService.onkeyupSearchList(result);
                default:
                    throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);
            }
        }
        public string tables(string catalogo, string caracteres,string strId="")
        {
            char[] charsToTrim = { ' ' };
            string result = caracteres.Trim(charsToTrim);
            result = "%" + result + "%";
            switch (catalogo)
            {
                case "sucursales":
                    return brancheSerevice.onkeyupSearchTable(result);
                case "dias":
                    return dayService.onkeyupSearchTable(result);
                case "horas":
                    return hoursService.onkeyupSearchTable(result);
                case "productos":
                    return productService.onkeyupSearchTable(result);
                case "productBranche":
                    return branchService.onkeyupSearchTable(result);
                case "productsByBrancheAndCharacteres":
                    return productService.onkeyupSearchTableByIdBrancheAndCharacteres(result, strId);
                default:
                    throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);
            }
        }
        public string comments(string catalogo, string caracteres, string id)
        {
            char[] charsToTrim = { ' ' };
            string result = caracteres.Trim(charsToTrim);
            switch (catalogo)
            {
                case "commentsCharacteres":
                    return brancheSerevice.onkeyupCommentsByIdBranchesAndCharacteres(id, result);

                default:
                    throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);
            }
        }
        public string searchUrlBySearch(string catalogo, string caracteres)
        {
            char[] charsToTrim = { ' ' };
            string resultTrim = caracteres.Trim(charsToTrim);
            string result="%"+resultTrim+"%";
            switch (catalogo)
            {
                case "actionSearchubmit":
                    return searchService.urlRederictByCharacterSought(result);

                default:
                    throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);
            }
        }
    }
}
