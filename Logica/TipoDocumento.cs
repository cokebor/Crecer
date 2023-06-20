using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoDocumento
    {
        public DataTable Obtener(int pCodigoTipoInscripcion)
        {
            try
            {
                return Datos.TipoDocumento.Obtener(pCodigoTipoInscripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
