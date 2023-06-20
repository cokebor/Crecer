using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Impuesto
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Impuesto.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosCompras()
        {
            try
            {
                return Datos.Impuesto.ObtenerTodosCompras();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosVentas()
        {
            try
            {
                return Datos.Impuesto.ObtenerTodosVentas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Impuesto pImpuesto)
        {
            try
            {
                Datos.Impuesto.Agregar(pImpuesto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerFechas(int pSucursal)
        {
            try
            {
                if (pSucursal == 1)
                {
                    //return DatosIntegracion.Asiento.ObtenerFechas(pEjercicio);
                    return DatosIntegracion.Impuesto.ObtenerFechas();
                }
                else
                {
                    return Datos.Impuesto.ObtenerFechas();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerRetencionesPercepciones(int pSucursal, Int64 pCodigoCuentaContable)//, int pCodigoImpuesto)
        {
            try
            {
                if (pSucursal == 1)
                {
                    //return DatosIntegracion.Asiento.ObtenerFechas(pEjercicio);
                    return DatosIntegracion.Impuesto.ObtenerRetencionesPercepciones(pCodigoCuentaContable);//,pCodigoImpuesto);
                }
                else
                {
                    return Datos.Impuesto.ObtenerRetencionesPercepciones(pCodigoCuentaContable);//, pCodigoImpuesto);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Eliminar(Entidades.Impuesto pImpuesto)
        {
            try
            {
                Datos.Impuesto.Eliminar(pImpuesto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Impuesto ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Impuesto.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Impuesto ObtenerUnoActivo(int pCodigo)
        {
            try
            {
                return Datos.Impuesto.ObtenerUnoActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Impuesto ObtenerUnoCompraActivo(int pCodigo)
        {
            try
            {
                return Datos.Impuesto.ObtenerUnoCompraActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Impuesto ObtenerUnoVentaActivo(int pCodigo)
        {
            try
            {
                return Datos.Impuesto.ObtenerUnoVentaActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerPercepciones(DateTime pDesde, DateTime pHasta) {
            try {
                return Datos.Impuesto.ObtenerPercepciones(pDesde, pHasta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerRetenciones(DateTime pDesde, DateTime pHasta, int pSucursal)
        {
            try
            {
                DataTable dt = new DataTable();
                switch (pSucursal)
                {
                    case 1:
                        dt = DatosIntegracion.Impuesto.ObtenerRetenciones(pDesde, pHasta);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        dt = Datos.Impuesto.ObtenerRetenciones(pDesde, pHasta);
                        break;
                        /*   case 3:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                           case 4:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                           case 5:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                           case 6:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                           case 7:
                               dt = Datos.Factura.ObtenerIngresosBrutos(pDesde, pHasta);
                               break;
                               */
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
