using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guias
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Ingrese Ultimos digitos del Remito a Sucursal: ");
                Int64 numRemito = Convert.ToInt64(Console.ReadLine());
                string num = "S0001" + numRemito.ToString("D8");

                Logica.RemitoSucursal rs = new Logica.RemitoSucursal();
                int codigoRemito = rs.ObtenerCodigoRemito(num);

                DataTable dtRemito = rs.ObtenerDataTable(codigoRemito);

                Console.Clear();

                if (dtRemito.Rows.Count > 0)
                {
                    foreach (DataRow remito in dtRemito.Rows)
                    {
                        Console.Write("Fecha: " + remito["Fecha"]);
                        Console.Write(" Destino: " + remito["SucursalDestino"]);
                        Console.Write(" Numero Remito: " + remito["NumRemito"]);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Detalle");

                    int ren=0;

                    foreach (DataRow item in rs.ObtenerDataTableDetalle(codigoRemito).Rows)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Renglon: " + item["Renglon"]);
                        Console.Write("Producto: (" + item["CodigoProducto"] + ") " + item["Producto"]);

                        Console.Write(" Lote: " + item["IdLote"]);
                        Console.WriteLine(" Cantidad: " + item["Cantidad"]);
                        ren = Convert.ToInt32(item["Renglon"]);
                    }

                    Console.WriteLine("");
                    Console.Write("Ingrese desde que renglon Eliminar: ");
                    int renglon = Convert.ToInt32(Console.ReadLine());

                    rs.Eliminar(codigoRemito, renglon);

                    if(ren>renglon)
                        Console.WriteLine("Items del Remito eliminados exitosamente");
                    else
                        Console.WriteLine("Ingrese valor correcto de Renglon");
                }
                else {
                    Console.WriteLine("El Remito Ingresado no se encuentra en la Base de Datos");
                }


                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
