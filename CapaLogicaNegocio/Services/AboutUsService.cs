﻿using CapaEntidades;
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
        private AboutUsUpdate usUpdate=new AboutUsUpdate();
        private AboutUsDelete usDelete=new AboutUsDelete();
        private AboutUsDataRec UsDataRec = new AboutUsDataRec();
        public bool persistence(Dictionary<string, string> request, string strId="")
        {
            AboutUs aboutUs = buildObjAboutUs(request);
            if (strId == "")
            {
                isEmpty(aboutUs);
                return usAdd.add(aboutUs);
            }

            aboutUs.idAbout = Convert.ToInt32(strId);
            isEmpty(aboutUs, nameof(aboutUs.idAbout));
            return usUpdate.update(aboutUs);
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
        private void isEmpty(AboutUs aboutUs, string id = "")
        {
            var isEmptyWhitId = "";
            if (id != null && id != "")
            {
                isEmptyWhitId = Validation.empty(aboutUs, nameof(aboutUs.idAbout));
            }
            else
            {
                isEmptyWhitId = Validation.empty(aboutUs);
            }

            if (isEmptyWhitId != null)
            {
                throw new ServiceException(isEmptyWhitId + MessageErrors.MessageErrors.isEmpty);
            }
        }
    }
}
