using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class PrestamoBancario
    {
        public int Agregar(Entidades.PrestamoBancario pPrestamo)
        {
            try
            {
                return Datos.PrestamoBancario.Agregar(pPrestamo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerPrestamosBancariosPendientes(Entidades.CuentaBancaria pCuentaBancaria)
        {
            try
            {
                return Datos.PrestamoBancario.ObtenerPrestamosBancariosPendientes(pCuentaBancaria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerPrestamosBancariosPendientes(int pCodigoPrestamo)
        {
            try
            {
                return Datos.PrestamoBancario.ObtenerPrestamosBancariosPendientes(pCodigoPrestamo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.TablaAmortizacion ObtenerCuotaUna(int pCodigoPrestamo, int pCuota)
        {
            try
            {
                return Datos.PrestamoBancario.ObtenerCuotaUna(pCodigoPrestamo, pCuota);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarPago(PrestamoBancarioPago objPPrestamo)
        {
            try
            {
                return Datos.PrestamoBancario.AgregarPago(objPPrestamo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
