using MySql.Data.MySqlClient;
using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosWeb
{
    public static class Empleado
    {
        private static string strProc = string.Empty;

        private static MySqlConnection objConexion = null;
        private static MySqlCommand objCommand = null;
        private static MySqlDataAdapter objDataAdapter = null;
        static Empleado()
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

        public static void Agregar(Entidades.Empleado pEmpleado, Entidades.Empresa pEmpresa)
        {
            //Creo objeto conexion
            strProc = "SP_EMPLEADOS_INSERT_WEB";
            objCommand = new MySqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGOPUESTO", pEmpresa.Codigo);
            objCommand.Parameters.AddWithValue("@LEGAJO", pEmpleado.Legajo);
            objCommand.Parameters.AddWithValue("@CODIGO", pEmpleado.Codigo);
            objCommand.Parameters.AddWithValue("@APELLIDO", pEmpleado.Apellido);
            objCommand.Parameters.AddWithValue("@NOMBRES", pEmpleado.Nombres);
            objCommand.Parameters.AddWithValue("@CODIGOTIPODOCUMENTO", pEmpleado.TipoDeDocumentoGuardar());
            objCommand.Parameters.AddWithValue("@NUMERODOCUMENTO", pEmpleado.NumeroDocumento);
            objCommand.Parameters.AddWithValue("@SEXO", pEmpleado.SexoParaGuardar());
            objCommand.Parameters.AddWithValue("@FECHANACIMIENTO", pEmpleado.FechaNacimiento);
            objCommand.Parameters.AddWithValue("@DIRECCION", pEmpleado.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@BARRIO", pEmpleado.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CODIGOPOSTAL", pEmpleado.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CODIGOLOCALIDAD", pEmpleado.Domicilio.Localidad.Codigo);
            objCommand.Parameters.AddWithValue("@FECHAINGRESO", pEmpleado.FechaIngreso);
            objCommand.Parameters.AddWithValue("@CUIL", pEmpleado.CUIL);
            objCommand.Parameters.AddWithValue("@CODIGOPUESTO2", pEmpleado.Puesto.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOESTADOCIVIL", pEmpleado.EstadoCivilParaGuardar());
            objCommand.Parameters.AddWithValue("@CANTIDADHIJOS", pEmpleado.CantidadHijos);
            objCommand.Parameters.AddWithValue("@CODIGOOBRASOCIAL", pEmpleado.ObraSocial.Codigo);
            
            objCommand.Parameters.AddWithValue("@ESEMPLEADO", pEmpleado.EsEmpleado);
            objCommand.Parameters.AddWithValue("@SUELDO", pEmpleado.Sueldo);
            objCommand.Parameters.AddWithValue("@CODIGOBANCO", pEmpleado.Banco.Codigo);
            objCommand.Parameters.AddWithValue("@ESTADO", (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(pEmpleado.Estado));

            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (MySqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Empleado, ya existe!!");
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

        public static DataTable ObtenerNovedades(int pCodigoNovedad, Entidades.Empresa pEmpresa)
        {
            DataTable dt = new DataTable();
            strProc = "SP_EMPLEADOS_SELECT_NOVEDADES";
            objDataAdapter = new MySqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoNovedad);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoP", pEmpresa.Codigo);
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
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
