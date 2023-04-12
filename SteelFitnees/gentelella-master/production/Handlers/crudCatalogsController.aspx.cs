using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using CapaEntidades;
using Newtonsoft.Json;
using CapaLogicaNegocio.Exceptions;
namespace SteelFitnessWEB.gentelella_master.production.Handlers
{
    public partial class crudCatalogsController : System.Web.UI.Page
    {
        private FacadeCrudCatalogs facadeCrudCatalogs = new FacadeCrudCatalogs();
        public static string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.Form["typeSubmit"];
            if (type == "add")
            {

                add();
            }            
            else if (type == "delete")
            {
                requestDelete();
            }
            else if (type == "recoverData")
            {
                recoverData();
            }
            else if (type == "update")
            {
                requestUpdate();
            }
        }
        private void add()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string[] submit = Request.Form.AllKeys;
            var valuesSubmit = getValuesForm(submit);
            var httpPostFileList = getHttpPostFileListOfHtppFileCollection();
            if (submit.Length > 0 )
            {
                try
                {
                    var success = facadeCrudCatalogs.add(catalogo, valuesSubmit, httpPostFileList);
                    if (success)
                    {
                        response.success = success;
                        string table = facadeCrudCatalogs.tableCatalogs(catalogo);
                        data.Add("info", catalogo);
                        data.Add("type", "add");
                        data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));

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
        private void requestDelete()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string strIds = Request.Form["idsToDelete"];
            if (strIds != "" && catalogo != "")
            {
                try
                {
                    var success = facadeCrudCatalogs.delete(catalogo, strIds);
                    if (success)
                    {
                        response.success = success;
                        string table = facadeCrudCatalogs.tableCatalogs(catalogo);
                        data.Add("info", catalogo);
                        data.Add("type", "delete");
                        data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));
                    }
                    else
                    {
                        response.error = "No se ha podido eliminar.";
                    }
                }
                catch (ServiceException se)
                {
                    response.error = se.getMessage();
                }
                catch (Exception e)
                {
                    response.error = "¡Error inesperado en el servidor!";
                }
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void recoverData()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string id = Request.QueryString["id"];
            try
            {
                var json = facadeCrudCatalogs.recoverData(catalogo, id);
                if (json != "")
                {
                    response.success = true;
                    data.Add("info", catalogo);
                    data.Add("recoverDates", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));
                }
            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }            
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void requestUpdate()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            string catalogo = Request.Form["catalogo"];
            string strId = Request.Form["id"];
            var httpPostFileList = getHttpPostFileListOfHtppFileCollection();
            string[] submit = Request.Form.AllKeys;
            var valuesSubmit = getValuesForm(submit);
            if (valuesSubmit.Count > 0)
            {
                try
                {
                    var success = facadeCrudCatalogs.update(catalogo, valuesSubmit, strId, httpPostFileList);
                    if (success)
                    {
                        response.success = success;
                        string table = facadeCrudCatalogs.tableCatalogs(catalogo);
                        data.Add("info", catalogo);
                        data.Add("type", "update");
                        data.Add("table", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(table));
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
        private List<HttpPostedFile> getHttpPostFileListOfHtppFileCollection()
        {
            List<HttpPostedFile> filesList = new List<HttpPostedFile>();
            HttpFileCollection files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                filesList.Add(files[i]);
            }
            return filesList;
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