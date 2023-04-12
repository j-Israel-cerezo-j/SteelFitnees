using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.utils;
namespace CapaEntidades
{
    public class Product
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public string  Descripcion { get; set; }
        public string  imagen { get; set; }
        public string  filename { get; set; }
        public Product()
        {

        }
        public Product(SqlDataReader renglon)
        {
            this.idProducto = (int)(Validation.getValue(renglon, "idProducto") ?? 0);
            this.Nombre = (string)Validation.getValue(renglon, "Nombre");
            this.Descripcion = (string)Validation.getValue(renglon, "Descripcion");
            this.imagen = (string)Validation.getValue(renglon, "imagen");
            this.filename = (string)Validation.getValue(renglon, "filename");
        }

        override
        public string ToString()
        {
            return
                "id:'" + idProducto + "', " +
                "Nombre:'" + Nombre + "'," +
                "Descripcion:'" + Descripcion + "'," +
                "imagen:'" + imagen + "'," +
                "fileName:'" + filename + "'";                
        }
    }
}
