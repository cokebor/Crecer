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
    public static class Proveedor
    {
        private static string strProc = string.Empty;

        private static MySqlConnection objConexion = null;
        private static MySqlCommand objCommand = null;
        private static MySqlDataAdapter objDataAdapter = null;
        static Proveedor()
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

        public static void Agregar(Entidades.Proveedor pProveedor, Entidades.Empresa pEmpresa)
        {
            //Creo objeto conexion
            strProc = "SP_PROVEEDORES_INSERT_WEB";
            objCommand = new MySqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGOPUESTO", pEmpresa.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGO", pProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@NOMBRE", pProveedor.Nombre);
            objCommand.Parameters.AddWithValue("@CODIGOTIPOINSCRIPCION", pProveedor.TipoInscripcion.Codigo);
            objCommand.Parameters.AddWithValue("@CUIT", pProveedor.CUIT);
            objCommand.Parameters.AddWithValue("@CODIGOALICUOTAMUNICIPAL", pProveedor.TipoContribuyente.Codigo);
            objCommand.Parameters.AddWithValue("@RIESGOFISCAL", pProveedor.RiesgoFiscal);
            objCommand.Parameters.AddWithValue("@INGRESOSBRUTOS", pProveedor.IngresosBrutos);
            objCommand.Parameters.AddWithValue("@DIRECCION", pProveedor.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@NUMERO", pProveedor.Domicilio.Numero);
            objCommand.Parameters.AddWithValue("@BARRIO", pProveedor.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CODIGOPOSTAL", pProveedor.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CODIGOLOCALIDAD", pProveedor.Domicilio.Localidad.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOCATEGORIAPROVEEDOR", pProveedor.CategoriaProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@OBSERVACIONES", pProveedor.Observaciones);
            objCommand.Parameters.AddWithValue("@COMISION", pProveedor.Comision);
            objCommand.Parameters.AddWithValue("@FORMAPAGO", pProveedor.FormaPago);
            objCommand.Parameters.AddWithValue("@INSCRIPTOGANANCIAS", pProveedor.InscriptoGanancias);

            objCommand.Parameters.AddWithValue("@ESTADO", (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(pProveedor.Estado));

            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (MySqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Proveedor, ya existe!!");
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
            strProc = "SP_PROVEEDORES_SELECT_NOVEDADES";
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

