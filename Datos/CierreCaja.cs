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
    public static class CierreCaja
    {
        private static SqlConnection objConexion = null;
        private static string strProc = string.Empty;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static CierreCaja()
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

        public static int Agregar(Entidades.CierreDeCaja pCierreCaja)
        {
            //Creo objeto conexion
            strProc = "SP_CIERRESDECAJA_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@FechaCierre", pCierreCaja.FechaCierreCaja);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", pCierreCaja.PuestoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCierreCaja.Usuario.Codigo);


            try
            {
                objConexion.Open();
                int res = Convert.ToInt32(objCommand.ExecuteScalar());
                return res;
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Cierre de Caja, ya existe!!");
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

        public static DataTable ObtenerTodos(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CIERRESDECAJA_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pHasta);
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

        public static DataTable ObtenerEfectivo(int pCodigo, string pMoneda, string nombreTabla)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MOVIMIENTOS_EFECTIVO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Moneda", pMoneda);

            try
            {
                dt.TableName = nombreTabla;
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

        public static DataTable ObtenerCheques(int pCodigo, string pMovimiento, string nombreTabla)
        {
            DataTable dt = new DataTable();
            strProc = "SP_MOVIMIENTOS_CHEQUES";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Movimiento", pMovimiento);

            try
            {
                dt.TableName = nombreTabla;
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

        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CIERRESDECAJATODOS_SELECT";
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

        public static DataTable ObtenerCierresPendientes()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CIERRESDECAJAPENDIENTES_SELECT";
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
        public static DataTable ObtenerCajasPasadas(Entidades.Sucursal pSucursal)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CAJASPASADAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoSucursal", pSucursal.Codigo);
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

        public static DateTime ObtenerFecha(int pCodigoCierreCaja)
        {
            strProc = "SP_CIERRECAJA_FECHA_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierreCaja);
            try
            {
                objConexion.Open();
                DateTime res = Convert.ToDateTime(objCommand.ExecuteScalar());
                return res;
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
        public static Entidades.CierreDeCaja ObtenerUno(Entidades.CierreDeCaja objECierre)
        {
            strProc = "SP_CIERREDECAJA_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCierreCaja", objECierre.Codigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objECierre.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objECierre.FechaApertura = Convert.ToDateTime(objDataReader["FechaApertura"]);
                    objECierre.FechaCierreCaja = Convert.ToDateTime(objDataReader["FechaCierre"]);
                    objECierre.Usuario.Codigo = Convert.ToInt32(objDataReader["CodigoUsuario"]);
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
            return objECierre;
        }

        public static double ObtenerMontoEgreso(int pCodigoCierreCaja)
        {
            strProc = "SP_CAJA_EGRESOSUCURSALESCAJA_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCierreCaja", pCodigoCierreCaja);
            try
            {
                objConexion.Open();
                double res = Convert.ToDouble(objCommand.ExecuteScalar());
                return res;
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

        public static int ObtenerCantidadCajas()
        {
            strProc = "SP_CAJASCANTIDAD_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objConexion.Open();
                int res = Convert.ToInt32(objCommand.ExecuteScalar());
                return res;
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
