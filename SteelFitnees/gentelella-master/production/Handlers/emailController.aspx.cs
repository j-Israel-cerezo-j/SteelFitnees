using CapaEntidades;
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
    public partial class emailController : System.Web.UI.Page
    {
        public static string getJsonResponse { get; private set; } = "{\"k\":1}";
        private EmailSendService sendService=new EmailSendService();
        protected void Page_Load(object sender, EventArgs e)
        {
            sendEmail();
        }
        private void sendEmail()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string[] submit = Request.Form.AllKeys;
            var file = Request.Files["image"];
            var valuesRequest = getValuesForm(submit);
            if (submit.Length > 0)
            {
                try
                {
                    var success = sendService.send(valuesRequest, file);
                    if (success)
                    {
                        response.success = success;
                        data.Add("type", "send");

                    }
                    else
                    {
                        response.error = "¡Error inesperado en el servidor!.";
                    }
                }
                catch (ServiceException ex)
                {
                    response.error = ex.getMessage();
                }
            }
            else
            {
                response.error = "Campos vacios";
                response.success = false;
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