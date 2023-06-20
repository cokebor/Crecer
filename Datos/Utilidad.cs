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
    public static class Utilidad
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        //private static SqlCommand objCommand = null;
       // private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;

        static Utilidad()
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

        public static DataTable Obtener(Entidades.Sucursal pSucursal,Entidades.Proveedor pProveedor, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Cliente pCliente, DateTime pFechaDesde, DateTime pFechaHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_UTILIDADES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoSucursal", pSucursal.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pFechaDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pFechaHasta);
            try
            {
                dt.TableName = "dsUtilidades";
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
            //}
        }

        public static DataTable Obtener(Entidades.Proveedor pProveedor, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Cliente pCliente, DateTime pFechaDesde, DateTime pFechaHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_UTILIDADESPUESTO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProveedor", pProveedor.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoRubro", pRubro.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoProducto", pProducto.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pFechaDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaHasta", pFechaHasta);
            try
            {
                dt.TableName = "dsUtilidades";
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
            //}
        }
    }
}
