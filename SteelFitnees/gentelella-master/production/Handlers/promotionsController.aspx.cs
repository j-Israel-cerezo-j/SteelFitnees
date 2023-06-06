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
    public partial class promotionsController : System.Web.UI.Page
    {
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            string requestMeth = Request.QueryString["meth"];
            if (requestMeth=="add")
            {
                save();
            }

        }
        private void save()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                var formData = Request.Form["data"];
                
                var datas=JsonConvert.DeserializeObject<List<Promocion>>(formData);

                for (int i = 0; i < datas.Count; i++)
                {
                    var formObject = datas[i];
                    var name = formObject.branche;
                    var age = formObject.check;
                    var avatar = Request.Files[$"img{i}"];
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
    class Promocion
    {
        public string branche { get; set; }
        public string check { get; set; }
        Promocion() { }
    }
}