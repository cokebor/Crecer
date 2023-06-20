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
    public static class Cheque
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;

        private static string strProc = string.Empty;
        static Cheque()
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

        public static DataTable ObtenerEnCartera()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_ENCARTERA_SELECT";
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

        public static DataTable ObtenerRechazados()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_RECHAZADOS_SELECT";
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

        public static DataTable ObtenerEnProveedor(Entidades.Proveedor objProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_ENPROVEEDOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", objProveedor.Codigo);
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

        public static DataTable ObtenerUno(int pCodigoCheque)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoCheque);
            try
            {
                dt.TableName = "dsCheque";
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

        public static DataTable ObtenerTresMesesEnProveedor(Entidades.Proveedor objProveedor, Boolean ultimosTresMeses)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUESTRESMESES_ENPROVEEDOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", objProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@UltimosTresMeses", ultimosTresMeses);
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
        public static DataTable ObtenerChequesPorEstado(DateTime pDesde, DateTime pHasta, char pRango, string pTipoEstadoValor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_PORESTADO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Rango", pRango);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@EstadoValor", pTipoEstadoValor);
            try
            {
                dt.TableName = "dsCheques";
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

        public static DataTable ObtenerEnCartera(Entidades.Cliente objCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_ENCARTERAPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", objCliente.Codigo);
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

        public static DataTable ObtenerEnCarteraPorRemito(Entidades.Cliente objCliente, int pCodigoRecibo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_ENCARTERAPORCLIENTEYREMITO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", objCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRecibo", pCodigoRecibo);
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

        public static DataTable ObtenerEnProveedorPorRecibo(Entidades.Proveedor pProveedor, int pCodigoRecibo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_ENPROVEEDORPORPROVEEDORYRECIBO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRecibo", pCodigoRecibo);
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

        public static DataTable ObtenerADPorCierre(int pCodigo)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_AD_PORCIERRE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);
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

        public static DataTable ObtenerTodosLosMovimientos(int pCodigoCheque)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_LISTADO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCheque", pCodigoCheque);
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
        public static DataTable ObtenerTodosLosCheques(int pCodigoBanco, string pNroCheque, bool pDuplicados)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoBanco", pCodigoBanco);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@NroCheque", pNroCheque);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Duplicados", pDuplicados);
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


        public static DataTable ObtenerParaConciliacion(Entidades.CuentaBancaria objCuentaBancaria)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUES_CONCILIACION_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", objCuentaBancaria.Codigo);
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


        public static int ObtenerSiEstaConciliado(Entidades.Cheque objCheque)
        {
            strProc = "SP_CHEQUECONCILIADO_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCheque", objCheque.Codigo);

            try
            {
                objConexion.Open();
                return Convert.ToInt32(objCommand.ExecuteScalar());
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
        }

        public static DataTable ObtenerDeClientes(Entidades.Cliente objCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CHEQUESDECLIENTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", objCliente.Codigo);
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
