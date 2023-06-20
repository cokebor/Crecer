using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class Cliente
    {
        Entidades.Cliente objECliente = new Entidades.Cliente();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Cliente objLWCliente = new LogicaWeb.Cliente();
        Logica.Cliente objLCliente = new Logica.Cliente();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtProveedores = objLCliente.ObtenerNovedades();
                foreach (DataRow dr in dtProveedores.Rows)
                {
                    objECliente.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objECliente.Nombre = dr["Nombre"].ToString();
                    objECliente.TipoDocumento.Codigo= Convert.ToInt32(dr["CodigoTipoDocumento"]);
                    objECliente.CUIT = dr["CUIT"].ToString();
                    objECliente.FechaValidacionCUIT = Convert.ToDateTime(dr["fechaValidacionCUIT"]);
                    objECliente.TipoInscripcion.Codigo = Convert.ToInt32(dr["CodigoTipoInscripcion"]);
                    /*objECliente.Domicilio.Direccion = dr["Direccion"].ToString();
                    objECliente.Domicilio.Numero = dr["Numero"].ToString();
                    objECliente.Domicilio.Barrio = dr["Barrio"].ToString();
                    objECliente.Domicilio.CodigoPostal = dr["CodigoPostal"].ToString();
                    objECliente.Domicilio.Localidad.Codigo = Convert.ToInt32(dr["CodigoLocalidad"]);*/
                    objECliente.FacturaKilos = Convert.ToBoolean(dr["FacturaPorKilos"]);
                    objECliente.Observaciones= dr["Observaciones"].ToString();
                    objECliente.Comision = Convert.ToDouble(dr["Comision"]);
                    objECliente.Original = Convert.ToBoolean(dr["Original"]);
                    objECliente.Duplicado = Convert.ToBoolean(dr["Duplicado"]);
                    objECliente.Triplicado = Convert.ToBoolean(dr["Triplicado"]);
                    objECliente.FacturacionPorCubeta = Convert.ToBoolean(dr["FacturacionPorCubeta"]);
                    objECliente.MiPYME= Convert.ToBoolean(dr["MiPYME"]);
                    objECliente.TipoContribuyente.Codigo= Convert.ToInt32(dr["CodigoTipoContribuyente"]);
                    objECliente.RiesgoFiscal= Convert.ToBoolean(dr["RiesgoFiscal"]);

                    objECliente.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWCliente.Agregar(objECliente, SingletonNovedad.Instancia.Empresa);
                    objLCliente.CambiarEstadoNovedad(objECliente);
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
                objENovedad = objLNovedad.ObtenerUno("Clientes");

                DataTable dtClientes = objLWCliente.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtClientes.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objECliente.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objECliente.TipoDocumento.Codigo = Convert.ToInt32(dr["CodigoTipoDocumento"]);
                    objECliente.Nombre = dr["Nombre"].ToString();
                    objECliente.CUIT = dr["CUIT"].ToString();
                    objECliente.FechaValidacionCUIT = Convert.ToDateTime(dr["fechaValidacionCUIT"]);
                    objECliente.TipoInscripcion.Codigo = Convert.ToInt32(dr["CodigoTipoInscripcion"]);
                   /* objECliente.Domicilio.Direccion = dr["Direccion"].ToString();
                    objECliente.Domicilio.Numero = dr["Numero"].ToString();
                    objECliente.Domicilio.Barrio = dr["Barrio"].ToString();
                    objECliente.Domicilio.CodigoPostal = dr["CodigoPostal"].ToString();
                    objECliente.Domicilio.Localidad.Codigo = Convert.ToInt32(dr["CodigoLocalidad"]);*/
                    objECliente.FacturaKilos = Convert.ToBoolean(dr["FacturaPorKilos"]);
                    objECliente.Observaciones = dr["Observaciones"].ToString();
                    objECliente.Comision = Convert.ToDouble(dr["Comision"]);
                    objECliente.Original = Convert.ToBoolean(dr["Original"]);
                    objECliente.Duplicado = Convert.ToBoolean(dr["Duplicado"]);
                    objECliente.Triplicado = Convert.ToBoolean(dr["Triplicado"]);
                    objECliente.FacturacionPorCubeta = Convert.ToBoolean(dr["FacturacionPorCubeta"]);
                    objECliente.MiPYME = Convert.ToBoolean(dr["MiPYME"]);
                    objECliente.TipoContribuyente.Codigo = Convert.ToInt32(dr["CodigoTipoContribuyente"]);
                    objECliente.RiesgoFiscal = Convert.ToBoolean(dr["RiesgoFiscal"]);
                    objECliente.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLCliente.AgregarDeWeb(objECliente);
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
