using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CambiosCheques
    {
        public void Agregar(Entidades.CambiosCheques pCambiosCheques,string pCodigoTipoEstadoValor, Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {
                Datos.CambiosCheques.Agregar(pCambiosCheques,pCodigoTipoEstadoValor, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
