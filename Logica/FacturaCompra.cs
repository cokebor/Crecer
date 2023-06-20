using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class FacturaCompra
    {
        public void Agregar(Entidades.FacturaCompra pFactura, Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {
                Datos.FacturaCompra.Agregar(pFactura, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFechasLiquidaciones()
        {
            try
            {
               
                    return Datos.FacturaCompra.ObtenerFechasLiquidaciones();
        
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

                public DataTable ObtenerFechasDetallesCompras()
        {
            try
            {
               
                    return Datos.FacturaCompra.ObtenerFechasDetallesCompras();
        
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void AgregarChequesRechazados(Entidades.FacturaCompra pFactura,string pMotivo, Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {
                Datos.FacturaCompra.AgregarChequesRechazados(pFactura, pMotivo, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerFechas()
        {
            try
            {
                return Datos.FacturaCompra.ObtenerFechas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerIVA(DateTime pDesde, DateTime pHasta)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerIVA(pDesde, pHasta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFacturasSinImputar(Entidades.Proveedor pProveedor, bool liquidaciones) {
            try
            {
                return Datos.FacturaCompra.ObtenerFacturasSinImputar(pProveedor, liquidaciones);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerPorProveedor(Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerPorProveedor(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.FacturaCompra ObtenerUna(int pCodigo)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerUna(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.FacturaCompra ObtenerUnaAjuste(int pCodigo)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerUnaAjuste(pCodigo);
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
                Datos.FacturaCompra.AgregarObservaciones(pCodigoTipoDocumento, pCodigo, pObservaciones);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarAjustes(Entidades.FacturaCompra pFactura, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.FacturaCompra.AgregarAjustes(pFactura, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarLiquidacion(Entidades.FacturaCompra pFactura, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.FacturaCompra.AgregarLiquidacion(pFactura, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarLiquidacionDeposito(Entidades.FacturaCompra pFactura, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.FacturaCompra.AgregarLiquidacionDeposito(pFactura, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerEncabezadoLiquidacion(int pCodigo)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerEncabezadoLiquidacion(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDetalleLiquidacion(int pCodigo)
        {
            try
            {
                return Datos.FacturaCompra_Detalle.ObtenerDetalleLiquidacion(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerLiquidacionesPorProveedor(DateTime pDesde, DateTime pHasta, Entidades.Proveedor pProveedor, Entidades.Producto pProducto, Entidades.Lote pLote)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerLiquidacionesPorProveedor(pDesde, pHasta, pProveedor,pProducto,pLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerMermasLiquidacion(int pCodigo)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerMermasLiquidacion(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public int AgregarSaldoInicial(Entidades.FacturaCompra pFactura)
        {
            try
            {
                return Datos.FacturaCompra.AgregarSaldoInicial(pFactura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerPorProveedor(Entidades.Proveedor pProveedor, int pCodigoTipoDocumentoProveedor)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerPorProveedor(pProveedor, pCodigoTipoDocumentoProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ObtenerObservaciones(int pCodigoTipoDocumentoProveedor, int pCodigo)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerObservaciones(pCodigoTipoDocumentoProveedor, pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFacturasCuentaCorriente(Entidades.Proveedor pProveedor, DateTime pDesde)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerFacturasCuentaCorriente(pProveedor, pDesde);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFacturasSinImputarPorProveedor(Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerFacturasSinImputarPorProveedor(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Anular(Entidades.FacturaCompra pFactura)
        {
            try
            {
                Datos.FacturaCompra.Anular(pFactura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ValidarExistencia(Entidades.FacturaCompra pFacturaCompra)
        {
            try
            {
                return Datos.FacturaCompra.ValidarExistencia(pFacturaCompra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerLiquidacionesPorProveedor(DateTime pDesde, DateTime pHasta, Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerLiquidacionesPorProveedor(pDesde,pHasta, pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Entidades.FacturaCompra ObtenerFactura(int pCodigo)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerFactura(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DateTime ObtenerFechaUltimaLiquidacion(string pLetra)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerFechaUltimaLiquidacion(pLetra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFacturasParaImputar(Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerFacturasParaImputar(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerImputacionesDetalle(Entidades.Pago pPago)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerImputacionesDetalle(pPago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDetalleFacturasBC(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                return Datos.FacturaCompra_Detalle.ObtenerDetalleFacturasBC(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDetalleFacturasGYBC(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                return Datos.FacturaCompra_Detalle.ObtenerDetalleFacturasGYBC(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerImpuestos(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                return Datos.FacturaCompra_Detalle.ObtenerImpuestos(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ValidarStock(Entidades.FacturaCompra pFacturaCompra)
        {
            try
            {
                Datos.FacturaCompra.ValidarStock(pFacturaCompra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ObtenerSiguienteNumero(Entidades.TipoDocumentoProveedor pTipoDocumentoProveedor, Entidades.Proveedor pEntidadProveedor)
        {
            try
            {
                return Datos.FacturaCompra.ObtenerSiguienteNumero(pTipoDocumentoProveedor, pEntidadProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable OtenerImpuestos(int pCodigo)
        {
            try
            {
                return Datos.FacturaCompra.OtenerImpuestos(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
