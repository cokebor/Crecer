using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumeraciones;

namespace Entidades
{
    public class Cliente : DatosGenerales
    {
        public Cliente()
        {
            tipoInscripcion = new TipoInscripcion();
            domicilio = new Domicilio();
            comunicaciones = new List<Comunicacion>();
            descuentos = new List<Descuento>();
            TipoContribuyente = new TipoContribuyente();
            tipoDocumento = new TipoDocumento();
            sucursales = new List<SucursalCliente>();
        }

        private string nombre;
        private TipoDocumento tipoDocumento;
        private string cUIT;
        private DateTime fechaValidacionCUIT;
        private TipoInscripcion tipoInscripcion;
        private Domicilio domicilio;
        private List<Comunicacion> comunicaciones;
        private List<Descuento> descuentos;
        private bool facturaKilos;
        private string observaciones;
        private double deuda;
        private double comision;
        private bool original;
        private bool duplicado;
        private bool triplicado;
        private List<SucursalCliente> sucursales;
        private bool ctaCte;
        public TipoContribuyente TipoContribuyente { get; set; }
        public bool RiesgoFiscal { get; set; }
        public bool FacturacionPorCubeta { get; set; }
        public bool MiPYME { get; set; }
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = Utilidades.Convertir.AMayusculas(value);
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

        public DateTime FechaValidacionCUIT
        {
            get
            {
                return fechaValidacionCUIT;
            }

            set
            {
                fechaValidacionCUIT = value;
            }
        }

        public TipoInscripcion TipoInscripcion
        {
            get
            {
                return tipoInscripcion;
            }

            set
            {
                tipoInscripcion = value;
            }
        }

        public Domicilio Domicilio
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

        public List<Comunicacion> Comunicaciones
        {
            get
            {
                return comunicaciones;
            }

            set
            {
                comunicaciones = value;
            }
        }

        public List<Descuento> Descuentos
        {
            get
            {
                return descuentos;
            }

            set
            {
                descuentos = value;
            }
        }
        public bool FacturaKilos
        {
            get
            {
                return facturaKilos;
            }

            set
            {
                facturaKilos = value;
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

        public string CUITSinGuion
        {
            get
            {
                return cUIT.Substring(0, 2) + cUIT.Substring(3, 8) + cUIT.Substring(12, 1);
            }


        }
        public string DNI
        {
            get
            {
                return cUIT.Substring(3, 8);
            }


        }
        public double Deuda
        {
            get
            {
                return deuda;
            }

            set
            {
                deuda = value;
            }
        }

        public double Comision
        {
            get
            {
                return comision;
            }

            set
            {
                comision = value;
            }
        }

        public bool Original
        {
            get
            {
                return original;
            }

            set
            {
                original = value;
            }
        }

        public bool Duplicado
        {
            get
            {
                return duplicado;
            }

            set
            {
                duplicado = value;
            }
        }

        public bool Triplicado
        {
            get
            {
                return triplicado;
            }

            set
            {
                triplicado = value;
            }
        }

        public TipoDocumento TipoDocumento
        {
            get
            {
                return tipoDocumento;
            }

            set
            {
                tipoDocumento = value;
            }
        }

        public List<SucursalCliente> Sucursales
        {
            get
            {
                return sucursales;
            }

            set
            {
                sucursales = value;
            }
        }

        public bool CtaCte
        {
            get
            {
                return ctaCte;
            }

            set
            {
                ctaCte = value;
            }
        }
    }
}
