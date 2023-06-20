using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DatosIntegracion
{
    public static class Factura
    {
        private static string strProc = string.Empty;
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        static Factura()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexionIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ObtenerTodosPorFecha(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta);
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

        public static DataTable ObtenerFacturasCuentaCorriente(Entidades.Cliente pCliente, DateTime pDesde)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_CUENTASCORRIENTEPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@FechaDesde", pDesde);
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
        public static DataTable ObtenerFacturasSinImputarPorCliente(Entidades.Cliente pCliente)
        {
            DataTable dt = new DataTable();
            strProc = "SP_FACTURAS_SINIMPUTARPORCLIENTE_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", pCliente.Codigo);
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

        public static DataTable ObtenerFechas()
        {
            DataTable dt = new DataTable();
            strProc = "SP_IVAVENTAS_FECHAS_SELECT";
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

        public static DataTable ObtenerFechasPerMunicipales()
        {
            DataTable dt = new DataTable();
            strProc = "SP_PERCEPCIONESMUNICIPALES_FECHAS_SELECT";
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

        
        public static List<CITIVentas> ObtenerCITIVentas(DateTime pDesde, DateTime pHasta)
        {
            List<CITIVentas> listaCiti = new List<CITIVentas>();
            Entidades.CITIVentas citi;
            
            strProc = "SP_CITIVENTAS_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows.Equals(false))
                {
                    listaCiti = null;
                }
                else
                {
                    while (objDataReader.Read())
                    {
                        citi = new CITIVentas();
                        citi.Fecha= Convert.ToDateTime(objDataReader["Fecha"]);
                        citi.CodigoTipoDocumentoAFIP = Convert.ToInt32(objDataReader["CodigoTipoDocumentoAFIP"]);
                        citi.PuntoDeVenta = Convert.ToInt32(objDataReader["PuntoDeVenta"]);
                        citi.Numero = Convert.ToInt32(objDataReader["Numero"]);
                        citi.CodigoDocumentoComprador = Convert.ToInt32(objDataReader["CodigoDocumento"]);
                        citi.CUIT = objDataReader["CUIT"].ToString();
                        citi.Cliente= objDataReader["Cliente"].ToString();
                        citi.Total= Convert.ToInt64(objDataReader["Total"]);
                        citi.TotalConceptosQueNoIntegranNetoGravado = 0;
                        citi.PercepcionNoCategorizados = 0;
                        citi.OperacionesExentas= Convert.ToInt32(objDataReader["OperacionesExentas"]);
                        citi.ImportePercepciones = 0;
                        citi.ImportePercepcionesIIBB = 0;
                        citi.ImportePercepcionesMunicipales = Convert.ToInt32(objDataReader["PercepcionMunicipal"]);
                        citi.ImporteImpuestosInternos = 0;
                        citi.CodigoMoneda = "PES";
                        citi.TipoCambio = 1;
                        Entidades.CITIVentasAlicuotas alicuota;
                        if (Convert.ToInt32(objDataReader["iva105"]) > 0) {
                            alicuota = new CITIVentasAlicuotas();
                            alicuota.NetoGravado = Convert.ToInt64(objDataReader["Neto105"]);
                            alicuota.CodigoAlicuotaAFIP = 4;
                            alicuota.ImpuestoLiquidado= Convert.ToInt64(objDataReader["iva105"]);
                            citi.Alicuotas.Add(alicuota);
                        }
                        if (Convert.ToInt32(objDataReader["iva21"]) > 0)
                        {
                            alicuota = new CITIVentasAlicuotas();
                            alicuota.NetoGravado = Convert.ToInt64(objDataReader["Neto21"]);
                            alicuota.CodigoAlicuotaAFIP = 5;
                            alicuota.ImpuestoLiquidado = Convert.ToInt64(objDataReader["iva21"]);
                            citi.Alicuotas.Add(alicuota);
                        }
                        if (citi.Alicuotas.Count == 0)
                        {
                            alicuota = new CITIVentasAlicuotas();
                            alicuota.NetoGravado = 0;
                            alicuota.CodigoAlicuotaAFIP = 3;
                            alicuota.ImpuestoLiquidado = 0;
                            citi.Alicuotas.Add(alicuota);
                            citi.CodigoOperacion = "N";
                        }
                        else {
                            citi.CodigoOperacion = "0";
                        }

                        
                        listaCiti.Add(citi);
                        
                    }
                }
                objDataReader.Close();
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
            return listaCiti;
        }
        public static DataTable ObtenerFacturasAnuladasIvaDigital(DateTime pDesde, DateTime pHasta)
        {
            DataTable dt = new DataTable();

            strProc = "SP_IVADIGITALVENTASANULADAS_SELECT";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
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

        public static List<PercepcionesMunicipales> ObtenerPercepcionesMunicipales(DateTime pDesde, DateTime pHasta)
        {
            List<PercepcionesMunicipales> lista = new List<PercepcionesMunicipales>();
            Entidades.PercepcionesMunicipales per;

            strProc = "SP_PERCEPCIONESMUNICIPALES_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Desde", pDesde.Date);
            objCommand.Parameters.AddWithValue("@Hasta", pHasta.Date);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows.Equals(false))
                {
                    lista = null;
                }
                else
                {
                    while (objDataReader.Read())
                    {
                        per = new PercepcionesMunicipales();
                        //per.CuitEmpresa = objDataReader["CuitEmpresa"].ToString();
                        per.NroPercepcion = objDataReader["NroPercepcion"].ToString();
                        per.LetraPercepcion = Convert.ToChar(objDataReader["LetraPercepcion"].ToString());
                        per.Comprobante = objDataReader["Comprobante"].ToString();
                        per.CuitCliente = objDataReader["CuitCliente"].ToString();
                        per.BaseImponible = Convert.ToDouble(objDataReader["BaseImponible"]);
                        per.Alicuota = Convert.ToDouble(objDataReader["Alicuota"]);
                        per.MontoPercepcion = Convert.ToDouble(objDataReader["MontoPercepcion"]);
                        per.Estado = Convert.ToChar(objDataReader["Estado"].ToString());
                        per.Fecha = Convert.ToDateTime(objDataReader["Fecha"]);
                        per.NombreCliente = objDataReader["NombreCliente"].ToString();
                        per.Calle = objDataReader["Calle"].ToString();
                        per.Numero = objDataReader["Numero"].ToString();
                        per.BarrioLocalidad = objDataReader["BarrioLocalidad"].ToString();
                        per.CodigoPostal = objDataReader["CodigoPostal"].ToString();
                        per.FechaInicioPercepcion = Convert.ToDateTime(objDataReader["FechaInicioPercepcion"]);
                        per.FechaCambiosDatos = Convert.ToDateTime(objDataReader["FechaCambioDatos"]);


                        lista.Add(per);

                    }
                }
                objDataReader.Close();
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
            return lista;
        }
    }
}
