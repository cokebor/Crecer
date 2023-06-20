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
    public static class TipoContribuyente
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
        static TipoContribuyente()
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
        public static DataTable ObtenerTodosDeClientes()
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSCONTRIBUYENTESCLIENTES_SELECT";
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

        public static DataTable ObtenerTodosDeProveedores()
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSCONTRIBUYENTESPROVEEDORES_SELECT";
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
        public static Entidades.TipoContribuyente ObtenerUno(int pCodigo)
        {
            Entidades.TipoContribuyente objETipoContribuyente = new Entidades.TipoContribuyente();
            strProc = "SP_TIPOSCONTRIBUYENTES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoTipoContribuyente", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objETipoContribuyente = null;
                }
                else
                {
                    objETipoContribuyente.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objETipoContribuyente.Descripcion = objDataReader["Descripcion"].ToString();
                    objETipoContribuyente.PorcentajePercepcion = Convert.ToDouble(objDataReader["PorcentajePercepcion"]);
                    objETipoContribuyente.PorcentajeRetencion = Convert.ToDouble(objDataReader["PorcentajeRetencion"]);
                    objETipoContribuyente.MinimoRetencion = Convert.ToDouble(objDataReader["MinimoRetencion"]);
                }
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
            return objETipoContribuyente;
        }
    }
}
