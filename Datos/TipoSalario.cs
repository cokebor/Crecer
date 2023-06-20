using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servidor;
using System.Data;

namespace Datos
{
    public static class TipoSalario
    {
        private static SqlConnection objConexion = null;
        private static string strProc = string.Empty;
        private static SqlDataAdapter objDataAdapter = null;
        static TipoSalario()
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
            strProc = "SP_TIPOSSALARIOS_SELECT";
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
        
        public static DataTable ObtenerAlgunos()
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSSALARIOSALGUNOS_SELECT";
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
        public static DataTable ObtenerAlgunos(int pCodigoConcepto, string pPeriodo)
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_PERIODOSAPAGAR2_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoConcepto", pCodigoConcepto);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Periodo", pPeriodo);
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

        public static DataTable ObtenerParaBorrar(int pCodigoConcepto, string pPeriodo)
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_DEVENGAMIENTOSABORRAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoConcepto", pCodigoConcepto);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Periodo", pPeriodo);
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
