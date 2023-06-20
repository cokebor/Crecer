using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Usuario
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Usuario.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Usuario ObtenerUno(Entidades.Usuario pUsuario,int pCodigoPuestoCaja)
        {
            try
            {
                return Datos.Usuario.ObtenerUno(pUsuario, pCodigoPuestoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Usuario ObtenerUno(int pCodigoUsuario)
        {
            try
            {
                return Datos.Usuario.ObtenerUno(pCodigoUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ExisteUsuario(Entidades.Usuario pUsuario) {
            try
            {
                return Datos.Usuario.ExisteUsuario(pUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ExisteUsuarioParaEmpleado(Entidades.Usuario pUsuario)
        {
            try
            {
                return Datos.Usuario.ExisteUsuarioParaEmpleado(pUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Usuario pUsuario)
        {
            try
            {
                Datos.Usuario.Agregar(pUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Modificar(Entidades.Usuario pUsuario)
        {
            try
            {
                Datos.Usuario.Modificar(pUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*public void Modificar(Entidades.Usuario pUsuario, int pCodigoGrupoAnterior)
        {
            try
            {
                Datos.Usuario.Modificar(pUsuario, pCodigoGrupoAnterior);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        public bool CambiarClave(Entidades.Usuario pUsuario, string pContraseña) {
            if (!pUsuario.Contraseña.Equals(pContraseña)) {
                throw new Exception("Las contraseñas deben ser iguales");
            }
            try
            {
                Datos.Usuario.CambiarClave(pUsuario);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
        /*
         
            try
            {
                Datos.Usuario.CambiarClave(pUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
             */
        public void Eliminar(Entidades.Usuario pUsuario)
        {
            try
            {
                Datos.Usuario.Eliminar(pUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
