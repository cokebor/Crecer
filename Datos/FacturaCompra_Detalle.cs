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
    public static class FacturaCompra_Detalle
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlDataReader objDataReader = null;
        static FacturaCompra_Detalle()
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

        public static List<Entidades.FacturaCompra_Detalle> ObtenerUnoParaNC(int pCodigoFactura)
        {
            List<Entidades.FacturaCompra_Detalle> detalle = new List<Entidades.FacturaCompra_Detalle>();
            Entidades.FacturaCompra_Detalle objFacturaDetalle; ;
            strProc = "SP_FACTURASCOMPRASPARANC_SELECT";
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
                        objFacturaDetalle = new Entidades.FacturaCompra_Detalle();
                        objFacturaDetalle.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objFacturaDetalle.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objFacturaDetalle.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        //objFacturaDetalle.MovStock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objFacturaDetalle.PrecioUnitario = Convert.ToDouble(objDataReader["PrecioUnitario"]);
                        //objFacturaDetalle.PrecioUnitarioConDescuento = Convert.ToDouble(objDataReader["PrecioUnitarioConDescuento"]);
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

        public static List<Entidades.FacturaCompra_Detalle> ObtenerUnoParaAjuste(int pCodigoFactura)
        {
            List<Entidades.FacturaCompra_Detalle> detalle = new List<Entidades.FacturaCompra_Detalle>();
            Entidades.FacturaCompra_Detalle objFacturaDetalle; ;
            strProc = "SP_FACTURASCOMPRASPARAAJUSTE_SELECT";
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
                        objFacturaDetalle = new Entidades.FacturaCompra_Detalle();
                        objFacturaDetalle.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objFacturaDetalle.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objFacturaDetalle.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objFacturaDetalle.MovStock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        //objFacturaDetalle.MovStock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objFacturaDetalle.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objFacturaDetalle.PrecioUnitario = Convert.ToDouble(objDataReader["PrecioUnitario"]);
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
            strProc = "SP_FACTURASCOMPRAS_DETALLE_SELECT";
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

        public static DataTable ObtenerDetalleFacturasBC(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURACOMPRABC_DETALLE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoFacturaCompra", pCodigoFactura);
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

        public static DataTable ObtenerDetalleFacturasGYBC(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURACOMPRAGYBU_DETALLE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoFacturaCompra", pCodigoFactura);
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

        public static DataTable ObtenerImpuestos(int pCodigoFactura)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURASCOMPRAS_IMPUESTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoFacturaCompra", pCodigoFactura);
            try
            {
                dt.TableName = "dsImpuestos";
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
