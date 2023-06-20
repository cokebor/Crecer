using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Provincia
    {
        public DataTable ObtenerTodos(Entidades.Pais pPais)
        {
            try
            {
                return Datos.Provincia.ObtenerTodos(pPais);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerActivos(Entidades.Pais pPais)
        {
            try
            {
                return Datos.Provincia.ObtenerActivos(pPais);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Provincia ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Provincia.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Provincia pProvincia)
        {
            try
            {
                Datos.Provincia.Agregar(pProvincia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.Provincia pProvincia)
        {
            try
            {
                Datos.Provincia.Eliminar(pProvincia);
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
                return Datos.Provincia.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Provincia pProvincia)
        {
            try
            {
                Datos.Provincia.CambiarEstadoNovedad(pProvincia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Provincia pProvincia)
        {
            try
            {
                Datos.Provincia.AgregarDeWeb(pProvincia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
