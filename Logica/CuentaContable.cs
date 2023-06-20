using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CuentaContable
    {
        
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.CuentaContable.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable ObtenerTodosParaAperturaYCierre()
        {
            try
            {
                return Datos.CuentaContable.ObtenerTodosParaAperturaYCierre();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerImpuestosTodos(char pTipo)
        {
            try
            {
                return Datos.CuentaContable.ObtenerImpuestosTodos(pTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerDelPeriodo(DateTime pDesde, DateTime pHasta, int pSucursal, bool pPorFechaEmision)
        {
            try
            {
                if (pSucursal == 1)
                    return DatosIntegracion.CuentaContable.ObtenerDelPeriodo(pDesde, pHasta, pPorFechaEmision);
                else
                    return Datos.CuentaContable.ObtenerDelPeriodo(pDesde, pHasta, pPorFechaEmision);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerBienesDeUso()
        {
            try
            {
                return Datos.CuentaContable.ObtenerBienesDeUso();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerBienesDeCambio()
        {
            try
            {
                return Datos.CuentaContable.ObtenerBienesDeCambio();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerGastos()
        {
            try
            {
                return Datos.CuentaContable.ObtenerGastos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable ObtenerGastos2()
        {
            try
            {
                return Datos.CuentaContable.ObtenerGastos2();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable ObtenerIngresos()
        {
            try
            {
                return Datos.CuentaContable.ObtenerIngresos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerBancosPrestamos()
        {
            try
            {
                return Datos.CuentaContable.ObtenerBancosPrestamos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerGastosDevengamientos()
        {
            try
            {
                return Datos.CuentaContable.ObtenerGastosDevengamientos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable ObtenerBancos()
        {
            try
            {
                return Datos.CuentaContable.ObtenerBancos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerValoresDiferidos()
        {
            try
            {
                return Datos.CuentaContable.ObtenerValoresDiferidos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerTarjetas()
        {
            try
            {
                return Datos.CuentaContable.ObtenerTarjetas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.CuentaContable ObtenerUno(Int64 pCodigo)
    {
        try
        {
            return Datos.CuentaContable.ObtenerUno(pCodigo);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
/*
        public void Agregar(Entidades.CuentaContable pCuentaContable)
        {
            try
            {
                Datos.CuentaContable.Agregar(pCuentaContable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
    }
}