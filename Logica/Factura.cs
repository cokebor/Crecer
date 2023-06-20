using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Factura
    {
        public int Agregar(Entidades.Factura pFactura, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.Factura.Agregar(pFactura, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarDeVentaInicial(Entidades.Factura pFactura, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.Factura.AgregarDeVentaInicial(pFactura, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //    public int AgregarSaldoInicial(Entidades.Factura pFactura, Entidades.Asiento pAsiento)
        public int AgregarSaldoInicial(Entidades.Factura pFactura)
        {
            try
            {
                return Datos.Factura.AgregarSaldoInicial(pFactura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarLiquidacion(Entidades.Factura pFactura, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.Factura.AgregarLiquidacion(pFactura, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarAjustes(Entidades.Factura pFactura, Entidades.Asiento pAsiento, int pViejos = 0)
        {
            try
            {
                return Datos.Factura.AgregarAjustes(pFactura, pAsiento, pViejos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarChequesRechazados(Entidades.Factura pFactura, string pMotivo, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.Factura.AgregarChequesRechazados(pFactura, pMotivo, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerPorClienteParaNCLotesViejas(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta)
        {
            try
            {
                return Datos.Factura.ObtenerPorClienteParaNCLotesViejas(pCliente, pDesde, pHasta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerPorClienteParaNCViejas(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.Factura.ObtenerPorClienteParaNCViejas(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public DataTable ObtenerPorClienteParaNCLotes(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta, bool pConDescuentos)
        {
            try
            {
                return Datos.Factura.ObtenerPorClienteParaNCLotes(pCliente, pDesde, pHasta, pConDescuentos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerUno(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerUno(pCodigo);
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
        public DataTable ObtenerFechas(Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerFechas();
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerFechas();
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerFechas();
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerFechas();
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerFechas();
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerFechas();
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerFechas();
                            break;
                    }
                }
                return dt;
                /*if (pSucursal == 1)
                {
                    //return DatosIntegracion.Asiento.ObtenerFechas(pEjercicio);
                    return DatosIntegracion.Factura.ObtenerFechas();
                }
                else
                {
                    return Datos.Factura.ObtenerFechas();
                }*/

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string ObtenerObservaciones(int pCodigoTipoDocumentoCliente, int pCodigo)
        {
            try
            {
                return Datos.Factura.ObtenerObservaciones(pCodigoTipoDocumentoCliente, pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerIVA(DateTime pDesde, DateTime pHasta, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.Factura.ObtenerIVA(pDesde, pHasta);
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerIVA(pDesde, pHasta);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerIVA(pDesde, pHasta);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerIVA(pDesde, pHasta);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerIVA(pDesde, pHasta);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerIVA(pDesde, pHasta);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerIVA(pDesde, pHasta);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerIVA(pDesde, pHasta);
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

        public void Anular(Entidades.Factura pFactura)
        {
            try
            {
                Datos.Factura.Anular(pFactura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerPorCliente(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.Factura.ObtenerPorCliente(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarObservaciones(int pCodigoTipoDocumento, int pCodigo, string pObservaciones)
        {
            try
            {
                Datos.Factura.AgregarObservaciones(pCodigoTipoDocumento, pCodigo, pObservaciones);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerPorCliente(Entidades.Cliente pCliente, int pCodigoTipoDocumentoCliente)
        {
            try
            {
                return Datos.Factura.ObtenerPorCliente(pCliente, pCodigoTipoDocumentoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerVentasIniciales()
        {
            try
            {
                return Datos.Factura.ObtenerVentasIniciales();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.Factura ObtenerUna(int pCodigo)
        {
            try
            {
                return Datos.Factura.ObtenerUna(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Factura ObtenerUnaVentasIniciales(int pCodigo)
        {
            try
            {
                return Datos.Factura.ObtenerUnaVentasIniciales(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.Factura ObtenerUnaParaNCLote(int pCodigo, int pViejo, bool pConDescuento)
        {
            try
            {
                return Datos.Factura.ObtenerUnaParaNCLote(pCodigo, pViejo, pConDescuento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFechasIntegracion(int pCodigoSucursal)
        {
            try
            {
                if (pCodigoSucursal == 1)
                {
                    return DatosIntegracion.Factura.ObtenerFechas();
                }
                else
                {
                    return Datos.Factura.ObtenerFechas();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFechasPerMunicipales(int pCodigoSucursal)
        {
            try
            {
                if (pCodigoSucursal == 1)
                {
                    return DatosIntegracion.Factura.ObtenerFechasPerMunicipales();
                }
                else
                {
                    return Datos.Factura.ObtenerFechasPerMunicipales();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ObtenerFacturaAfectada(int pCodigo)
        {
            try
            {
                return Datos.Factura.ObtenerFacturaAfectada(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Factura ObtenerUnaAjuste(int pCodigo)
        {
            try
            {
                return Datos.Factura.ObtenerUnaAjuste(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Factura ObtenerUnaAjuste(int pCodigo,int pViejos)
        {
            try
            {
                return Datos.Factura.ObtenerUnaAjuste(pCodigo,pViejos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFacturasSinImputar(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.Factura.ObtenerFacturasSinImputar(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFacturasParaImputar(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.Factura.ObtenerFacturasParaImputar(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosPorFecha(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerTodosPorFecha(pCliente, pDesde, pHasta);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerTodosPorFecha(pCliente, pDesde, pHasta);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerTodosPorFecha(pCliente, pDesde, pHasta);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerTodosPorFecha(pCliente, pDesde, pHasta);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerTodosPorFecha(pCliente, pDesde, pHasta);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerTodosPorFecha(pCliente, pDesde, pHasta);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerTodosPorFecha(pCliente, pDesde, pHasta);
                            break;
                        case 0:
                            dt = DatosIntegracion.Factura.ObtenerTodosPorFecha(pCliente, pDesde, pHasta);
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

        public DataTable ObtenerComprobantesCtasCorrientesClientes(char pCodigoTipoComprobante,Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerComprobantesCtasCorrientesClientes(pCodigoTipoComprobante, pCliente, pDesde, pHasta);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerComprobantesCtasCorrientesClientes(pCodigoTipoComprobante, pCliente, pDesde, pHasta);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerComprobantesCtasCorrientesClientes(pCodigoTipoComprobante, pCliente, pDesde, pHasta);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerComprobantesCtasCorrientesClientes(pCodigoTipoComprobante, pCliente, pDesde, pHasta);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerComprobantesCtasCorrientesClientes(pCodigoTipoComprobante, pCliente, pDesde, pHasta);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerComprobantesCtasCorrientesClientes(pCodigoTipoComprobante, pCliente, pDesde, pHasta);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerComprobantesCtasCorrientesClientes(pCodigoTipoComprobante, pCliente, pDesde, pHasta);
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
        public Entidades.Factura ObtenerFactura(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                Entidades.Factura objEFactura = new Entidades.Factura();
                if (pSucursal == null)
                    objEFactura = Datos.Factura.ObtenerFactura(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            objEFactura = Datos.Factura.ObtenerFactura(pCodigo);
                            break;
                        case 2:
                            objEFactura = DatosWiki.Factura.ObtenerFactura(pCodigo);
                            break;
                        case 3:
                            objEFactura = DatosNave7.Factura.ObtenerFactura(pCodigo);
                            break;
                        case 4:
                            objEFactura = DatosVillaMaria.Factura.ObtenerFactura(pCodigo);
                            break;
                        case 5:
                            objEFactura = DatosRioCuarto.Factura.ObtenerFactura(pCodigo);
                            break;
                        case 7:
                            objEFactura = DatosSucursal6.Factura.ObtenerFactura(pCodigo);
                            break;
                    }
                }
                return objEFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFacturasCuentaCorriente(Entidades.Cliente pCliente, DateTime pDesde, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerFacturasCuentaCorriente(pCliente, pDesde);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerFacturasCuentaCorriente(pCliente, pDesde);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerFacturasCuentaCorriente(pCliente, pDesde);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerFacturasCuentaCorriente(pCliente, pDesde);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerFacturasCuentaCorriente(pCliente, pDesde);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerFacturasCuentaCorriente(pCliente, pDesde);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerFacturasCuentaCorriente(pCliente, pDesde);
                            break;
                        case 0:
                            dt = DatosIntegracion.Factura.ObtenerFacturasCuentaCorriente(pCliente, pDesde);
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

        public DataTable ObtenerFacturasSinImputarPorCliente(Entidades.Cliente pCliente, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerFacturasSinImputarPorCliente(pCliente);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerFacturasSinImputarPorCliente(pCliente);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerFacturasSinImputarPorCliente(pCliente);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerFacturasSinImputarPorCliente(pCliente);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerFacturasSinImputarPorCliente(pCliente);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerFacturasSinImputarPorCliente(pCliente);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerFacturasSinImputarPorCliente(pCliente);
                            break;
                        case 0:
                            dt = DatosIntegracion.Factura.ObtenerFacturasSinImputarPorCliente(pCliente);
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

        public List<Entidades.CITIVentas> ObtenerCITIVentas(DateTime pDesde, DateTime pHasta, int pSucursal)
        {
            try
            {
                List<Entidades.CITIVentas> citi = new List<Entidades.CITIVentas>();
                switch (pSucursal)
                {
                    case 1:
                        citi = DatosIntegracion.Factura.ObtenerCITIVentas(pDesde, pHasta);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        citi = Datos.Factura.ObtenerCITIVentas(pDesde, pHasta);
                        break;
                }

                return citi;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entidades.PercepcionesMunicipales> ObtenerPercepcionesMunicipales(DateTime pDesde, DateTime pHasta, int pSucursal)
        {
            try
            {
                List<Entidades.PercepcionesMunicipales> per = new List<Entidades.PercepcionesMunicipales>();
                switch (pSucursal)
                {
                    case 1:
                        per = DatosIntegracion.Factura.ObtenerPercepcionesMunicipales(pDesde, pHasta);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        per = Datos.Factura.ObtenerPercepcionesMunicipales(pDesde, pHasta);
                        break;
                }

                return per;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerFacturasAnuladasIvaDigital(DateTime pDesde, DateTime pHasta, int pSucursal)
        {
            try
            {
                DataTable dt = new DataTable();
                switch (pSucursal)
                {
                    case 1:
                        dt = DatosIntegracion.Factura.ObtenerFacturasAnuladasIvaDigital(pDesde, pHasta);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        dt = Datos.Factura.ObtenerFacturasAnuladasIvaDigital(pDesde, pHasta);
                        break;
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Entidades.CITICompras> ObtenerCITICompras(DateTime pDesde, DateTime pHasta, Entidades.Empresa pEmpresa)
        {
            try
            {
                return Datos.Factura.ObtenerCITICompras(pDesde, pHasta, pEmpresa);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerIngresosBrutos(DateTime pDesde, DateTime pHasta, int pSucursal)
        {
            try
            {
                DataTable dt = new DataTable();
                switch (pSucursal)
                {
                    case 1:
                        dt = Datos.Factura.ObtenerIngresosBrutosDeposito(pDesde, pHasta);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                        break;
                        /*   case 3:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                           case 4:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                           case 5:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                           case 6:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                           case 7:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                               */
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarDescuento(Entidades.Factura pFactura, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.Factura.AgregarDescuento(pFactura, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerEncabezadoLiquidacion(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            //return Datos.Factura.ObtenerEncabezadoLiquidacion(pCodigo);
            try
            {
                //Entidades.Factura objEFactura = new Entidades.Factura();
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerEncabezadoLiquidacion(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerEncabezadoLiquidacion(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerEncabezadoLiquidacion(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerEncabezadoLiquidacion(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerEncabezadoLiquidacion(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerEncabezadoLiquidacion(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerEncabezadoLiquidacion(pCodigo);
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

        public DataTable ObtenerMermasLiquidacion(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.FacturaCompra.ObtenerMermasLiquidacion(pCodigo);
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerMermasLiquidacion(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerMermasLiquidacion(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerMermasLiquidacion(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerMermasLiquidacion(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerMermasLiquidacion(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerMermasLiquidacion(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerMermasLiquidacion(pCodigo);
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

        public DataTable ObtenerDetallesLiquidacion(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.FacturaCompra.ObtenerMermasLiquidacion(pCodigo);
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.ObtenerDetallesLiquidacion(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.ObtenerDetallesLiquidacion(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.ObtenerDetallesLiquidacion(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.ObtenerDetallesLiquidacion(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.ObtenerDetallesLiquidacion(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.ObtenerDetallesLiquidacion(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.ObtenerDetallesLiquidacion(pCodigo);
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

        public DataTable ObtenerImputacionesDetalle(Entidades.PagoCliente pPago)
        {
            try
            {
                return Datos.Factura.ObtenerImputacionesDetalle(pPago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerLiquidacionesPorCliente(DateTime pDesde, DateTime pHasta, Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.Factura.ObtenerLiquidacionesPorCliente(pDesde, pHasta, pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable VentasPorEmpleados(DateTime pDesde, DateTime pHasta,Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.FacturaCompra.ObtenerMermasLiquidacion(pCodigo);
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.VentasPorEmpleados(pDesde, pHasta);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.VentasPorEmpleados(pDesde, pHasta);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.VentasPorEmpleados(pDesde, pHasta);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.VentasPorEmpleados(pDesde, pHasta);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.VentasPorEmpleados(pDesde, pHasta);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.VentasPorEmpleados(pDesde, pHasta);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.VentasPorEmpleados(pDesde, pHasta);
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
        public DataTable VentasPorEmpleadosDetalle(DateTime pDesde, DateTime pHasta, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.FacturaCompra.ObtenerMermasLiquidacion(pCodigo);
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Factura.VentasPorEmpleadosDetalle(pDesde, pHasta);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Factura.VentasPorEmpleadosDetalle(pDesde, pHasta);
                            break;
                        case 2:
                            dt = DatosWiki.Factura.VentasPorEmpleadosDetalle(pDesde, pHasta);
                            break;
                        case 3:
                            dt = DatosNave7.Factura.VentasPorEmpleadosDetalle(pDesde, pHasta);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Factura.VentasPorEmpleadosDetalle(pDesde, pHasta);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Factura.VentasPorEmpleadosDetalle(pDesde, pHasta);
                            break;
                        case 7:
                            dt = DatosSucursal6.Factura.VentasPorEmpleadosDetalle(pDesde, pHasta);
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
