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
    public static class TipoDocumentoCliente
    {
        private static SqlConnection objConexion = null;
      //  private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc = string.Empty;
        static TipoDocumentoCliente()
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
   
        public static Entidades.TipoDocumentoCliente ObtenerUno(int pCodigo)
        {
            Entidades.TipoDocumentoCliente objTipo = new Entidades.TipoDocumentoCliente();
            strProc = "SP_TIPOSDOCUMENTOSCLIENTE_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objTipo.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objTipo.Descripcion = objDataReader["Descripcion"].ToString();
                objTipo.TipoDoc.Codigo= objDataReader["CodigoTipoDoc"].ToString();
                objTipo.Numerador.Codigo= Convert.ToInt32(objDataReader["CodigoNumerador"]);
                objTipo.AfectaCtaCte= Convert.ToChar(objDataReader["AfectaCtaCte"].ToString());
                objTipo.AfectaCaja = Convert.ToChar(objDataReader["AfectaCaja"].ToString());
                objTipo.AfectaIVA = Convert.ToChar(objDataReader["AfectaIVA"].ToString());
                objTipo.TipoDiscIVA = Convert.ToChar(objDataReader["TipoDiscIVA"].ToString());
                objTipo.Numerador.Letra = objDataReader["Letra"].ToString();
                objTipo.MiPYME = Convert.ToBoolean(objDataReader["MiPYME"]);
                objTipo.Numerador.PuntoVenta = Convert.ToInt32(objDataReader["PuntoVenta"]);
                objTipo.Numerador.Numero = Convert.ToInt32(objDataReader["Numero"]);
                objTipo.Electronico = Convert.ToBoolean(objDataReader["Electronico"]);

                Enumeraciones.Enumeraciones.Estados estado;

                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objTipo.Estado = estado;

                objTipo.TiposInscripcion = TipoInscripcion.ObtenerTodos(pCodigo);


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
            return objTipo;
        }

   
    }
}
