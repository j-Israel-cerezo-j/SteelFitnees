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
    public partial class filesController : System.Web.UI.Page
    {
        private FileService fileService = new FileService();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
                        
            if (Request.QueryString["action"] == "saveTemporaly")
            {
                saveTemporarily();
            }else if (Request.QueryString["action"]== "saveFiles")
            {
                saveFiles();
            }else if (Request.QueryString["action"] == "removeAll")
            {
                removeAll();
            }else if (Request.QueryString["action"] == "removeFile")
            {
                removeFile();
            }
        }
        private void saveTemporarily()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                
                string getUrlReferrer = Request.Headers["X-Forwarded-For"]!=null? Request.Headers["X-Forwarded-For"]: Request.UserHostAddress;
                var httpPostFileList = getHttpPostFileListOfHtppFileCollection();
                var success = fileService.push(httpPostFileList, getUrlReferrer);                
                response.success = success;

            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void saveFiles()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string[] submit = Request.Form.AllKeys;
                var valuesRequest = getValuesForm(submit);
                var listValores = fileService.saveFiles(valuesRequest);
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
        private void removeAll()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string getUrlReferrer = Request.Headers["X-Forwarded-For"] != null ? Request.Headers["X-Forwarded-For"] : Request.UserHostAddress;                
                var success = fileService.removeAll(getUrlReferrer);
                response.success = success;

            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }

        private void removeFile()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                string fileName = Request.QueryString["fileName"];
                string getUrlReferrer = Request.Headers["X-Forwarded-For"] != null ? Request.Headers["X-Forwarded-For"] : Request.UserHostAddress;
                var success = fileService.removeFile(getUrlReferrer, fileName);
                response.success = success;

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
    }
}