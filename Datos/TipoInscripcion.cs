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
    public static class TipoInscripcion
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
        static TipoInscripcion()
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
            strProc = "SP_TIPOINSCRIPCION_SELECT";
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

        public static List<Entidades.TipoInscripcion> ObtenerTodosProveedor(int pCodigoTipoDocumento)
        {
            List<Entidades.TipoInscripcion> detalle = new List<Entidades.TipoInscripcion>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.TipoInscripcion objTipoInscripcion;
            strProc = "SP_TIPODOCUMENTOPROVEEDOR_TIPOINSCRIPCION_SELECT";
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
