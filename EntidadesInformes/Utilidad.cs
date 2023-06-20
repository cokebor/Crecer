using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInformes
{
    public class Utilidad
    {
        private int codigoProveedor;
        private string proveedor;
        private int lote;
        private string numRemito;
        private int codigoRubroPructo;
        private string rubroProducto;
        private int codigoProducto;
        private string producto;
        private int cantIngresada;
        private int cantidadLiquidada;
        private int mermas;
        private int cantVendida;
        private double totalVentas;
        private double totalCostos;


        private double precioUnitario;
        private double precioUnitarioConMermas;
        private double costoUnitario;
        private double utilidadUnitariaSinMermas;
        private double utilidadUnitariaConMermas;
        private double utilidadSinMerma;
        private double utilidadConMerma;




        public int CodigoProveedor { get => codigoProveedor; set => codigoProveedor = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }
        public int Lote { get => lote; set => lote = value; }
        public string NumRemito { get => numRemito; set => numRemito = value; }
        public int CodigoRubroPructo { get => codigoRubroPructo; set => codigoRubroPructo = value; }
        public string RubroProducto { get => rubroProducto; set => rubroProducto = value; }
        public int CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public string Producto { get => producto; set => producto = value; }
        public int CantIngresada { get => cantIngresada; set => cantIngresada = value; }
        public int CantidadLiquidada { get => cantidadLiquidada; set => cantidadLiquidada = value; }
        public int Mermas { get => mermas; set => mermas = value; }
        public int CantVendida { get => cantVendida; set => cantVendida = value; }
        public double TotalVentas { get => totalVentas; set => totalVentas = value; }
        public double TotalCostos { get => totalCostos; set => totalCostos = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public double PrecioUnitarioConMermas { get => precioUnitarioConMermas; set => precioUnitarioConMermas = value; }
        public double CostoUnitario { get => costoUnitario; set => costoUnitario = value; }
        public double UtilidadUnitariaSinMermas { get => utilidadUnitariaSinMermas; set => utilidadUnitariaSinMermas = value; }
        public double UtilidadUnitariaConMermas { get => utilidadUnitariaConMermas; set => utilidadUnitariaConMermas = value; }
        public double UtilidadSinMerma { get => utilidadSinMerma; set => utilidadSinMerma = value; }
        public double UtilidadConMerma { get => utilidadConMerma; set => utilidadConMerma = value; }
    }
}
