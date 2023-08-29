using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;

namespace CapaEntidades
{
    public  class AboutUs
    {
        public int idAbout { get; set; }
        public string mision { get; set; }
        public string vision { get; set; }
        public string valores { get; set; }
        public AboutUs()
        {

        }
        public AboutUs(SqlDataReader renglon)
        {
            this.idAbout = (int)(Validation.getValue(renglon, "idAbout") ?? 0);
            this.mision = (string)Validation.getValue(renglon, "mision");
            this.vision = (string)Validation.getValue(renglon, "vision");
            this.valores = (string)Validation.getValue(renglon, "valores");
        }
        public bool empty()
        {
            return string.IsNullOrWhiteSpace(this.mision) || string.IsNullOrWhiteSpace(this.vision) || string.IsNullOrWhiteSpace(this.valores)|| this.idAbout==0;
        }
        public bool emptyExceptId()
        {
            return string.IsNullOrWhiteSpace(this.mision) || string.IsNullOrWhiteSpace(this.vision) || string.IsNullOrWhiteSpace(this.valores);
        }

        override
        public string ToString()
        {
            return
                "id:'" + idAbout + "', " +
                "mision:'" + mision + "', " +
                "vision:'" + vision + "', " +
                "valores:'" + valores + "'";
        }
    }
}
