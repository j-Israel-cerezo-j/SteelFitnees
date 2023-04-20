using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.utils;
namespace CapaEntidades
{
    public  class User
    {
        public int idUser { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public User()
        {

        }
        public User(SqlDataReader renglon)
        {
            this.idUser = (int)(Validation.getValue(renglon, "idUser") ?? 0);
            this.usuario = (string)Validation.getValue(renglon, "usuario");
            this.pass = (string)Validation.getValue(renglon, "pass");

        }

        override
        public string ToString()
        {
            return
                "id:'" + idUser + "', " +
                "usuario:'" + usuario + "'," +
                "pass:'" + pass + "'";                
        }
    }
}
