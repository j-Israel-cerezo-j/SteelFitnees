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
        private static Dictionary<string, List<HttpPostedFile>> httpPostedFilessDirec = new Dictionary<string, List<HttpPostedFile>>();
        public bool push(List<HttpPostedFile> httpPostedFiless,string ipRequest) {
            try
            {
                var files = new List<HttpPostedFile>();
                foreach (var file in httpPostedFiless)
                {
                    files.Add(file);
                }

                if (!FileService.httpPostedFilessDirec.ContainsKey(ipRequest))
                {                   
                    FileService.httpPostedFilessDirec.Add(ipRequest,files);
                }
                else
                {
                    var fileTem = FileService.httpPostedFilessDirec[ipRequest];
                    var newListTem = fileTem.Concat(files).ToList();
                    FileService.httpPostedFilessDirec[ipRequest] = newListTem;
                }
                return true;
            }
            catch (Exception e)
            {                
                throw new ServiceException("Error al cargar la imagen");
            }
        }
        public List<HttpPostedFile> selectFile(string ipRequest)
        {
            return FileService.httpPostedFilessDirec[ipRequest];
        }
        public bool removeAll(string ipRequest)
        {
            return FileService.httpPostedFilessDirec.Remove(ipRequest);
        }
        public bool removeFile(string ipRequest,string fileName)
        {
            var files = FileService.httpPostedFilessDirec[ipRequest];
            if (fileName!="")
            {
                foreach (var file in files)
                {
                    if (file.FileName == fileName)
                    {
                        files.Remove(file);
                        return true;
                    }
                }
            }            
            return false;

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
    }
}
