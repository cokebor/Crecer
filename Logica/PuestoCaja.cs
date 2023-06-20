using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PuestoCaja
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.PuestoCaja.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.PuestoCaja ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.PuestoCaja.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
