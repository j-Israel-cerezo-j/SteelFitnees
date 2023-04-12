using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Adds
{
    public class DayAdd
    {
        private DayDatos dayDatos = new DayDatos();
        public bool add(Day day)
        {
            return dayDatos.add(day);
        }
    }
}
