using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Adelanto
    {
        public int Agregar(Entidades.Adelanto pAdelanto, Entidades.Asiento pAsiento){
            try
            {
                return Datos.Adelanto.Agregar(pAdelanto,pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
