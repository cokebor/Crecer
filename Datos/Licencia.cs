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
    public static class Licencia
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static Licencia()
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
        public static List<Entidades.Licencia> ObtenerporEmpleado(Entidades.Empleado pEmpleado)
        {
            List<Entidades.Licencia> lista = new List<Entidades.Licencia>();
            strProc = "SP_LICENCIASPOREMPLEADO_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoEmpleado", pEmpleado.Codigo);
            
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                Entidades.Licencia licencia;
                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        licencia = new Entidades.Licencia();
                        licencia.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                        licencia.Empleado.Codigo= Convert.ToInt32(objDataReader["CodigoEmpleado"]);
                        licencia.TipoLicencia.Codigo = Convert.ToInt32(objDataReader["CodigoTipoLicencia"]);
                        licencia.Desde = Convert.ToDateTime(objDataReader["Desde"]);
                        licencia.Hasta = Convert.ToDateTime(objDataReader["Hasta"]);
                        licencia.Dias = Convert.ToInt32(objDataReader["Dias"]);
                        licencia.Estado = Convert.ToBoolean(objDataReader["Estado"]);
                        lista.Add(licencia);
                    }
                }
                else
                {
                    lista = new List<Entidades.Licencia>();
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
            return lista;
        }
    }
}
