using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public static class Inversion
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        //private static SqlDataReader objDataReader = null;
        static Inversion()
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

        public static DataTable ObtenerCodigos(int pCodigoTipoInversion, Entidades.CuentaBancaria pCuentaBancaria)
        {
            DataTable dt = new DataTable();
            strProc = "SP_INVERSIONESCODIGO_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoInversion", pCodigoTipoInversion);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCuentaBancaria.Codigo);
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

        public static DataTable ObtenerFondosComunes(DateTime pDesde, DateTime pHasta, Entidades.CuentaBancaria pCuentaBancaria, char pTipoOperacion, int pCodigoFondo, bool pPendientes)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FONDOSCOMUNES_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCuentaBancaria.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoTipoOperacion", pTipoOperacion);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoFondo", pCodigoFondo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Pendientes", pPendientes);
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

        public static int Agregar(Entidades.Inversion pInversion, Entidades.Asiento pAsiento)
        {
     
            //Creo objeto conexion
            strProc = "SP_INVERSIONES_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion=null;
    
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pInversion.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoInversion", pInversion.TipoInversion.Codigo);
            objCommand.Parameters.AddWithValue("@FechaInversion", pInversion.FechaInversion);
            objCommand.Parameters.AddWithValue("@FechaVencimiento", pInversion.FechaVencimiento);
            objCommand.Parameters.AddWithValue("@CapitalInvertido", pInversion.CapitalInvertido);
            objCommand.Parameters.AddWithValue("@PlazosDias", pInversion.PlazoDias);
            objCommand.Parameters.AddWithValue("@TNA", pInversion.TNA);
            objCommand.Parameters.AddWithValue("@NroReferencia", pInversion.NroReferencia);
            objCommand.Parameters.AddWithValue("@Intereses", pInversion.Intereses);
            objCommand.Parameters.AddWithValue("@Observaciones", pInversion.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pInversion.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pInversion.CuentaBancaria.Codigo);
            objCommand.Parameters.AddWithValue("@Estado", pInversion.Estado);
            
            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                int CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);

                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);

                int res= Convert.ToInt32(objCommand.ExecuteScalar());

             
                transaccion.Commit();
                return res;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }



        public static int Agregar(Entidades.FondoComunInversion pFondoComun, Entidades.Asiento pAsiento)
        {

            //Creo objeto conexion
            strProc = "SP_FONDOCOMUN_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@Fecha", pFondoComun.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoFondoComun", pFondoComun.Fondo.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoTipoOperacion", pFondoComun.CodigoTipoOperacion);
            objCommand.Parameters.AddWithValue("@CantidadCuotapartes", pFondoComun.CantCuotapartes);
            objCommand.Parameters.AddWithValue("@ValorCuotapartes", pFondoComun.ValorCuotaparte);
            objCommand.Parameters.AddWithValue("@Importe", pFondoComun.Importe);
            objCommand.Parameters.AddWithValue("@Observaciones", pFondoComun.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", pFondoComun.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@NroReferencia", pFondoComun.NroReferencia);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pFondoComun.CuentaBancaria.Codigo);

            #region DataTable FondosRescate

            DataTable dtFondos = new DataTable();
            DataColumn column;

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int16");
            column.ColumnName = "Renglon";
            dtFondos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoFondo";
            dtFondos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "CantidadCuotaPartes";
            dtFondos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "CantidadCuotaPartesRestantes";
            dtFondos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Rescatado";
            dtFondos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Intereses";
            dtFondos.Columns.Add(column);

            int renglon = 1;
            foreach (Entidades.FondoComunInversion fc in pFondoComun.Fondos)
            {
                double capitalInvertido = (fc.CantCuotapartes * fc.ValorCuotaparte);
                double capitalRescatado = (fc.CantCuotapartes * pFondoComun.ValorCuotaparte);
                dtFondos.Rows.Add(renglon, fc.Codigo, fc.CantCuotapartes, fc.CantCuotapartesRestantes, Math.Round(capitalInvertido,2),Math.Round(capitalRescatado-capitalInvertido,2));
                renglon++;
            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Fondos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtFondos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            #endregion
            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                int CodigoAsiento = Asiento.Agregar(pAsiento, objConexion, transaccion);

                objCommand.Parameters.AddWithValue("@CodigoAsiento", CodigoAsiento);

                int res = Convert.ToInt32(objCommand.ExecuteScalar());


                transaccion.Commit();
                return res;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }

        public static int Eliminar(int pCodigoFondoComun, char pCodigoTipoOperacion) {
            //Creo objeto conexion
            strProc = "SP_FONDOCOMUN_ANULAR";
            objCommand = new SqlCommand(strProc, objConexion);
            SqlTransaction transaccion = null;

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@CodigoFondoComun", pCodigoFondoComun);
            objCommand.Parameters.AddWithValue("@CodigoTipoOperacion", pCodigoTipoOperacion);

            try
            {

                objConexion.Open();
                transaccion = objConexion.BeginTransaction();
                objCommand.Transaction = transaccion;

                int res = Convert.ToInt32(objCommand.ExecuteScalar());


                transaccion.Commit();
                return res;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }
        public static List<Entidades.FondoComunInversion> ObtenerFondosComunesConCuotapartes(int pCodigoFondo, int pCodigoCUentaBancaria) {
            List<Entidades.FondoComunInversion> fondos = new List<Entidades.FondoComunInversion>();
            Entidades.FondoComunInversion objEFCI;
            strProc = "SP_FONDOSCOMUNESCONCUOTAPARTES_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CodigoFondo", pCodigoFondo);
            objCommand.Parameters.AddWithValue("@CodigoCuentaBancaria", pCodigoCUentaBancaria);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)//.Equals(false))
                {
                    while (objDataReader.Read())
                    {
                        objEFCI = new FondoComunInversion();
                        objEFCI.Codigo= Convert.ToInt32(objDataReader["Codigo"]);
                        objEFCI.CantCuotapartes = Convert.ToDouble(objDataReader["CantidadCuotapartes"]);
                        objEFCI.CantCuotapartesRestantes = Convert.ToDouble(objDataReader["CantidadCuotapartesRestantes"]);
                        objEFCI.ValorCuotaparte= Convert.ToDouble(objDataReader["ValorCuotaparte"]);
                        fondos.Add(objEFCI);
                    }
                }
                else
                {
                    objEFCI = null;
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
            return fondos;
        }

        public static Entidades.Inversion ObtenerUna(int pCodigoInversion) {
            Entidades.Inversion objEInversion = new Entidades.Inversion();
            strProc = "SP_INVERSIONES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoInversion);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objEInversion.Codigo = Convert.ToInt32(objDataReader["CodigoInversion"]);
                objEInversion.PlazoDias = objDataReader["PlazosDias"].ToString().Equals("") ?0: Convert.ToInt32(objDataReader["PlazosDias"]);
                objEInversion.CapitalInvertido = Convert.ToDouble(objDataReader["CapitalInvertido"]);
                objEInversion.FechaInversion= Convert.ToDateTime(objDataReader["Fecha"]);
                objEInversion.FechaVencimiento = objDataReader["FechaVencimiento"].ToString().Equals("")? Convert.ToDateTime("01/01/2010"):Convert.ToDateTime(objDataReader["FechaVencimiento"]);
                objEInversion.TNA= objDataReader["TNA"].ToString().Equals("")? 0 : Convert.ToDouble(objDataReader["TNA"]);
                objEInversion.Intereses = objDataReader["Interes"].ToString().Equals("") ? 0 : Convert.ToDouble(objDataReader["Interes"]);
                objEInversion.Observaciones = objDataReader["Observaciones"].ToString();
                objEInversion.NroReferencia= objDataReader["NroReferencia"].ToString();

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
            return objEInversion;
        }     
    }
}