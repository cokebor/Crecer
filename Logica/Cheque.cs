using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Cheque
    {
        public DataTable ObtenerEnCartera() {
            try
            {
                return Datos.Cheque.ObtenerEnCartera();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerRechazados()
        {
            try
            {
                return Datos.Cheque.ObtenerRechazados();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerADPorCierre(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                // return Datos.Cheque.ObtenerEnCartera();
                try
                {
                    DataTable dt = new DataTable();
                    if (pSucursal == null)
                        dt = Datos.Cheque.ObtenerADPorCierre(pCodigo);
                    else
                    {
                        switch (pSucursal.Codigo)
                        {
                            case 1:
                                dt = Datos.Cheque.ObtenerADPorCierre(pCodigo);
                                break;
                            case 2:
                                dt = DatosWiki.Cheque.ObtenerADPorCierre(pCodigo);
                                break;
                            case 3:
                                dt = DatosNave7.Cheque.ObtenerADPorCierre(pCodigo);
                                break;
                            case 4:
                                dt = DatosVillaMaria.Cheque.ObtenerADPorCierre(pCodigo);
                                break;
                            case 5:
                                dt = DatosRioCuarto.Cheque.ObtenerADPorCierre(pCodigo);
                                break;
                            case 7:
                                dt = DatosSucursal6.Cheque.ObtenerADPorCierre(pCodigo);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerUno(int pCodigoCheque) {
            try
            {
                return Datos.Cheque.ObtenerUno(pCodigoCheque);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerEnProveedor(Entidades.Proveedor objProveedor)
        {
            try
            {
                return Datos.Cheque.ObtenerEnProveedor(objProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerTresMesesEnProveedor(Entidades.Proveedor objProveedor, Boolean ultimosTresMeses)
        {
            try
            {
                return Datos.Cheque.ObtenerTresMesesEnProveedor(objProveedor, ultimosTresMeses);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable ObtenerEnCartera(Entidades.Cliente objCliente)
        {
            try
            {
                return Datos.Cheque.ObtenerEnCartera(objCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerEnCarteraPorRemito(Entidades.Cliente objCliente, int pCodigoRecibo)
        {
            try
            {
                return Datos.Cheque.ObtenerEnCarteraPorRemito(objCliente, pCodigoRecibo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerEnProveedorPorRecibo(Entidades.Proveedor pProveedor, int pCodigoRecibo)
        {
            try
            {
                return Datos.Cheque.ObtenerEnProveedorPorRecibo(pProveedor, pCodigoRecibo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerChequesPorEstado(DateTime pDesde, DateTime pHasta, char pRango, string pTipoEstadoValor)
        {
            try
            {
                return Datos.Cheque.ObtenerChequesPorEstado(pDesde, pHasta, pRango, pTipoEstadoValor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerParaConciliacion(Entidades.CuentaBancaria objCuentaBancaria)
        {
            try
            {
                return Datos.Cheque.ObtenerParaConciliacion(objCuentaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public int ObtenerSiEstaConciliado(Entidades.Cheque objCheque)
        {
            try
            {
                return Datos.Cheque.ObtenerSiEstaConciliado(objCheque);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable ObtenerDeClientes(Entidades.Cliente objCliente)
        {
            try
            {
                return Datos.Cheque.ObtenerDeClientes(objCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerTodosLosMovimientos(int pCodigoCheque, int pSucursal)
        {
            try
            {
                if (pSucursal == 1)
                {
                    return DatosIntegracion.Cheques.ObtenerTodosLosMovimientos(pCodigoCheque);
                }
                else
                {
                    return Datos.Cheque.ObtenerTodosLosMovimientos(pCodigoCheque);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable ObtenerTodosLosCheques(int pCodigoBanco, string pNroCheque, bool pDuplicados)
        {
            try
            {
                    return Datos.Cheque.ObtenerTodosLosCheques(pCodigoBanco, pNroCheque, pDuplicados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
