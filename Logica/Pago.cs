using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica
{
    public class Pago
    {
        public int Agregar(Entidades.Pago pPago, Entidades.Asiento pAsiento, int pCodigoRecibo)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {
                return Datos.Pago.Agregar(pPago, pAsiento, pCodigoRecibo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDataTable(int pCodigo)
        {
            try
            {
                return Datos.Pago.ObtenerDataTable(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerEfectivoUno(int pCodigo, Entidades.Sucursal pSucursal=null)
        {
           try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Pago.ObtenerEfectivoUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Pago.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.Pago.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.Pago.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Pago.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Pago.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.Pago.ObtenerEfectivoUno(pCodigo);
                            break;
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        public DataTable ObtenerChequesUno(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Pago.ObtenerChequesUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Pago.ObtenerChequesUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.Pago.ObtenerChequesUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.Pago.ObtenerChequesUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Pago.ObtenerChequesUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Pago.ObtenerChequesUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.Pago.ObtenerChequesUno(pCodigo);
                            break;
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerChequesRechazadosUno(int pCodigo)
        {
            try
            {
                return Datos.Pago.ObtenerChequesRechazadosUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
            public DataTable ObtenerPagosChequesProveedores(int pCodigoProveedor)
        {
            try
            {
                return Datos.Pago.ObtenerPagosChequesProveedores(pCodigoProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFechasRetMunicipales()
        {
            try
            {
                    return Datos.Pago.ObtenerFechasRetMunicipales();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerImputacionesUno(int pCodigo)
        {
            try
            {
                return Datos.Pago.ObtenerImputacionesUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerImpuestosUno(int pCodigo)
        {
            try
            {
                return Datos.Pago.ObtenerImpuestosUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTranferenciasUno(int pCodigo)
        {
            try
            {
                return Datos.Pago.ObtenerTranferenciasUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerDebitoCreditoUno(int pCodigo)
        {
            try
            {
                return Datos.Pago.ObtenerDebitoCreditoUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerPagosPorProveedor(int pCodigo, DateTime pFecha)
        {
            try
            {
                return Datos.Pago.ObtenerPagosPorProveedor(pCodigo, pFecha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Pago.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerRetenciones(int pCodigoPago)
        {
            try
            {
                return Datos.Pago.ObtenerRetenciones(pCodigoPago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerRetencionesMunicipales(int pCodigoPago)
        {
            try
            {
                DataTable dt = new DataTable();
                dt= Datos.Pago.ObtenerRetencionesMunicipales(pCodigoPago);
                if (dt.Rows.Count > 0) { 
                DataColumn dc = new DataColumn("ImporteRetenidoEnLetras", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dt.Rows[0]["ImporteRetenidoEnLetras"] = Utilidades.NumeroEnLetras.Convertir(dt.Rows[0]["ImporteRetenido"].ToString(), false,"pesos con");
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerParaImputar(Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.Pago.ObtenerParaImputar(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Imputar(Entidades.Pago pPago)
        {
            try
            {
                Datos.Pago.Imputar(pPago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Imputar(Entidades.Pago pPago, int pFactura)
        {
            try
            {
                Datos.Pago.Imputar(pPago, pFactura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.RetencionesGanancias ObtenerTotalPagosRetenciones(int pCodigoProveedor, DateTime pDesde, DateTime pHasta) {
            try
            {
                return Datos.Pago.ObtenerTotalPagosRetenciones(pCodigoProveedor, pDesde, pHasta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Entidades.RetencionesMunicipales> ObtenerRetencionesMunicipales(DateTime pDesde, DateTime pHasta)
        {
            try
            {

                return Datos.Pago.ObtenerRetencionesMunicipales(pDesde, pHasta);
                            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object ObtenerPagosPendientesConciliar(Entidades.Sucursal pSucursal)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Pago.ObtenerPagosPendientesConciliar();
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Pago.ObtenerPagosPendientesConciliar();
                            break;
                        case 2:
                            dt = DatosWiki.Pago.ObtenerPagosPendientesConciliar();
                            break;
                        case 3:
                            dt = DatosNave7.Pago.ObtenerPagosPendientesConciliar();
                            break;
                        case 4:
                            dt = DatosVillaMaria.Pago.ObtenerPagosPendientesConciliar();
                            break;
                        case 5:
                            dt = DatosRioCuarto.Pago.ObtenerPagosPendientesConciliar();
                            break;
                        case 7:
                            dt = DatosSucursal6.Pago.ObtenerPagosPendientesConciliar();
                            break;
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
