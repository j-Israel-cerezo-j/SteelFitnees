using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio.Services;
using CapaEntidades;
using CapaLogicaNegocio.Exceptions;
using Newtonsoft.Json;
using CapaLogicaNegocio;

namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class sucursalesController : System.Web.UI.Page
    {
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        private BrancheSerevice brancheSerevice = new BrancheSerevice();
        protected void Page_Load(object sender, EventArgs e)
        {
            string request = Request.QueryString["meth"];
            if (request=="si")
            {
                getSucursalesAllImage();
            }else if (request== "comments")
            {
                getAddComments();
            }else if (request=="commentsByBranche")
            {
                getCommentsByBranche();
            }
            else
            {
                getSucursalesAll();
            }            
        }
        
        private void getSucursalesAll()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {                
                string json = brancheSerevice.jsonBranches();
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
        private void getSucursalesAllImage()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {                
                string json = brancheSerevice.jsonTableBranches();
                response.success = true;
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));

            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void getAddComments()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string[] request = Request.Form.AllKeys;
                var valuesSubmit = getValuesForm(request);
                string id = Request.QueryString["id"];
                response.success = brancheSerevice.addCommmentsByBranche(valuesSubmit,id);
            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void getCommentsByBranche()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string id= Request.QueryString["id"];
                string json = brancheSerevice.jsonCommentsBranches(id);
                response.success = true;
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));

            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private Dictionary<string, string> getValuesForm(string[] submitKeys)
        {
            var values = new Dictionary<string, string>();
            for (int i = 0; i < submitKeys.Length; i++)
            {
                string value = Request.Form[submitKeys[i]];
                values.Add(submitKeys[i], value);
            }
            return values;
        }
    }
}