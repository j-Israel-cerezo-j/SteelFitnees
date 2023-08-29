using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using Validaciones.utils;
using CapaLogicaNegocio.utils;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.Lists;
using CapaLogicaNegocio.Deletes;
using CapaLogicaNegocio.RecoverData;
using CapaLogicaNegocio.Updates;
using CapaLogicaNegocio.Tables;
using CapaLogicaNegocio.Selects;
using System.Web;
using System.IO;

namespace CapaLogicaNegocio.Services
{
    public class ProductService
    {
        private ProductAdd productAdd = new ProductAdd();
        private ProductList productList = new ProductList();
        private ProductDelete productDelete = new ProductDelete();
        private ProducData productData = new ProducData();
        private ProductUpdate productUpdate = new ProductUpdate();
        private ProductTable productTable = new ProductTable();
        private Random rd = new Random();

        public bool persistence(Dictionary<string, string> request, List<HttpPostedFile> filesList,string strId="")
        {           
            Images.validWrongSizeInImageName(filesList);
            Product product = new Product();
            product.Nombre = RetrieveAtributes.values(request, "product");
            product.Descripcion = RetrieveAtributes.values(request, "description");
            foreach (var file in filesList)
            {
                string fileName = rd.Next(1, 100000000).ToString() + file.FileName;
                product.imagen = defineImagePath(request, file, fileName, strId);
                product.filename = defineTheSourceOfTheFileName(file, "fileName", "Productos", "idProducto", strId, fileName);
            }

            if (strId != "")
            {
                product.idProducto = Convert.ToInt32(strId);
                isEmpty(product, nameof(product.idProducto));
                return productUpdate.productUpdate(product);                
            }
            isEmpty(product);
            return productAdd.add(product);
        }
        public string jsonProducts()
        {
            return Converter.ToJson(productList.listProduct()).ToString();
        }
        public string jsonProductsByIdBranche(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            return Converter.ToJson(productTable.ByIdBranche(Convert.ToInt32(strId))).ToString();
        }
        public string jsonProductsAllTable()
        {
            return Converter.ToJson(productTable.tableProductsAll(), "idProducto").ToString();
        }
        public string tableProductsAllByCharacteres(string caracteres)
        {
            return Converter.ToJson(productTable.tableProductsAllByCharacteres(caracteres)).ToString();
        }
        public List<string> coincidencesProductByCharacters(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            return Converter.ToList(productTable.coincidencesProductByCharacters(caracteres));

        }
        public bool deleteProducts(string strIds)
        {
            try
            {
                var idsList = Converter.ToList(strIds);
                var productsSchedules = productList.listProductBranches();
                for (int i = 0; i < productsSchedules.Count; i++)
                {
                    if (idsList.Contains(productsSchedules[i].fkProducto.ToString()))
                    {
                        throw new ServiceException(MessageErrors.MessageErrors.errorDeletePorductReference);
                    }
                }
                foreach (var item in idsList)
                {
                    string fileName = (string)Select.findFieldWhere("fileName", "Productos", "idProducto", item.ToString());
                    Images.Delete("products", fileName);
                }
                return productDelete.delete(strIds);
            }
            catch (ServiceException se)
            {
                throw new ServiceException(se.getMessage());
            }
            catch (Exception e)
            {
                throw new ServiceException(MessageErrors.MessageErrors.errorDeletingProduct);
            }            
        }
        public string jsonRecoverData(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var products = new List<Product>
            {
                productData.dataProduct(Convert.ToInt32(strId))
            };
            return Converter.ToJson(products);
        }
        private string defineImagePath(Dictionary<string, string> request, HttpPostedFile file,string fileName,string idProduct)
        {            
            if (file == null || file.FileName == "")
            {
                return  RetrieveAtributes.values(request, "imageUploadAut");
            }
            else
            {
                if (idProduct!="")
                {
                    string fileNameRe = (string)Select.findFieldWhere("fileName", "Productos", "idProducto", idProduct);
                    Images.Delete("products", fileNameRe);
                    return Images.Save(file, "products", fileName);
                }
                else
                {
                    return Images.Save(file, "products", fileName);
                }
            }
        }
        protected string defineTheSourceOfTheFileName(HttpPostedFile file, string slcField, string table, string fieldWhere, string idProduct,string fileName)
        {
            return file == null || file.FileName == "" ? (idProduct== "" ? fileName : retiveFileNameUser(slcField, table, fieldWhere, idProduct))  : fileName;
        }
        private string retiveFileNameUser(string field, string table, string fieldWhere, string idsUser)
        {
            return Select.findFieldWhere(field, table, fieldWhere, idsUser).ToString();
        }
        public List<string> onkeyupSearchList(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            return Converter.ToList(productTable.listPorducrsByCharacters(caracteres));

        }
        public List<string> onkeyupSearchListByCharacteresAndIdBranche(string caracteres,string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            caracteres = "%" + caracteres + "%";
            return Converter.ToList(productTable.listProductsByCharactersAndIdBranche(caracteres,Convert.ToInt32(strId)));

        }
        public string onkeyupSearchTableByIdBrancheAndCharacteres(string caracteres,string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            return Converter.ToJson(productTable.ByIdBrancheAndCharacteres(Convert.ToInt32(strId),caracteres)).ToString();

        }
        public string onkeyupSearchTable(string caracteres)
        {            
            return Converter.ToJson(productList.listProductByCharacters(caracteres)).ToString();

        }

        public string jsonProductsTableByPrices(string strPriceMin,string strPriceMax)
        {
            if(!Validation.numericalFormat(strPriceMin) || strPriceMin=="")
            {
                throw new ServiceException(MessageErrors.MessageErrors.formantIncorrectNumber);
            }
            if (!Validation.numericalFormat(strPriceMax)||strPriceMax=="")
            {
                throw new ServiceException(MessageErrors.MessageErrors.formantIncorrectNumber);
            }
            return Converter.ToJson(productTable.tableProductsByPrices(Convert.ToDecimal(strPriceMin),Convert.ToDecimal(strPriceMax)), "idProducto").ToString();
        }

        private void isEmpty(Product product,string id="")
        {
            var isEmptyWhitId = "";
            if (id!=null && id != "")
            {
                isEmptyWhitId = Validation.empty(product, nameof(product.idProducto));
            }
            else
            {
                isEmptyWhitId = Validation.empty(product);
            }

            if (isEmptyWhitId != null)
            {
                throw new ServiceException(isEmptyWhitId + MessageErrors.MessageErrors.isEmpty);
            }
        }
    }
}
