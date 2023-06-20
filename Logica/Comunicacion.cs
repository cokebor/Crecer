using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Comunicacion
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Comunicacion.ObtenerTodos();
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
                return Datos.Comunicacion.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Comunicacion ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Comunicacion.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Comunicacion pComunicacion)
        {
            try
            {
                Datos.Comunicacion.Agregar(pComunicacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.Comunicacion pComunicacion)
        {
            try
            {
                Datos.Comunicacion.Eliminar(pComunicacion);
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
                return Datos.Comunicacion.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Comunicacion pComunicacion)
        {
            try
            {
                Datos.Comunicacion.CambiarEstadoNovedad(pComunicacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Comunicacion pComunicacion)
        {
            try
            {
                Datos.Comunicacion.AgregarDeWeb(pComunicacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
