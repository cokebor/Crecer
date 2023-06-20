using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Ejercicio
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Ejercicio.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Agregar(Entidades.Ejercicio pEjercicio)
        {
            try
            {
                Datos.Ejercicio.Agregar(pEjercicio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.Ejercicio pEjercicio)
        {
            try
            {
                Datos.Ejercicio.Eliminar(pEjercicio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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


    }
}
