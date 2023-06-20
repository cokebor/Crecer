using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class PagoCliente
    {
        public int Agregar(Entidades.PagoCliente pPago,Entidades.Asiento pAsiento ,int pCodigoRecibo)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {
                return Datos.PagoCliente.Agregar(pPago, pAsiento, pCodigoRecibo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDataTable(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.PagoCliente.ObtenerDataTable(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.PagoCliente.ObtenerDataTable(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.PagoCliente.ObtenerDataTable(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.PagoCliente.ObtenerDataTable(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.PagoCliente.ObtenerDataTable(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.PagoCliente.ObtenerDataTable(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.PagoCliente.ObtenerDataTable(pCodigo);
                            break;
                    }
                }
                return dt;

                //return Datos.PagoCliente.ObtenerDataTable(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerEfectivoUno(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.PagoCliente.ObtenerEfectivoUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.PagoCliente.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.PagoCliente.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.PagoCliente.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.PagoCliente.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.PagoCliente.ObtenerEfectivoUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.PagoCliente.ObtenerEfectivoUno(pCodigo);
                            break;
                    }
                }
                return dt;
                // return Datos.PagoCliente.ObtenerEfectivoUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTranferenciasUno(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.PagoCliente.ObtenerTranferenciasUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.PagoCliente.ObtenerTranferenciasUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.PagoCliente.ObtenerTranferenciasUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.PagoCliente.ObtenerTranferenciasUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.PagoCliente.ObtenerTranferenciasUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.PagoCliente.ObtenerTranferenciasUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.PagoCliente.ObtenerTranferenciasUno(pCodigo);
                            break;
                    }
                }
                return dt;
                // return Datos.PagoCliente.ObtenerEfectivoUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDebitoCreditoUno(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.PagoCliente.ObtenerDebitoCreditoUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.PagoCliente.ObtenerDebitoCreditoUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.PagoCliente.ObtenerDebitoCreditoUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.PagoCliente.ObtenerDebitoCreditoUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.PagoCliente.ObtenerDebitoCreditoUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.PagoCliente.ObtenerDebitoCreditoUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.PagoCliente.ObtenerDebitoCreditoUno(pCodigo);
                            break;
                    }
                }
                return dt;
                // return Datos.PagoCliente.ObtenerEfectivoUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDebitosCreditos(Entidades.CuentaBancaria pCuentaBancaria, TipoDeTarjetas pTipoTarjeta, Entidades.FormaDePago pFormaDePago, Entidades.Sucursal pSucursal=null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.PagoCliente.ObtenerDebitosCreditos(pCuentaBancaria,pTipoTarjeta,pFormaDePago);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.PagoCliente.ObtenerDebitosCreditos(pCuentaBancaria, pTipoTarjeta, pFormaDePago);
                            break;
                        case 2:
                            dt = DatosWiki.PagoCliente.ObtenerDebitosCreditos(pCuentaBancaria, pTipoTarjeta, pFormaDePago);
                            break;
                        case 3:
                            dt = DatosNave7.PagoCliente.ObtenerDebitosCreditos(pCuentaBancaria, pTipoTarjeta, pFormaDePago);
                            break;
                        case 4:
                            dt = DatosVillaMaria.PagoCliente.ObtenerDebitosCreditos(pCuentaBancaria, pTipoTarjeta, pFormaDePago);
                            break;
                        case 5:
                            dt = DatosRioCuarto.PagoCliente.ObtenerDebitosCreditos(pCuentaBancaria, pTipoTarjeta, pFormaDePago);
                            break;
                        case 7:
                            dt = DatosSucursal6.PagoCliente.ObtenerDebitosCreditos(pCuentaBancaria, pTipoTarjeta, pFormaDePago);
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
                    dt = Datos.PagoCliente.ObtenerChequesUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.PagoCliente.ObtenerChequesUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.PagoCliente.ObtenerChequesUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.PagoCliente.ObtenerChequesUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.PagoCliente.ObtenerChequesUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.PagoCliente.ObtenerChequesUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.PagoCliente.ObtenerChequesUno(pCodigo);
                            break;
                    }
                }
                return dt;
               // return Datos.PagoCliente.ObtenerChequesUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerImputacionesUno(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.PagoCliente.ObtenerImputacionesUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.PagoCliente.ObtenerImputacionesUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.PagoCliente.ObtenerImputacionesUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.PagoCliente.ObtenerImputacionesUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.PagoCliente.ObtenerImputacionesUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.PagoCliente.ObtenerImputacionesUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.PagoCliente.ObtenerImputacionesUno(pCodigo);
                            break;
                    }
                }
                return dt;
              //  return Datos.PagoCliente.ObtenerImputacionesUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerPagosPorCliente(int pCodigo, DateTime pFecha)
        {
            try
            {
                return Datos.PagoCliente.ObtenerPagosPorCliente(pCodigo, pFecha);
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
                return Datos.PagoCliente.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerParaImputar(Entidades.Cliente pCliente) {
            try
            {
                return Datos.PagoCliente.ObtenerParaImputar(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Imputar(Entidades.PagoCliente pPago) {
            try
            {
                Datos.PagoCliente.Imputar(pPago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerImpuestosUno(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.PagoCliente.ObtenerImpuestosUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.PagoCliente.ObtenerImpuestosUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.PagoCliente.ObtenerImpuestosUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.PagoCliente.ObtenerImpuestosUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.PagoCliente.ObtenerImpuestosUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.PagoCliente.ObtenerImpuestosUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.PagoCliente.ObtenerImpuestosUno(pCodigo);
                            break;
                    }
                }
                return dt;
                //  return Datos.PagoCliente.ObtenerImputacionesUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Imputar(Entidades.PagoCliente pPago,int pCodigoTipo, int pFactura)
        {
            try
            {
                Datos.PagoCliente.Imputar(pPago, pCodigoTipo, pFactura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
