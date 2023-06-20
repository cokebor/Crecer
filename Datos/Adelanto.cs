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
    public static class Adelanto
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static Adelanto()
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
        public static int Agregar(Entidades.Adelanto pAdelanto, Entidades.Asiento pAsiento)
        {
            //Creo objeto conexion
            strProc = "SP_CAJAADELANTO_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCaja", pAdelanto.Caja.TipoDocumentoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pAdelanto.Caja.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pAdelanto.Caja.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pAdelanto.Caja.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pAdelanto.Caja.Numero);
            objCommand.Parameters.AddWithValue("@Observaciones", pAdelanto.Caja.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pAdelanto.Caja.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pAdelanto.Caja.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pAdelanto.Caja.SucursalDestino);
            objCommand.Parameters.AddWithValue("@CodigoEmpleado", pAdelanto.Empleado.Codigo);
            objCommand.Parameters.AddWithValue("@ObservacionesAdelanto", pAdelanto.Observaciones);
            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Efectivo

            if (pAdelanto.Caja.FacturaEfectivo.Count > 0)
            {
                DataTable dtEfectivo = new DataTable();

                column = new DataColumn();
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
                foreach (Entidades.Factura_Efectivo fe in pAdelanto.Caja.FacturaEfectivo)
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
    }
}
