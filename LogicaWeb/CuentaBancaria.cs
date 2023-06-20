using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaWeb
{
    public class CuentaBancaria
    {
        
        public void Agregar(Entidades.CuentaBancaria pCuentaBancaria, Entidades.Empresa pEmpresa)
        {
            try
            {
                DatosWeb.CuentaBancaria.Agregar(pCuentaBancaria, pEmpresa);
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
                return DatosWeb.CuentaBancaria.ObtenerNovedades(pCodigoNovedad, pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
