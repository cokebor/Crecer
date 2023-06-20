using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public static class Producto
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        static Producto()
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
            strProc = "SP_PRODUCTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsStock";
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

        public static DataTable ObtenerParaCargarPrecios(Entidades.Empresa pEmpresa, bool pSaldoEnSucursales)
        {
            DataTable dt = new DataTable();
            strProc = "SP_PRECIOSCARGA_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CODIGOSUCURSAL", pEmpresa.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@SALDOENSUCURSALES", pSaldoEnSucursales);
            try
            {
                dt.TableName = "dsPrecios";
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
        public static DataTable ObtenerTodosConSaldo()
        {
            DataTable dt = new DataTable();
            strProc = "SP_PRODUCTOSCONSALDO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsStock";
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
            strProc = "SP_PRODUCTOS_SELECT_ACTIVOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dt.TableName = "dsProductos";
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
        public static Entidades.Producto ObtenerUno(int pCodigoProducto)
        {
            Entidades.Producto objProducto = new Entidades.Producto();
            strProc = "SP_PRODUCTOS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoProducto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objProducto = null;
                }
                else
                {
                    objProducto.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objProducto.RubroProducto.Codigo = Convert.ToInt32(objDataReader["CodigoRubroProducto"]);
                    objProducto.RubroProducto.Descripcion = objDataReader["RubroProducto"].ToString();
                    objProducto.Descripcion = objDataReader["Descripcion"].ToString();
                    objProducto.UnidadDeMedida = objDataReader["UnidadMedida"].ToString();
                    objProducto.Peso = Convert.ToDouble(objDataReader["Peso"]);
                    objProducto.StockMinimo = Convert.ToInt32(objDataReader["StockMinimo"]);
                    objProducto.Stock = Convert.ToInt32(objDataReader["Stock"]);
                    objProducto.CodigoBarra = objDataReader["CodigoBarra"].ToString();
                    objProducto.PorcentajeIVA = Convert.ToDouble(objDataReader["PorcentajeIva"]);
                    objProducto.FacturacionPorCubeta = Convert.ToBoolean(objDataReader["FacturacionPorCubeta"]);
                    objProducto.Vacio = Convert.ToBoolean(objDataReader["Vacio"]);
                    objProducto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
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
            return objProducto;
        }

        public static Entidades.Producto ObtenerUnoActivo(int pCodigoProducto)
        {
            Entidades.Producto objProducto = new Entidades.Producto();
            strProc = "SP_PRODUCTOS_SELECT_UNO_ACTIVO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoProducto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objProducto = null;
                }
                else
                {
                    objProducto.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objProducto.RubroProducto.Codigo = Convert.ToInt32(objDataReader["CodigoRubroProducto"]);
                    objProducto.RubroProducto.Descripcion = objDataReader["RubroProducto"].ToString();
                    objProducto.Descripcion = objDataReader["Descripcion"].ToString();
                    objProducto.UnidadDeMedida = objDataReader["UnidadMedida"].ToString();
                    objProducto.Peso = Convert.ToDouble(objDataReader["Peso"]);
                    objProducto.StockMinimo = Convert.ToInt32(objDataReader["StockMinimo"]);
                    objProducto.Stock = Convert.ToInt32(objDataReader["Stock"]);
                    objProducto.CodigoBarra = objDataReader["CodigoBarra"].ToString();
                    objProducto.PorcentajeIVA = Convert.ToDouble(objDataReader["PorcentajeIva"]);
                    objProducto.FacturacionPorCubeta = Convert.ToBoolean(objDataReader["FacturacionPorCubeta"]);
                    objProducto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(objDataReader["Estado"]);
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
            return objProducto;
        }
        public static int Agregar(Entidades.Producto pProducto)
        {
            //Creo objeto conexion
            strProc = "SP_PRODUCTOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pProducto.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pProducto.Descripcion);
            objCommand.Parameters.AddWithValue("@CodigoRubroProducto", pProducto.RubroProducto.Codigo);
            objCommand.Parameters.AddWithValue("@UnidadDeMedida", pProducto.UnidadDeMedida);
            objCommand.Parameters.AddWithValue("@Peso", pProducto.Peso);
            objCommand.Parameters.AddWithValue("@StockMinimo", pProducto.StockMinimo);
            objCommand.Parameters.AddWithValue("@CodigoBarra", pProducto.CodigoBarra);
            objCommand.Parameters.AddWithValue("@PorcentajeIva", pProducto.PorcentajeIVA);
            objCommand.Parameters.AddWithValue("@FacturacionPorCubeta", pProducto.FacturacionPorCubeta);
            objCommand.Parameters.AddWithValue("@Vacio", pProducto.Vacio);

            try
            {
                objConexion.Open();
                //objCommand.ExecuteNonQuery();
                return Convert.ToInt32(objCommand.ExecuteScalar());
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar el Producto, ya existe!!");
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

        public static void AgregarPrecios(Entidades.Usuario pUsuario, List<PreciosLote> pPrecios)
        {
            strProc = "SP_CARGARPRECIOS";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pUsuario.Codigo);

            DataTable dtDetalle = new DataTable();
            DataColumn column;

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Codigo";
            dtDetalle.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Lote";
            dtDetalle.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Precio";
            dtDetalle.Columns.Add(column);

            foreach (Entidades.PreciosLote pl in pPrecios)
            {
                dtDetalle.Rows.Add(pl.Codigo, pl.Lote, pl.PrecioUnitario);

            }
            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@PreciosLotes";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDetalle;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            try
            {
                objConexion.Open();
                objCommand.ExecuteScalar();
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

        public static void Eliminar(Entidades.Producto pProducto)
        {
            //Creo objeto conexion
            strProc = "SP_PRODUCTOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pProducto.Codigo);
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
            strProc = "SP_PRODUCTOS_SELECT_NOVEDADES";
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

        public static DataTable ObtenerPreciosNovedades()
        {
            DataTable dt = new DataTable();
            strProc = "SP_PRODUCTOSPRECIOS_SELECT_NOVEDADES";
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
        public static void CambiarEstadoNovedad(Entidades.Producto pProducto)
        {
            strProc = "SP_PRODUCTOS_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pProducto.Codigo);
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

        public static void CambiarEstadoNovedad(Entidades.PreciosLote pPreciosLote)
        {
            strProc = "SP_PRECIOS_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pPreciosLote.Codigo);
            objCommand.Parameters.AddWithValue("@Lote", pPreciosLote.Lote);
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

        public static void AgregarDeWeb(Entidades.Producto pProducto)
        {
            //Creo objeto conexion
            strProc = "SP_PRODUCTOS_INSERT_WEB";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pProducto.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pProducto.Descripcion);
            objCommand.Parameters.AddWithValue("@CodigoRubro", pProducto.RubroProducto.Codigo);
            objCommand.Parameters.AddWithValue("@UnidadMedida", pProducto.UnidadDeMedida);
            objCommand.Parameters.AddWithValue("@Peso", pProducto.Peso);
            objCommand.Parameters.AddWithValue("@StockMinimo", pProducto.StockMinimo);
            objCommand.Parameters.AddWithValue("@CodigoBarra", pProducto.CodigoBarra);
            objCommand.Parameters.AddWithValue("@PorcentajeIva", pProducto.PorcentajeIVA);
            objCommand.Parameters.AddWithValue("@FacturacionPorCubeta", pProducto.FacturacionPorCubeta);
            objCommand.Parameters.AddWithValue("@Vacio", pProducto.Vacio);
            objCommand.Parameters.AddWithValue("@Estado", pProducto.Estado);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Producto, ya existe!!");
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

        public static void AgregarDeWeb(Entidades.PreciosLote pPrecios)        {
            //Creo objeto conexion
            strProc = "SP_CARGARPRECIOS_INSERT_WEB";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Fecha", pPrecios.Fecha);
            objCommand.Parameters.AddWithValue("@Codigo", pPrecios.Codigo);
            objCommand.Parameters.AddWithValue("@Lote", pPrecios.Lote);
            objCommand.Parameters.AddWithValue("@PrecioUnitario", pPrecios.PrecioUnitario);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Precio, ya existe!!");
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

        public static DataTable ObtenerVentas(DateTime pDesde, DateTime pHasta, Entidades.Cliente pCliente, Entidades.RubroProducto pRubro, Entidades.Producto pProducto)
        {
            DataTable dt = new DataTable();
            strProc = "SP_VENTAPORPRODUCTOS";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde",pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodCliente", pCliente.Codigo);
            try
            {
                dt.TableName = "dsVentas";
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

        public static DataTable ObtenerVentasDetalladas(DateTime pDesde, DateTime pHasta, Entidades.Cliente pCliente, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote)
        {
            DataTable dt = new DataTable();
            strProc = "SP_VENTAPORPRODUCTOSDETALLADO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodLote", pLote.IdLote);
            try
            {
                dt.TableName = "dsVentas";
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
