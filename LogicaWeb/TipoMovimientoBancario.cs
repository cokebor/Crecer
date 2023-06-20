using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaWeb
{
    public class TipoMovimientoBancario
    {
        public void Agregar(Entidades.TipoMovimientoBancario pTipo, Entidades.Empresa pEmpresa)
        {
            try
            {
                DatosWeb.TipoMovimientoBancario.Agregar(pTipo, pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerNovedades(int pCodigoNovedad, Entidades.Empresa pEmpresa)
        {
            try
            {
                return DatosWeb.TipoMovimientoBancario.ObtenerNovedades(pCodigoNovedad, pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
