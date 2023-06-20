using System;
using System.Data;

namespace LogicaWeb
{
    public class SucursalCliente
    {

        public void Agregar(Entidades.SucursalCliente pSucursalC, Entidades.Empresa pEmpresa)
        {
            try
            {
                DatosWeb.SucursalCliente.Agregar(pSucursalC, pEmpresa);
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
                return DatosWeb.SucursalCliente.ObtenerNovedades(pCodigoNovedad, pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}