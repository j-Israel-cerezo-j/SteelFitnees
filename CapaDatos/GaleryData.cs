using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GaleryData
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string cadCon;
        public GaleryData()
        {
            cadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(cadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public DataTable AllGalery()
        {
            DataTable galery = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_allGalery";
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                galery.Load(renglon);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return galery;
        }
    }
}
