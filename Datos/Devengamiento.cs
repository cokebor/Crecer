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
    public static class Devengamiento
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static Devengamiento()
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
        
        public static void Agregar(Entidades.Devengamiento pDevengamiento, Entidades.Caja pCaja)//, List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_DEVENGAMIENTO_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoConcepto", pDevengamiento.Concepto.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoSalario", pDevengamiento.TipoSalario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSecuencia", pDevengamiento.Secuencia.Codigo);
            objCommand.Parameters.AddWithValue("@Periodo", pDevengamiento.Periodo);
            objCommand.Parameters.AddWithValue("@Fecha", pDevengamiento.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pDevengamiento.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCaja", pCaja.Codigo);

            DataColumn column;
            SqlParameter paramItems;
           // int contador;

            #region Detalle

            if (pDevengamiento.Detalles.Count > 0)
            {
                DataTable dtDetalle = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaAsociada";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Debe";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Haber";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "SaldoAnterior";
                dtDetalle.Columns.Add(column);

                foreach (Entidades.DevengamientoDetalle s in pDevengamiento.Detalles)
                {
                    dtDetalle.Rows.Add(s.Renglon, s.Concepto.Codigo, s.CuentaContable.Codigo, s.Debe, s.Haber, s.SaldoAnterior);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Detalle";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtDetalle;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;


                int CodigoAsiento = Asiento.Agregar(pDevengamiento.Asiento, objConexion, transaccion);
                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);
                objCommand.ExecuteScalar();

                // AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
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
        }

        public static bool ValidarExistencia(Entidades.Devengamiento pDevengamiento)
        {
            bool res;
            strProc = "SP_DEVENGAMIENTO_VALIDAREXISTENCIA";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoConcepto", pDevengamiento.Concepto.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoSalario", pDevengamiento.TipoSalario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSecuencia", pDevengamiento.Secuencia.Codigo);
            objCommand.Parameters.AddWithValue("@Periodo", pDevengamiento.Periodo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                res = Convert.ToBoolean(objDataReader["res"]);

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
            return res;
        }

        public static void Anular(Entidades.Devengamiento pDevengamiento)
        {
            strProc = "SP_DEVENGAMIENTO_ANULAR";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoDevengamiento", pDevengamiento.Codigo);

            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                objCommand.ExecuteNonQuery();

                //AsientoTemp.Agregar(pAsientos, objConexion, transaccion);
                transaccion.Commit();
            }
            catch (SqlException sql)
            {
                throw new Exception(sql.Message);
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

        public static DataTable ObtenerAlgunos(int pCodigoDevengamiento)
        {
            /*using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            {*/
            DataTable dt = new DataTable();
            strProc = "SP_CONCEPTOAPAGAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipo", pTipoSalario);
            //objDataAdapter.SelectCommand.Parameters.AddWithValue("@Periodo", pPeriodo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoDevengamiento", pCodigoDevengamiento);
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }
        public static int ObtenerUno(int pCodigoSalario, int pCodigoConcepto)
        {
            //Entidades.ConceptoAsociadoASueldo objConcepto = new Entidades.ConceptoAsociadoASueldo();
            int renglon;
            strProc = "SP_DEVENGAMIENTODETALLE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoDevengamiento", pCodigoSalario);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTAASOCIADA", pCodigoConcepto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                renglon = Convert.ToInt32(objDataReader["Renglon"]);

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
            return renglon;
        }
        public static Entidades.Devengamiento ObtenerUno(int pCodigoDevengamiento)
        {
            //Entidades.ConceptoAsociadoASueldo objConcepto = new Entidades.ConceptoAsociadoASueldo();
            Entidades.Devengamiento objEDevengamiento = new Entidades.Devengamiento();
            //int renglon;
            strProc = "SP_DEVENGAMIENTO_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoDevengamiento", pCodigoDevengamiento);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objEDevengamiento.Codigo = pCodigoDevengamiento;
                objEDevengamiento.Concepto.Codigo= Convert.ToInt32(objDataReader["CodigoConcepto"]);
                objEDevengamiento.Concepto.Descripcion = objDataReader["Concepto"].ToString();
                objEDevengamiento.TipoSalario.Descripcion= objDataReader["Tipo"].ToString();
                objEDevengamiento.Periodo= objDataReader["Periodo"].ToString();
                objEDevengamiento.Fecha= Convert.ToDateTime(objDataReader["Fecha"]);

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
            return objEDevengamiento;
        }

        public static DataTable Obtener(Entidades.Concepto objEConcepto, DateTime pDesde, DateTime pHasta, bool pSoloPendientesDePago)
        {
            DataTable dt = new DataTable();
            strProc = "SP_DEVENGAMIENTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoConcepto", objEConcepto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@SoloPendientesDePago", pSoloPendientesDePago);

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
        public static DataTable ObtenerDetalle(int pCodigoDevengamiento)
        {
            DataTable dt = new DataTable();
            strProc = "SP_DEVENGAMIENTODETALLE_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoDevengamiento", pCodigoDevengamiento);

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
