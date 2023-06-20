using Servidor;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public static class Banco
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static Banco()
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
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
                DataTable dt = new DataTable();
                strProc = "SP_BANCOS_SELECT";
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
            //}
        }
        public static DataTable ObtenerActivos()
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
                DataTable dt = new DataTable();
                strProc = "SP_BANCOS_SELECT_ACTIVOS";
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
       // }

        public static DataTable ObtenerActivosDeCuentasActivas()
        {
            /*using (SqlConnection objConexion2 = new SqlConnection(BaseDatos.StringConexion))
            {*/
                DataTable dt = new DataTable();
                strProc = "SP_BANCOS_DECUENTAS_SELECT";
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
            //}
        }

        public static DataTable ObtenerActivosDeCuentasActivasParaTransferenciasClientes()
        {
            /*using (SqlConnection objConexion2 = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_BANCOS_DECUENTASTRANSFERENCIASCLIENTES_SELECT";
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
            //}
        }

        public static DataTable ObtenerBancoCuentaDebitoCredito(bool pVentas, bool pDebito)
        {
            /*using (SqlConnection objConexion2 = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_CUENTABANCARIADEBITOCREDITO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Ventas", pVentas);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Debito", pDebito);
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
            //}
        }
        public static Entidades.Banco ObtenerUno(int pCodigo)
        {
            //using (objConexion = new SqlConnection(BaseDatos.StringConexion))
          //  {
                Entidades.Banco objBanco = new Entidades.Banco();
                strProc = "SP_BANCOS_SELECT_UNO";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
                try
                {
                    objConexion.Open();
                    objDataReader = objCommand.ExecuteReader();
                    objDataReader.Read();
                    objBanco.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objBanco.Descripcion = objDataReader["Descripcion"].ToString();
                    Enumeraciones.Enumeraciones.Estados estado;

                    Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                    objBanco.Estado = estado;

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
                return objBanco;
          //  }
        }

        public static Entidades.Banco ObtenerUnoActivo(int pCodigo)
        {
          //  using (objConexion = new SqlConnection(BaseDatos.StringConexion))
          //  {
                Entidades.Banco objBanco = new Entidades.Banco();
                strProc = "SP_BANCO_SELECT_UNO_ACTIVO";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
                try
                {
                    objConexion.Open();
                    objDataReader = objCommand.ExecuteReader();
                    objDataReader.Read();
                    objBanco.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objBanco.Descripcion = objDataReader["Descripcion"].ToString();
                    Enumeraciones.Enumeraciones.Estados estado;

                    Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                    objBanco.Estado = estado;

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
                return objBanco;
        //    }
        }
        public static void Agregar(Entidades.Banco pBanco)
        {
          //  using (objConexion = new SqlConnection(BaseDatos.StringConexion))
         //   {
                //Creo objeto conexion
                strProc = "SP_BANCOS_INSERT";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pBanco.Codigo);
                objCommand.Parameters.AddWithValue("@Descripcion", pBanco.Descripcion);
                try
                {
                    objConexion.Open();
                    objCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlex)
                {
                    if (sqlex.Number == 2601)
                    {
                        throw new Exception("No se pude agregar Banco, ya existe!!");
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
         //   }
        }
        public static void Eliminar(Entidades.Banco pBanco)
        {
            //Creo objeto conexion
         //   using (objConexion = new SqlConnection(BaseDatos.StringConexion))
        //    {
                strProc = "SP_BANCOS_DELETE";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pBanco.Codigo);
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
       //     }
        }

        public static DataTable ObtenerNovedades()
        {
          //  using (objConexion = new SqlConnection(BaseDatos.StringConexion))
         //   {
                DataTable dt = new DataTable();
                strProc = "SP_BANCOS_SELECT_NOVEDADES";
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
       //     }
        }
        public static void CambiarEstadoNovedad(Entidades.Banco pBanco)
        {
          //  using (objConexion = new SqlConnection(BaseDatos.StringConexion))
          //  {
                strProc = "SP_BANCOS_UPDATE_NOVEDAD";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pBanco.Codigo);
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
         //   }
        }

        public static void AgregarDeWeb(Entidades.Banco pBanco)
        {
          //  using (objConexion = new SqlConnection(BaseDatos.StringConexion))
         //   {
                //Creo objeto conexion
                strProc = "SP_BANCOS_INSERT_WEB";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pBanco.Codigo);
                objCommand.Parameters.AddWithValue("@Descripcion", pBanco.Descripcion);
                objCommand.Parameters.AddWithValue("@Estado", pBanco.Estado);
                try
                {
                    objConexion.Open();
                    objCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlex)
                {
                    if (sqlex.Number == 2601)
                    {
                        throw new Exception("No se pude agregar Banco, ya existe!!");
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
        //    }
        }

    }
}
