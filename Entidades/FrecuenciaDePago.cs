using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FrecuenciaDePago
    {
        private int codigo;
        private string descripcion;
        private int diasParaEquivalencia;
       // private double valorParaCalculo;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public int DiasParaEquivalencia
        {
            get
            {
                return diasParaEquivalencia;
            }

            set
            {
                diasParaEquivalencia = value;
               // valorParaCalculo = (double)value / 360;
            }
        }
        /*
        public double ValorParaCalculo
        {
            get
            {
                return valorParaCalculo;
            }
        }*/
        public int CantidadCuotas {
            get
            {
                return 360/DiasParaEquivalencia;
            }
        } 
    }
}
