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
    public static class RemitoCliente
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static RemitoCliente()
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
        public static int Agregar(Entidades.RemitoCliente_M pRemito)
        {
            //Creo objeto conexion
            strProc = "SP_REMITOCLIENTE_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pRemito.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoRemitoCliente", pRemito.TipoRemitoCliente.Codigo);
            objCommand.Parameters.AddWithValue("@NumRemito", pRemito.NumRemito);
            objCommand.Parameters.AddWithValue("@Fecha", pRemito.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoCliente", pRemito.Cliente.Codigo);
            

            DataTable dtProductos=new DataTable();
            DataColumn column;
            column= new DataColumn(); ;
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
            column.ColumnName = "IdLoteViejo";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "IdLoteNuevo";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoMovStock";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Contador";
            dtProductos.Columns.Add(column);

            int contador = 1;
            foreach (Entidades.RemitoCliente_D_Producto rpdp in pRemito.Productos) {
                dtProductos.Rows.Add(rpdp.Renglon, rpdp.Producto.Codigo, rpdp.Movstock_Lotes.Cantidad, rpdp.Movstock_Lotes.IdLote.IdLote, rpdp.LoteNuevo.IdLote,rpdp.Movstock_Lotes.Codigo, contador);
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
                //objCommand.ExecuteNonQuery();
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

        public static DataTable ObtenerTodos(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOCLIENTE_M_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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

        public static DataTable ObtenerTodosSinLiquidar(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOCLIENTE_SINLIQUIDAR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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

        public static DataTable ObtenerTodosPorFecha(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOCLIENTE_M_SELECT_POR_FECHA";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta);
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

        public static Entidades.RemitoCliente_M ObtenerUno(int pCodigoRemito)
        {
            Entidades.RemitoCliente_M objRemito = new Entidades.RemitoCliente_M();
            strProc = "SP_REMITOCLIENTE_M_SELECT_UNO";
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
                    objRemito.TipoRemitoCliente.Codigo = Convert.ToInt32(objDataReader["CodigoTipoRemitoCliente"]);
                    objRemito.NumRemito = objDataReader["NumRemito"].ToString();
                    objRemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objRemito.Cliente.Codigo = Convert.ToInt32(objDataReader["CodigoCliente"]);
                    
                    objRemito.Productos = RemitoCliente_D_Productos.ObtenerTodos(objRemito.Codigo);

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

        public static Entidades.RemitoCliente_M ObtenerUnoParaLiquidar(int pCodigoRemito)
        {
            Entidades.RemitoCliente_M objRemito = new Entidades.RemitoCliente_M();
            strProc = "SP_REMITOCLIENTE_M_SELECT_UNO";
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
                    objRemito.TipoRemitoCliente.Codigo = Convert.ToInt32(objDataReader["CodigoTipoRemitoCliente"]);
                    objRemito.NumRemito = objDataReader["NumRemito"].ToString();
                    objRemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objRemito.Cliente.Codigo = Convert.ToInt32(objDataReader["CodigoCliente"]);

                    objRemito.Productos = RemitoCliente_D_Productos.ObtenerTodosParaLiquidar(objRemito.Codigo);

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

        public static DataTable ObtenerDataTable(int pCodigoRemito)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOCLIENTE_M_SELECT_UNO";
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

        public static void Eliminar(Entidades.RemitoCliente_M pRemito)
        {
            //Creo objeto conexion
            strProc = "SP_REMITOCLIENTE_DELETE";
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

        public static DataTable ObtenerTodosDataTable(DateTime desde, DateTime hasta, Entidades.Cliente pCliente, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOCLIENTE_INFORMES";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", desde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", hasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodLote", pLote.IdLote);
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

        public static DataTable ObtenerTodosPorClienteParaLiquidar(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOCLIENTE_PRODUCTOS_PARALIQUIDARINFORME_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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
