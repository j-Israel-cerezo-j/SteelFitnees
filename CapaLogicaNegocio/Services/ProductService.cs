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
        public bool add(Dictionary<string, string> request, List<HttpPostedFile> filesList)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                Product product = new Product();
                product.Nombre = RetrieveAtributes.values(request, "product");
                product.Descripcion = RetrieveAtributes.values(request, "description");
                foreach (var file in filesList)
                {
                    string fileName = rd.Next(1, 100000000).ToString() + file.FileName;
                    product.imagen = Images.Save(file, "products", fileName);
                    product.filename = fileName;
                }               
                return productAdd.add(product);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
        public bool updateProduct(Dictionary<string, string> request, string strId, List<HttpPostedFile> filesList)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Product product = new Product();
                product.idProducto = Convert.ToInt32(strId);
                product.Nombre = RetrieveAtributes.values(request, "product");
                product.Descripcion = RetrieveAtributes.values(request, "description");
                foreach (var file in filesList)
                {
                    string fileName = rd.Next(1, 100000000).ToString() + file.FileName;
                    product.imagen = defineImagePath(request, file, fileName, product.idProducto);
                    product.filename = defineTheSourceOfTheFileName(file, "fileName", "Productos", "idProducto", product.idProducto.ToString(), fileName);
                }                
                return productUpdate.productUpdate(product);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
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
            var products = new List<Product>();
            products.Add(productData.dataProduct(Convert.ToInt32(strId)));
            return Converter.ToJson(products);
        }
        private string defineImagePath(Dictionary<string, string> request, HttpPostedFile file,string fileName,int idProduct)
        {
            string path = "";
            if (file == null || file.FileName == "")
            {
                path = RetrieveAtributes.values(request, "imageUploadAut");
            }
            else
            {
                string fileNameRe = (string)Select.findFieldWhere("fileName", "Productos", "idProducto", idProduct.ToString());
                Images.Delete("products", fileNameRe);
                path =Images.Save(file, "products", fileName);
            }
            return path;
        }
        protected string defineTheSourceOfTheFileName(HttpPostedFile file, string slcField, string table, string fieldWhere, string idUser,string fileName)
        {
            return file == null || file.FileName == "" ? retiveFileNameUser(slcField, table, fieldWhere, idUser) : fileName;
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
    }
}
