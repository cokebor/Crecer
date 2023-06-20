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
    public static class RemitoProveedor_D_Productos
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static RemitoProveedor_D_Productos()
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
        public static List<Entidades.RemitoProveedor_D_Producto> ObtenerTodos(int pCodigoRemito)
        {
            List<Entidades.RemitoProveedor_D_Producto> detalle = new List<Entidades.RemitoProveedor_D_Producto>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.RemitoProveedor_D_Producto objRemitoProveedorD_Productos;
            strProc = "SP_REMITOPROVEEDOR_D_PRODUCTOS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoRemito);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                
                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read()) {
                        objRemitoProveedorD_Productos = new Entidades.RemitoProveedor_D_Producto();
                        objRemitoProveedorD_Productos.Renglon= Convert.ToInt32(objDataReader["Renglon"]);
                        objRemitoProveedorD_Productos.Producto.Codigo= Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objRemitoProveedorD_Productos.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objRemitoProveedorD_Productos.MovStock_Lotes.Cantidad= Convert.ToInt32(objDataReader["Cantidad"]);
                        objRemitoProveedorD_Productos.MovStock_Lotes.Codigo= Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objRemitoProveedorD_Productos.MovStock_Lotes.IdLote.IdLote= Convert.ToInt32(objDataReader["IdLote"]);
                      //  objRemitoProveedorD_Productos.MovStock_Lotes.IdLote.DTVe = objDataReader["DTVe"].ToString().Trim().Equals("")?null: objDataReader["DTVe"].ToString().Trim();

                     //   fila.Cells["DTVe"].Value == null ? null : (fila.Cells["DTVe"].Value.ToString().Trim().Equals("") ? null : fila.Cells["DTVe"].Value.ToString());

                        objRemitoProveedorD_Productos.Producto.PorcentajeIVA = Convert.ToDouble(objDataReader["PorcentajeIva"]);
                        detalle.Add(objRemitoProveedorD_Productos);
                    }
                }
                else
                {
                    objRemitoProveedorD_Productos = null;
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

        public static List<Entidades.RemitoProveedor_D_Producto> ObtenerAlgunos(int pCodigoRemito)
        {
            List<Entidades.RemitoProveedor_D_Producto> detalle = new List<Entidades.RemitoProveedor_D_Producto>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.RemitoProveedor_D_Producto objRemitoProveedorD_Productos;
            strProc = "SP_REMITOPROVEEDOR_D_PRODUCTOSAFACTURAR_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoRemito);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();

                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objRemitoProveedorD_Productos = new Entidades.RemitoProveedor_D_Producto();
                        objRemitoProveedorD_Productos.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objRemitoProveedorD_Productos.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objRemitoProveedorD_Productos.Producto.Descripcion = objDataReader["Producto"].ToString(); Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objRemitoProveedorD_Productos.MovStock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        objRemitoProveedorD_Productos.MovStock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objRemitoProveedorD_Productos.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objRemitoProveedorD_Productos.Producto.PorcentajeIVA = Convert.ToDouble(objDataReader["PorcentajeIva"]);
                        detalle.Add(objRemitoProveedorD_Productos);
                    }
                }
                else
                {
                    objRemitoProveedorD_Productos = null;
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
        public static List<Entidades.RemitoProveedor_A_Liquidar> ObtenerTodosParaLiquidar(int pCodigoRemito, Entidades.Empresa pEmpresa)
        {
            List<Entidades.RemitoProveedor_A_Liquidar> detalle = new List<Entidades.RemitoProveedor_A_Liquidar>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.RemitoProveedor_A_Liquidar objRemitoProveedor_A_Liquidar;
            strProc = "SP_REMITOPROVEEDOR_PRODUCTOS_PARALIQUIDAR_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemitoProveedor", pCodigoRemito);
            objCommand.Parameters.AddWithValue("@CodigoEmpresa", pEmpresa.Codigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();

                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objRemitoProveedor_A_Liquidar = new Entidades.RemitoProveedor_A_Liquidar();
                        objRemitoProveedor_A_Liquidar.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objRemitoProveedor_A_Liquidar.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objRemitoProveedor_A_Liquidar.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objRemitoProveedor_A_Liquidar.Producto.PorcentajeIVA = Convert.ToDouble(objDataReader["PorcentajeIva"]);
                        objRemitoProveedor_A_Liquidar.MovStock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        //objRemitoProveedorD_Productos.MovStock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objRemitoProveedor_A_Liquidar.MovStock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objRemitoProveedor_A_Liquidar.CantidadRemitida=Convert.ToInt32(objDataReader["Cantidad_Remitida"]);
                        objRemitoProveedor_A_Liquidar.CantidadVendida = Convert.ToInt32(objDataReader["Cantidad_Vendida"]);
                        objRemitoProveedor_A_Liquidar.CantidadLiquidada = Convert.ToInt32(objDataReader["Cantidad_Liquidada"]);
                        objRemitoProveedor_A_Liquidar.CantidadMerma = Convert.ToInt32(objDataReader["Cantidad_Merma"]);
                        //objRemitoProveedor_A_Liquidar.ImporteTotal= Convert.ToDouble(objDataReader["Importe_Total"]);
                        // objRemitoClienteD_Productos.LoteNuevo.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        //   objRemitoClienteD_Productos.CantidadLiquidadas = Convert.ToInt32(objDataReader["Liquidadas"]);
                      /*  if (pEmpresa.Codigo == 1) {
                            objRemitoProveedor_A_Liquidar.CantidadVendidaCba = Convert.ToInt32(objDataReader["Cantidad_Vendida_Cba"]);
                            objRemitoProveedor_A_Liquidar.CantidadVendidaVM = Convert.ToInt32(objDataReader["Cantidad_Vendida_VM"]);
                            objRemitoProveedor_A_Liquidar.CantidadVendidaRC = Convert.ToInt32(objDataReader["Cantidad_Vendida_RC"]);
                        }
                        */

                        detalle.Add(objRemitoProveedor_A_Liquidar);
                    }
                }
                else
                {
                    objRemitoProveedor_A_Liquidar = null;
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

        public static DataTable ObtenerDetalle(int pCodigoRemito)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOPROVEEDOR_D_PRODUCTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", pCodigoRemito);

            try
            {
                dt.TableName = "DataSet3";
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
