using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public static class PagoCliente
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        static PagoCliente()
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

        public static int Agregar(Entidades.PagoCliente pPago, Entidades.Asiento pAsiento, int pCodigoRecibo)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_PAGOSCLIENTES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pPago.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCliente", pPago.Cliente.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pPago.Fecha);
            //objCommand.Parameters.AddWithValue("@Letra", pPago.Letra);
            //objCommand.Parameters.AddWithValue("@PuntoDeVenta", pPago.PuntoDeVenta);
            //objCommand.Parameters.AddWithValue("@Numero", pPago.Numero);
            objCommand.Parameters.AddWithValue("@Observaciones", pPago.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pPago.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPago.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@TipoDoc", pPago.TipoDocumentoCliente.TipoDoc.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoRecibo", pCodigoRecibo);
            objCommand.Parameters.AddWithValue("@Total", pPago.Total);
            objCommand.Parameters.AddWithValue("@CodigoImputacion2", pPago.Imputacion);
            objCommand.Parameters.AddWithValue("@ChequeRechazado", pPago.ChequeRechazado);

            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Efectivo

            if (pPago.FacturaEfectivo.Count > 0)
            {
                DataTable dtEfectivo = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtEfectivo.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoMoneda";
                dtEfectivo.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtEfectivo.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtEfectivo.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Factura_Efectivo fe in pPago.FacturaEfectivo)
                {
                    dtEfectivo.Rows.Add(contador++, fe.Moneda.Codigo, fe.Moneda.Cotizacion, fe.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Efectivo";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtEfectivo;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            #region ChequesDeTerceros
            if (pPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("CR") && pPago.Cheques.Count > 0)
            {
                DataTable dtCheques = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCheque";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtCheques.Columns.Add(column);


                contador = 1;
                foreach (Entidades.Cheque che in pPago.Cheques)
                {
                    dtCheques.Rows.Add(contador++, che.Codigo, che.Moneda.Cotizacion);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Cheques2";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtCheques;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }

            #endregion

            #region ChequesPropios
            if (pPago.TipoDocumentoCliente.TipoDoc.Codigo.Equals("RC") && pPago.Cheques.Count > 0)
            {
                DataTable dtChequesPropios = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoBanco";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NroCheque";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaBancaria";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "FechaEmision";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "FechaPago";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Librador";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUIT";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoMoneda";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtChequesPropios.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtChequesPropios.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Cheque che in pPago.Cheques)
                {
                    dtChequesPropios.Rows.Add(contador++, che.Banco.Codigo, che.NumeroCheque, che.CuentaBancaria.Codigo, che.FechaEmision, che.FechaPago, che.Librador, che.Cuit, che.Moneda.Codigo, che.Moneda.Cotizacion, che.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Cheques";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtChequesPropios;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region Tranferencias
            if (pPago.Tranferencias.Count > 0)
            {
                DataTable dtTranferencias = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoBanco";
                dtTranferencias.Columns.Add(column);


                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaBancaria";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtTranferencias.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Tranferencia tra in pPago.Tranferencias)
                {
                    dtTranferencias.Rows.Add(contador++, tra.Banco.Codigo, tra.CuentaBancaria.Codigo, tra.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Tranferencias";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtTranferencias;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region DebitoCredito
            if (pPago.CreditosDebitos.Count > 0)
            {
                DataTable dtDebitoCredito = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoFormaDePago";
                dtDebitoCredito.Columns.Add(column);


                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoTipoTarjeta";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Cuotas";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NroCupon";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtDebitoCredito.Columns.Add(column);

                contador = 1;
                foreach (Entidades.CreditoDebito cd in pPago.CreditosDebitos)
                {
                    dtDebitoCredito.Rows.Add(contador++, cd.FormaDePago.Codigo, cd.CuentaBancaria.Codigo,cd.TipoDeTarjetas.Codigo,cd.Cuotas,cd.NroCupon, cd.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@DebitoCredito";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtDebitoCredito;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            #region Imputacion
            if (pPago.FacturasImputacion.Count > 0)
            {
                DataTable dtFacturas = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoTipoDocumentoProveedor";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Codigo";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Monto";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "ImputacionAnterior";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Char");
                column.ColumnName = "CodigoImputacion";
                dtFacturas.Columns.Add(column);


                contador = 1;
                foreach (Entidades.FacturaImputacion fci in pPago.FacturasImputacion)
                {
                    dtFacturas.Rows.Add(contador, fci.TipoDocumentoCliente.Codigo, fci.Codigo, fci.Monto, fci.ImputacionAnterior, fci.CodigoImputacion);
                    contador++;
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@FacturasImputacion";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtFacturas;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            #region DataTable Impuestos
            DataTable dtImpuestos = new DataTable();

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoImpuesto";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Importe";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "CuentaContable";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Fecha";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "NroAgente";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "NroComprobante";
            dtImpuestos.Columns.Add(column);

            contador = 1;
            foreach (Entidades.FacturaImpuesto fi in pPago.Impuestos)
            {
                dtImpuestos.Rows.Add(contador++, fi.Impuesto.Codigo, fi.Importe, fi.Impuesto.CuentaContable.Codigo, fi.Impuesto.Fecha, fi.Impuesto.Nroagente, fi.Impuesto.NroComprobante);
            }

            paramItems = new SqlParameter();
            paramItems.ParameterName = "@Impuestos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtImpuestos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);


            #endregion

            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;


                int CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);
                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);
                int res = Convert.ToInt32(objCommand.ExecuteScalar());

                // AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                transaccion.Commit();
                return res;
            }

            catch (Exception ex)
            {
                transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
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

        public static DataTable ObtenerPagosPorCliente(int pCodigo, DateTime pFecha)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSCLIENTES_PORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCodigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pFecha);
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerUno(int pCodigo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSCLIENTES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;

        }

        public static DataTable ObtenerParaImputar(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSAIMPUTAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;

        }

        public static void Imputar(Entidades.PagoCliente pPago)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_IMPUTACIONESCLIENTES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoPago", pPago.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCliente", pPago.Cliente.Codigo);

            DataColumn column;
            SqlParameter paramItems;
            int contador;


            #region Imputacion
            if (pPago.FacturasImputacion.Count > 0)
            {
                DataTable dtFacturas = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoTipoDocumentoProveedor";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Codigo";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Monto";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "ImputacionAnterior";
                dtFacturas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Char");
                column.ColumnName = "CodigoImputacion";
                dtFacturas.Columns.Add(column);


                contador = 1;
                foreach (Entidades.FacturaImputacion fci in pPago.FacturasImputacion)
                {
                    dtFacturas.Rows.Add(contador, fci.TipoDocumentoCliente.Codigo, fci.Codigo, fci.Monto, fci.ImputacionAnterior, fci.CodigoImputacion);
                    contador++;
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@FacturasImputacion";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtFacturas;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                objCommand.ExecuteNonQuery();

                // AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                transaccion.Commit();
            }

            catch (Exception ex)
            {
                transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
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

        public static void Imputar(Entidades.PagoCliente pPago,int pCodigoTipo, int pCodigoFactura)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_IMPUTACIONESCLIENTES";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRecibo", pPago.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipo", pCodigoTipo);
            objCommand.Parameters.AddWithValue("@CodigoFactura", pCodigoFactura);
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

    }
}
