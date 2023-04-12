using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ExceptionDao;
namespace CapaDatos
{
    public class SearchData
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string cadCon;
        public SearchData()
        {
            cadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(cadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public DataTable searchCoincidencesPrincipal(string characters)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_searchCoincidencesPrincipal";
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.Text));
                Comando.Parameters["@characters"].Value = characters;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                schedules.Load(renglon);
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
            return schedules;
        }
        public int idBrancheByCharacteres(string search)
        {
            int idRecuperado = 0;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_searchIdBySearchBranche";
                Comando.Parameters.Add(new SqlParameter("@search", SqlDbType.Text));
                Comando.Parameters["@search"].Value = search;
                Conexion.Open();
                idRecuperado = (int)Comando.ExecuteScalar();
            }
            catch(NullReferenceException ne)
            {
                throw new ExceptionDao.ExceptionDao("Id no encontrado");
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
            return idRecuperado;

        }
        public int idProductByCharacteres(string search)
        {
            int idRecuperado = 0;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_searchIdProductByBranche";
                Comando.Parameters.Add(new SqlParameter("@search", SqlDbType.Text));
                Comando.Parameters["@search"].Value = search;
                Conexion.Open();
                idRecuperado = (int)Comando.ExecuteScalar();
            }
            catch (NullReferenceException ne)
            {
                throw new ExceptionDao.ExceptionDao("Id no encontrado");
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
            return idRecuperado;

        }
    }
}
