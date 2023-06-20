using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class MovStock_Lote
    {

        public DataTable ObtenerLotesSaldoPorProducto(int pCodigo, int pCantidad)
        {
            try
            {
                return Datos.MovStock_Lote.ObtenerLotesSaldoPorProducto(pCodigo, pCantidad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerLoteDeProducto(int pCodigo)
        {
            try
            {
                return Datos.MovStock_Lote.ObtenerLoteDeProducto(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public DataTable ObtenerLotesSaldoPorProductoYProveedor(Entidades.Producto pProducto, Entidades.Proveedor pProveedor, int pCantidad)
        {
            try
            {
                if (pProveedor == null || pProveedor.Codigo==0) {
                    throw new Exception("Debe Seleccionar un Proveedor valido");
                }else
                    return Datos.MovStock_Lote.ObtenerLotesSaldoPorProductoYProveedor(pProducto, pProveedor, pCantidad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int VerSiExisteComprobante(int pLote)
        {
            try
            {
                if (Datos.MovStock_Lote.VerSiExisteComprobante(pLote)==1)
                {
                    throw new Exception("No se puede modificar el Lote debido a que contiene comprobantes asociados");
                }
                return Datos.MovStock_Lote.ObtenerMovStock(pLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        public int CantidadDeMovimientosPorLote(Entidades.Lote pLote) {
            try
            {
                return Datos.MovStock_Lote.CantidadDeMovimientosPorLote(pLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerStockPorFecha(DateTime pFecha, Entidades.Canal pCanal, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.Producto.ObtenerTodos();
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.MovStock_Lote.ObtenerStockPorFecha(pFecha,pCanal);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.MovStock_Lote.ObtenerStockPorFecha(pFecha,pCanal);
                            break;
                        case 2:
                            dt = DatosWiki.MovStock_Lote.ObtenerStockPorFecha(pFecha, pCanal);
                            break;
                        case 3:
                            dt = DatosNave7.MovStock_Lote.ObtenerStockPorFecha(pFecha, pCanal);
                            break;
                        case 4:
                            dt = DatosVillaMaria.MovStock_Lote.ObtenerStockPorFecha(pFecha, pCanal);
                            break;
                        case 5:
                            dt = DatosRioCuarto.MovStock_Lote.ObtenerStockPorFecha(pFecha, pCanal);
                            break;
                        case 7:
                            dt = DatosSucursal6.MovStock_Lote.ObtenerStockPorFecha(pFecha, pCanal);
                            break;
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerStockPorLotePuesto(Entidades.Producto pProducto, Entidades.Proveedor pProveedor, Entidades.Lote pLote, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.MovStock_Lote.ObtenerStockPorLotePuesto(pProducto, pProveedor, pLote);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.MovStock_Lote.ObtenerStockPorLotePuesto(pProducto, pProveedor, pLote);
                            break;
                        case 2:
                            dt = DatosWiki.MovStock_Lote.ObtenerStockPorLotePuesto(pProducto, pProveedor, pLote);
                            break;
                        case 3:
                            dt = DatosNave7.MovStock_Lote.ObtenerStockPorLotePuesto(pProducto, pProveedor, pLote);
                            break;
                        case 4:
                            dt = DatosVillaMaria.MovStock_Lote.ObtenerStockPorLotePuesto(pProducto, pProveedor, pLote);
                            break;
                        case 5:
                            dt = DatosRioCuarto.MovStock_Lote.ObtenerStockPorLotePuesto(pProducto, pProveedor, pLote);
                            break;
                        case 7:
                            dt = DatosSucursal6.MovStock_Lote.ObtenerStockPorLotePuesto(pProducto, pProveedor, pLote);
                            break;
                        case 0:
                            dt = DatosIntegracion.MovStock_Lote.ObtenerStockPorLotePuesto(pProducto, pProveedor, pLote);
                            break;
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Actualizar(Entidades.MovStock_Lotes pMovStock, Entidades.Usuario pUsuario)
        {
            try
            {
                Datos.MovStock_Lote.Actualizar(pMovStock, pUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
