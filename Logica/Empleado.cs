using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Empleado
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Empleado.ObtenerTodos();
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
                return Datos.Empleado.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerActivosEmpleados()
        {
            try
            {
                return Datos.Empleado.ObtenerActivosEmpleados();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerActivosQueSonEmpleados()
        {
            try
            {
                return Datos.Empleado.ObtenerActivosQueSonEmpleados();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerComunicaciones(Entidades.Empleado pEmpleado)
        {
            try
            {
                return Datos.Empleado.ObtenerComunicaciones(pEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.Empleado ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Empleado.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Empleado ObtenerUnoActivo(int pCodigo)
        {
            try
            {
                return Datos.Empleado.ObtenerUnoActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Empleado ObtenerVendedorUnoActivo(int pCodigo)
        {
            try
            {
                return Datos.Empleado.ObtenerVendedorUnoActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet ObtenerEmpleadosActivos() {
            try
            {
                return Datos.Empleado.ObtenerEmpleadosActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Empleado pEmpleado, DataTable pComunicaciones, bool pEgreso)
        {
            try
            {
                Datos.Empleado.Agregar(pEmpleado, pComunicaciones, pEgreso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Entidades.Empleado pEmpleado)
        {
            try
            {
                Datos.Empleado.Eliminar(pEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarSueldo(Entidades.Empleado pEmpleado)
        {
            try
            {
                Datos.Empleado.ActualizarSueldo(pEmpleado);
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
                return Datos.Empleado.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Empleado pEmpleado)
        {
            try
            {
                Datos.Empleado.CambiarEstadoNovedad(pEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Empleado pEmpleado)
        {
            try
            {
                Datos.Empleado.AgregarDeWeb(pEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarVacaciones(List<Vacaciones> listaVacaciones,Entidades.Usuario pUsuario)
        {
            try
            {
                Datos.Empleado.AgregarVacaciones(listaVacaciones, pUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int ObtenerDiasVacacionesYaTomados(Entidades.Empleado pEmpleado, int pPeriodo) {
            try
            {
                return Datos.Empleado.ObtenerDiasVacacionesYaTomados(pEmpleado, pPeriodo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarLicencia(Entidades.Licencia pLicencia, Entidades.Usuario pUsuario)
        {
            try
            {
                Datos.Empleado.AgregarLicencia(pLicencia, pUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entidades.Empleado> ObtenerEmpleadosLiquidacionSueldo(int pCodigoFormaPago, int pCodigoCuentaBancaria)
        {
            try
            {
                return Datos.Empleado.ObtenerEmpleadosLiquidacionSueldo(pCodigoFormaPago, pCodigoCuentaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
