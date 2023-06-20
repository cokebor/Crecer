using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoLicencia
    {
        public DataTable ObtenerTodos(bool pTodas) {
            try
            {
                return Datos.TipoLicencia.ObtenerTodos(pTodas);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Agregar(Entidades.TipoLicencia objETipoLicencia)
        {
            try
            {
                Datos.TipoLicencia.Agregar(objETipoLicencia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.TipoLicencia objETipoLicencia)
        {
            try
            {
                Datos.TipoLicencia.Eliminar(objETipoLicencia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
