using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class Proveedor
    {
        Entidades.Proveedor objEProveedor = new Entidades.Proveedor();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Proveedor objLWProveedor = new LogicaWeb.Proveedor();
        Logica.Proveedor objLProveedor = new Logica.Proveedor();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtProveedores = objLProveedor.ObtenerNovedades();
                foreach (DataRow dr in dtProveedores.Rows)
                {
                    objEProveedor.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEProveedor.Nombre = dr["Nombre"].ToString();
                    objEProveedor.TipoInscripcion.Codigo = Convert.ToInt32(dr["CodigoTipoInscripcion"]);
                    objEProveedor.CUIT= dr["CUIT"].ToString();
                    objEProveedor.TipoContribuyente.Codigo = Convert.ToInt32(dr["CodigoAlicuotaMunicipal"]);
                    objEProveedor.RiesgoFiscal = Convert.ToBoolean(dr["RiesgoFiscal"]);

                    objEProveedor.IngresosBrutos= dr["IngresosBrutos"].ToString();
                    objEProveedor.Domicilio.Direccion = dr["Direccion"].ToString();
                    objEProveedor.Domicilio.Numero = dr["Numero"].ToString();
                    objEProveedor.Domicilio.Barrio = dr["Barrio"].ToString();
                    objEProveedor.Domicilio.CodigoPostal = dr["CodigoPostal"].ToString();
                    objEProveedor.Domicilio.Localidad.Codigo = Convert.ToInt32(dr["CodigoLocalidad"]);
                    objEProveedor.CategoriaProveedor.Codigo = Convert.ToInt32(dr["CodigoCategoriaProveedor"]);
                    objEProveedor.Observaciones= dr["Observaciones"].ToString();
                    objEProveedor.Comision = Convert.ToDouble(dr["Comision"]);
                    objEProveedor.FormaPago = Convert.ToBoolean(dr["FormaPago"]);
                    objEProveedor.InscriptoGanancias = Convert.ToBoolean(dr["InscriptoGanancias"]);

                    objEProveedor.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWProveedor.Agregar(objEProveedor, SingletonNovedad.Instancia.Empresa);
                    objLProveedor.CambiarEstadoNovedad(objEProveedor);
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
                objENovedad = objLNovedad.ObtenerUno("Proveedores");

                DataTable dtProveedores = objLWProveedor.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtProveedores.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEProveedor.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEProveedor.Nombre = dr["Nombre"].ToString();
                    objEProveedor.TipoInscripcion.Codigo = Convert.ToInt32(dr["CodigoTipoInscripcion"]);
                    objEProveedor.CUIT = dr["CUIT"].ToString();
                    objEProveedor.TipoContribuyente.Codigo = Convert.ToInt32(dr["CodigoAlicuotaMunicipal"]);
                    objEProveedor.RiesgoFiscal = Convert.ToBoolean(dr["RiesgoFiscal"]);
                    objEProveedor.IngresosBrutos = dr["IngresosBrutos"].ToString();
                    objEProveedor.Domicilio.Direccion = dr["Direccion"].ToString();
                    objEProveedor.Domicilio.Numero = dr["Numero"].ToString();
                    objEProveedor.Domicilio.Barrio = dr["Barrio"].ToString();
                    objEProveedor.Domicilio.CodigoPostal = dr["CodigoPostal"].ToString();
                    objEProveedor.Domicilio.Localidad.Codigo = Convert.ToInt32(dr["CodigoLocalidad"]);
                    objEProveedor.CategoriaProveedor.Codigo = Convert.ToInt32(dr["CodigoCategoriaProveedor"]);
                    objEProveedor.Observaciones = dr["Observaciones"].ToString();
                    objEProveedor.Comision = Convert.ToDouble(dr["Comision"]);
                    objEProveedor.FormaPago = Convert.ToBoolean(dr["FormaPago"]);
                    objEProveedor.InscriptoGanancias = Convert.ToBoolean(dr["InscriptoGanancias"]);
                    objEProveedor.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLProveedor.AgregarDeWeb(objEProveedor);
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
