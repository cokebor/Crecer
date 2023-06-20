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
    public static class Moneda
    {
        private static string strProc = string.Empty;

        private static MySqlConnection objConexion = null;
        private static MySqlCommand objCommand = null;
        private static MySqlDataAdapter objDataAdapter = null;
        static Moneda()
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

        public static void Agregar(Entidades.Moneda pMoneda, Entidades.Empresa pEmpresa)
        {
            //Creo objeto conexion
            strProc = "SP_MONEDAS_INSERT_WEB";
            objCommand = new MySqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGOPUESTO", pEmpresa.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGO", pMoneda.Codigo);
            objCommand.Parameters.AddWithValue("@DESCRIPCION", pMoneda.Descripcion);
            objCommand.Parameters.AddWithValue("@FECHACOTIZACION", pMoneda.FechaCotizacion);
            objCommand.Parameters.AddWithValue("@COTIZACION", pMoneda.Cotizacion);

            objCommand.Parameters.AddWithValue("@ESTADO", (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(pMoneda.Estado));

            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (MySqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Moneda, ya existe!!");
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
            strProc = "SP_MONEDAS_SELECT_NOVEDADES";
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
