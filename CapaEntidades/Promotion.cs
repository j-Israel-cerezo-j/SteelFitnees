using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Validaciones.utils;

namespace CapaEntidades
{
    public class Promotion
    {
        public int id { get; set; }
        public int fkBranche { get; set; }
        public bool checkk { get; set; }
        public HttpPostedFile img { get; set; }
        public string path { get; set; }
        public string fileName { get; set; }
        public Promotion()
        {

        }
        public Promotion(SqlDataReader renglon)
        {
            this.id = (int)(Validation.getValue(renglon, "id") ?? 0);
            this.checkk= (bool)Validation.getValue(renglon, "checkk");
            this.path= (string)Validation.getValue(renglon, "img");
            this.fileName = (string)Validation.getValue(renglon, "fileNane");

        }

        override
        public string ToString()
        {
            return
                "id:'" + id + "', " +
                "check:'" + checkk + "'," +
                "path:'" + path + "'," +
                "fileName:'" + fileName + "'";               
        }

    }
}
