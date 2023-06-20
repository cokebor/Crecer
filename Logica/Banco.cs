using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Banco
    {
        public DataTable ObtenerTodos() {
            try
            {
                return Datos.Banco.ObtenerTodos();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerActivos()
        {
            try
            {
                return Datos.Banco.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public DataTable ObtenerActivosDeCuentasActivas()
        {
            try
            {
                return Datos.Banco.ObtenerActivosDeCuentasActivas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerActivosDeCuentasActivasParaTransferenciasClientes()
        {
            try
            {
                return Datos.Banco.ObtenerActivosDeCuentasActivasParaTransferenciasClientes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerBancoCuentaDebitoCredito(bool pVentas, bool pDebito)
        {
            try
            {
                return Datos.Banco.ObtenerBancoCuentaDebitoCredito(pVentas, pDebito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Banco ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Banco.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Banco ObtenerUnoActivo(int pCodigo)
        {
            try
            {
                return Datos.Banco.ObtenerUnoActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Banco pBanco) {
            try
            {
                Datos.Banco.Agregar(pBanco);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.Banco pBanco)
        {
            try
            {
                Datos.Banco.Eliminar(pBanco);
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
                return Datos.Banco.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Banco pBanco)
        {
            try
            {
                Datos.Banco.CambiarEstadoNovedad(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Banco pBanco)
        {
            try
            {
                Datos.Banco.AgregarDeWeb(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
