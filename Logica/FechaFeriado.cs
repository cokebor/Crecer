using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FechaFeriado
    {
        public bool VerSiExiste(DateTime pFecha, int pCodigoSucursal)
        {
            try
            {
                return Datos.FechaFeriado.VerSiExiste(pFecha, pCodigoSucursal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Agregar(Entidades.FechaFeriado objEFechaFeriado)
        {
            try
            {
                Datos.FechaFeriado.Agregar(objEFechaFeriado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
