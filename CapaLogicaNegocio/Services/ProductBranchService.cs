using CapaEntidades;
using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;
using CapaLogicaNegocio.Tables;
using CapaLogicaNegocio.Deletes;
using CapaLogicaNegocio.RecoverData;
using CapaLogicaNegocio.Updates;

namespace CapaLogicaNegocio.Services
{
    public class ProductBranchService
    {
        private ProductBrancheAdd productBrancheAdd=new ProductBrancheAdd();
        private ProductBrancheTable productBrancheTable=new ProductBrancheTable();
        private ProductBranchDelete branchDelete=new ProductBranchDelete();
        private ProductBranchRecoverData recoverData =new ProductBranchRecoverData();
        private ProductBrancheUpdate brancheUpdate=new ProductBrancheUpdate();
        public bool add(Dictionary<string, string> request)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                ProductBranch productBranch= buildObjProductBranch(request);
                return productBrancheAdd.add(productBranch);
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
        public bool deleteProductBranch(string strIds)
        {
            return branchDelete.delete(strIds);
        }
        private ProductBranch buildObjProductBranch(Dictionary<string, string> request)
        {
            ProductBranch productBranch = new ProductBranch();
            string strCantidad = RetrieveAtributes.values(request, "cantidad");
            string strPrecio = RetrieveAtributes.values(request, "precio");
            validateFormantCantidadPrecio(strCantidad,strPrecio);
            productBranch.cantidad = Convert.ToInt32(strCantidad);
            productBranch.precio = Convert.ToDecimal(strPrecio);

            string strSelectFkBranche = RetrieveAtributes.values(request, "branches");
            string strSelectFkProduct = RetrieveAtributes.values(request, "products");
            validateSelec(strSelectFkBranche);
            validateSelec(strSelectFkProduct);
            productBranch.fkProducto = Convert.ToInt32(strSelectFkProduct);
            productBranch.fkSucursal = Convert.ToInt32(strSelectFkBranche);
            return productBranch;
        }
        private void validateSelec(string select)
        {
            if (!Validation.Select(select))
            {
                throw new ServiceException(MessageErrors.MessageErrors.invalidSelectorIn());
            }
        }
        private void validateFormantCantidadPrecio(string cantidad,string precio)
        {
            if (!Validation.numericalFormat(cantidad))
            {
                throw new ServiceException(MessageErrors.MessageErrors.formantIncorrectNumber);
            }
        }
        public string jsonProductBrancheTable()
        {
            return Converter.ToJson(productBrancheTable.table()).ToString();
        }
        public string jsonProductBrancheTableByIdProduct(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            return Converter.ToJson(productBrancheTable.ByIdProduct(Convert.ToInt32(strId))).ToString();
        }
        public string jsonProductBrancheTableByIdBranche(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            return Converter.ToJson(productBrancheTable.ByIdBranche(Convert.ToInt32(strId))).ToString();
        }
        public string jsonRecoverData(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var hours = new List<ProductBranch>
            {
                recoverData.dataProductBranchByIdRecord(Convert.ToInt32(strId))
            };
            string jsonRecoerDtes = Converter.ToJson(hours);
            return jsonRecoerDtes;
        }
        public bool updateProductBranche(Dictionary<string, string> request, string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                ProductBranch productBranch = buildObjProductBranch(request);
                productBranch.idRegistro = Convert.ToInt32(strId);
                return brancheUpdate.update(productBranch);
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
        public List<string> onkeyupSearchList(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            return Converter.ToList(productBrancheTable.ByCharacters(caracteres));

        }
        public string onkeyupSearchTable(string caracteres)
        {
            var namesTypeDateTime = new List<string>() { "horaInicio", "horaCierre" };
            return Converter.ToJson(productBrancheTable.ByCharacters(caracteres)).ToString();

        }
    }
}
