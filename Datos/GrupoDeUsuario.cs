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
    public static class GrupoDeUsuario
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static GrupoDeUsuario()
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
            strProc = "SP_GRUPOSDEUSUARIOS_SELECT";
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
        public static DataTable ObtenerActivos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_GRUPOSDEUSUARIOS_SELECT_ACTIVOS";
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
        public static Entidades.GrupoDeUsuario ObtenerUno(int pCodigoGrupo)
        {
            Entidades.GrupoDeUsuario objGrupoUsuario = new Entidades.GrupoDeUsuario();
            strProc = "SP_GRUPOSDEUSUARIOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoGrupo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objGrupoUsuario.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objGrupoUsuario.Descripcion = objDataReader["Descripcion"].ToString();
                Enumeraciones.Enumeraciones.Estados estado;

                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objGrupoUsuario.Estado = estado;

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
            return objGrupoUsuario;
        }

        public static void Agregar(Entidades.GrupoDeUsuario pGrupoDeUsuario)
        {
            //Creo objeto conexion
            strProc = "SP_GRUPOSDEUSUARIOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pGrupoDeUsuario.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pGrupoDeUsuario.Descripcion);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar el Grupo de Usuario, ya existe!!");
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

        public static void Eliminar(Entidades.GrupoDeUsuario pGrupoDeUsuario)
        {
            //Creo objeto conexion
            strProc = "SP_GRUPOSDEUSUARIOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pGrupoDeUsuario.Codigo);
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
