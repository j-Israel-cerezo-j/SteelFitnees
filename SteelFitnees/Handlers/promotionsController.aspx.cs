﻿using CapaEntidades;
using CapaEntidades.DTO;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteelFitnees.Handlers
{
    public partial class promotionsController : System.Web.UI.Page
    {
        private PromotionService promotionService=new PromotionService();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            string requestMeth = Request.QueryString["meth"];
            if (requestMeth=="add")
            {
                post();
            }else if (requestMeth == "get")
            {
                getAllPromotions();
            }
            else if (requestMeth== "brancheByPromotion")
            {
                getBrancheByPromotion();
            }
            else if (requestMeth == "promotionByBranchOrVisibility")
            {
                getPromotionsByVisibilityOrBranchOrNone();
            }
            else if (requestMeth == "promotionNoBranch")
            {
                getPromotionsNoBranch();
            }
            else if (requestMeth == "delete")
            {
                delete();
            }
        }
        private void getAllPromotions()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                var jsonPromotion = promotionService.jsonPromotions();
                response.success = true;
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonPromotion));
            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }

        private void getBrancheByPromotion()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string idPromotionStr=Request.QueryString["id"];
                var idBranche = promotionService.idBrancheByPromotion(idPromotionStr);
                response.success = true;
                data.Add("recoverData",idBranche);
            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }

        private void getPromotionsByVisibilityOrBranchOrNone()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string idPromotionStr = Request.QueryString["id"];
                string strVisivility= Request.QueryString["visivility"];
                var jsonPromotion = promotionService.promotionsByVisibilityOrBranchOrNone(idPromotionStr, strVisivility);
                response.success = true;
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonPromotion));
            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }

        private void getPromotionsNoBranch()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {                
                var jsonPromotion = promotionService.promotionsNoBranch();
                response.success = true;
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonPromotion));
            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }

        private void post()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {                
                var jsonPromotion=promotionService.add(Request);
                response.success = true;
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonPromotion));
            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }

        private void delete()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                var jsonPromotion = promotionService.delete(Request);
                response.success = true;
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(jsonPromotion));
            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }   
}