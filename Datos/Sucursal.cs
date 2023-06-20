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
    public static class Sucursal
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static Sucursal()
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

        public static DataTable ObtenerLocalidades()
        {
            DataTable dt = new DataTable();
            strProc = "SP_LOCALIDADESSUCURSALES_SELECT";
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

        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_SUCURSALES_SELECT";
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


        public static DataTable ObtenerUno(int pCodigo)
        {
            //  Entidades.Empresa objEmpresa = new Entidades.Empresa();
            DataTable dt = new DataTable();
            strProc = "SP_SUCURSALES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigo);

            try
            {
                dt.TableName = "dsEmpresa";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerSucursales()
        {
            DataTable dt = new DataTable();
            strProc = "SP_SUCURSALESSOLAS_SELECT";
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

        public static Entidades.Sucursal ObtenerSucursal(int pCodigoSucursal, int pCodigoSucursalEnviar)
        {
            Entidades.Sucursal objESucursal = new Entidades.Sucursal();
            strProc = "SP_SUCURSALESENVIOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pCodigoSucursal);
            objCommand.Parameters.AddWithValue("@CodigoSucursalEnvio", pCodigoSucursalEnviar);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objESucursal.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objESucursal.RazonSocial = objDataReader["Descripcion"].ToString();

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
            return objESucursal;
        }

        public static Entidades.Sucursal ObtenerSucursal(int pCodigoSucursal)
        {
            Entidades.Sucursal objESucursal = new Entidades.Sucursal();
            strProc = "SP_SUCURSALES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoSucursal);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.Read())
                {
                    objESucursal.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objESucursal.RazonSocial = objDataReader["Descripcion"].ToString();

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
            return objESucursal;
        }
    }
}
