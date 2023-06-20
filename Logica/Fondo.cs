using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Fondo
    {

        public DataTable ObtenerTodos(Entidades.Banco pBanco)
        {
            try
            {
                return Datos.Fondo.ObtenerTodos(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerActivos(Entidades.Banco pBanco)
        {
            try
            {
                return Datos.Fondo.ObtenerActivos(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Agregar(Entidades.Fondo pFondo)
        {
            try
            {
                Datos.Fondo.Agregar(pFondo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void Eliminar(Entidades.Fondo pFondo)
        {
            try
            {
                Datos.Fondo.Eliminar(pFondo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        public Entidades.Ejercicio ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Ejercicio.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    */
    }
}
