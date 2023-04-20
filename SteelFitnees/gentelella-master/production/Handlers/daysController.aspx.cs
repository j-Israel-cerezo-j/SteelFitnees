using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio.Services;
using CapaEntidades;
using Newtonsoft.Json;
using CapaLogicaNegocio.Exceptions;
namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class daysController : System.Web.UI.Page
    {
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        private DayService dayService = new DayService();
        protected void Page_Load(object sender, EventArgs e)
        {
            getDaysAll();
        }
        private void getDaysAll()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {                
                string json = dayService.jsonDays();
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