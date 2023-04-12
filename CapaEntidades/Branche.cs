using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Validaciones.utils;
namespace CapaEntidades
{
    public class Branche
    {
        public int idSucursal { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }        
        public Branche()
        {

        }
        public Branche(SqlDataReader renglon)
        {
            this.idSucursal = (int)(Validation.getValue(renglon, "idSucursal") ?? 0);
            this.nombre = (string)Validation.getValue(renglon, "nombre");
            this.descripcion = (string)Validation.getValue(renglon, "descripcion");
            this.ubicacion = (string)Validation.getValue(renglon, "ubicacion");
           
        }

        override
        public string ToString()
        {
            return
                "id:'" + idSucursal + "', " +
                "Nombre:'" + nombre + "'," +
                "Descripcion:'" + descripcion + "'," +
                "ubicacion:'" + ubicacion + "'";              
        }
    }
}
