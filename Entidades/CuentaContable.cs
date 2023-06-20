using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CuentaContable
    {
        public CuentaContable() {
            //cuentaPadre = new CuentaContable();
        }
        private Int64 codigo;
        private string nombre;
        private string saldo;
        private int genero;
        private int grupo;
        private int rubro;
        private int cuenta;
        private int subCuenta;
        private char tipo;

        public Int64 Codigo
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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Saldo
        {
            get
            {
                return saldo;
            }

            set
            {
                saldo = value;
            }
        }

        public int Genero
        {
            get
            {
                return genero;
            }

            set
            {
                genero = value;
            }
        }

        public int Grupo
        {
            get
            {
                return grupo;
            }

            set
            {
                grupo = value;
            }
        }

        public int Rubro
        {
            get
            {
                return rubro;
            }

            set
            {
                rubro = value;
            }
        }

        public int Cuenta
        {
            get
            {
                return cuenta;
            }

            set
            {
                cuenta = value;
            }
        }

        public int SubCuenta
        {
            get
            {
                return subCuenta;
            }

            set
            {
                subCuenta = value;
            }
        }

        public char Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }
        
    }
}
