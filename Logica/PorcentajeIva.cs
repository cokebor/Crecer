using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PorcentajeIva
    {
        public DataTable ObtenerTodos() {
            try
            {
                return Datos.PorcentajeIva.ObtenerTodos();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}
