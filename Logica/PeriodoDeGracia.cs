using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PeriodoDeGracia
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.PeriodoDeGracia.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
    }
}
