using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRioCuarto
{
    public static class Factura
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        static Factura()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionRioCuarto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ObtenerTodosPorFecha(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
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
        public static DataTable ObtenerFechas()
        {
            DataTable dt = new DataTable();
            strProc = "SP_IVAVENTAS_FECHAS_SELECT";
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
        public static Entidades.Factura ObtenerFactura(int pCodigo)
        {
            Entidades.Factura objFactura = new Entidades.Factura();
            strProc = "SP_FACTURAS_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objFactura = null;
                }
                else
                {
                    objFactura.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objFactura.FacturaKilos = Convert.ToBoolean(objDataReader["FacturaKilos"]);
                    objFactura.TipoDocumentoCliente = TipoDocumentoCliente.ObtenerUno(Convert.ToInt32(objDataReader["CodigoTipoDocumentoCliente"]));
                    objFactura.Letra = Convert.ToChar(objDataReader["Letra"]);
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
            return objFactura;
        }

        public static DataTable ObtenerUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsFactura";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerFacturasCuentaCorriente(Entidades.Cliente pCliente, DateTime pDesde)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_CUENTASCORRIENTEPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde);
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

        public static DataTable ObtenerFacturasSinImputarPorCliente(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_SINIMPUTARPORCLIENTE_SELECT";
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

        public static DataTable ObtenerIVA(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_IVAVENTAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsIVAVentas";
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

        public static DataTable ObtenerEncabezadoLiquidacion(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESCLIENTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoLiquidacion", pCodigoFactura);
            try
            {
                dt.TableName = "dsEncabezado";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerMermasLiquidacion(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESCLIENTES_MERMAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoLiquidacion", pCodigoFactura);
            try
            {
                dt.TableName = "dsLiquidacionMermas";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerDetallesLiquidacion(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESCLIENTES_DETALLES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoLiquidacion", pCodigoFactura);
            try
            {
                dt.TableName = "dsLiquidacionDetalles";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static DataTable VentasPorEmpleados(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();

            strProc = "SP_VENTASPOREMPLEADOFECHA";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsVentasPorEmpleado";
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
        public static DataTable VentasPorEmpleadosDetalle(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();

            strProc = "SP_VENTASPOREMPLEADOFECHADETALLE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                dt.TableName = "dsVentasPorEmpleadoDetalle";
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

        public static DataTable ObtenerComprobantesCtasCorrientesClientes(char pCodigoTipoComprobante, Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_COMPROBANTESCTASCTESCLIENTES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@TipoDocumentos", pCodigoTipoComprobante);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            try
            {
                dt.TableName = "dsCuentasCorrientesClientes";
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
