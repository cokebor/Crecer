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
    
    public static class CambiosChequesProveedores
    {
        private static SqlConnection objConexion = null;
        private static string strProc = string.Empty;
        private static SqlCommand objCommand = null;
        static CambiosChequesProveedores()
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

        public static void Agregar(Entidades.CambiosChequesProveedores pCambiosChequesP,  Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_CAMBIOSCHEQUESPROVEEDORES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Letra", pCambiosChequesP.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pCambiosChequesP.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pCambiosChequesP.Numero);
            objCommand.Parameters.AddWithValue("@Fecha", pCambiosChequesP.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoPago", pCambiosChequesP.Pago.Codigo);

            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCambiosChequesP.Usuario.Codigo);
            
            DataColumn column;
            SqlParameter paramItems;
            int contador;
            
            #region Efectivo

            if (pCambiosChequesP.FacturaEfectivo.Count > 0)
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
                foreach (Entidades.Factura_Efectivo fe in pCambiosChequesP.FacturaEfectivo)
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

            #region ChequesRechazados
            if (pCambiosChequesP.ChequesRechazados.Count > 0)
            {
                DataTable dtChequesRechazados = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtChequesRechazados.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtChequesRechazados.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCheque";
                dtChequesRechazados.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtChequesRechazados.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtChequesRechazados.Columns.Add(column);


                contador = 1;
                foreach (Entidades.Cheque che in pCambiosChequesP.ChequesRechazados)
                {
                    dtChequesRechazados.Rows.Add(contador++,che.CuentaBancaria.Codigo, che.Codigo, che.Importe , che.Moneda.Cotizacion);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@ChequesRechazados";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtChequesRechazados;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }

            #endregion

            #region ChequesPropios
            if (pCambiosChequesP.ChequesPropios.Count > 0)
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
                foreach (Entidades.Cheque che in pCambiosChequesP.ChequesPropios)
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

            #region ChequesDeTerceros
            if (pCambiosChequesP.ChequesTerceros.Count > 0)
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
                foreach (Entidades.Cheque che in pCambiosChequesP.ChequesTerceros)
                {
                    dtCheques.Rows.Add(contador++, che.Codigo, che.Moneda.Cotizacion);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@ChequesTerceros";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtCheques;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }

            #endregion

            #region Tranferencias
            if (pCambiosChequesP.Tranferencias.Count > 0)
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
                foreach (Entidades.Tranferencia tra in pCambiosChequesP.Tranferencias)
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





            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;


                int CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);
                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);
                objCommand.ExecuteScalar();

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
