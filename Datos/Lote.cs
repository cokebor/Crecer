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
    public static class Lote
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
        static Lote()
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

        public static Entidades.Lote ObtenerUno(int pLote)
        {
            Entidades.Lote objLote = new Entidades.Lote();
            strProc = "SP_LOTES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Lote", pLote);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objLote = null;
                }
                else
                {
                    objLote.IdLote = Convert.ToInt32(objDataReader["Lote"]);
                    objLote.Proveedor.Codigo= Convert.ToInt32(objDataReader["CodigoProveedor"]);
                    objLote.Proveedor.Nombre= objDataReader["Proveedor"].ToString();
                    objLote.Producto.Codigo= Convert.ToInt32(objDataReader["CodigoProducto"]);
                    objLote.Producto.Descripcion = objDataReader["Producto"].ToString();
                    objLote.Stock = Convert.ToInt32(objDataReader["Stock"]);
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
            return objLote;
        }

        public static Entidades.Lote ObtenerUno(int pLote, int pCantidad)
        {
            Entidades.Lote objLote = new Entidades.Lote();
            strProc = "SP_LOTES_SELECT_UNO2";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Lote", pLote);
            objCommand.Parameters.AddWithValue("@Cantidad", pCantidad);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objLote = null;
                }
                else
                {
                    objLote.IdLote = Convert.ToInt32(objDataReader["Lote"]);
                    objLote.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);
                    objLote.Proveedor.Nombre = objDataReader["Proveedor"].ToString();
                    objLote.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                    objLote.Producto.Descripcion = objDataReader["Producto"].ToString();
                    objLote.Stock = Convert.ToInt32(objDataReader["Stock"]);
                    objLote.PrecioUnitario = Convert.ToDouble(objDataReader["PrecioUnitario"]);
                  //  objLote.DTVe= objDataReader["DTVE"].ToString();
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
            return objLote;
        }

        public static DataTable ObtenerTodosPorProducto(Entidades.Producto pProducto)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LOTESPORPRODUCTO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodioProducto", pProducto.Codigo);
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

        public static DataTable ObtenerStockPorCanal(Entidades.Proveedor pProveedor, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote, Entidades.Canal pCanal)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LOTESSALDOPORCANAL_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRubroProducto", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoLote", pLote.IdLote);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCanal", pCanal.Codigo);
            try
            {
                dt.TableName = "dsStockPorCanal";
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

        public static Entidades.Lote ObtenerIngreso(int pLote)
        {
            Entidades.Lote objLote = new Entidades.Lote();
            strProc = "SP_INGRESOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Lote", pLote);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objLote = null;
                }
                else
                {
                    objLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                    objLote.Stock = Convert.ToInt32(objDataReader["Ingreso"]);
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
            return objLote;
        }
    }
}
