using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class ConciliacionesTransacciones
    {
      /*  public void Agregar(Entidades.FormaDePago pFormaDePago,Entidades.Sucursal pSucursal, Entidades.CuentaBancaria pCuentaBancaria, DateTime pFechaConciliacion,Entidades.Usuario pUsuario, List<Entidades.Transacciones> pTranferencias, List<Entidades.Transacciones> pDebitoCredito, double pGasto,double pIva, double pRetIIBB, double pRetIva)
        {
            try
            {
                Datos.ConciliacionesTransacciones.Agregar(pFormaDePago, pSucursal, pCuentaBancaria,pFechaConciliacion,pUsuario, pTranferencias, pDebitoCredito, pGasto, pIva,pRetIIBB, pRetIva);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

        public void Agregar(Entidades.FormaDePago pFormaDePago, Entidades.Sucursal pSucursal,Entidades.CuentaBancaria pCuentaBancaria, Conciliacion pConciliacion, Entidades.Usuario pUsuario, Entidades.Asiento pAsiento, Entidades.Proveedor pProveedor, Entidades.PuestoCaja pPuesto, DateTime pFechaConciliacion)
        {
            try
            {
                Datos.ConciliacionesTransacciones.Agregar(pFormaDePago, pSucursal,pCuentaBancaria,pConciliacion,pUsuario,pAsiento,pProveedor,pPuesto, pFechaConciliacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
