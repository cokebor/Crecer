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
    public static class PuestoCaja
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
        static PuestoCaja()
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
            strProc = "SP_PUESTOSCAJA_SELECT";
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

        public static Entidades.PuestoCaja ObtenerUno(int pCodigoPuesto)
        {
            Entidades.PuestoCaja objPuestocaja = new Entidades.PuestoCaja();
            strProc = "SP_PUESTOSCAJA_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoPuesto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objPuestocaja.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objPuestocaja.Descripcion = objDataReader["Descripcion"].ToString();
                
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
            return objPuestocaja;
        }

        public static List<Entidades.PuestoCaja> ObtenerAlgunos(int pCodigoUsuario)
        {
            List<Entidades.PuestoCaja> detalle = new List<Entidades.PuestoCaja>();
            Entidades.PuestoCaja objPuesto;
            strProc = "SP_PUESTOSDECAJA_USUARIOS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pCodigoUsuario);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();

                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objPuesto = new Entidades.PuestoCaja();
                        objPuesto.Codigo = Convert.ToInt32(objDataReader["CodigoPuestoCaja"]);

                        detalle.Add(objPuesto);
                    }
                }
                else
                {
                    objPuesto = null;
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
