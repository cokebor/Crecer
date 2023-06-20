using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoRemitoCliente
    {
        public DataTable ObtenerSalientes()
        {
            try
            {
                return Datos.TipoRemitoCliente.ObtenerSalientes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.TipoRemitoCliente ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.TipoRemitoCliente.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}