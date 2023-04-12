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
    {   private SearchTable searchTable= new SearchTable(); 
        public List<string> onkeyupSearchList(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            return Converter.ToList(searchTable.searchCoincidencesPrincipal(caracteres));

        }
        public string urlRederictByCharacterSought(string caracteres)
        {            
            string result = "%" + caracteres + "%";
            var response = new Dictionary<string, string>();                                   
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
                    response.Add("url", "productsByBranche.aspx?id=" + idProduct + "&characters=" + caracteres);
                    return Converter.ToJson(response);
                }
                else
                {
                    const string productoWordProduct = "PRODUCTOS";
                    const string productoWordBranche = "SUCURSALES";
                    int caracteresSimilaresProductos = 0;
                    int caracteresSimilaresSucursales = 0;
                    int caracteresDiferentesProductos = 0;
                    int caracteresDiferentesSucursales = 0;

                    foreach (char c in caracteres.ToUpper())
                    {
                        if (productoWordProduct.Contains(c))
                        {
                            caracteresSimilaresProductos++;
                        }
                        else
                        {
                            caracteresDiferentesProductos++;
                        }
                        if (productoWordBranche.Contains(c))
                        {
                            caracteresSimilaresSucursales++;
                        }
                        else
                        {
                            caracteresDiferentesSucursales++;
                        }

                    }
                    if (caracteresSimilaresProductos > caracteresSimilaresSucursales)
                    {
                        if (caracteresSimilaresProductos >= 6)
                        {
                            response.Add("url", "allProducts.aspx");
                            return Converter.ToJson(response);
                        }
                    }
                    else if (caracteresSimilaresProductos < caracteresSimilaresSucursales)
                    {
                        if (caracteresSimilaresSucursales >= 6)
                        {
                            response.Add("url", "allBranches.aspx");
                            return Converter.ToJson(response);
                        }
                    }
                }
                throw new ServiceException(MessageErrors.MessageErrors.searchNotFoundPleaseBeMoreSpecific);
            }
        }
    }
}
