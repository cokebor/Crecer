using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PercepcionesMunicipales
    {
        private string nombreCliente;
        private string calle;
        private string numero;
        private string piso="";
        private string departamento="";
        private string barrioLocalidad;
        private string codigoPostal;
       /* public string CuitEmpresa { get; set; }
        public string TipoCuitEmpresa() {
            return CuitEmpresa.Substring(1, 2);
        }

        public string NumeroCUITEmpresa()
        {
            return CuitEmpresa.Substring(4, 8);
        }
        public string DigitoVerificadorCuitEmpresa()
        {
            return CuitEmpresa.Substring(12, 1);
        }*/
        public string NroPercepcion { get; set; }
        public char LetraPercepcion { get; set; }
        public string Comprobante { get; set; }
        public string CuitCliente { get; set; }
        public string TipoCuitCliente()
        {
            return CuitCliente.Substring(0, 2);
        }

        public string NumeroCUITCliente()
        {
            return CuitCliente.Substring(3, 8);
        }
        public string DigitoVerificadorCuitCliente()
        {
            return CuitCliente.Substring(12, 1);
        }
        public double BaseImponible { get; set; }
        public string BaseImponibleStr() {
            return (Convert.ToInt32(BaseImponible * 100)).ToString("000000000000000");
        }
        public double Alicuota { get; set; }
        public string AlicuotaStr()
        {
            return (Convert.ToInt32(Alicuota * 100)).ToString("00000");
        }
        public double MontoPercepcion { get; set; }
        public string MontoPercepcionStr()
        {
            return (Convert.ToInt32(MontoPercepcion * 100)).ToString("000000000000000");
        }
        public char Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string PeriodoPresentacion() {
            return Fecha.Date.Year.ToString("0000") + Fecha.Date.Month.ToString("00");
        }
        public string FechaCargaPercepcion()
        {
            return Fecha.Date.Year.ToString("0000") + Fecha.Date.Month.ToString("00") + Fecha.Date.Day.ToString("00");
        }
        public string NombreCliente
        {
            get
            {
                return nombreCliente.PadRight(50);
            }

            set
            {
                nombreCliente = value;
            }
        }
        public string Calle
        {
            get
            {
                return calle.PadRight(50);
            }

            set
            {
                calle = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero.PadLeft(5, '0'); 
            }

            set
            {
                numero = value;
            }
        }



        public string Piso
        {
            get
            {
                return piso.PadLeft(5, '0'); 
            }

            set
            {
                piso = value;
            }
        }

        public string Departamento
        {
            get
            {
                return departamento.PadLeft(5, '0');
            }

            set
            {
                departamento = value;
            }
        }

        public string BarrioLocalidad
        {
            get
            {
                return barrioLocalidad.PadRight(50);
            }

            set
            {
                barrioLocalidad = value;
            }
        }

        public string CodigoPostal
        {
            get
            {
                return codigoPostal.PadLeft(15,'0');
            }

            set
            {
                codigoPostal = value;
            }
        }

        public DateTime FechaInicioPercepcion { get; set; }
        public string FechaInicioPercepcionFormato()
        {
            return FechaInicioPercepcion.Date.Year.ToString("0000") + FechaInicioPercepcion.Date.Month.ToString("00") + FechaInicioPercepcion.Date.Day.ToString("00");
        }
        public string FechaAnulacionPercepcion()
        {
            return "19000101";
        }

        public DateTime FechaCambiosDatos { get; set; }
        public string FechaCambiosDatosFormato()
        {
            return FechaCambiosDatos.Date.Year.ToString("0000") + FechaCambiosDatos.Date.Month.ToString("00") + FechaCambiosDatos.Date.Day.ToString("00");
        }
    }
}
