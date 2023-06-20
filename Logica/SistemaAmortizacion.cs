using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class SistemaAmortizacion
    {
        public DataTable ObtenerTodos() {
            try
            {
                return Datos.SistemaAmortizacion.ObtenerTodos();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}
