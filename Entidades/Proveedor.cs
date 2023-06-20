using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor : DatosGenerales
    {
        public Proveedor() {
            tipoInscripcion = new TipoInscripcion();
            domicilio = new Domicilio();
            comunicaciones = new List<Comunicacion>();
            categoriaProveedor = new CategoriaProveedor();
            TipoContribuyente = new TipoContribuyente();
        }

        private string nombre;
        private TipoInscripcion tipoInscripcion;
        private string cUIT;
        private string ingresosBrutos;
        private Domicilio domicilio;
        private List<Comunicacion> comunicaciones;
        private CategoriaProveedor categoriaProveedor;
        private string observaciones;
        private double comision;
        private bool formaPago;
        private bool inscriptoGanancias;

        public TipoContribuyente TipoContribuyente { get; set; }
        public bool RiesgoFiscal { get; set; }
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

        public string IngresosBrutos
        {
            get
            {
                return ingresosBrutos;
            }

            set
            {
                ingresosBrutos = value;
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

        public CategoriaProveedor CategoriaProveedor
        {
            get
            {
                return categoriaProveedor;
            }

            set
            {
                categoriaProveedor = value;
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

        public bool InscriptoGanancias
        {
            get
            {
                return inscriptoGanancias;
            }

            set
            {
                inscriptoGanancias = value;
            }
        }
    }
}
