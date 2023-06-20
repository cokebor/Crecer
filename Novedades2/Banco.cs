using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades2
{
    public class Banco
    {
        Entidades.Banco objEBanco = new Entidades.Banco();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Banco objLWBanco = new LogicaWeb.Banco();
        Logica.Banco objLBanco = new Logica.Banco();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtBancos = objLBanco.ObtenerNovedades();
                foreach (DataRow dr in dtBancos.Rows)
                {
                    objEBanco.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEBanco.Descripcion = dr["Descripcion"].ToString();
                    objEBanco.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWBanco.Agregar(objEBanco, SingletonNovedad.Instancia.Empresa);
                    objLBanco.CambiarEstadoNovedad(objEBanco);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Recibir()
        {
            try
            {
                objENovedad = objLNovedad.ObtenerUno("Bancos");

                DataTable dtBancos = objLWBanco.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtBancos.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEBanco.Codigo = Convert.ToInt32(dr["CodigoBanco"]);
                    objEBanco.Descripcion = dr["Descripcion"].ToString();
                    objEBanco.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLBanco.AgregarDeWeb(objEBanco);
                    objLNovedad.Actualizar(objENovedad);
                    // objLPais.CambiarEstadoNovedad(objEPais);
                }
                //objLWPais.Update(Singleton.Instancia.Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
