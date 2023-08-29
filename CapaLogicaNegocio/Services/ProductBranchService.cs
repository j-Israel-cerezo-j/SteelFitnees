﻿using CapaEntidades;
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
        public bool persistence(Dictionary<string, string> request,string strId="")
        {
            ProductBranch productBranch = buildObjProductBranch(request);
            if (strId == "")
            {
                isEmpty(productBranch);
                return productBrancheAdd.add(productBranch);
            }
            productBranch.idRegistro = Convert.ToInt32(strId);
            isEmpty(productBranch, nameof(productBranch.idRegistro));
            return brancheUpdate.update(productBranch);
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
            validateFormantCantidadPrecio(strCantidad, strPrecio);
            productBranch.cantidad = Convert.ToInt32(strCantidad);
            productBranch.precio = decimal.Parse(strPrecio,System.Globalization.CultureInfo.InvariantCulture);

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
            var recordDecial = new List<string>() { "precio" };
            return Converter.ToJson(productBrancheTable.table(),false,null, recordDecial).ToString();
        }
        public string jsonProductBrancheTableByIdProduct(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var recordDecial = new List<string>() { "precio" };
            return Converter.ToJson(productBrancheTable.ByIdProduct(Convert.ToInt32(strId)), false, null, recordDecial).ToString();
        }
        public string jsonProductBrancheTableByIdBranche(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var recordDecial = new List<string>() { "precio" };
            return Converter.ToJson(productBrancheTable.ByIdBranche(Convert.ToInt32(strId)), false, null, recordDecial).ToString();
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

        private void isEmpty(ProductBranch productBranch, string id = "")
        {
            var isEmptyWhitId = "";
            if (id != null && id != "")
            {
                isEmptyWhitId = Validation.empty(productBranch, nameof(productBranch.idRegistro));
            }
            else
            {
                isEmptyWhitId = Validation.empty(productBranch);
            }

            if (isEmptyWhitId != null)
            {
                throw new ServiceException(isEmptyWhitId + MessageErrors.MessageErrors.isEmpty);
            }
        }
    }
}
