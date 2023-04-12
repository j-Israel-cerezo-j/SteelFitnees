using CapaEntidades;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class filterByController : System.Web.UI.Page
    {
        private FacedeFilter facedeFilter=new FacedeFilter();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "filterBy")
            {
                getFilterBy();
            }
            else if(Request.QueryString["action"] == "table")
            {
                getFilterByTable();
            }else if (Request.QueryString["action"] == "weeks")
            {
                getFilterByWeeks();
            }
        }
        private void getFilterBy()
        {
            string filterBy = Request.QueryString["filterByValue"];
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {                
                string json = facedeFilter.by(filterBy);
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
        private void getFilterByTable()
        {
            string filterByValue = Request.QueryString["filterByValue"];
            string filterBy = Request.QueryString["filterBy"];
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string json = facedeFilter.table(filterByValue, filterBy);
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
        private void getFilterByWeeks()
        {
            string filterByValue = Request.QueryString["filterByValue"];
            string filterBy = Request.QueryString["filterBy"];
            string idBranche = Request.QueryString["id"];
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string json = facedeFilter.commentsBranche(filterByValue, filterBy, idBranche);
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
    }  
}