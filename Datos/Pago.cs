using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class Pago
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static SqlDataAdapter objDataAdapter = null;
        static Pago()
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

        public static int Agregar(Entidades.Pago pPago, Entidades.Asiento pAsiento, int pCodigoRecibo)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_PAGOSPROVEEDORES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pPago.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pPago.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@NombreProveedor", pPago.Proveedor.Nombre);
            objCommand.Parameters.AddWithValue("@Fecha", pPago.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pPago.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pPago.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pPago.Numero);
            objCommand.Parameters.AddWithValue("@Observaciones", pPago.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pPago.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPago.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@TipoDoc", pPago.TipoDocumentoProveedor.TipoDoc.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoRecibo", pCodigoRecibo);
            objCommand.Parameters.AddWithValue("@Total", pPago.Total);
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
                    dtEfectivo.Rows.Add(contador++, fe.Moneda.Codigo, fe.Moneda.Cotizacion, -fe.Importe);
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
            if (pPago.Cheques.Count > 0)
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
                paramItems.ParameterName = "@Cheques";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtCheques;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }

            #endregion
            
            #region ChequesPropios
            if (pPago.ChequesPropios.Count > 0)
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
                column.DataType = System.Type.GetType("System.Int32");
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
                foreach (Entidades.Cheque che in pPago.ChequesPropios)
                {
                    dtChequesPropios.Rows.Add(contador++, che.Banco.Codigo, che.NumeroCheque, che.CuentaBancaria.Codigo, che.FechaEmision, che.FechaPago, che.Librador, che.Cuit, che.Moneda.Codigo, che.Moneda.Cotizacion, che.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@ChequesPropios";
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
                column.DataType = System.Type.GetType("System.Int32");
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
                    dtDebitoCredito.Rows.Add(contador++, cd.FormaDePago.Codigo, cd.CuentaBancaria.Codigo, cd.TipoDeTarjetas.Codigo, cd.Cuotas, cd.NroCupon, cd.Importe);
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
                foreach (Entidades.FacturaCompraImputacion fci in pPago.FacturasImputacion)
                {
                    dtFacturas.Rows.Add(contador,fci.TipoDocumentoProveedor.Codigo, fci.Codigo, fci.Monto,fci.ImputacionAnterior, fci.CodigoImputacion);
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
            #region Impuestos
            if (pPago.Impuestos.Count > 0)
            {
                DataTable dtImpuestos = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtImpuestos.Columns.Add(column);

                /*column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoFacturaCompra";
                dtImpuestos.Columns.Add(column);*/

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoImpuesto";
                dtImpuestos.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "ImporteRetenido";
                dtImpuestos.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoRegimen";
                dtImpuestos.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "AlicuotaAplicada";
                dtImpuestos.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Total";
                dtImpuestos.Columns.Add(column);

                contador = 1;
                foreach (Entidades.PagosProveedoresImpuestos fci in pPago.Impuestos)
                {
                    dtImpuestos.Rows.Add(contador, /*fci.FacturaCompra.Codigo,*/ fci.Impuesto.Codigo, fci.ImporteRetenido, fci.Regimen.Codigo, fci.AlicuotaAplicada, fci.TotalComprobante);
                    contador++;
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@FacturasImpuesto";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtImpuestos;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
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

        public static DataTable ObtenerPagosPendientesConciliar()
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORESPENDIENTESDECONCILIAR";
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

        public static DataTable ObtenerFechasRetMunicipales()
        {
            DataTable dt = new DataTable();
            strProc = "SP_RETENCIONESMUNICIPALES_FECHAS_SELECT";
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

        public static DataTable ObtenerDataTable(int pCodigo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORES_SELECT_UNO";
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
            strProc = "SP_PAGOSPROVEEDORES_EFECTIVO_SELECT_UNO";
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
            strProc = "SP_PAGOSPROVEEDORES_CHEQUES_SELECT_UNO";
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
        public static DataTable ObtenerChequesRechazadosUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORESCR_CHEQUES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsPagoChequeRechazados";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public static DataTable ObtenerPagosChequesProveedores(int pCodigoProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORES_CHEQUESPROVEEDORES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pCodigoProveedor);
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
            strProc = "SP_PAGOSPROVEEDORESIMPUTACION_SELECT_UNO";
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
            strProc = "SP_PAGOSPROVEEDORES_IMPUESTOS_SELECT_UNO";
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
        public static DataTable ObtenerDebitoCreditoUno(int pCodigoPago)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORES_DEBITOCREDITO_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoPago);
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

        public static DataTable ObtenerTranferenciasUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORES_TRANFERENCIAS_SELECT_UNO";
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
        public static DataTable ObtenerPagosPorProveedor(int pCodigo, DateTime pFecha)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORES_PORPROVEEDOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pCodigo);
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
            strProc = "SP_PAGOSPROVEEDORES2_SELECT_UNO";
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

        public static DataTable ObtenerParaImputar(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORESAIMPUTAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static void Imputar(Entidades.Pago pPago)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_IMPUTACIONESPROVEEDORES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoPago", pPago.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pPago.Proveedor.Codigo);

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
                foreach (Entidades.FacturaCompraImputacion fci in pPago.FacturasImputacion)
                {
                    dtFacturas.Rows.Add(contador, fci.TipoDocumentoProveedor.Codigo, fci.Codigo, fci.Monto, fci.ImputacionAnterior, fci.CodigoImputacion);
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

        public static void Imputar(Entidades.Pago pPago, int pCodigoFactura)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_IMPUTACIONESPROVEEDORES";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRecibo", pPago.Codigo);
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

        public static Entidades.RetencionesGanancias ObtenerTotalPagosRetenciones(int pCodigoProveedor, DateTime pDesde, DateTime pHasta)
        {
            Entidades.RetencionesGanancias ret = new Entidades.RetencionesGanancias();
            strProc = "SP_RETENCIONESGANANCIAS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pCodigoProveedor);
            objCommand.Parameters.AddWithValue("@Desde", pDesde);
            objCommand.Parameters.AddWithValue("@hasta", pHasta);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    ret = null;
                }
                else
                {
                    ret.TotalPagos= Convert.ToDouble(objDataReader["TotalPagos"]);
                    ret.TotalRetencionesGanancias = Convert.ToDouble(objDataReader["TotalRetencionesGanancias"]);
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
            return ret;
        }
        
        public static DataTable ObtenerRetenciones(int pCodigoPago)
        {
            DataTable dt = new DataTable();
            strProc = "SP_RETENCIONESPAGOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPago", pCodigoPago);
            
            try
            {
                dt.TableName = "DataSet1";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return dt;
        }
        public static DataTable ObtenerRetencionesMunicipales(int pCodigoPago)
        {
            DataTable dt = new DataTable();
            strProc = "SP_RETENCIONESMUNICIPALESPAGOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPago", pCodigoPago);

            try
            {
                dt.TableName = "DataSet2";
                objDataAdapter.Fill(dt);
                


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }

        public static List<Entidades.RetencionesMunicipales> ObtenerRetencionesMunicipales(DateTime pDesde, DateTime pHasta)
        {
            List<Entidades.RetencionesMunicipales> lista = new List<Entidades.RetencionesMunicipales>();
            Entidades.RetencionesMunicipales ret;

            strProc = "SP_RETENCIONESMUNICIPALES_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows.Equals(false))
                {
                    lista = null;
                }
                else
                {
                    while (objDataReader.Read())
                    {
                        ret = new Entidades.RetencionesMunicipales();
                        //per.CuitEmpresa= objDataReader["CuitEmpresa"].ToString();
                        ret.NroRetencion = objDataReader["NroRetencion"].ToString();
                        ret.LetraRetencion = Convert.ToChar(objDataReader["LetraRetencion"].ToString());
                        ret.Comprobante = objDataReader["Comprobante"].ToString();
                        ret.CuitProveedor = objDataReader["CuitProveedor"].ToString();
                        ret.BaseImponible = Convert.ToDouble(objDataReader["BaseImponible"]);
                        ret.Alicuota = Convert.ToDouble(objDataReader["Alicuota"]);
                        ret.MontoRetencion = Convert.ToDouble(objDataReader["MontoRetencion"]);
                        ret.Estado = Convert.ToChar(objDataReader["Estado"].ToString());
                        ret.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                        ret.NombreProveedor = objDataReader["NombreProveedor"].ToString();
                        ret.Calle = objDataReader["Calle"].ToString();
                        ret.Numero = objDataReader["Numero"].ToString();
                        ret.BarrioLocalidad = objDataReader["BarrioLocalidad"].ToString();
                        ret.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                        ret.FechaInicioRetencion = Convert.ToDateTime(objDataReader["FechaInicioRetencion"]);
                        ret.FechaCambiosDatos = Convert.ToDateTime(objDataReader["FechaCambioDatos"]);


                        lista.Add(ret);

                    }
                }
                objDataReader.Close();
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
            return lista;
        }
    }
}
