using CapaEntidades;
using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.Deletes;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Lists;
using CapaLogicaNegocio.RecoverData;
using CapaLogicaNegocio.Updates;
using CapaLogicaNegocio.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;

namespace CapaLogicaNegocio.Services
{
    public  class AboutUsService
    {
        private AboutUsAdd usAdd=new AboutUsAdd();
        private AboutUsList usList=new AboutUsList();
        private AboutUsDataRec UsDataRec = new AboutUsDataRec();
        private AboutUsUpdate usUpdate=new AboutUsUpdate(); 
        private AboutUsDelete usDelete=new AboutUsDelete(); 
        public bool add(Dictionary<string, string> request)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                AboutUs aboutUs = buildObjAboutUs(request);
                return usAdd.add(aboutUs);
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
        public string jsonAboutUs()
        {
            return Converter.ToJson(usList.listAboutUs()).ToString();
        }
        public List<object> jsonValoresAboutUsList()
        {            
            var aboutUs = usList.listAboutUs();
            return Converter.ToList(aboutUs[0].valores);
        }
        public string jsonRecoverData(string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var aboutUs = new List<AboutUs>
            {
                UsDataRec.dataProductBranchByIdRecord(Convert.ToInt32(strId))
            };
            string jsonRecoerDtes = Converter.ToJson(aboutUs);
            return jsonRecoerDtes;
        }
        public bool updateAboutUs(Dictionary<string, string> request, string strId)
        {
            if (strId == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                AboutUs aboutUs = buildObjAboutUs(request);
                aboutUs.idAbout = Convert.ToInt32(strId);
                return usUpdate.update(aboutUs);
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
        public bool deleteAboutUs(string strIds)
        {
            return usDelete.delete(strIds);
        }
        private AboutUs buildObjAboutUs(Dictionary<string, string> request)
        {
            AboutUs aboutUs = new AboutUs();
            aboutUs.mision = RetrieveAtributes.values(request, "mision").Trim();
            aboutUs.vision = RetrieveAtributes.values(request, "vision").Trim();
            aboutUs.valores = RetrieveAtributes.values(request, "valores").Trim();
            return aboutUs;
        }
    }
}
