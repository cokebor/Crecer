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
    public static class Empresa
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static SqlDataAdapter objDataAdapter = null;
        static Empresa()
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

        public static Entidades.Empresa Obtener()
        {
            Entidades.Empresa objEmpresa = new Entidades.Empresa();
            strProc = "SP_EMPRESA_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objEmpresa.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objEmpresa.NombreSucursal = objDataReader["NombreSucursal"].ToString();
                objEmpresa.RazonSocial = objDataReader["RazonSocial"].ToString();
                objEmpresa.CUIT= objDataReader["CUIT"].ToString();
                objEmpresa.Domicilio= objDataReader["Domicilio"].ToString();
                objEmpresa.Puesto = objDataReader["Puesto"].ToString();
                objEmpresa.Domicilio2 = objDataReader["Domicilio2"].ToString();
                objEmpresa.IngresosBrutos = objDataReader["IngresosBrutos"].ToString();
                objEmpresa.FechaInicioActividad = objDataReader["FechaInicioActividad"].ToString();
                //objEmpresa.PuntoDeVentaElectronico= Convert.ToInt32(objDataReader["PuntoDeVentaElectronico"]);
                objEmpresa.CuentaContableVentaSucursal.Codigo = Convert.ToInt64(objDataReader["CuentaContableVentaSucursal"]);
                objEmpresa.CuentaContableIvaDebitoSucursal.Codigo = Convert.ToInt64(objDataReader["CuentaContableIvaDebitoSucursal"]);
                objEmpresa.CuentaContableDebolucionMercaderiaSucursal.Codigo = Convert.ToInt64(objDataReader["CuentaContableDebolucionMercaderiaSucursal"]);
                objEmpresa.CuentaContableAjusteSucursal.Codigo = Convert.ToInt64(objDataReader["CuentaContableAjusteSucursal"]);
                objEmpresa.CuentaContableCuentaCorrienteProveedores.Codigo= Convert.ToInt64(objDataReader["CuentaContableCuentaCorrienteProveedores"]);
                objEmpresa.CuentaContableCuentaCorrienteClientes.Codigo = Convert.ToInt64(objDataReader["CuentaContableCuentaCorrienteClientes"]);
                objEmpresa.CuentaContableDescuentosClientes.Codigo = Convert.ToInt64(objDataReader["CuentaContableDescuentosClientes"]);
                objEmpresa.Fiscal = Convert.ToBoolean(objDataReader["Fiscal"]);
                objEmpresa.Convenio = Convert.ToBoolean(objDataReader["Convenio"]);
                objEmpresa.CBUFacturasDeCredito = objDataReader["CBUFacturasDeCredito"].ToString();
                objEmpresa.PercepcionMunicipal= Convert.ToBoolean(objDataReader["PercepcionMunicipal"]);
                objEmpresa.DireccionBackup= objDataReader["DireccionBackup"].ToString();
                objEmpresa.FacturasM = Convert.ToBoolean(objDataReader["FacturasM"]);
                objEmpresa.Imprimir = Convert.ToBoolean(objDataReader["Imprimir"]);
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
            return objEmpresa;
        }

        public static void ActualizarImpresoras(int pCodigoUsuario,string pImpresoraComprobantes,bool pTermica, string pImpresoraInformes)
        {
            strProc = "SP_IMPRESORAS_UPDATE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCodigoUsuario);
            objCommand.Parameters.AddWithValue("@ImpresoraComprobantes", pImpresoraComprobantes);
            objCommand.Parameters.AddWithValue("@Termica", pTermica);
            objCommand.Parameters.AddWithValue("@ImpresoraInformes", pImpresoraInformes);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Ejercicio, ya existe!!");
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

        public static DataTable ObtenerDataTable()
        {
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            strProc = "SP_EMPRESA_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsEmpresa";
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

        public static void ActualizaLogo(byte[] pImagen)
        {
            //Creo objeto conexion
            strProc = "SP_LOGO_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Imagen", pImagen);
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
