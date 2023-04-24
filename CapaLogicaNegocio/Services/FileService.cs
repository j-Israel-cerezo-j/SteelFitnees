using CapaLogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

namespace CapaLogicaNegocio.Services
{
    public class FileService
    {
        private static List<HttpPostedFile> httpPostedFiles = new List<HttpPostedFile>();
        
        public bool saveTemporarily(List<HttpPostedFile> httpPostedFiless) {
            try
            {
                foreach (var file in httpPostedFiless)
                {
                    FileService.httpPostedFiles.Add(file);
                }
                return true;
            }
            catch (Exception e)
            {                
                throw new ServiceException("Error al cargar la imagen");
            }            
        }
        async public Task<string> saveFiles(Dictionary<string, string> request)
        {
             var httpClient = new HttpClient();

            var url = "Handlers/crudCatalogsController.aspxs";            
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }


        public List<HttpPostedFile> saveFilesS()
        {
            return httpPostedFiles;
        }
    }
}
