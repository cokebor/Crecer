using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class Empleados
    {
        public int Codigo { get; set; }
        public string Legajo { get; set; }
        public string NombreCompleto { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public string CodigoPostal { get; set; }
        public string Localidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string CUIL { get; set; }
        public string Puesto { get; set; }
        public string ObraSocial { get; set; }
    }
}
