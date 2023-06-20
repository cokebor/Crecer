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
    public static class RemitoSucursal_D_Productos
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        private static SqlDataReader objDataReader = null;
        static RemitoSucursal_D_Productos()
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


        public static DataTable ObtenerDataTable(int pCodigoRemito)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOSUCURSAL_D_PRODUCTOS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRemitoSucursal", pCodigoRemito);

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

        public static List<Entidades.RemitoSucursal_D_Producto> ObtenerTodos(int pCodigoRemito)
        {
            List<Entidades.RemitoSucursal_D_Producto> detalle = new List<Entidades.RemitoSucursal_D_Producto>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.RemitoSucursal_D_Producto objRemitoSucursalD_Productos;
            strProc = "SP_REMITOSUCURSAL_D_PRODUCTOS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoRemitoSucursal", pCodigoRemito);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();

                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objRemitoSucursalD_Productos = new Entidades.RemitoSucursal_D_Producto();
                        objRemitoSucursalD_Productos.Renglon = Convert.ToInt32(objDataReader["Renglon"]);
                        objRemitoSucursalD_Productos.Producto.Codigo = Convert.ToInt32(objDataReader["CodigoProducto"]);
                        objRemitoSucursalD_Productos.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objRemitoSucursalD_Productos.Movstock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        objRemitoSucursalD_Productos.Movstock_Lotes.Codigo = Convert.ToInt32(objDataReader["MovStock_Lotes"]);
                        objRemitoSucursalD_Productos.Movstock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objRemitoSucursalD_Productos.Proveedor.Codigo= Convert.ToInt32(objDataReader["CodigoProveedor"]);
                        objRemitoSucursalD_Productos.Canal.Codigo = Convert.ToInt32(objDataReader["CodigoCanal"]);

                        detalle.Add(objRemitoSucursalD_Productos);
                    }
                }
                else
                {
                    objRemitoSucursalD_Productos = null;
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
    }
}
