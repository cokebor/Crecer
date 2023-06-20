using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FacturaDetalle
    {
        public DataTable ObtenerUno(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt= Datos.FacturaDetalle.ObtenerUno(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.FacturaDetalle.ObtenerUno(pCodigo);
                            break;
                        case 2:
                            dt = DatosWiki.FacturaDetalle.ObtenerUno(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.FacturaDetalle.ObtenerUno(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.FacturaDetalle.ObtenerUno(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.FacturaDetalle.ObtenerUno(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.FacturaDetalle.ObtenerUno(pCodigo);
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

        public List<Entidades.Factura_Detalle> ObtenerUnoParaNC(int pCodigo)
        {
            try
            {
                return Datos.FacturaDetalle.ObtenerUnoParaNC(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entidades.Factura_Detalle> ObtenerUnoParaAjuste(int pCodigo)
        {
            try
            {
                return Datos.FacturaDetalle.ObtenerUnoParaAjuste(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDetalleLiquidacion(int pCodigo, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.FacturaCompra_Detalle.ObtenerDetalleLiquidacion(pCodigo);
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.FacturaDetalle.ObtenerDetalleLiquidacion(pCodigo);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.FacturaDetalle.ObtenerDetalleLiquidacion(pCodigo);
                            break;
                        case 3:
                            dt = DatosNave7.FacturaDetalle.ObtenerDetalleLiquidacion(pCodigo);
                            break;
                        case 4:
                            dt = DatosVillaMaria.FacturaDetalle.ObtenerDetalleLiquidacion(pCodigo);
                            break;
                        case 5:
                            dt = DatosRioCuarto.FacturaDetalle.ObtenerDetalleLiquidacion(pCodigo);
                            break;
                        case 7:
                            dt = DatosSucursal6.FacturaDetalle.ObtenerDetalleLiquidacion(pCodigo);
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
