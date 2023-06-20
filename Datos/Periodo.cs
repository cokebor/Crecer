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
    public static class Periodo
    {
        private static SqlConnection objConexion = null;
        private static string strProc = string.Empty;
        private static SqlDataAdapter objDataAdapter = null;
        static Periodo()
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
            strProc = "SP_PERIODOS_SELECT";
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
        public static DataTable ObtenerTodos(int pCodigoConcepto, int pCodigoTipoSalario,int pCodigoSecuencia)
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_PERIODOSAPAGAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoConcepto", pCodigoConcepto);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipo", pCodigoTipoSalario);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoSecuencia", pCodigoSecuencia);
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

        public static DataTable ObtenerTodos(int pCodigoConcepto)
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_PERIODOSAPAGAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoConcepto", pCodigoConcepto);
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

        public static DataTable ObtenerDevengamientosAAnular(int pCodigoConcepto)
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_PERIODOSABORRAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoConcepto", pCodigoConcepto);
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

        public static DataTable ObtenerTodos(int pCodigoConcepto, DateTime pDesde, DateTime pHasta)
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_PERIODOSDEVENGAMIENTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoConcepto", pCodigoConcepto);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta);
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
