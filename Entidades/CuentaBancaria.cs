using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CuentaBancaria: DatosGenerales
    {
        private Banco banco;
        private string numeroCuenta;
        private Moneda moneda;
        private CuentaContable cuentaContable;
        private CuentaContable cuentaContableValoresDiferidos;
        private CuentaContable cuentaContableTranferencias;
        private CuentaContable cuentaContablePrestamos;
        private CuentaContable cuentaContableDebitoCreditoCompras;
        public CuentaContable CuentaContablePayWay { get; set; }
        private Proveedor proveedor;
        private DateTime fechaConciliacion;
        private bool tranferencia;
        private bool debitoCredito;
        private bool debitoCreditoCompras;
        public bool PayWay { get; set; }

        public CuentaBancaria() {
            banco = new Banco();
            moneda = new Moneda();
            CuentaContable = new CuentaContable();
            CuentaContableValoresDiferidos = new CuentaContable();
            CuentaContableTranferencias = new CuentaContable();
            CuentaContablePrestamos = new CuentaContable();
            CuentaContableDebitoCreditoCompras = new CuentaContable();
            CuentaContablePayWay = new CuentaContable();
            Proveedor = new Proveedor();
        }

        public Banco Banco
        {
            get
            {
                return banco;
            }

            set
            {
                banco = value;
            }
        }

        public string NumeroCuenta
        {
            get
            {
                return numeroCuenta;
            }

            set
            {
                numeroCuenta = value;
            }
        }

        public Moneda Moneda
        {
            get
            {
                return moneda;
            }

            set
            {
                moneda = value;
            }
        }

        public CuentaContable CuentaContable
        {
            get
            {
                return cuentaContable;
            }

            set
            {
                cuentaContable = value;
            }
        }

        public CuentaContable CuentaContableValoresDiferidos
        {
            get
            {
                return cuentaContableValoresDiferidos;
            }

            set
            {
                cuentaContableValoresDiferidos = value;
            }
        }

        public CuentaContable CuentaContableTranferencias
        {
            get
            {
                return cuentaContableTranferencias;
            }

            set
            {
                cuentaContableTranferencias = value;
            }
        }

        public DateTime FechaConciliacion
        {
            get
            {
                return fechaConciliacion;
            }

            set
            {
                fechaConciliacion = value;
            }
        }

        public CuentaContable CuentaContablePrestamos
        {
            get
            {
                return cuentaContablePrestamos;
            }

            set
            {
                cuentaContablePrestamos = value;
            }
        }

        public bool Tranferencia
        {
            get
            {
                return tranferencia;
            }

            set
            {
                tranferencia = value;
            }
        }

        public bool DebitoCredito
        {
            get
            {
                return debitoCredito;
            }

            set
            {
                debitoCredito = value;
            }
        }

        public CuentaContable CuentaContableDebitoCreditoCompras
        {
            get
            {
                return cuentaContableDebitoCreditoCompras;
            }

            set
            {
                cuentaContableDebitoCreditoCompras = value;
            }
        }

        public bool DebitoCreditoCompras
        {
            get
            {
                return debitoCreditoCompras;
            }

            set
            {
                debitoCreditoCompras = value;
            }
        }

        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }

        public override string ToString()
        {
            string datos = "CUENTA BANCARIA\n--------\n";
            datos += "Codigo: " + this.Codigo.ToString() + "\n";
            //datos += "Banco: " + this.Banco.Descripcion.ToString() + "\n";
            datos += "Número Cuenta: " + this.NumeroCuenta.ToString() + "\n\n";
            return datos;
        }
    }
}
