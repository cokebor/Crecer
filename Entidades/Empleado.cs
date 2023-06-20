using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumeraciones;

namespace Entidades
{
    public class Empleado : Persona
    {
        public Empleado()
        {
            puesto = new Puesto();
            egreso = new Egreso();
            obraSocial = new ObraSocial();
            banco = new Banco();
            Sucursal = new Sucursal();
        }

        public Empleado(int pCodigo, string pApellido, string pNombres, Enumeraciones.Enumeraciones.Sexos pSexo, DateTime pFechaNacimiento, Enumeraciones.Enumeraciones.TiposDeDocumentos pTipoDeDocumento, string pNumeroDocumento, Domicilio pDomicilio, Enumeraciones.Enumeraciones.EstadosCiviles pEstadoCivil, string pLegajo, string pCUIL, Puesto pPuesto, int pCantidadHijos, ObraSocial pObraSocial, DateTime pFechaIngreso) : base(pCodigo, pApellido, pNombres, pSexo, pFechaNacimiento, pTipoDeDocumento, pNumeroDocumento, pDomicilio, pEstadoCivil)
        {
            Legajo = pLegajo;
            CUIL = pCUIL;
            Puesto = pPuesto;
            CantidadHijos = pCantidadHijos;
            ObraSocial = pObraSocial;
            FechaIngreso = pFechaIngreso;
        }

        public Empleado(int pCodigo, string pLegajo, string pNumeroDocumento, string pApellido, string pNombres) : base(pCodigo, pNumeroDocumento, pApellido, pNombres)
        {
            Legajo = pLegajo;
        }

        private string legajo;
        private string cUIL;
        private Puesto puesto;
        private int cantidadHijos;
        private ObraSocial obraSocial;
        private DateTime fechaIngreso;
        private Egreso egreso;
        private bool esEmpleado;
        private double sueldoEfectivo;
        private double sueldoBanco;
        private Banco banco;
        public Sucursal Sucursal  { get; set; }
        public bool FueraDeConvenio { get; set; }
        public string Legajo
        {
            get
            {
                return legajo;
            }

            set
            {
                legajo = value;
            }
        }

        public string CUIL
        {
            get
            {
                return cUIL;
            }

            set
            {
                cUIL = value;
            }
        }

        public Puesto Puesto
        {
            get
            {
                return puesto;
            }

            set
            {
                puesto = value;
            }
        }

        public int CantidadHijos
        {
            get
            {
                return cantidadHijos;
            }

            set
            {
                cantidadHijos = value;
            }
        }

        public ObraSocial ObraSocial
        {
            get
            {
                return obraSocial;
            }

            set
            {
                obraSocial = value;
            }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return fechaIngreso;
            }

            set
            {
                fechaIngreso = value;
            }
        }

        public Egreso Egreso
        {
            get
            {
                return egreso;
            }

            set
            {
                egreso = value;
            }
        }

        public bool EsEmpleado
        {
            get
            {
                return esEmpleado;
            }

            set
            {
                esEmpleado = value;
            }
        }

        public double SueldoEfectivo
        {
            get
            {
                return sueldoEfectivo;
            }

            set
            {
                sueldoEfectivo = value;
            }
        }

        public double SueldoBanco
        {
            get
            {
                return sueldoBanco;
            }

            set
            {
                sueldoBanco = value;
            }
        }

        public double Sueldo
        {
            get
            {
                return SueldoEfectivo + SueldoBanco;
            }
        }

        public Banco Banco
        {
            get
            {
                return banco;
            }

            set
            {
                banco = value;
            }
        }
    }
}
