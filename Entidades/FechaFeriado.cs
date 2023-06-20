using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FechaFeriado
    {
        public FechaFeriado() {
            Sucursal = new Sucursal();
            Usuario = new Usuario();
        }
        public DateTime Fecha { get; set; }
        public Sucursal Sucursal { get; set; }
        public bool PagoDiaExtra { get; set; }
        public Usuario Usuario { get; set; }
    }
}
