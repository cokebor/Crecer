using System;
using System.Collections.Generic;

namespace Entidades
{
    public class CITICompras
    {
        public CITICompras(){
            Alicuotas = new List<CITIVentasAlicuotas>();
        }

        private DateTime fecha;
        private int codigoTipoDocumentoAFIP;
        private int puntoDeVenta;
        private int numero;
        private string despachoImportacion;
        private int codigoDocumentoVendedor;
        private string cUIT;
        private string proveedor;
        private int total;
        private int totalConceptosQueNoIntegranNetoGravado;
        private int operacionesExentas;
        private int importePercepcionesIVA;
        private int importePercepciones;
        private int importePercepcionesIIBB;
        private int importePercepcionesMunicipales;
        private int importeImpuestosInternos;
        private string codigoMoneda;
        private int tipoCambio;
        private string codigoOperacion;
        private int creditoFiscal;
        private int otrosTributos;
        private string cUITEmisor;
        private string nombreEmisor;
        private int iVAComision;
        private char letra;

        private List<CITIVentasAlicuotas> alicuotas;

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

        public string DespachoImportacion
        {
            get
            {
                return despachoImportacion;
            }

            set
            {
                despachoImportacion = value;
            }
        }

        public int CodigoDocumentoVendedor
        {
            get
            {
                return codigoDocumentoVendedor;
            }

            set
            {
                codigoDocumentoVendedor = value;
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

        public string Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
            }
        }

        public int Total
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

        public int ImportePercepcionesIVA
        {
            get
            {
                return importePercepcionesIVA;
            }

            set
            {
                importePercepcionesIVA = value;
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

        public int CreditoFiscal
        {
            get
            {
                return creditoFiscal;
            }

            set
            {
                creditoFiscal = value;
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

        public string CUITEmisor
        {
            get
            {
                return cUITEmisor;
            }

            set
            {
                cUITEmisor = value;
            }
        }

        public string NombreEmisor
        {
            get
            {
                return nombreEmisor;
            }

            set
            {
                nombreEmisor = value;
            }
        }

        public int IVAComision
        {
            get
            {
                return iVAComision;
            }

            set
            {
                iVAComision = value;
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

        public int CantAlicuotas()
        {
            if (this.letra.Equals('A') || this.letra.Equals('M'))
            {
                if (Alicuotas.Count > 0)
                    return Alicuotas.Count;
                else
                    return 1;
            }
            else {
                return 0;
            }
        }
    }
}
