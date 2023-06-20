using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public static class Fechas
    {
        public static int DiferenciaEntreFechasEnAños(DateTime pFechaMayor, DateTime pFechaMenor) {
            return pFechaMayor.Date.AddTicks(-Convert.ToDateTime(pFechaMenor.Date).Ticks).Year - 1;
        }

        public static int DiferenciaEntreFechasEnMeses(DateTime pFechaMayor, DateTime pFechaMenor)
        {
            return(pFechaMayor.Date.Month - pFechaMenor.Date.Month) + 12 * (pFechaMayor.Year - pFechaMenor.Year);
        }

        public static int DiferenciaEntreFechasEnDias(DateTime pFechaMayor, DateTime pFechaMenor)
        {
            DateTime pFecha = pFechaMayor.AddDays(1);
            return (pFecha.Date- pFechaMenor.Date).Days;
        }
    }
}
