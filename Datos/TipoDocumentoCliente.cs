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
    public static class TipoDocumentoCliente
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static TipoDocumentoCliente()
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
            strProc = "SP_TIPOSDOCUMENTOSCLIENTE_SELECT";
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
            strProc = "SP_TIPOSDOCUMENTOSCLIENTE_SELECT_ACTIVOS";
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
        public static Entidades.TipoDocumentoCliente ObtenerUno(int pCodigo)
        {
            Entidades.TipoDocumentoCliente objTipo = new Entidades.TipoDocumentoCliente();
            strProc = "SP_TIPOSDOCUMENTOSCLIENTE_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objTipo.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objTipo.Descripcion = objDataReader["Descripcion"].ToString();
                objTipo.TipoDoc.Codigo= objDataReader["CodigoTipoDoc"].ToString();
                objTipo.Numerador.Codigo= Convert.ToInt32(objDataReader["CodigoNumerador"]);
                objTipo.AfectaCtaCte= Convert.ToChar(objDataReader["AfectaCtaCte"].ToString());
                objTipo.AfectaCaja = Convert.ToChar(objDataReader["AfectaCaja"].ToString());
                objTipo.AfectaIVA = Convert.ToChar(objDataReader["AfectaIVA"].ToString());
                objTipo.TipoDiscIVA = Convert.ToChar(objDataReader["TipoDiscIVA"].ToString());
                
                     objTipo.Numerador.Letra= objDataReader["Letra"].ToString();
                objTipo.MiPYME = Convert.ToBoolean(objDataReader["MiPYME"]);
                objTipo.Numerador.PuntoVenta = Convert.ToInt32(objDataReader["PuntoVenta"]);
                    objTipo.Numerador.Numero= Convert.ToInt32(objDataReader["Numero"]);
                objTipo.TipoDocLotes = Convert.ToBoolean(objDataReader["NCLotes"]);
                objTipo.Electronico = Convert.ToBoolean(objDataReader["Electronico"]);
                objTipo.FacturasM = Convert.ToBoolean(objDataReader["FacturasM"]);
                Enumeraciones.Enumeraciones.Estados estado;

                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objTipo.Estado = estado;

                objTipo.TiposInscripcion = TipoInscripcion.ObtenerTodos(pCodigo);


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
            return objTipo;
        }

        public static Entidades.TipoDocumentoCliente ObtenerDeCliente(int pCodigoCliente, Entidades.TipoDocumentoCliente pTipoDocumentoCliente, double pTotal, bool pVacios)
        {
            Entidades.TipoDocumentoCliente objTipo = new Entidades.TipoDocumentoCliente();
            strProc = "SP_TIPODECOMPROBANTEYNUMERO_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoCliente", pCodigoCliente);
            objCommand.Parameters.AddWithValue("@CodigoTipoDoc", pTipoDocumentoCliente.TipoDoc.Codigo);
            objCommand.Parameters.AddWithValue("@AfectaCaja", pTipoDocumentoCliente.AfectaCaja);
            objCommand.Parameters.AddWithValue("@AfectaCtaCte", pTipoDocumentoCliente.AfectaCtaCte);
            objCommand.Parameters.AddWithValue("@AfectaStock", pTipoDocumentoCliente.AfectaStock);
            objCommand.Parameters.AddWithValue("@Electronico", pTipoDocumentoCliente.Electronico);
            objCommand.Parameters.AddWithValue("@FacturasM", pTipoDocumentoCliente.FacturasM);
            objCommand.Parameters.AddWithValue("@TipoDocLotes", pTipoDocumentoCliente.TipoDocLotes);
            objCommand.Parameters.AddWithValue("@MiPYME", pTipoDocumentoCliente.MiPYME);
            objCommand.Parameters.AddWithValue("@TotalFactura", pTotal);
            objCommand.Parameters.AddWithValue("@Vacios", pVacios);

            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objTipo = null;
                }
                else
                {
                    objTipo.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objTipo.Descripcion = objDataReader["Descripcion"].ToString();
                    objTipo.TipoDoc.Codigo = objDataReader["CodigoTipoDoc"].ToString();
                    objTipo.Numerador.Codigo = Convert.ToInt32(objDataReader["CodigoNumerador"]);
                    objTipo.Numerador.Letra= objDataReader["Letra"].ToString();
                    objTipo.Numerador.PuntoVenta = Convert.ToInt32(objDataReader["PuntoVenta"]);
                    objTipo.Numerador.Numero= Convert.ToInt32(objDataReader["Numero"]);
                    objTipo.AfectaCtaCte = Convert.ToChar(objDataReader["AfectaCtaCte"].ToString());
                    objTipo.AfectaCaja = Convert.ToChar(objDataReader["AfectaCaja"].ToString());
                    objTipo.AfectaIVA = Convert.ToChar(objDataReader["AfectaIVA"].ToString());
                    objTipo.TipoDiscIVA = Convert.ToChar(objDataReader["TipoDiscIVA"].ToString());
                    objTipo.Electronico = Convert.ToBoolean(objDataReader["Electronico"]);
                    objTipo.MiPYME= Convert.ToBoolean(objDataReader["MiPYME"]);
                    objTipo.TipoDocLotes= Convert.ToBoolean(objDataReader["NCLotes"]);
                    Enumeraciones.Enumeraciones.Estados estado;

                    Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                    objTipo.Estado = estado;
                }
                //objTipo.TiposInscripcion = TipoInscripcion.ObtenerTodos(pCodigo);


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
            return objTipo;
        }

        public static void Agregar(Entidades.TipoDocumentoCliente pTipo)
        {
            //Creo objeto conexion
            strProc = "SP_TIPOSDOCUMENTOSCLIENTE_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pTipo.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pTipo.Descripcion);
            objCommand.Parameters.AddWithValue("@CodigoTipoDoc", pTipo.TipoDoc.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoNumerador", pTipo.Numerador.Codigo);
            objCommand.Parameters.AddWithValue("@AfectaCtaCte", pTipo.AfectaCtaCte);
            objCommand.Parameters.AddWithValue("@AfectaCaja", pTipo.AfectaCaja);
            objCommand.Parameters.AddWithValue("@AfectaIVA", pTipo.AfectaIVA);
            objCommand.Parameters.AddWithValue("@TipoDiscIVA", pTipo.TipoDiscIVA);
            objCommand.Parameters.AddWithValue("@Electronico", pTipo.Electronico);
            objCommand.Parameters.AddWithValue("@FacturasM", pTipo.FacturasM);

            DataTable dtTipiIVA = new DataTable();
            DataColumn column;

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoTipoInscripcion";
            dtTipiIVA.Columns.Add(column);

            foreach (Entidades.TipoInscripcion ti in pTipo.TiposInscripcion) {
                dtTipiIVA.Rows.Add(ti.Codigo);
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@TiposInscripcion";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtTipiIVA;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);

            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Tipo Documento de Cliente, ya existe!!");
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

        public static void Eliminar(Entidades.TipoDocumentoCliente pTipo)
        {
            //Creo objeto conexion
            strProc = "SP_TIPOSDOCUMENTOSCLIENTE_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pTipo.Codigo);
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

        public static DataTable ObtenerFacturasManuales()
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSDOCUMENTOSCLIENTE_FACTURASMANUALES_SELECT";
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

        public static DataTable ObtenerTodosDeTipoPagos(int pCodigoTipoInscripcion)
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSDOCUMENTOSCLIENTES_PAGOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoTipoInscripcion);

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

        public static DataTable ObtenerTiposPorClientes(int pCodigoTipoInscripcion)
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSDOCUMENTOSCLIENTESPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoTipoInscripcion);

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
    }
}
