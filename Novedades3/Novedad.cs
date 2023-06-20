using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public static class Novedad
    {
        static Pais pais = null;
        static Comunicacion comunicacion = null;
        static ObraSocial obraSocial = null;
        static Puesto puesto = null;
        static Provincia provincia = null;
        static Localidad localidad = null;
        static Empleado empleado = null;
        static RubroProducto rubro = null;
        static Producto producto = null;
        static Proveedor proveedor = null;
        static Cliente cliente = null;
        static Moneda moneda = null;
        static Banco banco = null;
        static RemitoSucursal remito = null;
        static TipoMovimientoBancario tipoMovimiento = null;
        static Precio precios = null;
        static CuentaBancaria cuentaBancaria = null;
        static SucursalCliente sucursalCliente = null;

        public static Entidades.Empresa Empresa;
        static Novedad()
        {
            pais = new Pais();
            comunicacion = new Comunicacion();
            obraSocial = new ObraSocial();
            puesto = new Puesto();
            provincia = new Provincia();
            localidad = new Localidad();
            empleado = new Empleado();
            rubro = new RubroProducto();
            producto = new Producto();
            proveedor = new Proveedor();
            cliente = new Cliente();
            moneda = new Moneda();
            banco = new Banco();
            remito = new RemitoSucursal();
            tipoMovimiento = new TipoMovimientoBancario();
            precios = new Precio();
            cuentaBancaria = new CuentaBancaria();
            sucursalCliente = new SucursalCliente();
        }

        public static void EnviarNovedades()
        {
            SingletonNovedad.Instancia.Empresa = Empresa;
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
        public static string RecibirNovedades()
        {
            string datos = "";
            SingletonNovedad.Instancia.Empresa = Empresa;
            datos=pais.Recibir();
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
            cliente.Recibir();
            sucursalCliente.Recibir();
            banco.Recibir();
            remito.Recibir();
            tipoMovimiento.Recibir();

            return datos;
        }

    }
}
