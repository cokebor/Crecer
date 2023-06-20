using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Transporte
    {
        public void Agregar(Entidades.Transporte pTransporte)
        {
            try
            {
                Datos.Transporte.Agregar(pTransporte);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.Transporte pTransporte)
        {
            try
            {
                Datos.Transporte.Eliminar(pTransporte);
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
                return Datos.Transporte.ObtenerTodos();
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
                return Datos.Transporte.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
