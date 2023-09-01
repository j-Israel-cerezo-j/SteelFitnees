using CapaEntidades;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio.Services;

namespace SteelFitnees.Handlers 
{ 
    public partial class GaleryController : System.Web.UI.Page
    {
        private GaleryService galeryService=new GaleryService();
        public static string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            string acction = Request.QueryString["action"];
            if (acction=="add")
            {
                add();
            }
            else if (acction == "get")
            {
                get();
            }
        }
        private void add()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            var httpPostFileList = getHttpPostFileListOfHtppFileCollection();
            try
            {
                galeryService.add(httpPostFileList);
                response.success = true;
                string gallery = galeryService.getGallery();
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(gallery));
            }
            catch (ServiceException ex)
            {
                response.error = ex.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
        private void get()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();            
            try
            {
                response.success = true;
                string gallery = galeryService.getGallery();
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(gallery));
            }
            catch (ServiceException ex)
            {
                response.error = ex.getMessage();
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
    }
}