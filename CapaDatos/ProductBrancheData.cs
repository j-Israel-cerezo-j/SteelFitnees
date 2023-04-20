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
    public class ProductBrancheData
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string cadCon;
        public ProductBrancheData()
        {
            cadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(cadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public bool add(ProductBranch productBranche)
        {

            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_addProductBranche";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@precio", SqlDbType.Decimal));
                Comando.Parameters["@precio"].Value = productBranche.precio;
                Comando.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                Comando.Parameters["@cantidad"].Value = productBranche.cantidad;
                Comando.Parameters.Add(new SqlParameter("@fkSucursal", SqlDbType.Int));
                Comando.Parameters["@fkSucursal"].Value = productBranche.fkSucursal;
                Comando.Parameters.Add(new SqlParameter("@fkProducto", SqlDbType.Int));
                Comando.Parameters["@fkProducto"].Value = productBranche.fkProducto;
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
        public List<ProductBranch> listProductBranches()
        {
            List<ProductBranch> productsBranches = new List<ProductBranch>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listProductsBranches";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    productsBranches.Add(new ProductBranch(renglon));
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
            return productsBranches;
        }
        public DataTable tableProductBranches()
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableProductBranches";
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
        public DataTable tableProductBranchesByIdProduct(int id)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableProductBranchesByIdProduct";
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
        public DataTable tableProductBranchesByIdBranche(int id)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableProductBranchesByIdBranche";
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
        public bool delete(string ids)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteProductBranche";
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
        public ProductBranch dataProductBrachByIdRegistro(int idRegistro)
        {
            SqlDataReader renglon;
            ProductBranch productBranch = null;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_recoverDataProductBranchByIdRecord";
                Comando.Parameters.Add(new SqlParameter("@idRegistro", SqlDbType.Int));
                Comando.Parameters["@idRegistro"].Value = idRegistro;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    productBranch = new ProductBranch(renglon);
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
            return productBranch;
        }
        public bool update(ProductBranch productBranche)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_updateProductBranche";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = productBranche.idRegistro;
                Comando.Parameters.Add(new SqlParameter("@precio", SqlDbType.Decimal));
                Comando.Parameters["@precio"].Value = productBranche.precio;
                Comando.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));
                Comando.Parameters["@cantidad"].Value = productBranche.cantidad;
                Comando.Parameters.Add(new SqlParameter("@fkSucursal", SqlDbType.Int));
                Comando.Parameters["@fkSucursal"].Value = productBranche.fkSucursal;
                Comando.Parameters.Add(new SqlParameter("@fkProducto", SqlDbType.Int));
                Comando.Parameters["@fkProducto"].Value = productBranche.fkProducto;
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
        public DataTable tableProductBranchesByCharacters(string characters)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableProductBranchesByCharacters";
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
