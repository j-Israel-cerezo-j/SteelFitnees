using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using CapaLogicaNegocio.RecoverData;

namespace CapaLogicaNegocio.Lists
{
    public class DayList
    {
        private DayDatos dayDatos = new DayDatos();
        public List<Day> listDays()
        {
            return dayDatos.listDays();
        }
        public List<Day> tableDaysByCharactersConicidences(string characters)
        {
            return dayDatos.tableDaysByCharactersConicidences(characters);
        }
    }
}
