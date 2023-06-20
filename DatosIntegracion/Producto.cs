using Servidor;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DatosIntegracion
{
    public static class Producto
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        
        static Producto()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ObtenerVentasDetalladas(DateTime pDesde, DateTime pHasta, Entidades.Cliente pCliente, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote)
        {
            DataTable dt = new DataTable();
            strProc = "SP_VENTAPORPRODUCTOSDETALLADO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodLote", pLote.IdLote);
            try
            {
                dt.TableName = "dsVentas";
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

        public static DataTable ObtenerVentas(DateTime pDesde, DateTime pHasta, Entidades.Cliente pCliente, Entidades.RubroProducto pRubro, Entidades.Producto pProducto)
        {
            DataTable dt = new DataTable();
            strProc = "SP_VENTAPORPRODUCTOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodCliente", pCliente.Codigo);
            try
            {
                dt.TableName = "dsVentas";
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
