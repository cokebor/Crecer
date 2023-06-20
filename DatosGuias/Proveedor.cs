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
    public static class Proveedor
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objComando = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static Proveedor()
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

        public static void Agregar(Entidades.Proveedor pProveedor)
        {
            strProc = "SP_PROVEEDORESCRECER_INSERT";


            objComando = new SqlCommand(strProc, objConexion);
            objComando.CommandType = CommandType.StoredProcedure;

            objComando.Parameters.AddWithValue("@Codigo", pProveedor.Codigo);
            objComando.Parameters.AddWithValue("@Descripcion", pProveedor.Nombre);
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
