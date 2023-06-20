using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class CierreCaja
    {
        public int Agregar(Entidades.CierreDeCaja pCierreCaja)
        {
            try
            {
                return Datos.CierreCaja.Agregar(pCierreCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodos(DateTime pDesde, DateTime pHasta, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.CierreCaja.ObtenerTodos(pDesde, pHasta);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.CierreCaja.ObtenerTodos(pDesde, pHasta);
                            break;
                        case 2:
                            dt = DatosWiki.CierreCaja.ObtenerTodos(pDesde, pHasta);
                            break;
                        case 3:
                            dt = DatosNave7.CierreCaja.ObtenerTodos(pDesde, pHasta);
                            break;
                        case 4:
                            dt = DatosVillaMaria.CierreCaja.ObtenerTodos(pDesde, pHasta);
                            break;
                        case 5:
                            dt = DatosRioCuarto.CierreCaja.ObtenerTodos(pDesde, pHasta);
                            break;
                        case 7:
                            dt = DatosSucursal6.CierreCaja.ObtenerTodos(pDesde, pHasta);
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

        public DataTable ObtenerEfectivo(int pCodigo, string pMoneda, string nombreTabla, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                // return Datos.CierreCaja.ObtenerEfectivo(pCodigo, pMoneda, nombreTabla);
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.CierreCaja.ObtenerEfectivo(pCodigo, pMoneda, nombreTabla);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.CierreCaja.ObtenerEfectivo(pCodigo, pMoneda, nombreTabla);
                            break;
                        case 2:
                            dt = DatosWiki.CierreCaja.ObtenerEfectivo(pCodigo, pMoneda, nombreTabla);
                            break;
                        case 3:
                            dt = DatosNave7.CierreCaja.ObtenerEfectivo(pCodigo, pMoneda, nombreTabla);
                            break;
                        case 4:
                            dt = DatosVillaMaria.CierreCaja.ObtenerEfectivo(pCodigo, pMoneda, nombreTabla);
                            break;
                        case 5:
                            dt = DatosRioCuarto.CierreCaja.ObtenerEfectivo(pCodigo, pMoneda, nombreTabla);
                            break;
                        case 7:
                            dt = DatosSucursal6.CierreCaja.ObtenerEfectivo(pCodigo, pMoneda, nombreTabla);
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

        public DataTable ObtenerCheques(int pCodigo, string pMovimiento, string nombreTabla, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.CierreCaja.ObtenerCheques(pCodigo, pMovimiento, nombreTabla);
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.CierreCaja.ObtenerCheques(pCodigo, pMovimiento, nombreTabla);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.CierreCaja.ObtenerCheques(pCodigo, pMovimiento, nombreTabla);
                            break;
                        case 2:
                            dt = DatosWiki.CierreCaja.ObtenerCheques(pCodigo, pMovimiento, nombreTabla);
                            break;
                        case 3:
                            dt = DatosNave7.CierreCaja.ObtenerCheques(pCodigo, pMovimiento, nombreTabla);
                            break;
                        case 4:
                            dt = DatosVillaMaria.CierreCaja.ObtenerCheques(pCodigo, pMovimiento, nombreTabla);
                            break;
                        case 5:
                            dt = DatosRioCuarto.CierreCaja.ObtenerCheques(pCodigo, pMovimiento, nombreTabla);
                            break;
                        case 7:
                            dt = DatosSucursal6.CierreCaja.ObtenerCheques(pCodigo, pMovimiento, nombreTabla);
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

        public DataTable ObtenerTodos(Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.CierreCaja.ObtenerTodos();
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.CierreCaja.ObtenerTodos();
                            break;
                        case 2:
                            dt = DatosWiki.CierreCaja.ObtenerTodos();
                            break;
                        case 3:
                            dt = DatosNave7.CierreCaja.ObtenerTodos();
                            break;
                        case 4:
                            dt = DatosVillaMaria.CierreCaja.ObtenerTodos();
                            break;
                        case 5:
                            dt = DatosRioCuarto.CierreCaja.ObtenerTodos();
                            break;
                        case 7:
                            dt = DatosSucursal6.CierreCaja.ObtenerTodos();
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

        public DataTable ObtenerCierresPendientes(Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.CierreCaja.ObtenerCierresPendientes();
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.CierreCaja.ObtenerCierresPendientes();
                            break;
                        case 2:
                            dt = DatosWiki.CierreCaja.ObtenerCierresPendientes();
                            break;
                        case 3:
                            dt = DatosNave7.CierreCaja.ObtenerCierresPendientes();
                            break;
                        case 4:
                            dt = DatosVillaMaria.CierreCaja.ObtenerCierresPendientes();
                            break;
                        case 5:
                            dt = DatosRioCuarto.CierreCaja.ObtenerCierresPendientes();
                            break;
                        case 7:
                            dt = DatosSucursal6.CierreCaja.ObtenerCierresPendientes();
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

        public DataTable ObtenerCajasPasadas(Entidades.Sucursal pSucursal)
        {
            try
            {
                return Datos.CierreCaja.ObtenerCajasPasadas(pSucursal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DateTime ObtenerFecha(int pCodigoSucursal, int pCodigoCierreCaja)
        {
            try
            {
                DateTime dt = new DateTime();
                switch (pCodigoSucursal)
                {
                    case 1:
                        dt = Datos.CierreCaja.ObtenerFecha(pCodigoCierreCaja);
                        break;
                    case 2:
                        dt = DatosWiki.CierreCaja.ObtenerFecha(pCodigoCierreCaja);
                        break;
                    case 3:
                        dt = DatosNave7.CierreCaja.ObtenerFecha(pCodigoCierreCaja);
                        break;
                    case 4:
                        dt = DatosVillaMaria.CierreCaja.ObtenerFecha(pCodigoCierreCaja);
                        break;
                    case 5:
                        dt = DatosRioCuarto.CierreCaja.ObtenerFecha(pCodigoCierreCaja);
                        break;
                    case 7:
                        dt = DatosSucursal6.CierreCaja.ObtenerFecha(pCodigoCierreCaja);
                        break;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CierreDeCaja ObtenerUno(CierreDeCaja objECierre)
        {
            try
            {
                return Datos.CierreCaja.ObtenerUno(objECierre);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double ObtenerMontoEgreso(int pCodigoSucursal, int pCodigoCierreCaja)
        {
            try
            {
                double monto=0;
                switch (pCodigoSucursal)
                {
                    case 1:
                        monto = Datos.CierreCaja.ObtenerMontoEgreso(pCodigoCierreCaja);
                        break;
                    case 2:
                        monto = DatosWiki.CierreCaja.ObtenerMontoEgreso(pCodigoCierreCaja);
                        break;
                    case 3:
                        monto = DatosNave7.CierreCaja.ObtenerMontoEgreso(pCodigoCierreCaja);
                        break;
                    case 4:
                        monto = DatosVillaMaria.CierreCaja.ObtenerMontoEgreso(pCodigoCierreCaja);
                        break;
                    case 5:
                        monto = DatosRioCuarto.CierreCaja.ObtenerMontoEgreso(pCodigoCierreCaja);
                        break;
                    case 7:
                        monto = DatosSucursal6.CierreCaja.ObtenerMontoEgreso(pCodigoCierreCaja);
                        break;
                }
                return monto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ObtenerCantidadCajas()
        {
            try
            {
                return Datos.CierreCaja.ObtenerCantidadCajas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
