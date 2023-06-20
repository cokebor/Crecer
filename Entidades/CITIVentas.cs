using System;
using System.Collections.Generic;

namespace Entidades
{
    public class CITIVentas
    {
        public CITIVentas(){
            Alicuotas = new List<CITIVentasAlicuotas>();
        }

        private DateTime fecha;
        private int codigoTipoDocumentoAFIP;
        private int puntoDeVenta;
        private int numero;
        private int codigoDocumentoComprador;
        private string cUIT;
        private string cliente;
        private long total;
        private int totalConceptosQueNoIntegranNetoGravado;
        private int percepcionNoCategorizados;
        private int operacionesExentas;
        private int importePercepciones;
        private int importePercepcionesIIBB;
        private int importePercepcionesMunicipales;
        private int importeImpuestosInternos;
        private string codigoMoneda;
        private int tipoCambio;
        private string codigoOperacion;
        private int otrosTributos;

        private List<CITIVentasAlicuotas> alicuotas;

        public int CantAlicuotas()
        {
            if (CodigoTipoDocumentoAFIP.Equals(2) && Alicuotas.Count == 0)
                return 1;
            else
                return Alicuotas.Count;
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

        public int CodigoTipoDocumentoAFIP
        {
            get
            {
                return codigoTipoDocumentoAFIP;
            }

            set
            {
                codigoTipoDocumentoAFIP = value;
            }
        }

        public int PuntoDeVenta
        {
            get
            {
                return puntoDeVenta;
            }

            set
            {
                puntoDeVenta = value;
            }
        }

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

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

        public string Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public long Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public int OperacionesExentas
        {
            get
            {
                return operacionesExentas;
            }

            set
            {
                operacionesExentas = value;
            }
        }

        public List<CITIVentasAlicuotas> Alicuotas
        {
            get
            {
                return alicuotas;
            }

            set
            {
                alicuotas = value;
            }
        }

        public int CodigoDocumentoComprador
        {
            get
            {
                return codigoDocumentoComprador;
            }

            set
            {
                codigoDocumentoComprador = value;
            }
        }

        public int TotalConceptosQueNoIntegranNetoGravado
        {
            get
            {
                return totalConceptosQueNoIntegranNetoGravado;
            }

            set
            {
                totalConceptosQueNoIntegranNetoGravado = value;
            }
        }

        public int PercepcionNoCategorizados
        {
            get
            {
                return percepcionNoCategorizados;
            }

            set
            {
                percepcionNoCategorizados = value;
            }
        }

        public int ImportePercepciones
        {
            get
            {
                return importePercepciones;
            }

            set
            {
                importePercepciones = value;
            }
        }

        public int ImportePercepcionesIIBB
        {
            get
            {
                return importePercepcionesIIBB;
            }

            set
            {
                importePercepcionesIIBB = value;
            }
        }

        public int ImportePercepcionesMunicipales
        {
            get
            {
                return importePercepcionesMunicipales;
            }

            set
            {
                importePercepcionesMunicipales = value;
            }
        }

        public int ImporteImpuestosInternos
        {
            get
            {
                return importeImpuestosInternos;
            }

            set
            {
                importeImpuestosInternos = value;
            }
        }

        public string CodigoMoneda
        {
            get
            {
                return codigoMoneda;
            }

            set
            {
                codigoMoneda = value;
            }
        }

        public int TipoCambio
        {
            get
            {
                return tipoCambio;
            }

            set
            {
                tipoCambio = value;
            }
        }

        public string CodigoOperacion
        {
            get
            {
                return codigoOperacion;
            }

            set
            {
                codigoOperacion = value;
            }
        }

        public int OtrosTributos
        {
            get
            {
                return otrosTributos;
            }

            set
            {
                otrosTributos = value;
            }
        }
    }
}
