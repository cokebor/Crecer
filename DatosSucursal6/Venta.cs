using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSucursal6
{
    public static class Venta
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        //private static SqlCommand objCommand = null;
        //private static SqlDataReader objDataReader = null;

        static Venta()
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

        public static DataTable ObtenerTodosPorLote(Entidades.Lote pLote, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_VENTAPORLOTE";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@IDLOTE", pLote.IdLote);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
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
    }
}
