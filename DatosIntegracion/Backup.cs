using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosIntegracion
{
    public static class Backup
    {
        private static SqlConnection objConexion = null;

        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataAdapter objDataAdapter = null;
        static Backup()
        {
            try
            {
                
                objConexion = new SqlConnection(BaseDatos.StringConexionIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Agregar(int pCodigoSucursal,string pNombreArchivo )
        {
            //Creo objeto conexion
            strProc = "SP_BACKUPSFECHAS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGOSUC", pCodigoSucursal);
            objCommand.Parameters.AddWithValue("@NOMBREARCHIVO", pNombreArchivo);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
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
        public static DataTable ObtenerFechas(Entidades.Empresa pEmpresa)
        {
            DataTable dt = new DataTable();
            strProc = "SP_BACKUPS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Sucursal", pEmpresa.Codigo);
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (SqlException ex)
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