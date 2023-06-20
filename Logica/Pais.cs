using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Pais
    {
        public DataTable ObtenerTodos() {
            try
            {
                return Datos.Pais.ObtenerTodos();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerNovedades()
        {
            try
            {
                return Datos.Pais.ObtenerNovedades();
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
        public void Agregar(Entidades.Pais pPais) {
            try
            {
                Datos.Pais.Agregar(pPais);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Pais pPais)
        {
            try
            {
                Datos.Pais.AgregarDeWeb(pPais);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Pais pPais)
        {
            try
            {
                Datos.Pais.CambiarEstadoNovedad(pPais);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.Pais pPais)
        {
            try
            {
                Datos.Pais.Eliminar(pPais);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
