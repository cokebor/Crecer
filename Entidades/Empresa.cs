using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresa
    {
        public Empresa() {
            cuentaContableVentaSucursal = new CuentaContable();
            cuentaContableIvaDebitoSucursal = new CuentaContable();
            cuentaContableDebolucionMercaderiaSucursal = new CuentaContable();
            cuentaContableAjusteSucursal = new CuentaContable();
            cuentaContableCuentaCorrienteProveedores = new CuentaContable();
            cuentaContableCuentaCorrienteClientes = new CuentaContable();
            cuentaContableDescuentosClientes = new CuentaContable();
        }

        private int codigo;
        private string nombreSucursal;
        private string razonSocial;
        private string cUIT;
        //private int puntoDeVentaElectronico;
        private string domicilio;
        private string puesto;
        private string domicilio2;
        private string ingresosBrutos;
        private string fechaInicioActividad;
        private CuentaContable cuentaContableVentaSucursal;
        private CuentaContable cuentaContableIvaDebitoSucursal;
        private CuentaContable cuentaContableDebolucionMercaderiaSucursal;
        private CuentaContable cuentaContableAjusteSucursal;
        private CuentaContable cuentaContableCuentaCorrienteProveedores;
        private CuentaContable cuentaContableCuentaCorrienteClientes;
        private CuentaContable cuentaContableDescuentosClientes;
        private bool fiscal;
        private string logo;
        private bool facturasM;
        public bool PercepcionMunicipal { get; set; }

        public bool Convenio { get; set; }
        public string CBUFacturasDeCredito { get; set; }
        public string DireccionBackup { get; set; }
        public bool Imprimir { get; set; }
        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string RazonSocial
        {
            get
            {
                return razonSocial;
            }

            set
            {
                razonSocial = value;
            }
        }

        public CuentaContable CuentaContableVentaSucursal
        {
            get
            {
                return cuentaContableVentaSucursal;
            }

            set
            {
                cuentaContableVentaSucursal = value;
            }
        }

        public CuentaContable CuentaContableIvaDebitoSucursal
        {
            get
            {
                return cuentaContableIvaDebitoSucursal;
            }

            set
            {
                cuentaContableIvaDebitoSucursal = value;
            }
        }
        /*
        public int PuntoDeVentaElectronico
        {
            get
            {
                return puntoDeVentaElectronico;
            }

            set
            {
                puntoDeVentaElectronico = value;
            }
        }*/

        public string CUIT
        {
            get
            {
                return cUIT;
            }

            set
            {
                cUIT = value;
            }
        }

        public string CUITSinGuion
        {
            get
            {
                return cUIT.Substring(0,2) + cUIT.Substring(3, 8) + cUIT.Substring(12, 1);
            }

            
        }

        public string Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                domicilio = value;
            }
        }

        public string NombreSucursal
        {
            get
            {
                return nombreSucursal;
            }

            set
            {
                nombreSucursal = value;
            }
        }

        public string Domicilio2
        {
            get
            {
                return domicilio2;
            }

            set
            {
                domicilio2 = value;
            }
        }

        public string Puesto
        {
            get
            {
                return puesto;
            }

            set
            {
                puesto = value;
            }
        }

        public string IngresosBrutos
        {
            get
            {
                return ingresosBrutos;
            }

            set
            {
                ingresosBrutos = value;
            }
        }

        public string FechaInicioActividad
        {
            get
            {
                return fechaInicioActividad;
            }

            set
            {
                fechaInicioActividad = value;
            }
        }

        public CuentaContable CuentaContableDebolucionMercaderiaSucursal
        {
            get
            {
                return cuentaContableDebolucionMercaderiaSucursal;
            }

            set
            {
                cuentaContableDebolucionMercaderiaSucursal = value;
            }
        }

        public CuentaContable CuentaContableAjusteSucursal
        {
            get
            {
                return cuentaContableAjusteSucursal;
            }

            set
            {
                cuentaContableAjusteSucursal = value;
            }
        }

        public CuentaContable CuentaContableCuentaCorrienteProveedores
        {
            get
            {
                return cuentaContableCuentaCorrienteProveedores;
            }

            set
            {
                cuentaContableCuentaCorrienteProveedores = value;
            }
        }

        public CuentaContable CuentaContableCuentaCorrienteClientes
        {
            get
            {
                return cuentaContableCuentaCorrienteClientes;
            }

            set
            {
                cuentaContableCuentaCorrienteClientes = value;
            }
        }

        public bool Fiscal
        {
            get
            {
                return fiscal;
            }

            set
            {
                fiscal = value;
            }
        }

        public CuentaContable CuentaContableDescuentosClientes
        {
            get
            {
                return cuentaContableDescuentosClientes;
            }

            set
            {
                cuentaContableDescuentosClientes = value;
            }
        }

        public string Logo
        {
            get
            {
                return logo;
            }

            set
            {
                logo = value;
            }
        }

        public bool FacturasM
        {
            get
            {
                return facturasM;
            }

            set
            {
                facturasM = value;
            }
        }
    }
}
