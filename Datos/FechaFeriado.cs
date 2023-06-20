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
    public static class FechaFeriado
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static FechaFeriado()
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

        public static void Agregar(Entidades.FechaFeriado objEFechaFeriado)
        {
            strProc = "SP_FECHASFERIADOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Fecha", objEFechaFeriado.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoSucursal", objEFechaFeriado.Sucursal.Codigo);
            objCommand.Parameters.AddWithValue("@PagoDiaExtra", objEFechaFeriado.PagoDiaExtra);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", objEFechaFeriado.Usuario.Codigo);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Fecha de Feriado, ya existe!!");
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

        public static bool VerSiExiste(DateTime pFecha, int pCodigoSucursal)
        {

            //Creo objeto conexion
            strProc = "SP_FECHASFERIADOSEXISTE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Fecha", pFecha);
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pCodigoSucursal);
            try
            {

                objConexion.Open();
                bool res = Convert.ToBoolean(objCommand.ExecuteScalar());
                return res;
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