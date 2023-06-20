using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class Puesto
    {
        Entidades.Puesto objEPuesto = new Entidades.Puesto();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Puesto objLWPuesto = new LogicaWeb.Puesto();
        Logica.Puesto objLPuesto = new Logica.Puesto();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtObras = objLPuesto.ObtenerNovedades();
                foreach (DataRow dr in dtObras.Rows)
                {
                    objEPuesto.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEPuesto.Descripcion = dr["Descripcion"].ToString();
                    objEPuesto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWPuesto.Agregar(objEPuesto, SingletonNovedad.Instancia.Empresa);
                    objLPuesto.CambiarEstadoNovedad(objEPuesto);
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
                objENovedad = objLNovedad.ObtenerUno("Puestos");

                DataTable dtObrasSociales = objLWPuesto.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtObrasSociales.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEPuesto.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEPuesto.Descripcion = dr["Descripcion"].ToString();
                    objEPuesto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLPuesto.AgregarDeWeb(objEPuesto);
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
