using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public static class Novedades
    {
        static Banco banco = null;
        static Cliente cliente = null;
        static Comunicacion comunicacion = null;
        static CuentaBancaria cuentaBancaria = null;
        static Empleado empleado = null;
        static Localidad localidad = null;
        static Moneda moneda = null;
        static Pais pais = null;
        static ObraSocial obraSocial = null;
        static Precio precios = null;
        static Producto producto = null;
        static Proveedor proveedor = null;
        static Provincia provincia = null;
        static Puesto puesto = null;
        static RemitoSucursal remito = null;
        static RubroProducto rubro = null;
        static TipoMovimientoBancario tipoMovimiento = null;
        static SucursalCliente sucursalCliente = null;

        public static Entidades.Empresa Empresa;
        static Novedades()
        {
            banco = new Banco();
            cliente = new Cliente();
            comunicacion = new Comunicacion();
            cuentaBancaria = new CuentaBancaria();
            empleado = new Empleado();
            localidad = new Localidad();
            moneda = new Moneda();
            pais = new Pais();
            obraSocial = new ObraSocial();
            precios = new Precio();
            producto = new Producto();
            proveedor = new Proveedor();
            provincia = new Provincia();
            puesto = new Puesto();
            remito = new RemitoSucursal();
            rubro = new RubroProducto();
            tipoMovimiento = new TipoMovimientoBancario();
            sucursalCliente = new SucursalCliente();
        }
        public static void EnviarNovedades(/*BackgroundWorker b*/)
        {
            
            SingletonNovedad.Instancia.Empresa = Empresa;
            try
            {
                pais.Enviar();
                comunicacion.Enviar();
                provincia.Enviar();
                localidad.Enviar();

                if (Empresa.Codigo == 1)
                {
                    obraSocial.Enviar();
                    puesto.Enviar();
                    empleado.Enviar();
                    rubro.Enviar();
                    producto.Enviar();
                    proveedor.Enviar();
                    moneda.Enviar();
                    precios.Enviar();
                    cuentaBancaria.Enviar();
                }
                cliente.Enviar();
                sucursalCliente.Enviar();
                banco.Enviar();
                remito.Enviar();
                tipoMovimiento.Enviar();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            

        }
        public static string RecibirNovedades(/*BackgroundWorker b*/)
        {
            string datos = "";
            SingletonNovedad.Instancia.Empresa = Empresa;

            
            try
            {
                pais.Recibir();

                comunicacion.Recibir();
                provincia.Recibir();
                localidad.Recibir();
                if (!(Empresa.Codigo == 1))
                {
                    obraSocial.Recibir();
                    puesto.Recibir();
                    empleado.Recibir();
                    rubro.Recibir();
                    producto.Recibir();
                    proveedor.Recibir();
                    moneda.Recibir();
                    precios.Recibir();
                    datos += cuentaBancaria.Recibir();
                }
                if (Empresa.Codigo == 1)
                {
                    cliente.Recibir();
                    sucursalCliente.Recibir();
                }

                banco.Recibir();
                remito.Recibir();
                tipoMovimiento.Recibir();

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }

}
