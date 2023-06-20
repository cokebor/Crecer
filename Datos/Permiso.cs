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
    public static class Permiso
    {

        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        static Permiso()
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

        public static DataTable ObtenerTodos(int pCodigoGrupo)
        {
            DataTable dt = new DataTable();

             strProc = "SP_PERMISOS_SELECT";
             objDataAdapter = new SqlDataAdapter(strProc, objConexion);
             objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
             objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoGrupo", pCodigoGrupo);
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

        public static void Insertar(int pCodigoGrupo, DataTable pPermisos)
        {
            strProc = "SP_PERMISOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoGrupo", pCodigoGrupo);

            SqlParameter paramPermisos = new SqlParameter();
            paramPermisos.ParameterName = "@Permisos";
            paramPermisos.Direction = ParameterDirection.Input;
            paramPermisos.Value = pPermisos;
            paramPermisos.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramPermisos);


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
