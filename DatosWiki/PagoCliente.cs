using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosWiki
{
    public static class PagoCliente
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        static PagoCliente()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionWiki);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ObtenerDebitosCreditos(Entidades.CuentaBancaria pCuentaBancaria, Entidades.TipoDeTarjetas pTipoTarjeta, Entidades.FormaDePago pFormaDePago)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSCLIENTES_TRANSACCIONESPENDIENTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCuentaBancaria.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoTarjeta", pTipoTarjeta.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoFormaDePago", pFormaDePago.Codigo);
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
        public static DataTable ObtenerDataTable(int pCodigo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CLIENTESINFORME_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);

            try
            {
                dt.TableName = "dsPagoEncabezado";
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

        public static DataTable ObtenerDebitoCreditoUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSCLIENTES_DEBITOCREDITO_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsPagoDebitoCredito";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public static DataTable ObtenerEfectivoUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSCLIENTES_EFECTIVO_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsPagoEfectivo";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerTranferenciasUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSCLIENTES_TRANFERENCIAS_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsPagoTranferencias";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public static DataTable ObtenerChequesUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSCLIENTES_CHEQUES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsPagoCheque";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerImputacionesUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSCLIENTESIMPUTACION_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsPagoImputacion";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerImpuestosUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSCLIENTES_IMPUESTOS_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsPagoImpuestos";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
    }
}
