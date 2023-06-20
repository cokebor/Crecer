using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Novedad
    {
        private string descripcion;
        private int codigoNovedad;

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

        public int CodigoNovedad
        {
            get
            {
                return codigoNovedad;
            }

            set
            {
                codigoNovedad = value;
            }
        }


        /*
        private int codigoSucursalCambio;
        private bool deposito;
        private bool nave7;
        private bool villaMaria;
        private bool rioCuarto;
        private bool sucursal6;

        public int CodigoSucursalCambio
        {
            get
            {
                return codigoSucursalCambio;
            }

            set
            {
                codigoSucursalCambio = value;
            }
        }

        public bool Deposito
        {
            get
            {
                return deposito;
            }

            set
            {
                deposito = value;
            }
        }

        public bool Nave7
        {
            get
            {
                return nave7;
            }

            set
            {
                nave7 = value;
            }
        }

        public bool VillaMaria
        {
            get
            {
                return villaMaria;
            }

            set
            {
                villaMaria = value;
            }
        }

        public bool RioCuarto
        {
            get
            {
                return rioCuarto;
            }

            set
            {
                rioCuarto = value;
            }
        }

        public bool Sucursal6
        {
            get
            {
                return sucursal6;
            }

            set
            {
                sucursal6 = value;
            }
        }*/
    }
}
