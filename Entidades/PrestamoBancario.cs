using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PrestamoBancario
    {
        private int codigoPrestamo;
        private DateTime fechaOtorgamiento;
        private CuentaBancaria cuentabancaria;
        private SistemaAmortizacion sistemaAmortizacion;
        private double capital;
        private FrecuenciaDePago frecuenciaPago;
        private int cantCuotas;
        private double tNA;
        private PeriodoDeGracia periodoDeGracia;
        private DateTime fechaPrimerCuota;
        private bool pagarEnUnaCUota;
        private Asiento asiento ;
        private List<TablaAmortizacion> tablaAmortizacion;

        public DateTime FechaOtorgamiento
        {
            get
            {
                return fechaOtorgamiento;
            }

            set
            {
                fechaOtorgamiento = value;
            }
        }

        public CuentaBancaria Cuentabancaria
        {
            get
            {
                return cuentabancaria;
            }

            set
            {
                cuentabancaria = value;
            }
        }

        public SistemaAmortizacion SistemaAmortizacion
        {
            get
            {
                return sistemaAmortizacion;
            }

            set
            {
                sistemaAmortizacion = value;
            }
        }

        public double Capital
        {
            get
            {
                return capital;
            }

            set
            {
                capital = value;
            }
        }

        public FrecuenciaDePago FrecuenciaPago
        {
            get
            {
                return frecuenciaPago;
            }

            set
            {
                frecuenciaPago = value;
            }
        }

        public int CantCuotas
        {
            get
            {
                return cantCuotas;
            }

            set
            {
                cantCuotas = value;
            }
        }

        public double TNA
        {
            get
            {
                return tNA;
            }

            set
            {
                tNA = value;
            }
        }

        public PeriodoDeGracia PeriodoDeGracia
        {
            get
            {
                return periodoDeGracia;
            }

            set
            {
                periodoDeGracia = value;
            }
        }

        public DateTime FechaPrimerCuota
        {
            get
            {
                return fechaPrimerCuota;
            }

            set
            {
                fechaPrimerCuota = value;
            }
        }

        private int DiasPeriodoDeGracia {
            get {
                int dias = (FechaPrimerCuota.AddMonths(-1) - FechaOtorgamiento).Days;
                if (dias < 0)
                {
                    dias = (FechaPrimerCuota - FechaOtorgamiento).Days;
                }
                return dias;
            }
        }

        private int DiasPeriodoDeGracia2
        {
            get
            {
                DateTime f = this.FechaOtorgamiento.AddMonths(1);
                f = Convert.ToDateTime(this.FechaPrimerCuota.Day + "/" + f.Month + "/" + f.Year);

                int dias = (f.AddMonths(-1) - FechaOtorgamiento).Days;
                if (dias < 0)
                {
                    dias = (f - FechaOtorgamiento).Days;
                }
                if (dias == 0) {
                    dias = 30;
                }
                return dias;
            }
        }

        private double TEA
        {
            get
            {
                return (Math.Pow((((double)this.TNA / 100) / this.FrecuenciaPago.CantidadCuotas) + 1, this.FrecuenciaPago.CantidadCuotas)-1)*100;
            }
        }
        private double TED {
            get
            {
                return (Math.Pow((1 + (double)this.TEA / 100),((double)1/360))-1) * 100;
            }
        }

        private double TEMa
        {
            get
            {
                return Math.Pow((1 + (double)this.TED / 100), DiasPeriodoDeGracia)-1;
            }
        }
        private double TEMa2
        {
            get
            {
                return Math.Pow((1 + (double)this.TED / 100), DiasPeriodoDeGracia2) - 1;
            }
        }

        public double Tasa
        {
            get
            {
                return ((double)this.TNA / this.FrecuenciaPago.CantidadCuotas)/100;
            }
        }

        public double Anualidad {
            get {
                return Capital * Tasa / (1 - Math.Pow(1 + Tasa, -CantCuotas));
            }
        }

        public double InteresGratificacion
        {
            get
            {
                if (SistemaAmortizacion.Codigo==1)
                {
                    if (PeriodoDeGracia.Codigo == 1)
                    {
                        return 0;
                    }
                    else if (PeriodoDeGracia.Codigo == 2)
                    {
                        if (PagarEnUnaCUota)
                        {
                            return Utilidades.Redondear.DosDecimales(TEMa * Capital);
                        }
                        else
                        {
                            return Utilidades.Redondear.DosDecimales(TEMa2 * Capital);
                        }
                    }
                    else if (PeriodoDeGracia.Codigo==3){
                        return Utilidades.Redondear.DosDecimales(TEMa2 * Capital);
                    }
                    
                }
                /*else {
                    return 0;
                }*/
                return 0;
                
            }
        }

        public bool PagarEnUnaCUota
        {
            get
            {
                return pagarEnUnaCUota;
            }

            set
            {
                pagarEnUnaCUota = value;
            }
        }

        public Asiento Asiento
        {
            get
            {
                return asiento;
            }

            set
            {
                asiento = value;
            }
        }

        public List<TablaAmortizacion> TablaAmortizacion
        {
            get
            {
                return tablaAmortizacion;
            }

            set
            {
                tablaAmortizacion = value;
            }
        }

        public int CodigoPrestamo
        {
            get
            {
                return codigoPrestamo;
            }

            set
            {
                codigoPrestamo = value;
            }
        }
    }
}
