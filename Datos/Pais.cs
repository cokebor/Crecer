using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class Pais
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc=string.Empty;
        static Pais()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAISES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
                /*
                switch (ex.Number)
                {
                    case 53:
                        throw new Exception("No se encontró el servidor o éste no esta accesible.");
                    case 2812:
                        throw new Exception(ex.Message);
                    case 4060:
                        throw new Exception("No se puede abrir la base de datos.");
                    case 208:
                        throw new Exception(ex.Message + "\nProcedimiento almacenado " + ex.Procedure);
                    case 207:
                        throw new Exception(ex.Message + "\nError en " + ex.Procedure);
                        
                    default:
                        throw new Exception(ex.Message);
                }*/
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            
            return dt;
        }

        public static DataTable ObtenerNovedades()
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAISES_SELECT_NOVEDADES";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }

        public static void CambiarEstadoNovedad(Entidades.Pais pPais) {
            strProc = "SP_PAISES_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pPais.Codigo);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }
        public static DataTable ObtenerActivos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAISES_SELECT_ACTIVOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
                /*
                switch (ex.Number)
                {
                    case 53:
                        throw new Exception("No se encontró el servidor o éste no esta accesible.");
                    case 2812:
                        throw new Exception(ex.Message);
                    case 4060:
                        throw new Exception("No se puede abrir la base de datos.");
                    case 208:
                        throw new Exception(ex.Message + "\nProcedimiento almacenado " + ex.Procedure);
                    case 207:
                        throw new Exception(ex.Message + "\nError en " + ex.Procedure);
                        
                    default:
                        throw new Exception(ex.Message);
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }
        public static Entidades.Pais ObtenerUno(int pCodigoPais)
        {
            Entidades.Pais objPais = new Entidades.Pais();
            strProc = "SP_PAISES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoPais);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objPais.Codigo= Convert.ToInt32(objDataReader["Codigo"]);
                objPais.Descripcion = objDataReader["Descripcion"].ToString();
                Enumeraciones.Enumeraciones.Estados estado;
                
                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objPais.Estado = estado;

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
                /*
                switch (ex.Number)
                {
                    case 53:
                        throw new Exception("No se encontró el servidor o éste no esta accesible.");
                    case 2812:
                        throw new Exception(ex.Message);
                    case 4060:
                        throw new Exception("No se puede abrir la base de datos.");
                    case 208:
                        throw new Exception(ex.Message + "\nProcedimiento almacenado " + ex.Procedure);
                    case 207:
                        throw new Exception(ex.Message + "\nError en " + ex.Procedure);
                        
                    default:
                        throw new Exception(ex.Message);
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
            return objPais;
        }

        public static void Agregar(Entidades.Pais pPais)
        {
            //Creo objeto conexion
            strProc = "SP_PAISES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pPais.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pPais.Descripcion);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex) {
                if (sqlex.Number == 2601) {
                    throw new Exception("No se pude agregar Pais, ya existe!!");
                }
                throw new Exception(sqlex.Message);
            }
            catch (Exception ex)
            {
                    throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }
        public static void AgregarDeWeb(Entidades.Pais pPais)
        {
            //Creo objeto conexion
            strProc = "SP_PAISES_INSERT_WEB";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pPais.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pPais.Descripcion);
            objCommand.Parameters.AddWithValue("@Estado", pPais.Estado);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Pais, ya existe!!");
                }
                throw new Exception(sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }

        public static void Eliminar(Entidades.Pais pPais)
        {
            //Creo objeto conexion
            strProc = "SP_PAISES_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pPais.Codigo);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }
    }
}
