using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class ChequesMovimientos
    {
        private string sucursal;
        private int codigoSucursal;
        private DateTime fecha;
        private string tipo;
        private string tipoDocumento;
        private string numero;
        private string tipoEstadoValor;
        private string movimiento;
        private string operador;
        private int codigoChequeSucursal;
        private int codigoChequeDeposito;
        private bool estado;

        public string Sucursal { get => sucursal; set => sucursal = value; }
        public int CodigoSucursal { get => codigoSucursal; set => codigoSucursal = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string Numero { get => numero; set => numero = value; }
        public string TipoEstadoValor { get => tipoEstadoValor; set => tipoEstadoValor = value; }
        public string Movimiento { get => movimiento; set => movimiento = value; }
        public string Operador { get => operador; set => operador = value; }
        public int CodigoChequeSucursal { get => codigoChequeSucursal; set => codigoChequeSucursal = value; }
        public int CodigoChequeDeposito { get => codigoChequeDeposito; set => codigoChequeDeposito = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
