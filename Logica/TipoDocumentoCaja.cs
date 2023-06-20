using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoDocumentoCaja
    {
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
        public Entidades.TipoDocumentoCaja ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.TipoDocumentoCaja.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.TipoDocumentoCaja.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerCajaRetenciones()
        {
            try
            {
                return Datos.TipoDocumentoCaja.ObtenerCajaRetenciones();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTipoComprabantesSucursales()
        {
            try
            {
                return Datos.TipoDocumentoCaja.ObtenerTipoComprabantesSucursales();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
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
*/
    }
}
