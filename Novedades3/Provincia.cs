using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class Provincia
    {
        Entidades.Provincia objEProvincia = new Entidades.Provincia();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Provincia objLWProvincia = new LogicaWeb.Provincia();
        Logica.Provincia objLProvincia = new Logica.Provincia();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtProvincias = objLProvincia.ObtenerNovedades();
                foreach (DataRow dr in dtProvincias.Rows)
                {
                    objEProvincia.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEProvincia.Nombre = dr["Nombre"].ToString();
                    objEProvincia.Pais.Codigo = Convert.ToInt32(dr["CodigoPais"]);
                    objEProvincia.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWProvincia.Agregar(objEProvincia, SingletonNovedad.Instancia.Empresa);
                    objLProvincia.CambiarEstadoNovedad(objEProvincia);
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
                objENovedad = objLNovedad.ObtenerUno("Provincias");

                DataTable dtProvincias = objLWProvincia.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtProvincias.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEProvincia.Codigo = Convert.ToInt32(dr["CodigoProvincia"]);
                    objEProvincia.Nombre = dr["Descripcion"].ToString();
                    objEProvincia.Pais.Codigo = Convert.ToInt32(dr["CodigoPais"]);
                    objEProvincia.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLProvincia.AgregarDeWeb(objEProvincia);
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
