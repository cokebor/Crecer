using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class ObraSocial
    {
        Entidades.ObraSocial objEObraSocial = new Entidades.ObraSocial();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.ObraSocial objLWObraSocial = new LogicaWeb.ObraSocial();
        Logica.ObraSocial objLObraSocial = new Logica.ObraSocial();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtObras = objLObraSocial.ObtenerNovedades();
                foreach (DataRow dr in dtObras.Rows)
                {
                    objEObraSocial.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEObraSocial.Nombre = dr["Descripcion"].ToString();
                    objEObraSocial.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWObraSocial.Agregar(objEObraSocial, SingletonNovedad.Instancia.Empresa);
                    objLObraSocial.CambiarEstadoNovedad(objEObraSocial);
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
                objENovedad = objLNovedad.ObtenerUno("Obras Sociales");

                DataTable dtObrasSociales = objLWObraSocial.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtObrasSociales.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEObraSocial.Codigo = Convert.ToInt32(dr["CodigoObraSocial"]);
                    objEObraSocial.Nombre = dr["Descripcion"].ToString();
                    objEObraSocial.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLObraSocial.AgregarDeWeb(objEObraSocial);
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
