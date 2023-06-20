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
    public static class Venta
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        //private static SqlDataReader objDataReader = null;

        static Venta()
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

        public static DataTable ObtenerTodosPorLote(Entidades.Lote pLote, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_VENTAPORLOTE";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@IDLOTE", pLote.IdLote);
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

        public static int Agregar(Entidades.SaldoInicialVentas pVenta)
        {

            //Creo objeto conexion
            strProc = "SP_VENTAS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;

            
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCliente", pVenta.TipoDocumentoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pVenta.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pVenta.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pVenta.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pVenta.Numero);
            objCommand.Parameters.AddWithValue("@CodigoVendedor", pVenta.Vendedor.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pVenta.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pVenta.PuestoCaja.Codigo);
            
            
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
            column.DataType = System.Type.GetType("System.Int32");
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
            foreach (Entidades.Factura_Detalle fd in pVenta.Detalle)
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
            /*
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
    */
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


    }
}
