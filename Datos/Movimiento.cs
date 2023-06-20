using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;
using Servidor;

namespace Datos
{
    public static class Movimiento
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
     //   private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;

        static Movimiento()
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

        public static DataTable ObtenerEfectivoSinCierre(Entidades.PuestoCaja pPuestoCaja, string pMoneda, string nombreTabla)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MOVIMIENTOS_SINCIERRE_EFECTIVO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
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
        public static DataTable ObtenerTransferenciasSinCierre(Entidades.PuestoCaja pPuestoCaja, int pCodigoCierreCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MOVIMIENTOS_TRANFERENCIASRECIBIDAS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierreCaja);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
            
            try
            {
                dt.TableName = "dsTransferenciasRecibidas";
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
        public static double ObtenerMontoEfectivoSinCierre(Entidades.PuestoCaja pPuestoCaja, int pCodigoMoneda)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MOVIMIENTOS_SINCIERREMONTO_EFECTIVO";
            objCommand = new SqlCommand(strProc, objConexion);

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoMoneda", pCodigoMoneda);

            try
            {
                objConexion.Open();
                double res = Convert.ToDouble(objCommand.ExecuteScalar());
                return res;
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
        }
        public static DataTable ObtenerChequesSinCierre(Entidades.PuestoCaja pPuestoCaja, string pMovimiento, string nombreTabla)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MOVIMIENTOS_SINCIERRE_CHEQUES";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
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

        public static int ObtenerCantidadDeMovimientos() { 


            strProc = "SP_MOVIMIENTOSSINCIERRECANTIDAD_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            /* objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
             objDataAdapter.SelectCommand.Parameters.AddWithValue("@Movimiento", pMovimiento);*/

            try
            {
                objConexion.Open();
                int res = Convert.ToInt32(objCommand.ExecuteScalar());
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
    }
}
