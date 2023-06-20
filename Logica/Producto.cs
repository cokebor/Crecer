using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class Producto
    {
        //public DataTable ObtenerTodos()
        public DataTable ObtenerTodos(Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.Producto.ObtenerTodos();
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Producto.ObtenerTodos();
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Producto.ObtenerTodos();
                            break;
                        case 2:
                            dt = DatosWiki.Producto.ObtenerTodos();
                            break;
                        case 3:
                            dt = DatosNave7.Producto.ObtenerTodos();
                            break;
                        case 4:
                            dt = DatosVillaMaria.Producto.ObtenerTodos();
                            break;
                        case 5:
                            dt = DatosRioCuarto.Producto.ObtenerTodos();
                            break;
                        case 7:
                            dt = DatosSucursal6.Producto.ObtenerTodos();
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

        public DataTable ObtenerParaCargarPrecios(Entidades.Empresa pEmpresa, bool pSaldoEnSucursales)
        {
            try
            {
                return Datos.Producto.ObtenerParaCargarPrecios(pEmpresa,pSaldoEnSucursales);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosConSaldo(Entidades.Sucursal pSucursal = null)
        {
            try
            {
                //return Datos.Producto.ObtenerTodosConSaldo();
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt = Datos.Producto.ObtenerTodosConSaldo();
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Producto.ObtenerTodosConSaldo();
                            break;
                        case 2:
                            dt = DatosWiki.Producto.ObtenerTodosConSaldo();
                            break;
                        case 3:
                            dt = DatosNave7.Producto.ObtenerTodosConSaldo();
                            break;
                        case 4:
                            dt = DatosVillaMaria.Producto.ObtenerTodosConSaldo();
                            break;
                        case 5:
                            dt = DatosRioCuarto.Producto.ObtenerTodosConSaldo();
                            break;
                        case 7:
                            dt = DatosSucursal6.Producto.ObtenerTodosConSaldo();
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
        public DataTable ObtenerActivos()
        {
            try
            {
                return Datos.Producto.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Producto ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Producto.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Producto ObtenerUnoActivo(int pCodigo)
        {
            try
            {
                return Datos.Producto.ObtenerUnoActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Producto pProducto,Entidades.Empresa pEmpresa)
        {
            try
            {
                int pCodigo=Datos.Producto.Agregar(pProducto);
                if (pEmpresa.Codigo == 1) { 
                    pProducto.Codigo = pCodigo;
                    DatosGuias.Producto.Agregar(pProducto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Entidades.Producto pProducto)
        {
            try
            {
                Datos.Producto.Eliminar(pProducto);
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
                return Datos.Producto.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerPreciosNovedades()
        {
            try
            {
                return Datos.Producto.ObtenerPreciosNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Producto pProducto)
        {
            try
            {
                Datos.Producto.CambiarEstadoNovedad(pProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.PreciosLote pPreciosLote)
        {
            try
            {
                Datos.Producto.CambiarEstadoNovedad(pPreciosLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AgregarDeWeb(Entidades.Producto pProducto)
        {
            try
            {
                Datos.Producto.AgregarDeWeb(pProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.PreciosLote pPreciosLote)
        {
            try
            {
                Datos.Producto.AgregarDeWeb(pPreciosLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerVentas(DateTime pDesde, DateTime pHasta, Entidades.Cliente pCliente, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Sucursal pSucursal=null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt= Datos.Producto.ObtenerVentas(pDesde, pHasta, pCliente, pRubro, pProducto);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Producto.ObtenerVentas(pDesde, pHasta, pCliente, pRubro, pProducto);
                            break;
                        case 2:
                            dt = DatosWiki.Producto.ObtenerVentas(pDesde, pHasta, pCliente, pRubro, pProducto);
                            break;
                        case 3:
                            dt = DatosNave7.Producto.ObtenerVentas(pDesde, pHasta, pCliente, pRubro, pProducto);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Producto.ObtenerVentas(pDesde, pHasta, pCliente, pRubro, pProducto);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Producto.ObtenerVentas(pDesde, pHasta, pCliente, pRubro, pProducto);
                            break;
                        case 7:
                            dt = DatosSucursal6.Producto.ObtenerVentas(pDesde, pHasta, pCliente, pRubro, pProducto);
                            break;
                        case 0:
                            dt = DatosIntegracion.Producto.ObtenerVentas(pDesde, pHasta, pCliente, pRubro, pProducto);
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

        public DataTable ObtenerVentasDetalladas(DateTime pDesde, DateTime pHasta, Entidades.Cliente pCliente, Entidades.RubroProducto pRubro, Entidades.Producto pProducto,Entidades.Lote pLote, Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt= Datos.Producto.ObtenerVentasDetalladas(pDesde, pHasta, pCliente, pRubro, pProducto, pLote);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Producto.ObtenerVentasDetalladas(pDesde, pHasta, pCliente, pRubro, pProducto, pLote);
                            break;
                        case 2:
                            dt = DatosWiki.Producto.ObtenerVentasDetalladas(pDesde, pHasta, pCliente, pRubro, pProducto, pLote);
                            break;
                        case 3:
                            dt = DatosNave7.Producto.ObtenerVentasDetalladas(pDesde, pHasta, pCliente, pRubro, pProducto, pLote);
                            break;
                        case 4:
                            dt = DatosVillaMaria.Producto.ObtenerVentasDetalladas(pDesde, pHasta, pCliente, pRubro, pProducto, pLote);
                            break;
                        case 5:
                            dt = DatosRioCuarto.Producto.ObtenerVentasDetalladas(pDesde, pHasta, pCliente, pRubro, pProducto, pLote);
                            break;
                        case 7:
                            dt = DatosSucursal6.Producto.ObtenerVentasDetalladas(pDesde, pHasta, pCliente, pRubro, pProducto, pLote);
                            break;
                        case 0:
                            dt=DatosIntegracion.Producto.ObtenerVentasDetalladas(pDesde, pHasta, pCliente, pRubro, pProducto, pLote);
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

        public void AgregarPrecios(Entidades.Usuario pUsuario, List<PreciosLote> pPrecios)
        {
            try {
                Datos.Producto.AgregarPrecios(pUsuario, pPrecios);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
