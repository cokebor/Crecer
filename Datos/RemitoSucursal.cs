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
    public static class RemitoSucursal
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static RemitoSucursal()
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
        public static int Agregar(Entidades.RemitoSucursal_M pRemito)
        {
            //Creo objeto conexion
            strProc = "SP_REMITOSUCURSALENVIO_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pRemito.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoRemitoSucursal", pRemito.TipoRemitoSucursal.Codigo);
           // objCommand.Parameters.AddWithValue("@Fecha", pRemito.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoSucursalOrigen", pRemito.SucursalOrigen.Codigo);
            //objCommand.Parameters.AddWithValue("@NumRemito", pRemito.NumRemito);
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pRemito.SucursalDestino.Codigo);



            DataTable dtProductos = new DataTable();
            DataColumn column;
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Renglon";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoProducto";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Cantidad";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "IdLote";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);

            int contador = 1;
            foreach (Entidades.RemitoSucursal_D_Producto rpdp in pRemito.Productos)
            {
                dtProductos.Rows.Add(rpdp.Renglon, rpdp.Producto.Codigo, rpdp.Movstock_Lotes.Cantidad, rpdp.Movstock_Lotes.IdLote.IdLote, contador);
                contador++;
            }


            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@ItemsNuevo";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);


            try
            {
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

        public static int ObtenerCodigoRemito(string pNumRemito) {
            DataTable dt = new DataTable();
            strProc = "SP_OBTENERCODIGOREMITO_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@NUMREMITO", pNumRemito);

                        
            int res=0;

            try
            {

                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(true))
                {
                    res = Convert.ToInt32(objDataReader["Codigo"]);
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

        public static void Eliminar(int pCodigoRemito, int pRenglonDesde)
        {
            //Creo objeto conexion
            strProc = "SP_ELIMINARRENGLON_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemito", pCodigoRemito);
            objCommand.Parameters.AddWithValue("@Renglon", pRenglonDesde);
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


        public static DataTable ObtenerDataTable(int pCodigoRemito)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOSUCURSAL_M_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoRemito);

            try
            {
                dt.TableName = "DataSet2";
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

        public static DataTable ObtenerEnviosProductosConSucursales(DateTime pDesde, DateTime pHasta, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, bool pRubrosSeleccionados)
        {
            DataTable dt = new DataTable();
            strProc = "SP_ENVIOSPRODUCTOSCONSUCURSALES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@RubrosSeleccionados", pRubrosSeleccionados);

            try
            {
                dt.TableName = "EnviosProductosConSucursales";
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

        public static int ObtenerCantidadFechas(DateTime pDesde, DateTime pHasta, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, bool pRubrosSeleccionados)
        {
            
            strProc = "SP_ENVIOSPRODUCTOSCONSUCURSALESCANTFECHAS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Desde", pDesde);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objCommand.Parameters.AddWithValue("@CodigoRubro", pRubro.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objCommand.Parameters.AddWithValue("@RubrosSeleccionados", pRubrosSeleccionados);

            try
            {
                objConexion.Open();
                return Convert.ToInt32(objCommand.ExecuteScalar());
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
        }

        public static DataTable ObtenerEnviosProductos(DateTime pDesde, DateTime pHasta, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, bool pRubrosSeleccionados)
        {
            DataTable dt = new DataTable();
            strProc = "SP_ENVIOSPRODUCTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@RubrosSeleccionados", pRubrosSeleccionados);

            try
            {
                dt.TableName = "EnviosProductos";
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
        public static DataTable ObtenerNovedades()
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOSUCURSAL_SELECT_NOVEDADES";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public static void CambiarEstadoNovedad(Entidades.RemitoSucursal_M pRemito)
        {
            strProc = "SP_REMITOSUCURSAL_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@NumRemito", pRemito.NumRemito);
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

        public static void AgregarDeWeb(Entidades.RemitoSucursal_M pRemito)
        {
            //Creo objeto conexion
            strProc = "SP_REMITOSUCURSALRECIBIR_INSERT";
            
            SqlTransaction transaccion = null;
            //transaccion = objConexion.BeginTransaction("Remito");

            objCommand = new SqlCommand(strProc, objConexion);
            //objCommand.Transaction = transaccion;

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@Codigo", 0);
            objCommand.Parameters.AddWithValue("@CodigoTipoRemitoSucursal", 2);
            objCommand.Parameters.AddWithValue("@Fecha", pRemito.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoSucursalOrigen", pRemito.SucursalOrigen.Codigo);
            objCommand.Parameters.AddWithValue("@NumRemito", pRemito.NumRemito);
            objCommand.Parameters.AddWithValue("@CodigoSucursalDestino", pRemito.SucursalDestino.Codigo);

            DataTable dtProductos = new DataTable();
            DataColumn column;
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Renglon";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoProducto";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Cantidad";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "IdLote";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoProveedor";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoCanal";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);

            int contador = 1;
            foreach (Entidades.RemitoSucursal_D_Producto rpdp in pRemito.Productos)
            {
                dtProductos.Rows.Add(rpdp.Renglon, rpdp.Producto.Codigo, rpdp.Movstock_Lotes.Cantidad, rpdp.Movstock_Lotes.IdLote.IdLote,rpdp.Proveedor.Codigo, rpdp.Canal.Codigo, contador);
                contador++;
            }


            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@ItemsNuevo";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);

            try
            {
                /*
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;
                */
                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                objCommand.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (SqlException sqlex)
            {
                transaccion.Rollback();
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Remito, ya existe!!");
                }
                throw new Exception(sqlex.Message);
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

        //public static DataTable ObtenerTodosDataTable(DateTime desde, DateTime hasta, Entidades.Sucursal pSucursalOrigen, Entidades.Sucursal pSucursalDestino, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote, bool pEnviados, bool pRecibidos)
        public static DataTable ObtenerTodosDataTable(DateTime desde, DateTime hasta,  Entidades.Sucursal pSucursalDestino, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote, bool pEnviados, bool pRecibidos)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOSUCURSAL_INFORMES";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", desde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", hasta);
            //objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodSucursalOrigen", pSucursalOrigen.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodSucursalDestino", pSucursalDestino.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodLote", pLote.IdLote);
            int enviados=0;
            if (pEnviados)
                enviados = 1;
            int recibidos=0;
            if (pRecibidos)
                recibidos = 2;

            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Enviados", enviados);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Recibidos", recibidos);
            try
            {
                dt.TableName = "DataSet1";
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
