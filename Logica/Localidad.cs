using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Localidad
    {
        public DataTable ObtenerTodos(Entidades.Provincia pProvincia)
        {
            try
            {
                return Datos.Localidad.ObtenerTodos(pProvincia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerActivos(Entidades.Provincia pProvincia)
        {
            try
            {
                return Datos.Localidad.ObtenerActivos(pProvincia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Localidad pLocalidad)
        {
            try
            {
                Datos.Localidad.Agregar(pLocalidad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.Localidad pLocalidad)
        {
            try
            {
                Datos.Localidad.Eliminar(pLocalidad);
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
                return Datos.Localidad.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Localidad pLocalidad)
        {
            try
            {
                Datos.Localidad.CambiarEstadoNovedad(pLocalidad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Localidad pLocalidad)
        {
            try
            {
                Datos.Localidad.AgregarDeWeb(pLocalidad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
