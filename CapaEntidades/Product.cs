using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.utils;
using System.Runtime.Remoting.Messaging;
using System.Net.NetworkInformation;

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

        public string empty()
        {
            if (string.IsNullOrWhiteSpace(this.Nombre))
            {
                return nameof(this.Nombre);
            }
            else if (string.IsNullOrWhiteSpace(this.Descripcion))
            {
                return nameof(this.Descripcion);
            }
            else if (string.IsNullOrWhiteSpace(this.imagen))
            {
                return nameof(this.imagen);
            }
            else if (string.IsNullOrWhiteSpace(this.filename))
            {
                return nameof(this.filename);
            }
            else if (this.idProducto==0)
            {
                return "id";
            }
            return null;
        }
        public string emptyExceptId()
        {            
            if (string.IsNullOrWhiteSpace(this.Nombre))
            {
                return nameof(this.Nombre);
            }
            else if (string.IsNullOrWhiteSpace(this.Descripcion))
            {
                return nameof(this.Descripcion);
            }
            else if (string.IsNullOrWhiteSpace(this.imagen))
            {
                return nameof(this.imagen);
            }
            else if (string.IsNullOrWhiteSpace(this.filename))
            {
                return nameof(this.filename);
            }
            return null;
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
