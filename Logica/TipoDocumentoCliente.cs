using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoDocumentoCliente
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.TipoDocumentoCliente.ObtenerTodos();
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
                return Datos.TipoDocumentoCliente.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.TipoDocumentoCliente ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.TipoDocumentoCliente.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.TipoDocumentoCliente pTipo)
        {
            try
            {
                Datos.TipoDocumentoCliente.Agregar(pTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.TipoDocumentoCliente pTipo)
        {
            try
            {
                Datos.TipoDocumentoCliente.Eliminar(pTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.TipoDocumentoCliente ObtenerDeCliente(int pCodigoCliente, Entidades.TipoDocumentoCliente pTipoDocumentoCliente,double pTotalFactura=0, bool pVacios=false)
        {
            try
            {
                return Datos.TipoDocumentoCliente.ObtenerDeCliente(pCodigoCliente, pTipoDocumentoCliente, pTotalFactura,pVacios);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFacturasManuales()
        {
            try
            {
                return Datos.TipoDocumentoCliente.ObtenerFacturasManuales();
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
                return Datos.TipoDocumentoCliente.ObtenerTodosDeTipoPagos(pCodigoTipoInscripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        public DataTable ObtenerTiposPorClientes(int pCodigoTipoInscripcion)
        {
            try
            {
                return Datos.TipoDocumentoCliente.ObtenerTiposPorClientes(pCodigoTipoInscripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
