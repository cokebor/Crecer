using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Utilidad
    {
        public DataTable Obtener(Entidades.Sucursal pSucursal, Entidades.Proveedor pProveedor, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Cliente pCliente, DateTime pFechaDesde, DateTime pFechaHasta)
        {
            try
            {
                return Datos.Utilidad.Obtener(pSucursal, pProveedor, pRubro, pProducto, pCliente, pFechaDesde, pFechaHasta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Obtener(Entidades.Proveedor pProveedor, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Cliente pCliente, DateTime pFechaDesde, DateTime pFechaHasta)
        {
            try
            {
                return Datos.Utilidad.Obtener(pProveedor, pRubro, pProducto, pCliente, pFechaDesde, pFechaHasta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
