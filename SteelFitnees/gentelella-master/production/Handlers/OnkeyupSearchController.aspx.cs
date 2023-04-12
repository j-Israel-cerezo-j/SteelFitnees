using CapaEntidades;
using CapaLogicaNegocio.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using CapaLogicaNegocio.MessageErrors;

namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class OnkeyupSearchController : System.Web.UI.Page
    {
        private FacadeOnkeyup facadeOnkeyup= new FacadeOnkeyup();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["action"];
            if (action == "full")
            {
                onkeyupSearch();
            }
            else if (action == "comments")
            {
                onkeyupSearchComments();
            }else if (action=="productosByBranche")
            {
                onkeyupSearchProductosByBranche();
            }
            else if (action == "searchMaster")
            {
                onkeyupSearchMasterPage();
            }
            else if (action == "actionSearchubmit")
            {
                onkeyupSearchMasterPageAction();
            }
        }
        private void onkeyupSearch()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.QueryString["catalogo"];
            string caracteresDeBusqueda = Request.Form["onkeyupCoincidencias"];

            try
            {
                var coincidencias = facadeOnkeyup.coincidences(catalogo, caracteresDeBusqueda);                
                var jsonTable = facadeOnkeyup.tables(catalogo, caracteresDeBusqueda);
                data.Add("catalogo", catalogo);                
                data.Add("coincidencias", coincidencias);
                data.Add("table", JsonConvert.DeserializeObject(jsonTable));
                response.success = true;

            }
            catch (ServiceException e)
            {
                response.error = e.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void onkeyupSearchMasterPage()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.QueryString["catalogo"];
            string caracteresDeBusqueda = Request.Form["onkeyupCoincidenciasMaster"];

            try
            {
                var coincidencias = facadeOnkeyup.coincidences(catalogo, caracteresDeBusqueda);
                data.Add("catalogo", catalogo);
                data.Add("coincidencias", coincidencias);
                data.Add("table", "");
                response.success = true;

            }
            catch (ServiceException e)
            {
                response.error = e.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void onkeyupSearchMasterPageAction()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.QueryString["catalogo"];
            string search = Request.Form["onkeyupCoincidenciasMaster"];

            try
            {
                var responseStr = facadeOnkeyup.searchUrlBySearch(catalogo, search);
                data.Add("catalogo", catalogo);
                data.Add("accion", "sinCoincidencias");                
                data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>>(responseStr));
                response.success = true;

            }
            catch (ServiceException e)
            {
                response.error = e.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void onkeyupSearchComments()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.QueryString["catalogo"];
            string caracteresDeBusqueda = Request.Form["onkeyupCoincidencias"];
            string id = Request.QueryString["id"];

            if (catalogo != "")
            {
                try
                {                    
                    
                    var jsonTable = facadeOnkeyup.comments(catalogo, caracteresDeBusqueda, id);
                    data.Add("catalogo", catalogo);
                    response.success = true;
                    data.Add("coincidencias", "");
                    data.Add("table", JsonConvert.DeserializeObject(jsonTable));

                }
                catch (ServiceException e)
                {
                    response.error = e.getMessage();
                }
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void onkeyupSearchProductosByBranche()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.QueryString["catalogo"];
            string strId= Request.QueryString["id"];
            string caracteresDeBusqueda = Request.Form["onkeyupCoincidencias"];

            try
            {
                if (strId=="" || strId =="-1")
                {
                    throw new ServiceException(MessageErrors.selectABranchPlease);
                }
                var coincidencias = facadeOnkeyup.coincidences(catalogo, caracteresDeBusqueda, strId);
                var productsJson = facadeOnkeyup.tables(catalogo, caracteresDeBusqueda, strId);
                if (productsJson.Length <= 2)
                {
                    data.Add("accion", "sinCoincidencias");
                }
                data.Add("coincidencias", coincidencias);
                data.Add("catalogo", catalogo);                
                data.Add("table", JsonConvert.DeserializeObject(productsJson));
                response.success = true;

            }
            catch (ServiceException e)
            {
                response.error = e.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}