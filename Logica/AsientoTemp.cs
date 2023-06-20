using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class AsientoTemp
    {
        public DataTable Agrupacion()
        {
            try
            {
                return Datos.AsientoTemp.Agrupacion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
