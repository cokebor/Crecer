using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class Localidad
    {
        Entidades.Localidad objELocalidad = new Entidades.Localidad();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Localidad objLWLocalidad = new LogicaWeb.Localidad();
        Logica.Localidad objLLocalidad = new Logica.Localidad();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtLocalidades = objLLocalidad.ObtenerNovedades();
                foreach (DataRow dr in dtLocalidades.Rows)
                {
                    objELocalidad.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objELocalidad.Nombre = dr["Nombre"].ToString();
                    objELocalidad.Provincia.Codigo = Convert.ToInt32(dr["CodigoProvincia"]);
                    objELocalidad.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWLocalidad.Agregar(objELocalidad, SingletonNovedad.Instancia.Empresa);
                    objLLocalidad.CambiarEstadoNovedad(objELocalidad);
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
                objENovedad = objLNovedad.ObtenerUno("Localidades");

                DataTable dtLocalidades = objLWLocalidad.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtLocalidades.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objELocalidad.Codigo = Convert.ToInt32(dr["CodigoLocalidad"]);
                    objELocalidad.Nombre = dr["Descripcion"].ToString();
                    objELocalidad.Provincia.Codigo = Convert.ToInt32(dr["CodigoProvincia"]);
                    objELocalidad.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLLocalidad.AgregarDeWeb(objELocalidad);
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
