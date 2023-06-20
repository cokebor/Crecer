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
    public static class Cliente
    {
        private static string strProc = string.Empty;

        private static MySqlConnection objConexion = null;
        private static MySqlCommand objCommand = null;
        private static MySqlDataAdapter objDataAdapter = null;
        static Cliente()
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

        public static void Agregar(Entidades.Cliente pCliente, Entidades.Empresa pEmpresa)
        {
            //Creo objeto conexion
            strProc = "SP_CLIENTES_INSERT_WEB";
            objCommand = new MySqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGOPUESTO", pEmpresa.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGO", pCliente.Codigo);
            objCommand.Parameters.AddWithValue("@NOMBRE", pCliente.Nombre);
            objCommand.Parameters.AddWithValue("@CODIGOTIPODOCUMENTO", pCliente.TipoDocumento.Codigo);
            objCommand.Parameters.AddWithValue("@CUIT", pCliente.CUIT);
            objCommand.Parameters.AddWithValue("@FECHAVALIDACIONCUIT", pCliente.FechaValidacionCUIT);
            objCommand.Parameters.AddWithValue("@CODIGOTIPOINSCRIPCION", pCliente.TipoInscripcion.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOTIPOCONTRIBUYENTE", pCliente.TipoContribuyente.Codigo);
            objCommand.Parameters.AddWithValue("@RIESGOFISCAL", pCliente.RiesgoFiscal);
            /*objCommand.Parameters.AddWithValue("@DIRECCION", pCliente.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@NUMERO", pCliente.Domicilio.Numero);
            objCommand.Parameters.AddWithValue("@BARRIO", pCliente.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CODIGOPOSTAL", pCliente.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CODIGOLOCALIDAD", pCliente.Domicilio.Localidad.Codigo);*/
            objCommand.Parameters.AddWithValue("@FACTURAPORKILOS", pCliente.FacturaKilos);
            objCommand.Parameters.AddWithValue("@OBSERVACIONES", pCliente.Observaciones);
            objCommand.Parameters.AddWithValue("@COMISION", pCliente.Comision);
            objCommand.Parameters.AddWithValue("@ORIGINAL", pCliente.Original);
            objCommand.Parameters.AddWithValue("@DUPLICADO", pCliente.Duplicado);
            objCommand.Parameters.AddWithValue("@TRIPLICADO", pCliente.Triplicado);
            objCommand.Parameters.AddWithValue("@FACTURACIONPORCUBETA", pCliente.FacturacionPorCubeta);
            objCommand.Parameters.AddWithValue("@MIPYME", pCliente.MiPYME);
            objCommand.Parameters.AddWithValue("@ESTADO", (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(pCliente.Estado));
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (MySqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Cliente, ya existe!!");
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
            strProc = "SP_CLIENTES_SELECT_NOVEDADES";
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