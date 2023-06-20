using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;
using Servidor;

namespace DatosSucursal6
{
    public static class Movimiento
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
     //   private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;

        static Movimiento()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionSucursal6);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      
        public static DataTable ObtenerTransferenciasSinCierre(Entidades.PuestoCaja pPuestoCaja, int pCodigoCierreCaja)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MOVIMIENTOS_TRANFERENCIASRECIBIDAS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierreCaja);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pPuestoCaja.Codigo);
            
            try
            {
                dt.TableName = "dsTransferenciasRecibidas";
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
