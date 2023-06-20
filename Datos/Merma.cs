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
    public static class Merma
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
     //   private static SqlDataReader objDataReader = null;
        static Merma()
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
        public static int Agregar(Entidades.Merma pMerma)
        {
            //Creo objeto conexion
            strProc = "SP_MERMAS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pMerma.Codigo);
            objCommand.Parameters.AddWithValue("@Fecha", pMerma.Fecha);
            objCommand.Parameters.AddWithValue("@NumDoc", pMerma.NumDoc);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pMerma.Usuario.Codigo);



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
            foreach (Entidades.Merma_D_Producto rpdp in pMerma.Productos)
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

        public static int ObtenerCantidad(Entidades.Lote pLote, DateTime pDesde, DateTime pHasta) {
            strProc = "SP_MERMAS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@IDLOTE", pLote.IdLote);
            objCommand.Parameters.AddWithValue("@Desde", pDesde);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta);
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

        public static DataTable ObtenerPorLote(DateTime pDesde, DateTime pHasta, Entidades.Lote pLote, Entidades.RubroProducto pRubro, Entidades.Producto pProducto) {
            DataTable dt = new DataTable();
            strProc = "SP_MERMAPORLOTE";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@IDLOTE", pLote.IdLote);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            try
            {
                dt.TableName = "dsMermas";
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

        public static int ObtenerMermasALiquidar(int pCodigo, int pCodigoProducto, int pLote, DateTime pHasta)
        {
            int  cant = 0;
            strProc = "SP_MERMASALIQUIDAR";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemitoProveedor", pCodigo);
            objCommand.Parameters.AddWithValue("@CodigoProducto", pCodigoProducto);
            objCommand.Parameters.AddWithValue("@Lote", pLote);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta);
            try
            {
                objConexion.Open();
                cant = Convert.ToInt32(objCommand.ExecuteScalar());
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
            return cant;
        }
    }
}
