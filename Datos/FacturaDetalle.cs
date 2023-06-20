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
    public static class FacturaDetalle
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        static FacturaDetalle()
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
        public static DataTable ObtenerUno(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_DETALLES_SELECT_UNO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            try
            {
                dt.TableName = "dsFacturaDetalle";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }


        public static List<Entidades.Factura_DescuentosEspeciales> ObtenerDescuentosEspecialesParaNC(int pCodigoFactura)
        {
            List<Entidades.Factura_DescuentosEspeciales> descuentos = new List<Entidades.Factura_DescuentosEspeciales>();
            Entidades.Factura_DescuentosEspeciales objFacturaDescuentos;
            strProc = "SP_FACTURASDESCUENTOSPARANC_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);


            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objFacturaDescuentos = new Entidades.Factura_DescuentosEspeciales();
                        objFacturaDescuentos.Descripcion = objDataReader["Descripcion"].ToString();
                        objFacturaDescuentos.PorcentajeDescuento = Convert.ToDouble(objDataReader["PorcentajeDescuento"]);
                        descuentos.Add(objFacturaDescuentos);
                    }
                }
                else
                {
                    objFacturaDescuentos = null;
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
            return descuentos;
        }
        public static List<Entidades.Factura_Detalle> ObtenerUnoParaNC(int pCodigoFactura)
        {
            List<Entidades.Factura_Detalle> detalle = new List<Entidades.Factura_Detalle>();
            Entidades.Factura_Detalle objFacturaDetalle;
            strProc = "SP_FACTURASPARANC_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);


            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objFacturaDetalle = new Entidades.Factura_Detalle();
                        objFacturaDetalle.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objFacturaDetalle.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objFacturaDetalle.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        //objFacturaDetalle.MovStock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objFacturaDetalle.Kilos = Convert.ToDouble(objDataReader["Kilos"]);
                        objFacturaDetalle.PrecioUnitario = Convert.ToDouble(objDataReader["PrecioUnitario"]);
                        objFacturaDetalle.PrecioUnitarioPorKilo = Convert.ToDouble(objDataReader["PrecioUnitarioPorKilo"]);
                        objFacturaDetalle.PrecioUnitarioConDescuento = Convert.ToDouble(objDataReader["PrecioUnitarioConDescuento"]);
                        objFacturaDetalle.PrecioUnitarioPorKiloConDescuento = Convert.ToDouble(objDataReader["PrecioUnitarioPorKiloConDescuento"]);
                        objFacturaDetalle.PorIva = Convert.ToDouble(objDataReader["PorcIva"]);
                        objFacturaDetalle.FacturaPorCubeta = Convert.ToBoolean(objDataReader["Cubetas"]);
                        objFacturaDetalle.Cantidad = Convert.ToInt32(objDataReader["CantidadOriginal"]);
                        detalle.Add(objFacturaDetalle);
                    }
                }
                else
                {
                    objFacturaDetalle = null;
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
            return detalle;
        }
        public static List<Entidades.Factura_Detalle> ObtenerUnoParaNCVentasIniciales(int pCodigoFactura)
        {
            List<Entidades.Factura_Detalle> detalle = new List<Entidades.Factura_Detalle>();
            Entidades.Factura_Detalle objFacturaDetalle; ;
            strProc = "SP_FACTURASPARANCVENTASINICIALES_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);


            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objFacturaDetalle = new Entidades.Factura_Detalle();
                        objFacturaDetalle.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objFacturaDetalle.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objFacturaDetalle.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        //objFacturaDetalle.MovStock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objFacturaDetalle.Kilos = Convert.ToDouble(objDataReader["Kilos"]);
                        objFacturaDetalle.PrecioUnitario = Convert.ToDouble(objDataReader["PrecioUnitario"]);
                        objFacturaDetalle.PrecioUnitarioConDescuento = Convert.ToDouble(objDataReader["PrecioUnitarioConDescuento"]);
                        objFacturaDetalle.PorIva = Convert.ToDouble(objDataReader["PorcIva"]);
                        detalle.Add(objFacturaDetalle);
                    }
                }
                else
                {
                    objFacturaDetalle = null;
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
            return detalle;
        }
        public static List<Entidades.Factura_Detalle> ObtenerUnoParaNCLote(int pCodigoFactura, int pViejo, bool pConDescuento)
        {
            List<Entidades.Factura_Detalle> detalle = new List<Entidades.Factura_Detalle>();
            Entidades.Factura_Detalle objFacturaDetalle; ;
            strProc = "SP_FACTURASPARANCLOTE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);
            objCommand.Parameters.AddWithValue("@Viejo", pViejo);
            objCommand.Parameters.AddWithValue("@ConDescuento", pConDescuento);


            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objFacturaDetalle = new Entidades.Factura_Detalle();
                        objFacturaDetalle.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objFacturaDetalle.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objFacturaDetalle.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        //objFacturaDetalle.MovStock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objFacturaDetalle.Kilos = Convert.ToDouble(objDataReader["Kilos"]);
                        objFacturaDetalle.PrecioUnitario = Convert.ToDouble(objDataReader["PrecioUnitario"]);
                        // objFacturaDetalle.PrecioUnitarioConDescuento = Convert.ToDouble(objDataReader["PrecioUnitarioConDescuento"]);
                        objFacturaDetalle.PorIva = Convert.ToDouble(objDataReader["PorcIva"]);
                        detalle.Add(objFacturaDetalle);
                    }
                }
                else
                {
                    objFacturaDetalle = null;
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
            return detalle;
        }
        public static List<Entidades.Factura_Detalle> ObtenerUnoParaAjuste(int pCodigoFactura)
        {
            List<Entidades.Factura_Detalle> detalle = new List<Entidades.Factura_Detalle>();
            Entidades.Factura_Detalle objFacturaDetalle; ;
            strProc = "SP_FACTURASPARAAJUSTE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoFactura);


            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objFacturaDetalle = new Entidades.Factura_Detalle();
                        objFacturaDetalle.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objFacturaDetalle.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objFacturaDetalle.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        //objFacturaDetalle.MovStock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objFacturaDetalle.Kilos = Convert.ToDouble(objDataReader["Kilos"]);
                        objFacturaDetalle.PrecioUnitario = Convert.ToDouble(objDataReader["PrecioUnitario"]);
                        objFacturaDetalle.PrecioUnitarioConDescuento = Convert.ToDouble(objDataReader["PrecioUnitarioConDescuento"]);
                        objFacturaDetalle.PorIva = Convert.ToDouble(objDataReader["PorcIva"]);
                        detalle.Add(objFacturaDetalle);
                    }
                }
                else
                {
                    objFacturaDetalle = null;
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
            return detalle;
        }

        public static DataTable ObtenerDetalleLiquidacion(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_LIQUIDACIONESCLIENTES_DETALLE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoLiquidacion", pCodigoFactura);
            try
            {
                dt.TableName = "dsFacturaDetalle";
                objDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
    }
}
