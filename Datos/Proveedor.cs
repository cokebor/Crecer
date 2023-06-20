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
    public class Proveedor
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static Proveedor()
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
            strProc = "SP_PROVEEDORES_SELECT";
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
            strProc = "SP_PROVEEDORES_SELECT_ACTIVOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsProveedores";
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
        public static Entidades.Proveedor ObtenerUno(int pCodigoProveedor)
        {
            Entidades.Proveedor objProveedor = new Entidades.Proveedor();
            strProc = "SP_PROVEEDORES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoProveedor);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();

                if (objDataReader.HasRows.Equals(false)) {
                    objProveedor = null;
                }else{ 
                objProveedor.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objProveedor.Nombre = objDataReader["Nombre"].ToString();
                objProveedor.TipoInscripcion.Codigo= Convert.ToInt32(objDataReader["CodigoTipoInscripcion"]);
                objProveedor.CUIT = objDataReader["CUIT"].ToString();
                objProveedor.IngresosBrutos = objDataReader["IngresosBrutos"].ToString();
                objProveedor.Domicilio.Direccion = objDataReader["Direccion"].ToString();
                objProveedor.Domicilio.Numero = objDataReader["Numero"].ToString();
                objProveedor.Domicilio.Barrio = objDataReader["Barrio"].ToString();
                objProveedor.Domicilio.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                objProveedor.Domicilio.Localidad.Codigo = Convert.ToInt32(objDataReader["CodigoLocalidad"]);
                objProveedor.Domicilio.Localidad.Provincia.Codigo = Convert.ToInt32(objDataReader["CodigoProvincia"]);
                objProveedor.Domicilio.Localidad.Provincia.Pais.Codigo = Convert.ToInt32(objDataReader["CodigoPais"]);
                objProveedor.CategoriaProveedor.Codigo= Convert.ToInt32(objDataReader["CodigoCategoriaProveedor"]);
                objProveedor.Observaciones= objDataReader["Observaciones"].ToString();
                objProveedor.Comision = Convert.ToDouble(objDataReader["Comision"]);
                objProveedor.FormaPago= Convert.ToBoolean(objDataReader["FormaPago"]);
                objProveedor.InscriptoGanancias = Convert.ToBoolean(objDataReader["InscriptoGanancias"]);
                objProveedor.TipoContribuyente.Codigo = Convert.ToInt32(objDataReader["CodigoTipoContribuyente"]);
                objProveedor.TipoContribuyente.PorcentajeRetencion = Convert.ToDouble(objDataReader["PorcentajeRetencion"]);
                objProveedor.RiesgoFiscal = Convert.ToBoolean(objDataReader["RiesgoFiscal"]);
                objProveedor.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);

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
            return objProveedor;
        }

        public static Entidades.Proveedor ObtenerUnoActivo(int pCodigoProveedor)
        {
            Entidades.Proveedor objProveedor = new Entidades.Proveedor();
            strProc = "SP_PROVEEDORES_SELECT_UNO_ACTIVO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoProveedor);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objProveedor = null;
                }
                else
                {
                    objProveedor.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objProveedor.Nombre = objDataReader["Nombre"].ToString();
                    objProveedor.TipoInscripcion.Codigo = Convert.ToInt32(objDataReader["CodigoTipoInscripcion"]);
                    objProveedor.CUIT = objDataReader["CUIT"].ToString();
                    objProveedor.IngresosBrutos = objDataReader["IngresosBrutos"].ToString();
                    objProveedor.Domicilio.Direccion = objDataReader["Direccion"].ToString();
                    objProveedor.Domicilio.Numero = objDataReader["Numero"].ToString();
                    objProveedor.Domicilio.Barrio = objDataReader["Barrio"].ToString();
                    objProveedor.Domicilio.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                    objProveedor.Domicilio.Localidad.Codigo = Convert.ToInt32(objDataReader["CodigoLocalidad"]);
                    objProveedor.Domicilio.Localidad.Provincia.Codigo = Convert.ToInt32(objDataReader["CodigoProvincia"]);
                    objProveedor.Domicilio.Localidad.Provincia.Pais.Codigo = Convert.ToInt32(objDataReader["CodigoPais"]);
                    objProveedor.CategoriaProveedor.Codigo = Convert.ToInt32(objDataReader["CodigoCategoriaProveedor"]);
                    objProveedor.Observaciones = objDataReader["Observaciones"].ToString();
                    objProveedor.Comision = Convert.ToDouble(objDataReader["Comision"]);
                    objProveedor.FormaPago = Convert.ToBoolean(objDataReader["FormaPago"]);
                    objProveedor.InscriptoGanancias= Convert.ToBoolean(objDataReader["InscriptoGanancias"]);
                    /*objProveedor.TipoContribuyente.Codigo = Convert.ToInt32(objDataReader["CodigoTipoContribuyente"]);
                    objProveedor.TipoContribuyente.PorcentajeRetencion = Convert.ToDouble(objDataReader["PorcentajeRetencion"]);*/
                    objProveedor.TipoContribuyente=Datos.TipoContribuyente.ObtenerUno(Convert.ToInt32(objDataReader["CodigoTipoContribuyente"]));
                    objProveedor.RiesgoFiscal = Convert.ToBoolean(objDataReader["RiesgoFiscal"]);
                    objProveedor.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
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
            return objProveedor;

        }
        public static DataTable ObtenerComunicaciones(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_COMUNICACIONESPORPROVEEDOR_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
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
        public static void Agregar(Entidades.Proveedor pProveedor, DataTable pComunicaciones)
        {
            //Creo objeto conexion
            strProc = "SP_PROVEEDORES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Nombre", pProveedor.Nombre);
            objCommand.Parameters.AddWithValue("@CodigoTipoInscripcion", pProveedor.TipoInscripcion.Codigo);
            objCommand.Parameters.AddWithValue("@CUIT", pProveedor.CUIT);
            objCommand.Parameters.AddWithValue("@IngresosBrutos", pProveedor.IngresosBrutos);
            objCommand.Parameters.AddWithValue("@Direccion", pProveedor.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@Numero", pProveedor.Domicilio.Numero);
            objCommand.Parameters.AddWithValue("@Barrio", pProveedor.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CodigoPostal", pProveedor.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CodigoLocalidad", pProveedor.Domicilio.Localidad.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCategoriaProveedor", pProveedor.CategoriaProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Observaciones", pProveedor.Observaciones);
            objCommand.Parameters.AddWithValue("@Comision", pProveedor.Comision);
            objCommand.Parameters.AddWithValue("@FormaPago", pProveedor.FormaPago);
            objCommand.Parameters.AddWithValue("@InscriptoGanancias", pProveedor.InscriptoGanancias);
            objCommand.Parameters.AddWithValue("@CodigoTipoContribuyente", pProveedor.TipoContribuyente.Codigo);
            objCommand.Parameters.AddWithValue("@RiesgoFiscal", pProveedor.RiesgoFiscal);

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

        public static void Eliminar(Entidades.Proveedor pProveedor)
        {
            //Creo objeto conexion
            strProc = "SP_PROVEEDORES_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pProveedor.Codigo);
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
            strProc = "SP_PROVEEDORES_SELECT_NOVEDADES";
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

        public static void CambiarEstadoNovedad(Entidades.Proveedor pProveedor)
        {
            strProc = "SP_PROVEEDORES_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pProveedor.Codigo);
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

        public static void AgregarDeWeb(Entidades.Proveedor pProveedor)
        {
            //Creo objeto conexion
            strProc = "SP_PROVEEDORES_INSERT_WEB";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Nombre", pProveedor.Nombre);
            objCommand.Parameters.AddWithValue("@CodigoTipoInscripcion", pProveedor.TipoInscripcion.Codigo);
            objCommand.Parameters.AddWithValue("@CUIT", pProveedor.CUIT);
            objCommand.Parameters.AddWithValue("@CodigoTipoContribuyente", pProveedor.TipoContribuyente.Codigo);
            objCommand.Parameters.AddWithValue("@RiesgoFiscal", pProveedor.RiesgoFiscal);
            objCommand.Parameters.AddWithValue("@IngresosBrutos", pProveedor.IngresosBrutos);
            objCommand.Parameters.AddWithValue("@Direccion", pProveedor.Domicilio.Direccion);
            objCommand.Parameters.AddWithValue("@Numero", pProveedor.Domicilio.Numero);
            objCommand.Parameters.AddWithValue("@Barrio", pProveedor.Domicilio.Barrio);
            objCommand.Parameters.AddWithValue("@CodigoPostal", pProveedor.Domicilio.CodigoPostal);
            objCommand.Parameters.AddWithValue("@CodigoLocalidad", pProveedor.Domicilio.Localidad.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCategoriaProveedor", pProveedor.CategoriaProveedor.Codigo);
            objCommand.Parameters.AddWithValue("@Observaciones", pProveedor.Observaciones);
            objCommand.Parameters.AddWithValue("@Comision", pProveedor.Comision);
            objCommand.Parameters.AddWithValue("@FormaPago", pProveedor.FormaPago);
            objCommand.Parameters.AddWithValue("@InscriptoGanancias", pProveedor.InscriptoGanancias);

            objCommand.Parameters.AddWithValue("@Estado", pProveedor.Estado);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Proveedor, ya existe!!");
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

        public static DataTable ObtenerDataTable(Entidades.Proveedor pProveedor)
        {
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            strProc = "SP_PROVEEDORES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pProveedor.Codigo);
            try
            {
                dt.TableName = "dsProveedor";
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
    }
}
