using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class RubroProducto
    {
        Entidades.RubroProducto objERubroProducto = new Entidades.RubroProducto();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.RubroProducto objLWRubroProducto = new LogicaWeb.RubroProducto();
        Logica.RubroProducto objLRubroProducto = new Logica.RubroProducto();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtRubros = objLRubroProducto.ObtenerNovedades();
                foreach (DataRow dr in dtRubros.Rows)
                {
                    objERubroProducto.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objERubroProducto.Descripcion = dr["Descripcion"].ToString();
                    objERubroProducto.IncluirEnInforme= Convert.ToBoolean(dr["IncluirEnInforme"]);
                    objERubroProducto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWRubroProducto.Agregar(objERubroProducto, SingletonNovedad.Instancia.Empresa);
                    objLRubroProducto.CambiarEstadoNovedad(objERubroProducto);
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
                objENovedad = objLNovedad.ObtenerUno("Rubros de Productos");

                DataTable dtRubros = objLWRubroProducto.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtRubros.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objERubroProducto.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objERubroProducto.Descripcion = dr["Descripcion"].ToString();
                    objERubroProducto.IncluirEnInforme = Convert.ToBoolean(dr["IncluirEnInforme"]);
                    objERubroProducto.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLRubroProducto.AgregarDeWeb(objERubroProducto);
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
