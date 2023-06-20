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
    public static class Asiento
    {
        private static string strProc = string.Empty;
        private static SqlCommand objCommand = null;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;

        static Asiento()
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

      
        
        public static DataTable ObtenerFechas(Entidades.Ejercicio pEjercicio,bool pFechaEmision) {
            DataTable dt = new DataTable();
            strProc = "SP_ASIENTOS_FECHAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pEjercicio.FechaInicio.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pEjercicio.FechaFinal.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@PorFechaEmision", pFechaEmision);
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

        
        public static void Ordenar(Entidades.Ejercicio pEjercicio, bool pFechaEmision) {
            strProc = "SP_ASIENTOS_ORDENAR";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@FechaInicio", pEjercicio.FechaInicio);
            objCommand.Parameters.AddWithValue("@FechaFin", pEjercicio.FechaFinal);
            objCommand.Parameters.AddWithValue("@PorFechaEmision", pFechaEmision);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
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
        
        public static DataTable Obtener(DateTime pDesde, DateTime pHasta, bool pPorFechaEmision)
        {
            DataTable dt = new DataTable();
            strProc = "SP_ASIENTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@PorFechaEmision", pPorFechaEmision);
            try
            {
                dt.TableName = "dsAsientos";
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
        
        public static DataTable SumaYSaldo(DateTime pDesde, DateTime pHasta, bool pPorFechaEmision)
        {
            DataTable dt = new DataTable();
            strProc = "SP_SUMAYSALDO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@PorFechaEmision", pPorFechaEmision);
            try
            {
                dt.TableName = "dsSumaYSaldo";
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
        
        public static DataTable LibroMayor(DateTime pDesde, DateTime pHasta, DateTime pFechaInicioEjercicio, Int64 codigoCuentaContable, bool pPorFechaEmision)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MAYOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaInicioEjercicio", pFechaInicioEjercicio.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaContable", codigoCuentaContable);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@PorFechaEmision", pPorFechaEmision);
            try
            {
                dt.TableName = "dsLibroMayor";
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
