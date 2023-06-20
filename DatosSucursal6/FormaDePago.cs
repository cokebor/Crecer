using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSucursal6
{
    public static class FormaDePago
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;

        static FormaDePago()
        {
            try
            {

                objConexion = new SqlConnection(BaseDatos.StringConexionSucursal6);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                    objForma.CuentaContable.Codigo = Convert.ToInt64(objDataReader["CodigoCuentaContable"]);
                    objForma.Compra = Convert.ToBoolean(objDataReader["Compra"]);
                    objForma.Venta = Convert.ToBoolean(objDataReader["Venta"]);
                    objForma.FormaPago = Convert.ToBoolean(objDataReader["FormasDePago"]);
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
