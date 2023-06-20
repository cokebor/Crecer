using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ObraSocial
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.ObraSocial.ObtenerTodos();
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
                return Datos.ObraSocial.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.ObraSocial pObraSocial)
        {
            try
            {
                Datos.ObraSocial.Agregar(pObraSocial);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.ObraSocial pObraSocial)
        {
            try
            {
                Datos.ObraSocial.Eliminar(pObraSocial);
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
                return Datos.ObraSocial.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.ObraSocial pObraSocial)
        {
            try
            {
                Datos.ObraSocial.CambiarEstadoNovedad(pObraSocial);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.ObraSocial pObraSocial)
        {
            try
            {
                Datos.ObraSocial.AgregarDeWeb(pObraSocial);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
