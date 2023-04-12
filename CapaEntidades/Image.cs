using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.utils;
namespace CapaEntidades
{
    public class Image
    {
        public int idImage { get; set; }
        public string nombre { get; set; }
        public string path { get; set; }
        public int fkSucursal { get; set; }
        public Image()
        {

        }
        public Image(SqlDataReader renglon)
        {
            this.idImage = (int)(Validation.getValue(renglon, "idImage") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
            this.path = (string)Validation.getValue(renglon, "path");
            this.fkSucursal = (int)(Validation.getValue(renglon, "fkSucursal") ??0);

        }

        override
        public string ToString()
        {
            return
                "id:'" + idImage + "', " +
                "Nombre:'" + nombre + "'," +
                "path:'" + path + "'," +
                "fkSucursal:'" + fkSucursal + "'";
        }
    }
}
