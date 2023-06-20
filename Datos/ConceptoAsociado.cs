using System;
using Entidades;
using System.Data.SqlClient;
using Servidor;
using System.Data;
using System.Collections.Generic;

namespace Datos
{
    public static class ConceptoAsociado
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static ConceptoAsociado()
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
            strProc = "SP_CONCEPTOSASOCIACIONES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoConcepto", pConcepto.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pConcepto.Usuario.Codigo);
            Entidades.ConceptoAsociado conAsociado = pConcepto.ConceptosAsociados[0];
            objCommand.Parameters.AddWithValue("@CodigoAsociacion", conAsociado.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContable", conAsociado.CuentaContable.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", conAsociado.Descripcion);
            objCommand.Parameters.AddWithValue("@DebeOHaber", conAsociado.DebeOHaber);
            objCommand.Parameters.AddWithValue("@MostrarEnPago", conAsociado.MostrarEnPago);
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
            strProc = "SP_CONCEPTOSASOCIADOS_SELECT";
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
            strProc = "SP_CONCEPTOSASOCIADOS_SELECT_ACTIVOS";
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
        public static DataTable ObtenerAsociacionesActivasParaPagos(Entidades.Concepto pConcepto)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CONCEPTOSASOCIADOSAPAGOS_SELECT_ACTIVOS";
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
        public static void Eliminar(Entidades.ConceptoAsociado pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_CONCEPTOASOCIACION_DELETE";
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
        public static Entidades.ConceptoAsociado ObtenerUno(int pCodigoConceptoAsociado)
        {
            Entidades.ConceptoAsociado objConcepto = new Entidades.ConceptoAsociado();
            strProc = "SP_CUENTASASOCIADAS_SELECT_UNO";
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
        public static double ObtenerMontoUno(int pCodigoDevengamiento, int pCodigoConcepto)
        {
            //Entidades.ConceptoAsociadoASueldo objConcepto = new Entidades.ConceptoAsociadoASueldo();
            double monto;
            strProc = "SP_DEVENGAMIENTODETALLE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoDevengamiento", pCodigoDevengamiento);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTAASOCIADA", pCodigoConcepto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                //monto = Convert.ToDouble(objDataReader["Monto"]);
                monto = Convert.ToDouble(objDataReader["Saldo"]);

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
        /*
        public static void Agregar(Entidades.ConceptoAsociadoASueldo pConcepto)
        {
            strProc = "SP_CUENTASASOCIADASASUELDOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pConcepto.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pConcepto.Descripcion);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContable", pConcepto.CuentaContable.Codigo);
            objCommand.Parameters.AddWithValue("@DebeOHaber", pConcepto.DebeOHaber);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
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
        public static void Eliminar(Entidades.ConceptoAsociadoASueldo pConcepto)
        {
            //Creo objeto conexion
            strProc = "SP_CUENTASASOCIADASASUELDOS_DELETE";
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
        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CUENTASASOCIADASASUELDOS_SELECT";
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
            strProc = "SP_CUENTASASOCIADOSASUELDOS_SELECT_UNO";
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
                objConcepto.CuentaContable.Codigo = Convert.ToInt32(objDataReader["CodigoCuentaContable"].ToString());
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
        public static int ObtenerUno(int pCodigoSalario,int pCodigoConcepto)
        {
            //Entidades.ConceptoAsociadoASueldo objConcepto = new Entidades.ConceptoAsociadoASueldo();
            int renglon;
            strProc = "SP_SALARIOSDETALLE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSalario", pCodigoSalario);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTAASOCIADA", pCodigoConcepto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                renglon = Convert.ToInt32(objDataReader["Renglon"]);

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
            return renglon;
        }
        public static double ObtenerMontoUno(int pCodigoSalario, int pCodigoConcepto)
        {
            //Entidades.ConceptoAsociadoASueldo objConcepto = new Entidades.ConceptoAsociadoASueldo();
            double monto;
            strProc = "SP_SALARIOSDETALLE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSalario", pCodigoSalario);
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
        }*/
    }
}