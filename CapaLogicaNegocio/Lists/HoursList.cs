using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Lists
{
    public class HoursList
    {
        DatosHour datosHour = new DatosHour();

        public List<Hour> listHours()
        {
            return datosHour.listHours();
        }
    }
}
