using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;

namespace CapaEntidades
{
    public class ProductBranch
    {
        public int idRegistro { get; set; }
        public int fkSucursal { get; set; }
        public int fkProducto { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public ProductBranch()
        {

        }
        public ProductBranch(SqlDataReader renglon)
        {
            this.idRegistro = (int)(Validation.getValue(renglon, "idRegistro") ?? 0);
            this.fkSucursal = (int)(Validation.getValue(renglon, "fkSucursal") ?? 0);
            this.fkProducto = (int)(Validation.getValue(renglon, "fkProducto") ?? 0);
            this.cantidad = (int)(Validation.getValue(renglon, "cantidad") ?? 0);
            this.precio = (decimal)(Validation.getValue(renglon, "precio") ?? 0);

        }

        override
        public string ToString()
        {
            return
                "id:'" + idRegistro + "', " +
                "fkSucursal:'" + fkSucursal + "'," +
                "fkProducto:'" + fkProducto + "'," +
                "cantidad:'" + cantidad + "',"+
                "precio:'" + precio + "'";
        }
    }
}
