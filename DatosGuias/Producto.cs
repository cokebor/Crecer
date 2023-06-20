using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosGuias
{
    public static class Producto
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objComando = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static Producto()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionGuias);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Agregar(Entidades.Producto pProducto)
        {
            strProc = "SP_PRODUCTOSCRECER_INSERT";
            objComando = new SqlCommand(strProc, objConexion);
            objComando.CommandType = CommandType.StoredProcedure;

            objComando.Parameters.AddWithValue("@Codigo", pProducto.Codigo);
            objComando.Parameters.AddWithValue("@Descripcion", pProducto.Descripcion);
            try
            {
                objConexion.Open();
                objComando.ExecuteNonQuery();
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
