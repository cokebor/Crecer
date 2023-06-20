using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impresion
{

    public class Comprobantes
    {
        public Font LetraGrande { get; set; }
        public Font LetraChica { get; set; }

        public float Distancia { get; set; }
        public float TamCod { get; set; }
        public float TamProd { get; set; }
        public float TamCant { get; set; }
        public float TamPrec { get; set; }
        public float TamTotal { get; set; }
        public int Altura { get; set; }





        private string frase = "DOCUMENTO NO VALIDO COMO FACTURA";
        public void Imprimir(string pImpresora, bool pTermica, Entidades.Factura pFactura, Entidades.Empresa pEmpresa)
        {

            objComprobante = pFactura;
            objEmpresa = pEmpresa;
            System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Margins margins = new Margins(0, 0, 0, 0);
            printDocument1.DefaultPageSettings.Margins = margins;
            //ps.PrinterName = "Microsoft Print to PDF";
            ps.PrinterName = pImpresora;
            if (pTermica == true)
            {
                LetraGrande = new Font("Arial", (float)12, FontStyle.Regular, GraphicsUnit.Point);
                LetraChica = new Font("Arial", (float)8, FontStyle.Regular, GraphicsUnit.Point);
                Altura = 15;
                Distancia = (float)3.85;
                TamCod = (float)(30);
                TamProd = (float)(95);
                TamCant = (float)(34.65);
                TamPrec = (float)(50.05);
                TamTotal = (float)(57.75);
            }
            else
            {
                LetraGrande = new Font("Arial", (float)11.3, FontStyle.Regular, GraphicsUnit.Point);
                LetraChica = new Font("Arial", (float)7.3, FontStyle.Regular, GraphicsUnit.Point);
                Altura = 14;
                /*if (objEmpresa.Codigo == 4)
                {
                    Distancia = (float)30;
                    TamProd = (float)(82);
                }
                else {*/
                    Distancia = (float)0;
                    TamProd = (float)(92);
                //}
                
                TamCod = (float)(24.3);
                TamCant = (float)(28);
                TamPrec = (float)(50.05);
                TamTotal = (float)(57.75);
            }

            printDocument1.PrinterSettings = ps;
            // PaperSource pss = ps.PaperSources[0];
            // printDocument1.DefaultPageSettings.PaperSource = pss;


           /* printDocument1.PrintPage += ComprobanteConPrecio;
            printDocument1.Print();
            printDocument1.PrintPage -= ComprobanteConPrecio;
            printDocument1.PrintPage += ComprobanteSinPrecio;
            printDocument1.Print();
           */
            printDocument1.PrintPage += ComprobanteSinPrecio;
            printDocument1.Print();
            printDocument1.PrintPage -= ComprobanteSinPrecio;

            if (pTermica == true)
            {
                LetraGrande = new Font("Arial", (float)12, FontStyle.Regular, GraphicsUnit.Point);
                LetraChica = new Font("Arial", (float)8, FontStyle.Regular, GraphicsUnit.Point);
                Altura = 15;
                Distancia = (float)3.85;
                TamCod = (float)(30);
                TamProd = (float)(95);
                TamCant = (float)(34.65);
                TamPrec = (float)(50.05);
                TamTotal = (float)(57.75);
            }
            else
            {
                LetraGrande = new Font("Arial", (float)11.3, FontStyle.Regular, GraphicsUnit.Point);
                LetraChica = new Font("Arial", (float)7.3, FontStyle.Regular, GraphicsUnit.Point);
                Altura = 14;
               /* if (objEmpresa.Codigo == 4)
                {
                    Distancia = (float)30;
                    TamProd = (float)(82);
                }
                else
                {*/
                    Distancia = (float)0;
                    TamProd = (float)(92);
                //}
                TamCod = (float)(24.3);
                TamCant = (float)(28);
                TamPrec = (float)(50.05);
                TamTotal = (float)(57.75);
            }
            printDocument1.PrintPage += ComprobanteConPrecio;
            printDocument1.Print();
        }



        private void ComprobanteConPrecio(object sender, PrintPageEventArgs e)
        {
            //int width = 287;

            int width = (int)(TamCod + Distancia + TamProd + Distancia + TamCant + Distancia + TamPrec + Distancia + TamTotal);
            int y = 0;
            StringFormat sf = new StringFormat(StringFormatFlags.NoClip);
            sf.Alignment = StringAlignment.Far;
            StringFormat sf2 = new StringFormat(StringFormatFlags.NoClip);
            sf2.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(frase, LetraGrande, Brushes.Black, new RectangleF(0, y += 40, width, 40), sf2);
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString(objEmpresa.NombreSucursal, LetraGrande, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("Vendedor: " + objComprobante.Vendedor.Codigo.ToString() + '-' + objComprobante.Vendedor.NombreCompleto, LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("Fecha.: " + objComprobante.Fecha.ToString("G"), LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("Nro. Comp.: " + objComprobante.Numdoc + " " + objComprobante.CondicionVentaComprobante, LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("Cliente: " + objComprobante.Cliente.Nombre, LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));

            //e.Graphics.DrawString("Cód.", LetraChica, Brushes.Black, new RectangleF(0, y += 17, (float)30.8, 15));
            //e.Graphics.DrawString("Producto", LetraChica, Brushes.Black, new RectangleF((float)34.65, y, (float)107.8, 15));
            //e.Graphics.DrawString("Cant.", LetraChica, Brushes.Black, new RectangleF((float)146.3, y, (float)34.65, 15), sf);
            //e.Graphics.DrawString("Precio", LetraChica, Brushes.Black, new RectangleF((float)184.8, y, (float)50.05, 15), sf);
            //e.Graphics.DrawString("Total", LetraChica, Brushes.Black, new RectangleF((float)238.7, y, (float)57.75, 15), sf);

            float comienzo = 0f;

            e.Graphics.DrawString("Cód.", LetraChica, Brushes.Black, new RectangleF(comienzo, y += (Altura + 2), (float)TamCod, Altura));
            comienzo += (float)(Math.Round(TamCod + Distancia, 2));
            e.Graphics.DrawString("Producto", LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamProd, Altura));
            comienzo += (float)(Math.Round(TamProd + Distancia, 2));
            e.Graphics.DrawString("Cant.", LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamCant, Altura), sf);
            comienzo += (float)(Math.Round(TamCant + Distancia, 2));
            e.Graphics.DrawString("Precio", LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamPrec, Altura), sf);
            comienzo += (float)(Math.Round(TamPrec + Distancia, 2));
            e.Graphics.DrawString("Total", LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamTotal, Altura), sf);

            foreach (Entidades.Factura_Detalle item in objComprobante.Detalles)
            {
                comienzo = 0f;

                y += Altura;
                e.Graphics.DrawString(item.Producto.Codigo.ToString(), LetraChica, Brushes.Black, new RectangleF(comienzo, y, (float)TamCod, Altura));
                comienzo += (float)(Math.Round(TamCod + Distancia, 2));
                e.Graphics.DrawString(item.Producto.Descripcion.ToString(), LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamProd, Altura));
                comienzo += (float)(Math.Round(TamProd + Distancia, 2));
                e.Graphics.DrawString(item.MovStock_Lotes.Cantidad.ToString("N0"), LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamCant, Altura), sf);
                comienzo += (float)(Math.Round(TamCant + Distancia, 2));

                if (objComprobante.FacturaKilos)
                    e.Graphics.DrawString(((item.PrecioUnitario * item.Kilos) / item.MovStock_Lotes.Cantidad).ToString("N2"), LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamPrec, Altura), sf);
                else
                    e.Graphics.DrawString(item.PrecioUnitario.ToString("N2"), LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamPrec, Altura), sf);

                comienzo += (float)(Math.Round(TamPrec + Distancia, 2));
                if (objComprobante.FacturaKilos)
                    e.Graphics.DrawString((item.PrecioUnitario * item.Kilos).ToString("N2"), LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamTotal, Altura), sf);
                else
                    e.Graphics.DrawString(item.SubTotal().ToString("N2"), LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamTotal, Altura), sf);
            }
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("TOTAL:   " + objComprobante.Total.ToString("C2"), LetraChica, Brushes.Black, new RectangleF((float)0, y += Altura, (float)(TamCod + Distancia + TamProd + Distancia + TamCant + Distancia + TamPrec + Distancia + TamTotal), Altura), sf);
            //e.Graphics.DrawString(objComprobante.Total.ToString("C2"), LetraChica, Brushes.Black, new RectangleF((float)200, y, (float)80.85, 15), sf);
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += (Altura + 2), width, Altura + 2));
            e.Graphics.DrawString(frase, LetraGrande, Brushes.Black, new RectangleF(0, y += 40, width, 40), sf2);
        }

        private void ComprobanteSinPrecio(object sender, PrintPageEventArgs e)
        {
            //int width = 287;
            int width = (int)(TamCod + Distancia + TamProd + Distancia + TamCant + Distancia +  TamPrec + Distancia + TamTotal);

            TamCod += 5.7f;
            TamProd += 23;
            TamCant += 6.65f;
            Distancia = 3.65f;
            LetraGrande = new Font("Arial", (float)12, FontStyle.Regular, GraphicsUnit.Point);
            LetraChica = new Font("Arial", (float)8, FontStyle.Regular, GraphicsUnit.Point);


            int y = 0;
            StringFormat sf = new StringFormat(StringFormatFlags.NoClip);
            sf.Alignment = StringAlignment.Far;
            StringFormat sf2 = new StringFormat(StringFormatFlags.NoClip);
            sf2.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(frase, LetraGrande, Brushes.Black, new RectangleF(0, y += 40, width, 40), sf2);
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString(objEmpresa.NombreSucursal, LetraGrande, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("Vendedor: " + objComprobante.Vendedor.Codigo.ToString() + '-' + objComprobante.Vendedor.NombreCompleto, LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("Fecha.: " + objComprobante.Fecha.ToString("G"), LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("Nro. Comp.: " + objComprobante.Numdoc + " " + objComprobante.CondicionVentaComprobante, LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("Cliente: " + objComprobante.Cliente.Nombre, LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += Altura, width, Altura));

            //e.Graphics.DrawString("Cód.", LetraChica, Brushes.Black, new RectangleF(0, y += 17, (float)30.8, 15));
            //e.Graphics.DrawString("Producto", LetraChica, Brushes.Black, new RectangleF((float)34.65, y, (float)107.8, 15));
            //e.Graphics.DrawString("Cant.", LetraChica, Brushes.Black, new RectangleF((float)146.3, y, (float)34.65, 15), sf);
            //e.Graphics.DrawString("Precio", LetraChica, Brushes.Black, new RectangleF((float)184.8, y, (float)50.05, 15), sf);
            //e.Graphics.DrawString("Total", LetraChica, Brushes.Black, new RectangleF((float)238.7, y, (float)57.75, 15), sf);
            float comienzo = 0f;

            e.Graphics.DrawString("Cód.", LetraChica, Brushes.Black, new RectangleF(comienzo, y += (Altura + 2), (float)TamCod, Altura));
            comienzo += (float)(Math.Round(TamCod + Distancia, 2));
            e.Graphics.DrawString("Producto", LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamProd, Altura));
            comienzo += (float)(Math.Round(TamProd + Distancia, 2));
            e.Graphics.DrawString("Cant.", LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamCant, Altura), sf);
            comienzo += (float)(Math.Round(TamCant + Distancia, 2));

            foreach (Entidades.Factura_Detalle item in objComprobante.Detalles)
            {
                comienzo = 0f;

                y += Altura;
                e.Graphics.DrawString(item.Producto.Codigo.ToString(), LetraChica, Brushes.Black, new RectangleF(comienzo, y, (float)TamCod, Altura));
                comienzo += (float)(Math.Round(TamCod + Distancia, 2));
                e.Graphics.DrawString(item.Producto.Descripcion.ToString(), LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamProd, Altura));
                comienzo += (float)(Math.Round(TamProd + Distancia, 2));
                e.Graphics.DrawString(item.MovStock_Lotes.Cantidad.ToString("N0"), LetraChica, Brushes.Black, new RectangleF((float)comienzo, y, (float)TamCant, Altura), sf);
                comienzo += (float)(Math.Round(TamCant + Distancia, 2));
            }
            //e.Graphics.DrawString(objComprobante.Total.ToString("C2"), LetraChica, Brushes.Black, new RectangleF((float)200, y, (float)80.85, 15), sf);
            e.Graphics.DrawString("", LetraChica, Brushes.Black, new RectangleF(0, y += (Altura + 2), width, Altura + 2));
            e.Graphics.DrawString(frase, LetraGrande, Brushes.Black, new RectangleF(0, y += 40, width, 40), sf2);
        }


        private Entidades.Empresa objEmpresa { get; set; }
        private Entidades.Factura objComprobante { get; set; }

    }

}
