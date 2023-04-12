using CapaDatos.Querys;
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
    public  class DatosUser
    {
        SqlConnection Conexion;
        SqlCommand Comando;
        string CadCon;
        public DatosUser()
        {
            CadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public User login(string strUser)
        {
            SqlDataReader renglon;
            User user = null;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_login";
                Comando.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 50));
                Comando.Parameters["@user"].Value = strUser;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                if (renglon.Read())
                {
                    user = new User(renglon);
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Campo erroneo");
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return user;
        }
        public void add(User user)
        {
            
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addUser";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar,50));
                Comando.Parameters["@user"].Value = user.usuario;
                Comando.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar,50));
                Comando.Parameters["@pass"].Value = user.pass;
                Conexion.Open();
                Comando.ExecuteNonQuery();
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
        }
    }
}
