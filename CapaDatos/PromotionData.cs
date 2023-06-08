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
    public class PromotionData
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string CadCon;
        public PromotionData()
        {
            CadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public int add(Promotion promotion)
        {
            int idRecuperado = 0;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_addPromotions";

                Comando.Parameters.Add(new SqlParameter("@checkk", SqlDbType.Bit));
                Comando.Parameters["@checkk"].Value = promotion.check;
                Comando.Parameters.Add(new SqlParameter("@img", SqlDbType.Text));
                Comando.Parameters["@img"].Value = promotion.path;
                Comando.Parameters.Add(new SqlParameter("@fileNane", SqlDbType.Text));
                Comando.Parameters["@fileNane"].Value = promotion.fileName;
                Conexion.Open();
                idRecuperado = (int)Comando.ExecuteScalar();
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
        public bool addPromotionBranch(int idBranch,int idPromotion)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addPromotionsBranch";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@fkBranch", SqlDbType.Int));
                Comando.Parameters["@fkBranch"].Value = idBranch;
                Comando.Parameters.Add(new SqlParameter("@fkPromotion", SqlDbType.Int));
                Comando.Parameters["@fkPromotion"].Value = idPromotion;
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

        public bool delete(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deletePromotions";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@ids", SqlDbType.VarChar));
                Comando.Parameters["@ids"].Value = strIds;
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

        public DataTable lisAllPromotions()
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listAllPromotions";
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
    }
}
