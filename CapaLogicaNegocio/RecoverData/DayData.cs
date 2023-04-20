using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.RecoverData
{
    public class DayData
    {
        private DayDatos dayDatos = new DayDatos();
        public Day data(int id)
        {
            return dayDatos.dataDayByIdDay(id);
        }
    }
}
