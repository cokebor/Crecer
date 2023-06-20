using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaWeb
{
    public class Pais
    {
        public void Agregar(Entidades.Pais pPais, Entidades.Empresa pEmpresa)
        {
            try
            {
                DatosWeb.Pais.Agregar(pPais, pEmpresa);
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
                return DatosWeb.Pais.ObtenerNovedades(pCodigoNovedad, pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*
        public void Update(Entidades.Empresa pEmpresa) {
            try
            {
                DatosWeb.Pais.Update(pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */

    }
}
