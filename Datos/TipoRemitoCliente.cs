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
    public static class TipoRemitoCliente
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
        static TipoRemitoCliente()
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
        public static DataTable ObtenerSalientes()
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOREMITOCLIENTE_SELECT_SALIENTES";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public static Entidades.TipoRemitoCliente ObtenerUno(int pCodigo)
        {
            Entidades.TipoRemitoCliente objTipoRemito = new Entidades.TipoRemitoCliente();
            strProc = "SP_TIPOREMITOCLIENTE_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objTipoRemito.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objTipoRemito.Descripcion = objDataReader["Descripcion"].ToString();
                objTipoRemito.AfectaStock= objDataReader["AfectaStock"].ToString();
                objTipoRemito.Numerador.Codigo = Convert.ToInt32(objDataReader["CodigoNumerador"]);
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
            return objTipoRemito;
        }
    }
}
