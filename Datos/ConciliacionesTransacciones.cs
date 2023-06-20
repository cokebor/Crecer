using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public static class ConciliacionesTransacciones
    {
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;

        private static string strProc = string.Empty;
        static ConciliacionesTransacciones()
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

        /*
public static void Agregar(Entidades.FormaDePago pFormaDePago,Entidades.Sucursal pSucursal, Entidades.CuentaBancaria pCuentaBancaria, DateTime pFechaConciliacion  ,Entidades.Usuario pUsuario, List<Entidades.Transacciones> pTranferencias, List<Entidades.Transacciones> pDebitoCredito, double pGasto, double pIva, double pRetIIBB, double pRetIva)
{
   strProc = "SP_CONCILIACIONTRANSACCIONES_INSERT";
   objCommand = new SqlCommand(strProc, objConexion);
   SqlTransaction transaccion = null;


   objCommand.CommandType = CommandType.StoredProcedure;
   objCommand.Parameters.AddWithValue("@CodigoFormaDePago", pFormaDePago.Codigo);
   objCommand.Parameters.AddWithValue("@CodigoSucursal", pSucursal.Codigo);
   objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCuentaBancaria.Codigo);

   objCommand.Parameters.AddWithValue("@CodigoCuentaContableTranferencia", pCuentaBancaria.CuentaContable.Codigo);
   objCommand.Parameters.AddWithValue("@FechaConciliacion", pFechaConciliacion);
   objCommand.Parameters.AddWithValue("@CodigoUsuario", pUsuario.Codigo);
   objCommand.Parameters.AddWithValue("@GastoBancario", pGasto);

   DataColumn column;
   SqlParameter paramItems;
   int contador;

   #region Tranferencias

   if (pTranferencias.Count > 0)
   {
       DataTable dtTranferencias = new DataTable();

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int32");
       column.ColumnName = "Renglon";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.DateTime");
       column.ColumnName = "Fecha";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int16");
       column.ColumnName = "CodigoTipoMovimientoBancario";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int32");
       column.ColumnName = "CodigoPago";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int16");
       column.ColumnName = "RenglonPago";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.String");
       column.ColumnName = "Observaciones";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int64");
       column.ColumnName = "CodigoCuentaContable";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Double");
       column.ColumnName = "Importe";
       dtTranferencias.Columns.Add(column);

       foreach (Entidades.Transacciones tr in pTranferencias)
       {
           dtTranferencias.Rows.Add(tr.Renglon,tr.Fecha,tr.TipoMovimientoBancario.Codigo, tr.CodigoPago, tr.RenglonPago, tr.Observaciones,tr.CuentaContable.Codigo, tr.Importe);
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

   if (pDebitoCredito.Count > 0)
   {
       DataTable dtTranferencias = new DataTable();

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int32");
       column.ColumnName = "Renglon";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int16");
       column.ColumnName = "CodigoFormaDePago";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int32");
       column.ColumnName = "CodigoPago";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int16");
       column.ColumnName = "RenglonPago";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.String");
       column.ColumnName = "Observaciones";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int64");
       column.ColumnName = "CodigoCuentaContable";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Int16");
       column.ColumnName = "CodigoTipoTarjeta";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.String");
       column.ColumnName = "NroCupon";
       dtTranferencias.Columns.Add(column);

       column = new DataColumn(); ;
       column.DataType = System.Type.GetType("System.Double");
       column.ColumnName = "Importe";
       dtTranferencias.Columns.Add(column);

       foreach (Entidades.Transacciones tr in pDebitoCredito)
       {
           dtTranferencias.Rows.Add(tr.Renglon, tr.FormaDePago.Codigo, tr.CodigoPago, tr.RenglonPago, tr.Observaciones, tr.CuentaContable.Codigo,tr.TipoDeTarjetas.Codigo, tr.NroCupon,tr.Importe);
       }

       paramItems = new SqlParameter();
       paramItems.ParameterName = "@DebitoCredito";
       paramItems.Direction = ParameterDirection.Input;
       paramItems.Value = dtTranferencias;
       paramItems.SqlDbType = SqlDbType.Structured;
       objCommand.Parameters.Add(paramItems);
   }
   #endregion
   try
   {

       objConexion.Open();
       transaccion = objConexion.BeginTransaction();
       objCommand.Transaction = transaccion;

       objCommand.ExecuteScalar();

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
}*/

        public static void Agregar(Entidades.FormaDePago pFormaDePago, Entidades.Sucursal pSucursal,Entidades.CuentaBancaria pCuentaBancaria, Conciliacion pConciliacion, Entidades.Usuario pUsuario, Entidades.Asiento pAsiento, Entidades.Proveedor pProveedor, Entidades.PuestoCaja pPuesto, DateTime pFechaContable)
        {
            strProc = "SP_CONCILIACIONTRANSACCIONES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoFormaDePago", pFormaDePago.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pSucursal.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCuentaBancaria.Codigo);

            objCommand.Parameters.AddWithValue("@CodigoCuentaContableTranferencia", pCuentaBancaria.CuentaContable.Codigo);
            objCommand.Parameters.AddWithValue("@FechaConciliacion", pConciliacion.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pUsuario.Codigo);
            objCommand.Parameters.AddWithValue("@GastoBancario", pConciliacion.Gastos);
             objCommand.Parameters.AddWithValue("@Iva", pConciliacion.IVA);
            objCommand.Parameters.AddWithValue("@Descripcion", pAsiento.Descripcion==null?"":pAsiento.Descripcion);
            objCommand.Parameters.AddWithValue("@FechaContable", pFechaContable);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuesto.Codigo);
            /*
             objCommand.Parameters.AddWithValue("@RetIva", pRetIva);
             objCommand.Parameters.AddWithValue("@RetIIBB", pRetIIBB);*/
            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Tranferencias
            
            if (pConciliacion.Tranferencias.Count > 0)
            {
                DataTable dtTranferencias = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); 
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "Fecha";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); 
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "CodigoTipoMovimientoBancario";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); 
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoPago";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "RenglonPago";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); 
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Observaciones";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); 
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); 
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtTranferencias.Columns.Add(column);

                foreach (Entidades.Transacciones tr in pConciliacion.Tranferencias)
                {
                    if (tr.Observaciones.Length > 200)
                        tr.Observaciones = tr.Observaciones.Substring(0, 199);
                    dtTranferencias.Rows.Add(tr.Renglon, tr.Fecha, tr.TipoMovimientoBancario.Codigo, tr.CodigoPago, tr.RenglonPago, tr.Observaciones/*.Substring(0, 190)*/, tr.CuentaContable.Codigo, tr.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Tranferencias";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtTranferencias;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region DepositoEfectivo

            if (pConciliacion.DepositoSucursalesEfectivos.Count > 0)
            {
                DataTable dtDepEfectivo = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDepEfectivo.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "Fecha";
                dtDepEfectivo.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "CodigoTipoMovimientoBancario";
                dtDepEfectivo.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCaja";
                dtDepEfectivo.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Observaciones";
                dtDepEfectivo.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtDepEfectivo.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtDepEfectivo.Columns.Add(column);

                foreach (Entidades.DepositoSucursalesEfectivo dse in pConciliacion.DepositoSucursalesEfectivos)
                {
                    if (dse.Observaciones.Length > 200)
                        dse.Observaciones = dse.Observaciones.Substring(0, 199);
                    dtDepEfectivo.Rows.Add(dse.Renglon, dse.Fecha, dse.TipoMovimientoBancario.Codigo, dse.CodigoCaja, dse.Observaciones/*.Substring(0, 190)*/, dse.CuentaContable.Codigo, dse.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Efectivo";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtDepEfectivo;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region DepositoCheques

            if (pConciliacion.DepositoSucursalesCheques.Count > 0)
            {
                DataTable dtDepCheques = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "Fecha";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "CodigoTipoMovimientoBancario";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCaja";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Observaciones";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoChequeSucursal";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoBanco";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NroCheque";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "FechaEmision";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "FechaPago";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Librador";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUIT";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoMoneda";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtDepCheques.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtDepCheques.Columns.Add(column);

                foreach (Entidades.DepositoSucursalesCheques dse in pConciliacion.DepositoSucursalesCheques)
                {
                    if (dse.Observaciones.Length > 200)
                        dse.Observaciones = dse.Observaciones.Substring(0, 199);
                    dtDepCheques.Rows.Add(dse.Renglon, dse.Fecha, dse.TipoMovimientoBancario.Codigo, dse.CodigoCaja, dse.Observaciones/*.Substring(0, 190)*/, dse.CuentaContable.Codigo,dse.Cheque.Codigo,dse.Cheque.Banco.Codigo, dse.Cheque.NumeroCheque,dse.Cheque.FechaEmision,dse.Cheque.FechaPago,dse.Cheque.Librador, dse.Cheque.Cuit,dse.Cheque.Moneda.Codigo, dse.Cheque.Moneda.Cotizacion, dse.Cheque.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Cheques";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtDepCheques;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region DebitoCredito

            if (pConciliacion.DebitoCreditos.Count > 0)
            {
                DataTable dtTranferencias = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "CodigoFormaDePago";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoPago";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "RenglonPago";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Observaciones";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "CodigoTipoTarjeta";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NroCupon";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtTranferencias.Columns.Add(column);

                foreach (Entidades.Transacciones tr in pConciliacion.DebitoCreditos)
                {
                    dtTranferencias.Rows.Add(tr.Renglon, tr.FormaDePago.Codigo, tr.CodigoPago, tr.RenglonPago, tr.Observaciones, tr.CuentaContable.Codigo, tr.TipoDeTarjetas.Codigo, tr.NroCupon, tr.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@DebitoCredito";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtTranferencias;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            #region DataTable Impuestos
            DataTable dtImpuestos = new DataTable();

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn();
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
            foreach (Entidades.FacturaImpuesto fi in pConciliacion.Impuestos)
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
            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;
                int CodigoAsiento;
                if (pFormaDePago.Codigo == 0)
                    CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);
                else
                    CodigoAsiento = 0;
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




    }
}
