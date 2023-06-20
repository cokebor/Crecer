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
    public static class Impuesto
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        static Impuesto()
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

        public static DataTable ObtenerRetenciones(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_RETENCIONES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsRetenciones";
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

        public static DataTable ObtenerFechas()
        {
            DataTable dt = new DataTable();
            strProc = "SP_IMPUESTOS_FECHAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        public static DataTable ObtenerRetencionesPercepciones(Int64 pCodigoCuentaContable)//, int pCodigoRetencionAsociado)
        {
            DataTable dt = new DataTable();
            strProc = "SP_RETPERCPAGOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaContable", pCodigoCuentaContable);
            //objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoImpuesto", pCodigoRetencionAsociado);

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
