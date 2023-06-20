using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Conciliacion
    {
        public Conciliacion() {
            Usuario = new Usuario();
            DebitoCreditos = new List<Transacciones>();
            Tranferencias = new List<Transacciones>();
            Impuestos = new List<FacturaImpuesto>();
            DepositoSucursalesEfectivos = new List<DepositoSucursalesEfectivo>();
            DepositoSucursalesCheques = new List<DepositoSucursalesCheques>();
        }
        public DateTime Fecha { get; set; }
        public DateTime FechaConciliacion { get; set; }
        public Entidades.Usuario Usuario { get; set; }
        public List<Entidades.Transacciones> DebitoCreditos { get; set; }
        public List<Entidades.Transacciones> Tranferencias { get; set; }
        public List<Entidades.DepositoSucursalesEfectivo> DepositoSucursalesEfectivos { get; set; }
        public List<Entidades.DepositoSucursalesCheques> DepositoSucursalesCheques { get; set; }
        public double Gastos { get; set; }
        public List<FacturaImpuesto> Impuestos { get; set; }
        public double IVA { get; set; }
    }
}
