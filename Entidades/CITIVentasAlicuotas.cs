using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CITIVentasAlicuotas
    {
        private long netoGravado;
        private int codigoAlicuotaAFIP;
        private long impuestoLiquidado;

        public long NetoGravado
        {
            get
            {
                return netoGravado;
            }

            set
            {
                netoGravado = value;
            }
        }

        public int CodigoAlicuotaAFIP
        {
            get
            {
                return codigoAlicuotaAFIP;
            }

            set
            {
                codigoAlicuotaAFIP = value;
            }
        }

        public long ImpuestoLiquidado
        {
            get
            {
                return impuestoLiquidado;
            }

            set
            {
                impuestoLiquidado = value;
            }
        }
    }
}
