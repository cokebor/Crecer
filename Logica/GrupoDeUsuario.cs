using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class GrupoDeUsuario
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.GrupoDeUsuario.ObtenerTodos();
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
                return Datos.GrupoDeUsuario.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.GrupoDeUsuario ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.GrupoDeUsuario.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.GrupoDeUsuario pGrupoDeUsuario)
        {
            try
            {
                Datos.GrupoDeUsuario.Agregar(pGrupoDeUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.GrupoDeUsuario pGrupoDeUsuario)
        {
            try
            {
                Datos.GrupoDeUsuario.Eliminar(pGrupoDeUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
