using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoSalario
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.TipoSalario.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerAlgunos(int pCodigoConcepto, string pPeriodo)
        {
            try
            {
                return Datos.TipoSalario.ObtenerAlgunos(pCodigoConcepto,pPeriodo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerParaBorrar(int pCodigoConcepto, string pPeriodo)
        {
            try
            {
                return Datos.TipoSalario.ObtenerParaBorrar(pCodigoConcepto, pPeriodo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerAlgunos()
        {
            try
            {
                return Datos.TipoSalario.ObtenerAlgunos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
