using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSucursal6
{
    public static class CierreCaja
    {
        private static SqlConnection objConexion = null;
        private static string strProc = string.Empty;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        static CierreCaja()
        {
            try
            {
                
                objConexion = new SqlConnection(BaseDatos.StringConexionSucursal6);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ObtenerTodos(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CIERRESDECAJA_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public static DataTable ObtenerEfectivo(int pCodigo, string pMoneda, string nombreTabla)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MOVIMIENTOS_EFECTIVO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Moneda", pMoneda);

            try
            {
                dt.TableName = nombreTabla;
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

        public static DataTable ObtenerCheques(int pCodigo, string pMovimiento, string nombreTabla)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MOVIMIENTOS_CHEQUES";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Movimiento", pMovimiento);

            try
            {
                dt.TableName = nombreTabla;
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

        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CIERRESDECAJATODOS_SELECT";
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
        public static DateTime ObtenerFecha(int pCodigoCierreCaja)
        {
            strProc = "SP_CIERRECAJA_FECHA_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierreCaja);
            try
            {
                objConexion.Open();
                DateTime res = Convert.ToDateTime(objCommand.ExecuteScalar());
                return res;
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
        public static double ObtenerMontoEgreso(int pCodigoCierreCaja)
        {
            strProc = "SP_CAJA_EGRESOSUCURSALESCAJA_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierreCaja);
            try
            {
                objConexion.Open();
                double res = Convert.ToDouble(objCommand.ExecuteScalar());
                return res;
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

        public static DataTable ObtenerCierresPendientes()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CIERRESDECAJAPENDIENTES_SELECT";
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
    }
}
