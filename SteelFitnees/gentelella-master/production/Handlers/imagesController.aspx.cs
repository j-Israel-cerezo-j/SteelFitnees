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
namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class imagesController : System.Web.UI.Page
    {
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        private BrancheSerevice bracheService= new BrancheSerevice();
        protected void Page_Load(object sender, EventArgs e)
        {
            getImages();
        }
        private void getImages()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            var id = Request.QueryString["id"];
            try
            {                
                string json = bracheService.jsonImagesByIdBranche(id);
                data.Add("info", id);
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