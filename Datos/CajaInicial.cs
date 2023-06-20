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
    public static class CajaInicial
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
       // private static SqlDataAdapter objDataAdapter = null;
        static CajaInicial()
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

        public static int Agregar(Entidades.CajaInicial pCaja)
        {

            //Creo objeto conexion
            strProc = "SP_CAJAINICIAL_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCaja", pCaja.TipoDocumentoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pCaja.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pCaja.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pCaja.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pCaja.Numero);
            objCommand.Parameters.AddWithValue("@Observaciones", pCaja.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCaja.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pCaja.PuestoCaja.Codigo);

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
            
            
            #region ChequesPropios
            if (pCaja.Cheques.Count > 0)
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
                foreach (Entidades.Cheque che in pCaja.Cheques)
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
            
            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;


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
       
    }
}
