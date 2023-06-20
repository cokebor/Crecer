using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeraciones
{
    public static class Enumeraciones
    {
        public enum Estados
        {
            Activo = 1,
            Inactivo = 0
        }

        public enum Sexos {
            Masculino = 'M',
            Femenino = 'F'
        }

        public enum TiposDeDocumentos {
            DNI=1
        }

        public enum EstadosCiviles {
            Casado=1,
            Soltero=2,
            Viudo=3,
            Divorciado=4
        }
        public static List<Estados> ListarEstados()
        {
            List<Estados> lista = Enum.GetValues(typeof(Estados)).Cast<Estados>().ToList();
            lista.Sort((p, q) => string.Compare(p.ToString(), q.ToString()));
            return lista;
        }

        public static List<Sexos> ListarSexos() {
            List<Sexos> lista = Enum.GetValues(typeof(Sexos)).Cast<Sexos>().ToList();
            lista.Sort((p, q) => string.Compare(p.ToString(), q.ToString()));
            return lista;
        }
        public static List<TiposDeDocumentos> ListarTiposDeDocumentos()
        {
            List<TiposDeDocumentos> lista = Enum.GetValues(typeof(TiposDeDocumentos)).Cast<TiposDeDocumentos>().ToList();
            lista.Sort((p, q) => string.Compare(p.ToString(), q.ToString()));
            return lista;
        }
        public static List<EstadosCiviles> ListarEstadosCiviles()
        {
            List<EstadosCiviles> lista = Enum.GetValues(typeof(EstadosCiviles)).Cast<EstadosCiviles>().ToList();
            lista.Sort((p, q) => string.Compare(p.ToString(), q.ToString()));
            return lista;
        }
    }
}
