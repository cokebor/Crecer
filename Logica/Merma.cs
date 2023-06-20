using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Merma
    {
        public int Agregar(Entidades.Merma pMerma)
        {
            try
            {
                return Datos.Merma.Agregar(pMerma);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ObtenerCantidad(Entidades.Lote pLote, DateTime pDesde, DateTime pHasta,Entidades.Sucursal pSucursal = null)
        {
            try
            {
                int res = 0;
                if (pSucursal == null)
                    res = Datos.Merma.ObtenerCantidad(pLote, pDesde, pHasta);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            res = Datos.Merma.ObtenerCantidad(pLote, pDesde, pHasta);
                            break;
                        case 2:
                            res = DatosWiki.Merma.ObtenerCantidad(pLote, pDesde, pHasta);
                            break;
                        case 3:
                            res = DatosNave7.Merma.ObtenerCantidad(pLote, pDesde, pHasta);
                            break;
                        case 4:
                            res = DatosVillaMaria.Merma.ObtenerCantidad(pLote, pDesde, pHasta);
                            break;
                        case 5:
                            res = DatosRioCuarto.Merma.ObtenerCantidad(pLote, pDesde, pHasta);
                            break;
                        case 7:
                            res = DatosSucursal6.Merma.ObtenerCantidad(pLote, pDesde, pHasta);
                            break;
                        case 0:
                            res = DatosIntegracion.Merma.ObtenerCantidad(pLote, pDesde, pHasta);
                            break;
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerPorLote(DateTime pDesde, DateTime pHasta, Entidades.Lote pLote, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Merma.ObtenerPorLote(pDesde, pHasta, pLote, pRubro, pProducto);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Merma.ObtenerPorLote(pDesde, pHasta, pLote, pRubro, pProducto);
                            break;
                        case 2:
                            dt = DatosWiki.Merma.ObtenerPorLote(pDesde, pHasta, pLote, pRubro, pProducto);
                            break;
                        case 3:
                            dt = DatosNave7.Merma.ObtenerPorLote(pDesde, pHasta, pLote, pRubro, pProducto);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Merma.ObtenerPorLote(pDesde, pHasta, pLote, pRubro, pProducto);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Merma.ObtenerPorLote(pDesde, pHasta, pLote, pRubro, pProducto);
                            break;
                        case 7:
                            dt = DatosSucursal6.Merma.ObtenerPorLote(pDesde, pHasta, pLote, pRubro, pProducto);
                            break;
                        case 0:
                            dt = DatosIntegracion.Merma.ObtenerPorLote(pDesde, pHasta, pLote, pRubro, pProducto);
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

        public int ObtenerMermasALiquidar(int pCodigo, int pCodigoProducto, int pLote,DateTime pHasta, Entidades.Empresa pEmpresa)
        {
            try
            {
                if (pEmpresa.Codigo == 1)
                {
                    return DatosIntegracion.Merma.ObtenerMermasALiquidar(pCodigo, pCodigoProducto, pLote, pHasta);
                }
                else
                {
                    return Datos.Merma.ObtenerMermasALiquidar(pCodigo, pCodigoProducto, pLote, pHasta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
