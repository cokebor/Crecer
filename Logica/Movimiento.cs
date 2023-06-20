using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Movimiento
    {
        public DataTable ObtenerEfectivoSinCierre(Entidades.PuestoCaja pPuestoCaja, string pMoneda, string nombreTabla)
        {
            try
            {
                return Datos.Movimiento.ObtenerEfectivoSinCierre(pPuestoCaja, pMoneda, nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public double ObtenerMontoEfectivoSinCierre(Entidades.PuestoCaja pPuestoCaja, int pCodigoMoneda)
        {
            try
            {
                return Datos.Movimiento.ObtenerMontoEfectivoSinCierre(pPuestoCaja, pCodigoMoneda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerChequesSinCierre(Entidades.PuestoCaja pPuestoCaja, string pMovimiento, string nombreTabla)
        {
            try
            {
                return Datos.Movimiento.ObtenerChequesSinCierre(pPuestoCaja, pMovimiento, nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ObtenerCantidadDeMovimientos() {
            try {
                return Datos.Movimiento.ObtenerCantidadDeMovimientos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTransferenciasSinCierre(Entidades.PuestoCaja pPuestoCaja, int pCodigoCierreCaja=0, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.CierreCaja.ObtenerCheques(pCodigo, pMovimiento, nombreTabla);
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Movimiento.ObtenerTransferenciasSinCierre(pPuestoCaja, pCodigoCierreCaja);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Movimiento.ObtenerTransferenciasSinCierre(pPuestoCaja, pCodigoCierreCaja);
                            break;
                        case 2:
                            dt = DatosWiki.Movimiento.ObtenerTransferenciasSinCierre(pPuestoCaja, pCodigoCierreCaja);
                            break;
                        case 3:
                            dt = DatosNave7.Movimiento.ObtenerTransferenciasSinCierre(pPuestoCaja, pCodigoCierreCaja);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Movimiento.ObtenerTransferenciasSinCierre(pPuestoCaja, pCodigoCierreCaja);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Movimiento.ObtenerTransferenciasSinCierre(pPuestoCaja, pCodigoCierreCaja);
                            break;
                        case 7:
                            dt = DatosSucursal6.Movimiento.ObtenerTransferenciasSinCierre(pPuestoCaja, pCodigoCierreCaja);
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
