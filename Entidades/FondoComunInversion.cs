using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FondoComunInversion
    {
        public FondoComunInversion() {
            Fondo = new Fondo();
            Usuario = new Usuario();
            CuentaBancaria = new CuentaBancaria();
            fondos = new List<FondoComunInversion>();
        }
        private int codigo;
        private DateTime fecha;
        private Fondo fondo;
        private char codigoTipoOperacion;
        private double cantCuotapartes;
        private double cantCuotapartesRestantes;
        private double valorCuotaparte;
        private CuentaBancaria cuentaBancaria;
        private List<FondoComunInversion> fondos;
        private double importe;
        private string observaciones;
        private string nroReferencia;
        private Usuario usuario;

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

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public Fondo Fondo
        {
            get
            {
                return fondo;
            }

            set
            {
                fondo = value;
            }
        }

        public char CodigoTipoOperacion
        {
            get
            {
                return codigoTipoOperacion;
            }

            set
            {
                codigoTipoOperacion = value;
            }
        }

        public double CantCuotapartes
        {
            get
            {
                return Utilidades.Redondear.DosDecimales(cantCuotapartes);
            }

            set
            {
                cantCuotapartes = Utilidades.Redondear.DosDecimales(value);
            }
        }

        public double CantCuotapartesRestantes
        {
            get
            {
                return Utilidades.Redondear.DosDecimales(cantCuotapartesRestantes);
            }

            set
            {
                cantCuotapartesRestantes = Utilidades.Redondear.DosDecimales(value);
            }
        }

        public double ValorCuotaparte
        {
            get
            {
                return valorCuotaparte;
            }

            set
            {
                valorCuotaparte = value;
            }
        }

        public double Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public CuentaBancaria CuentaBancaria
        {
            get
            {
                return cuentaBancaria;
            }

            set
            {
                cuentaBancaria = value;
            }
        }

        public List<FondoComunInversion> Fondos
        {
            get
            {
                return fondos;
            }

            set
            {
                fondos = value;
            }
        }

        public string NroReferencia
        {
            get
            {
                return nroReferencia;
            }

            set
            {
                nroReferencia = value;
            }
        }
    }
}
