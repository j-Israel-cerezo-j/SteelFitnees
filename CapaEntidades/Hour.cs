using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.utils;
namespace CapaEntidades
{
    public class Hour
    {
        public int idHorario { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaCierre { get; set; }
        public int fkSucursal { get; set; }
        public int fkDia { get; set; }
        public Hour()
        {

        }
        public Hour(SqlDataReader renglon)
        {
            this.idHorario = (int)(Validation.getValue(renglon, "idHorario") ?? 0);
            this.horaInicio = (DateTime)Validation.getValue(renglon, "horaInicio");
            this.horaCierre = (DateTime)Validation.getValue(renglon, "horaCierre");
            this.fkDia = (int)(Validation.getValue(renglon, "fkDia")??0);
            this.fkSucursal = (int)(Validation.getValue(renglon, "fkSucursal")??0);
        }

        override
        public string ToString()
        {
            return
                "id:'" + idHorario + "', " +
                "horaInicio:'" + horaInicio.ToString("HH:mm") + "'," +
                "horaCierre:'" + horaCierre.ToString("HH:mm") + "',"+
                "fkSucursal:'" + fkSucursal + "',"+
                "fkDia:'" + fkDia + "'";
        }
    }
}
