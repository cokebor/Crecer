using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class TipoMovimientoBancario
    {
        public DataTable ObtenerTodos() {
            try
            {
                return Datos.TipoMovimientoBancario.ObtenerTodos();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerAlgunos()
        {
            try
            {
                return Datos.TipoMovimientoBancario.ObtenerAlgunos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.TipoMovimientoBancario pTipo)
        {
            try
            {
                Datos.TipoMovimientoBancario.Agregar(pTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.TipoMovimientoBancario pTipo)
        {
            try
            {
                Datos.TipoMovimientoBancario.Eliminar(pTipo);
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
                return Datos.TipoMovimientoBancario.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.TipoMovimientoBancario pTipoMovimientoBancario)
        {
            try
            {
                Datos.TipoMovimientoBancario.CambiarEstadoNovedad(pTipoMovimientoBancario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.TipoMovimientoBancario pTipoMovimientoBancario)
        {
            try
            {
                Datos.TipoMovimientoBancario.AgregarDeWeb(pTipoMovimientoBancario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.TipoMovimientoBancario ObtenerUno(int pCodigo)
        {
            try
            {
                if (pCodigo == 0) {
                    return new Entidades.TipoMovimientoBancario();
                }else
                return Datos.TipoMovimientoBancario.ObtenerUno(pCodigo);
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
       return Datos.Pais.ObtenerActivos();
   }
   catch (Exception ex)
   {
       throw new Exception(ex.Message);
   }
}
public Entidades.Pais ObtenerUno(int pCodigo)
{
   try
   {
       return Datos.Pais.ObtenerUno(pCodigo);
   }
   catch (Exception ex)
   {
       throw new Exception(ex.Message);
   }
}







*/
    }
}
