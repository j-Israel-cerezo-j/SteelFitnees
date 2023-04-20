using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Updates
{
    public class DayUpdate
    {
        private DayDatos dayDatos = new DayDatos();
        public bool update(Day day)
        {
            return dayDatos.update(day);
        }
    }
}
