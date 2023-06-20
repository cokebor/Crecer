using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoContribuyente
    {
        public DataTable ObtenerTodosDeClientes()
        {
            try
            {
                return Datos.TipoContribuyente.ObtenerTodosDeClientes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosDeProveedores()
        {
            try
            {
                return Datos.TipoContribuyente.ObtenerTodosDeProveedores();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.TipoContribuyente ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.TipoContribuyente.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
