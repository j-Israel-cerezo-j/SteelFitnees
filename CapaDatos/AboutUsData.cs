using CapaEntidades;
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
    public class AboutUsData
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string cadCon;
        public AboutUsData()
        {
            cadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(cadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool add(AboutUs aboutUs)
        {
            bool ban;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_addAboutUs";
                Comando.Parameters.Add(new SqlParameter("@mision", SqlDbType.Text));
                Comando.Parameters["@mision"].Value = aboutUs.mision;
                Comando.Parameters.Add(new SqlParameter("@vision", SqlDbType.Text));
                Comando.Parameters["@vision"].Value = aboutUs.vision;
                Comando.Parameters.Add(new SqlParameter("@valores", SqlDbType.Text));
                Comando.Parameters["@valores"].Value = aboutUs.valores;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
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
            return ban;

        }
        public bool update(AboutUs aboutUs)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateAboutUs";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idAbout", SqlDbType.Int));
                Comando.Parameters["@idAbout"].Value = aboutUs.idAbout;
                Comando.Parameters.Add(new SqlParameter("@mision", SqlDbType.Text));
                Comando.Parameters["@mision"].Value = aboutUs.mision;
                Comando.Parameters.Add(new SqlParameter("@vision", SqlDbType.Text));
                Comando.Parameters["@vision"].Value = aboutUs.vision;
                Comando.Parameters.Add(new SqlParameter("@valores", SqlDbType.Text));
                Comando.Parameters["@valores"].Value = aboutUs.valores;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
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
            return ban;
        }
        public List<AboutUs> listAboutUs()
        {
            List<AboutUs> aboutsUs = new List<AboutUs>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listAboutUs";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    aboutsUs.Add(new AboutUs(renglon));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();

            }
            return aboutsUs;
        }
        public AboutUs dataAboudUsByIdRecord(int idRecord)
        {
            SqlDataReader renglon;
            AboutUs aboutUs = null;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_aboutUsById";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idRecord;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    aboutUs = new AboutUs(renglon);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return aboutUs;
        }
        public bool delete(string ids)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteAboutUs";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@ids", SqlDbType.VarChar));
                Comando.Parameters["@ids"].Value = ids;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
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
            return ban;
        }
    }
}
