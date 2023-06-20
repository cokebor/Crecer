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
    public static class Novedad
    {
        private static SqlConnection objConexion = null;
        //private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static Novedad()
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

        public static Entidades.Novedad ObtenerUno(string pTabla)
        {
            Entidades.Novedad objNovedad = new Entidades.Novedad();
            strProc = "SP_NOVEDADES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Tabla", pTabla);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objNovedad.Descripcion= objDataReader["Tabla"].ToString();
                objNovedad.CodigoNovedad = Convert.ToInt32(objDataReader["CodigoNovedad"]);
                
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
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
            return objNovedad;
        }

        public static void Actualizar(Entidades.Novedad pNovedad)
        {
            //Creo objeto conexion
            strProc = "SP_NOVEDADES_UPDATE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Tabla", pNovedad.Descripcion);
            objCommand.Parameters.AddWithValue("@CodigoNovedad", pNovedad.CodigoNovedad);

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
