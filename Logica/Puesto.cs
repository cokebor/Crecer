using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Puesto
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Puesto.ObtenerTodos();
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
                return Datos.Puesto.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Puesto pPuesto)
        {
            try
            {
                Datos.Puesto.Agregar(pPuesto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.Puesto pPuesto)
        {
            try
            {
                Datos.Puesto.Eliminar(pPuesto);
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
                return Datos.Puesto.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Puesto pPuesto)
        {
            try
            {
                Datos.Puesto.CambiarEstadoNovedad(pPuesto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Puesto pPuesto)
        {
            try
            {
                Datos.Puesto.AgregarDeWeb(pPuesto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
