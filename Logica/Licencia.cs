using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Licencia
    {
        public List<Entidades.Licencia> ObtenerporEmpleado(Entidades.Empleado pEmpleado)
        {
            try
            {
                return Datos.Licencia.ObtenerporEmpleado(pEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
