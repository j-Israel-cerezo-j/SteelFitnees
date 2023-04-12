using CapaEntidades;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio.Services;

namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class aboutUsController : System.Web.UI.Page
    {
        private AboutUsService aboutUsService=new AboutUsService();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "aboutUsListValores")
            {
                getValoresAboutUsList();
            }else if (Request.QueryString["action"] == "aboutUs")
            {
                getAboutUs();
            }            
        }
        private void getAboutUs()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string json = aboutUsService.jsonAboutUs();
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                response.success = true;

            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void getValoresAboutUsList()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                var listValores = aboutUsService.jsonValoresAboutUsList();
                data.Add("recoverData", listValores);
                response.success = true;

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