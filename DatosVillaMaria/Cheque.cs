using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosVillaMaria
{
    public static class Cheque
    {
        private static SqlConnection objConexion = null;
        private static string strProc = string.Empty;
        //private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        static Cheque()
        {
            try
            {
                
                objConexion = new SqlConnection(BaseDatos.StringConexionVillaMaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable ObtenerADPorCierre(int pCodigo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_AD_PORCIERRE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);
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
