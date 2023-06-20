using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaWeb
{
    public class Localidad
    {
        public void Agregar(Entidades.Localidad pLocalidad, Entidades.Empresa pEmpresa)
        {
            try
            {
                DatosWeb.Localidad.Agregar(pLocalidad, pEmpresa);
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
                return DatosWeb.Localidad.ObtenerNovedades(pCodigoNovedad, pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
