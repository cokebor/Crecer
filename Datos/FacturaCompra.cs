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
    public static class FacturaCompra
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static FacturaCompra()
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

        public static void Agregar(Entidades.FacturaCompra pFactura, Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_FACTURASCOMPRAS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.Sucursal.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pFactura.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pFactura.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@FechaEmision", pFactura.FechaEmision);
            objCommand.Parameters.AddWithValue("@FechaContable", pFactura.FechaContable);
            objCommand.Parameters.AddWithValue("@CodigoTipoCompra", pFactura.TipoCompra);
            objCommand.Parameters.AddWithValue("@Neto1", pFactura.Neto1);
            objCommand.Parameters.AddWithValue("@DescripImp1", pFactura.DescripImp1);
            objCommand.Parameters.AddWithValue("@ImporteImp1", pFactura.ImporteImp1);
            objCommand.Parameters.AddWithValue("@Neto2", pFactura.Neto2);
            objCommand.Parameters.AddWithValue("@DescripImp2", pFactura.DescripImp2);
            objCommand.Parameters.AddWithValue("@ImporteImp2", pFactura.ImporteImp2);
            objCommand.Parameters.AddWithValue("@NoGravado", pFactura.NoGravado);
            objCommand.Parameters.AddWithValue("@Exento", pFactura.Exento);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoRemito", pFactura.Remito.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);


            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Efectivo

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
            if (pFactura.Cheques.Count > 0)
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
                foreach (Entidades.Cheque che in pFactura.Cheques)
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
            if (pFactura.ChequesPropios.Count > 0)
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
                foreach (Entidades.Cheque che in pFactura.ChequesPropios)
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
            if (pFactura.Tranferencias.Count > 0)
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
                foreach (Entidades.Tranferencia tra in pFactura.Tranferencias)
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

            contador = 1;
            foreach (Entidades.FacturaImpuesto fi in pFactura.Impuestos)
            {
                dtImpuestos.Rows.Add(contador++, fi.Impuesto.Codigo, fi.Importe, fi.Impuesto.CuentaContable.Codigo);                
            }

            paramItems = new SqlParameter();
            paramItems.ParameterName = "@Impuestos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtImpuestos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);


            #endregion

            #region Productos

            DataTable dtProductos = new DataTable();
            
            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonRemito";
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
            column.ColumnName = "CodigoFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Lote";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);
            

            contador = 1;
            foreach (Entidades.FacturaCompra_Detalle fd in pFactura.Detalle)
            {
                dtProductos.Rows.Add(fd.Renglon,fd.RenglonRemito, fd.Producto.Codigo, fd.Producto.Descripcion, fd.Cantidad,
                     fd.PrecioUnitario, fd.PorIva, fd.Iva,fd.Codigofactura,fd.RenglonFactura,fd.MovStock_Lotes.IdLote.IdLote,  contador);
                contador++;
            }

            paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
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


                int CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);
                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);
                objCommand.ExecuteScalar();

                // AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                transaccion.Commit();
            }
          /*  catch (SqlException sql) {

                transaccion.Rollback();
                throw new Exception(sql.Message);
            }*/
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

        public static DataTable OtenerImpuestos(int pCodigo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESIMPUESTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoFacturaCompra", pCodigo);
            try
            {
                dt.TableName = "dsImpuestos";
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

        public static string ObtenerObservaciones(int pCodigoTipoDocumentoProveedor, int pCodigo)
        {
            string resultado = "";
            strProc = "SP_FACTURASCOMPRASPAGOSOBSERVACIONES_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pCodigoTipoDocumentoProveedor);
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
                else
                {
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

        public static DataTable ObtenerPorProveedor(Entidades.Proveedor pProveedor, int pCodigoTipoDocumentoProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_COMPROBANTES_PORPROVEEDOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pCodigoTipoDocumentoProveedor);
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

 
        public static void AgregarObservaciones(int pCodigoTipoDocumento, int pCodigo, string pObservaciones)
        {
            strProc = "SP_FACTURASCOMPRASPAGOSOBSERVACIONES_INSERT";
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

        public static DataTable ObtenerFechasLiquidaciones()
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESPROVEEDORES_FECHAS_SELECT";
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
        public static DataTable ObtenerFechasDetallesCompras()
        {
            DataTable dt = new DataTable();
            strProc = "SP_DETALLECOMPRAS_FECHAS_SELECT";
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

        public static DateTime ObtenerFechaUltimaLiquidacion(string pLetra)
        {
            DateTime fecha = new DateTime();
            strProc = "SP_FECHAULTIMALIQUIDACION";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@LETRA", pLetra);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    fecha = DateTime.MinValue;
                }
                else
                {
                    fecha = Convert.ToDateTime(objDataReader["Fecha"]);
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
            return fecha;
        }



        public static int AgregarChequesRechazados(Entidades.FacturaCompra pFactura, string pMotivo, Entidades.Asiento pAsiento)
        {

            //Creo objeto conexion
            strProc = "SP_NDCHEQUESRECHAZADOSPROVEEDOR_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.Sucursal.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pFactura.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@FechaEmision", pFactura.FechaEmision);
            objCommand.Parameters.AddWithValue("@FechaContable", pFactura.FechaContable);
            
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pFactura.Proveedor.Codigo);
            //objCommand.Parameters.AddWithValue("@FacturaPorKilo", pFactura.Cliente.FacturaKilos);
            objCommand.Parameters.AddWithValue("@CodigoTipoCompra", pFactura.TipoCompra);
            //objCommand.Parameters.AddWithValue("@NroRemito", pFactura.NroRemito);
            objCommand.Parameters.AddWithValue("@Neto1", pFactura.Neto1);
            objCommand.Parameters.AddWithValue("@DescripImp1", pFactura.DescripImp1);
            objCommand.Parameters.AddWithValue("@ImporteImp1", pFactura.ImporteImp1);
            objCommand.Parameters.AddWithValue("@Neto2", pFactura.Neto2);
            objCommand.Parameters.AddWithValue("@DescripImp2", pFactura.DescripImp2);
            objCommand.Parameters.AddWithValue("@ImporteImp2", pFactura.ImporteImp2);
            objCommand.Parameters.AddWithValue("@NoGravado", pFactura.NoGravado);
            objCommand.Parameters.AddWithValue("@Exento", pFactura.Exento);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoRemito", pFactura.Remito.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);
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
                dtProductos.Rows.Add(ch.Codigo, ch.CuentaBancaria.Codigo,ch.Importe, ++contador);
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
        public static void ValidarStock(Entidades.FacturaCompra pFacturaCompra)
        {
            DataTable dt = new DataTable();
            strProc = "SP_VALIDARSTOCKFACTURACOMPRA";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;

            DataTable dtProductos = new DataTable();
            DataColumn column;
            #region DataTable Productos

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonRemito";
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
            column.ColumnName = "CodigoFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Lote";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);


            int contador = 1;

            foreach (Entidades.FacturaCompra_Detalle fd in pFacturaCompra.Detalle)
            {
                dtProductos.Rows.Add(fd.Renglon, fd.RenglonRemito, fd.Producto.Codigo, fd.Producto.Descripcion, fd.Cantidad,
                     fd.PrecioUnitario, fd.PorIva, fd.Iva, fd.Codigofactura, fd.RenglonFactura, fd.MovStock_Lotes.IdLote.IdLote, contador);
                contador++;
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion

            try
            {
                objConexion.Open();
                int res = Convert.ToInt32(objCommand.ExecuteScalar());
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

        public static Entidades.FacturaCompra ObtenerFactura(int pCodigo)
        {
            Entidades.FacturaCompra objFactura = new Entidades.FacturaCompra();
            strProc = "SP_FACTURASCOMPRASINFORME_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoFactura", pCodigo);
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
                    objFactura.TipoDocumentoProveedor = TipoDocumentoProveedor.ObtenerUno(Convert.ToInt32(objDataReader["CodigoTipoDocumentoProveedor"]));
                   //objFactura.TipoDocumentoProveedor.TipoDoc.Codigo= Convert.ToString(objDataReader["Tipo"]);
                    //new TipoDocumentoProveedor().ObtenerUno(Convert.ToInt32(objDataReader["CodigoProveedor"]));
                    objFactura.FechaEmision= Convert.ToDateTime(objDataReader["FechaEmision"]);
                    objFactura.Letra = Convert.ToChar(objDataReader["Letra"]);
                    objFactura.PuntoDeVenta = Convert.ToInt32(objDataReader["PuntoDeVenta"]);
                    objFactura.Numero = Convert.ToInt32(objDataReader["Numero"]);
                    objFactura.Proveedor.Codigo= Convert.ToInt32(objDataReader["CodigoProveedor"]);
                    objFactura.TipoCompra = objDataReader["CodigoTipoCompra"].ToString();
                    objFactura.DescripImp1= Convert.ToDouble(objDataReader["DescripImp1"]);
                    objFactura.Neto1 = Convert.ToDouble(objDataReader["Neto1"]);
                    objFactura.ImporteImp1= Convert.ToDouble(objDataReader["ImporteImp1"]);
                    objFactura.DescripImp2 = Convert.ToDouble(objDataReader["DescripImp2"]);
                    objFactura.Neto2 = Convert.ToDouble(objDataReader["Neto2"]);
                    objFactura.ImporteImp2 = Convert.ToDouble(objDataReader["ImporteImp2"]);
                    objFactura.Exento= Convert.ToDouble(objDataReader["Exento"]);
                    objFactura.NoGravado = Convert.ToDouble(objDataReader["NoGravado"]);

                    // objFactura.TipoDocumentoProveedor.TipoDoc.Descripcion= Convert.ToString(objDataReader["TipoDocumento"]);

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

    public static DataTable ObtenerFechas()
        {
            DataTable dt = new DataTable();
            strProc = "SP_IVACOMPRAS_FECHAS_SELECT";
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
            strProc = "SP_IVACOMPRAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsIVACompras";
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

        public static DataTable ObtenerFacturasSinImputar(Entidades.Proveedor pProveedor, bool liquidaciones)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASCOMPRAS_SINIMPUTAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Liquidaciones", liquidaciones);
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

        public static DataTable ObtenerPorProveedor(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASCOMPRASBC_PORPROVEEDOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static Entidades.FacturaCompra ObtenerUna(int pCodigo)
        {
            Entidades.FacturaCompra objFactura = new Entidades.FacturaCompra();
            strProc = "SP_FACTURASCOMPRAS_SELECT_UNO";
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
          
                    objFactura.Detalle = FacturaCompra_Detalle.ObtenerUnoParaNC(objFactura.Codigo);

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

        public static Entidades.FacturaCompra ObtenerUnaAjuste(int pCodigo)
        {
            Entidades.FacturaCompra objFactura = new Entidades.FacturaCompra();
            strProc = "SP_FACTURASCOMPRAS_SELECT_UNO";
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
                    //objFactura.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaKilos"]);

                    objFactura.Detalle = FacturaCompra_Detalle.ObtenerUnoParaAjuste(objFactura.Codigo);
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

        public static int AgregarAjustes(Entidades.FacturaCompra pFactura, Entidades.Asiento pAsiento)
        {

            //Creo objeto conexion
            strProc = "SP_AJUSTESCOMPRAS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.Sucursal.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pFactura.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pFactura.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@FechaEmision", pFactura.FechaEmision);
            objCommand.Parameters.AddWithValue("@FechaContable", pFactura.FechaContable);
            objCommand.Parameters.AddWithValue("@CodigoTipoCompra", pFactura.TipoCompra);
            objCommand.Parameters.AddWithValue("@Neto1", pFactura.Neto1);
            objCommand.Parameters.AddWithValue("@DescripImp1", pFactura.DescripImp1);
            objCommand.Parameters.AddWithValue("@ImporteImp1", pFactura.ImporteImp1);
            objCommand.Parameters.AddWithValue("@Neto2", pFactura.Neto2);
            objCommand.Parameters.AddWithValue("@DescripImp2", pFactura.DescripImp2);
            objCommand.Parameters.AddWithValue("@ImporteImp2", pFactura.ImporteImp2);
            objCommand.Parameters.AddWithValue("@NoGravado", pFactura.NoGravado);
            objCommand.Parameters.AddWithValue("@Exento", pFactura.Exento);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);

            DataTable dtProductos = new DataTable();
            DataColumn column;

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

            int contador = 1;
            foreach (Entidades.FacturaImpuesto fi in pFactura.Impuestos)
            {
                dtImpuestos.Rows.Add(contador++, fi.Impuesto.Codigo, fi.Importe, fi.Impuesto.CuentaContable.Codigo);
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Impuestos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtImpuestos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);


            #endregion

            #region DataTable Productos

            

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonRemito";
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
            column.ColumnName = "CodigoFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "RenglonFactura";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Lote";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);


            contador = 1;

            foreach (Entidades.FacturaCompra_Detalle fd in pFactura.Detalle)
            {
                dtProductos.Rows.Add(fd.Renglon, fd.RenglonRemito, fd.Producto.Codigo, fd.Producto.Descripcion, fd.Cantidad,
                     fd.PrecioUnitario, fd.PorIva, fd.Iva, fd.Codigofactura, fd.RenglonFactura,fd.MovStock_Lotes.IdLote.IdLote, contador);
                contador++;
            }

            paramItems = new SqlParameter();
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
            if (pFactura.Cheques.Count > 0)
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
                foreach (Entidades.Cheque che in pFactura.Cheques)
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
            if (pFactura.ChequesPropios.Count > 0)
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
                foreach (Entidades.Cheque che in pFactura.ChequesPropios)
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


        public static int AgregarLiquidacion(Entidades.FacturaCompra pFactura, Entidades.Asiento pAsiento)
        {

            //Creo objeto conexion
            strProc = "SP_LIQUIDACIONESPROVEEDORES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.Sucursal.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pFactura.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pFactura.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@FechaEmision", pFactura.FechaEmision);
            objCommand.Parameters.AddWithValue("@FechaContable", pFactura.FechaContable);
            objCommand.Parameters.AddWithValue("@CodigoTipoCompra", pFactura.TipoCompra);
            objCommand.Parameters.AddWithValue("@Neto1", pFactura.Neto1);
            objCommand.Parameters.AddWithValue("@DescripImp1", pFactura.DescripImp1);
            objCommand.Parameters.AddWithValue("@ImporteImp1", pFactura.ImporteImp1);
            objCommand.Parameters.AddWithValue("@Neto2", pFactura.Neto2);
            objCommand.Parameters.AddWithValue("@DescripImp2", pFactura.DescripImp2);
            objCommand.Parameters.AddWithValue("@ImporteImp2", pFactura.ImporteImp2);
            objCommand.Parameters.AddWithValue("@NoGravado", pFactura.NoGravado);
            objCommand.Parameters.AddWithValue("@Exento", pFactura.Exento);
            objCommand.Parameters.AddWithValue("@Comision", pFactura.Comision);
            objCommand.Parameters.AddWithValue("@Redondeo", pFactura.Redondeo);
            
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);
            objCommand.Parameters.AddWithValue("@CodigoLiquidacion", pFactura.Liquidacion);

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


            foreach (Entidades.FacturaCompra_Detalle fd in pFactura.Detalle)
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
                foreach (Entidades.FacturaCompra_Merma fm in pFactura.Mermas)
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

        public static int AgregarLiquidacionDeposito(Entidades.FacturaCompra pFactura, Entidades.Asiento pAsiento)
        {

            //Creo objeto conexion
            strProc = "SP_LIQUIDACIONESPROVEEDORESDEPOSITO_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.Sucursal.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pFactura.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pFactura.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@FechaEmision", pFactura.FechaEmision);
            objCommand.Parameters.AddWithValue("@FechaContable", pFactura.FechaContable);
            objCommand.Parameters.AddWithValue("@CodigoTipoCompra", pFactura.TipoCompra);
            objCommand.Parameters.AddWithValue("@Neto1", pFactura.Neto1);
            objCommand.Parameters.AddWithValue("@DescripImp1", pFactura.DescripImp1);
            objCommand.Parameters.AddWithValue("@ImporteImp1", pFactura.ImporteImp1);
            objCommand.Parameters.AddWithValue("@Neto2", pFactura.Neto2);
            objCommand.Parameters.AddWithValue("@DescripImp2", pFactura.DescripImp2);
            objCommand.Parameters.AddWithValue("@ImporteImp2", pFactura.ImporteImp2);
            objCommand.Parameters.AddWithValue("@NoGravado", pFactura.NoGravado);
            objCommand.Parameters.AddWithValue("@Exento", pFactura.Exento);
            objCommand.Parameters.AddWithValue("@Comision", pFactura.Comision);
            objCommand.Parameters.AddWithValue("@Redondeo", pFactura.Redondeo);


            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);
            objCommand.Parameters.AddWithValue("@CodigoLiquidacion", pFactura.Liquidacion);

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
            /*
            DataTable dtVentas = new DataTable();
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtVentas.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "PrecioUnitario";
            dtVentas.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Cordoba";
            dtVentas.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "VillaMaria";
            dtVentas.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "RioCuarto";
            dtVentas.Columns.Add(column);

    */
            foreach (Entidades.FacturaCompra_Detalle fd in pFactura.Detalle)
            {
                dtProductos.Rows.Add(fd.Renglon, fd.Producto.Codigo, fd.Producto.Descripcion, fd.MovStock_Lotes.Cantidad,
                     fd.PrecioUnitario, fd.PorIva, fd.Iva, fd.Codigofactura, fd.RenglonFactura);
             //   dtVentas.Rows.Add(fd.Renglon, fd.PrecioUnitario, fd.CantCba, fd.CantVM, fd.CantRC);
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);

          /*  SqlParameter paramItems2 = new SqlParameter();
            paramItems2.ParameterName = "@Ventas";
            paramItems2.Direction = ParameterDirection.Input;
            paramItems2.Value = dtVentas;
            paramItems2.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems2);
            */

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
                foreach (Entidades.FacturaCompra_Merma fm in pFactura.Mermas)
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

            #region Impuestos
            if (pFactura.Impuestos.Count > 0)
            {
                DataTable dtImpuesto = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtImpuesto.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoImpuesto";
                dtImpuesto.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtImpuesto.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CuentaContable";
                dtImpuesto.Columns.Add(column);

                int contador = 1;
                foreach (Entidades.FacturaImpuesto fi in pFactura.Impuestos)
                {
                    dtImpuesto.Rows.Add(contador++, fi.Impuesto.Codigo, fi.Importe, fi.Impuesto.CuentaContable.Codigo);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Impuestos";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtImpuesto;
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
        public static DataTable ObtenerEncabezadoLiquidacion(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESPROVEEDORES_SELECT";
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
            strProc = "SP_FACTURASCOMPRAS_MERMAS_SELECT";
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
        
        public static int AgregarSaldoInicial(Entidades.FacturaCompra pFactura)
        {

            //Creo objeto conexion
            strProc = "SP_FACTURASCOMPRASSALDOINICIAL_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);

            // SqlTransaction transaccion = null;
            SqlTransaction transaccion = null;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pFactura.Sucursal.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pFactura.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFactura.Numero);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pFactura.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pFactura.FechaEmision);

            objCommand.Parameters.AddWithValue("@Importe", pFactura.Neto1);



            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFactura.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pFactura.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoImputacion", pFactura.Imputacion);


            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;
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

        public static DataTable ObtenerFacturasCuentaCorriente(Entidades.Proveedor pProveedor, DateTime pDesde)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASCOMPRAS_CUENTASCORRIENTEPORPROVEEDOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static DataTable ObtenerFacturasSinImputarPorProveedor(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASCOMPRAS_SINIMPUTARPORPROVEEDOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static void Anular(Entidades.FacturaCompra pFactura)
        {

            //Creo objeto conexion
            strProc = "SP_FACTURASCOMPRAS_ANULAR";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pFactura.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pFactura.Proveedor.Codigo);
            // objCommand.Parameters.AddWithValue("@PuntoVenta", pFactura.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Letra", pFactura.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFactura.PuntoDeVenta);
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
            catch (Exception ex)
            {
                //transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }

        public static int ValidarExistencia(Entidades.FacturaCompra pFacturaCompra)
        {

            //Creo objeto conexion
           // int res;
            strProc = "SP_FACTURASCOMPRASVALIDAR_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pFacturaCompra.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pFacturaCompra.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pFacturaCompra.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pFacturaCompra.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pFacturaCompra.Numero);
           
            try
            {

                objConexion.Open();

                //objCommand.ExecuteScalar();

                //int CodigoAsiento = AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                //objCommand.Parameters.AddWithValue("@CodigoAsientoTemp", CodigoAsiento);
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

        public static int ObtenerSiguienteNumero(Entidades.TipoDocumentoProveedor pTipoDocumentoProveedor, Entidades.Proveedor pProveedor)
        {

            //Creo objeto conexion
            // int res;
            strProc = "SP_NUMEROCOMPROBANTEPROVEEDORSEGUIENTE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pTipoDocumentoProveedor.Codigo);
            
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

        public static DataTable ObtenerLiquidacionesPorProveedor(DateTime pDesde, DateTime pHasta,Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASCOMPRAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static DataTable ObtenerLiquidacionesPorProveedor(DateTime pDesde, DateTime pHasta, Entidades.Proveedor pProveedor, Entidades.Producto pProducto, Entidades.Lote pLote)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESPROVEEDORESLOTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Lote", pLote.IdLote);
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

        public static DataTable ObtenerFacturasParaImputar(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASCOMPRAS_PARAIMPUTAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static DataTable ObtenerImputacionesDetalle(Entidades.Pago pPago)
        {
            DataTable dt = new DataTable();
            strProc = "SP_IMPUTACIONPROVEEDORESDETALLE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPagoProveedor", pPago.Codigo);
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






