using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;
using Servidor;

namespace Datos
{
    public static class MovimientoBancario
    {
        private static SqlConnection objConexion = null;
      //  private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
      //  private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;

        static MovimientoBancario()
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
        public static int Agregar(Entidades.MovimientoBancario pMovimiento, Entidades.Asiento pAsiento=null)
        {
            strProc = "SP_MOVIMIENTOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pMovimiento.CuentaBancaria.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoMovimiento", pMovimiento.TipoMovimientoBancario.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pMovimiento.FechaMovimiento);
            objCommand.Parameters.AddWithValue("@Observaciones", pMovimiento.Observaciones);
            objCommand.Parameters.AddWithValue("@Importe", pMovimiento.Importe);

            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;
                int CodigoAsiento = 0;
                if (pAsiento != null)
                {
                    CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);
                }

                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);
                int res = Convert.ToInt32(objCommand.ExecuteScalar());

                transaccion.Commit();
                return CodigoAsiento;
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

        public static void Actualizar(List<Entidades.MovimientoBancario> pMovimientos, Entidades.Asiento pAsiento, Entidades.Usuario pUsuario, Entidades.CuentaBancaria pCuentaBancaria)
        {
            strProc = "SP_MOVIMIENTOSBANCARIOS_UPDATE";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@FechaConciliacion", pAsiento.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pUsuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCuentaBancaria.Codigo);
            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Movimientos

            if (pMovimientos.Count > 0)
            {
                DataTable dtEfectivo = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtEfectivo.Columns.Add(column);

                column = new DataColumn(); 
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtEfectivo.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "CodigoMovimientoBancario";
                dtEfectivo.Columns.Add(column);

                contador = 1;
                foreach (Entidades.MovimientoBancario mb in pMovimientos)
                {
                    dtEfectivo.Rows.Add(contador++, mb.CuentaBancaria.Codigo, mb.Codigo);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@MovimientosBancarios";
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
                objCommand.Parameters.AddWithValue("@CodigoAsientoConciliacion", CodigoAsiento);
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
