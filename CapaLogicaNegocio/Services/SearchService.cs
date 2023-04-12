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
using CapaLogicaNegocio.MessageErrors;

namespace CapaLogicaNegocio.Services
{
    public class SearchService
    {
        private const string wordProduct = "PRODUCTOS";
        private const string wordBranche = "SUCURSALES";
        private SearchTable searchTable= new SearchTable(); 
        public List<string> onkeyupSearchListMasterSeeker(string caracteres)
        {
            bool banProduct = false;
            bool banBrance = false;
            string caracteresResult = "%" + caracteres + "%";
            var listCoincidences=Converter.ToList(searchTable.searchCoincidencesPrincipal(caracteresResult));
            for (int i = 0; i < caracteres.Length; i++)
            {
                if (wordProduct.Contains(caracteres.ToUpper()[i]))
                {                    
                    banProduct =true;
                    break;
                }                
            }
            for (int i = 0; i < caracteres.Length; i++)
            {
                if (wordBranche.Contains(caracteres.ToUpper()[i]))
                {                    
                    banBrance = true;
                    break;
                }
            }
            if (banProduct)
            {
                listCoincidences.Add(wordProduct.ToLower());
            }
            if (banBrance)
            {
                listCoincidences.Add(wordBranche.ToLower());
            }
            return listCoincidences;

        }
        public string urlRederictByCharacterMasterSeeker(string caracteres)
        {            
            string result = "%" + caracteres + "%";
            var response = new Dictionary<string, string>();


           
            int caracteresSimilaresProductos = 0;
            int caracteresSimilaresSucursales = 0;


            for (int i = 0; i < caracteres.Length; i++)
            {
                if (caracteres.Length <= wordProduct.Length)
                {
                    if (caracteres.ToUpper()[i] == wordProduct[i])
                    {
                        caracteresSimilaresProductos++;
                    }
                }
                if (caracteres.Length <= wordBranche.Length)
                {
                    if (caracteres.ToUpper()[i] == wordBranche[i])
                    {
                        caracteresSimilaresSucursales++;
                    }
                }

            }
            if (caracteresSimilaresProductos > caracteresSimilaresSucursales)
            {
                if (caracteresSimilaresProductos >= 4)
                {
                    response.Add("url", "allProducts.aspx");
                    return Converter.ToJson(response);
                }
            }
            else
            {
                if (caracteresSimilaresSucursales >= 4)
                {

                    response.Add("url", "allBranches.aspx");
                    return Converter.ToJson(response);
                }
            }
            var idBranche = searchTable.idBrancheByCharacteres(result);
            if (idBranche != -1)
            {
                response.Add("url", "showBranchesDetails.aspx?id=" + idBranche);
                return Converter.ToJson(response);
            }
            else
            {
                var idProduct = searchTable.idProductByCharacteres(result);
                if (idProduct!=-1)
                {
                    response.Add("url", "allProducts.aspx?characters=" + caracteres);
                    return Converter.ToJson(response);
                }
                else
                {
                   
                }
                throw new ServiceException(MessageErrors.MessageErrors.searchNotFoundPleaseBeMoreSpecific);
            }
        }
    }
}
