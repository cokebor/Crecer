using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class BancoRechazos
    {
        public int Agregar(Entidades.BancoRechazados pBancoRechazado, Entidades.Asiento pAsiento)//, List<Entidades.AsientoTemp> pAsiento)
        {
            try
            {
                return Datos.BancoRechazos.Agregar(pBancoRechazado, pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
