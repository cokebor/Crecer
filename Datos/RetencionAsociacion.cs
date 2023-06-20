using System;
using Entidades;
using System.Data.SqlClient;
using Servidor;
using System.Data;
using System.Collections.Generic;

namespace Datos
{
    public static class RetencionAsociacion
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static RetencionAsociacion()
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
        public static int Agregar(Entidades.Concepto pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_RETENCIONESASOCIACIONES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoConcepto", pConcepto.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pConcepto.Usuario.Codigo);
            Entidades.RetencionAsociado retAsociado = pConcepto.RetencionesAsociados[0];
            objCommand.Parameters.AddWithValue("@CodigoAsociacion", retAsociado.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContable", retAsociado.CuentaContable.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", retAsociado.Descripcion);
            objCommand.Parameters.AddWithValue("@DebeOHaber", retAsociado.DebeOHaber);
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
        public static DataTable ObtenerAsociaciones(Entidades.Concepto pConcepto)
        {
            DataTable dt = new DataTable();
            strProc = "SP_RETENCIONESASOCIADOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoConcepto", pConcepto.Codigo);
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
        public static DataTable ObtenerAsociacionesActivas(Entidades.Concepto pConcepto)
        {
            DataTable dt = new DataTable();
            strProc = "SP_RETENCIONESASOCIACIONES_SELECT_ACTIVOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoConcepto", pConcepto.Codigo);
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
        public static void Eliminar(Entidades.RetencionAsociado pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_RETENCIONESASOCIACION_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoAsociacion", pConcepto.Codigo);
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
        public static Entidades.RetencionAsociado ObtenerUno(int pCodigoConceptoAsociado)
        {
            Entidades.RetencionAsociado objConcepto = new Entidades.RetencionAsociado();
            strProc = "SP_RETENCIONESASOCIADAS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoConceptoAsociado);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objConcepto.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objConcepto.Descripcion = objDataReader["Descripcion"].ToString();
                objConcepto.CuentaContable.Codigo = Convert.ToInt64(objDataReader["CodigoCuentaContable"].ToString());
                objConcepto.DebeOHaber = Convert.ToChar(objDataReader["DebeOHaber"]);

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
        public static double ObtenerMontoUno(int pCodigoSalario, int pCodigoConcepto)
        {
            //Entidades.ConceptoAsociadoASueldo objConcepto = new Entidades.ConceptoAsociadoASueldo();
            double monto;
            strProc = "SP_DEVENGAMIENTODETALLE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoDevengamiento", pCodigoSalario);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTAASOCIADA", pCodigoConcepto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                monto = Convert.ToDouble(objDataReader["Monto"]);

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
            return monto;
        }
       
    }
}