using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDocumentoProveedor : DatosGenerales, IEquatable<TipoDocumentoProveedor>
    {
        public TipoDocumentoProveedor()
        {
            tipoDoc = new TipoDoc();
            Numerador = new Numerador();
            tiposInscripcion = new List<TipoInscripcion>();
            impuestos = new List<TipoDocumentoProveedorImpuesto>();
        }

        private string descripcion;
        private TipoDoc tipoDoc;
        private Numerador numerador;
        private char afectaCtaCte;
        private char afectaCaja;
        private char afectaIVA;
        private char tipoDiscIVA;
        private char letra;
        private List<TipoInscripcion> tiposInscripcion;
        private List<TipoDocumentoProveedorImpuesto> impuestos;
        
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

        public TipoDoc TipoDoc
        {
            get
            {
                return tipoDoc;
            }

            set
            {
                tipoDoc = value;
            }
        }

        public char AfectaCtaCte
        {
            get
            {
                return afectaCtaCte;
            }

            set
            {
                afectaCtaCte = value;
            }
        }

        public char AfectaCaja
        {
            get
            {
                return afectaCaja;
            }

            set
            {
                afectaCaja = value;
            }
        }

        public char AfectaIVA
        {
            get
            {
                return afectaIVA;
            }

            set
            {
                afectaIVA = value;
            }
        }

        public char TipoDiscIVA
        {
            get
            {
                return tipoDiscIVA;
            }

            set
            {
                tipoDiscIVA = value;
            }
        }

        public List<TipoInscripcion> TiposInscripcion
        {
            get
            {
                return tiposInscripcion;
            }

            set
            {
                tiposInscripcion = value;
            }
        }

        public Numerador Numerador
        {
            get
            {
                return numerador;
            }

            set
            {
                numerador = value;
            }
        }

        public char Letra
        {
            get
            {
                return letra;
            }

            set
            {
                letra = value;
            }
        }

        public List<TipoDocumentoProveedorImpuesto> Impuestos
        {
            get
            {
                return impuestos;
            }

            set
            {
                impuestos = value;
            }
        }

        // override object.Equals
        public bool Equals(TipoDocumentoProveedor obj)
        {
            return this.Codigo == obj.Codigo;
        }

        // override object.GetHashCode
    }
}
