using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RetencionesMunicipales
    {
        private string nombreProveedor;
        private string calle;
        private string numero;
        private string piso="";
        private string departamento="";
        private string barrioLocalidad;
        private string codigoPostal;

        public string NroRetencion { get; set; }
        public char LetraRetencion { get; set; }
        public string Comprobante { get; set; }
        public string CuitProveedor { get; set; }
        public string TipoCuitProveedor()
        {
            return CuitProveedor.Substring(0, 2);
        }

        public string NumeroCUITProveedor()
        {
            return CuitProveedor.Substring(3, 8);
        }
        public string DigitoVerificadorCuitProveedor()
        {
            return CuitProveedor.Substring(12, 1);
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
        public double MontoRetencion { get; set; }
        public string MontoRetencionStr()
        {
            return (Convert.ToInt32(MontoRetencion * 100)).ToString("000000000000000");
        }
        public char Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string PeriodoPresentacion() {
            return Fecha.Date.Year.ToString("0000") + Fecha.Date.Month.ToString("00");
        }
        public string FechaCargaRetencion()
        {
            return Fecha.Date.Year.ToString("0000") + Fecha.Date.Month.ToString("00") + Fecha.Date.Day.ToString("00");
        }
        public string NombreProveedor
        {
            get
            {
                return nombreProveedor.PadRight(50);
            }

            set
            {
                nombreProveedor = value;
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

        public DateTime FechaInicioRetencion { get; set; }
        public string FechaInicioRetencionFormato()
        {
            return FechaInicioRetencion.Date.Year.ToString("0000") + FechaInicioRetencion.Date.Month.ToString("00") + FechaInicioRetencion.Date.Day.ToString("00");
        }
        public string FechaAnulacionRetencion()
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
