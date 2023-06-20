using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosWiki
{
    public static class Integracion
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        static Integracion()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionWiki);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void InsertarDatos(Entidades.Integracion pIntegracion)
        {
            //Creo objeto conexion
            strProc = "SP_INTEGRACION_TOTAL";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@TipoIntegracion", pIntegracion.TipoIntegracion);
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
