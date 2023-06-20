using System;
using System.Data;

namespace LogicaWeb
{
    public class ObraSocial
    {

        public void Agregar(Entidades.ObraSocial pObraSocial, Entidades.Empresa pEmpresa)
        {
            try
            {
                DatosWeb.ObraSocial.Agregar(pObraSocial, pEmpresa);
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
                return DatosWeb.ObraSocial.ObtenerNovedades(pCodigoNovedad, pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}