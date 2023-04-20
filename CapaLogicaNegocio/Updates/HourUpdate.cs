using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Updates
{
    public class HourUpdate
    {
        private DatosHour datosHour = new DatosHour();
        public bool hourUpdate(Hour hour)
        {
            return datosHour.update(hour);
        }

    }
}
