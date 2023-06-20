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
    public static class CategroriaProveedor
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
        static CategroriaProveedor()
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
        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CATEGORIASPROVEEDOR_SELECT";
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
        public static Entidades.CategoriaProveedor ObtenerUno(int pCodigo)
        {
            Entidades.CategoriaProveedor objECatProv = new Entidades.CategoriaProveedor();
            strProc = "SP_CATEGORIASPROVEEDOR_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCategoria", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objECatProv = null;
                }
                else
                {
                    objECatProv.Codigo= Convert.ToInt32(objDataReader["Codigo"]);
                    objECatProv.Descripcion = objDataReader["Descripcion"].ToString();
                    objECatProv.RetencionDesdeInscripto = Convert.ToDouble(objDataReader["RetencionDesdeInscripto"]);
                    objECatProv.ImporteMinimoRetencion = Convert.ToDouble(objDataReader["ImporteMinimoRetencion"]);
                    objECatProv.PorcentajeRetencionInscripto = Convert.ToDouble(objDataReader["PorcentajeRetencionInscripto"]);
                    objECatProv.PorcentajeRetencionNoInscripto = Convert.ToDouble(objDataReader["PorcentajeRetencionNoInscripto"]);
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
            return objECatProv;
        }


    }
}
