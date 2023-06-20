using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaWeb
{
    public class Proveedor
    {
        public void Agregar(Entidades.Proveedor pProveedor, Entidades.Empresa pEmpresa)
        {
            try
            {
                DatosWeb.Proveedor.Agregar(pProveedor, pEmpresa);
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
                return DatosWeb.Proveedor.ObtenerNovedades(pCodigoNovedad, pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
