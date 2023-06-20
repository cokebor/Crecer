using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Novedades
{
    public class Moneda
    {
        Entidades.Moneda objEMoneda = new Entidades.Moneda();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Moneda objLWMoneda = new LogicaWeb.Moneda();
        Logica.Moneda objLMoneda = new Logica.Moneda();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtMonedas = objLMoneda.ObtenerNovedades();
                foreach (DataRow dr in dtMonedas.Rows)
                {
                    objEMoneda.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEMoneda.Descripcion = dr["Descripcion"].ToString();
                    objEMoneda.FechaCotizacion = Convert.ToDateTime(dr["FechaCotizacion"]);
                    objEMoneda.Cotizacion = Convert.ToDouble(dr["Cotizacion"]);
                    objEMoneda.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWMoneda.Agregar(objEMoneda, SingletonNovedad.Instancia.Empresa);
                    objLMoneda.CambiarEstadoNovedad(objEMoneda);
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
                objENovedad = objLNovedad.ObtenerUno("Monedas");

                DataTable dtMonedas = objLWMoneda.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtMonedas.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEMoneda.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEMoneda.Descripcion = dr["Descripcion"].ToString();
                    objEMoneda.FechaCotizacion = Convert.ToDateTime(dr["FechaCotizacion"]);
                    objEMoneda.Cotizacion = Convert.ToDouble(dr["Cotizacion"]);
                    objEMoneda.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);
                    
                    objLMoneda.AgregarDeWeb(objEMoneda);
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
