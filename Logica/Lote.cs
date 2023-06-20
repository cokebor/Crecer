using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Lote
    {
        public Entidades.Lote ObtenerUno(int pLote) {
            try
            {
                return Datos.Lote.ObtenerUno(pLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Lote ObtenerUno(int pLote, int pCantidad)
        {
            try
            {
                return Datos.Lote.ObtenerUno(pLote, pCantidad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosPorProducto(Entidades.Producto pProducto)
        {
            try
            {
                return Datos.Lote.ObtenerTodosPorProducto(pProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerStockPorCanal(Entidades.Proveedor pProveedor, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote, Entidades.Canal pCanal)
        {
            try
            {
                return Datos.Lote.ObtenerStockPorCanal(pProveedor, pRubro, pProducto, pLote, pCanal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Lote ObtenerIngreso(int pLote)
        {
            try
            {
                return Datos.Lote.ObtenerIngreso(pLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
