using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FrecuenciaDePago
    {
        public DataTable ObtenerTodos() {
            try
            {
                return Datos.FrecuenciaDePago.ObtenerTodos();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.FrecuenciaDePago ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.FrecuenciaDePago.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
