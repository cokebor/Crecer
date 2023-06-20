using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoDocumentoProveedor
    {

        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.TipoDocumentoProveedor.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entidades.TipoDocumentoProveedor> ObtenerTodosConImpuestos(char pImpuesto)
        {
            try
            {
                return Datos.TipoDocumentoProveedor.ObtenerTodosConImpuestos(pImpuesto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
                public DataTable ObtenerActivos()
                {
                    try
                    {
                        return Datos.TipoDocumentoCliente.ObtenerActivos();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }*/
        public Entidades.TipoDocumentoProveedor ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.TipoDocumentoProveedor.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.TipoDocumentoProveedor pTipo)
        {
            try
            {
                Datos.TipoDocumentoProveedor.Agregar(pTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void Eliminar(Entidades.TipoDocumentoProveedor pTipo)
        {
            try
            {
                Datos.TipoDocumentoProveedor.Eliminar(pTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        public Entidades.TipoDocumentoCliente ObtenerDeCliente(int pCodigoCliente, Entidades.TipoDocumentoCliente pTipoDocumentoCliente)
        {
            try
            {
                return Datos.TipoDocumentoCliente.ObtenerDeCliente(pCodigoCliente, pTipoDocumentoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/
        
       public DataTable ObtenerTodosDeTipoFacturas(int pCodigoTipoInscripcion, bool FormaPago)
        {
            try
            {
                return Datos.TipoDocumentoProveedor.ObtenerTodosDeTipoFacturas(pCodigoTipoInscripcion, FormaPago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosDeTipoPagos(int pCodigoTipoInscripcion)
        {
            try
            {
                return Datos.TipoDocumentoProveedor.ObtenerTodosDeTipoPagos(pCodigoTipoInscripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.TipoDocumentoProveedor ObtenerDeProveedorLiquidaciones(int pCodigoTipoInscripcion, Entidades.TipoDocumentoProveedor pTipoDocumentoProveedor)
        {
            try
            {
                return Datos.TipoDocumentoProveedor.ObtenerDeProveedorLiquidaciones(pCodigoTipoInscripcion, pTipoDocumentoProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.TipoDocumentoProveedor ObtenerDeProveedor(int pCodigoProveedor, Entidades.TipoDocumentoProveedor pTipoDocumentoProveedor)
        {
            try
            {
                return Datos.TipoDocumentoProveedor.ObtenerDeProveedor(pCodigoProveedor, pTipoDocumentoProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosAAnular(int pCodigoProveedor)
        {
            try
            {
                return Datos.TipoDocumentoProveedor.ObtenerTodosAAnular(pCodigoProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTiposPorProveedores(int pCodigoTipoInscripcion)
        {
            try
            {
                return Datos.TipoDocumentoProveedor.ObtenerTiposPorProveedores(pCodigoTipoInscripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
