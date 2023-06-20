using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class Comunicacion
    {
        Entidades.Comunicacion objEComunicacion = new Entidades.Comunicacion();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Comunicacion objLWComunicacion = new LogicaWeb.Comunicacion();
        Logica.Comunicacion objLComunicacion = new Logica.Comunicacion();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtComunicaciones = objLComunicacion.ObtenerNovedades();
                foreach (DataRow dr in dtComunicaciones.Rows)
                {
                    objEComunicacion.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEComunicacion.Descripcion = dr["Descripcion"].ToString();
                    objEComunicacion.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWComunicacion.Agregar(objEComunicacion, SingletonNovedad.Instancia.Empresa);
                    objLComunicacion.CambiarEstadoNovedad(objEComunicacion);
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
                objENovedad = objLNovedad.ObtenerUno("Comunicaciones");

                DataTable dtComunicaciones = objLWComunicacion.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtComunicaciones.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEComunicacion.Codigo = Convert.ToInt32(dr["CodigoComunicacion"]);
                    objEComunicacion.Descripcion = dr["Descripcion"].ToString();
                    objEComunicacion.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLComunicacion.AgregarDeWeb(objEComunicacion);
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
