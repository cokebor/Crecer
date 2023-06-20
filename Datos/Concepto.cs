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
    public static class Concepto
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc=string.Empty;
        static Concepto()
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
        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CONCEPTOS_SELECT";
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
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            
            return dt;
        }
        public static DataTable ObtenerActivos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CONCEPTOS_SELECT_ACTIVOS";
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
        public static Entidades.Concepto ObtenerUno(int pCodigoConcepto)
        {
            Entidades.Concepto objConcepto = new Entidades.Concepto();
            strProc = "SP_CONCEPTOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoConcepto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objConcepto.Codigo= Convert.ToInt32(objDataReader["Codigo"]);
                objConcepto.Descripcion = objDataReader["Descripcion"].ToString();
                objConcepto.Impuesto = Convert.ToBoolean(objDataReader["EsImpuesto"].ToString());
                Enumeraciones.Enumeraciones.Estados estado;
                
                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objConcepto.Estado = estado;

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
            return objConcepto;
        }

        public static void Agregar(Entidades.Concepto pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_CONCEPTOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pConcepto.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pConcepto.Descripcion);
            objCommand.Parameters.AddWithValue("@EsImpuesto", pConcepto.Impuesto);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex) {
                if (sqlex.Number == 2601) {
                    throw new Exception("No se pude agregar Concepto, ya existe!!");
                }
                throw new Exception(sqlex.Message);
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
        public static void Eliminar(Entidades.Concepto pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_CONCEPTOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pConcepto.Codigo);
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


        public static void EliminarCuentasAsociadas(Entidades.Concepto pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_CONCEPTOSASOCIADOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoConcepto", pConcepto.Codigo);
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
    }
}
