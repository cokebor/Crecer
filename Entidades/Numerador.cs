using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numerador: DatosGenerales
    {
        public Numerador() {
        }

        public Numerador(int pCodigo, string pDescripcion, string letra, int puntoVenta, int Numero) : base(pCodigo) {
            this.Codigo = pCodigo;
            this.Descripcion = pDescripcion;
        }


        private string descripcion;
        private string letra;
        private int puntoVenta;
        private int numero;


        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = Utilidades.Convertir.PrimerLetraDeCadaPalabraAMayuscula(value.ToLower());
            }
        }

        public string Letra
        {
            get
            {
                return letra;
            }

            set
            {
                letra = value.ToUpper();
            }
        }
        
        public int PuntoVenta
        {
            get
            {
                return puntoVenta;
            }

            set
            {
                puntoVenta = value;
            }
        }
        
        public int Numero
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

        public string Valor {
            get {
                return Letra + "-" + PuntoVenta.ToString("0000") +"-" + Numero.ToString("00000000");
            }
        }

        public string ValorSinGuion
        {
            get
            {
                return Letra + PuntoVenta.ToString("0000") + Numero.ToString("00000000");
            }
        }

    }
}
