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
    public static class RemitoCliente_D_Productos
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static RemitoCliente_D_Productos()
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
        public static List<Entidades.RemitoCliente_D_Producto> ObtenerTodos(int pCodigoRemito)
        {
            List<Entidades.RemitoCliente_D_Producto> detalle = new List<Entidades.RemitoCliente_D_Producto>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.RemitoCliente_D_Producto objRemitoClienteD_Productos;
            strProc = "SP_REMITOCLIENTE_D_PRODUCTOS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemitoCliente", pCodigoRemito);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                
                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read()) {
                        objRemitoClienteD_Productos = new Entidades.RemitoCliente_D_Producto();
                        objRemitoClienteD_Productos.Renglon= Convert.ToInt32(objDataReader["Renglon"]);
                        objRemitoClienteD_Productos.Producto.Codigo= Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objRemitoClienteD_Productos.Producto.Descripcion = objDataReader["Producto"].ToString(); 
                        objRemitoClienteD_Productos.Movstock_Lotes.Cantidad= Convert.ToInt32(objDataReader["Cantidad"]);
                        objRemitoClienteD_Productos.Movstock_Lotes.Codigo= Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objRemitoClienteD_Productos.Movstock_Lotes.IdLote.IdLote= Convert.ToInt32(objDataReader["IdLote"]);
                        objRemitoClienteD_Productos.LoteNuevo.IdLote = Convert.ToInt32(objDataReader["IdLote"]);

                        detalle.Add(objRemitoClienteD_Productos);
                    }
                }
                else
                {
                    objRemitoClienteD_Productos = null;
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

        public static List<Entidades.RemitoCliente_D_Producto> ObtenerTodosParaLiquidar(int pCodigoRemito)
        {
            List<Entidades.RemitoCliente_D_Producto> detalle = new List<Entidades.RemitoCliente_D_Producto>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.RemitoCliente_D_Producto objRemitoClienteD_Productos;
            strProc = "SP_REMITOCLIENTE_PRODUCTOS_PARALIQUIDAR_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemitoCliente", pCodigoRemito);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();

                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objRemitoClienteD_Productos = new Entidades.RemitoCliente_D_Producto();
                        objRemitoClienteD_Productos.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objRemitoClienteD_Productos.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objRemitoClienteD_Productos.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objRemitoClienteD_Productos.Producto.PorcentajeIVA = Convert.ToDouble(objDataReader["PorcentajeIva"]);
                        objRemitoClienteD_Productos.Movstock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        objRemitoClienteD_Productos.Movstock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objRemitoClienteD_Productos.Movstock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objRemitoClienteD_Productos.LoteNuevo.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objRemitoClienteD_Productos.CantidadLiquidadas = Convert.ToInt32(objDataReader["Liquidadas"]);
                        detalle.Add(objRemitoClienteD_Productos);
                    }
                }
                else
                {
                    objRemitoClienteD_Productos = null;
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


        public static DataTable ObtenerDataTable(int pCodigoRemito)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOCLIENTE_D_PRODUCTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRemitoCliente", pCodigoRemito);

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
