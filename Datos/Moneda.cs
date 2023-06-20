using Servidor;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public static class Moneda
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static Moneda()
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
           // using(objConexion=new SqlConnection(BaseDatos.StringConexion)) { 
                DataTable dt = new DataTable();
            strProc = "SP_MONEDAS_SELECT";
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
        public static DataTable ObtenerActivos()
        {
         //   using (objConexion = new SqlConnection(BaseDatos.StringConexion))
        //    {
                DataTable dt = new DataTable();
                strProc = "SP_MONEDAS_SELECT_ACTIVOS";
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
        public static Entidades.Moneda ObtenerUno(int pCodigo)
        {
         //   using (objConexion = new SqlConnection(BaseDatos.StringConexion))
         //   {
                Entidades.Moneda objMoneda = new Entidades.Moneda();
                strProc = "SP_MONEDAS_SELECT_UNO";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
                try
                {
                    objConexion.Open();
                    objDataReader = objCommand.ExecuteReader();
                    objDataReader.Read();
                    if (objDataReader.HasRows.Equals(false))
                    {
                        objMoneda = null;
                    }
                    else
                    {
                        objMoneda.Codigo = Convert.ToInt32(objDataReader["CodigoMoneda"]);
                        objMoneda.Descripcion = objDataReader["Descripcion"].ToString();
                        objMoneda.FechaCotizacion = Convert.ToDateTime(objDataReader["FechaCotizacion"]);
                        objMoneda.Cotizacion = Convert.ToDouble(objDataReader["Cotizacion"]);
                        objMoneda.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
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
                return objMoneda;
        //    }
        }

        public static void Agregar(Entidades.Moneda pMoneda)
        {
            //Creo objeto conexion
         //   using (objConexion = new SqlConnection(BaseDatos.StringConexion))
        //    {
                strProc = "SP_MONEDAS_INSERT";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pMoneda.Codigo);
                objCommand.Parameters.AddWithValue("@Descripcion", pMoneda.Descripcion);
                objCommand.Parameters.AddWithValue("@FechaCotizacion", pMoneda.FechaCotizacion);
                objCommand.Parameters.AddWithValue("@Cotizacion", pMoneda.Cotizacion);


                try
                {
                    objConexion.Open();
                    objCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlex)
                {
                    if (sqlex.Number == 2601)
                    {
                        throw new Exception("No se pude agregar la Moneda, ya existe!!");
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

        public static void Eliminar(Entidades.Moneda pMoneda)
        {
            //Creo objeto conexion
       //     using (objConexion = new SqlConnection(BaseDatos.StringConexion))
       //     {
                strProc = "SP_MONEDAS_DELETE";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pMoneda.Codigo);
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
      //      }
        }

        public static DataTable ObtenerNovedades()
        {
        //    using (objConexion = new SqlConnection(BaseDatos.StringConexion))
        //    {
                DataTable dt = new DataTable();
                strProc = "SP_MONEDAS_SELECT_NOVEDADES";
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
    //        }
        }

        public static void CambiarEstadoNovedad(Entidades.Moneda pMoneda)
        {
       //     using (objConexion = new SqlConnection(BaseDatos.StringConexion))
      //      {
                strProc = "SP_MONEDAS_UPDATE_NOVEDAD";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pMoneda.Codigo);
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
      //      }
        }

        public static void AgregarDeWeb(Entidades.Moneda pMoneda)
        {
            //Creo objeto conexion
        //    using (objConexion = new SqlConnection(BaseDatos.StringConexion))
      //      {
                strProc = "SP_MONEDAS_INSERT_WEB";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Codigo", pMoneda.Codigo);
                objCommand.Parameters.AddWithValue("@Descripcion", pMoneda.Descripcion);
                objCommand.Parameters.AddWithValue("@FechaCotizacion", pMoneda.FechaCotizacion);
                objCommand.Parameters.AddWithValue("@Cotizacion", pMoneda.Cotizacion);
                objCommand.Parameters.AddWithValue("@Estado", pMoneda.Estado);
                try
                {
                    objConexion.Open();
                    objCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlex)
                {
                    if (sqlex.Number == 2601)
                    {
                        throw new Exception("No se pude agregar Moneda, ya existe!!");
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
       //     }
        }
    }
}
