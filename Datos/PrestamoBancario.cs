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
    public static class PrestamoBancario
    {
        private static SqlConnection objConexion = null;
        private static string strProc = string.Empty;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static PrestamoBancario()
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

        public static int Agregar(Entidades.PrestamoBancario pPrestamo)
        {
            //Creo objeto conexion
            strProc = "SP_PRESTAMOSBANCARIOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;
            objCommand.CommandTimeout = 0;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@FechaOtorgamiento", pPrestamo.FechaOtorgamiento);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pPrestamo.Cuentabancaria.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSistemaAmortizacion", pPrestamo.SistemaAmortizacion.Codigo);
            objCommand.Parameters.AddWithValue("@Capital", pPrestamo.Capital);
            objCommand.Parameters.AddWithValue("@CodigoFrecuenciaPago", pPrestamo.FrecuenciaPago.Codigo);
            objCommand.Parameters.AddWithValue("@CantidadDeCuotas", pPrestamo.CantCuotas);
            objCommand.Parameters.AddWithValue("@TNA", pPrestamo.TNA);
            objCommand.Parameters.AddWithValue("@CodigoPeriodoDeGracia", pPrestamo.PeriodoDeGracia.Codigo);
            objCommand.Parameters.AddWithValue("@FechaPrimerCuota", pPrestamo.FechaPrimerCuota);
            objCommand.Parameters.AddWithValue("@Tasa", pPrestamo.Tasa);
            DataColumn column;
            SqlParameter paramItems;

            #region Tabla

            if (pPrestamo.TablaAmortizacion.Count > 0)
            {
                DataTable dtTaba = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Cuota";
                dtTaba.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "Fecha";
                dtTaba.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "CapitalAmortizado";
                dtTaba.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Interes";
                dtTaba.Columns.Add(column);


                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "IVA";
                dtTaba.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "CuotaAPagar";
                dtTaba.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "CapitalPendiente";
                dtTaba.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Boolean");
                column.ColumnName = "Estado";
                dtTaba.Columns.Add(column);

              
                foreach (Entidades.TablaAmortizacion t in pPrestamo.TablaAmortizacion)
                {
                    dtTaba.Rows.Add(t.Cuota, t.Fecha, t.CapitalAmortizado,t.Interes,t.IVA,t.CuotaAPagar,t.CapitalPendiente,t.Estado);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Tabla";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtTaba;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            try
            {
                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                int CodigoAsiento = Asiento.Agregar(pPrestamo.Asiento, objConexion, transaccion);

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

        public static int AgregarPago(PrestamoBancarioPago objPPrestamo)
        {
            //Creo objeto conexion
            strProc = "SP_PRESTAMOSBANCARIOSPAGOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;
            objCommand.CommandTimeout = 0;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoPrestamo", objPPrestamo.Prestamo.CodigoPrestamo);
            objCommand.Parameters.AddWithValue("@Cuota", objPPrestamo.TablaAmortizacion.Cuota);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", objPPrestamo.CuentaBancaria.Codigo);
            objCommand.Parameters.AddWithValue("@FechaCuota", objPPrestamo.FechaPago);
            objCommand.Parameters.AddWithValue("@FechaContable", objPPrestamo.FechaContable);
            objCommand.Parameters.AddWithValue("@CapitalAmortizado", objPPrestamo.TablaAmortizacion.CapitalAmortizado);
            objCommand.Parameters.AddWithValue("@Interes", objPPrestamo.TablaAmortizacion.Interes);
            objCommand.Parameters.AddWithValue("@IVA", objPPrestamo.TablaAmortizacion.IVA);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", objPPrestamo.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", objPPrestamo.PuestoCaja.Codigo);

            try
            {
                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                int CodigoAsiento = Asiento.Agregar(objPPrestamo.Asiento, objConexion, transaccion);

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

        public static DataTable ObtenerPrestamosBancariosPendientes(Entidades.CuentaBancaria pCuentaBancaria)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PRESTAMOSBANCARIOSPENDIENTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCuentaBancaria.Codigo);
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

        public static DataTable ObtenerPrestamosBancariosPendientes(int pCodigoPrestamo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PRESTAMOSBANCARIOSTABLAPORPRESTAMOPENDIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPrestamo", pCodigoPrestamo);
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
        public static Entidades.TablaAmortizacion ObtenerCuotaUna(int pCodigoPrestamo, int pCuota)
        {
            Entidades.TablaAmortizacion da = new Entidades.TablaAmortizacion();
            strProc = "SP_PRESTAMOSBANCARIOSCUOTAS_SELECTUNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoPrestamo", pCodigoPrestamo);
            objCommand.Parameters.AddWithValue("@Cuota", pCuota);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();

                if (objDataReader.HasRows.Equals(false))
                {
                    da = null;
                }
                else
                {
                    da.Cuota = Convert.ToInt32(objDataReader["Cuota"]);
                    da.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    da.CapitalAmortizado = Convert.ToDouble(objDataReader["CapitalAmortizado"]);
                    da.Interes = Convert.ToDouble(objDataReader["Interes"]);
                    da.IVA = Convert.ToDouble(objDataReader["IVA"]);
                    da.CuotaAPagar = Convert.ToDouble(objDataReader["CuotaAPagar"]);
                    da.CapitalPendiente = Convert.ToDouble(objDataReader["CapitalPendiente"]);
                    da.Estado = Convert.ToBoolean(objDataReader["Estado"]);
                    
                }

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
            return da;

        }
    }
}
