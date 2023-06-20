using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Proveedor
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Proveedor.ObtenerTodos();
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
                return Datos.Proveedor.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerComunicaciones(Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.Proveedor.ObtenerComunicaciones(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.Proveedor ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Proveedor.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Proveedor ObtenerUnoActivo(int pCodigo)
        {
            try
            {
                return Datos.Proveedor.ObtenerUnoActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Proveedor pProveedor, DataTable pComunicaciones, Entidades.Empresa pEmpresa)
        {
            try
            {
                Datos.Proveedor.Agregar(pProveedor, pComunicaciones);
                if (pEmpresa.Codigo == 1)
                    DatosGuias.Proveedor.Agregar(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Entidades.Proveedor pProveedor)
        {
            try
            {
                Datos.Proveedor.Eliminar(pProveedor);
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
                return Datos.Proveedor.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Proveedor pProveedor)
        {
            try
            {
                Datos.Proveedor.CambiarEstadoNovedad(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Proveedor pProveedor)
        {
            try
            {
                Datos.Proveedor.AgregarDeWeb(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDataTable(Entidades.Proveedor pProveedor)
        {
            try
            {
                return Datos.Proveedor.ObtenerDataTable(pProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
