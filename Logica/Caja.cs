using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class Caja
    {
        public int Agregar(Entidades.Caja pCaja, Entidades.Asiento pAsiento, string tipo)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {
                int val = 0;
                switch (tipo)
                {
                    case "Egreso":
                        val = Datos.Caja.AgregarEgreso(pCaja, pAsiento);
                        break;
                    case "Ingresos":
                        val = Datos.Caja.AgregarIngreso(pCaja, pAsiento);
                        break;
                    case "Gastos":
                        val = Datos.Caja.AgregarGasto(pCaja, pAsiento);
                        break;
                    case "Deposito":
                        val = Datos.Caja.AgregarDeposito(pCaja, pAsiento);
                        break;
                  /*  case "PagoSueldo":
                        val = Datos.Caja.AgregarPagoSalario(pCaja,pSalario, pAsiento);
                        break;*/
                }
                return val;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarPagoDevengamiento(Entidades.Caja pCaja, Entidades.Devengamiento pDevengamiento, Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {

               return Datos.Caja.AgregarPagoDevengamiento(pCaja, pDevengamiento, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int AgregarRendicion(Entidades.Caja pCaja, Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {
                return Datos.Caja.AgregarRendicion(pCaja, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Anular(Entidades.Caja pCaja)
        {
            try
            {
                Datos.Caja.Anular(pCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AnularSucursal(Entidades.Caja pCaja)
        {
            try
            {
                Datos.Caja.AnularSucursal(pCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable ObtenerFormasDePagoGasto(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerFormasDePagoGasto(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerChequesGasto(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerChequesGasto(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object ObtenerChequesDepositados(Entidades.CuentaBancaria pCuentaBancaria, int pCodigoBancoEmision)
        {
            try
            {
                return Datos.Caja.ObtenerChequesDepositados(pCuentaBancaria, pCodigoBancoEmision);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerCajasConCheques(Entidades.CuentaBancaria pCuentaBancaria)
        {
            try
            {
                return Datos.Caja.ObtenerCajasConCheques(pCuentaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTranferenciasGasto(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerTranferenciasGasto(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerImpuestosGasto(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerImpuestosGasto(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerDebitoCreditoGasto(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerDebitoCreditoGasto(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public object ObtenerLibreDisponibilidad(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerLibreDisponibilidad(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerEfectivoGasto(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerEfectivoGasto(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerRendiciones(DateTime pDesde, DateTime pHasta, int pSucursal) {
            try
            {
                return Datos.Caja.ObtenerRendiciones(pDesde, pHasta, pSucursal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerSaldoInicial(DateTime pFecha)
        {
            try
            {
                return Datos.Caja.ObtenerSaldoInicial(pFecha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerPagos()
        {
            try
            {
                return Datos.Caja.ObtenerPagos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object ObtenerDepositoChequesSucursalesPendientes(Entidades.CuentaBancaria pCuentaBancaria, Entidades.Sucursal pSucursal)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Caja.ObtenerDepositoChequesSucursalesPendientes(pCuentaBancaria);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Caja.ObtenerDepositoChequesSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 2:
                            dt = DatosWiki.Caja.ObtenerDepositoChequesSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 3:
                            dt = DatosNave7.Caja.ObtenerDepositoChequesSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Caja.ObtenerDepositoChequesSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Caja.ObtenerDepositoChequesSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 7:
                            dt = DatosSucursal6.Caja.ObtenerDepositoChequesSucursalesPendientes(pCuentaBancaria);
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

        public DataTable ObtenerDepositoSucursalesPendientes(Entidades.CuentaBancaria pCuentaBancaria, Entidades.Sucursal pSucursal)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Caja.ObtenerDepositoSucursalesPendientes(pCuentaBancaria);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Caja.ObtenerDepositoSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 2:
                            dt = DatosWiki.Caja.ObtenerDepositoSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 3:
                            dt = DatosNave7.Caja.ObtenerDepositoSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Caja.ObtenerDepositoSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Caja.ObtenerDepositoSucursalesPendientes(pCuentaBancaria);
                            break;
                        case 7:
                            dt = DatosSucursal6.Caja.ObtenerDepositoSucursalesPendientes(pCuentaBancaria);
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

        public DataTable ObtenerGastos(long pCuenta, DateTime pDesde, DateTime pHasta)
        {
            try
            {
                return Datos.Caja.ObtenerGastos(pCuenta, pDesde,pHasta);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerGastosSucursales(long pCuenta, DateTime pDesde, DateTime pHasta, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Caja.ObtenerGastosSucursales(pCuenta, pDesde, pHasta);
                else

                    switch (pSucursal.Codigo)
                    {
                        case 0:
                            dt = DatosIntegracion.Caja.ObtenerGastosSucursales(pCuenta, pDesde, pHasta);
                            break;
                        case 1:
                            dt = Datos.Caja.ObtenerGastosSucursales(pCuenta, pDesde, pHasta);
                            break;
                        case 2:
                               dt = DatosWiki.Caja.ObtenerGastosSucursales(pCuenta, pDesde, pHasta);
                            break;
                        case 3:
                                 dt = DatosNave7.Caja.ObtenerGastosSucursales(pCuenta, pDesde, pHasta);
                            break;
                        case 4:
                                dt = DatosVillaMaria.Caja.ObtenerGastosSucursales(pCuenta, pDesde, pHasta);
                            break;
                        case 5:
                                 dt = DatosRioCuarto.Caja.ObtenerGastosSucursales(pCuenta, pDesde, pHasta);
                            break;
                        case 7:
                                 dt = DatosSucursal6.Caja.ObtenerGastosSucursales(pCuenta, pDesde, pHasta);
                            break;
                    }
                

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public DataTable ObtenerDetalleGasto(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerDetalleGasto(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerCajasDeVengamientos(Entidades.Devengamiento pDevengamiento)
        {
            try
            {
                return Datos.Caja.ObtenerCajasDeVengamientos(pDevengamiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*public DataTable ObtenerUna(Entidades.Devengamiento pDevengamiento)
        {
            try
            {
                return Datos.Caja.ObtenerUna(pDevengamiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

        public Entidades.Caja ObtenerUna(Entidades.Caja pCaja)
        {
            try
            {
                return Datos.Caja.ObtenerUna(pCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerUna(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerUna(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerCuentaBancaria(int pCodigoCaja)
        {
            try
            {
                return Datos.Caja.ObtenerCuentaBancaria(pCodigoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AnularMovimientosDeCaja(Entidades.Caja pCaja)
        {
            try
            {
                Datos.Caja.AnularMovimientosDeCaja(pCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDetalle(int pCodigo) {
            try
            {
                return Datos.Caja.ObtenerDetalle(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
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

       public DataTable ObtenerEfectivoUno(int pCodigo)
       {
           try
           {
               return Datos.Pago.ObtenerEfectivoUno(pCodigo);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }

       public DataTable ObtenerChequesUno(int pCodigo)
       {
           try
           {
               return Datos.Pago.ObtenerChequesUno(pCodigo);
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
       */
    }
}
