using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Backup
    {
        public string CrearBackups(string direccion)
        {
            try
            {
                return Datos.Backup.CrearBackups(direccion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ObtenerNombre()
        {
            try
            {
                return Datos.Backup.ObtenerNombre();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        public void CrearBackups2(string nombreBase,string direccion)
        {
            try
            {
                Datos.Backup.CrearBackups2(nombreBase, direccion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        public void Restaurar(string nombreBase, string direccion)
        {
            try
            {
                Datos.Backup.Restaurar(nombreBase, direccion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CrearBackups2(string nombreBase, string direccion)
        {
            try
            {
                Datos.Backup.CrearBackups2(nombreBase, direccion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(int pCodigoSucursal, string pNombreArchivo) {
            try
            {
                DatosIntegracion.Backup.Agregar(pCodigoSucursal, pNombreArchivo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFechas(Entidades.Empresa pEmpresa)
        {
            try
            {
                return DatosIntegracion.Backup.ObtenerFechas(pEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
