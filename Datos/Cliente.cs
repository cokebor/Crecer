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
    public static class Cliente
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static Cliente()
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
            strProc = "SP_CLIENTES_SELECT";
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
            strProc = "SP_CLIENTES_SELECT_ACTIVOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsClientes";
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
        public static Entidades.Cliente ObtenerUno(int pCodigoCliente)
        {
            Entidades.Cliente objCliente = new Entidades.Cliente();
            strProc = "SP_CLIENTES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoCliente);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objCliente = null;
                }
                else
                {
                    objCliente.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objCliente.Nombre = objDataReader["Nombre"].ToString();
                    objCliente.CUIT = objDataReader["CUIT"].ToString();
                    objCliente.FechaValidacionCUIT = Convert.ToDateTime(objDataReader["FechaValidacionCUIT"]);
                    objCliente.TipoInscripcion.Codigo = Convert.ToInt32(objDataReader["CodigoTipoInscripcion"]);
                    objCliente.Domicilio.Direccion = objDataReader["Direccion"].ToString();
                    objCliente.Domicilio.Numero = objDataReader["Numero"].ToString();
                    objCliente.Domicilio.Barrio = objDataReader["Barrio"].ToString();
                    objCliente.Domicilio.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                    objCliente.Domicilio.Localidad.Codigo = Convert.ToInt32(objDataReader["CodigoLocalidad"]);
                    objCliente.Domicilio.Localidad.Provincia.Codigo = Convert.ToInt32(objDataReader["CodigoProvincia"]);
                    objCliente.Domicilio.Localidad.Provincia.Pais.Codigo = Convert.ToInt32(objDataReader["CodigoPais"]);
                    objCliente.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaPorKilos"]);
                    objCliente.Observaciones = objDataReader["Observaciones"].ToString();
                    objCliente.Comision = Convert.ToDouble(objDataReader["Comision"]);
                    objCliente.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
                    objCliente.Original = Convert.ToBoolean(objDataReader["Original"]);
                    objCliente.Duplicado = Convert.ToBoolean(objDataReader["Duplicado"]);
                    objCliente.Triplicado = Convert.ToBoolean(objDataReader["Triplicado"]);
                    objCliente.FacturacionPorCubeta = Convert.ToBoolean(objDataReader["FacturacionPorCubeta"]);
                    objCliente.MiPYME = Convert.ToBoolean(objDataReader["MiPYME"]);
                    objCliente.TipoContribuyente.Codigo = Convert.ToInt32(objDataReader["CodigoTipoContribuyente"]);
                    objCliente.TipoContribuyente.PorcentajePercepcion = Convert.ToDouble(objDataReader["PorcentajePercepcion"]);
                    objCliente.RiesgoFiscal = Convert.ToBoolean(objDataReader["RiesgoFiscal"]);
                    objCliente.TipoDocumento.Codigo= Convert.ToInt32(objDataReader["CodigoTipoDocumento"]);
                    //objCliente.DescuentoEnFactura = Convert.ToBoolean(objDataReader["DescuentoEnFactura"]);
                    objCliente.CtaCte = Convert.ToBoolean(objDataReader["CtaCte"]);
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
            return objCliente;
        }

        public static List<Entidades.SucursalCliente> ObtenerSucursales(Entidades.Cliente objECliente)
        {
            List<Entidades.SucursalCliente> lista = new List<Entidades.SucursalCliente>();
            try
            {
                Entidades.SucursalCliente sucursal;
                strProc = "SP_SUCURSALESCLIENTES_SELECT";
                objCommand = new SqlCommand(strProc, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@CodigoCliente", objECliente.Codigo);
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                while (objDataReader.Read())
                {
                    sucursal = new Entidades.SucursalCliente();
                    sucursal.CodigoSucursal = Convert.ToInt32(objDataReader["CodigoSucursal"]);
                    sucursal.NombreSucursal = objDataReader["NombreSucursal"].ToString();
                    sucursal.Domicilio.Direccion= objDataReader["Direccion"].ToString();
                    sucursal.Domicilio.Numero= objDataReader["Numero"].ToString();
                    sucursal.Domicilio.Barrio = objDataReader["Barrio"].ToString();
                    sucursal.Domicilio.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                    sucursal.Domicilio.Localidad.Codigo = Convert.ToInt32(objDataReader["CodigoLocalidad"].ToString());
                    sucursal.Domicilio.Localidad.Nombre = objDataReader["Localidad"].ToString();
                    sucursal.Domicilio.Localidad.Provincia.Codigo = Convert.ToInt32(objDataReader["CodigoProvincia"].ToString());
                    sucursal.Domicilio.Localidad.Provincia.Nombre = objDataReader["Provincia"].ToString();
                    sucursal.Domicilio.Localidad.Provincia.Pais.Codigo = Convert.ToInt32(objDataReader["CodigoPais"].ToString());
                    sucursal.Domicilio.Localidad.Provincia.Pais.Descripcion = objDataReader["Pais"].ToString();

                    lista.Add(sucursal);
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

        public static Entidades.Cliente ObtenerUnoActivo(int pCodigoCliente)
        {
            Entidades.Cliente objCliente = new Entidades.Cliente();
            strProc = "SP_CLIENTES_SELECT_UNO_ACTIVO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoCliente);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objCliente = null;
                }
                else
                {
                    objCliente.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objCliente.Nombre = objDataReader["Nombre"].ToString();
                    objCliente.CUIT = objDataReader["CUIT"].ToString();
                    objCliente.FechaValidacionCUIT = Convert.ToDateTime(objDataReader["FechaValidacionCUIT"]);
                    objCliente.TipoInscripcion.Codigo = Convert.ToInt32(objDataReader["CodigoTipoInscripcion"]);
                    objCliente.TipoInscripcion.MontoMaximo = Convert.ToDouble(objDataReader["MontoMaximo"]);
                    objCliente.TipoInscripcion.Sigla = objDataReader["Sigla"].ToString();
                    objCliente.Domicilio.Direccion = objDataReader["Direccion"].ToString();
                    objCliente.Domicilio.Numero = objDataReader["Numero"].ToString();
                    objCliente.Domicilio.Barrio = objDataReader["Barrio"].ToString();
                    objCliente.Domicilio.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                    objCliente.Domicilio.Localidad.Codigo = Convert.ToInt32(objDataReader["CodigoLocalidad"]);
                    objCliente.Domicilio.Localidad.Provincia.Codigo = Convert.ToInt32(objDataReader["CodigoProvincia"]);
                    objCliente.Domicilio.Localidad.Provincia.Pais.Codigo = Convert.ToInt32(objDataReader["CodigoPais"]);
                    objCliente.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaPorKilos"]);
                    objCliente.Observaciones = objDataReader["Observaciones"].ToString();
                    objCliente.Comision = Convert.ToDouble(objDataReader["Comision"]);
                    objCliente.Deuda = Convert.ToDouble(objDataReader["Deuda"]);
                    objCliente.Original = Convert.ToBoolean(objDataReader["Original"]);
                    objCliente.Duplicado = Convert.ToBoolean(objDataReader["Duplicado"]);
                    objCliente.Triplicado = Convert.ToBoolean(objDataReader["Triplicado"]);
                    objCliente.FacturacionPorCubeta = Convert.ToBoolean(objDataReader["FacturacionPorCubeta"]);
                    objCliente.MiPYME = Convert.ToBoolean(objDataReader["MiPYME"]);
                    //objCliente.DescuentoEnFactura = Convert.ToBoolean(objDataReader["DescuentoEnFactura"]);
                    objCliente.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
                    objCliente.TipoContribuyente.Codigo = Convert.ToInt32(objDataReader["CodigoTipoContribuyente"]);
                    objCliente.TipoContribuyente.PorcentajePercepcion = Convert.ToDouble(objDataReader["PorcentajePercepcion"]);
                    objCliente.RiesgoFiscal = Convert.ToBoolean(objDataReader["RiesgoFiscal"]);
                    objCliente.TipoDocumento.Codigo= Convert.ToInt32(objDataReader["CodigoTipoDocumento"]);
                    objCliente.CtaCte = Convert.ToBoolean(objDataReader["CtaCte"]);

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
            return objCliente;
        }
        public static DataTable ObtenerComunicaciones(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_COMUNICACIONESPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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

        public static DataTable ObtenerEmails(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_EMAILSPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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
        public static DataTable ObtenerDescuentos(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_DESCUENTOSPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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
        public static void Agregar(Entidades.Cliente pCliente, DataTable pComunicaciones, DataTable pDescuentos)
        {
            //Creo objeto conexion
            strProc = "SP_CLIENTES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pCliente.TipoDocumento.Codigo);
            objCommand.Parameters.AddWithValue("@CUIT", pCliente.CUIT);
            objCommand.Parameters.AddWithValue("@FechaValidacion", pCliente.FechaValidacionCUIT);
            objCommand.Parameters.AddWithValue("@CodigoTipoInscripcion", pCliente.TipoInscripcion.Codigo);
            objCommand.Parameters.AddWithValue("@Direccion", pCliente.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@Numero", pCliente.Domicilio.Numero);
            objCommand.Parameters.AddWithValue("@Barrio", pCliente.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CodigoPostal", pCliente.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CodigoLocalidad", pCliente.Domicilio.Localidad.Codigo);
            objCommand.Parameters.AddWithValue("@FacturaKilos", pCliente.FacturaKilos);
            objCommand.Parameters.AddWithValue("@Observaciones", pCliente.Observaciones);
            objCommand.Parameters.AddWithValue("@Comision", pCliente.Comision);
            objCommand.Parameters.AddWithValue("@Original", pCliente.Original);
            objCommand.Parameters.AddWithValue("@Duplicado", pCliente.Duplicado);
            objCommand.Parameters.AddWithValue("@Triplicado", pCliente.Triplicado);
            objCommand.Parameters.AddWithValue("@FacturacionPorCubeta", pCliente.FacturacionPorCubeta);
            objCommand.Parameters.AddWithValue("@MiPYME", pCliente.MiPYME);
            objCommand.Parameters.AddWithValue("@CodigoTipoContribuyente", pCliente.TipoContribuyente.Codigo);
            objCommand.Parameters.AddWithValue("@RiesgoFiscal", pCliente.RiesgoFiscal);
            //objCommand.Parameters.AddWithValue("@DescuentoEnFactura", pCliente.DescuentoEnFactura);
            objCommand.Parameters.AddWithValue("@CtaCte", pCliente.CtaCte);

            SqlParameter paramComunicaciones = new SqlParameter();
            paramComunicaciones.ParameterName = "@Comunicaciones";
            paramComunicaciones.Direction = ParameterDirection.Input;
            paramComunicaciones.Value = pComunicaciones;
            paramComunicaciones.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramComunicaciones);

            SqlParameter paramDescuentos = new SqlParameter();
            paramDescuentos.ParameterName = "@Descuentos";
            paramDescuentos.Direction = ParameterDirection.Input;
            paramDescuentos.Value = pDescuentos;
            paramDescuentos.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramDescuentos);


            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Cliente, ya existe!!");
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

        public static void Eliminar(Entidades.Cliente pCliente)
        {
            //Creo objeto conexion
            strProc = "SP_CLIENTES_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCliente.Codigo);
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
        public static DataTable ObtenerNovedades()
        {
            DataTable dt = new DataTable();
            strProc = "SP_CLIENTES_SELECT_NOVEDADES";
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

        public static void CambiarEstadoNovedad(Entidades.Cliente pCliente)
        {
            strProc = "SP_CLIENTES_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCliente.Codigo);
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

        public static void AgregarDeWeb(Entidades.Cliente pCliente)
        {
            //Creo objeto conexion
            strProc = "SP_CLIENTES_INSERT_WEB";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCliente.Codigo);
            objCommand.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
            objCommand.Parameters.AddWithValue("@CodigoTipoDocumento", pCliente.TipoDocumento.Codigo);
            objCommand.Parameters.AddWithValue("@CUIT", pCliente.CUIT);
            objCommand.Parameters.AddWithValue("@FechaValidacionCUIT", pCliente.FechaValidacionCUIT);
            objCommand.Parameters.AddWithValue("@CodigoTipoInscripcion", pCliente.TipoInscripcion.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoContribuyente", pCliente.TipoContribuyente.Codigo);
            objCommand.Parameters.AddWithValue("@RiesgoFiscal", pCliente.RiesgoFiscal);
            /*objCommand.Parameters.AddWithValue("@Direccion", pCliente.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@Numero", pCliente.Domicilio.Numero);
            objCommand.Parameters.AddWithValue("@Barrio", pCliente.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CodigoPostal", pCliente.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CodigoLocalidad", pCliente.Domicilio.Localidad.Codigo);*/
            objCommand.Parameters.AddWithValue("@FacturaPorKilos", pCliente.FacturaKilos);
            objCommand.Parameters.AddWithValue("@Observaciones", pCliente.Observaciones);
            objCommand.Parameters.AddWithValue("@Comision", pCliente.Comision);
            objCommand.Parameters.AddWithValue("@Original", pCliente.Original);
            objCommand.Parameters.AddWithValue("@Duplicado", pCliente.Duplicado);
            objCommand.Parameters.AddWithValue("@Triplicado", pCliente.Triplicado);
            objCommand.Parameters.AddWithValue("@FacturaPorCubetas", pCliente.FacturacionPorCubeta);
            objCommand.Parameters.AddWithValue("@MiPYME", pCliente.MiPYME);
            objCommand.Parameters.AddWithValue("@Estado", pCliente.Estado);

            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Cliente, ya existe!!");
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
