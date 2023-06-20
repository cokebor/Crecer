using Servidor;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public static class TipoLicencia
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static TipoLicencia()
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

        public static void Agregar(Entidades.TipoLicencia objETipoLicencia)
        {
            strProc = "SP_TIPOSLICENCIAS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", objETipoLicencia.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", objETipoLicencia.Descripcion);
            objCommand.Parameters.AddWithValue("@LiquidacionSobre", objETipoLicencia.LiquidacionSobre);
            objCommand.Parameters.AddWithValue("@Descuento", objETipoLicencia.Descuento);

            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Tipo de Licencia, ya existe!!");
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

        public static void Eliminar(Entidades.TipoLicencia objETipoLicencia)
        {
            //Creo objeto conexion
            strProc = "SP_TIPOSLICENCIAS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", objETipoLicencia.Codigo);
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

        public static DataTable ObtenerTodos(bool pTodas)
        {
                DataTable dt = new DataTable();
                strProc = "SP_TIPOSLICENCIAS_SELECT";
                objDataAdapter = new SqlDataAdapter(strProc, objConexion);
                objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                objDataAdapter.SelectCommand.Parameters.AddWithValue("@Todas", pTodas);
            
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

    }
}
