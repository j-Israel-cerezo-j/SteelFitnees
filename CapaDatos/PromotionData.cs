using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapaDatos.ExceptionDao;

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
                Comando.Parameters["@checkk"].Value = promotion.checkk;
                Comando.Parameters.Add(new SqlParameter("@img", SqlDbType.Text));
                Comando.Parameters["@img"].Value = promotion.path;
                Comando.Parameters.Add(new SqlParameter("@promotionName", SqlDbType.VarChar,50));
                Comando.Parameters["@promotionName"].Value = promotion.promotionName;
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

        public int idBrancheByIdPromotions(int id)
        {
            int idRecuperado = 0;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_recoverIdBrancheByPromotion";

                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;                
                Conexion.Open();
                idRecuperado = (int)Comando.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw new ExceptionDao.ExceptionDao(e.Message);
            }catch (NullReferenceException ex)
            {
                throw new ExceptionDao.ExceptionDao(ex.Message);
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

        public bool deletePrmotionsBranche(int idPromotion)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deletePrmotionsBranche";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idPromotion", SqlDbType.Int));
                Comando.Parameters["@idPromotion"].Value = idPromotion;
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

        public bool update(int id,bool checkPromotion)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updatePromotion";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                Comando.Parameters.Add(new SqlParameter("@checkk", SqlDbType.Bit));
                Comando.Parameters["@checkk"].Value = checkPromotion;
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

        public bool updatePromotionBranchByPromotion(int idPromotion, int idBranch)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updatePromotionBranch";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@idBranch", SqlDbType.Int));
                Comando.Parameters["@idBranch"].Value = idBranch;
                Comando.Parameters.Add(new SqlParameter("@idPromotion", SqlDbType.Int));
                Comando.Parameters["@idPromotion"].Value = idPromotion;
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

        public DataTable lisAllPromotionsVisibility(int visibility)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add(new SqlParameter("@visibiliti",SqlDbType.Int));
                Comando.Parameters["@visibiliti"].Value = visibility;

                Comando.CommandText = "pro_listAllPromotionsByVisivility";
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

        public DataTable lisAllPromotionsVisivilityByBranche(int idBranch,int visivility)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listAllPromotionsVisibilityByBranche";
                Comando.Parameters.Add(new SqlParameter("@idBranch", SqlDbType.Int));
                Comando.Parameters["@idBranch"].Value = idBranch;
                Comando.Parameters.Add(new SqlParameter("@visibility", SqlDbType.Int));
                Comando.Parameters["@visibility"].Value = visivility;
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

        public DataTable listAllPromotionsByCharacteres(string characteres)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listAllPromotionsByCharacteres";
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.VarChar));
                Comando.Parameters["@characters"].Value = characteres;
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

        public DataTable lisAllPromotionsByBranche(int idBranch)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listAllPromotionsByBranche";
                Comando.Parameters.Add(new SqlParameter("@idBranch", SqlDbType.Int));
                Comando.Parameters["@idBranch"].Value = idBranch;
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

        public DataTable lisAllPromotionsNoBranche()
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listAllPromotionsNoBranche";
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

        public List<PromotionBranch> listPromotionBranch()
        {
            List<PromotionBranch> promotionsBranch = new List<PromotionBranch>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listPromotionsBranch";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    promotionsBranch.Add(new PromotionBranch(renglon));
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
            return promotionsBranch;
        }

        public List<Promotion> listPromotion()
        {
            List<Promotion> promotionsBranch = new List<Promotion>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listAllPromotions";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    promotionsBranch.Add(new Promotion(renglon));
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
            return promotionsBranch;
        }
    }
}
