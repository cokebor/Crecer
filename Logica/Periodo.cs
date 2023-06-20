using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Periodo
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Periodo.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodos(int pCodigoConcepto, int pCodigoTipoSalario, int pCodigoSecuencia)
        {
            try
            {
                return Datos.Periodo.ObtenerTodos(pCodigoConcepto, pCodigoTipoSalario, pCodigoSecuencia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodos(int pCodigoConcepto)
        {
            try
            {
                return Datos.Periodo.ObtenerTodos(pCodigoConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerDevengamientosAAnular(int pCodigoConcepto)
        {
            try
            {
                return Datos.Periodo.ObtenerDevengamientosAAnular(pCodigoConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodos(int pCodigoConcepto, DateTime pDesde, DateTime pHasta)
        {
            try
            {
                return Datos.Periodo.ObtenerTodos(pCodigoConcepto, pDesde, pHasta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
