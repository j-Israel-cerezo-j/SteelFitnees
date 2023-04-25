using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.Services;
using CapaLogicaNegocio.Exceptions;
using System.Web;

namespace CapaLogicaNegocio
{
    public class FacadeCrudCatalogs 
    {
        private HoursService hoursService = new HoursService();
        private DayService dayService = new DayService();
        private ProductService productService = new ProductService();
        private BrancheSerevice brancheSerevice = new BrancheSerevice();
        private ProductBranchService productBranchService = new ProductBranchService();
        private AboutUsService aboutUsService = new AboutUsService();
        public bool add(string catalog, Dictionary<string, string> request, List<HttpPostedFile> filesList)
        {
            if (catalog == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);
            }
            switch (catalog)
            {
                case "horas":
                    return hoursService.add(request);
                case "dias":
                    return dayService.add(request);
                case "productos":
                    return productService.add(request, filesList);
                case "sucursales":
                    return brancheSerevice.add(request, filesList);
                case "productBranche":
                    return productBranchService.add(request);
                case "aboutUsAdmin":
                    return aboutUsService.add(request);
                default:
                    throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);

            }
        }
        public bool update(string catalog, Dictionary<string, string> request,string strId, List<HttpPostedFile> filesList)
        {
            if (catalog == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);
            }
            switch (catalog)
            {
                case "horas":
                    return hoursService.updateHours(request,strId);
                case "dias":
                    return dayService.updateDays(request, strId);                
                case "productos":
                    return productService.updateProduct(request, strId, filesList);
                case "sucursales":
                    return brancheSerevice.update(request, strId, filesList);
                case "productBranche":
                    return productBranchService.updateProductBranche(request, strId);
                case "aboutUsAdmin":
                    return aboutUsService.updateAboutUs(request, strId);
                default:
                    throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);

            }
        }
        public bool delete(string catalog, string strIds)
        {
            if (catalog == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);
            }
            switch (catalog)
            {
                case "horas":
                    return hoursService.deleteHours(strIds);
                case "dias":
                    return dayService.deleteDays(strIds);
                case "productos":
                    return productService.deleteProducts(strIds);
                case "sucursales":
                    return brancheSerevice.deleteBranche(strIds);
                case "productBranche":
                    return productBranchService.deleteProductBranch(strIds);
                case "aboutUsAdmin":
                    return aboutUsService.deleteAboutUs(strIds);
                default:
                    throw new ServiceException(MessageErrors.MessageErrors.noneTable);
            }
        }
        public string recoverData(string catalog, string strId)
        {
            
            if (catalog == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);
            }
            switch (catalog)
            {
                case "horas":
                    return hoursService.jsonRecoverData(strId);
                case "dias":
                    return dayService.jsonRecoverData(strId);
                case "productos":
                    return productService.jsonRecoverData(strId);
                case "sucursales":
                    return brancheSerevice.jsonRecoverData(strId);
                case "productBranche":
                    return productBranchService.jsonRecoverData(strId);
                case "aboutUsAdmin":
                    return aboutUsService.jsonRecoverData(strId);
                default:
                    throw new ServiceException(MessageErrors.MessageErrors.noneTable);
            }
        }
        public string tableCatalogs(string catalog)
        {
            if (catalog == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.catalogNoExists);
            }
            switch (catalog)
            {
                case "horas":
                    return hoursService.jsonHoursTable();
                case "dias":
                    return dayService.jsonDays();
                case "productos":
                    return productService.jsonProducts();
                case "sucursales":
                    return brancheSerevice.jsonBranches();
                case "productBranche":
                    return productBranchService.jsonProductBrancheTable();
                case "aboutUsAdmin":
                    return aboutUsService.jsonAboutUs();
                default :
                    throw new ServiceException(MessageErrors.MessageErrors.noneTable);
            }
        }
    }
}
