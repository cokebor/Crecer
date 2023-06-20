using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class TipoMovimientoBancario
    {
        Entidades.TipoMovimientoBancario objETipoMovimientoBancario = new Entidades.TipoMovimientoBancario();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.TipoMovimientoBancario objLWTipoMovimientoBancario = new LogicaWeb.TipoMovimientoBancario();
        Logica.TipoMovimientoBancario objLTipoMovimientoBancario = new Logica.TipoMovimientoBancario();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtTipoMovimiento = objLTipoMovimientoBancario.ObtenerNovedades();
                foreach (DataRow dr in dtTipoMovimiento.Rows)
                {
                    objETipoMovimientoBancario.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objETipoMovimientoBancario.Descripcion = dr["Descripcion"].ToString();
                    objETipoMovimientoBancario.AfectaCuenta = Convert.ToChar(dr["AfectaCuenta"].ToString());
                    objETipoMovimientoBancario.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWTipoMovimientoBancario.Agregar(objETipoMovimientoBancario, SingletonNovedad.Instancia.Empresa);
                    objLTipoMovimientoBancario.CambiarEstadoNovedad(objETipoMovimientoBancario);
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
                objENovedad = objLNovedad.ObtenerUno("TiposMovimientosBancarios");

                DataTable dtMovimientos = objLWTipoMovimientoBancario.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtMovimientos.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objETipoMovimientoBancario.Codigo = Convert.ToInt32(dr["CodigoTipoMovimientoBancario"]);
                    objETipoMovimientoBancario.Descripcion = dr["Descripcion"].ToString();
                    objETipoMovimientoBancario.AfectaCuenta = Convert.ToChar(dr["AfectaCuenta"]);
                    objETipoMovimientoBancario.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLTipoMovimientoBancario.AgregarDeWeb(objETipoMovimientoBancario);
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
