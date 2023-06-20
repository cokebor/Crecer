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
    public static class Caja
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static Caja()
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

        public static int AgregarEgreso(Entidades.Caja pCaja, Entidades.Asiento pAsiento)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_CAJAEGRESO_INSERT";
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
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pCaja.SucursalDestino);
            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Efectivo

            if (pCaja.FacturaEfectivo.Count > 0)
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
                foreach (Entidades.Factura_Efectivo fe in pCaja.FacturaEfectivo)
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
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtCheques.Columns.Add(column);


                contador = 1;
                foreach (Entidades.Cheque che in pCaja.Cheques)
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

            #region Tranferencias
            if (pCaja.Tranferencias.Count > 0)
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
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtTranferencias.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Tranferencia tra in pCaja.Tranferencias)
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

            #region ChequesPropios
            if (pCaja.ChequesPropios.Count > 0)
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
                foreach (Entidades.Cheque che in pCaja.ChequesPropios)
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

        public static DataTable ObtenerDepositoChequesSucursalesPendientes(Entidades.CuentaBancaria pCuentaBancaria)
        {
            DataTable dt = new DataTable();
            strProc = "SP_DEPOSITOCHEQUESSUCUSALESPENDIENTES_SELECT";
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

            return dt; ;
        }

        public static DataTable ObtenerDepositoSucursalesPendientes(Entidades.CuentaBancaria pCuentaBancaria)
        {
            DataTable dt = new DataTable();
            strProc = "SP_DEPOSITOEFECTIVOSUCUSALESPENDIENTES_SELECT";
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

        public static void Anular(Entidades.Caja pCaja)
        {
            //Creo objeto conexion
            strProc = "SP_CAJAS_ANULAR";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCaja", pCaja.TipoDocumentoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pCaja.Letra);
            objCommand.Parameters.AddWithValue("@PuntoVenta", pCaja.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pCaja.Numero);

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

        public static void AnularSucursal(Entidades.Caja pCaja)
        {
            //Creo objeto conexion
            strProc = "SP_RENDICION_ANULAR";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCaja", pCaja.TipoDocumentoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pCaja.Letra);
            objCommand.Parameters.AddWithValue("@PuntoVenta", pCaja.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pCaja.Numero);

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
        public static int AgregarIngreso(Entidades.Caja pCaja, Entidades.Asiento pAsiento)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_CAJAINGRESO_INSERT";
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
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pCaja.SucursalDestino);
            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Efectivo

            if (pCaja.FacturaEfectivo.Count > 0)
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
            /*
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
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtCheques.Columns.Add(column);


                contador = 1;
                foreach (Entidades.Cheque che in pCaja.Cheques)
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

            #endregion*/

            #region Tranferencias
            if (pCaja.Tranferencias.Count > 0)
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
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtTranferencias.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Tranferencia tra in pCaja.Tranferencias)
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

            #region Cheques
            //if (pCaja.ChequesPropios.Count > 0)
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
                paramItems.ParameterName = "@ChequesPropios";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtChequesPropios;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            #region Detalle
            if (pCaja.Detalle.Count > 0)
            {
                DataTable dtDetalle = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDetalle.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtDetalle.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Descripcion";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtDetalle.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Caja_Detalle cd in pCaja.Detalle)
                {
                    dtDetalle.Rows.Add(contador++,cd.CodigoCuentaContable, cd.Descripcion,cd.Importe);
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
        public static DataTable ObtenerChequesGasto(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_GASTOSCHEQUES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
            try
            {
                dt.TableName = "dsCheques";
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

        public static object ObtenerChequesDepositados(Entidades.CuentaBancaria pCuentaBancaria, int pCodigoBancoEmision)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUESDEPOSITADOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCuentaBancaria.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoBancoEmision", pCodigoBancoEmision);
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

        public static DataTable ObtenerCajasConCheques(Entidades.CuentaBancaria pCuentaBancaria)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CAJASCONCHEQUESDEPOSITADOS_SELECT";
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
        public static DataTable ObtenerTranferenciasGasto(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_GASTOSTRANFERENCIAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
            try
            {
                dt.TableName = "dsTransferencias";
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
        public static DataTable ObtenerImpuestosGasto(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_GASTOSIMPUESTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
            try
            {
                dt.TableName = "dsCajaImpuestos";
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
        public static DataTable ObtenerDebitoCreditoGasto(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_GASTOSDEBITOCREDITO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
            try
            {
                dt.TableName = "dsDebitoCredito";
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
        public static object ObtenerLibreDisponibilidad(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIBREDISPONIBILIDAD_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
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
        public static DataTable ObtenerEfectivoGasto(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_GASTOSEFECTIVO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
            try
            {
                dt.TableName = "dsEfectivo";
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
        public static DataTable ObtenerFormasDePagoGasto(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_GASTOSFORMASDEPAGO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
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
        public static DataTable ObtenerDetalleGasto(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_GASTOSDETALLE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
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
        public static DataTable ObtenerGastos(long pCuenta, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_GASTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaContable", pCuenta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
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
        public static DataTable ObtenerGastosSucursales(long pCuenta, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_GASTOSSUCURSALES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaContable", pCuenta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
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
        public static int AgregarPagoDevengamiento(Entidades.Caja pCaja, Entidades.Devengamiento pDevengamiento, Entidades.Asiento pAsiento)
        {
            //Creo objeto conexion
            strProc = "SP_CAJADEVENGAMIENTO_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCaja", pCaja.TipoDocumentoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pCaja.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pCaja.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pCaja.Numero);
            objCommand.Parameters.AddWithValue("@Fecha", pCaja.Fecha);
            objCommand.Parameters.AddWithValue("@Observaciones", pCaja.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCaja.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pCaja.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pCaja.SucursalDestino);
            objCommand.Parameters.AddWithValue("@CodigoDevengamiento", pDevengamiento.Codigo);
            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Efectivo

            if (pCaja.FacturaEfectivo.Count > 0)
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

                column = new DataColumn(); 
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
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtCheques.Columns.Add(column);


                contador = 1;
                foreach (Entidades.Cheque che in pCaja.Cheques)
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

            #region ChequesPropios
            if (pCaja.ChequesPropios.Count > 0)
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
                foreach (Entidades.Cheque che in pCaja.ChequesPropios)
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
            #region Tranferencias
            if (pCaja.Tranferencias.Count > 0)
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
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtTranferencias.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Tranferencia tra in pCaja.Tranferencias)
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
                    dtDetalle.Rows.Add(s.Renglon, s.Concepto.Codigo, s.CuentaContable.Codigo, s.Debe, s.Haber,s.SaldoAnterior);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Detalle";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtDetalle;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region Retenciones

            if (pCaja.Retenciones.Count > 0)
            {
                DataTable dtDetalle = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "CodigoSucursal";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoFacturaCompra";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoPagoCliente";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoImpuesto";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoRetencionAsociacion";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Monto";
                dtDetalle.Columns.Add(column);

                int i = 1;
                foreach (Entidades.Retenciones s in pCaja.Retenciones)
                {
                    dtDetalle.Rows.Add(i++, s.CodigoSucursal, s.FacturaCompra.Codigo, s.PagoCliente.Codigo, s.Impuesto.Codigo, s.RetencionAsociado.Codigo, s.Impuesto.CuentaContable.Codigo, s.Monto);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Retenciones";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtDetalle;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region LibreDisponibilidad

            if (pCaja.LibreDisponibilidad.Count > 0)
            {
                DataTable dtDetalle = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoLibreDisponibilidad";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Monto";
                dtDetalle.Columns.Add(column);

                int ren = 0;
                foreach (Entidades.LibreDisponibilidadAsociado s in pCaja.LibreDisponibilidad)
                {
                    dtDetalle.Rows.Add(++ren, s.Codigo, s.CuentaContable.Codigo, s.Monto);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@LibreDisponibilidad";
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
        public static int AgregarGasto(Entidades.Caja pCaja, Entidades.Asiento pAsiento)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_CAJAGASTO_INSERT";
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
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pCaja.SucursalDestino);

            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Efectivo

            if (pCaja.FacturaEfectivo.Count > 0)
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
                foreach (Entidades.Factura_Efectivo fe in pCaja.FacturaEfectivo)
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
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtCheques.Columns.Add(column);


                contador = 1;
                foreach (Entidades.Cheque che in pCaja.Cheques)
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

            #region Tranferencias
            if (pCaja.Tranferencias.Count > 0)
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
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtTranferencias.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Tranferencia tra in pCaja.Tranferencias)
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

            #region ChequesPropios
            if (pCaja.ChequesPropios.Count > 0)
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
                foreach (Entidades.Cheque che in pCaja.ChequesPropios)
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

            #region DebitoCredito
            if (pCaja.CreditosDebitos.Count > 0)
            {
                DataTable dtDebitoCredito = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoFormaDePago";
                dtDebitoCredito.Columns.Add(column);


                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoTipoTarjeta";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Cuotas";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NroCupon";
                dtDebitoCredito.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtDebitoCredito.Columns.Add(column);

                contador = 1;
                foreach (Entidades.CreditoDebito cd in pCaja.CreditosDebitos)
                {
                    dtDebitoCredito.Rows.Add(contador++, cd.FormaDePago.Codigo, cd.CuentaBancaria.Codigo, cd.TipoDeTarjetas.Codigo, cd.Cuotas, cd.NroCupon, cd.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@DebitoCredito";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtDebitoCredito;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region Impuestos
            if (pCaja.Impuestos.Count > 0)
            {
                DataTable dtImpuesto = new DataTable();

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "Renglon";
                dtImpuesto.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoImpuesto";
                dtImpuesto.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtImpuesto.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CuentaContable";
                dtImpuesto.Columns.Add(column);

                contador = 1;
                foreach (Entidades.FacturaImpuesto fi in pCaja.Impuestos)
                {
                    dtImpuesto.Rows.Add(contador++, fi.Impuesto.Codigo, fi.Importe, fi.Impuesto.CuentaContable.Codigo);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Impuestos";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtImpuesto;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            #region Detalle
            if (pCaja.Detalle.Count > 0)
            {
                DataTable dtDetalle = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDetalle.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtDetalle.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Descripcion";
                dtDetalle.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtDetalle.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Caja_Detalle cd in pCaja.Detalle)
                {
                    dtDetalle.Rows.Add(contador++, cd.CodigoCuentaContable,cd.Descripcion, cd.Importe);
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

       
        public static int AgregarDeposito(Entidades.Caja pCaja, Entidades.Asiento pAsiento)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_CAJADEPOSITO_INSERT";
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
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pCaja.SucursalDestino);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCaja.CuentaBancaria.Codigo);

            DataColumn column;
            SqlParameter paramItems;
            int contador;

            #region Efectivo

            if (pCaja.FacturaEfectivo.Count > 0)
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
                foreach (Entidades.Factura_Efectivo fe in pCaja.FacturaEfectivo)
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
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtCheques.Columns.Add(column);


                contador = 1;
                foreach (Entidades.Cheque che in pCaja.Cheques)
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

            #region Tranferencias
            if (pCaja.Tranferencias.Count > 0)
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
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtTranferencias.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Tranferencia tra in pCaja.Tranferencias)
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

            #region ChequesPropios
            if (pCaja.ChequesPropios.Count > 0)
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
                foreach (Entidades.Cheque che in pCaja.ChequesPropios)
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

        public static int Agregar(Entidades.Caja pCaja,Entidades.MovimientoBancario pMovimiento, Entidades.Asiento pAsiento)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_CAJA_INSERT";
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
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pCaja.SucursalDestino);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pMovimiento.CuentaBancaria.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoMovimiento", pMovimiento.TipoMovimientoBancario.Codigo);

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
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtCheques.Columns.Add(column);


                contador = 1;
                foreach (Entidades.Cheque che in pCaja.Cheques)
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
        public static DataTable ObtenerDataTable(int pCodigo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);

            try
            {
                dt.TableName = "dsPagoEncabezado";
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
        public static DataTable ObtenerEfectivoUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAGOSPROVEEDORES_EFECTIVO_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsPagoEfectivo";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerDetalle(int pCodigo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CAJADETALLES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigo);
            try
            {
                dt.TableName = "dsCajaDetalle";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
    
        public static int AgregarRendicion(Entidades.Caja pCaja, Entidades.Asiento pAsiento)// , List<Entidades.AsientoTemp> pAsientos)
        {

            //Creo objeto conexion
            strProc = "SP_CAJARENDICION_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCaja", pCaja.TipoDocumentoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@SucursalDestino", pCaja.SucursalDestino);
            objCommand.Parameters.AddWithValue("@Fecha", pCaja.Fecha);
            objCommand.Parameters.AddWithValue("@Letra", pCaja.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", pCaja.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pCaja.Numero);
            objCommand.Parameters.AddWithValue("@Observaciones", pCaja.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCaja.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pCaja.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCaja.CierreCaja.Codigo);

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
                    dtCheques.Rows.Add(contador++, che.Codigo, che.Banco.Codigo, che.NumeroCheque, che.CuentaBancaria.Codigo, che.FechaEmision, che.FechaPago, che.Librador, che.Cuit, che.Moneda.Codigo, che.Moneda.Cotizacion, che.Importe);
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
        public static DataTable ObtenerRendiciones(DateTime pDesde, DateTime pHasta, int pSucursal)
        {
            DataTable dt = new DataTable();
            strProc = "SP_RENDIONESCAJA_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoSucursal", pSucursal);
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
        public static DataTable ObtenerSaldoInicial(DateTime pFecha) {
            DataTable dt = new DataTable();
            strProc = "SP_SALDOINICIAL_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Fecha", pFecha);
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

        public static DataTable ObtenerCajasDeVengamientos(Entidades.Devengamiento pDevengamiento) {
            DataTable dt = new DataTable();
            strProc = "SP_CAJASDEDEVENGAMIENTO_SELECT_TODAS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoDevengamiento", pDevengamiento.Codigo);
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerPagos() {
            DataTable dt = new DataTable();
            strProc = "SP_CAJASSINDEVENGAMIENTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //objDataAdapter.SelectCommand.Parameters.AddWithValue("@Fecha", pFecha);
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

        public static void AnularMovimientosDeCaja(Entidades.Caja pCaja)
        {
            //Creo objeto conexion
            strProc = "SP_CAJASMOVIMIENTOS_ANULAR";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCaja", pCaja.TipoDocumentoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", pCaja.Letra);
            objCommand.Parameters.AddWithValue("@PuntoVenta", pCaja.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", pCaja.Numero);

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

        public static DataTable ObtenerUna(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CAJAS_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
            try
            {
                dt.TableName = "dsCaja";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;


           
        }
        public static DataTable ObtenerCuentaBancaria(int pCodigoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CUENTABANCARIADECAJA_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCaja", pCodigoCaja);
            try
            {
                dt.TableName = "dsCajaCuenta";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;



        }
        public static Entidades.Caja ObtenerUna(Entidades.Caja pCaja)
        {
            Entidades.Caja objECaja = new Entidades.Caja();
            strProc = "SP_CAJAS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCaja", pCaja.Codigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objECaja.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objECaja.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objECaja.Letra = Convert.ToChar(objDataReader["Letra"]);
                    objECaja.PuntoDeVenta = Convert.ToInt32(objDataReader["PuntoDeVenta"]);
                    objECaja.Numero = Convert.ToInt32(objDataReader["Numero"]);
                    objECaja.Observaciones = objDataReader["Observaciones"].ToString();
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
            return objECaja;
        }
    }
}
