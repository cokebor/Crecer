using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FormaDePago
    {
        private int codigo;
        private string descripcion;
        private CuentaContable cuentaContable;
        private bool compra;
        private bool venta;
        private bool formaPago;
        public FormaDePago() {
            cuentaContable = new CuentaContable();
        }

        public FormaDePago(int pCodigo, string pDescripcion)
        {
            cuentaContable = new CuentaContable();
        }

        public FormaDePago(string pDescripcion) {
            Descripcion = pDescripcion;
        }
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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
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

        public bool Compra
        {
            get
            {
                return compra;
            }

            set
            {
                compra = value;
            }
        }

        public bool Venta
        {
            get
            {
                return venta;
            }

            set
            {
                venta = value;
            }
        }

        public bool FormaPago
        {
            get
            {
                return formaPago;
            }

            set
            {
                formaPago = value;
            }
        }
    }
}
