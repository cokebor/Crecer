using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CajaInicial
    {
        public int Agregar(Entidades.CajaInicial pCaja)
        {
            try
            {
                return Datos.CajaInicial.Agregar(pCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

  
    }
}
