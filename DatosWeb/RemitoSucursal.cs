using MySql.Data.MySqlClient;
using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosWeb
{
    public static class RemitoSucursal
    {
        private static string strProc = string.Empty;

        private static MySqlConnection objConexion = null;
        private static MySqlCommand objCommand = null;
      //  private static MySqlDataAdapter objDataAdapter = null;
        private static MySqlDataReader objDataReader = null;
        static RemitoSucursal()
        {
            try
            {
                objConexion = new MySqlConnection(BaseDatos.StringConexionWeb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Agregar(Entidades.RemitoSucursal_M pRemito)
        {
            //Creo objeto conexion
            strProc = "SP_REMITOSUCURSAL_M_INSERT_WEB";
            objCommand = new MySqlCommand(strProc, objConexion);
            MySqlTransaction transaccion = null;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@FECHA", pRemito.Fecha);
            objCommand.Parameters.AddWithValue("@CODIGOSUCURSALORIGEN", pRemito.SucursalOrigen.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOSUCURSALDESTINO", pRemito.SucursalDestino.Codigo);
            objCommand.Parameters.AddWithValue("@NUMREMITO", pRemito.NumRemito);
           


            try
            {
                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                int res=Convert.ToInt32(objCommand.ExecuteScalar());

                foreach (Entidades.RemitoSucursal_D_Producto rs in pRemito.Productos) {
                    AgregarDetalles(res, rs, objConexion, objCommand.Transaction);
                }

                // transaccion.Commit();
                objCommand.Transaction.Commit();
            }
            catch (MySqlException sqlex)
            {
                //transaccion.Rollback();
                objCommand.Transaction.Rollback();
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Remito, ya existe!!");
                }
                throw new Exception(sqlex.Message);
            }
            catch (Exception ex)
            {
               // transaccion.Rollback();
                objCommand.Transaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }

        public static void AgregarDetalles(int pCodigo, Entidades.RemitoSucursal_D_Producto pRemitoDetalle, MySqlConnection conexion, MySqlTransaction transaccion)
        {
            //Creo objeto conexion
            strProc = "SP_REMITOSUCURSAL_D_PRODUCTOS_INSERT_WEB";
            objCommand = new MySqlCommand(strProc, conexion);
            objCommand.Transaction = transaccion;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGO", pCodigo);
            objCommand.Parameters.AddWithValue("@RENGLON", pRemitoDetalle.Renglon);
            objCommand.Parameters.AddWithValue("@CODIGOPRODUCTO", pRemitoDetalle.Producto.Codigo);
            objCommand.Parameters.AddWithValue("@IDLOTE", pRemitoDetalle.Movstock_Lotes.IdLote.IdLote);
            objCommand.Parameters.AddWithValue("@CANTIDAD", pRemitoDetalle.Movstock_Lotes.Cantidad);
            objCommand.Parameters.AddWithValue("@CODIGOPROVEEDOR", pRemitoDetalle.Proveedor.Codigo);
            objCommand.Parameters.AddWithValue("@CODIGOCANAL", pRemitoDetalle.Canal.Codigo);


            try
            {

                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        public static DataTable ObtenerNovedades(Entidades.Empresa pEmpresa)
        {
            DataTable dt = new DataTable();
            strProc = "SP_REMITOSUCURSAL_M_SELECT_NOVEDADES";
            objDataAdapter = new MySqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CODIGOSUCURSALDESTINO", pEmpresa.Codigo);
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }*/
        public static Entidades.RemitoSucursal_M ObtenerNovedades(Entidades.Empresa pEmpresa)
        {
            //DataTable dt = new DataTable();
            Entidades.RemitoSucursal_M objERemito=new Entidades.RemitoSucursal_M();
            strProc = "SP_REMITOSUCURSAL_M_SELECT_NOVEDADES";
            objCommand = new MySqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGOSUCURSALDESTINO2", pEmpresa.Codigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objERemito = null;
                }
                else
                {
                    objERemito.Codigo= Convert.ToInt32(objDataReader["Codigo"]);
                    objERemito.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                    objERemito.SucursalOrigen.Codigo = Convert.ToInt32(objDataReader["CodigoSucursalOrigen"]);
                    objERemito.SucursalDestino.Codigo = Convert.ToInt32(objDataReader["CodigoSucursalDestino"]);
                    objERemito.NumRemito = objDataReader["NumRemito"].ToString();

                }
            }
            catch (MySqlException ex)
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
            return objERemito;
        }


      
        public static List<Entidades.RemitoSucursal_D_Producto> ObtenerNovedades(int pCodigo)
        {
            List<Entidades.RemitoSucursal_D_Producto> detalle = new List<Entidades.RemitoSucursal_D_Producto>();
            Entidades.RemitoSucursal_D_Producto objRemitoSucursalD_Productos;
            strProc = "SP_REMITOSUCURSAL_D_PRODUCTOS_SELECT_NOVEDADES";
            // objDataAdapter = new MySqlDataAdapter(strProc, objConexion);
            objCommand = new MySqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CODIGO2", pCodigo);



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
                        //objRemitoSucursalD_Productos.Producto.Descripcion = objDataReader["Producto"].ToString();
                        objRemitoSucursalD_Productos.Movstock_Lotes.IdLote.IdLote = Convert.ToInt32(objDataReader["IdLote"]);
                        objRemitoSucursalD_Productos.Movstock_Lotes.Cantidad = Convert.ToInt32(objDataReader["Cantidad"]);
                        objRemitoSucursalD_Productos.Proveedor.Codigo = Convert.ToInt32(objDataReader["CodigoProveedor"]);
                        objRemitoSucursalD_Productos.Canal.Codigo = Convert.ToInt32(objDataReader["CodigoCanal"]);

                        detalle.Add(objRemitoSucursalD_Productos);
                    }
                }
                else
                {
                    objRemitoSucursalD_Productos = null;
                }

            }
            catch (MySqlException ex)
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

        public static void PasarABajado(string numRemito)
        {
            strProc = "SP_REMITOSUCURSAL_M_UPDATE";
            objCommand = new MySqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@NUMEROREMITO", numRemito);

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
    }
}