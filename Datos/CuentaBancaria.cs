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
    public static class CuentaBancaria
    {
        private static SqlDataAdapter objDataAdapter = null;
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        static CuentaBancaria()
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
            strProc = "SP_CUENTASBANCARIAS_SELECT";
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

        public static void Agregar(Entidades.CuentaBancaria pCuenta)
        {
            //Creo objeto conexion
            strProc = "SP_CUENTASBANCARIAS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCuenta.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoBanco", pCuenta.Banco.Codigo);
            objCommand.Parameters.AddWithValue("@NumeroCuenta", pCuenta.NumeroCuenta);
            objCommand.Parameters.AddWithValue("@CodigoMoneda", pCuenta.Moneda.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContable", pCuenta.CuentaContable.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContableValoresDiferidos", pCuenta.CuentaContableValoresDiferidos.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContableTranferencias", pCuenta.CuentaContableTranferencias.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContablePrestamos", pCuenta.CuentaContablePrestamos.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContableDebitoCreditoCompras", pCuenta.CuentaContableDebitoCreditoCompras.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContablePayWay", pCuenta.CuentaContablePayWay.Codigo);
            objCommand.Parameters.AddWithValue("@Tranferencia", pCuenta.Tranferencia);
            objCommand.Parameters.AddWithValue("@DebitoCredito", pCuenta.DebitoCredito);
            objCommand.Parameters.AddWithValue("@DebitoCreditoCompras", pCuenta.DebitoCreditoCompras);
            objCommand.Parameters.AddWithValue("@PayWay", pCuenta.PayWay);
            objCommand.Parameters.AddWithValue("@FechaConciliacion", pCuenta.FechaConciliacion);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
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

        public static void Eliminar(Entidades.CuentaBancaria pCuenta)
        {
            //Creo objeto conexion
            strProc = "SP_CUENTASBANCARIAS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCuenta.Codigo);
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

        public static DataTable ObtenerDeBancos(Entidades.Banco pBanco)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CUENTASSBANCARIAS_DEBANCOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoBanco", pBanco.Codigo);
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

        public static DataTable ObtenerCuentasDebitoCreditoDeBancos(Entidades.Banco pBanco)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CUENTASSBANCARIASDEBITOCREDITO_DEBANCOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoBanco", pBanco.Codigo);
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

        public static DataTable ObtenerDeBancosParaTransferenciasClientes(Entidades.Banco pBanco)
        {
            DataTable dt = new DataTable();
            strProc = "SP_CUENTASSBANCARIAS_DEBANCOS_TRANSFERENCIASCLIENTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoBanco", pBanco.Codigo);
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
        public static Entidades.CuentaBancaria ObtenerUno(int pCodigo)
        {
            Entidades.CuentaBancaria objCuentaBancaria = new Entidades.CuentaBancaria();
            strProc = "SP_CUENTASBANCARIAS_SELECT_UNO";
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
                    objCuentaBancaria = null;
                }
                else
                {

                    objCuentaBancaria.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objCuentaBancaria.Banco.Codigo= Convert.ToInt32(objDataReader["CodigoBanco"]);
                    objCuentaBancaria.Banco.Descripcion = objDataReader["Banco"].ToString();
                    objCuentaBancaria.Moneda.Codigo = Convert.ToInt32(objDataReader["CodigoMoneda"]);
                    objCuentaBancaria.Moneda.Descripcion= objDataReader["Moneda"].ToString();
                    objCuentaBancaria.Moneda.Cotizacion= Convert.ToDouble(objDataReader["Cotizacion"]);
                    objCuentaBancaria.CuentaContable.Codigo= Convert.ToInt64(objDataReader["CodigoCuentaContable"]);
                    objCuentaBancaria.CuentaContable.Nombre= objDataReader["CuentaContable"].ToString();
                    objCuentaBancaria.NumeroCuenta = objDataReader["NumeroCuenta"].ToString();
                    objCuentaBancaria.CuentaContableValoresDiferidos.Codigo = Convert.ToInt64(objDataReader["CodigoCuentaContableValoresDiferidos"]);
                    objCuentaBancaria.CuentaContableValoresDiferidos.Nombre = objDataReader["CuentaContableValoresDiferidos"].ToString();
                    objCuentaBancaria.CuentaContableTranferencias.Codigo = Convert.ToInt64(objDataReader["CodigoCuentaContableTranferencias"]);
                    objCuentaBancaria.CuentaContableTranferencias.Nombre = objDataReader["CuentaContableTranferencias"].ToString();
                    objCuentaBancaria.CuentaContablePrestamos.Codigo = Convert.ToInt64(objDataReader["CodigoCuentaContablePrestamos"]);
                    objCuentaBancaria.CuentaContablePrestamos.Nombre = objDataReader["CuentaContablePrestamos"].ToString();
                    objCuentaBancaria.CuentaContableDebitoCreditoCompras.Codigo = Convert.ToInt64(objDataReader["CodigoCuentaContableDebitoCreditoCompras"]);
                    objCuentaBancaria.CuentaContableDebitoCreditoCompras.Nombre = objDataReader["CuentaContableDebitoCreditoCompras"].ToString();
                    objCuentaBancaria.FechaConciliacion = Convert.ToDateTime(objDataReader["FechaConciliacion"]);
                    objCuentaBancaria.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
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
            return objCuentaBancaria;
        }

        public static DataTable ObtenerNovedades()
        {
            //    using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            //    {
            DataTable dt = new DataTable();
            strProc = "SP_CUENTASBANCARIAS_SELECT_NOVEDADES";
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
            //        }
        }

        public static void CambiarEstadoNovedad(Entidades.CuentaBancaria pCuenta)
        {
            //     using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            //      {
            strProc = "SP_CUENTASBANCARIAS_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCuenta.Codigo);
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
            //      }
        }

        public static void AgregarDeWeb(Entidades.CuentaBancaria pCuenta)
        {
            //Creo objeto conexion
            //    using (objConexion = new SqlConnection(BaseDatos.StringConexion))
            //      {
            strProc = "SP_CUENTASBANCARIAS_INSERT_WEB";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCuenta.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoBanco", pCuenta.Banco.Codigo);
            objCommand.Parameters.AddWithValue("@NumeroCuenta", pCuenta.NumeroCuenta);
            objCommand.Parameters.AddWithValue("@CodigoMoneda", pCuenta.Moneda.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContable", pCuenta.CuentaContable.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContableValoresDiferidos", pCuenta.CuentaContableValoresDiferidos.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContableTranferencias", pCuenta.CuentaContableTranferencias.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContablePrestamos", pCuenta.CuentaContablePrestamos.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaContableDebitoCreditoCompras", pCuenta.CuentaContableDebitoCreditoCompras.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pCuenta.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Tranferencia", pCuenta.Tranferencia);
            objCommand.Parameters.AddWithValue("@DebitoCredito", pCuenta.DebitoCredito);
            objCommand.Parameters.AddWithValue("@DebitoCreditoCompras", pCuenta.DebitoCreditoCompras);
            objCommand.Parameters.AddWithValue("@FechaConciliacion", pCuenta.FechaConciliacion);
            objCommand.Parameters.AddWithValue("@Estado", pCuenta.Estado);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
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
            //     }
        }
    }

}
