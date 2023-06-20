using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class MovimientoBancario
    {
        public void Agregar(Entidades.MovimientoBancario pMovimiento,Entidades.Caja pCaja=null ,Entidades.Asiento pAsiento=null)
        {
            try
            {
                if (pMovimiento.TipoMovimientoBancario.Codigo == 2)

                    Datos.MovimientoBancario.Agregar(pMovimiento);
                else
                {
                    
                   /* int cod=Datos.MovimientoBancario.Agregar(pMovimiento, pAsiento);
                    if(pCaja!=null)*/
                        Datos.Caja.Agregar(pCaja,pMovimiento, pAsiento);
                }
                }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Actualizar(List<Entidades.MovimientoBancario> pMovimientos, Entidades.Asiento pAsiento, Entidades.Usuario pUsuario, Entidades.CuentaBancaria pCuentaBancaria)
        {
            try
            {
                Datos.MovimientoBancario.Actualizar(pMovimientos, pAsiento, pUsuario, pCuentaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
