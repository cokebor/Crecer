using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura:  DatosGenerales
    {
        public Factura() {
            tipoDocumentoCliente = new TipoDocumentoCliente();
            cliente = new Cliente();
            vendedor = new Empleado();
            usuario = new Usuario();
            puestoCaja = new PuestoCaja();
            cierreCaja = new CierreDeCaja();
            detalles = new List<Factura_Detalle>();
            facturaEfectivo = new List<Factura_Efectivo>();
            formasDePago = new List<FormaDePago>();
            // FacturaCheque = new List<Factura_Cheque>();
            cheques = new List<Cheque>();
            mermas = new List<Factura_Merma>();
            Impuestos = new List<FacturaImpuesto>();
            DescuentosEspecialesDetalle = new List<Factura_DescuentosEspecialesDetalle>();
            DescuentosEspeciales = new List<Factura_DescuentosEspeciales>();
            FechaVencimientoPago = Convert.ToDateTime("01/01/2000");
        }

        private TipoDocumentoCliente tipoDocumentoCliente;
        private char letra;
        private int puntoDeVenta;
        private int numero;
        private int codigoSucursal;
                
        private DateTime fecha;
        private Cliente cliente;
        private SucursalCliente sucursalCliente;
        private Empleado vendedor;
        private string nroRemito;
        private double neto105;
        private double iva105;
        private double neto21;
        private double iva21;
        private double netoNoGravado;
        private double comision;
        private double porcentajeComision;
        private double redondeo;
        private string cae;
        private DateTime fechaVenCae;
        private Usuario usuario;
        private PuestoCaja puestoCaja;
        private CierreDeCaja cierreCaja;
        private string codigoTipoDocumento;
        private string condicionVenta;
        private string tipoVenta;
        private bool facturaKilos;
        private List<Factura_Detalle> detalles;
        private List<Factura_DescuentosEspecialesDetalle> descuentosEspecialesDetalle;
        private List<Factura_DescuentosEspeciales> descuentosEspeciales;
        private List<Factura_Efectivo> facturaEfectivo;
        private List<FormaDePago> formasDePago;
        //private List<Factura_Cheque> facturaCheque;
        private List<Cheque> cheques;
        private List<Factura_Merma> mermas;
        private List<FacturaImpuesto> impuestos;
        private char imputacion;
        private char liquidacion;
        private string observaciones;
        private bool modificarNumerador;
        private int codigoTipoDocumentoAFIP;
        public DateTime FechaVencimientoPago { get; set; }

        public double PercepcionMunicipal { get; set; }
        public double AlicuotaMunicipal { get; set; }

        public TipoDocumentoCliente TipoDocumentoCliente
        {
            get
            {
                return tipoDocumentoCliente;
            }

            set
            {
                tipoDocumentoCliente = value;
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

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public Empleado Vendedor
        {
            get
            {
                return vendedor;
            }

            set
            {
                vendedor = value;
            }
        }

        public string NroRemito
        {
            get
            {
                return nroRemito;
            }

            set
            {
                nroRemito = value;
            }
        }

        public double Neto105
        {
            get
            {
                return neto105;
            }

            set
            {
                neto105 = value;
            }
        }

        public double Iva105
        {
            get
            {
                return iva105;
            }

            set
            {
                iva105 = value;
            }
        }

        public double Neto21
        {
            get
            {
                return neto21;
            }

            set
            {
                neto21 = value;
            }
        }

        public double Iva21
        {
            get
            {
                return iva21;
            }

            set
            {
                iva21 = value;
            }
        }

        public string Cae
        {
            get
            {
                return cae;
            }

            set
            {
                cae = value;
            }
        }

        public DateTime FechaVenCae
        {
            get
            {
                return fechaVenCae;
            }

            set
            {
                fechaVenCae = value;
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

        internal CierreDeCaja CierreZeta
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

        public List<Factura_Detalle> Detalles
        {
            get
            {
                return detalles;
            }

            set
            {
                detalles = value;
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

        public List<FormaDePago> FormasDePago
        {
            get
            {
                return formasDePago;
            }

            set
            {
                formasDePago = value;
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

        public string Numdoc {
            get {
                return Letra + "-" + PuntoDeVenta.ToString("0000") + "-" + Numero.ToString("00000000");
            }
        }

        public string NumdocSinLetra
        {
            get
            {
                return PuntoDeVenta.ToString("0000") + "-" + Numero.ToString("00000000");
            }
        }
        public double Neto {
            get{
                return Neto105 + Neto21;
            }
        }

        public double Iva
        {
            get
            {
                return Iva105 + Iva21;
            }
        }

        public double Total {
            get {
                return Utilidades.Redondear.DosDecimales(Neto + Iva + NetoNoGravado + PercepcionMunicipal);
            }
        }

        public int CodigoSucursal
        {
            get
            {
                return codigoSucursal;
            }

            set
            {
                codigoSucursal = value;
            }
        }

        public string CodigoTipoDocumento
        {
            get
            {
                if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumento = "Cod. 201";
                } else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME==false) {
                    codigoTipoDocumento = "Cod. 01";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumento = "Cod. 206";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME == false){
                    codigoTipoDocumento = "Cod. 06";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumento = "Cod. 203";
                }
                else if(TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME == false)
                {
                    codigoTipoDocumento = "Cod. 03";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumento = "Cod. 208";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME==false)
                {
                    codigoTipoDocumento = "Cod. 08";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumento = "Cod. 202";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME==false)
                {
                    codigoTipoDocumento = "Cod. 02";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumento = "Cod. 207";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME==false)
                {
                    codigoTipoDocumento = "Cod. 07";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('K'))
                {
                    codigoTipoDocumento = "";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('M') && TipoDocumentoCliente.MiPYME == false)
                {
                    codigoTipoDocumento = "Cod. 51";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('M') && TipoDocumentoCliente.MiPYME == false)
                {
                    codigoTipoDocumento = "Cod. 53";
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('M') && TipoDocumentoCliente.MiPYME == false)
                {
                    codigoTipoDocumento = "Cod. 52";
                }
                return codigoTipoDocumento;
            }
            
        }
        public int CodigoTipoDocumentoAFIP
        {
            get
            {
                if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumentoAFIP = 201;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME == false)
                {
                    codigoTipoDocumentoAFIP = 1;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumentoAFIP = 206;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME == false)
                {
                    codigoTipoDocumentoAFIP = 6;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumentoAFIP = 203;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME==false)
                {
                    codigoTipoDocumentoAFIP = 3;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumentoAFIP = 208;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME==false)
                {
                    codigoTipoDocumentoAFIP = 8;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumentoAFIP = 202;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('A') && TipoDocumentoCliente.MiPYME==false)
                {
                    codigoTipoDocumentoAFIP = 2;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME)
                {
                    codigoTipoDocumentoAFIP = 207;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('B') && TipoDocumentoCliente.MiPYME==false)
                {
                    codigoTipoDocumentoAFIP = 7;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('K'))
                {
                    codigoTipoDocumentoAFIP = 0;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA") && Letra.Equals('M') && TipoDocumentoCliente.MiPYME == false)
                {
                    codigoTipoDocumentoAFIP = 51;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC") && Letra.Equals('M') && TipoDocumentoCliente.MiPYME == false)
                {
                    codigoTipoDocumentoAFIP = 53;
                }
                else if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND") && Letra.Equals('M') && TipoDocumentoCliente.MiPYME == false)
                {
                    codigoTipoDocumentoAFIP = 52;
                }
                return codigoTipoDocumentoAFIP;
            }

        }

        public string CondicionVenta
        {
            get
            {
                if (TipoDocumentoCliente.AfectaCtaCte.Equals('N'))
                {
                    condicionVenta = "CONTADO";
                }else if (TipoDocumentoCliente.AfectaCtaCte.Equals('D') || TipoDocumentoCliente.AfectaCtaCte.Equals('C'))
                {
                    condicionVenta = "CUENTA CORRIENTE";
                }
                return condicionVenta;
            }
        }

        public string CondicionVentaComprobante
        {
            get
            {
                if (TipoDocumentoCliente.AfectaCtaCte.Equals('N'))
                {
                    condicionVenta = "Contado";
                }
                else if (TipoDocumentoCliente.AfectaCtaCte.Equals('D') || TipoDocumentoCliente.AfectaCtaCte.Equals('C'))
                {
                    condicionVenta = "Cta. Cte.";
                }
                return condicionVenta;
            }
        }

        public string TipoVenta
        {
            get
            {
                if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("FA"))
                {
                    if (TipoDocumentoCliente.MiPYME)
                        tipoVenta = "FACTURA DE CREDITO ELECTRONICA MiPyMes";
                    else
                        tipoVenta = "FACTURA";
                }
                if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("NC"))
                {
                    if (TipoDocumentoCliente.MiPYME)
                        tipoVenta = "NOTA DE CREDITO ELECTRONICA MiPyMes";
                    else
                        tipoVenta = "NOTA DE CREDITO";
                }
                if (TipoDocumentoCliente.TipoDoc.Codigo.Equals("ND"))
                {
                    if (TipoDocumentoCliente.MiPYME)
                        tipoVenta = "NOTA DE DEBITO ELECTRONICA MiPyMes";
                    else
                        tipoVenta = "NOTA DE DEBITO";
                }
                return tipoVenta;
            }
            
        }

        public bool FacturaKilos
        {
            get
            {
                return facturaKilos;
            }

            set
            {
                facturaKilos = value;
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

        public List<Factura_Merma> Mermas
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

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public double PorcentajeComision
        {
            get
            {
                return porcentajeComision;
            }

            set
            {
                porcentajeComision = value;
            }
        }

        public bool ModificarNumerador
        {
            get
            {
                return modificarNumerador;
            }

            set
            {
                modificarNumerador = value;
            }
        }

        public double NetoNoGravado
        {
            get
            {
                return netoNoGravado;
            }

            set
            {
                netoNoGravado = value;
            }
        }

        public List<Factura_DescuentosEspecialesDetalle> DescuentosEspecialesDetalle
        {
            get
            {
                return descuentosEspecialesDetalle;
            }

            set
            {
                descuentosEspecialesDetalle = value;
            }
        }

        public List<Factura_DescuentosEspeciales> DescuentosEspeciales
        {
            get
            {
                return descuentosEspeciales;
            }

            set
            {
                descuentosEspeciales = value;
            }
        }

        public SucursalCliente SucursalCliente
        {
            get
            {
                return sucursalCliente;
            }

            set
            {
                sucursalCliente = value;
            }
        }


        /*
public List<Factura_Cheque> FacturaCheque
{
get
{
return facturaCheque;
}

set
{
facturaCheque = value;
}
}*/
    }
}
