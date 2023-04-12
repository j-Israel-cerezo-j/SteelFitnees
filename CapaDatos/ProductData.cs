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
    public class ProductData
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string cadCon;
        public ProductData()
        {
            cadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(cadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public Product dataProductByIdProduct(int idProduct)
        {
            SqlDataReader renglon;
            Product product = null;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_recoverDataProductByIdProduct";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idProduct;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    product = new Product(renglon);
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
            return product;
        }

        public bool add(Product product)
        {
            bool ban;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_addProduct";
                Comando.Parameters.Add(new SqlParameter("@product", SqlDbType.VarChar, 75));
                Comando.Parameters["@product"].Value = product.Nombre;
                Comando.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.Text));
                Comando.Parameters["@Descripcion"].Value = product.Descripcion;
                Comando.Parameters.Add(new SqlParameter("@imagen", SqlDbType.Text));
                Comando.Parameters["@imagen"].Value = product.imagen;
                Comando.Parameters.Add(new SqlParameter("@filename", SqlDbType.Text));
                Comando.Parameters["@filename"].Value = product.filename;
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
        public bool update(Product product)
        {
            bool ban;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_updateProduct";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = product.idProducto;
                Comando.Parameters.Add(new SqlParameter("@product", SqlDbType.VarChar, 75));
                Comando.Parameters["@product"].Value = product.Nombre;
                Comando.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.Text));
                Comando.Parameters["@Descripcion"].Value = product.Descripcion;
                Comando.Parameters.Add(new SqlParameter("@imagen", SqlDbType.Text));
                Comando.Parameters["@imagen"].Value = product.imagen;
                Comando.Parameters.Add(new SqlParameter("@filename", SqlDbType.Text));
                Comando.Parameters["@filename"].Value = product.filename;
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
        public List<Product> listProduct()
        {
            List<Product> products = new List<Product>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listProducts";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    products.Add(new Product(renglon));
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
            return products;
        }
        public DataTable tableProductsByIdBranche(int id)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableProductsByIdSucursal";
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
        public DataTable tableProductsByIdBrancheAndCharacteres(int id, string characteres)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableProductsByIdSucursalAndCharacteres";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = id;
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.Text));
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

            public bool delete(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteProducts";
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
        public List<Product> listProductByCharacters(string characters)
        {
            List<Product> products = new List<Product>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listProductsByCharacters";
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.VarChar));
                Comando.Parameters["@characters"].Value = characters;
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    products.Add(new Product(renglon));
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
            return products;
        }
        public DataTable listProductsByCharacters(string characters)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listProductsByCharacters";
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.VarChar));
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
        public DataTable listProductsByCharactersAndIdBranche(string characters,int id)
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listProductsByCharactersAndIdBranche";
                Comando.Parameters.Add(new SqlParameter("@characters", SqlDbType.VarChar));
                Comando.Parameters["@characters"].Value = characters;
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
    }
}
