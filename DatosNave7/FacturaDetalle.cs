using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosNave7
{
    public static class FacturaDetalle
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
       // private static SqlCommand objCommand = null;
       // private static SqlDataReader objDataReader = null;
        static FacturaDetalle()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionNave7);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ObtenerUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_DETALLES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsFacturaDetalle";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerDetalleLiquidacion(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESCLIENTES_DETALLE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoLiquidacion", pCodigoFactura);
            try
            {
                dt.TableName = "dsFacturaDetalle";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
    }
}
