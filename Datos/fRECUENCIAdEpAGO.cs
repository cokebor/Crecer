using Servidor;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public static class FrecuenciaDePago
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static FrecuenciaDePago()
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
                strProc = "SP_FRECUENCIASDEPAGO_SELECT";
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
        public static Entidades.FrecuenciaDePago ObtenerUno(int pCodigo)
        {
            Entidades.FrecuenciaDePago objFPago = new Entidades.FrecuenciaDePago();
            strProc = "SP_FRECUENCIASDEPAGO_SELECT_UNO";
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
                    objFPago = null;
                }
                else
                {
                    objFPago.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objFPago.Descripcion = objDataReader["Descripcion"].ToString();
                    objFPago.DiasParaEquivalencia = Convert.ToInt32(objDataReader["DiasParaEquivalencia"]);
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
            return objFPago;
        }
    }
}
