using MySql.Data.MySqlClient;
using Servidor;
using System;
using System.Data;

namespace DatosWeb
{
    public static class Producto
    {
        private static string strProc = string.Empty;

        private static MySqlConnection objConexion = null;
        private static MySqlCommand objCommand = null;
        private static MySqlDataAdapter objDataAdapter = null;
        static Producto()
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

        public static void Agregar(Entidades.Producto pProducto, Entidades.Empresa pEmpresa)
        {
            //Creo objeto conexion
            strProc = "SP_PRODUCTOS_INSERT_WEB";
            objCommand = new MySqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGOPUESTO", pEmpresa.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGO", pProducto.Codigo);
            objCommand.Parameters.AddWithValue("@DESCRIPCION", pProducto.Descripcion);
            objCommand.Parameters.AddWithValue("@CODIGORUBRO", pProducto.RubroProducto.Codigo);
            objCommand.Parameters.AddWithValue("@UNIDADMEDIDA", pProducto.UnidadDeMedida);
            objCommand.Parameters.AddWithValue("@PESO", pProducto.Peso);
            objCommand.Parameters.AddWithValue("@STOCKMINIMO", pProducto.StockMinimo);
            objCommand.Parameters.AddWithValue("@CODIGOBARRA", pProducto.CodigoBarra);
            objCommand.Parameters.AddWithValue("@PORCENTAJEIVA", pProducto.PorcentajeIVA);
            objCommand.Parameters.AddWithValue("@FACTURACIONPORCUBETA", pProducto.FacturacionPorCubeta);
            objCommand.Parameters.AddWithValue("@VACIO", pProducto.Vacio);
            objCommand.Parameters.AddWithValue("@ESTADO", (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(pProducto.Estado));

            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (MySqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Producto, ya existe!!");
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
            strProc = "SP_PRODUCTOS_SELECT_NOVEDADES";
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

