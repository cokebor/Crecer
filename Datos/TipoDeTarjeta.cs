using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class TipoDeTarjeta
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        static TipoDeTarjeta()
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

      
        public static DataTable ObtenerTodosActivos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSDETARJETASACTIVAS_SELECT";
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
        /*
        public static Entidades.TipoDeTarjetas ObtenerUno(int pCodigo)
        {
            Entidades.TipoDeTarjetas objTipo = new Entidades.TipoDeTarjetas();
            strProc = "SP_TIPOSDETARJETAS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objTipo.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objTipo.Descripcion = objDataReader["Descripcion"].ToString();
                objTipo.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);

                Enumeraciones.Enumeraciones.Estados estado;

                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objTipo.Estado = estado;


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
            return objTipo;
        }*/

        public static Entidades.TipoDeTarjetas ObtenerUno(int pCodigo, Entidades.Banco pBanco)
        {
            Entidades.TipoDeTarjetas objTipo = new Entidades.TipoDeTarjetas();
            strProc = "SP_TIPOSDETARJETAS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            objCommand.Parameters.AddWithValue("@CodigoBanco", pBanco.Codigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objTipo.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objTipo.Descripcion = objDataReader["Descripcion"].ToString();
                objTipo.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);

                Enumeraciones.Enumeraciones.Estados estado;

                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objTipo.Estado = estado;


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
            return objTipo;
        }
    }
}
