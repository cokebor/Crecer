using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosVillaMaria
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
                objConexion = new SqlConnection(BaseDatos.StringConexionVillaMaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        public static DataTable ObtenerPorLote(DateTime pDesde, DateTime pHasta, Entidades.Lote pLote, Entidades.RubroProducto pRubro, Entidades.Producto pProducto)
        {
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


    }
}
