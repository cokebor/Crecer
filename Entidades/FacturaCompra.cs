using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaCompra
    {
        public FacturaCompra() {
            Sucursal = new Sucursal();
            TipoDocumentoProveedor = new TipoDocumentoProveedor();
            Proveedor = new Proveedor();
            Usuario = new Usuario();
            PuestoCaja = new PuestoCaja();
            CierreCaja = new CierreDeCaja();
            Asiento = new Asiento();
            Impuestos = new List<FacturaImpuesto>();
            facturaEfectivo = new List<Factura_Efectivo>();
            Cheques = new List<Cheque>();
            ChequesPropios = new List<Cheque>();
            detalle = new List<FacturaCompra_Detalle>();
            Remito = new RemitoProveedor_M();
            mermas = new List<FacturaCompra_Merma>();
            Tranferencias = new List<Tranferencia>();
        }

        private int codigo;
        private Sucursal sucursal;
        private TipoDocumentoProveedor tipoDocumentoProveedor;
        //private string numero;

        private char letra;
        private int puntoDeVenta;
        private int numero;

        private Proveedor proveedor;
        private DateTime fechaEmision;
        private DateTime fechaContable;
        private string tipoCompra;
        private double neto1;
        private double descripImp1;
        private double importeImp1;
        private double neto2;
        private double descripImp2;
        private double importeImp2;
        private double noGravado;
        private double exento;
        private Usuario usuario;
        private PuestoCaja puestoCaja;
        private CierreDeCaja cierreCaja;
        private Asiento asiento;
        private List<FacturaCompra_Detalle> detalle;
        private List<FacturaImpuesto> impuestos;
        private List<Factura_Efectivo> facturaEfectivo;
        private List<Cheque> cheques;
        private List<Cheque> chequesPropios;
        private RemitoProveedor_M remito;
        private List<FacturaCompra_Merma> mermas;
        private char imputacion;
        private double comision;
        private double redondeo;
        private char liquidacion;
        private string codigoTipoDocumento;
        private string condicionVenta;
        private string tipoVenta;
        private List<Tranferencia> tranferencias;

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

        public Sucursal Sucursal
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

        public TipoDocumentoProveedor TipoDocumentoProveedor
        {
            get
            {
                return tipoDocumentoProveedor;
            }

            set
            {
                tipoDocumentoProveedor = value;
            }
        }

        /*public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }*/

        
/*
        public string Letra {
            get {
                return Numero.Substring(0, 1);
            }
        }
        */

        public Proveedor Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
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

        public DateTime FechaContable
        {
            get
            {
                return fechaContable;
            }

            set
            {
                fechaContable = value;
            }
        }

        public string TipoCompra
        {
            get
            {
                return tipoCompra;
            }

            set
            {
                tipoCompra = value;
            }
        }

        public double Neto1
        {
            get
            {
                return neto1;
            }

            set
            {
                neto1 = value;
            }
        }

        public double DescripImp1
        {
            get
            {
                return descripImp1;
            }

            set
            {
                descripImp1 = value;
            }
        }

        public double ImporteImp1
        {
            get
            {
                return importeImp1;
            }

            set
            {
                importeImp1 = value;
            }
        }

        public double Neto2
        {
            get
            {
                return neto2;
            }

            set
            {
                neto2 = value;
            }
        }

        public double DescripImp2
        {
            get
            {
                return descripImp2;
            }

            set
            {
                descripImp2 = value;
            }
        }

        public double ImporteImp2
        {
            get
            {
                return importeImp2;
            }

            set
            {
                importeImp2 = value;
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

        internal CierreDeCaja CierreCaja
        {
            get
            {
                return cierreCaja;
            }

            set
            {
                cierreCaja = value;
            }
        }

        public Asiento Asiento
        {
            get
            {
                return asiento;
            }

            set
            {
                asiento = value;
            }
        }
        /*
        public string Numdoc
        {
            get
            {
                return Numero.Substring(0,1) + "-" + Numero.Substring(1, 4) + "-" + Numero.Substring(5, 8);
            }
        }*/
        
        public double Neto
        {
            get
            {
                return Neto1 + Neto2;
            }
        }

        public double Iva
        {
            get
            {
                return ImporteImp1 + ImporteImp2;
            }
        }

        public double NoGravado
        {
            get
            {
                return noGravado;
            }

            set
            {
                noGravado = value;
            }
        }

        public List<FacturaImpuesto> Impuestos
        {
            get
            {
                return impuestos;
            }

            set
            {
                impuestos = value;
            }
        }

        public List<Factura_Efectivo> FacturaEfectivo
        {
            get
            {
                return facturaEfectivo;
            }

            set
            {
                facturaEfectivo = value;
            }
        }

        public List<Cheque> Cheques
        {
            get
            {
                return cheques;
            }

            set
            {
                cheques = value;
            }
        }

        public List<Cheque> ChequesPropios
        {
            get
            {
                return chequesPropios;
            }

            set
            {
                chequesPropios = value;
            }
        }

        public List<FacturaCompra_Detalle> Detalle
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

        public RemitoProveedor_M Remito
        {
            get
            {
                return remito;
            }

            set
            {
                remito = value;
            }
        }

        public char Imputacion
        {
            get
            {
                return imputacion;
            }

            set
            {
                imputacion = value;
            }
        }

        public double Exento
        {
            get
            {
                return exento;
            }

            set
            {
                exento = value;
            }
        }

        public double Comision
        {
            get
            {
                return comision;
            }

            set
            {
                comision = value;
            }
        }

        public double Redondeo
        {
            get
            {
                return redondeo;
            }

            set
            {
                redondeo = value;
            }
        }

        public char Liquidacion
        {
            get
            {
                return liquidacion;
            }

            set
            {
                liquidacion = value;
            }
        }

        public List<FacturaCompra_Merma> Mermas
        {
            get
            {
                return mermas;
            }

            set
            {
                mermas = value;
            }
        }

        public string CodigoTipoDocumento
        {
            get
            {
                if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("FA") && Letra.Equals("A"))
                {
                    codigoTipoDocumento = "Cod. 01";
                }
                else if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("FA") && Letra.Equals("B"))
                {
                    codigoTipoDocumento = "Cod. 06";
                }
                else if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("FA") && Letra.Equals("M"))
                {
                    codigoTipoDocumento = "Cod. 51";
                }
                else if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && Letra.Equals("A"))
                {
                    codigoTipoDocumento = "Cod. 03";
                }
                else if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC") && Letra.Equals("B"))
                {
                    codigoTipoDocumento = "Cod. 08";
                }
                else if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("ND") && Letra.Equals("A"))
                {
                    codigoTipoDocumento = "Cod. 02";
                }
                else if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("ND") && Letra.Equals("B"))
                {
                    codigoTipoDocumento = "Cod. 07";
                }
                return codigoTipoDocumento;
            }

        }

        public string CondicionVenta
        {
            get
            {
                if (TipoDocumentoProveedor.AfectaCtaCte.Equals('N'))
                {
                    condicionVenta = "CONTADO";
                }
                else if (TipoDocumentoProveedor.AfectaCtaCte.Equals('D') || TipoDocumentoProveedor.AfectaCtaCte.Equals('C'))
                {
                    condicionVenta = "CUENTA CORRIENTE";
                }
                return condicionVenta;
            }
        }

        public string TipoVenta
        {
            get
            {
                switch (TipoDocumentoProveedor.TipoDoc.Codigo)
                {
                    case "FA":
                        tipoVenta = "FACTURA";
                        break;
                    case "NC":
                        tipoVenta = "NOTA DE CREDITO";
                        break;
                    case "ND":
                        tipoVenta = "NOTA DE DEBITO";
                        break;
                    case "FL":
                        tipoVenta = "FLETE";
                        break;
                    case "CO":
                        tipoVenta = "COMISION";
                        break;
                    case "OT":
                        tipoVenta = "OTROS";
                        break;
                }
                /*if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("FA"))
                {
                    tipoVenta = "FACTURA";
                }
                if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("NC"))
                {
                    tipoVenta = "NOTA DE CREDITO";
                }
                if (TipoDocumentoProveedor.TipoDoc.Codigo.Equals("ND"))
                {
                    tipoVenta = "NOTA DE DEBITO";
                }*/
                return tipoVenta;
            }

        }

        public List<Tranferencia> Tranferencias
        {
            get
            {
                return tranferencias;
            }

            set
            {
                tranferencias = value;
            }
        }

        public char Letra
        {
            get
            {
                return letra;
            }

            set
            {
                letra = value;
            }
        }

        public int PuntoDeVenta
        {
            get
            {
                return puntoDeVenta;
            }

            set
            {
                puntoDeVenta = value;
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
        public string Numdoc
        {
            get
            {
                return Letra + "-" + PuntoDeVenta.ToString("0000") + "-" + Numero.ToString("00000000");
            }
        }
    }
}
