using System;


namespace Entidades
{
    public class CierreDeCaja
    {
        public CierreDeCaja()
        {
            usuario = new Usuario();
            puestoCaja = new PuestoCaja();
        }

        private int codigo;
        private DateTime fechaApertura;
        private DateTime fechaCierreCaja;
        private Usuario usuario;
        private PuestoCaja puestoCaja;

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

        public DateTime FechaApertura
        {
            get
            {
                return fechaApertura;
            }

            set
            {
                fechaApertura = value;
            }
        }

        public DateTime FechaCierreCaja
        {
            get
            {
                return fechaCierreCaja;
            }

            set
            {
                fechaCierreCaja = value;
            }
        }

        public Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public PuestoCaja PuestoCaja
        {
            get
            {
                return puestoCaja;
            }

            set
            {
                puestoCaja = value;
            }
        }
    }
}