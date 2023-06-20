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
    public static class Factura
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        //private static SqlDataReader objDataReader = null;
        static Factura()
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

        public static int Agregar(Entidades.Factura pFactura, Entidades.Asiento pAsiento)
        {
     
            //Creo objeto conexion
            strProc = "SP_FACTURAS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion=null;
            objCommand.CommandTimeout = 0;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pFactura.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pFactura.Fecha);
            objCommand.Parameters.AddWithValue("@FechaVencimientoPago", pFactura.FechaVencimientoPago);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoCliente", pFactura.Cliente.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSucursalCliente", pFactura.SucursalCliente.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@FacturaPorKilo", pFactura.Cliente.FacturaKilos);
            objCommand.Parameters.AddWithValue("@CodigoVendedor", pFactura.Vendedor.Codigo);
            objCommand.Parameters.AddWithValue("@NroRemito", pFactura.NroRemito);
            objCommand.Parameters.AddWithValue("@Neto105", pFactura.Neto105);
            objCommand.Parameters.AddWithValue("@Iva105", pFactura.Iva105);
            objCommand.Parameters.AddWithValue("@Neto21", pFactura.Neto21);
            objCommand.Parameters.AddWithValue("@Iva21", pFactura.Iva21);
            objCommand.Parameters.AddWithValue("@Cae", pFactura.Cae);
            objCommand.Parameters.AddWithValue("@FechaVenCae", pFactura.FechaVenCae);
            objCommand.Parameters.AddWithValue("@FacturaKilos", pFactura.FacturaKilos);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);
            objCommand.Parameters.AddWithValue("@PercepcionMunicipal", pFactura.PercepcionMunicipal);
            objCommand.Parameters.AddWithValue("@AlicuotaMunicipal", pFactura.Cliente.TipoContribuyente.PorcentajePercepcion);
            
            objCommand.Parameters.AddWithValue("@Observaciones", pFactura.Observaciones); 


            #region DataTable Productos

            DataTable dtProductos = new DataTable();
            DataColumn column;

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoProducto";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Descripcion";
            dtProductos.Columns.Add(column);
            
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Cantidad";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Kilos";
            dtProductos.Columns.Add(column);
            
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PrecioUnitario";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PorcIva";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Iva";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Lote";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Cubetas";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);

            


            int contador = 1;
            foreach (Entidades.Factura_Detalle fd in pFactura.Detalles)
            {
                dtProductos.Rows.Add(fd.Renglon, fd.Producto.Codigo, fd.Producto.Descripcion,fd.MovStock_Lotes.Cantidad, 
                     fd.Kilos,fd.PrecioUnitario,fd.PorIva, fd.Iva, fd.MovStock_Lotes.IdLote.IdLote,fd.Codigofactura,fd.RenglonFactura,fd.FacturaPorCubeta, contador);
                contador++;
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion
            #region DataTable Descuentos

            DataTable dtDescuentos = new DataTable();
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Descripcion";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Porcentaje";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Cantidad";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Kilos";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PrecioUnitario";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Iva";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoFactura";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonFactura";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtDescuentos.Columns.Add(column);




            contador = 1;
            foreach (Entidades.Factura_DescuentosEspecialesDetalle fd in pFactura.DescuentosEspecialesDetalle)
            {
                dtDescuentos.Rows.Add(fd.Renglon,fd.Detalle,fd.Porcentaje, fd.Cantidad,
                     fd.Kilos, fd.PrecioUnitario, fd.Iva, fd.Codigofactura, fd.RenglonFactura,contador);
                contador++;
            }

            paramItems = new SqlParameter();
            paramItems.ParameterName = "@Descuentos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDescuentos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion
            #region DataTable Efectivo
            if (pFactura.FacturaEfectivo.Count > 0) {
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
                foreach (Entidades.Factura_Efectivo fe in pFactura.FacturaEfectivo)
                {
                    dtEfectivo.Rows.Add(contador++,fe.Moneda.Codigo, fe.Moneda.Cotizacion, fe.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Efectivo";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtEfectivo;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region DataTable Cheques
            if (pFactura.Cheques.Count > 0)
            {
                DataTable dtCheques = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoBanco";
                dtCheques.Columns.Add(column);

                column = new DataColumn(); 
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NroCheque";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "FechaEmision";
                dtCheques.Columns.Add(column);
                
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "FechaPago";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Librador";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUIT";
                dtCheques.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoMoneda";
                dtCheques.Columns.Add(column);
                
                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtCheques.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtCheques.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Cheque che in pFactura.Cheques)
                {
                    dtCheques.Rows.Add(contador++, che.Banco.Codigo, che.NumeroCheque, che.CuentaBancaria.Codigo, che.FechaEmision, che.FechaPago, che.Librador, che.Cuit, che.Moneda.Codigo, che.Moneda.Cotizacion,che.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Cheques";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtCheques;
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
                //objCommand.ExecuteScalar();

                //int CodigoAsiento = AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                //objCommand.Parameters.AddWithValue("@CodigoAsientoTemp", CodigoAsiento);
                int res= Convert.ToInt32(objCommand.ExecuteScalar());

                //AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
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
     
        public static string ObtenerObservaciones(int pCodigoTipoDocumentoCliente, int pCodigo)
        {
            string resultado = "";
            strProc = "SP_FACTURASPAGOSOBSERVACIONES_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pCodigoTipoDocumentoCliente);
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {

                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    resultado = "";
                }
                else {
                    resultado = objDataReader["Observaciones"].ToString();
                }
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
            return resultado;
        }

        public static DataTable ObtenerComprobantesCtasCorrientesClientes(char pCodigoTipoComprobante, Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_COMPROBANTESCTASCTESCLIENTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@TipoDocumentos", pCodigoTipoComprobante);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            try
            {
                dt.TableName ="dsCuentasCorrientesClientes";
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

        public static void AgregarObservaciones(int pCodigoTipoDocumento, int pCodigo, string pObservaciones) {
            strProc = "SP_FACTURASPAGOSOBSERVACIONES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pCodigoTipoDocumento);
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            objCommand.Parameters.AddWithValue("@Observaciones", pObservaciones);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                throw new Exception(sqlex.Message);
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
        public static int AgregarDeVentaInicial(Entidades.Factura pFactura, Entidades.Asiento pAsiento)
        {

            //Creo objeto conexion
            strProc = "SP_FACTURASVENTASINICIALES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pFactura.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pFactura.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoCliente", pFactura.Cliente.Codigo);
            objCommand.Parameters.AddWithValue("@FacturaPorKilo", pFactura.Cliente.FacturaKilos);
            objCommand.Parameters.AddWithValue("@CodigoVendedor", pFactura.Vendedor.Codigo);
            objCommand.Parameters.AddWithValue("@NroRemito", pFactura.NroRemito);
            objCommand.Parameters.AddWithValue("@Neto105", pFactura.Neto105);
            objCommand.Parameters.AddWithValue("@Iva105", pFactura.Iva105);
            objCommand.Parameters.AddWithValue("@Neto21", pFactura.Neto21);
            objCommand.Parameters.AddWithValue("@Iva21", pFactura.Iva21);
            objCommand.Parameters.AddWithValue("@Cae", pFactura.Cae);
            objCommand.Parameters.AddWithValue("@FechaVenCae", pFactura.FechaVenCae);
            objCommand.Parameters.AddWithValue("@FacturaKilos", pFactura.FacturaKilos);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);

            #region DataTable Productos

            DataTable dtProductos = new DataTable();
            DataColumn column;

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoProducto";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Descripcion";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Cantidad";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Kilos";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PrecioUnitario";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PorcIva";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Iva";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Lote";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Cubetas";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);


            int contador = 1;
            foreach (Entidades.Factura_Detalle fd in pFactura.Detalles)
            {
                dtProductos.Rows.Add(fd.Renglon, fd.Producto.Codigo, fd.Producto.Descripcion, fd.MovStock_Lotes.Cantidad,
                     fd.Kilos, fd.PrecioUnitario, fd.PorIva, fd.Iva, fd.MovStock_Lotes.IdLote.IdLote, fd.Codigofactura, fd.RenglonFactura,fd.FacturaPorCubeta, contador);
                contador++;
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion
            #region DataTable Efectivo
            if (pFactura.FacturaEfectivo.Count > 0)
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
                foreach (Entidades.Factura_Efectivo fe in pFactura.FacturaEfectivo)
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
            #region DataTable Cheques
            if (pFactura.Cheques.Count > 0)
            {
                DataTable dtCheques = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoBanco";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NroCheque";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "FechaEmision";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "FechaPago";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Librador";
                dtCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUIT";
                dtCheques.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoMoneda";
                dtCheques.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtCheques.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtCheques.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Cheque che in pFactura.Cheques)
                {
                    dtCheques.Rows.Add(contador++, che.Banco.Codigo, che.NumeroCheque, che.CuentaBancaria.Codigo, che.FechaEmision, che.FechaPago, che.Librador, che.Cuit, che.Moneda.Codigo, che.Moneda.Cotizacion, che.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Cheques";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtCheques;
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
                //objCommand.ExecuteScalar();

                //int CodigoAsiento = AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                //objCommand.Parameters.AddWithValue("@CodigoAsientoTemp", CodigoAsiento);
                int res = Convert.ToInt32(objCommand.ExecuteScalar());

                //AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
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

        public static List<PercepcionesMunicipales> ObtenerPercepcionesMunicipales(DateTime pDesde, DateTime pHasta)
        {
            List<PercepcionesMunicipales> lista = new List<PercepcionesMunicipales>();
            Entidades.PercepcionesMunicipales per;

            strProc = "SP_PERCEPCIONESMUNICIPALES_SELECT";
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
                        per = new PercepcionesMunicipales();
                        //per.CuitEmpresa= objDataReader["CuitEmpresa"].ToString();
                        per.NroPercepcion= objDataReader["NroPercepcion"].ToString();
                        per.LetraPercepcion= Convert.ToChar(objDataReader["LetraPercepcion"].ToString());
                        per.Comprobante= objDataReader["Comprobante"].ToString();
                        per.CuitCliente = objDataReader["CuitCliente"].ToString();
                        per.BaseImponible = Convert.ToDouble(objDataReader["BaseImponible"]);
                        per.Alicuota = Convert.ToDouble(objDataReader["Alicuota"]);
                        per.MontoPercepcion = Convert.ToDouble(objDataReader["MontoPercepcion"]);
                        per.Estado= Convert.ToChar(objDataReader["Estado"].ToString());
                        per.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                        per.NombreCliente= objDataReader["NombreCliente"].ToString();
                        per.Calle= objDataReader["Calle"].ToString();
                        per.Numero= objDataReader["Numero"].ToString();
                        per.BarrioLocalidad= objDataReader["BarrioLocalidad"].ToString();
                        per.CodigoPostal= objDataReader["CodigoPostal"].ToString();
                        per.FechaInicioPercepcion = Convert.ToDateTime(objDataReader["FechaInicioPercepcion"]);
                        per.FechaCambiosDatos = Convert.ToDateTime(objDataReader["FechaCambioDatos"]);


                        lista.Add(per);

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

        public static List<CITIVentas> ObtenerCITIVentas(DateTime pDesde, DateTime pHasta)
        {
            List<CITIVentas> listaCiti = new List<CITIVentas>();
            Entidades.CITIVentas citi;

            strProc = "SP_CITIVENTAS_SELECT";
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
                    listaCiti = null;
                }
                else
                {
                    while (objDataReader.Read())
                    {
                        citi = new CITIVentas();
                        citi.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                        citi.CodigoTipoDocumentoAFIP = Convert.ToInt32(objDataReader["CodigoTipoDocumentoAFIP"]);
                        citi.PuntoDeVenta = Convert.ToInt32(objDataReader["PuntoDeVenta"]);
                        citi.Numero = Convert.ToInt32(objDataReader["Numero"]);
                        citi.CodigoDocumentoComprador = Convert.ToInt32(objDataReader["CodigoDocumento"]);
                        citi.CUIT = objDataReader["CUIT"].ToString();
                        citi.Cliente = objDataReader["Cliente"].ToString();
                        citi.Total = Convert.ToInt32(objDataReader["Total"]);
                        citi.TotalConceptosQueNoIntegranNetoGravado = 0;
                        citi.PercepcionNoCategorizados = 0;
                        citi.OperacionesExentas = Convert.ToInt32(objDataReader["OperacionesExentas"]);
                        citi.ImportePercepciones = 0;
                        citi.ImportePercepcionesIIBB = 0;
                        citi.ImportePercepcionesMunicipales = Convert.ToInt32(objDataReader["PercepcionMunicipal"]);
                        citi.ImporteImpuestosInternos = 0;
                        citi.CodigoMoneda = "PES";
                        citi.TipoCambio = 1;
                        Entidades.CITIVentasAlicuotas alicuota;
                        if (Convert.ToInt32(objDataReader["iva105"]) > 0)
                        {
                            alicuota = new CITIVentasAlicuotas();
                            alicuota.NetoGravado = Convert.ToInt32(objDataReader["Neto105"]);
                            alicuota.CodigoAlicuotaAFIP = 4;
                            alicuota.ImpuestoLiquidado = Convert.ToInt32(objDataReader["iva105"]);
                            citi.Alicuotas.Add(alicuota);
                        }
                        if (Convert.ToInt32(objDataReader["iva21"]) > 0)
                        {
                            alicuota = new CITIVentasAlicuotas();
                            alicuota.NetoGravado = Convert.ToInt32(objDataReader["Neto21"]);
                            alicuota.CodigoAlicuotaAFIP = 5;
                            alicuota.ImpuestoLiquidado = Convert.ToInt32(objDataReader["iva21"]);
                            citi.Alicuotas.Add(alicuota);
                        }
                        if (citi.Alicuotas.Count == 0)
                        {
                            alicuota = new CITIVentasAlicuotas();
                            alicuota.NetoGravado = 0;
                            alicuota.CodigoAlicuotaAFIP = 3;
                            alicuota.ImpuestoLiquidado = 0;
                            citi.Alicuotas.Add(alicuota);
                            citi.CodigoOperacion = "N";
                        }
                        else
                        {
                            citi.CodigoOperacion = "0";
                        }

                        
                        listaCiti.Add(citi);

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
            return listaCiti;
        }

        public static List<CITICompras> ObtenerCITICompras(DateTime pDesde, DateTime pHasta, Entidades.Empresa pEmpresa)
        {
            List<CITICompras> listaCiti = new List<CITICompras>();
            Entidades.CITICompras citi;

            strProc = "SP_CITICOMPRAS_SELECT";
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
                    listaCiti = null;
                }
                else
                {
                    while (objDataReader.Read())
                    {
                        citi = new CITICompras();
                        citi.Fecha = Convert.ToDateTime(objDataReader["FechaEmision"]);
                        citi.CodigoTipoDocumentoAFIP = Convert.ToInt32(objDataReader["CodigoTipoDocumentoAFIP"]);
                        citi.PuntoDeVenta = Convert.ToInt32(objDataReader["PuntoDeVenta"]);
                        citi.Numero = Convert.ToInt32(objDataReader["Numero"]);
                        citi.DespachoImportacion = "";
                        citi.CodigoDocumentoVendedor = 80;
                        citi.CUIT = objDataReader["CUIT"].ToString();
                        citi.Proveedor = objDataReader["Proveedor"].ToString();
                        citi.Total = Convert.ToInt32(objDataReader["Total"]);
                        citi.TotalConceptosQueNoIntegranNetoGravado = Convert.ToInt32(objDataReader["TotalConceptosQueNoIntegranNetoGravado"]);
                        citi.OperacionesExentas = Convert.ToInt32(objDataReader["OperacionesExentas"]);
                        citi.ImportePercepcionesIVA= Convert.ToInt32(objDataReader["PercepcionIVA"]);
                        citi.ImportePercepciones= Convert.ToInt32(objDataReader["Percepciones"]);
                        citi.ImportePercepcionesIIBB = Convert.ToInt32(objDataReader["PercepcionIIBB"]);
                        citi.ImportePercepcionesMunicipales = 0;
                        citi.ImporteImpuestosInternos = 0;
                        citi.CodigoMoneda = "PES";
                        citi.TipoCambio = 1;
                        citi.Letra = Convert.ToChar(objDataReader["Letra"]);
                        if (citi.Letra.Equals('A') || citi.Letra.Equals('M'))
                            citi.CodigoOperacion = " ";
                        else
                            citi.CodigoOperacion = "N";
                        citi.CreditoFiscal= Convert.ToInt32(objDataReader["IVA"]);
                        citi.OtrosTributos = 0;
                        if (citi.CodigoTipoDocumentoAFIP == 63)
                        {
                            citi.CUITEmisor = pEmpresa.CUITSinGuion;
                            citi.NombreEmisor = pEmpresa.RazonSocial;
                        }
                        else {
                            citi.CUITEmisor = "";
                            citi.NombreEmisor = "";
                        }
                        citi.IVAComision = 0;

                        if (citi.Letra.Equals('A') || citi.Letra.Equals('M')) {
                            Entidades.CITIVentasAlicuotas alicuota;
                            if (Convert.ToInt32(objDataReader["IVA105"]) > 0) {
                                alicuota = new CITIVentasAlicuotas();
                                alicuota.NetoGravado = Convert.ToInt32(objDataReader["NETO105"]);
                                alicuota.CodigoAlicuotaAFIP = 4;
                                alicuota.ImpuestoLiquidado = Convert.ToInt32(objDataReader["iva105"]);
                                citi.Alicuotas.Add(alicuota);
                            }
                            if (Convert.ToInt32(objDataReader["IVA21"]) > 0)
                            {
                                alicuota = new CITIVentasAlicuotas();
                                alicuota.NetoGravado = Convert.ToInt32(objDataReader["NETO21"]);
                                alicuota.CodigoAlicuotaAFIP = 5;
                                alicuota.ImpuestoLiquidado = Convert.ToInt32(objDataReader["iva21"]);
                                citi.Alicuotas.Add(alicuota);
                            }
                            if (Convert.ToInt32(objDataReader["IVA27"]) > 0)
                            {
                                alicuota = new CITIVentasAlicuotas();
                                alicuota.NetoGravado = Convert.ToInt32(objDataReader["NETO27"]);
                                alicuota.CodigoAlicuotaAFIP = 6;
                                alicuota.ImpuestoLiquidado = Convert.ToInt32(objDataReader["iva27"]);
                                citi.Alicuotas.Add(alicuota);
                            }
                            if (citi.Alicuotas.Count == 0) {
                                alicuota = new CITIVentasAlicuotas();
                                alicuota.NetoGravado = Convert.ToInt32(0);
                                alicuota.CodigoAlicuotaAFIP = 3;
                                alicuota.ImpuestoLiquidado = Convert.ToInt32(0);
                                citi.Alicuotas.Add(alicuota);
                            }
                        }

                        
                        listaCiti.Add(citi);

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
            return listaCiti;
        }

        public static int AgregarSaldoInicial(Entidades.Factura pFactura)//, Entidades.Asiento pAsiento)
        {

            //Creo objeto conexion
            strProc = "SP_FACTURASSALDOINICIAL_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);

            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pFactura.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pFactura.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoCliente", pFactura.Cliente.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoVendedor", pFactura.Vendedor.Codigo);
            
            objCommand.Parameters.AddWithValue("@Importe", pFactura.Neto105);
            objCommand.Parameters.AddWithValue("@ModificaNumerador", pFactura.ModificarNumerador);


            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);
       
            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                //int CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);

               // objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);

                int res = Convert.ToInt32(objCommand.ExecuteScalar());


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

     
        public static DataTable ObtenerIngresosBrutosDeposito(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_INGRESOSBRUTOSDEPOSITO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsIngresosBrutos";
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

        public static DataTable ObtenerIngresosBrutos(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_INGRESOSBRUTOSLOCAL";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsIngresosBrutos";
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
        public static int AgregarLiquidacion(Entidades.Factura pFactura, Entidades.Asiento pAsiento)
        {

            //Creo objeto conexion
            strProc = "SP_LIQUIDACIONESCLIENTES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pFactura.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pFactura.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoCliente", pFactura.Cliente.Codigo);
            
            objCommand.Parameters.AddWithValue("@CodigoVendedor", pFactura.Vendedor.Codigo);
            objCommand.Parameters.AddWithValue("@NroRemito", pFactura.NroRemito);
            objCommand.Parameters.AddWithValue("@Neto105", pFactura.Neto105);
            objCommand.Parameters.AddWithValue("@Iva105", pFactura.Iva105);
            objCommand.Parameters.AddWithValue("@Neto21", pFactura.Neto21);
            objCommand.Parameters.AddWithValue("@Iva21", pFactura.Iva21);
            //objCommand.Parameters.AddWithValue("@Cae", pFactura.Cae);
            //objCommand.Parameters.AddWithValue("@FechaVenCae", pFactura.FechaVenCae);
            objCommand.Parameters.AddWithValue("@Comision", pFactura.Comision);
            objCommand.Parameters.AddWithValue("@Redondeo", pFactura.Redondeo);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);
            objCommand.Parameters.AddWithValue("@CodigoLiquidacion", pFactura.Liquidacion);
            objCommand.Parameters.AddWithValue("@PorcentajeComision", pFactura.PorcentajeComision);

            #region DataTable Productos

            DataTable dtProductos = new DataTable();
            DataColumn column;

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonLiquidacion";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoProducto";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Descripcion";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Cantidad";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PrecioUnitario";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PorcIva";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Iva";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoRemito";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonRemito";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);


            foreach (Entidades.Factura_Detalle fd in pFactura.Detalles)
            {
                dtProductos.Rows.Add(fd.Renglon, fd.Producto.Codigo, fd.Producto.Descripcion, fd.MovStock_Lotes.Cantidad,
                     fd.PrecioUnitario, fd.PorIva, fd.Iva, fd.Codigofactura, fd.RenglonFactura);
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion

            #region DataTable Merma
            if (pFactura.Mermas.Count > 0)
            {
                DataTable dtMermas = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtMermas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoRemito";
                dtMermas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "RenglonRemito";
                dtMermas.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Merma";
                dtMermas.Columns.Add(column);

                // contador = 1;
                foreach (Entidades.Factura_Merma fm in pFactura.Mermas)
                {
                    dtMermas.Rows.Add(fm.Renglon, fm.CodigoRemito, fm.RenglonRemito, fm.Merma);
                   // dtMermas.Rows.Add(contador++, che.Banco.Codigo, che.NumeroCheque, che.CuentaBancaria.Codigo, che.FechaEmision, che.FechaPago, che.Librador, che.Cuit, che.Moneda.Codigo, che.Moneda.Cotizacion, che.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Merma";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtMermas;
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
                //objCommand.ExecuteScalar();

                //int CodigoAsiento = AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                //objCommand.Parameters.AddWithValue("@CodigoAsientoTemp", CodigoAsiento);
                int res = Convert.ToInt32(objCommand.ExecuteScalar());

                //AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
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

        public static DataTable ObtenerLiquidacionesPorCliente(DateTime pDesde, DateTime pHasta, Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESCLIENTES2_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
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

        public static int AgregarAjustes(Entidades.Factura pFactura, Entidades.Asiento pAsiento, int pViejos)
        {

            //Creo objeto conexion
            if(pViejos==0)
                strProc = "SP_AJUSTES_INSERT";
            else
                strProc = "SP_AJUSTESVIEJOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pFactura.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pFactura.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoCliente", pFactura.Cliente.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSucursalCliente", pFactura.SucursalCliente.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@FacturaPorKilo", pFactura.Cliente.FacturaKilos);
            objCommand.Parameters.AddWithValue("@CodigoVendedor", pFactura.Vendedor.Codigo);
            objCommand.Parameters.AddWithValue("@NroRemito", pFactura.NroRemito);
            objCommand.Parameters.AddWithValue("@Neto105", pFactura.Neto105);
            objCommand.Parameters.AddWithValue("@Iva105", pFactura.Iva105);
            objCommand.Parameters.AddWithValue("@Neto21", pFactura.Neto21);
            objCommand.Parameters.AddWithValue("@Iva21", pFactura.Iva21);
            objCommand.Parameters.AddWithValue("@Cae", pFactura.Cae);
            objCommand.Parameters.AddWithValue("@FechaVenCae", pFactura.FechaVenCae);
            objCommand.Parameters.AddWithValue("@FacturaKilos", pFactura.FacturaKilos);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@PercepcionMunicipal", pFactura.PercepcionMunicipal);
            objCommand.Parameters.AddWithValue("@AlicuotaMunicipal", pFactura.Cliente.TipoContribuyente.PorcentajePercepcion);
            objCommand.Parameters.AddWithValue("@Observaciones", pFactura.Observaciones);

            #region DataTable Productos

            DataTable dtProductos = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoProducto";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Descripcion";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Cantidad";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Kilos";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PrecioUnitario";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PorcIva";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Iva";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Lote";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Cubetas";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);


            int contador = 1;
            foreach (Entidades.Factura_Detalle fd in pFactura.Detalles)
            {
                dtProductos.Rows.Add(fd.Renglon, fd.Producto.Codigo, "", fd.MovStock_Lotes.Cantidad,
                     fd.Kilos, fd.PrecioUnitario, fd.PorIva, fd.Iva, fd.MovStock_Lotes.IdLote.IdLote, fd.Codigofactura, fd.RenglonFactura,fd.FacturaPorCubeta, contador);
                contador++;
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion
            #region DataTable Descuentos

            DataTable dtDescuentos = new DataTable();
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Descripcion";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Porcentaje";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Cantidad";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Kilos";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PrecioUnitario";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Iva";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoFactura";
            dtDescuentos.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonFactura";
            dtDescuentos.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtDescuentos.Columns.Add(column);




            contador = 1;
            foreach (Entidades.Factura_DescuentosEspecialesDetalle fd in pFactura.DescuentosEspecialesDetalle)
            {
                dtDescuentos.Rows.Add(fd.Renglon, fd.Detalle, fd.Porcentaje, fd.Cantidad,
                     fd.Kilos, fd.PrecioUnitario, fd.Iva, fd.Codigofactura, fd.RenglonFactura, contador);
                contador++;
            }

            paramItems = new SqlParameter();
            paramItems.ParameterName = "@Descuentos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDescuentos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion
            #region DataTable Efectivo
            if (pFactura.FacturaEfectivo.Count > 0)
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
                foreach (Entidades.Factura_Efectivo fe in pFactura.FacturaEfectivo)
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
          
            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;


                //int CodigoAsiento = AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                int CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);
                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);
                int res = Convert.ToInt32(objCommand.ExecuteScalar());

                //AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                transaccion.Commit();
                return res;
            }
            catch (Exception ex)
            {
                //  transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }
        public static int AgregarChequesRechazados(Entidades.Factura pFactura,string pMotivo, Entidades.Asiento pAsiento)
        {

            //Creo objeto conexion
            strProc = "SP_NDCHEQUESRECHAZADOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pFactura.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pFactura.Fecha);
            /*objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);*/
            objCommand.Parameters.AddWithValue("@CodigoCliente", pFactura.Cliente.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSucursalCliente", pFactura.SucursalCliente.CodigoSucursal);
            //objCommand.Parameters.AddWithValue("@FacturaPorKilo", pFactura.Cliente.FacturaKilos);
            objCommand.Parameters.AddWithValue("@CodigoVendedor", pFactura.Vendedor.Codigo);
            //objCommand.Parameters.AddWithValue("@NroRemito", pFactura.NroRemito);
            
            objCommand.Parameters.AddWithValue("@NetoNoGravado", pFactura.NetoNoGravado);
            objCommand.Parameters.AddWithValue("@Neto105", pFactura.Neto105);
            objCommand.Parameters.AddWithValue("@Iva105", pFactura.Iva105);
            objCommand.Parameters.AddWithValue("@Neto21", pFactura.Neto21);
            objCommand.Parameters.AddWithValue("@Iva21", pFactura.Iva21);
            objCommand.Parameters.AddWithValue("@Cae", pFactura.Cae);
            objCommand.Parameters.AddWithValue("@FechaVenCae", pFactura.FechaVenCae);
            objCommand.Parameters.AddWithValue("@FacturaKilos", pFactura.FacturaKilos);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@Motivos", pMotivo);

            #region DataTable Cheques

            DataTable dtProductos = new DataTable();
            DataColumn column;

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Codigo";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoCuentaBancaria";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Importe";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Renglon";
            dtProductos.Columns.Add(column);

            int contador = 0;
            foreach (Entidades.Cheque ch in pFactura.Cheques)
            {
                dtProductos.Rows.Add(ch.Codigo,ch.CuentaBancaria.Codigo, ch.Importe, ++contador);
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Cheques";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion

            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;


                //int CodigoAsiento = AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                int CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);
                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);
                int res = Convert.ToInt32(objCommand.ExecuteScalar());

                //AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                transaccion.Commit();
                return res;
            }
            catch (Exception ex)
            {
                //  transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }
        public static DataTable ObtenerUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsFactura";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerFechas()
        {
            DataTable dt = new DataTable();
            strProc = "SP_IVAVENTAS_FECHAS_SELECT";
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

        public static DataTable ObtenerFechasPerMunicipales()
        {
            DataTable dt = new DataTable();
            strProc = "SP_PERCEPCIONESMUNICIPALES_FECHAS_SELECT";
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

        
        public static DataTable ObtenerIVA(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_IVAVENTAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsIVAVentas";
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

        public static void Anular(Entidades.Factura pFactura)
        {

            //Creo objeto conexion
            strProc = "SP_FACTURAS_ANULAR";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pFactura.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            
            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                objCommand.ExecuteNonQuery();

                //AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                transaccion.Commit();
            }
            catch (SqlException sql)
            {
                if (sql.Number == 547)
                    throw new Exception("No se puede Anular Comprobante!!\n Contiene movimientos posteriores de sus Formas de Pago.");

                else
                    throw new Exception(sql.Message);
            }
            catch (Exception ex)
            {
                //  transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }

        public static DataTable ObtenerPorCliente(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_PORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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

        public static DataTable ObtenerPorCliente(Entidades.Cliente pCliente, int pCodigoTipoDocumentoCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_COMPROBANTES_PORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pCodigoTipoDocumentoCliente);
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

        public static DataTable ObtenerVentasIniciales()
        {
            DataTable dt = new DataTable();
            strProc = "SP_VENTASINICIALES_SELECT";
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

        public static Entidades.Factura ObtenerUna(int pCodigo)
        {
            Entidades.Factura objFactura = new Entidades.Factura();
            strProc = "SP_FACTURAS_SELECT_UNO";
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
                    objFactura = null;
                }
                else
                {
                    objFactura.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objFactura.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objFactura.Letra = Convert.ToChar(objDataReader["Letra"]);
                    objFactura.PuntoDeVenta = Convert.ToInt32(objDataReader["PuntoDeVenta"]);
                    objFactura.Numero = Convert.ToInt32(objDataReader["Numero"]);
                    objFactura.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaKilos"]);
                    objFactura.TipoDocumentoCliente.MiPYME= Convert.ToBoolean(objDataReader["MiPYME"]);
                    objFactura.TipoDocumentoCliente.TipoDoc.Codigo = Convert.ToString(objDataReader["CodigoTipoDoc"]);
                    objFactura.TipoDocumentoCliente.AfectaCtaCte = Convert.ToChar(objDataReader["AfectaCtaCte"]);
                    objFactura.AlicuotaMunicipal = Convert.ToDouble(objDataReader["AlicuotaMunicipal"]);
                    Entidades.SucursalCliente sc = new Entidades.SucursalCliente();
                    sc.CodigoSucursal = Convert.ToInt32(objDataReader["CodigoSucursalCliente"]);
                    objFactura.SucursalCliente= sc;

                    objFactura.DescuentosEspeciales= FacturaDetalle.ObtenerDescuentosEspecialesParaNC(objFactura.Codigo);
                    objFactura.Detalles = FacturaDetalle.ObtenerUnoParaNC(objFactura.Codigo);
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
            return objFactura;
        }

        public static Entidades.Factura ObtenerUnaVentasIniciales(int pCodigo)
        {
            Entidades.Factura objFactura = new Entidades.Factura();
            strProc = "SP_VENTASINICIALES_SELECT_UNO";
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
                    objFactura = null;
                }
                else
                {
                    objFactura.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objFactura.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaKilos"]);

                    objFactura.Detalles = FacturaDetalle.ObtenerUnoParaNCVentasIniciales(objFactura.Codigo);
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
            return objFactura;
        }

        public static Entidades.Factura ObtenerUnaParaNCLote(int pCodigo, int pViejo, bool pConDescuento)
        {
            Entidades.Factura objFactura = new Entidades.Factura();
            strProc = "SP_FACTURAS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            objCommand.Parameters.AddWithValue("@Viejo", pViejo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objFactura = null;
                }
                else
                {
                    objFactura.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objFactura.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaKilos"]);

                    Entidades.SucursalCliente sc = new Entidades.SucursalCliente();
                    sc.CodigoSucursal = Convert.ToInt32(objDataReader["CodigoSucursalCliente"]);
                    objFactura.SucursalCliente = sc;

                    objFactura.TipoDocumentoCliente.AfectaCtaCte = Convert.ToChar(objDataReader["AfectaCtaCte"]);
                    objFactura.TipoDocumentoCliente.MiPYME = Convert.ToBoolean(objDataReader["MiPYME"]);

                    objFactura.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaKilos"]);
                    objFactura.TipoDocumentoCliente.TipoDoc.Codigo = Convert.ToString(objDataReader["CodigoTipoDoc"]);

                    objFactura.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objFactura.Letra = Convert.ToChar(objDataReader["Letra"]);
                    objFactura.PuntoDeVenta = Convert.ToInt32(objDataReader["PuntoDeVenta"]);
                    objFactura.Numero = Convert.ToInt32(objDataReader["Numero"]);
                    objFactura.AlicuotaMunicipal = Convert.ToDouble(objDataReader["AlicuotaMunicipal"]);

                    objFactura.Detalles = FacturaDetalle.ObtenerUnoParaNCLote(objFactura.Codigo, pViejo, pConDescuento);
                    /*objRemito.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);
                    objRemito.TipoRemitoProveedor.Codigo = Convert.ToInt32(objDataReader["CodigoTipoRemitoProveedor"]);
                    objRemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objRemito.Provisorio = Convert.ToBoolean(objDataReader["Provisorio"]);
                    objRemito.NumRemito = objDataReader["NumRemito"].ToString();
                    objRemito.Canal.Codigo = Convert.ToInt32(objDataReader["CodigoCanal"]);

                    objRemito.Productos = RemitoProveedor_D_Productos.ObtenerTodos(objRemito.Codigo);
                    */
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
            return objFactura;
        }


        public static Entidades.Factura ObtenerUnaAjuste(int pCodigo)
        {
            Entidades.Factura objFactura = new Entidades.Factura();
            strProc = "SP_FACTURAS_SELECT_UNO";
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
                    objFactura = null;
                }
                else
                {
                    objFactura.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objFactura.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaKilos"]);
                    objFactura.TipoDocumentoCliente.AfectaCtaCte = Convert.ToChar(objDataReader["AfectaCtaCte"]);
                    objFactura.TipoDocumentoCliente.MiPYME = Convert.ToBoolean(objDataReader["MiPYME"]);
                    Entidades.SucursalCliente sc = new Entidades.SucursalCliente();
                    sc.CodigoSucursal = Convert.ToInt32(objDataReader["CodigoSucursalCliente"]);
                    objFactura.SucursalCliente = sc;
                    //
                    objFactura.TipoDocumentoCliente.TipoDoc.Codigo = Convert.ToString(objDataReader["CodigoTipoDoc"]);
                    
                    objFactura.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objFactura.Letra = Convert.ToChar(objDataReader["Letra"]);
                    objFactura.PuntoDeVenta = Convert.ToInt32(objDataReader["PuntoDeVenta"]);
                    objFactura.Numero = Convert.ToInt32(objDataReader["Numero"]);
                    objFactura.AlicuotaMunicipal = Convert.ToInt32(objDataReader["AlicuotaMunicipal"]);

                    //


                    objFactura.Detalles = FacturaDetalle.ObtenerUnoParaAjuste(objFactura.Codigo);

                    objFactura.DescuentosEspeciales = FacturaDetalle.ObtenerDescuentosEspecialesParaNC(objFactura.Codigo);
                    /*objRemito.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);
                    objRemito.TipoRemitoProveedor.Codigo = Convert.ToInt32(objDataReader["CodigoTipoRemitoProveedor"]);
                    objRemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objRemito.Provisorio = Convert.ToBoolean(objDataReader["Provisorio"]);
                    objRemito.NumRemito = objDataReader["NumRemito"].ToString();
                    objRemito.Canal.Codigo = Convert.ToInt32(objDataReader["CodigoCanal"]);

                    objRemito.Productos = RemitoProveedor_D_Productos.ObtenerTodos(objRemito.Codigo);
                    */
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
            return objFactura;
        }
        public static Entidades.Factura ObtenerUnaAjuste(int pCodigo, int pViejo)
        {
            Entidades.Factura objFactura = new Entidades.Factura();
            strProc = "SP_FACTURAS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            objCommand.Parameters.AddWithValue("@Viejo", pViejo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objFactura = null;
                }
                else
                {
                    objFactura.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objFactura.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaKilos"]);
                    objFactura.TipoDocumentoCliente.AfectaCtaCte = Convert.ToChar(objDataReader["AfectaCtaCte"]);
                    objFactura.TipoDocumentoCliente.MiPYME = Convert.ToBoolean(objDataReader["MiPYME"]);
                    Entidades.SucursalCliente sc = new Entidades.SucursalCliente();
                    sc.CodigoSucursal = Convert.ToInt32(objDataReader["CodigoSucursalCliente"]);
                    objFactura.SucursalCliente = sc;
                    //
                    objFactura.TipoDocumentoCliente.TipoDoc.Codigo = Convert.ToString(objDataReader["CodigoTipoDoc"]);

                    objFactura.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objFactura.Letra = Convert.ToChar(objDataReader["Letra"]);
                    objFactura.PuntoDeVenta = Convert.ToInt32(objDataReader["PuntoDeVenta"]);
                    objFactura.Numero = Convert.ToInt32(objDataReader["Numero"]);
                    objFactura.AlicuotaMunicipal = Convert.ToInt32(objDataReader["AlicuotaMunicipal"]);

                    //


                    //objFactura.Detalles = FacturaDetalle.ObtenerUnoParaAjuste(objFactura.Codigo);
                    objFactura.Detalles = FacturaDetalle.ObtenerUnoParaNCLote(objFactura.Codigo, pViejo,false);
                    objFactura.DescuentosEspeciales = FacturaDetalle.ObtenerDescuentosEspecialesParaNC(objFactura.Codigo);
                    /*objRemito.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);
                    objRemito.TipoRemitoProveedor.Codigo = Convert.ToInt32(objDataReader["CodigoTipoRemitoProveedor"]);
                    objRemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objRemito.Provisorio = Convert.ToBoolean(objDataReader["Provisorio"]);
                    objRemito.NumRemito = objDataReader["NumRemito"].ToString();
                    objRemito.Canal.Codigo = Convert.ToInt32(objDataReader["CodigoCanal"]);

                    objRemito.Productos = RemitoProveedor_D_Productos.ObtenerTodos(objRemito.Codigo);
                    */
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
            return objFactura;
        }
        public static string ObtenerFacturaAfectada(int pCodigo) {
            string factura;
            strProc = "SP_FACTURAAFECTADA_SELECT";
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
                    factura = "";
                }
                else
                {
                    factura = objDataReader["Factura"].ToString();
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
            return factura;
        }

        public static DataTable ObtenerFacturasSinImputar(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_SINIMPUTAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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

        public static DataTable ObtenerFacturasParaImputar(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            try
            {
                
            strProc = "SP_FACTURAS_PARAIMPUTAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
           
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
        public static DataTable ObtenerTodosPorFecha(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
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

        public static Entidades.Factura ObtenerFactura(int pCodigo)
        {
            Entidades.Factura objFactura = new Entidades.Factura();
            strProc = "SP_FACTURAS_SELECT_UNO";
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
                    objFactura = null;
                }
                else
                {
                    objFactura.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objFactura.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaKilos"]);
                    objFactura.TipoDocumentoCliente = TipoDocumentoCliente.ObtenerUno(Convert.ToInt32(objDataReader["CodigoTipoDocumentoCliente"]));
                    objFactura.Letra = Convert.ToChar(objDataReader["Letra"]);
                    /*objRemito.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);
                    objRemito.TipoRemitoProveedor.Codigo = Convert.ToInt32(objDataReader["CodigoTipoRemitoProveedor"]);
                    objRemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objRemito.Provisorio = Convert.ToBoolean(objDataReader["Provisorio"]);
                    objRemito.NumRemito = objDataReader["NumRemito"].ToString();
                    objRemito.Canal.Codigo = Convert.ToInt32(objDataReader["CodigoCanal"]);

                    objRemito.Productos = RemitoProveedor_D_Productos.ObtenerTodos(objRemito.Codigo);
                    */
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
            return objFactura;
        }

        public static DataTable ObtenerFacturasCuentaCorriente(Entidades.Cliente pCliente, DateTime pDesde)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_CUENTASCORRIENTEPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde);
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

        public static DataTable ObtenerFacturasSinImputarPorCliente(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_SINIMPUTARPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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

        public static DataTable ObtenerPorClienteParaNCLotes(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta, bool pConDescuentos)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASPARANCLOTE";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@ConDescuentos", pConDescuentos);
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

        public static DataTable ObtenerPorClienteParaNCLotesViejas(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASPARANCLOTEVIEJAS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
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

        public static DataTable ObtenerPorClienteParaNCViejas(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASVIEJASPARANCAJUSTE";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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
        public static int AgregarDescuento(Entidades.Factura pFactura, Entidades.Asiento pAsiento)
        {
            //Creo objeto conexion
            strProc = "SP_FACTURASDESCUENTOS_INSERT";

            objCommand = new SqlCommand(strProc, objConexion);

            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pFactura.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pFactura.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoCliente", pFactura.Cliente.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoVendedor", pFactura.Vendedor.Codigo);

            objCommand.Parameters.AddWithValue("@Importe", pFactura.Neto105);

            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);

            objCommand.Parameters.AddWithValue("@Observaciones", pFactura.Observaciones);

            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                int CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);

                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);

                int res = Convert.ToInt32(objCommand.ExecuteScalar());


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

        public static DataTable ObtenerEncabezadoLiquidacion(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESCLIENTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoLiquidacion", pCodigoFactura);
            try
            {
                dt.TableName = "dsEncabezado";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerMermasLiquidacion(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESCLIENTES_MERMAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoLiquidacion", pCodigoFactura);
            try
            {
                dt.TableName = "dsLiquidacionMermas";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerDetallesLiquidacion(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESCLIENTES_DETALLES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoLiquidacion", pCodigoFactura);
            try
            {
                dt.TableName = "dsLiquidacionDetalles";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerImputacionesDetalle(Entidades.PagoCliente pPago)
        {
            DataTable dt = new DataTable();
            strProc = "SP_IMPUTACIONDETALLE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPagoCliente", pPago.Codigo);
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
        public static DataTable ObtenerFacturasAnuladasIvaDigital(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();

            strProc = "SP_IVADIGITALVENTASANULADAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
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

        public static DataTable VentasPorEmpleados(DateTime pDesde, DateTime pHasta) {
            DataTable dt = new DataTable();

            strProc = "SP_VENTASPOREMPLEADOFECHA";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsVentasPorEmpleado";
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
        public static DataTable VentasPorEmpleadosDetalle(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();

            strProc = "SP_VENTASPOREMPLEADOFECHADETALLE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsVentasPorEmpleadoDetalle";
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