using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Presentacion
{
    public static class FacturaElectronica
    {
        public static int ObtenerNumeroFactura(Entidades.Factura pFactura, WSAFIPFE.Factura fa)
        {
            int tipoDocumento=0;
            tipoDocumento = pFactura.CodigoTipoDocumentoAFIP;
            /*
            switch (pFactura.TipoDocumentoCliente.TipoDoc.Codigo)
            {
                case "FA":
                    //if (pFactura.TipoDocumentoCliente.Codigo == 2 || pFactura.TipoDocumentoCliente.Codigo == 3)
                    if(pFactura.Letra.Equals('A') && pFactura.TipoDocumentoCliente.MiPYME)
                    {
                        tipoDocumento = 201;
                    }
                    else if (pFactura.Letra.Equals('A') && pFactura.TipoDocumentoCliente.MiPYME==false)
                    {
                        tipoDocumento = 1;
                    }
                    else if (pFactura.Letra.Equals('B') && pFactura.TipoDocumentoCliente.MiPYME)
                    {
                        tipoDocumento = 206;
                    }
                    else if (pFactura.Letra.Equals('B') && pFactura.TipoDocumentoCliente.MiPYME == false)
                    {
                        tipoDocumento = 6;
                    }
                    break;
                case "NC":
                    //if (pFactura.TipoDocumentoCliente.Codigo == 2 || pFactura.TipoDocumentoCliente.Codigo == 3)
                    if (pFactura.Letra.Equals('A'))
                    {
                        tipoDocumento = 3;
                    }
                    else if (pFactura.Letra.Equals('B'))//if (pFactura.TipoDocumentoCliente.Codigo == 4 || pFactura.TipoDocumentoCliente.Codigo == 5)
                    {
                        tipoDocumento = 8;
                    }
                    break;
                case "ND":
                    //if (pFactura.TipoDocumentoCliente.Codigo == 2 || pFactura.TipoDocumentoCliente.Codigo == 3)
                    if (pFactura.Letra.Equals('A'))
                    {
                        tipoDocumento = 2;
                    }
                    else if (pFactura.Letra.Equals('B'))//if (pFactura.TipoDocumentoCliente.Codigo == 4 || pFactura.TipoDocumentoCliente.Codigo == 5)
                    {
                        tipoDocumento = 7;
                    }
                    break;
            }*/
            int comprobante = fa.F1CompUltimoAutorizado(pFactura.PuntoDeVenta,  tipoDocumento);

            return ++comprobante;
        }

        public static Entidades.Factura FacturaElectronicaPedido(Entidades.Factura pFactura, WSAFIPFE.Factura fe, Entidades.Factura pFacturaOriginal=null, bool pRechazadaFactura=false) {
            fe.F1CabeceraCbteTipo = pFactura.CodigoTipoDocumentoAFIP;
            

            fe.F1CabeceraCantReg = 1;
            fe.F1CabeceraPtoVta = pFactura.PuntoDeVenta;

            fe.f1Indice = 0;
            fe.F1DetalleConcepto = 1;

            fe.F1DetalleDocTipo = pFactura.Cliente.TipoDocumento.Codigo;

            switch (pFactura.Cliente.TipoDocumento.Codigo)
            {
                case 99:
                    fe.F1DetalleDocNro = "0";
                    break;
                case 96:
                    fe.F1DetalleDocNro = pFactura.Cliente.DNI;
                    break;
                default:
                    fe.F1DetalleDocNro=pFactura.Cliente.CUITSinGuion;
                    break;
            }


            /*
            if (pFactura.Cliente.TipoInscripcion.Sigla.Equals("CF")) {
                fe.F1DetalleDocTipo = 99;//86;
                fe.F1DetalleDocNro = pFactura.Cliente.DNI;
            }
            else { 
            fe.F1DetalleDocTipo = 80;
                fe.F1DetalleDocNro = pFactura.Cliente.CUITSinGuion;
            }*/

            
            fe.F1DetalleCbteDesde = pFactura.Numero;
            fe.F1DetalleCbteHasta = pFactura.Numero;
            fe.F1DetalleCbteFch = pFactura.Fecha.ToString("yyyyMMdd");
            if (pFactura.TipoDocumentoCliente.MiPYME)
            {


                fe.F1DetalleOpcionalItemCantidad = 1;
                //este agregue

                if ((pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "NC" || pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "ND") && pFactura.TipoDocumentoCliente.MiPYME)
                {
                    fe.F1DetalleCbtesAsocItemCantidad = 1;
                    fe.F1DetalleCbtesAsocTipo = pFacturaOriginal.CodigoTipoDocumentoAFIP;
                    fe.F1DetalleCbtesAsocPtoVta = pFacturaOriginal.PuntoDeVenta;
                    fe.F1DetalleCbtesAsocNro = pFacturaOriginal.Numero;
                    fe.F1DetalleCbtesAsocCUIT = Singleton.Instancia.Empresa.CUITSinGuion;
                    fe.F1DetalleCbtesAsocFecha = pFacturaOriginal.Fecha.ToString("yyyyMMdd");
                }

                if (pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "FA" /*|| pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "ND"*/)
                {

                    fe.f1IndiceItem = 0;
                    fe.F1DetalleOpcionalId = "2101";
                    fe.F1DetalleOpcionalValor = Singleton.Instancia.Empresa.CBUFacturasDeCredito;
                    //if (pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "FA")
                    fe.F1DetalleFchVtoPago = pFactura.FechaVencimientoPago.ToString("yyyyMMdd");
                }
                else if ((pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "NC" || pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "ND"))
                {
                    fe.f1IndiceItem = 0;
                    fe.F1DetalleOpcionalId = "22";
                    if (pRechazadaFactura)
                    {
                        fe.F1DetalleOpcionalValor = "S";//S
                    }
                    else
                    {
                        fe.F1DetalleOpcionalValor = "N";//S
                    }

                }


            } else if ((pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "NC" || pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "ND") && pFactura.TipoDocumentoCliente.MiPYME == false && pFacturaOriginal!=null)
                {
                fe.F1DetalleCbtesAsocItemCantidad = 1;
                fe.F1DetalleCbtesAsocTipo = pFacturaOriginal.CodigoTipoDocumentoAFIP;
                fe.F1DetalleCbtesAsocPtoVta = pFacturaOriginal.PuntoDeVenta;
                fe.F1DetalleCbtesAsocNro = pFacturaOriginal.Numero;
                fe.F1DetalleCbtesAsocCUIT = Singleton.Instancia.Empresa.CUITSinGuion;
                fe.F1DetalleCbtesAsocFecha = pFacturaOriginal.Fecha.ToString("yyyyMMdd");
            }/*
            else {
                if ((pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "NC" || pFactura.TipoDocumentoCliente.TipoDoc.Codigo == "ND") && pFactura.TipoDocumentoCliente.MiPYME==false)
                {
                    fe.F1DetalleCbtesAsocItemCantidad = 1;
                    fe.F1DetalleCbtesAsocTipo = pFacturaOriginal.CodigoTipoDocumentoAFIP;
                    fe.F1DetalleCbtesAsocPtoVta = pFacturaOriginal.PuntoDeVenta;
                    fe.F1DetalleCbtesAsocNro = pFacturaOriginal.Numero;
                    fe.F1DetalleCbtesAsocCUIT = Singleton.Instancia.Empresa.CUITSinGuion;
                    fe.F1DetalleCbtesAsocFecha = pFacturaOriginal.Fecha.ToString("yyyyMMdd");
                }
            }*/
            fe.F1DetalleImpTotal = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Total));
            fe.F1DetalleImpTotalConc = pFactura.NetoNoGravado;

            fe.F1DetalleImpNeto = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Neto));

            fe.F1DetalleImpOpEx = 0;
            

            fe.F1DetalleImpIva = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Iva));

            fe.F1DetalleMonId = "PES";
            fe.F1DetalleMonCotiz = 1;

            int cont = 0;
            if (Math.Abs(pFactura.Neto105) != 0) {
                cont++;
            }
            if (Math.Abs(pFactura.Neto21) != 0)
            {
                cont++;
            }

            fe.F1DetalleIvaItemCantidad = cont;

            if (cont == 1)
            {
                if (Math.Abs(pFactura.Neto105) != 0)
                {
                    fe.F1DetalleIvaId = 4;
                    fe.F1DetalleIvaBaseImp = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Neto105));
                    fe.F1DetalleIvaImporte = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Iva105));
                }
                else
                {
                    if (Math.Abs(pFactura.Neto21) != 0)
                    {
                        fe.F1DetalleIvaId = 5;
                        fe.F1DetalleIvaBaseImp = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Neto21));
                        fe.F1DetalleIvaImporte = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Iva21));
                    }
                }
            }
            else if(cont==2){
                fe.f1IndiceItem = 0;
                fe.F1DetalleIvaId = 4;
                fe.F1DetalleIvaBaseImp = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Neto105));
                fe.F1DetalleIvaImporte = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Iva105));

                fe.f1IndiceItem = 1;
                fe.F1DetalleIvaId = 5;
                fe.F1DetalleIvaBaseImp = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Neto21));
                fe.F1DetalleIvaImporte = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Iva21));
                
            }

            fe.F1DetalleImpTrib = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.PercepcionMunicipal));

            if (pFactura.PercepcionMunicipal != 0) {
                fe.F1DetalleTributoItemCantidad = 1;
                fe.f1IndiceItem = 0;
                fe.F1DetalleTributoId =3;
                fe.F1DetalleTributoDesc ="Percepcion Municipal Cordoba";
                fe.F1DetalleTributoBaseImp = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.Neto));
                fe.F1DetalleTributoAlic = Utilidades.Redondear.DosDecimales(pFactura.Cliente.TipoContribuyente.PorcentajePercepcion);
                fe.F1DetalleTributoImporte = Utilidades.Redondear.DosDecimales(Math.Abs(pFactura.PercepcionMunicipal));
            }           

            Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + @"\XML\Recibido");
            fe.ArchivoXMLRecibido = System.Windows.Forms.Application.StartupPath + @"\XML\Recibido\(" + pFactura.TipoDocumentoCliente.TipoDoc.Codigo +") " + pFactura.Numdoc + ".xml";

            Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + @"\XML\Enviado");
            fe.ArchivoXMLEnviado = System.Windows.Forms.Application.StartupPath + @"\XML\Enviado\(" + pFactura.TipoDocumentoCliente.TipoDoc.Codigo + ") " + pFactura.Numdoc + ".xml";

            return pFactura;
        }


        public static string ToI2of5(string codigo)
        {
            int sumaImpar = 0, sumaPar = 0, mult = 0, suma = 0;
            for (int i = 0; i < codigo.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sumaImpar += (int)Char.GetNumericValue(codigo[i]);
                }
                else
                {
                    sumaPar += (int)Char.GetNumericValue(codigo[i]);
                }
            }
            mult = sumaImpar * 3;
            suma = mult + sumaPar;

            int res = 0;
            for (int i = 0; i < 10; i++)
            {
                res = suma + i;
                if (res % 10 == 0)
                {
                    codigo = codigo + i;
                }
            }
            return codigo;
        }

    }
}
