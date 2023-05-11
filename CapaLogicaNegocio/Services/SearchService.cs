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
        private const string wordSingIn = "INICIAR SESION";
        private SearchTable searchTable= new SearchTable(); 
        public List<string> onkeyupSearchListMasterSeeker(string caracteres)
        {
            bool banProduct = false;
            bool banBrance = false;
            bool banSingIn= false;
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
            for (int i = 0; i < caracteres.Length; i++)
            {
                if (wordSingIn.Contains(caracteres.ToUpper()[i]))
                {
                    banSingIn = true;
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
            if (banSingIn)
            {
                listCoincidences.Add(wordSingIn.ToLower());
            }
            return listCoincidences;

        }
        public string urlRederictByCharacterMasterSeeker(string caracteres)
        {            
            string result = "%" + caracteres + "%";
            var response = new Dictionary<string, string>();


           
            int caracteresSimilaresProductos = 0;
            int caracteresSimilaresSucursales = 0;
            int caracteresSimilaresSingIn= 0;

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
                if (caracteres.Length<=wordSingIn.Length)
                {
                    if (caracteres.ToUpper()[i] == wordSingIn[i])
                    {
                        caracteresSimilaresSingIn++;
                    }
                }
            }
            if (caracteresSimilaresProductos > caracteresSimilaresSucursales)
            {
                if (caracteresSimilaresProductos >= 3)
                {
                    response.Add("url", "allProducts.aspx");
                    return Converter.ToJson(response);
                }
            }
            else
            {
                if (caracteresSimilaresSucursales >= 3)
                {

                    response.Add("url", "allBranches.aspx");
                    return Converter.ToJson(response);
                }
            }
            if (caracteresSimilaresSingIn>=7)
            {
                response.Add("url", "Login.aspx");
                return Converter.ToJson(response);
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
