using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;
using System.Data.SqlClient;
namespace CapaEntidades
{
    public class Day
    {
        public int idDia { get; set; }
        public string dia { get; set; }
        public Day()
        {

        }
        public Day(SqlDataReader renglon)
        {
            this.idDia = (int)(Validation.getValue(renglon, "idDia") ?? 0);
            this.dia = (string)Validation.getValue(renglon, "dia");
        }

        override
        public string ToString()
        {
            return
                "id:'" + idDia + "', " +
                "dia:'" + dia + "'";                
        }
    }
}
