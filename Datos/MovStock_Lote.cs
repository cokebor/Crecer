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
    public static class MovStock_Lote
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
        static MovStock_Lote()
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

        public static DataTable ObtenerLotesSaldoPorProducto(int pCodigo, int pCantidad)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LOTESSALDOSPORPRODUCTO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pCodigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Cantidad", pCantidad);
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
        public static DataTable ObtenerLoteDeProducto(int pCodigo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LOTESDEPRODUCTO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pCodigo);
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

        public static DataTable ObtenerLotesSaldoPorProductoYProveedor(Entidades.Producto pProducto, Entidades.Proveedor pProveedor, int pCantidad)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LOTESSALDOSPORPRODUCTOYPROVEEDOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor",pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Cantidad", pCantidad);
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

        public static int VerSiExisteComprobante(int pLote)
        {
            int res = 0;
            strProc = "SP_EXISTENCIADECOMPROBANTE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@LOTE", pLote);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    res = 0;
                }
                else
                {
                    res = Convert.ToInt32(objDataReader["Resultado"]);
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
        public static int ObtenerMovStock(int pLote)
        {
            int res = 0;
            strProc = "SP_MOVSTOCK_LOTES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@LOTE", pLote);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    res = 0;
                }
                else
                {
                    res = Convert.ToInt32(objDataReader["CodigoMovStock"]);
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
        public static int CantidadDeMovimientosPorLote(Entidades.Lote pLote) {
            int res = 0;
            strProc = "SP_MOVIMIENTOSPORLOTE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@LOTE", pLote.IdLote);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    res = 0;
                }
                else
                {
                    res = Convert.ToInt32(objDataReader["CANTIDAD"]);
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

        public static DataTable ObtenerStockPorFecha(DateTime pHasta, Entidades.Canal pCanal)
        {
            DataTable dt = new DataTable();
            strProc = "SP_STOCKPORFECHA";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Canal", pCanal.Codigo);
            try
            {
                dt.TableName = "dsStock";
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

        public static DataTable ObtenerStockPorLotePuesto(Entidades.Producto pProducto, Entidades.Proveedor pProveedor, Entidades.Lote pLote)
        {
            DataTable dt = new DataTable();
            strProc = "SP_STOCKLOTEPUESTO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@IDLOTE", pLote.IdLote);
            try
            {
                dt.TableName = "dsStockPorLoteYPuesto";
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
        public static void Actualizar(Entidades.MovStock_Lotes pMovStock, Entidades.Usuario pUsuario)
        {
            //Creo objeto conexion
            strProc = "SP_MOVSTOCK_LOTES_UPDATE";
            Entidades.Lote A = new Entidades.Lote();
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoProducto", pMovStock.IdLote.Producto.Codigo);
            objCommand.Parameters.AddWithValue("@Lote", pMovStock.IdLote.IdLote);
            objCommand.Parameters.AddWithValue("@CodigoMovStock", pMovStock.Codigo);
            objCommand.Parameters.AddWithValue("@Cantidad", pMovStock.Cantidad);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pUsuario.Codigo);
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
