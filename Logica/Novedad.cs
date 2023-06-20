using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Novedad
    {
        public Entidades.Novedad ObtenerUno(string pTabla)
        {
            try
            {
                return Datos.Novedad.ObtenerUno(pTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Actualizar(Entidades.Novedad pNovedad) {
            try
            {
                Datos.Novedad.Actualizar(pNovedad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
