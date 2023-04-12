using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogicaNegocio.Deletes
{
    public class DayDelete
    {
        private DayDatos dayDatos = new DayDatos();
        public bool delete(string strIds)
        {
            return dayDatos.delete(strIds);
        }
    }
}
