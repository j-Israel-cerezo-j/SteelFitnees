using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Inserts;
using CapaLogicaNegocio.RecoverData;
using CapaLogicaNegocio.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaLogicaNegocio.Services
{
    public class GaleryService
    {
        private Random rd=new Random();
        private GaleryRD galeryRD = new GaleryRD();
        public void add(List<HttpPostedFile> files)
        {
            var fileNamesList=new List<string>();
            var fields =new  Dictionary<object, object>();
            try
            {
                foreach (var file in files)
                {
                    string fileName = rd.Next(1, 100000000).ToString() + file.FileName;
                    fileNamesList.Add(fileName);
                    var pathStr=Images.Save(file, "galery", fileName);
                    fields.Add(pathStr, fileName);
                }
                Insert.Many(fields, "galery");
            }
            catch (ServiceException se)
            {
                rollbackSaveImage(fileNamesList);
                throw new ServiceException(se.getMessage());
            }
        }

        public string getGallery()
        {
            return Converter.ToJson(galeryRD.allGallery()).ToString();
        }

        private void rollbackSaveImage(List<string> fileNames)
        {
            foreach (var name in fileNames)
            {
                Images.Delete("galery", name);
            }
        }
    }
}
