using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class CuentasCorrientesClientes
    {
        private int codigo;
        private string nombre;
        private double deuda;

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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public double Deuda
        {
            get
            {
                return deuda;
            }

            set
            {
                deuda = value;
            }
        }
    }
}
