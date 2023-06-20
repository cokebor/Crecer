using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Venta
    {
        public DataTable ObtenerTodosPorLote(Entidades.Lote pLote, DateTime pDesde, DateTime pHasta, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Venta.ObtenerTodosPorLote(pLote, pDesde, pHasta);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Venta.ObtenerTodosPorLote(pLote, pDesde, pHasta);
                            break;
                        case 2:
                            dt = DatosWiki.Venta.ObtenerTodosPorLote(pLote, pDesde, pHasta);
                            break;
                        case 3:
                            dt = DatosNave7.Venta.ObtenerTodosPorLote(pLote, pDesde, pHasta);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Venta.ObtenerTodosPorLote(pLote, pDesde, pHasta);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Venta.ObtenerTodosPorLote(pLote, pDesde, pHasta);
                            break;
                        case 7:
                            dt = DatosSucursal6.Venta.ObtenerTodosPorLote(pLote, pDesde, pHasta);
                            break;
                        case 0:
                            dt = DatosIntegracion.Venta.ObtenerTodosPorLote(pLote, pDesde, pHasta);
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

        public int Agregar(Entidades.SaldoInicialVentas pVentas)
        {
            try
            {
                return Datos.Venta.Agregar(pVentas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
