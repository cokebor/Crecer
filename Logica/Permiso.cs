using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Permiso
    {
        public DataTable ObtenerTodos(int pCodigoGrupo)
        {
            try
            {
                return Datos.Permiso.ObtenerTodos(pCodigoGrupo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insertar(int pCodigoGrupo, DataTable pPermisos) {
            try
            {
                Datos.Permiso.Insertar(pCodigoGrupo, pPermisos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
