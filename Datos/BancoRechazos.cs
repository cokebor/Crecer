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
    public static class BancoRechazos
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        static BancoRechazos()
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
        public static int Agregar(Entidades.BancoRechazados pBancoRechazado, Entidades.Asiento pAsiento)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_BANCORECHAZOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Letra", pBancoRechazado.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pBancoRechazado.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pBancoRechazado.Numero);
            objCommand.Parameters.AddWithValue("@Fecha", pBancoRechazado.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pBancoRechazado.CuentaBancaria.Codigo);
            objCommand.Parameters.AddWithValue("@Observaciones", pBancoRechazado.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pBancoRechazado.Usuario.Codigo);


            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region ChequesDeTerceros
            if (pBancoRechazado.Cheques.Count > 0)
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
                foreach (Entidades.Cheque che in pBancoRechazado.Cheques)
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
    }
}
