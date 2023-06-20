using Servidor;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public static class TipoDocumento
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        //private static SqlCommand objCommand = null;
        //private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static TipoDocumento()
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
        public static DataTable Obtener(int pCodigoTipoInscripcion)
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
                DataTable dt = new DataTable();
                strProc = "SP_TIPOSDOCUMENTOS_SELECT";
                objDataAdapter = new SqlDataAdapter(strProc, objConexion);
                objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoInscripcion", pCodigoTipoInscripcion);
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
      

    }
}
