using MySql.Data.MySqlClient;
using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatosWeb
{
    public static class Prueba
    {
        private static string sql = string.Empty;
        private static MySqlConnection objConexion = null;
        //private static MySqlCommand objCommand = null;
        //private static MySqlDataReader objDataReader;
        private static MySqlDataAdapter objDataAdapter;
        static Prueba()
        {
            try
            {
                objConexion = new MySqlConnection(BaseDatos.StringConexionWeb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool Resultado()
        {
            try
            {
                objConexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1042)
                    return false;
                else
                    throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }

        }

        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            sql = "SELECT * FROM Alumno";
            objDataAdapter = new MySqlDataAdapter(sql, objConexion);
            //objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1042)
                    throw new Exception("No se puede conectar con el Servidor Web.");
                else
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
