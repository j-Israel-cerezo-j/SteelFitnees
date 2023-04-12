using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.RecoverData
{
    public class DataHour
    {
        private DatosHour datosHour = new DatosHour();
        public Hour dataHour(int id)
        {
            return datosHour.dataHourByIdHour(id);
        }
    }
}
