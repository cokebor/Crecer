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
    
    public static class CambiosCheques
    {
        private static SqlConnection objConexion = null;
        private static string strProc = string.Empty;
        private static SqlCommand objCommand = null;
        static CambiosCheques()
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

        public static void Agregar(Entidades.CambiosCheques pCambiosCheques, string pCodigoTipoEstadoValor,  Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_CAMBIOSCHEQUES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Fecha", pCambiosCheques.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCambiosCheques.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoEstadoValor", pCodigoTipoEstadoValor);



            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region ChequesDeTerceros
            if (pCambiosCheques.Cheques.Count > 0)
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
                foreach (Entidades.Cheque che in pCambiosCheques.Cheques)
                {
                    dtCheques.Rows.Add(contador++, che.Codigo, che.Moneda.Cotizacion);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@ChequesCartera";
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
