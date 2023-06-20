using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class RubroProducto
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.RubroProducto.ObtenerTodos();
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
                return Datos.RubroProducto.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.RubroProducto ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.RubroProducto.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.RubroProducto ObtenerUnoActivo(int pCodigo)
        {
            try
            {
                return Datos.RubroProducto.ObtenerUnoActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.RubroProducto pRubroProducto)
        {
            try
            {
                Datos.RubroProducto.Agregar(pRubroProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.RubroProducto pRubroProducto)
        {
            try
            {
                Datos.RubroProducto.Eliminar(pRubroProducto);
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
                return Datos.RubroProducto.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.RubroProducto pRubro)
        {
            try
            {
                Datos.RubroProducto.CambiarEstadoNovedad(pRubro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.RubroProducto pRubro)
        {
            try
            {
                Datos.RubroProducto.AgregarDeWeb(pRubro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
