using System;
using Entidades;
using System.Data.SqlClient;
using Servidor;
using System.Data;
using System.Collections.Generic;

namespace Datos
{
    public static class ConceptosAsociadosASueldos
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static ConceptosAsociadosASueldos()
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

        public static int Agregar(Entidades.ConceptoAsociadoASueldo pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_CONCEPTOSASOCIADOSASUELDOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoConcepto", pConcepto.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pConcepto.Descripcion);
            objCommand.Parameters.AddWithValue("@TipoMonto", pConcepto.TipoMonto);
            objCommand.Parameters.AddWithValue("@Valor", pConcepto.Valor);
            //objCommand.Parameters.AddWithValue("@Estado", pConcepto.Estado);
            try
            {
                objConexion.Open();
                //objCommand.ExecuteNonQuery();
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
        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CONCEPTOSASOCIADOSASUELDOS_SELECT";
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

        public static DataTable ObtenerActivos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CONCEPTOSASOCIADOSASUELDOS_SELECT_ACTIVOS";
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

        public static Entidades.ConceptoAsociadoASueldo ObtenerUno(int pCodigoConcepto)
        {
            Entidades.ConceptoAsociadoASueldo objConcepto = new Entidades.ConceptoAsociadoASueldo();
            strProc = "SP_CONCEPTOSASOCIADOSASUELDOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoConcepto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objConcepto.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objConcepto.Descripcion = objDataReader["Descripcion"].ToString();
                objConcepto.TipoMonto = Convert.ToChar(objDataReader["TipoMonto"].ToString());
                objConcepto.Valor = Convert.ToDouble(objDataReader["Valor"].ToString());
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
        public static void Eliminar(Entidades.ConceptoAsociadoASueldo pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_CONCEPTOSASOCIADOSASUELDOS_DELETE";
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
        public static void NoRemunerativoActualizar(Entidades.ConceptoAsociadoASueldo pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_CONCEPTOSASOCIADOSASUELDOS_UPDATE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pConcepto.Codigo);
            objCommand.Parameters.AddWithValue("@Valor", pConcepto.Valor);
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