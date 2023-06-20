using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class RemitoSucursal
    {
        public int Agregar(Entidades.RemitoSucursal_M pRemito)
        {
            try
            {
                return Datos.RemitoSucursal.Agregar(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDataTable(int pCodigoRemito)
        {
            try
            {
                return Datos.RemitoSucursal.ObtenerDataTable(pCodigoRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerEnviosProductosConSucursales(DateTime pDesde, DateTime pHasta, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, bool pRubrosSeleccionados)
        {
            try
            {
                return Datos.RemitoSucursal.ObtenerEnviosProductosConSucursales(pDesde, pHasta, pRubro, pProducto, pRubrosSeleccionados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ObtenerCantidadFechas(DateTime pDesde, DateTime pHasta, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, bool pRubrosSeleccionados)
        {
            try
            {
                return Datos.RemitoSucursal.ObtenerCantidadFechas(pDesde, pHasta, pRubro, pProducto, pRubrosSeleccionados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerEnviosProductos(DateTime pDesde, DateTime pHasta, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, bool pRubrosSeleccionados)
        {
            try
            {
                return Datos.RemitoSucursal.ObtenerEnviosProductos(pDesde, pHasta, pRubro, pProducto, pRubrosSeleccionados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDataTableDetalle(int pCodigoRemito)
        {
            try
            {
                return Datos.RemitoSucursal_D_Productos.ObtenerDataTable(pCodigoRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(int pCodigoRemito, int pRenglonDesde)
        {
            try
            {
                Datos.RemitoSucursal.Eliminar(pCodigoRemito, pRenglonDesde);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        public DataTable ObtenerNovedades()
        {
            try
            {
                return Datos.RemitoSucursal.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.RemitoSucursal_M pRemito)
        {
            try
            {
                Datos.RemitoSucursal.CambiarEstadoNovedad(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entidades.RemitoSucursal_D_Producto> ObtenerTodos(int pCodigoRemito)
        {
            try
            {
                return Datos.RemitoSucursal_D_Productos.ObtenerTodos(pCodigoRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int ObtenerCodigoRemito(string pNumRemito) {
            try
            {
                return Datos.RemitoSucursal.ObtenerCodigoRemito(pNumRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AgregarDeWeb(Entidades.RemitoSucursal_M pRemito)
        {
            try
            {
                Datos.RemitoSucursal.AgregarDeWeb(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // public DataTable ObtenerTodosDataTable(DateTime desde, DateTime hasta, Entidades.Sucursal pSucursalOrigen, Entidades.Sucursal pSucursalDestino, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote, bool pEnviados, bool pRecibidos)
        public DataTable ObtenerTodosDataTable(DateTime desde, DateTime hasta,  Entidades.Sucursal pSucursalDestino, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote, bool pEnviados, bool pRecibidos)
        {
            try
            {
                //return Datos.RemitoSucursal.ObtenerTodosDataTable(desde, hasta, pSucursalOrigen, pSucursalDestino, pRubro, pProducto, pLote, pEnviados, pRecibidos);
                return Datos.RemitoSucursal.ObtenerTodosDataTable(desde, hasta,  pSucursalDestino, pRubro, pProducto, pLote, pEnviados, pRecibidos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
