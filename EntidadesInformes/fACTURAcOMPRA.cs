using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class FacturaCompra
    {
        private DateTime fechaEmision;
        private string numero;
        private string tipoDocumento;

        public DateTime FechaEmision
        {
            get
            {
                return fechaEmision;
            }

            set
            {
                fechaEmision = value;
            }
        }

        public string Numero
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

        public string TipoDocumento
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
    }
}
