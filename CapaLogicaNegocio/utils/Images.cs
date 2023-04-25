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
                    if (ext != ".jpg" && ext != ".png"&& ext != ".JPG" && ext != ".PNG"&& ext != "JPG" && ext != "PNG" && ext != "PNG"&&ext!= ".jfif"&&ext!= ".jpeg" && ext != ".JPEG")
                    {
                        throw new ServiceException(MessageErrors.MessageErrors.wrongFileExtension("png o jpg"));
                    }
                    string pathFile = UpLoadPath + "/" + fileName;
                    pathFileReturn = "images/perzonalizadas/" + binder + "/" + fileName;
                    file.SaveAs(pathFile);
                }
                catch (ServiceException se)
                {
                    throw new ServiceException(se.getMessage());
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
        public static void validWrongSizeInImageName(List<HttpPostedFile> filesList)
        {
            foreach (var file in filesList)
            {
                if (file.FileName.Length > 45)
                {
                    throw new ServiceException(MessageErrors.MessageErrors.wrongSizeInImageName(file.FileName));
                }
            }
        }
        public static void validateThatTheNameOfTheImageDoesNotHaveCommas(List<HttpPostedFile> filesList)
        {
            foreach (var file in filesList)
            {
                if (file.FileName.Contains(","))
                {
                    throw new ServiceException(MessageErrors.MessageErrors.commasAreNotAllowedInTheImageName(file.FileName));
                }
            }

        }
    }
}
