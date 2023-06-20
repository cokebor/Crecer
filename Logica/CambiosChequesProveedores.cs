using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CambiosChequesProveedores
    {
        public void Agregar(Entidades.CambiosChequesProveedores pCambiosChequesP, Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {
                Datos.CambiosChequesProveedores.Agregar(pCambiosChequesP, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
