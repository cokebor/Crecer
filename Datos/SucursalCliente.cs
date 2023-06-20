using Servidor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;

namespace Datos
{
    public static class SucursalCliente
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;

        private static SqlCommand objCommand = null;
        //private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static SucursalCliente()
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

        public static void CambiarEstadoNovedad(Entidades.SucursalCliente pSCliente)
        {
            strProc = "SP_SUCURSALESCLIENTES_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCliente", pSCliente.CodigoCliente);
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pSCliente.CodigoSucursal);
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

        public static void Agregar(Entidades.SucursalCliente pSCliente)
        {
            //Creo objeto conexion
            strProc = "SP_SUCURSALESCLIENTES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCliente", pSCliente.CodigoCliente);
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pSCliente.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@NombreSucursal", pSCliente.NombreSucursal);

            objCommand.Parameters.AddWithValue("@Direccion", pSCliente.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@Numero", pSCliente.Domicilio.Numero);
            objCommand.Parameters.AddWithValue("@Barrio", pSCliente.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CodigoPostal", pSCliente.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CodigoLocalidad", pSCliente.Domicilio.Localidad.Codigo);


            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar SucursalCliente, ya existe!!");
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

        public static void AgregarDeWeb(Entidades.SucursalCliente pSCliente)
        {
            //Creo objeto conexion
            strProc = "SP_SUCURSALESCLIENTES_INSERT_WEB";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCliente", pSCliente.CodigoCliente);
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pSCliente.CodigoSucursal);
            objCommand.Parameters.AddWithValue("@NombreSucursal", pSCliente.NombreSucursal);
            
            objCommand.Parameters.AddWithValue("@Direccion", pSCliente.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@Numero", pSCliente.Domicilio.Numero);
            objCommand.Parameters.AddWithValue("@Barrio", pSCliente.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CodigoPostal", pSCliente.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CodigoLocalidad", pSCliente.Domicilio.Localidad.Codigo);
            

            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar SucursalCliente, ya existe!!");
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

        public static DataTable ObtenerNovedades()
        {
            DataTable dt = new DataTable();
            strProc = "SP_SUCURSALESCLIENTES_SELECT_NOVEDADES";
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
    }
}
