using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosVillaMaria
{
    public static class Cliente
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        //private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        //private static SqlDataReader objDataReader = null;
        static Cliente()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionVillaMaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CLIENTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 4060) {
                    throw new Exception("Error de Conexion: no se encuentra la base de Datos Solicitada");
                }
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
