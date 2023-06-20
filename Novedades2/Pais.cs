using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Novedades2
{
    public class Pais
    {
        Entidades.Pais objEPais = new Entidades.Pais();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Pais objLWPais = new LogicaWeb.Pais();
        Logica.Pais objLPais = new Logica.Pais();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtPaises = objLPais.ObtenerNovedades();
                foreach (DataRow dr in dtPaises.Rows)
                {
                    objEPais.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEPais.Descripcion = dr["Descripcion"].ToString();
                    objEPais.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWPais.Agregar(objEPais, SingletonNovedad.Instancia.Empresa);
                    objLPais.CambiarEstadoNovedad(objEPais);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Recibir()
        {
            try
            {
                objENovedad = objLNovedad.ObtenerUno("Paises");

                DataTable dtPaises = objLWPais.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                string datos = "";
                foreach (DataRow dr in dtPaises.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEPais.Codigo = Convert.ToInt32(dr["CodigoPais"]);
                    objEPais.Descripcion = dr["Descripcion"].ToString();
                    objEPais.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLPais.AgregarDeWeb(objEPais);
                    objLNovedad.Actualizar(objENovedad);
                    datos = objEPais.ToString();
                    // objLPais.CambiarEstadoNovedad(objEPais);
                }
                return datos;
                //objLWPais.Update(Singleton.Instancia.Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
