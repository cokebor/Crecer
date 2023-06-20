using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDocumentoCliente : DatosGenerales
    {
        public TipoDocumentoCliente() {
            tipoDoc = new TipoDoc();
            numerador = new Numerador();
            tiposInscripcion = new List<TipoInscripcion>();
        }

        private string descripcion;
        private TipoDoc tipoDoc;
        private Numerador numerador;
        private char afectaCtaCte;
        private char afectaCaja;
        private char afectaIVA;
        private string afectaStock;
        private char tipoDiscIVA;
        private bool electronico;
        private List<TipoInscripcion> tiposInscripcion;
        public bool TipoDocLotes { get; set; }
        public bool MiPYME { get; set; }

        public bool FacturasM { get; set; }
        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
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

        public bool Electronico
        {
            get
            {
                return electronico;
            }

            set
            {
                electronico = value;
            }
        }

        public string AfectaStock
        {
            get
            {
                return afectaStock;
            }

            set
            {
                afectaStock = value;
            }
        }
    }
}
