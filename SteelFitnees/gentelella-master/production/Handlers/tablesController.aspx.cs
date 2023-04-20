using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using CapaEntidades;
using CapaLogicaNegocio.Exceptions;
using Newtonsoft.Json;
namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class tablesController : System.Web.UI.Page
    {
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        private FacadeCrudCatalogs facadeCrudCatalogs = new FacadeCrudCatalogs();
        protected void Page_Load(object sender, EventArgs e)
        {
            tables();
        }
        private void tables()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            var catalog = Request.QueryString["catalogo"];
            try
            {                
                string table = facadeCrudCatalogs.tableCatalogs(catalog);
                data.Add("info", catalog);
                data.Add("recoverTable", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));
                response.success = true;

            }
            catch(ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}