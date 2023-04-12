using CapaDatos.Querys;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class ValidateIfExits
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public ValidateIfExits()
        {
            CadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public DataTable ifExits(Dictionary<string, string> campos, string table)
        {
            DataTable dt = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.IfExists(campos, table);
            Comando.CommandType = CommandType.Text;
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                dt.Load(renglon);
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
            return dt;
        }
        public DataTable getCounts(Dictionary<string, string> campos, string table)
        {
            DataTable dt = new DataTable();
            SqlDataReader renglon;
            Comando.Connection = Conexion;
            Comando.CommandText = Query.getCounts(campos, table);
            Comando.CommandType = CommandType.Text;
            try
            {
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                dt.Load(renglon);
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
            return dt;
        }
    }
}
