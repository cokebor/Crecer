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
    public static class Usuario
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static Usuario()
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
            strProc = "SP_USUARIOS_SELECT";
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

        public static Entidades.Usuario ObtenerUno(Entidades.Usuario pUsuario, int pCodigoPuestoCaja)
        {
            Entidades.Usuario objUsuario = new Entidades.Usuario();
            strProc = "SP_USUARIOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Usuario", pUsuario.NombreUsuario);
            objCommand.Parameters.AddWithValue("@Contraseña", pUsuario.ContraseñaEncriptada);
            objCommand.Parameters.AddWithValue("@PuestoCaja", pCodigoPuestoCaja);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read()) {
                    objUsuario.NombreUsuario = pUsuario.NombreUsuario;
                    objUsuario.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objUsuario.ColorFormularios = objDataReader["ColorFormularios"].ToString();
                    objUsuario.ColorFormularioMDI = objDataReader["ColorFormularioMDI"].ToString();
                    objUsuario.Nombre= objDataReader["Nombre"].ToString();
                    objUsuario.Apellido = objDataReader["Apellido"].ToString();
                    objUsuario.GrupoDeUsuario = GrupoDeUsuario.ObtenerUno(Convert.ToInt32(objDataReader["CodigoGrupoDeUsuario"]));
                    objUsuario.ContraseñaEncriptada = objDataReader["Contraseña"].ToString();
                    objUsuario.Contraseña = Utilidades.Seguridad.DesencriptarClave(objUsuario.ContraseñaEncriptada);
                    objUsuario.ImpresoraComprobantes = objDataReader["ImpresoraComprobantes"].ToString();
                    objUsuario.Termica = Convert.ToBoolean(objDataReader["Termica"]);
                    objUsuario.ImpresoraInformes = objDataReader["ImpresoraInformes"].ToString();
                    
                    //objUsuario.PuestosDeCaja = PuestoCaja.ObtenerAlgunos(objUsuario.Codigo);
                    
                    //objUsuario.ImpresoraInformes = objDataReader["ImpresoraInformes"].ToString();
                    //objUsuario.BandejaInformes = Convert.ToInt32(objDataReader["BandejaInformes"]);
                }

                

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
                
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
            return objUsuario;
        }

        public static Entidades.Usuario ObtenerUno(int pCodigoUsuario)
        {
            Entidades.Usuario objUsuario = new Entidades.Usuario();
            strProc = "SP_USUARIOS_SELECT_UNO2";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoUsuario);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objUsuario.NombreUsuario = objDataReader["Usuario"].ToString();
                    objUsuario.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objUsuario.ColorFormularios = objDataReader["ColorFormularios"].ToString();
                    objUsuario.ColorFormularioMDI = objDataReader["ColorFormularioMDI"].ToString();
                    objUsuario.Nombre = objDataReader["Nombre"].ToString();
                    objUsuario.Apellido = objDataReader["Apellido"].ToString();
                    objUsuario.GrupoDeUsuario = GrupoDeUsuario.ObtenerUno(Convert.ToInt32(objDataReader["CodigoGrupoDeUsuario"]));
                    objUsuario.Contraseña = objDataReader["Contraseña"].ToString();
                    objUsuario.ImpresoraComprobantes = objDataReader["ImpresoraComprobantes"].ToString();
                    objUsuario.Termica = Convert.ToBoolean(objDataReader["Termica"]);
                    objUsuario.ImpresoraInformes = objDataReader["ImpresoraInformes"].ToString();


                    objUsuario.PuestosDeCaja = PuestoCaja.ObtenerAlgunos(objUsuario.Codigo);

                    //objUsuario.ImpresoraInformes = objDataReader["ImpresoraInformes"].ToString();
                    //objUsuario.BandejaInformes = Convert.ToInt32(objDataReader["BandejaInformes"]);
                }



            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);

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
            return objUsuario;
        }
        public static bool ExisteUsuario(Entidades.Usuario pUsuario) {
            bool res = false;
            strProc = "SP_USUARIOS_VALIDAR_USUARIO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Usuario", pUsuario.NombreUsuario);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                res = Convert.ToBoolean(objDataReader["EXISTE"]);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
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
            return res;
        }

        public static bool ExisteUsuarioParaEmpleado(Entidades.Usuario pUsuario)
        {
            bool res = false;
            strProc = "SP_USUARIOS_VALIDAR_USUARIOEMPLEADO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            objCommand.Parameters.AddWithValue("@Apellido", pUsuario.Apellido);
            objCommand.Parameters.AddWithValue("@CodigoGrupo", pUsuario.GrupoDeUsuario.Codigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                res = Convert.ToBoolean(objDataReader["EXISTE"]);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
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
            return res;
        }


        

        public static void Agregar(Entidades.Usuario pUsuario)
        {
            //Creo objeto conexion
            strProc = "SP_USUARIOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            objCommand.Parameters.AddWithValue("@Apellido", pUsuario.Apellido);
            objCommand.Parameters.AddWithValue("@CodigoGrupo", pUsuario.GrupoDeUsuario.Codigo);
            objCommand.Parameters.AddWithValue("@Usuario", pUsuario.NombreUsuario);
            objCommand.Parameters.AddWithValue("@Contraseña", pUsuario.ContraseñaEncriptada);
            objCommand.Parameters.AddWithValue("@Color", pUsuario.ColorFormularios);
            objCommand.Parameters.AddWithValue("@ColorMDI", pUsuario.ColorFormularioMDI);

            DataTable dtDetalle = new DataTable();
            DataColumn column;
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "CodigoPuestoCaja";
            dtDetalle.Columns.Add(column);

            foreach (Entidades.PuestoCaja item in pUsuario.PuestosDeCaja)
            {
                dtDetalle.Rows.Add(item.Codigo);
            }
            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Puestos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDetalle;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);

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

        public static void Modificar(Entidades.Usuario pUsuario)
        {
            //Creo objeto conexion
            strProc = "SP_USUARIOS_UPDATE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pUsuario.Codigo);
            objCommand.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            objCommand.Parameters.AddWithValue("@Apellido", pUsuario.Apellido);
            objCommand.Parameters.AddWithValue("@CodigoGrupo", pUsuario.GrupoDeUsuario.Codigo);
            objCommand.Parameters.AddWithValue("@Usuario", pUsuario.NombreUsuario);
            objCommand.Parameters.AddWithValue("@Contraseña", pUsuario.ContraseñaEncriptada);

            DataTable dtDetalle = new DataTable();
            DataColumn column;
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "CodigoPuestoCaja";
            dtDetalle.Columns.Add(column);

            foreach (Entidades.PuestoCaja item in pUsuario.PuestosDeCaja)
            {
                dtDetalle.Rows.Add(item.Codigo);
            }
            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Puestos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDetalle;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
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
        /*
        public static void Modificar(Entidades.Usuario pUsuario, int pCodigoGrupo)
        {
            //Creo objeto conexion
            strProc = "SP_USUARIOS_UPDATE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            objCommand.Parameters.AddWithValue("@Apellido", pUsuario.Apellido);
            objCommand.Parameters.AddWithValue("@CodigoGrupo", pUsuario.GrupoDeUsuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoGrupoAnterior", pCodigoGrupo);
            objCommand.Parameters.AddWithValue("@Usuario", pUsuario.NombreUsuario);
            objCommand.Parameters.AddWithValue("@Contraseña", pUsuario.ContraseñaEncriptada);
            
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
        }*/

        public static void Eliminar(Entidades.Usuario pUsuario)
        {
            //Creo objeto conexion
            strProc = "SP_USUARIOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pUsuario.Codigo);
            //objCommand.Parameters.AddWithValue("@Apellido", pUsuario.Apellido);
            //objCommand.Parameters.AddWithValue("@CodigoGrupo", pUsuario.GrupoDeUsuario.Codigo);
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

        public static void CambiarClave(Entidades.Usuario pUsuario)
        {
            //Creo objeto conexion
            strProc = "SP_USUARIOS_UPDATE_CLAVE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pUsuario.Codigo);
            objCommand.Parameters.AddWithValue("@Contraseña", pUsuario.ContraseñaEncriptada);
            objCommand.Parameters.AddWithValue("@Color", pUsuario.ColorFormularios);
            objCommand.Parameters.AddWithValue("@ColorMDI", pUsuario.ColorFormularioMDI);

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
