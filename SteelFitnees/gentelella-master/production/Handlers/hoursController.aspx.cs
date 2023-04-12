using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio.Services;
using Newtonsoft.Json;
using CapaLogicaNegocio.Exceptions;
namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class hoursController : System.Web.UI.Page
    {
        private HoursService hourService = new HoursService();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            jsonHpurs();
        }
        private void jsonHpurs()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();            
            try
            {                
                string json = hourService.jsonHoursTable();                
                data.Add("recoverTable", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
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