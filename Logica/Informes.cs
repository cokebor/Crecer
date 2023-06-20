using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public static class Informes
    {
        public static List<DataTable> PagosProveedores(int codigoPago)
        {
            Pago objLPago = new Pago();
            List<DataTable> lista = new List<DataTable>();
            lista.Add(new Logica.Empresa().ObtenerDataTable());
            lista.Add(objLPago.ObtenerDataTable(codigoPago));
            lista.Add(objLPago.ObtenerEfectivoUno(codigoPago));
            lista.Add(objLPago.ObtenerChequesUno(codigoPago));
            lista.Add(objLPago.ObtenerChequesRechazadosUno(codigoPago));
            lista.Add(objLPago.ObtenerImputacionesUno(codigoPago));
            lista.Add(objLPago.ObtenerTranferenciasUno(codigoPago));
            lista.Add(objLPago.ObtenerDebitoCreditoUno(codigoPago));
            lista.Add(objLPago.ObtenerImpuestosUno(codigoPago));
            lista.Add(objLPago.ObtenerRetenciones(codigoPago));
            lista.Add(objLPago.ObtenerRetencionesMunicipales(codigoPago));
            //Utilidades.Formularios.AbrirFuera(new frmInformes("COMPROBANTE DE PAGO", lista, "repProveedoresPagos"));
            return lista;
        }
        
        public static List<DataTable> CajaGastos(int codigoCaja, string pSucursal)
        {
            Caja objLCaja = new Caja();
            List<DataTable> lista = new List<DataTable>();
            Entidades.Caja c = new Entidades.Caja();
            c.Codigo = codigoCaja;
            DataTable dt = new DataTable();
            dt.TableName = "dsEmpresa";
            dt.Columns.Add("RazonSocial", Type.GetType("System.String"));
            dt.Rows.Add(pSucursal);
            lista.Add(dt);
            lista.Add(objLCaja.ObtenerUna(codigoCaja));
            lista.Add(objLCaja.ObtenerDetalle(codigoCaja));
            lista.Add(objLCaja.ObtenerEfectivoGasto(codigoCaja));
            lista.Add(objLCaja.ObtenerChequesGasto(codigoCaja));
            lista.Add(objLCaja.ObtenerTranferenciasGasto(codigoCaja));
            lista.Add(objLCaja.ObtenerDebitoCreditoGasto(codigoCaja));
            lista.Add(objLCaja.ObtenerImpuestosGasto(codigoCaja));
            //lista.Add(objLPago.ObtenerDebitoCreditoUno(codigoPago));
            return lista;
        }
        public static List<DataTable> CajaDepositos(int codigoCaja, string pSucursal)
        {
            Caja objLCaja = new Caja();
            List<DataTable> lista = new List<DataTable>();
            Entidades.Caja c = new Entidades.Caja();
            c.Codigo = codigoCaja;
            DataTable dt = new DataTable();
            dt.TableName = "dsEmpresa";
            dt.Columns.Add("RazonSocial", Type.GetType("System.String"));
            dt.Rows.Add(pSucursal);
            lista.Add(dt);
            lista.Add(objLCaja.ObtenerUna(codigoCaja));
            lista.Add(objLCaja.ObtenerCuentaBancaria(codigoCaja));
            //lista.Add(objLCaja.ObtenerDetalle(codigoCaja));
            lista.Add(objLCaja.ObtenerEfectivoGasto(codigoCaja));
            lista.Add(objLCaja.ObtenerChequesGasto(codigoCaja));
            //lista.Add(objLPago.ObtenerDebitoCreditoUno(codigoPago));
            return lista;
        }
        public static List<DataTable> CajaEgresosSucursales(int codigoCaja, string pSucursal)
        {
            Caja objLCaja = new Caja();
            List<DataTable> lista = new List<DataTable>();
            Entidades.Caja c = new Entidades.Caja();
            c.Codigo = codigoCaja;
            DataTable dt = new DataTable();
            dt.TableName = "dsEmpresa";
            dt.Columns.Add("RazonSocial", Type.GetType("System.String"));
            dt.Rows.Add(pSucursal);
            lista.Add(dt);
            lista.Add(objLCaja.ObtenerUna(codigoCaja));
            lista.Add(objLCaja.ObtenerEfectivoGasto(codigoCaja));
            lista.Add(objLCaja.ObtenerChequesGasto(codigoCaja));
            //lista.Add(objLPago.ObtenerDebitoCreditoUno(codigoPago));
            return lista;
        }
    }
}
