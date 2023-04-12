using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
namespace CapaDatos
{
    public class  DatosHour
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string CadCon;
        public DatosHour()
        {
            CadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(CadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public Hour dataHourByIdHour(int idHour)
        {
            SqlDataReader renglon;
            Hour hour = null;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_recoverDataHourByIdhour";
                Comando.Parameters.Add(new SqlParameter("@idHour", SqlDbType.Int));
                Comando.Parameters["@idHour"].Value = idHour;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    hour = new Hour(renglon);
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
            return hour;
        }
   
        public List<Hour> listHours()
        {
            List<Hour> hours = new List<Hour>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listHours";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    hours.Add(new Hour(renglon));
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
            return hours;
        }
        public bool delete(string ids)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteHours";
            try {
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
        public bool update(Hour hour)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateHours";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id",SqlDbType.Int));
                Comando.Parameters["@id"].Value = hour.idHorario;
                Comando.Parameters.Add(new SqlParameter("@horaInicio",SqlDbType.DateTime));
                Comando.Parameters["@horaInicio"].Value = hour.horaInicio;
                Comando.Parameters.Add(new SqlParameter("@horaCierre", SqlDbType.DateTime));
                Comando.Parameters["@horaCierre"].Value = hour.horaCierre;
                Comando.Parameters.Add(new SqlParameter("@fkDia", SqlDbType.Int));
                Comando.Parameters["@fkDia"].Value = hour.fkDia;
                Comando.Parameters.Add(new SqlParameter("@fkSucursal", SqlDbType.Int));
                Comando.Parameters["@fkSucursal"].Value = hour.fkSucursal;
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
        public bool add(Hour hour)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addHorarios";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@horaInicio", SqlDbType.DateTime));
                Comando.Parameters["@horaInicio"].Value = hour.horaInicio;
                Comando.Parameters.Add(new SqlParameter("@horaCierre", SqlDbType.DateTime));
                Comando.Parameters["@horaCierre"].Value = hour.horaCierre;
                Comando.Parameters.Add(new SqlParameter("@fkDia", SqlDbType.Int));
                Comando.Parameters["@fkDia"].Value = hour.fkDia;
                Comando.Parameters.Add(new SqlParameter("@fkSucursal", SqlDbType.Int));
                Comando.Parameters["@fkSucursal"].Value = hour.fkSucursal;
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
        public DataTable tableHours()
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableHorarios";
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
        public DataTable horariosByIdBranche(int id)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_horariosByIdSucursal";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
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
        public DataTable horariosByIdDay(int id)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_horariosByIdDia";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
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
        public DataTable tableHorariosByCharacters(string character)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableHorariosByCharacters";
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.Text));
                Comando.Parameters["@characters"].Value = character;
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
