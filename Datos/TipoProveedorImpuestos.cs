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
    public static class TipoProveedorImpuestos
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;

        private static string strProc = string.Empty;
        static TipoProveedorImpuestos()
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

        public static List<Entidades.TipoDocumentoProveedorImpuesto> ObtenerTodosProveedor(int pCodigoTipoDocumento, char pImpuesto='Z')
        {
            List<Entidades.TipoDocumentoProveedorImpuesto> impuestos = new List<Entidades.TipoDocumentoProveedorImpuesto>();
            //Entidades.RemitoProveedor_M objRemito = new Entidades.RemitoProveedor_M();
            Entidades.TipoDocumentoProveedorImpuesto objImpuesto;
            strProc = "SP_TIPODOCUMENTOPROVEEDOR_IMPUESTOS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoTipoDocumento);
            objCommand.Parameters.AddWithValue("@Impuesto", pImpuesto);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();

                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objImpuesto = new Entidades.TipoDocumentoProveedorImpuesto();
                        objImpuesto.Impuesto.Codigo = Convert.ToInt32(objDataReader["CodigoImpuesto"]);
                        objImpuesto.Impuesto.Descripcion = objDataReader["Descripcion"].ToString();
                        objImpuesto.Porcentaje = Convert.ToDouble(objDataReader["Porcentaje"]);
                        objImpuesto.Del = Convert.ToChar(objDataReader["Del"]);
                        objImpuesto.Impuesto.CuentaContable.Codigo=Convert.ToInt64(objDataReader["CodigoCuentaContable"]);
                        objImpuesto.Regimen.Codigo = Convert.ToInt32(objDataReader["CodigoRegimen"]);
                        impuestos.Add(objImpuesto);
                    }
                }
                else
                {
                    objImpuesto = null;
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
            return impuestos;
        }
    }
}
