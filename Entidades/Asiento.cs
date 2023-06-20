using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Asiento
    {
        public Asiento() {
            detalle = new List<Asiento_Detalle>();
        }

        private int codigo;
        private DateTime fecha;
        private DateTime fechaEmision;
        private string descripcion;
        private int sucursal;
        private List<Asiento_Detalle> detalle;
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

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
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

        public List<Asiento_Detalle> Detalle
        {
            get
            {
                return detalle;
            }

            set
            {
                detalle = value;
            }
        }

        public int Sucursal
        {
            get
            {
                return sucursal;
            }

            set
            {
                sucursal = value;
            }
        }

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
    }
}
