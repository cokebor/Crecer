using MySql.Data.MySqlClient;
using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosWeb
{
    public static class CuentaBancaria
    {
        private static string strProc = string.Empty;

        private static MySqlConnection objConexion = null;
        private static MySqlCommand objCommand = null;
        private static MySqlDataAdapter objDataAdapter = null;
        static CuentaBancaria()
        {
            try
            {
                objConexion = new MySqlConnection(BaseDatos.StringConexionWeb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Agregar(Entidades.CuentaBancaria pCuentaBancaria, Entidades.Empresa pEmpresa)
        {
            //Creo objeto conexion
            strProc = "SP_CUENTASBANCARIAS_INSERT_WEB";
            objCommand = new MySqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGOPUESTO", pEmpresa.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTABANCARIA", pCuentaBancaria.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOBANCO", pCuentaBancaria.Banco.Codigo);
            objCommand.Parameters.AddWithValue("@NUMEROCUENTA", pCuentaBancaria.NumeroCuenta);
            objCommand.Parameters.AddWithValue("@CODIGOMONEDA", pCuentaBancaria.Moneda.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTACONTABLE", pCuentaBancaria.CuentaContable.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTACONTABLEVALORESDIFERIDOS", pCuentaBancaria.CuentaContableValoresDiferidos.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTACONTABLETRANFERENCIAS", pCuentaBancaria.CuentaContableTranferencias.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTACONTABLEPRESTAMOS", pCuentaBancaria.CuentaContablePrestamos.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOCUENTACONTABLEDEBITOCREDITOCOMPRAS", pCuentaBancaria.CuentaContableDebitoCreditoCompras.Codigo);
            objCommand.Parameters.AddWithValue("@FECHACONCILIACION", pCuentaBancaria.FechaConciliacion);
            objCommand.Parameters.AddWithValue("@CODIGOPROVEEDOR", pCuentaBancaria.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@TRANFERENCIA", pCuentaBancaria.Tranferencia);
            objCommand.Parameters.AddWithValue("@DEBITOCREDITO", pCuentaBancaria.DebitoCredito);
            objCommand.Parameters.AddWithValue("@DEBITOCREDITOCOMPRAS", pCuentaBancaria.DebitoCreditoCompras);

            objCommand.Parameters.AddWithValue("@ESTADO", (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(pCuentaBancaria.Estado));

            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (MySqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Cuenta Bancaria, ya existe!!");
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
        
        public static DataTable ObtenerNovedades(int pCodigoNovedad, Entidades.Empresa pEmpresa)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CUENTASBANCARIAS_SELECT_NOVEDADES";
            objDataAdapter = new MySqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoNovedad);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoP", pEmpresa.Codigo);
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (MySqlException ex)
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
