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
    public class ConciliacionesProveedores
    {
        private static SqlConnection objConexion = null;

        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        static ConciliacionesProveedores()
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

        public static int Agregar(Entidades.Caja pCaja, Entidades.Asiento pAsientoCaja, Entidades.Pago pPagoProveedor, Entidades.Asiento pAsientoPago)
        {
            strProc = "SP_CONCILIACIONESPROVEEDORES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCaja", pCaja.TipoDocumentoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pCaja.Fecha);
            objCommand.Parameters.AddWithValue("@LetraC", pCaja.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVentaC", pCaja.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@NumeroC", pCaja.Numero);
            objCommand.Parameters.AddWithValue("@ObservacionesC", pCaja.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCaja.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pCaja.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pCaja.SucursalDestino);

            objCommand.Parameters.AddWithValue("@CodigoProveedor", pPagoProveedor.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoProveedor", pPagoProveedor.TipoDocumentoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@LetraP", pPagoProveedor.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVentaP", pPagoProveedor.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@NumeroP", pPagoProveedor.Numero);
            objCommand.Parameters.AddWithValue("@Total", pPagoProveedor.Total);
            objCommand.Parameters.AddWithValue("@ObservacionesP", pPagoProveedor.Observaciones);


            objCommand.Parameters.AddWithValue("@CodigoPagoProveedorSucursal", pPagoProveedor.Codigo);

            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Efectivo

            if (pCaja.FacturaEfectivo.Count > 0)
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
                foreach (Entidades.Factura_Efectivo fe in pCaja.FacturaEfectivo)
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
            if (pCaja.Cheques.Count > 0)
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
                column.ColumnName = "CodigoCierreCaja";
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
                foreach (Entidades.Cheque che in pCaja.Cheques)
                {
                    dtCheques.Rows.Add(contador++, che.Codigo, che.Banco.Codigo, che.NumeroCheque, che.CuentaBancaria.Codigo, che.FechaEmision, che.FechaPago, che.Librador, che.Cuit,che.CodigoCierreCaja, che.Moneda.Codigo, che.Moneda.Cotizacion, che.Importe);
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

                int CodigoAsientoC = Asiento.Agregar(pAsientoCaja, objConexion, transaccion);
                objCommand.Parameters.AddWithValue("@CodigoAsientoC", CodigoAsientoC);
                int CodigoAsientoP = Asiento.Agregar(pAsientoPago, objConexion, transaccion);
                objCommand.Parameters.AddWithValue("@CodigoAsientoP", CodigoAsientoP);
                
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
