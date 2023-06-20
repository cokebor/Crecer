using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRioCuarto
{
    public class MovStock_Lote
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
      //  private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        //   private static SqlDataReader objDataReader = null;
        static MovStock_Lote()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionRioCuarto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
    }
}
