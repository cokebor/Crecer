using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CategoriaProveedor
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.CategroriaProveedor.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.CategoriaProveedor ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.CategroriaProveedor.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
