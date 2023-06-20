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
    public static class Ejercicio
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        static Ejercicio()
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
            strProc = "SP_EJERCICIOS_SELECT";
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

        public static void Agregar(Entidades.Ejercicio pEjercicio)
        {
            //Creo objeto conexion
            strProc = "SP_EJERCICIOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pEjercicio.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pEjercicio.Descripcion);
            objCommand.Parameters.AddWithValue("@Desde", pEjercicio.FechaInicio.Date);
            objCommand.Parameters.AddWithValue("@hasta", pEjercicio.FechaFinal.Date);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Ejercicio, ya existe!!");
                }
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

        public static void Eliminar(Entidades.Ejercicio pEjercicio)
        {
            //Creo objeto conexion
            strProc = "SP_EJERCICIOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pEjercicio.Codigo);
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

        public static Entidades.Ejercicio ObtenerUno(int pCodigo)
        {
            Entidades.Ejercicio objEjercicio = new Entidades.Ejercicio();
            strProc = "SP_EJERCICIOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objEjercicio.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objEjercicio.Descripcion = objDataReader["Descripcion"].ToString();
                objEjercicio.FechaInicio = Convert.ToDateTime(objDataReader["FechaInicio"]);
                objEjercicio.FechaFinal = Convert.ToDateTime(objDataReader["FechaFin"]);

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
            return objEjercicio;
        }

    }
}
