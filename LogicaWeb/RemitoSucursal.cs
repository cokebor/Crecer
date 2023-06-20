using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaWeb
{
    public class RemitoSucursal
    {
        public void Agregar(Entidades.RemitoSucursal_M pRemito)
        {
            try
            {
                DatosWeb.RemitoSucursal.Agregar(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.RemitoSucursal_M ObtenerNovedades(Entidades.Empresa pEmpresa)
        {
            try
            {
                return DatosWeb.RemitoSucursal.ObtenerNovedades(pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
        public List<Entidades.RemitoSucursal_D_Producto> ObtenerNovedades(int pCodigo)
        {
            try
            {
                return DatosWeb.RemitoSucursal.ObtenerNovedades(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PasarABajado(string numRemito)
        {
            try
            {
                DatosWeb.RemitoSucursal.PasarABajado(numRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
