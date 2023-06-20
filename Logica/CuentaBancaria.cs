using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CuentaBancaria
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.CuentaBancaria.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Agregar(Entidades.CuentaBancaria pCuenta)
        {
            try
            {
                Datos.CuentaBancaria.Agregar(pCuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.CuentaBancaria pCuenta)
        {
            try
            {
                Datos.CuentaBancaria.Eliminar(pCuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDeBancos(Entidades.Banco pBanco) {
            try
            {
                return Datos.CuentaBancaria.ObtenerDeBancos(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerCuentasDebitoCreditoDeBancos(Entidades.Banco pBanco)
        {
            try
            {
                return Datos.CuentaBancaria.ObtenerCuentasDebitoCreditoDeBancos(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerDeBancosParaTransferenciasClientes(Entidades.Banco pBanco)
        {
            try
            {
                return Datos.CuentaBancaria.ObtenerDeBancosParaTransferenciasClientes(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public Entidades.CuentaBancaria ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.CuentaBancaria.ObtenerUno(pCodigo);
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
                return Datos.CuentaBancaria.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.CuentaBancaria pCUenta)
        {
            try
            {
                Datos.CuentaBancaria.CambiarEstadoNovedad(pCUenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.CuentaBancaria pCuenta)
        {
            try
            {
                Datos.CuentaBancaria.AgregarDeWeb(pCuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
