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
    public static class Impuesto
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static Impuesto()
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
            strProc = "SP_IMPUESTOS_SELECT";
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

        public static DataTable ObtenerTodosCompras()
        {
            DataTable dt = new DataTable();
            strProc = "SP_IMPUESTOSCOMPRAS_SELECT";
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

        public static DataTable ObtenerTodosVentas()
        {
            DataTable dt = new DataTable();
            strProc = "SP_IMPUESTOSVENTAS_SELECT";
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

        public static void Agregar(Entidades.Impuesto pImpuesto)
        {
            //Creo objeto conexion
            strProc = "SP_IMPUESTOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pImpuesto.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pImpuesto.Descripcion);
            objCommand.Parameters.AddWithValue("@Tipo", pImpuesto.Tipo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContable", pImpuesto.CuentaContable.Codigo);
            
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Impuesto, ya existe!!");
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

        public static DataTable ObtenerPercepciones(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PERCEPCIONES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsPercepciones";
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

        public static void Eliminar(Entidades.Impuesto pImpuesto)
        {
            //Creo objeto conexion
            strProc = "SP_IMPUESTOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pImpuesto.Codigo);
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

        public static Entidades.Impuesto ObtenerUno(int pCodigo)
        {
            Entidades.Impuesto objImpuesto = new Entidades.Impuesto();
            strProc = "SP_IMPUESTOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objImpuesto = null;
                }
                else
                {
                    objImpuesto.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objImpuesto.Descripcion = objDataReader["Descripcion"].ToString();
                    objImpuesto.CuentaContable.Codigo = Convert.ToInt64(objDataReader["CodigoCuentaContable"]);
                    objImpuesto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
                }
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
            return objImpuesto;
        }

        public static Entidades.Impuesto ObtenerUnoActivo(int pCodigo)
        {
            Entidades.Impuesto objImpuesto = new Entidades.Impuesto();
            strProc = "SP_IMPUESTOS_SELECT_UNO_ACTIVO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objImpuesto = null;
                }
                else
                {
                    objImpuesto.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objImpuesto.Descripcion = objDataReader["Descripcion"].ToString();
                    objImpuesto.CuentaContable.Codigo = Convert.ToInt32(objDataReader["CodigoCuentaContable"]);
                    objImpuesto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
                }

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
            return objImpuesto;

        }

        public static Entidades.Impuesto ObtenerUnoCompraActivo(int pCodigo)
        {
            Entidades.Impuesto objImpuesto = new Entidades.Impuesto();
            strProc = "SP_IMPUESTOSCOMPRAS_SELECT_UNO_ACTIVO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objImpuesto = null;
                }
                else
                {
                    objImpuesto.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objImpuesto.Descripcion = objDataReader["Descripcion"].ToString();
                    objImpuesto.CuentaContable.Codigo = Convert.ToInt32(objDataReader["CodigoCuentaContable"]);
                    objImpuesto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
                }

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
            return objImpuesto;

        }

        public static Entidades.Impuesto ObtenerUnoVentaActivo(int pCodigo)
        {
            Entidades.Impuesto objImpuesto = new Entidades.Impuesto();
            strProc = "SP_IMPUESTOSVENTAS_SELECT_UNO_ACTIVO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objImpuesto = null;
                }
                else
                {
                    objImpuesto.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objImpuesto.Descripcion = objDataReader["Descripcion"].ToString();
                    objImpuesto.CuentaContable.Codigo = Convert.ToInt64(objDataReader["CodigoCuentaContable"]);
                    objImpuesto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
                }

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
            return objImpuesto;

        }
        public static DataTable ObtenerRetencionesPercepciones(Int64 pCodigoCuentaContable)//, int pCodigoImpuesto)
        {
            DataTable dt = new DataTable();
            strProc = "SP_RETPERCPAGOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaContable", pCodigoCuentaContable);
            //objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoImpuesto", pCodigoImpuesto);

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
