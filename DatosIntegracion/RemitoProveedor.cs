using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosIntegracion
{
    public static class RemitoProveedor
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        //private static SqlDataReader objDataReader = null;
        static RemitoProveedor()
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

        public static double ObtenerPromedio(int pCodigo, int pCodigoProducto, int pLote, DateTime pHasta)
        {
            double promedio = 0;
            strProc = "SP_PRECIOPROMEDIO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemitoProveedor", pCodigo);
            objCommand.Parameters.AddWithValue("@CodigoProducto", pCodigoProducto);
            objCommand.Parameters.AddWithValue("@Lote", pLote);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta);
            try
            {
                objConexion.Open();
                promedio = Convert.ToDouble(objCommand.ExecuteScalar());
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
            return promedio;
        }

        public static double ObtenerCantidadALiquidar(int pCodigo, int pCodigoProducto, int pLote, DateTime pHasta)
        {
            double promedio = 0;
            strProc = "SP_CANTIDADALIQUIDAR";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemitoProveedor", pCodigo);
            objCommand.Parameters.AddWithValue("@CodigoProducto", pCodigoProducto);
            objCommand.Parameters.AddWithValue("@Lote", pLote);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta);

            try
            {
                objConexion.Open();
                promedio = Convert.ToDouble(objCommand.ExecuteScalar());
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
            return promedio;
        }

        public static DataTable ObtenerVentas(int pCodigo, int pCodigoProducto, int pLote, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CANTIDADALIQUIDARVENTAS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRemitoProveedor", pCodigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pCodigoProducto);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Lote", pLote);
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
