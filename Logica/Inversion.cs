using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Inversion
    {
        public int Agregar(Entidades.Inversion pInversion, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.Inversion.Agregar(pInversion, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Agregar(Entidades.FondoComunInversion pFondoComun, Entidades.Asiento pAsiento)
        {
            try
            {
                return Datos.Inversion.Agregar(pFondoComun, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Eliminar(int pCodigoFondoComun, char pCodigoTipoOperacion)
        {
            try
            {
                return Datos.Inversion.Eliminar(pCodigoFondoComun, pCodigoTipoOperacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerFondosComunes(DateTime pDesde, DateTime pHasta,Entidades.CuentaBancaria pCuentaBancaria,char pTipoOperacion,int pCodigoFondo,bool pPendientes)
        {
            try
            {
                return Datos.Inversion.ObtenerFondosComunes(pDesde, pHasta, pCuentaBancaria, pTipoOperacion, pCodigoFondo, pPendientes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerCodigos(int pCodigoTipoInversion, Entidades.CuentaBancaria pCuentaBancaria)
        {
            try
            {
                return Datos.Inversion.ObtenerCodigos(pCodigoTipoInversion, pCuentaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Inversion ObtenerUna(int pCodigoInversion)
        {
            try
            {
                return Datos.Inversion.ObtenerUna(pCodigoInversion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public  List<Entidades.FondoComunInversion> ObtenerFondosComunesConCuotapartes(int pCodigoFondo, int pCodigoCuentaBancaria)
        {
            try
            {
                return Datos.Inversion.ObtenerFondosComunesConCuotapartes(pCodigoFondo, pCodigoCuentaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
