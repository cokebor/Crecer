using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class RemitoProveedor
    {
        public int Agregar(Entidades.RemitoProveedor_M pRemito)
        {
            try
            {
                return Datos.RemitoProveedor.Agregar(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodos(Entidades.Proveedor pProveedor, bool ultimos6meses)
        {
            try
            {
                return Datos.RemitoProveedor.ObtenerTodos(pProveedor, ultimos6meses);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerCompraDirecta(Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.RemitoProveedor.ObtenerCompraDirecta(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerConsignacion(Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.RemitoProveedor.ObtenerConsignacion(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Obtener(int pCodigoRemito)
        {
            try
            {
                return Datos.RemitoProveedor.Obtener(pCodigoRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDetalle(int pCodigoRemito)
        {
            try
            {
                return Datos.RemitoProveedor_D_Productos.ObtenerDetalle(pCodigoRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodosDataTable(DateTime desde, DateTime hasta, Entidades.Proveedor pProveedor, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote, Entidades.Canal pCanal)
        {
            try
            {
                return Datos.RemitoProveedor.ObtenerTodosDataTable(desde,hasta,pProveedor,pRubro,pProducto,pLote, pCanal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerRemitosSinFacturas(Entidades.Proveedor objEntidadProveedor)
        {
            try
            {
                return Datos.RemitoProveedor.ObtenerRemitosSinFacturas(objEntidadProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.RemitoProveedor_M ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.RemitoProveedor.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.RemitoProveedor_M ObtenerUnoParaFacturar(int pCodigo)
        {
            try
            {
                return Datos.RemitoProveedor.ObtenerUnoParaFacturar(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Entidades.RemitoProveedor_M pRemito) {
            try
            {
                Datos.RemitoProveedor.Eliminar(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExisteFactura(Entidades.RemitoProveedor_M pRemito) {
            try
            {
                return Datos.RemitoProveedor.ExisteFactura(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExisteLiquidacion(Entidades.RemitoProveedor_M pRemito)
        {
            try
            {
                return Datos.RemitoProveedor.ExisteLiquidacion(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosSinLiquidar(Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.RemitoProveedor.ObtenerTodosSinLiquidar(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.RemitoProveedor_M ObtenerUnoParaLiquidar(int pCodigo, Entidades.Empresa pEmpresa)
        {
            try
            {

                    return Datos.RemitoProveedor.ObtenerUnoParaLiquidar(pCodigo, pEmpresa);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double ObtenerPromedio(int pCodigo, int pCodigoProducto, int pLote,DateTime pHasta, Entidades.Empresa pEmpresa) {
            try
            {
                if (pEmpresa.Codigo == 1) {
                    return DatosIntegracion.RemitoProveedor.ObtenerPromedio(pCodigo, pCodigoProducto, pLote,pHasta);
                }else { 
                     return Datos.RemitoProveedor.ObtenerPromedio(pCodigo, pCodigoProducto,pLote, pHasta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double ObtenerCantidadALiquidar(int pCodigo, int pCodigoProducto, int pLote,DateTime pHasta, Entidades.Empresa pEmpresa)
        {
            try
            {
                if (pEmpresa.Codigo == 1)
                {
                    return DatosIntegracion.RemitoProveedor.ObtenerCantidadALiquidar(pCodigo, pCodigoProducto, pLote, pHasta);
                }
                else { 
                    return Datos.RemitoProveedor.ObtenerCantidadALiquidar(pCodigo, pCodigoProducto, pLote, pHasta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerLiquidacionesPendientes(Entidades.Proveedor pProveedor, Entidades.Producto pProducto, DateTime pDesde, DateTime pHasta, Entidades.Empresa pEmpresa, Int16 pVendidasTotalmente)
       // public DataTable ObtenerLiquidacionesPendientes(Entidades.Proveedor pProveedor, Entidades.Producto pProducto, DateTime pHasta, Entidades.Empresa pEmpresa)
        {
            try
            {

                return Datos.RemitoProveedor.ObtenerLiquidacionesPendientes(pProveedor, pProducto, pDesde, pHasta, pEmpresa,pVendidasTotalmente);
               // return Datos.RemitoProveedor.ObtenerLiquidacionesPendientes(pProveedor, pProducto,  pHasta, pEmpresa);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerLiquidacionesDeProveedoresPendientes(Entidades.Proveedor pProveedor, Entidades.Producto pProducto, DateTime pDesde, DateTime pHasta, Entidades.Empresa pEmpresa, bool pVendidasTotalmente)
        // public DataTable ObtenerLiquidacionesPendientes(Entidades.Proveedor pProveedor, Entidades.Producto pProducto, DateTime pHasta, Entidades.Empresa pEmpresa)
        {
            try
            {

                return Datos.RemitoProveedor.ObtenerLiquidacionesDeProveedoresPendientes(pProveedor, pProducto, pDesde, pHasta, pEmpresa, pVendidasTotalmente);
                // return Datos.RemitoProveedor.ObtenerLiquidacionesPendientes(pProveedor, pProducto,  pHasta, pEmpresa);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerVentas(int pCodigo, int pCodigoProducto, int pLote,DateTime pHasta, Entidades.Empresa pEmpresa)
        // public DataTable ObtenerLiquidacionesPendientes(Entidades.Proveedor pProveedor, Entidades.Producto pProducto, DateTime pHasta, Entidades.Empresa pEmpresa)
        {
            try
            {
                //if (pEmpresa.Codigo == 1)
                {
                    return DatosIntegracion.RemitoProveedor.ObtenerVentas(pCodigo, pCodigoProducto, pLote, pHasta);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
