using Entidades;
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
    public static class Empleado
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static Empleado()
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
            strProc = "SP_EMPLEADOS_SELECT";
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
        public static DataTable ObtenerActivos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_EMPLEADOS_SELECT_ACTIVOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsEmpleados";
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

        public static DataTable ObtenerActivosEmpleados()
        {
            DataTable dt = new DataTable();
            strProc = "SP_EMPLEADOS_SELECT_ACTIVOSEMPLEADOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsEmpleados";
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
        public static DataTable ObtenerActivosQueSonEmpleados()
        {
            DataTable dt = new DataTable();
            strProc = "SP_EMPLEADOSQUESON_SELECT_ACTIVOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsEmpleados";
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
        public static Entidades.Empleado ObtenerUno(int pCodigoEmpleado)
        {
            Entidades.Empleado objEmpleado = new Entidades.Empleado();
            strProc = "SP_EMPLEADOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoEmpleado);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objEmpleado = null;
                }
                else
                {

                    objEmpleado.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objEmpleado.Legajo = objDataReader["Legajo"].ToString();
                    objEmpleado.Apellido = objDataReader["Apellido"].ToString();
                    objEmpleado.Nombres = objDataReader["Nombres"].ToString();
                    objEmpleado.Sexo = (Enumeraciones.Enumeraciones.Sexos)Convert.ToChar(objDataReader["Sexo"]);
                    objEmpleado.FechaNacimiento = Convert.ToDateTime(objDataReader["FechaNacimiento"]);
                    objEmpleado.TipoDeDocumento = (Enumeraciones.Enumeraciones.TiposDeDocumentos)Convert.ToInt32(objDataReader["CodigoTipoDocumento"]);
                    objEmpleado.NumeroDocumento = objDataReader["NumeroDocumento"].ToString();
                    objEmpleado.Domicilio.Direccion = objDataReader["Direccion"].ToString();
                    objEmpleado.Domicilio.Barrio = objDataReader["Barrio"].ToString();
                    objEmpleado.Domicilio.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                    objEmpleado.Domicilio.Localidad.Codigo = Convert.ToInt32(objDataReader["CodigoLocalidad"]);
                    objEmpleado.Domicilio.Localidad.Provincia.Codigo = Convert.ToInt32(objDataReader["CodigoProvincia"]);
                    objEmpleado.Domicilio.Localidad.Provincia.Pais.Codigo = Convert.ToInt32(objDataReader["CodigoPais"]);
                    objEmpleado.FechaIngreso = Convert.ToDateTime(objDataReader["FechaIngreso"]);
                    objEmpleado.CUIL = objDataReader["CUIL"].ToString();
                    objEmpleado.Puesto.Codigo = Convert.ToInt32(objDataReader["CodigoPuesto"]);
                    objEmpleado.Puesto.Descripcion = objDataReader["Puesto"].ToString();
                    objEmpleado.EstadoCivil = (Enumeraciones.Enumeraciones.EstadosCiviles)Convert.ToInt32(objDataReader["CodigoEstadoCivil"]);
                    objEmpleado.CantidadHijos = Convert.ToInt32(objDataReader["CantidadHijos"]);
                    objEmpleado.ObraSocial.Codigo = Convert.ToInt32(objDataReader["CodigoObraSocial"]);
                    objEmpleado.EsEmpleado = Convert.ToBoolean(objDataReader["EsEmpleado"]);
                    objEmpleado.SueldoEfectivo = Convert.ToDouble(objDataReader["SueldoEfectivo"]);
                    objEmpleado.SueldoBanco = Convert.ToDouble(objDataReader["SueldoBanco"]);
                    objEmpleado.Banco.Codigo = Convert.ToInt32(objDataReader["CodigoBanco"]);
                    objEmpleado.FueraDeConvenio = Convert.ToBoolean(objDataReader["FueraDeConvenio"]);
                    objEmpleado.Sucursal.Codigo= Convert.ToInt32(objDataReader["CodigoSucursal"]);
                    objEmpleado.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
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
            return objEmpleado;
        }

        public static List<Entidades.Empleado> ObtenerEmpleadosLiquidacionSueldo(int pCodigoFormaPago, int pCodigoCuentaBancaria)
        {
            Entidades.Empleado objEmpleado;
            List<Entidades.Empleado> lista = new List<Entidades.Empleado>();
            strProc = "SP_EMPLEADOSLIQUIDACIONSUELDO_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@FormaDePago", pCodigoFormaPago);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCodigoCuentaBancaria);


            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                while (objDataReader.Read())
                {

                    objEmpleado = new Entidades.Empleado();
                    objEmpleado.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objEmpleado.Nombres = objDataReader["NombreCompleto"].ToString();
                    objEmpleado.Legajo = objDataReader["Legajo"].ToString();
                    objEmpleado.NumeroDocumento = objDataReader["NumeroDocumento"].ToString();
                    lista.Add(objEmpleado);

                }
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

        public static void AgregarLicencia(Entidades.Licencia pLicencia, Entidades.Usuario pUsuario)
        {
            strProc = "SP_LICENCIAS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@CodigoEmpleado", pLicencia.Empleado.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoLicencia", pLicencia.TipoLicencia.Codigo);
            objCommand.Parameters.AddWithValue("@Desde", pLicencia.Desde);
            objCommand.Parameters.AddWithValue("@Hasta", pLicencia.Hasta);
            objCommand.Parameters.AddWithValue("@Dias", pLicencia.Dias);
            objCommand.Parameters.AddWithValue("@Certificado", pLicencia.Certificado);
            objCommand.Parameters.AddWithValue("@Observaciones", pLicencia.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pUsuario.Codigo);

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

        public static void AgregarVacaciones(List<Vacaciones> listaVacaciones, Entidades.Usuario pUsuario)
        {

            strProc = "SP_VACACIONES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@CodigoUsuario", pUsuario.Codigo);

            #region DataTable Vacaciones

            DataTable dtVacaciones = new DataTable();
            DataColumn column;


            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoEmpleado";
            dtVacaciones.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Periodo";
            dtVacaciones.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Desde";
            dtVacaciones.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Hasta";
            dtVacaciones.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "DiasTomados";
            dtVacaciones.Columns.Add(column);


            foreach (Entidades.Vacaciones v in listaVacaciones)
            {
                dtVacaciones.Rows.Add(v.Empleado.Codigo, v.Periodo, v.Desde, v.Hasta, v.DiasTomados);
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Vacaciones";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtVacaciones;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion

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

        public static int ObtenerDiasVacacionesYaTomados(Entidades.Empleado pEmpleado, int pPeriodo)
        {
            strProc = "SP_VACACIONES_DIASTOMADOSPOREMPLEADO_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoEmpleado", pEmpleado.Codigo);
            objCommand.Parameters.AddWithValue("@Periodo", pPeriodo);
            try
            {

                objConexion.Open();
                int res = Convert.ToInt32(objCommand.ExecuteScalar());
                return res;
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
        public static Entidades.Empleado ObtenerVendedorUnoActivo(int pCodigoEmpleado)
        {
            Entidades.Empleado objEmpleado = new Entidades.Empleado();
            strProc = "SP_EMPLEADOSVENDEDORES_SELECT_UNO_ACTIVO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoEmpleado);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objEmpleado = null;
                }
                else
                {

                    objEmpleado.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objEmpleado.Legajo = objDataReader["Legajo"].ToString();
                    objEmpleado.Apellido = objDataReader["Apellido"].ToString();
                    objEmpleado.Nombres = objDataReader["Nombres"].ToString();
                    objEmpleado.Sexo = (Enumeraciones.Enumeraciones.Sexos)Convert.ToChar(objDataReader["Sexo"]);
                    objEmpleado.FechaNacimiento = Convert.ToDateTime(objDataReader["FechaNacimiento"]);
                    objEmpleado.TipoDeDocumento = (Enumeraciones.Enumeraciones.TiposDeDocumentos)Convert.ToInt32(objDataReader["CodigoTipoDocumento"]);
                    objEmpleado.NumeroDocumento = objDataReader["NumeroDocumento"].ToString();
                    objEmpleado.Domicilio.Direccion = objDataReader["Direccion"].ToString();
                    objEmpleado.Domicilio.Barrio = objDataReader["Barrio"].ToString();
                    objEmpleado.Domicilio.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                    objEmpleado.Domicilio.Localidad.Codigo = Convert.ToInt32(objDataReader["CodigoLocalidad"]);
                    objEmpleado.Domicilio.Localidad.Provincia.Codigo = Convert.ToInt32(objDataReader["CodigoProvincia"]);
                    objEmpleado.Domicilio.Localidad.Provincia.Pais.Codigo = Convert.ToInt32(objDataReader["CodigoPais"]);
                    objEmpleado.FechaIngreso = Convert.ToDateTime(objDataReader["FechaIngreso"]);
                    objEmpleado.CUIL = objDataReader["CUIL"].ToString();
                    objEmpleado.Puesto.Codigo = Convert.ToInt32(objDataReader["CodigoPuesto"]);
                    objEmpleado.Puesto.Descripcion = objDataReader["Puesto"].ToString();
                    objEmpleado.EstadoCivil = (Enumeraciones.Enumeraciones.EstadosCiviles)Convert.ToInt32(objDataReader["CodigoEstadoCivil"]);
                    objEmpleado.CantidadHijos = Convert.ToInt32(objDataReader["CantidadHijos"]);
                    objEmpleado.ObraSocial.Codigo = Convert.ToInt32(objDataReader["CodigoObraSocial"]);
                    objEmpleado.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
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
            return objEmpleado;
        }

        public static Entidades.Empleado ObtenerUnoActivo(int pCodigoEmpleado)
        {
            Entidades.Empleado objEmpleado = new Entidades.Empleado();
            strProc = "SP_EMPLEADOS_SELECT_UNO_ACTIVO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoEmpleado);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objEmpleado = null;
                }
                else
                {

                    objEmpleado.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objEmpleado.Legajo = objDataReader["Legajo"].ToString();
                    objEmpleado.Apellido = objDataReader["Apellido"].ToString();
                    objEmpleado.Nombres = objDataReader["Nombres"].ToString();
                    objEmpleado.Sexo = (Enumeraciones.Enumeraciones.Sexos)Convert.ToChar(objDataReader["Sexo"]);
                    objEmpleado.FechaNacimiento = Convert.ToDateTime(objDataReader["FechaNacimiento"]);
                    objEmpleado.TipoDeDocumento = (Enumeraciones.Enumeraciones.TiposDeDocumentos)Convert.ToInt32(objDataReader["CodigoTipoDocumento"]);
                    objEmpleado.NumeroDocumento = objDataReader["NumeroDocumento"].ToString();
                    objEmpleado.Domicilio.Direccion = objDataReader["Direccion"].ToString();
                    objEmpleado.Domicilio.Barrio = objDataReader["Barrio"].ToString();
                    objEmpleado.Domicilio.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                    objEmpleado.Domicilio.Localidad.Codigo = Convert.ToInt32(objDataReader["CodigoLocalidad"]);
                    objEmpleado.Domicilio.Localidad.Provincia.Codigo = Convert.ToInt32(objDataReader["CodigoProvincia"]);
                    objEmpleado.Domicilio.Localidad.Provincia.Pais.Codigo = Convert.ToInt32(objDataReader["CodigoPais"]);
                    objEmpleado.FechaIngreso = Convert.ToDateTime(objDataReader["FechaIngreso"]);
                    objEmpleado.CUIL = objDataReader["CUIL"].ToString();
                    objEmpleado.Puesto.Codigo = Convert.ToInt32(objDataReader["CodigoPuesto"]);
                    objEmpleado.Puesto.Descripcion = objDataReader["Puesto"].ToString();
                    objEmpleado.EstadoCivil = (Enumeraciones.Enumeraciones.EstadosCiviles)Convert.ToInt32(objDataReader["CodigoEstadoCivil"]);
                    objEmpleado.CantidadHijos = Convert.ToInt32(objDataReader["CantidadHijos"]);
                    objEmpleado.ObraSocial.Codigo = Convert.ToInt32(objDataReader["CodigoObraSocial"]);
                    objEmpleado.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
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
            return objEmpleado;
        }
        public static DataTable ObtenerComunicaciones(Entidades.Empleado pEmpleado)
        {
            DataTable dt = new DataTable();
            strProc = "SP_COMUNICACIONESPOREMPLEADO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoEmpleado", pEmpleado.Codigo);
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
        public static void Agregar(Entidades.Empleado pEmpleado, DataTable pComunicaciones, bool pEgreso)
        {
            //Creo objeto conexion
            strProc = "SP_EMPLEADOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Egreso", pEgreso);
            objCommand.Parameters.AddWithValue("@Codigo", pEmpleado.Codigo);
            objCommand.Parameters.AddWithValue("@Legajo", pEmpleado.Legajo);
            objCommand.Parameters.AddWithValue("@Apellido", pEmpleado.Apellido);
            objCommand.Parameters.AddWithValue("@Nombres", pEmpleado.Nombres);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pEmpleado.TipoDeDocumentoGuardar());
            objCommand.Parameters.AddWithValue("@NumeroDocumento", pEmpleado.NumeroDocumento);
            objCommand.Parameters.AddWithValue("@Sexo", pEmpleado.SexoParaGuardar());
            objCommand.Parameters.AddWithValue("@FechaNacimiento", pEmpleado.FechaNacimiento);
            objCommand.Parameters.AddWithValue("@Direccion", pEmpleado.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@Barrio", pEmpleado.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CodigoPostal", pEmpleado.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CodigoLocalidad", pEmpleado.Domicilio.Localidad.Codigo);
            objCommand.Parameters.AddWithValue("@FechaIngreso", pEmpleado.FechaIngreso);
            objCommand.Parameters.AddWithValue("@CUIL", pEmpleado.CUIL);
            objCommand.Parameters.AddWithValue("@CodigoPuesto", pEmpleado.Puesto.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoEstadoCivil", pEmpleado.EstadoCivilParaGuardar());
            objCommand.Parameters.AddWithValue("@CantidadHijos", pEmpleado.CantidadHijos);
            objCommand.Parameters.AddWithValue("@CodigoObraSocial", pEmpleado.ObraSocial.Codigo);
            objCommand.Parameters.AddWithValue("@EsEmpleado", pEmpleado.EsEmpleado);
            objCommand.Parameters.AddWithValue("@CodigoBanco", pEmpleado.Banco.Codigo);
            objCommand.Parameters.AddWithValue("@FueraDeConvenio", pEmpleado.FueraDeConvenio);
            objCommand.Parameters.AddWithValue("@CodigoSucursal", pEmpleado.Sucursal.Codigo);
            //objCommand.Parameters.AddWithValue("@Sueldo", pEmpleado.Sueldo);


            objCommand.Parameters.AddWithValue("@FechaEgreso", pEmpleado.Egreso.FechaEgreso);
            objCommand.Parameters.AddWithValue("@Causa", pEmpleado.Egreso.Causa);


            SqlParameter paramComunicaciones = new SqlParameter();
            paramComunicaciones.ParameterName = "@Comunicaciones";
            paramComunicaciones.Direction = ParameterDirection.Input;
            paramComunicaciones.Value = pComunicaciones;
            paramComunicaciones.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramComunicaciones);


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

        public static void Eliminar(Entidades.Empleado pEmpleado)
        {
            //Creo objeto conexion
            strProc = "SP_EMPLEADOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pEmpleado.Codigo);
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
        public static void ActualizarSueldo(Entidades.Empleado pEmpleado)
        {
            //Creo objeto conexion
            strProc = "SP_EMPLEADOSSUELDOS_UPDATE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pEmpleado.Codigo);
            objCommand.Parameters.AddWithValue("@Sueldo", pEmpleado.Sueldo);
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

        public static DataSet ObtenerEmpleadosActivos()
        {
            DataSet ds = new DataSet();
            strProc = "SP_EMPLEADOS_SELECT_ACTIVOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objDataAdapter.Fill(ds, "Empleados");
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
            return ds;
        }

        public static DataTable ObtenerNovedades()
        {
            DataTable dt = new DataTable();
            strProc = "SP_EMPLEADOS_SELECT_NOVEDADES";
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

        public static void CambiarEstadoNovedad(Entidades.Empleado pEmpleado)
        {
            strProc = "SP_EMPLEADOS_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pEmpleado.Codigo);
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

        public static void AgregarDeWeb(Entidades.Empleado pEmpleado)
        {
            //Creo objeto conexion
            strProc = "SP_EMPLEADOS_INSERT_WEB";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pEmpleado.Codigo);
            objCommand.Parameters.AddWithValue("@Legajo", pEmpleado.Legajo);
            objCommand.Parameters.AddWithValue("@Apellido", pEmpleado.Apellido);
            objCommand.Parameters.AddWithValue("@Nombres", pEmpleado.Nombres);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pEmpleado.TipoDeDocumentoGuardar());
            objCommand.Parameters.AddWithValue("@NumeroDocumento", pEmpleado.NumeroDocumento);
            objCommand.Parameters.AddWithValue("@Sexo", pEmpleado.SexoParaGuardar());
            objCommand.Parameters.AddWithValue("@FechaNacimiento", pEmpleado.FechaNacimiento);
            objCommand.Parameters.AddWithValue("@Direccion", pEmpleado.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@Barrio", pEmpleado.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CodigoPostal", pEmpleado.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CodigoLocalidad", pEmpleado.Domicilio.Localidad.Codigo);
            objCommand.Parameters.AddWithValue("@FechaIngreso", pEmpleado.FechaIngreso);
            objCommand.Parameters.AddWithValue("@CUIL", pEmpleado.CUIL);
            objCommand.Parameters.AddWithValue("@CodigoPuesto", pEmpleado.Puesto.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoEstadoCivil", pEmpleado.EstadoCivilParaGuardar());
            objCommand.Parameters.AddWithValue("@CantidadHijos", pEmpleado.CantidadHijos);
            objCommand.Parameters.AddWithValue("@CodigoObraSocial", pEmpleado.ObraSocial.Codigo);
            objCommand.Parameters.AddWithValue("@EsEmpleado", pEmpleado.EsEmpleado);
            objCommand.Parameters.AddWithValue("@CodigoBanco", pEmpleado.Banco.Codigo);
            objCommand.Parameters.AddWithValue("@Estado", pEmpleado.Estado);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
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


    }
}
