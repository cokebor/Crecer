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
    public static class FormaDePago
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
       /* static FormaDePago() {
        }*/
        static FormaDePago()
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
        public static DataTable ObtenerTodosVentas()
        {
            DataTable dt = new DataTable();
            //objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_VENTAS";
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

        public static DataTable ObtenerTodosCompras()
        {
            DataTable dt = new DataTable();
           // objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_COMPRAS";
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

        public static DataTable ObtenerTodosVentasFormasPago()
        {
            DataTable dt = new DataTable();
           // objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_VENTAS_FORMASPAGO";
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
        public static DataTable ObtenerTodosVentasSaldoInicialFormasPago()
        {
            DataTable dt = new DataTable();
            // objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_VENTAS_SALDOINICIAL";
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
        
        public static DataTable ObtenerParaTransacciones()
        {
            DataTable dt = new DataTable();
            //   objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_DC_SELECT";
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

        public static DataTable ObtenerTodosComprasFormasPago()
        {
            DataTable dt = new DataTable();
         //   objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_COMPRAS_FORMASPAGO";
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

        public static DataTable ObtenerTodosComprasFormasPago(int pCodigoSucursal)
        {
            DataTable dt = new DataTable();
            //   objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_COMPRASSUC_FORMASPAGO";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoSucursal", pCodigoSucursal);

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

        public static DataTable ObtenerTodosIngresosFormasPago()
        {
            DataTable dt = new DataTable();
            //   objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_INGRESOS_FORMASPAGO";
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
        public static DataTable ObtenerTodosPagosSueldosFormasPago()
        {
            DataTable dt = new DataTable();
            //   objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_SUELDOS";
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
        public static DataTable ObtenerTodosComprasContraReciboFormasPago()
        {
            DataTable dt = new DataTable();
          //  objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_COMPRASCONTRARECIBO_FORMASPAGO";
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

        

        public static DataTable ObtenerParaEgreso()
        {
            DataTable dt = new DataTable();
            //  objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_EGRESO_FORMASPAGO";
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
        public static Entidades.FormaDePago ObtenerUno(int pCodigoFormaPago)
        {
            Entidades.FormaDePago objForma = new Entidades.FormaDePago();
         //   objConexion = new SqlConnection(BaseDatos.StringConexion);
            strProc = "SP_FORMASDEPAGO_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoFormaPago);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                if (objDataReader.HasRows.Equals(false))
                {
                    objForma = new Entidades.FormaDePago();
                }
                else
                {

                    objForma.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                    objForma.Descripcion = objDataReader["Descripcion"].ToString();
                    objForma.CuentaContable.Codigo= Convert.ToInt64(objDataReader["CodigoCuentaContable"]);
                    objForma.Compra = Convert.ToBoolean(objDataReader["Compra"]);
                    objForma.Venta = Convert.ToBoolean(objDataReader["Venta"]);
                    objForma.FormaPago= Convert.ToBoolean(objDataReader["FormasDePago"]);
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
            return objForma;
        }
        
    }
}
