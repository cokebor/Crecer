using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Numerador
    {
        public Entidades.Numerador ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Numerador.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Numerador.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Numerador pNumerador)
        {
            try
            {
                Datos.Numerador.Agregar(pNumerador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.Numerador pNumerador)
        {
            try
            {
                Datos.Numerador.Eliminar(pNumerador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
