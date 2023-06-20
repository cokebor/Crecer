using System;
using System.Data;

namespace LogicaWeb
{
    public class Banco
    {

        public void Agregar(Entidades.Banco pBanco, Entidades.Empresa pEmpresa)
        {
            try
            {
                DatosWeb.Banco.Agregar(pBanco, pEmpresa);
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
                return DatosWeb.Banco.ObtenerNovedades(pCodigoNovedad, pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}