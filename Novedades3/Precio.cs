using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Novedades
{
    public class Precio
    {
        Logica.Producto objLProducto = new Logica.Producto();

        Entidades.PreciosLote objEPrecio = new PreciosLote();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.PrecioLote objLWPrecioLote = new LogicaWeb.PrecioLote();

        Logica.Novedad objLNovedad = new Logica.Novedad();

        /* Entidades.Pais objEPais = new Entidades.Pais();
         


         Logica.Pais objLPais = new Logica.Pais();
         */

        public void Enviar()
        {
            try
            {
                DataTable dtPrecios = objLProducto.ObtenerPreciosNovedades();
                foreach (DataRow dr in dtPrecios.Rows)
                {
                    objEPrecio.Codigo= Convert.ToInt32(dr["Codigo"]);
                    objEPrecio.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    objEPrecio.Lote = Convert.ToInt32(dr["Lote"]);
                    objEPrecio.PrecioUnitario = Convert.ToDouble(dr["PrecioUnitario"]);
                    objLWPrecioLote.Agregar(objEPrecio, SingletonNovedad.Instancia.Empresa);
                    objLProducto.CambiarEstadoNovedad(objEPrecio);
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
                objENovedad = objLNovedad.ObtenerUno("Precios");

                DataTable dtPrecios = objLWPrecioLote.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtPrecios.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEPrecio.Codigo= Convert.ToInt32(dr["Codigo"]);
                    objEPrecio.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    objEPrecio.Lote = Convert.ToInt32(dr["Lote"]);
                    objEPrecio.PrecioUnitario = Convert.ToDouble(dr["PrecioUnitario"]);
                    objLProducto.AgregarDeWeb(objEPrecio);
                    
                    objLNovedad.Actualizar(objENovedad);

                }
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
