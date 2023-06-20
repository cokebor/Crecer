using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades2
{
    public class Producto
    {
        Entidades.Producto objEProducto = new Entidades.Producto();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Producto objLWProducto = new LogicaWeb.Producto();
        Logica.Producto objLProducto = new Logica.Producto();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtProductos = objLProducto.ObtenerNovedades();
                foreach (DataRow dr in dtProductos.Rows)
                {
                    objEProducto.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEProducto.Descripcion = dr["Descripcion"].ToString();
                    objEProducto.RubroProducto.Codigo=Convert.ToInt32(dr["CodigoRubro"]);
                    objEProducto.UnidadDeMedida = dr["UnidadMedida"].ToString();
                    objEProducto.Peso = Convert.ToDouble(dr["Peso"]);
                    objEProducto.StockMinimo= Convert.ToInt32(dr["StockMinimo"]);
                    objEProducto.CodigoBarra = dr["CodigoBarra"].ToString();
                    objEProducto.PorcentajeIVA= Convert.ToDouble(dr["PorcentajeIVA"]);
                    objEProducto.FacturacionPorCubeta = Convert.ToBoolean(dr["FacturacionPorCubeta"]);
                    objEProducto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWProducto.Agregar(objEProducto, SingletonNovedad.Instancia.Empresa);
                    objLProducto.CambiarEstadoNovedad(objEProducto);
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
                objENovedad = objLNovedad.ObtenerUno("Productos");

                DataTable dtProductos = objLWProducto.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtProductos.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEProducto.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEProducto.Descripcion = dr["Descripcion"].ToString();
                    objEProducto.RubroProducto.Codigo = Convert.ToInt32(dr["CodigoRubro"]);
                    objEProducto.UnidadDeMedida = dr["UnidadMedida"].ToString();
                    objEProducto.Peso = Convert.ToDouble(dr["Peso"]);
                    objEProducto.StockMinimo = Convert.ToInt32(dr["StockMinimo"]);
                    objEProducto.CodigoBarra = dr["CodigoBarra"].ToString();
                    objEProducto.PorcentajeIVA = Convert.ToDouble(dr["PorcentajeIVA"]);
                    objEProducto.FacturacionPorCubeta = Convert.ToBoolean(dr["FacturacionPorCubeta"]);
                    objEProducto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLProducto.AgregarDeWeb(objEProducto);
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
