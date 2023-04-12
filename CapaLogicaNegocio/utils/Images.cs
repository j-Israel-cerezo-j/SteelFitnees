using CapaLogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaLogicaNegocio.utils
{
    public class Images
    {
        public static string Save(HttpPostedFile file, string binder,string fileName)
        {            
            string pathFileReturn = "";            
            string UpLoadPath =Path.Image  + binder;
            if (file == null)
            {
                throw new ServiceException("Cargar archivo correctamente");
            }
            else
            {
                try
                {
                    string ext = System.IO.Path.GetExtension(file.FileName);
                    if (ext != ".jpg" && ext != ".png")
                    {
                        throw new ServiceException(MessageErrors.MessageErrors.wrongFileExtension("png o jpg"));
                    }
                    string pathFile = UpLoadPath + "/" + fileName;
                    pathFileReturn = "images/perzonalizadas/" + binder + "/" + fileName;
                    file.SaveAs(pathFile);
                }
                catch (ServiceException se)
                {
                    throw new ServiceException(MessageErrors.MessageErrors.wrongFileExtension("png o jpg"));
                }
                catch (Exception e)
                {
                    throw new ServiceException(MessageErrors.MessageErrors.errorSavingUserImage);
                }
            }
            return pathFileReturn;
        }
        public static void Delete(string binder, string fileName)
        {
            string path = Path.Image + binder+ " / " + fileName;
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (IOException e)
                {
                    throw new ServiceException(e.Message);
                }
            }
        }
    }
}
