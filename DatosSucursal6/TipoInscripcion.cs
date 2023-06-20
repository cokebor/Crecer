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
    public static class TipoInscripcion
    {
        private static SqlConnection objConexion = null;
        //private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
        static TipoInscripcion()
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

        public static List<Entidades.TipoInscripcion> ObtenerTodos(int pCodigoTipoDocumento)
        {
            List<Entidades.TipoInscripcion> detalle = new List<Entidades.TipoInscripcion>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.TipoInscripcion objTipoInscripcion;
            strProc = "SP_TIPODOCUMENTOCLIENTE_TIPOINSCRIPCION_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoTipoDocumento);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();

                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objTipoInscripcion = new Entidades.TipoInscripcion();
                        objTipoInscripcion.Codigo = Convert.ToInt32(objDataReader["CodigoTipoInscripcion"]);
                        objTipoInscripcion.Descripcion = objDataReader["Descripcion"].ToString();
                        detalle.Add(objTipoInscripcion);
                    }
                }
                else
                {
                    objTipoInscripcion = null;
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
            return detalle;
        }
        
    }
}
