using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.RecoverData
{    
    public class GaleryRD
    {
        private GaleryData galeryData=new GaleryData();
        public DataTable allGallery()
        {
            return galeryData.AllGalery();
        }
    }
}
