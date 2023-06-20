using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class Asiento
    {
        private static string strProc = string.Empty;
        private static SqlCommand objCommand = null;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static Asiento()
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

        public static void Agregar(Entidades.Asiento pAsiento)
        {
            //Creo objeto conexion
            strProc = "SP_ASIENTOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);

            //objCommand.Transaction = transaccion;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Fecha", pAsiento.Fecha);
            objCommand.Parameters.AddWithValue("@FechaEmision", pAsiento.FechaEmision);
            objCommand.Parameters.AddWithValue("@Descripcion", pAsiento.Descripcion);

            DataTable dtDetalle = new DataTable();
            DataColumn column;
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Renglon";
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


            int contador = 1;
            foreach (Entidades.Asiento_Detalle ad in pAsiento.Detalle)
            {
                dtDetalle.Rows.Add(contador++, ad.CuentaContable.Codigo, ad.Debe, ad.Haber);

            }


            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDetalle;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            try
            {
                objConexion.Open();
                objCommand.ExecuteScalar();
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
        }
        public static void AgregarAjustes(Entidades.Asiento pAsiento, int pCodigoTipoAsiento, int pCodigoUsuario)
        {
            //Creo objeto conexion
            strProc = "SP_ASIENTOSAJUSTES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);

            //objCommand.Transaction = transaccion;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoAsiento", pCodigoTipoAsiento);
            objCommand.Parameters.AddWithValue("@Fecha", pAsiento.Fecha);
            objCommand.Parameters.AddWithValue("@FechaEmision", pAsiento.FechaEmision);
            objCommand.Parameters.AddWithValue("@Descripcion", pAsiento.Descripcion);
            objCommand.Parameters.AddWithValue("@Sucursal", pAsiento.Sucursal);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCodigoUsuario);

            DataTable dtDetalle = new DataTable();
            DataColumn column;
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Renglon";
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
            column.ColumnName = "CodigoCheque";
            dtDetalle.Columns.Add(column);

            int contador = 1;
            foreach (Entidades.Asiento_Detalle ad in pAsiento.Detalle)
            {
                dtDetalle.Rows.Add(contador++, ad.CuentaContable.Codigo, ad.Debe, ad.Haber, 0);

            }


            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Asientos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDetalle;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            try
            {
                objConexion.Open();
                objCommand.ExecuteScalar();
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
        }

        public static int ValidarFecha(DateTime pFecha){
            int res = 0;
            strProc = "SP_ASIENTOSAJUSTES_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@FechaAsiento", pFecha);

            try
            {

                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(true))
                {
                    res = Convert.ToInt32(objDataReader["res"]);
                }
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

        public static int Agregar(Entidades.Asiento pAsiento, SqlConnection conexion, SqlTransaction transaccion)
        {
            //Creo objeto conexion
            strProc = "SP_ASIENTOS_INSERT";
            objCommand = new SqlCommand(strProc, conexion);

            objCommand.Transaction = transaccion;
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@Fecha", pAsiento.Fecha);
            objCommand.Parameters.AddWithValue("@FechaEmision", pAsiento.FechaEmision);
            objCommand.Parameters.AddWithValue("@Descripcion", pAsiento.Descripcion);
            objCommand.Parameters.AddWithValue("@Sucursal", pAsiento.Sucursal);

            DataTable dtDetalle = new DataTable();
            DataColumn column;
            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Renglon";
            dtDetalle.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "CodigoCuentaContable";
            dtDetalle.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Debe";
            dtDetalle.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Haber";
            dtDetalle.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoCheque";
            dtDetalle.Columns.Add(column);


            int contador = 1;
            foreach (Entidades.Asiento_Detalle ad in pAsiento.Detalle)
            {
                dtDetalle.Rows.Add(contador++, ad.CuentaContable.Codigo, ad.Debe, ad.Haber, ad.Cheque.Codigo);

            }


            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDetalle;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);


            try
            {
                //conexion.Open();
                return Convert.ToInt32(objCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static DataTable ObtenerFechas(Entidades.Ejercicio pEjercicio, bool pFechaEmision) {
            DataTable dt = new DataTable();
            strProc = "SP_ASIENTOS_FECHAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pEjercicio.FechaInicio.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pEjercicio.FechaFinal.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@PorFechaEmision", pFechaEmision);
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

        public static void Ordenar(Entidades.Ejercicio pEjercicio, bool pFechaEmision) {
            strProc = "SP_ASIENTOS_ORDENAR";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@FechaInicio", pEjercicio.FechaInicio);
            objCommand.Parameters.AddWithValue("@FechaFin", pEjercicio.FechaFinal);
            objCommand.Parameters.AddWithValue("@PorFechaEmision", pFechaEmision);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
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
        }

        public static DataTable Obtener(DateTime pDesde, DateTime pHasta, bool pFechaEmision)
        {
            DataTable dt = new DataTable();
            strProc = "SP_ASIENTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@PorFechaEmision", pFechaEmision);
            try
            {
                dt.TableName = "dsAsientos";
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

        public static DataTable SumaYSaldo(DateTime pDesde, DateTime pHasta, bool pPorFechaEmision)
        {
            DataTable dt = new DataTable();
            strProc = "SP_SUMAYSALDO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@PorFechaEmision", pPorFechaEmision);
            try
            {
                dt.TableName = "dsSumaYSaldo";
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

        public static DataTable LibroMayor(DateTime pDesde, DateTime pHasta, DateTime pFechaInicioEjercicio, Int64 codigoCuentaContable, bool pPorFechaEmision)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MAYOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaInicioEjercicio", pFechaInicioEjercicio.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaContable", codigoCuentaContable);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@PorFechaEmision", pPorFechaEmision);
            try
            {
                dt.TableName = "dsLibroMayor";
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

        public static DataTable AsientosFacturas(int pCodigoCierrecaja, string pTipoDoc, Entidades.PuestoCaja pPuestoCaja) {
            DataTable dt = new DataTable();
            strProc = "SP_ASIENTOSFACTURASAAGRUPAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierrecaja);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoDoc", pTipoDoc);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
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

        public static DataTable AsientosFacturasCompras(int pCodigoCierrecaja, string pTipoDoc, Entidades.PuestoCaja pPuestoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_ASIENTOSFACTURASCOMPRASAAGRUPAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierrecaja);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoDoc", pTipoDoc);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
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


        public static DataTable AsientosPagosClientes(int pCodigoCierrecaja, string pTipoDoc, Entidades.PuestoCaja pPuestoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_ASIENTOSPAGOSCLIENTESAAGRUPAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierrecaja);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoDoc", pTipoDoc);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
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

        public static DataTable AsientosPagosProveedores(int pCodigoCierrecaja, string pTipoDoc, Entidades.PuestoCaja pPuestoCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_ASIENTOSPAGOSPROVEEDORESAAGRUPAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierrecaja);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoDoc", pTipoDoc);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
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

        public static int AgregarAgrupadas(Entidades.Asiento pAsiento)
        {
            //Creo objeto conexion
            strProc = "SP_ASIENTOSAGRUPADOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);

            
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@Fecha", pAsiento.Fecha);
            objCommand.Parameters.AddWithValue("@Descripcion", pAsiento.Descripcion);

            DataTable dtDetalle = new DataTable();
            DataColumn column;
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Renglon";
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
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoCheque";
            dtDetalle.Columns.Add(column);

            int contador = 1;
            foreach (Entidades.Asiento_Detalle ad in pAsiento.Detalle)
            {
                dtDetalle.Rows.Add(contador++, ad.CuentaContable.Codigo, ad.Debe, ad.Haber);
            }


            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalles";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDetalle;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);


            try
            {
                //conexion.Open();
                objConexion.Open();
                return Convert.ToInt32(objCommand.ExecuteScalar());
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

        }

        public static void BorrarAsientosAgrupados(/*int pCodigoAsiento*/) {
            strProc = "SP_ASIENTOSAGRUPADOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
           // objCommand.Parameters.AddWithValue("@CodigoAsientoFinal", pCodigoAsiento);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
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
        }
        

    }
}
