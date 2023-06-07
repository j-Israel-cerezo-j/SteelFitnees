using CapaEntidades;
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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteelFitnees.gentelella_master.production.Handlers
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
                save();
            }

        }
        private void save()
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
    }   
}