using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FormaDePago
    {
        public DataTable ObtenerTodosVentas()
        {
            try
            {
                return Datos.FormaDePago.ObtenerTodosVentas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        public DataTable ObtenerTodosCompras()
        {
            try
            {
                return Datos.FormaDePago.ObtenerTodosCompras();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        public DataTable ObtenerTodosVentasFormasPago() {
            try
            {
                return Datos.FormaDePago.ObtenerTodosVentasFormasPago();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
       public DataTable ObtenerTodosVentasSaldoInicialFormasPago()
        {
            try
            {
                return Datos.FormaDePago.ObtenerTodosVentasSaldoInicialFormasPago();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodosComprasFormasPago()
        {
            try
            {
                return Datos.FormaDePago.ObtenerTodosComprasFormasPago();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosComprasFormasPago(int pCodigoSucursal)
        {
            try
            {
                return Datos.FormaDePago.ObtenerTodosComprasFormasPago(pCodigoSucursal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodosIngresosFormasPago()
        {
            try
            {
                return Datos.FormaDePago.ObtenerTodosIngresosFormasPago();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodosPagosSueldosFormasPago()
        {
            try
            {
                return Datos.FormaDePago.ObtenerTodosPagosSueldosFormasPago();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodosComprasContraReciboFormasPago()
        {
            try
            {
                return Datos.FormaDePago.ObtenerTodosComprasContraReciboFormasPago();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public DataTable ObtenerParaEgreso()
        {
            try
            {
                return Datos.FormaDePago.ObtenerParaEgreso();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.FormaDePago ObtenerUno(int pCodigoFormaPago, Entidades.Sucursal pSucursal=null) {
            try
            {
                Entidades.FormaDePago e = new Entidades.FormaDePago();
                if (pSucursal == null)
                    e = Datos.FormaDePago.ObtenerUno(pCodigoFormaPago);
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            e = Datos.FormaDePago.ObtenerUno(pCodigoFormaPago);
                            break;
                        case 2:
                            e = DatosWiki.FormaDePago.ObtenerUno(pCodigoFormaPago);
                            break;
                        case 3:
                            e = DatosNave7.FormaDePago.ObtenerUno(pCodigoFormaPago);
                            break;
                        case 4:
                            e = DatosVillaMaria.FormaDePago.ObtenerUno(pCodigoFormaPago);
                            break;
                        case 5:
                            e = DatosRioCuarto.FormaDePago.ObtenerUno(pCodigoFormaPago);
                            break;
                        case 7:
                            e = DatosSucursal6.FormaDePago.ObtenerUno(pCodigoFormaPago);
                            break;
                    }
                }

                return e;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerParaTransacciones()
        {
            try
            {
                return Datos.FormaDePago.ObtenerParaTransacciones();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
