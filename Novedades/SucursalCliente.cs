using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class SucursalCliente
    {
        Entidades.SucursalCliente objES = new Entidades.SucursalCliente();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.SucursalCliente objLWSCliente = new LogicaWeb.SucursalCliente();
        Logica.SucursalCliente objLSCliente = new Logica.SucursalCliente();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtSucursales = objLSCliente.ObtenerNovedades();
                foreach (DataRow dr in dtSucursales.Rows)
                {
                    objES.CodigoCliente = Convert.ToInt32(dr["CodigoCliente"]);
                    objES.CodigoSucursal = Convert.ToInt32(dr["CodigoSucursal"]);
                    objES.NombreSucursal = dr["NombreSucursal"].ToString();
                    objES.Domicilio.Direccion = dr["Direccion"].ToString();
                    objES.Domicilio.Numero = dr["Numero"].ToString();
                    objES.Domicilio.Barrio = dr["Barrio"].ToString();
                    objES.Domicilio.CodigoPostal = dr["CodigoPostal"].ToString();
                    objES.Domicilio.Localidad.Codigo= Convert.ToInt32(dr["CodigoLocalidad"]);
                    

                    objLWSCliente.Agregar(objES, SingletonNovedad.Instancia.Empresa);
                    objLSCliente.CambiarEstadoNovedad(objES);
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
                objENovedad = objLNovedad.ObtenerUno("SucursalesClientes");

                DataTable dtSCliente = objLWSCliente.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtSCliente.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objES.CodigoCliente = Convert.ToInt32(dr["CodigoCliente"]);
                    objES.CodigoSucursal = Convert.ToInt32(dr["CodigoSucursal"]);
                    objES.NombreSucursal = dr["NombreSucursal"].ToString();
                    objES.Domicilio.Direccion = dr["Direccion"].ToString();
                    objES.Domicilio.Numero = dr["Numero"].ToString();
                    objES.Domicilio.Barrio = dr["Barrio"].ToString();
                    objES.Domicilio.CodigoPostal = dr["CodigoPostal"].ToString();
                    objES.Domicilio.Localidad.Codigo = Convert.ToInt32(dr["CodigoLocalidad"]);

                    objLSCliente.AgregarDeWeb(objES);
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
