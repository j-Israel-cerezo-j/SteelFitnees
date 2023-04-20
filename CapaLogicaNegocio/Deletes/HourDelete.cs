using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogicaNegocio.Deletes
{
    public class HourDelete
    {
        private DatosHour datosHour = new DatosHour();
        public bool delete(string ids)
        {
           return datosHour.delete(ids);
        }

    }
}
