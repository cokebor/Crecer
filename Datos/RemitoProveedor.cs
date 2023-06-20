using Servidor;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public static class RemitoProveedor
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static RemitoProveedor()
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
        public static int Agregar(Entidades.RemitoProveedor_M pRemito)
        {
            //Creo objeto conexion
            strProc = "SP_REMITOPROVEEDOR_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pRemito.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pRemito.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoRemitoProveedor", pRemito.TipoRemitoProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pRemito.Fecha);
            objCommand.Parameters.AddWithValue("@FechaEmbarque", pRemito.FechaEmbarque);
            objCommand.Parameters.AddWithValue("@Provisorio", pRemito.Provisorio);
            objCommand.Parameters.AddWithValue("@NumRemito", pRemito.NumRemito);
//            objCommand.Parameters.AddWithValue("@DTVe", pRemito.DTVE);
            objCommand.Parameters.AddWithValue("@CodigoCanal", pRemito.Canal.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pRemito.Usuario.Codigo);
            //objComando.Parameters.AddWithValue("@Observaciones", pRemito.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoTransporte", pRemito.Transporte.Codigo);
            objCommand.Parameters.AddWithValue("@CantidadPallets", pRemito.Pallets);
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
            /*
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Descripcion";
            dtProductos.Columns.Add(column);*/

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
            column.ColumnName = "CodigoMovStock";
            dtProductos.Columns.Add(column);
            /*
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DTVe";
            dtProductos.Columns.Add(column);
            */
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);

            int contador = 1;
            foreach (Entidades.RemitoProveedor_D_Producto rpdp in pRemito.Productos)
            {
                dtProductos.Rows.Add(rpdp.Renglon, rpdp.Producto.Codigo, /*rpdp.Producto.Descripcion ,*/rpdp.MovStock_Lotes.Cantidad, rpdp.MovStock_Lotes.IdLote.IdLote, rpdp.MovStock_Lotes.Codigo/*,rpdp.MovStock_Lotes.IdLote.DTVe*/, contador);
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

        public static DataTable ObtenerRemitosSinFacturas(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOSSINFACTURASCOMPRAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static DataTable ObtenerTodos(Entidades.Proveedor pProveedor, bool ultimos6meses)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOPROVEEDOR_M_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Ultimos", ultimos6meses);
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
        public static DataTable ObtenerTodosDataTable(DateTime desde, DateTime hasta, Entidades.Proveedor pProveedor, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote, Entidades.Canal pCanal)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOPROVEEDOR_INFORMES";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", desde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", hasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodLote", pLote.IdLote);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodCanal", pCanal.Codigo);
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
        public static DataTable ObtenerCompraDirecta(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOPROVEEDOR_M_COMPRA_DIRECTA_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static DataTable ObtenerConsignacion(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOPROVEEDOR_M_CONSIGNACION_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static DataTable Obtener(int pCodigoRemito)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOPROVEEDOR_M_SELECT_UNO";
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
        public static Entidades.RemitoProveedor_M ObtenerUno(int pCodigoRemito)
        {
            Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            strProc = "SP_REMITOPROVEEDOR_M_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoRemito);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objRemito = null;
                }
                else
                {
                    objRemito.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objRemito.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);
                    objRemito.TipoRemitoProveedor.Codigo = Convert.ToInt32(objDataReader["CodigoTipoRemitoProveedor"]);
                    objRemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objRemito.FechaEmbarque = Convert.ToDateTime(objDataReader["FechaEmbarque"]);
                    objRemito.Provisorio = Convert.ToBoolean(objDataReader["Provisorio"]);
                    objRemito.NumRemito = objDataReader["NumRemito"].ToString();
                    //objRemito.DTVE = objDataReader["DTVE"].ToString();
                    objRemito.Canal.Codigo = Convert.ToInt32(objDataReader["CodigoCanal"]);
                    Entidades.Transporte objETransporte = new Entidades.Transporte();
                    objETransporte.Codigo = Convert.ToInt32(objDataReader["CodigoTransporte"]);
                    objRemito.Transporte = objETransporte;
                    objRemito.Pallets = Convert.ToInt32(objDataReader["CantidadPallets"]);

                    objRemito.Productos = RemitoProveedor_D_Productos.ObtenerTodos(objRemito.Codigo);

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
            return objRemito;
        }

        public static Entidades.RemitoProveedor_M ObtenerUnoParaFacturar(int pCodigoRemito)
        {
            Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            strProc = "SP_REMITOPROVEEDOR_M_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoRemito);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objRemito = null;
                }
                else
                {
                    objRemito.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objRemito.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);
                    objRemito.TipoRemitoProveedor.Codigo = Convert.ToInt32(objDataReader["CodigoTipoRemitoProveedor"]);
                    objRemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objRemito.Provisorio = Convert.ToBoolean(objDataReader["Provisorio"]);
                    objRemito.NumRemito = objDataReader["NumRemito"].ToString();
                    objRemito.Canal.Codigo = Convert.ToInt32(objDataReader["CodigoCanal"]);

                    objRemito.Productos = RemitoProveedor_D_Productos.ObtenerAlgunos(objRemito.Codigo);

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
            return objRemito;
        }
        public static void Eliminar(Entidades.RemitoProveedor_M pRemito)
        {
            //Creo objeto conexion
            strProc = "SP_REMITOPROVEEDOR_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pRemito.Codigo);
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

        public static bool ExisteFactura(Entidades.RemitoProveedor_M pRemito)
        {
            bool res = false;
            strProc = "SP_REMITOPROVEEDOR_FACTURACOMPRA_EXISTE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemito", pRemito.Codigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                res = Convert.ToBoolean(objDataReader["Existe"]);
                
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
        public static bool ExisteLiquidacion(Entidades.RemitoProveedor_M pRemito)
        {
            bool res = false;
            strProc = "SP_REMITOPROVEEDOR_LIQUIDACION_EXISTE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemito", pRemito.Codigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                res = Convert.ToBoolean(objDataReader["Existe"]);

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
        public static DataTable ObtenerTodosSinLiquidar(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOPROVEEDOR_SINLIQUIDAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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

        public static Entidades.RemitoProveedor_M ObtenerUnoParaLiquidar(int pCodigoRemito, Entidades.Empresa pEmpresa)
        {
            Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            strProc = "SP_REMITOPROVEEDOR_M_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoRemito);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objRemito = null;
                }
                else
                {
                    objRemito.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objRemito.TipoRemitoProveedor.Codigo = Convert.ToInt32(objDataReader["CodigoTipoRemitoProveedor"]);
                    objRemito.NumRemito = objDataReader["NumRemito"].ToString();
                    objRemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objRemito.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);


                    objRemito.Liquidar = RemitoProveedor_D_Productos.ObtenerTodosParaLiquidar(objRemito.Codigo, pEmpresa);
                   // objRemito.Productos = RemitoCliente_D_Productos.ObtenerTodosParaLiquidar(objRemito.Codigo);

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
            return objRemito;
        }

        public static double ObtenerPromedio(int pCodigo, int pCodigoProducto, int pLote, DateTime pHasta) {
            double promedio = 0;
            strProc = "SP_PRECIOPROMEDIO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemitoProveedor", pCodigo);
            objCommand.Parameters.AddWithValue("@CodigoProducto", pCodigoProducto);
            objCommand.Parameters.AddWithValue("@Lote", pLote);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta);
            try
            {
                objConexion.Open();
                promedio = Convert.ToDouble(objCommand.ExecuteScalar());
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
            return promedio;
        }

        public static double ObtenerCantidadALiquidar(int pCodigo, int pCodigoProducto, int pLote, DateTime pHasta)
        {
            double promedio = 0;
            strProc = "SP_CANTIDADALIQUIDAR";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemitoProveedor", pCodigo);
            objCommand.Parameters.AddWithValue("@CodigoProducto", pCodigoProducto);
            objCommand.Parameters.AddWithValue("@Lote", pLote);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta);
            try
            {
                objConexion.Open();
                promedio = Convert.ToDouble(objCommand.ExecuteScalar());
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
            return promedio;
        }

        public static DataTable ObtenerLiquidacionesPendientes(Entidades.Proveedor pProveedor, Entidades.Producto pProducto, DateTime pDesde, DateTime pHasta, Entidades.Empresa pEmpresa, Int16 pVendidasTotalmente)
       // public static DataTable ObtenerLiquidacionesPendientes(Entidades.Proveedor pProveedor, Entidades.Producto pProducto, DateTime pHasta, Entidades.Empresa pEmpresa)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONES_PROVEEDORES_SELECT_TODAS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoEmpresa", pEmpresa.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@VendidasTotalmente", pVendidasTotalmente);


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

        public static DataTable ObtenerLiquidacionesDeProveedoresPendientes(Entidades.Proveedor pProveedor, Entidades.Producto pProducto, DateTime pDesde, DateTime pHasta, Entidades.Empresa pEmpresa, bool pVendidasTotalmente)
        // public static DataTable ObtenerLiquidacionesPendientes(Entidades.Proveedor pProveedor, Entidades.Producto pProducto, DateTime pHasta, Entidades.Empresa pEmpresa)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONES_PROVEEDORES_SELECT_TODOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoEmpresa", pEmpresa.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@VendidasTotalmente", pVendidasTotalmente);


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