using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Concepto:DatosGenerales
    {
        public Concepto() {
            this.Usuario = new Usuario();
            this.ConceptosAsociados = new List<ConceptoAsociado>();
            this.RetencionesAsociados = new List<RetencionAsociado>();
            this.LibreDisponibilidadAsociado = new List<Entidades.LibreDisponibilidadAsociado>();
        }
        public Concepto(int pCodigo, string pDescripcion, bool pImpuesto) : base(pCodigo) {
            this.Codigo = pCodigo;
            this.Descripcion = pDescripcion;
            this.Impuesto = pImpuesto;
            this.Usuario = new Usuario();
            this.ConceptosAsociados = new List<ConceptoAsociado>();
            this.RetencionesAsociados = new List<RetencionAsociado>();
            this.LibreDisponibilidadAsociado = new List<Entidades.LibreDisponibilidadAsociado>();
        }

        private string descripcion;

        private bool impuesto;

        //private List<CuentaContable> cuentasContables;
        private List<ConceptoAsociado> conceptosAsociados;
        private List<RetencionAsociado> retencionesAsociados;
        private List<LibreDisponibilidadAsociado> libreDisponibilidadAsociado;

        private Usuario usuario;
        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                //descripcion = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());

                descripcion = value.ToUpper();
            }
        }

        public bool Impuesto
        {
            get
            {
                return impuesto;
            }

            set
            {
                impuesto = value;
            }
        }

        /*public List<CuentaContable> CuentasContables
        {
            get
            {
                return cuentasContables;
            }

            set
            {
                cuentasContables = value;
            }
        }*/

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

        public List<ConceptoAsociado> ConceptosAsociados
        {
            get
            {
                return conceptosAsociados;
            }

            set
            {
                conceptosAsociados = value;
            }
        }

        public List<RetencionAsociado> RetencionesAsociados
        {
            get
            {
                return retencionesAsociados;
            }

            set
            {
                retencionesAsociados = value;
            }
        }

        public List<LibreDisponibilidadAsociado> LibreDisponibilidadAsociado
        {
            get
            {
                return libreDisponibilidadAsociado;
            }

            set
            {
                libreDisponibilidadAsociado = value;
            }
        }
    }
}
