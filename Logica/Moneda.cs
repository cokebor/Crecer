using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Moneda
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Moneda.ObtenerTodos();
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
                return Datos.Moneda.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Moneda ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Moneda.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Moneda pMoneda)
        {
            try
            {
                Datos.Moneda.Agregar(pMoneda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Entidades.Moneda pMoneda)
        {
            try
            {
                Datos.Moneda.Eliminar(pMoneda);
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
                return Datos.Moneda.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Moneda pMoneda)
        {
            try
            {
                Datos.Moneda.CambiarEstadoNovedad(pMoneda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Moneda pMoneda)
        {
            try
            {
                Datos.Moneda.AgregarDeWeb(pMoneda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
