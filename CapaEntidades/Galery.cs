using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;

namespace CapaEntidades
{
    public class Galery
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }

        public Galery() { }

        public Galery(SqlDataReader renglon) {
            this.id = (int)(Validation.getValue(renglon, "id") ?? 0);
            this.name = (string)Validation.getValue(renglon, "name");
            this.path = (string)Validation.getValue(renglon, "path");
        }

        override
       public string ToString()
        {
            return
                "id:'" + id + "', " +
                "name:'" + name + "'," +
                "path:'" + path + "'";
        }
    }
}
