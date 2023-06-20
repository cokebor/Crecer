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
    public static class TipoDocumentoProveedor
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static TipoDocumentoProveedor()
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
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDORES_SELECT";
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

        public static List<Entidades.TipoDocumentoProveedor> ObtenerTodosConImpuestos(char pImpuesto)
        {
            List<Entidades.TipoDocumentoProveedor> lista = new List<Entidades.TipoDocumentoProveedor>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.TipoDocumentoProveedor objETipo;
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDORESIMPUESTOS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Impuesto", pImpuesto);

            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();

                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objETipo = new Entidades.TipoDocumentoProveedor();
                        objETipo.Codigo= Convert.ToInt32(objDataReader["CodigoTipoDocumentoProveedor"]);

                        objETipo.Impuestos = TipoProveedorImpuestos.ObtenerTodosProveedor(objETipo.Codigo, pImpuesto);

                        lista.Add(objETipo);
                    }
                }
                else
                {
                    lista = null;
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
        /*
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
                }*/
        public static Entidades.TipoDocumentoProveedor ObtenerUno(int pCodigo)
        {
            Entidades.TipoDocumentoProveedor objTipo = new Entidades.TipoDocumentoProveedor();
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDORES_SELECT_UNO";
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
                objTipo.Numerador.Codigo = Convert.ToInt32(objDataReader["CodigoNumerador"]);
                objTipo.Numerador.Letra = objDataReader["Letra"].ToString();
                objTipo.Numerador.PuntoVenta = Convert.ToInt32(objDataReader["PuntoVenta"]);
                objTipo.Numerador.Numero = Convert.ToInt32(objDataReader["Numero"]);
                objTipo.AfectaCtaCte= Convert.ToChar(objDataReader["AfectaCtaCte"].ToString());
                objTipo.AfectaCaja = Convert.ToChar(objDataReader["AfectaCaja"].ToString());
                objTipo.AfectaIVA = Convert.ToChar(objDataReader["AfectaIVA"].ToString());
                objTipo.TipoDiscIVA = Convert.ToChar(objDataReader["TipoDiscIVA"].ToString());
                objTipo.Letra = Convert.ToChar(objDataReader["Letra2"].ToString());
                Enumeraciones.Enumeraciones.Estados estado;

                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objTipo.Estado = estado;

                objTipo.TiposInscripcion = TipoInscripcion.ObtenerTodosProveedor(pCodigo);
                objTipo.Impuestos = TipoProveedorImpuestos.ObtenerTodosProveedor(pCodigo);

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

        public static DataTable ObtenerTiposPorProveedores(int pCodigoTipoInscripcion)
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDORESPORPROVEEDOR_SELECT";
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

        public static DataTable ObtenerTodosDeTipoFacturas(int pCodigoTipoInscripcion, bool pFormaPago)
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDORES_FACTURAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoTipoInscripcion);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FormaPago", pFormaPago);

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
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDORES_PAGOS_SELECT";
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
        
        public static Entidades.TipoDocumentoProveedor ObtenerDeProveedorLiquidaciones(int pCodigoTipoInscripcion, Entidades.TipoDocumentoProveedor pTipoDocumentoProveedor)
        {
            Entidades.TipoDocumentoProveedor objTipo = new Entidades.TipoDocumentoProveedor();
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDORES_LIQUIDACIONES_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoTipoInscripcion);
            objCommand.Parameters.AddWithValue("@AfectaCtaCte",pTipoDocumentoProveedor.AfectaCtaCte);

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

        public static void Agregar(Entidades.TipoDocumentoProveedor pTipo)
        {
            //Creo objeto conexion
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDORES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pTipo.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pTipo.Descripcion);
            objCommand.Parameters.AddWithValue("@Letra", pTipo.Letra);
            objCommand.Parameters.AddWithValue("@CodigoTipoDoc", pTipo.TipoDoc.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoNumerador", pTipo.Numerador.Codigo);
            objCommand.Parameters.AddWithValue("@AfectaCtaCte", pTipo.AfectaCtaCte);
            objCommand.Parameters.AddWithValue("@AfectaCaja", pTipo.AfectaCaja);
            objCommand.Parameters.AddWithValue("@AfectaIVA", pTipo.AfectaIVA);
            objCommand.Parameters.AddWithValue("@TipoDiscIVA", pTipo.TipoDiscIVA);

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


            DataTable dtImpuestos = new DataTable();
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoImpuesto";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn(); 
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Porcentaje";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Char");
            column.ColumnName = "Del";
            dtImpuestos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoRegimen";
            dtImpuestos.Columns.Add(column);

            foreach (Entidades.TipoDocumentoProveedorImpuesto i in pTipo.Impuestos)
            {
                dtImpuestos.Rows.Add(i.Impuesto.Codigo, i.Porcentaje, i.Del, i.Regimen.Codigo);
            }

            paramItems = new SqlParameter();
            paramItems.ParameterName = "@Impuestos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtImpuestos;
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
                    throw new Exception("No se pude agregar Tipo Documento de Proveedor, ya existe!!");
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
        
        public static void Eliminar(Entidades.TipoDocumentoProveedor pTipo)
        {
            //Creo objeto conexion
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDOR_DELETE";
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

        public static Entidades.TipoDocumentoProveedor ObtenerDeProveedor(int pCodigoProveedor, Entidades.TipoDocumentoProveedor pTipoDocumentoProveedor)
        {
            Entidades.TipoDocumentoProveedor objTipo = new Entidades.TipoDocumentoProveedor();
            strProc = "SP_SALDOSINICIALESPROVEEDORES_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoProveedor", pCodigoProveedor);
            objCommand.Parameters.AddWithValue("@CodigoTipoDoc", pTipoDocumentoProveedor.TipoDoc.Codigo);
            objCommand.Parameters.AddWithValue("@AfectaCaja", pTipoDocumentoProveedor.AfectaCaja);
            objCommand.Parameters.AddWithValue("@AfectaCtaCte", pTipoDocumentoProveedor.AfectaCtaCte);

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
                    objTipo.Numerador.Letra = objDataReader["Letra"].ToString();
                    objTipo.Numerador.PuntoVenta = Convert.ToInt32(objDataReader["PuntoVenta"]);
                    objTipo.Numerador.Numero = Convert.ToInt32(objDataReader["Numero"]);
                    objTipo.AfectaCtaCte = Convert.ToChar(objDataReader["AfectaCtaCte"].ToString());
                    objTipo.AfectaCaja = Convert.ToChar(objDataReader["AfectaCaja"].ToString());
                    objTipo.AfectaIVA = Convert.ToChar(objDataReader["AfectaIVA"].ToString());
                    objTipo.TipoDiscIVA = Convert.ToChar(objDataReader["TipoDiscIVA"].ToString());



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


        public static DataTable ObtenerTodosAAnular(int pCodigoProveedor)
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSDOCUMENTOSPROVEEDORESANULAR_FACTURAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pCodigoProveedor);

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
