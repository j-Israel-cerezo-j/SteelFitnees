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
    public class DayDatos
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string cadCon;
        public DayDatos()
        {
            cadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(cadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool delete(string ids)
        {
            bool ban;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_deleteDays";
                Comando.Parameters.Add(new SqlParameter("@ids",SqlDbType.VarChar));
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
        public Day dataDayByIdDay(int idHour)
        {
            SqlDataReader renglon;
            Day day = null;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_recoverDataDayByIdDay";
                Comando.Parameters.Add(new SqlParameter("@idDay", SqlDbType.Int));
                Comando.Parameters["@idDay"].Value = idHour;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    day = new Day(renglon);
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
            return day;
        }
        public bool add(Day day)
        {            
            bool ban;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_addDay";
                Comando.Parameters.Add(new SqlParameter("@dia", SqlDbType.VarChar,20));
                Comando.Parameters["@dia"].Value = day.dia;
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
        public bool update(Day day)
        {
            bool ban;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_updateDay";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = day.idDia;
                Comando.Parameters.Add(new SqlParameter("@dia", SqlDbType.VarChar, 20));
                Comando.Parameters["@dia"].Value = day.dia;
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
        public DataTable tableDays()
        {
            DataTable days = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableDays";
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                days.Load(renglon);
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
            return days;
        }
        public List<Day> listDays()
        {
            List<Day> days = new List<Day>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listDays";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    days.Add(new Day(renglon));
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
            return days;
        }
        public List<Day> tableDaysByCharactersConicidences(string characters)
        {
            List<Day> days = new List<Day>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listDaysByCharacters";
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.Text));
                Comando.Parameters["@characters"].Value = characters;
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    days.Add(new Day(renglon));
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
            return days;
        }
        public DataTable listDaysByCharactersConicidences(string characters)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listDaysByCharacters";
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
    }
}
