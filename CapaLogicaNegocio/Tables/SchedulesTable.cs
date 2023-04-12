using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogicaNegocio.Tables
{
    public class SchedulesTable
    {
        private DatosHour datosHour = new DatosHour();
        public DataTable Schedules()
        {
            return datosHour.tableHours();
        }
        public DataTable ByIdBranche(int id)
        {
            return datosHour.horariosByIdBranche(id);
        }
        public DataTable ByIdDay(int id)
        {
            return datosHour.horariosByIdDay(id);
        }
        public DataTable ByCharacters(string characters)
        {
            return datosHour.tableHorariosByCharacters(characters);
        }
    }
}
