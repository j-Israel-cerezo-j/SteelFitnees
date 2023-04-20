using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;

namespace CapaEntidades
{
    public  class Contact
    {
        public int idInformacion { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public Contact()
        {

        }
        public Contact(SqlDataReader renglon)
        {
            this.idInformacion = (int)(Validation.getValue(renglon, "idInformacion") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
            this.email = (string)Validation.getValue(renglon, "email");

        }

        override
        public string ToString()
        {
            return
                "id:'" + idInformacion + "', " +
                "nombre:'" + nombre + "'," +
                "email:'" + email + "'";
        }
    }
}
