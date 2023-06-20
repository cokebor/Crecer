using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSucursal6
{
    public static class Empresa
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        //private static SqlCommand objCommand = null;
        //private static SqlDataReader objDataReader = null;
        private static SqlDataAdapter objDataAdapter = null;
        static Empresa()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionSucursal6);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ObtenerDataTable()
        {
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            strProc = "SP_EMPRESA_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsEmpresa";
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
