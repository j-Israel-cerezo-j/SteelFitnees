using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
namespace CapaLogicaNegocio.Lists
{
    public class ImageList
    {
        private BrancheData brancheData = new BrancheData();
        public List<Image> listImagesByIdBranche(int idSucursal)
        {
            return brancheData.dataImageByFkSucursal(idSucursal);
        }
    }
}
