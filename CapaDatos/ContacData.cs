using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace CapaDatos
{
    public class ContacData
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string CadCon;
        public ContacData()
        {
            CadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool add(Contact contact)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addContact";
            try
            {                
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar,50));
                Comando.Parameters["@nombre"].Value = contact.nombre;                
                Comando.Parameters.Add(new SqlParameter("@email", SqlDbType.Text));
                Comando.Parameters["@email"].Value = contact.email;
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
        public List<Contact> listContacts()
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listContacts";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    contacts.Add(new Contact(renglon));
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
            return contacts;
        }
    }
}
