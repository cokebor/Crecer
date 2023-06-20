using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Asiento
    {
        public void Agregar(Entidades.Asiento pAsiento)
        {
            try
            {
                Datos.Asiento.Agregar(pAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AgregarAjustes(Entidades.Asiento pAsiento, int pCodigoTipoAsiento, int pCodigoUsuario)
        {
            try
            {
                Datos.Asiento.AgregarAjustes(pAsiento, pCodigoTipoAsiento, pCodigoUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int ValidarFecha(DateTime pFecha)
        {
            try
            {
                return Datos.Asiento.ValidarFecha(pFecha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerFechas(Entidades.Ejercicio pEjercicio, int pSucursal, bool pFechaEmision)
        {
            try
            {
                if (pSucursal == 1)
                {
                    return DatosIntegracion.Asiento.ObtenerFechas(pEjercicio, pFechaEmision);
                }
                else
                {
                    return Datos.Asiento.ObtenerFechas(pEjercicio, pFechaEmision);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Ordenar(Entidades.Ejercicio pEjercicio, int pSucursal, bool pPorFechaEmision)
        {
            try
            {
                if (pSucursal == 1)
                {
                    DatosIntegracion.Asiento.Ordenar(pEjercicio, pPorFechaEmision);
                }
                else
                {
                    Datos.Asiento.Ordenar(pEjercicio, pPorFechaEmision);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Ordenar(Entidades.Ejercicio pEjercicio)
        {
            try
            {
                Datos.Asiento.Ordenar(pEjercicio, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public DataTable Obtener(DateTime pDesde, DateTime pHasta, int pSucursal, bool pPorFechaEmision)
        {
            try
            {
                if (pSucursal == 1)
                    return DatosIntegracion.Asiento.Obtener(pDesde, pHasta, pPorFechaEmision);
                else
                    return Datos.Asiento.Obtener(pDesde, pHasta, pPorFechaEmision);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable SumaYSaldo(DateTime pDesde, DateTime pHasta, int pSucursal, bool pPorFechaEmision)
        {
            try
            {
                if (pSucursal == 1)
                    return DatosIntegracion.Asiento.SumaYSaldo(pDesde, pHasta, pPorFechaEmision);
                else
                    return Datos.Asiento.SumaYSaldo(pDesde, pHasta, pPorFechaEmision);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable LibroMayor(DateTime pDesde, DateTime pHasta, DateTime pFechaInicioEjercicio, Int64 pCodigoCuentaContable, int pSucursal, bool pPorFechaEmision)
        {
            try
            {
                if (pSucursal == 1)
                    return DatosIntegracion.Asiento.LibroMayor(pDesde, pHasta, pFechaInicioEjercicio, pCodigoCuentaContable, pPorFechaEmision);
                else
                    return Datos.Asiento.LibroMayor(pDesde, pHasta, pFechaInicioEjercicio, pCodigoCuentaContable, pPorFechaEmision);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Agrupar(DateTime pFecha, int CodigoCierrecaja, Entidades.PuestoCaja pPuestoCaja, Entidades.Empresa pEmpresa)
        {
            try
            {
                string sucursal = "";
                switch (pEmpresa.Codigo)
                {
                    case 1:
                        sucursal = "Deposito";
                        break;
                    case 2:
                        sucursal = "Wiki";
                        break;
                    case 3:
                        sucursal = "Nave 7";
                        break;
                    case 4:
                        sucursal = "Villa Maria";
                        break;
                    case 5:
                        sucursal = "Rio Cuarto";
                        break;
                    case 6:
                        sucursal = "Fruticola Centro";
                        break;
                    case 7:
                        sucursal = "Sucursal 6";
                        break;
                }


                DataTable dt;
                Entidades.Asiento objEAsiento;

                #region Facturas Venta
                dt = Datos.Asiento.AsientosFacturas(CodigoCierrecaja, "FA", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Facturas de Venta Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }

                dt = Datos.Asiento.AsientosFacturas(CodigoCierrecaja, "ND", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Notas de Debito Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }

                dt = Datos.Asiento.AsientosFacturas(CodigoCierrecaja, "NC", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Notas de Credito Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }

                dt = Datos.Asiento.AsientosFacturas(CodigoCierrecaja, "LQ", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Liquidaciones de Clientes Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }
                #endregion

                #region Facturas Compras
                dt = Datos.Asiento.AsientosFacturasCompras(CodigoCierrecaja, "FA", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Facturas de Compra Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }

                dt = Datos.Asiento.AsientosFacturasCompras(CodigoCierrecaja, "ND", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Notas de Debito Compras Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }

                dt = Datos.Asiento.AsientosFacturasCompras(CodigoCierrecaja, "NC", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Notas de Credito Compras Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }

                dt = Datos.Asiento.AsientosFacturasCompras(CodigoCierrecaja, "LQ", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Liquidaciones de Proveedores Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }
                #endregion

                #region Pagos Clientes
                dt = Datos.Asiento.AsientosPagosClientes(CodigoCierrecaja, "RC", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Recibos de Clientes Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }

                dt = Datos.Asiento.AsientosPagosClientes(CodigoCierrecaja, "CR", pPuestoCaja);
                objEAsiento = new Entidades.Asiento();
                if (dt.Rows.Count > 0)
                {
                    objEAsiento.Fecha = pFecha;
                    objEAsiento.FechaEmision = pFecha;
                    objEAsiento.Descripcion = "Contra Recibos de Clientes Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                    Entidades.Asiento_Detalle asientoDetalle;
                    foreach (DataRow dr in dt.Rows)
                    {
                        asientoDetalle = new Entidades.Asiento_Detalle();
                        asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                        asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                        asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                        objEAsiento.Detalle.Add(asientoDetalle);
                    }
                    Datos.Asiento.AgregarAgrupadas(objEAsiento);
                }
                #endregion
                
                #region Pagos Proveedores
                if (pEmpresa.Codigo == 1)
                {
                    dt = Datos.Asiento.AsientosPagosProveedores(CodigoCierrecaja, "RC", pPuestoCaja);
                    objEAsiento = new Entidades.Asiento();
                    if (dt.Rows.Count > 0)
                    {
                        objEAsiento.Fecha = pFecha;
                        objEAsiento.FechaEmision = pFecha;
                        objEAsiento.Descripcion = "Recibos de Proveedores Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                        Entidades.Asiento_Detalle asientoDetalle;
                        foreach (DataRow dr in dt.Rows)
                        {
                            asientoDetalle = new Entidades.Asiento_Detalle();
                            asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                            asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                            asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                            objEAsiento.Detalle.Add(asientoDetalle);
                        }
                        Datos.Asiento.AgregarAgrupadas(objEAsiento);
                    }

                    dt = Datos.Asiento.AsientosPagosProveedores(CodigoCierrecaja, "CR", pPuestoCaja);
                    objEAsiento = new Entidades.Asiento();
                    if (dt.Rows.Count > 0)
                    {
                        objEAsiento.Fecha = pFecha;

                        objEAsiento.FechaEmision = pFecha;
                        objEAsiento.Descripcion = "Contra Recibos de Proveedores Cierre de Caja N° " + CodigoCierrecaja + " Sucursal: " + sucursal;
                        Entidades.Asiento_Detalle asientoDetalle;
                        foreach (DataRow dr in dt.Rows)
                        {
                            asientoDetalle = new Entidades.Asiento_Detalle();
                            asientoDetalle.CuentaContable.Codigo = Convert.ToInt64(dr["CodigoCuentaContable"]);
                            asientoDetalle.Debe = Convert.ToDouble(dr["Debe"]);
                            asientoDetalle.Haber = Convert.ToDouble(dr["Haber"]);
                            objEAsiento.Detalle.Add(asientoDetalle);
                        }
                        Datos.Asiento.AgregarAgrupadas(objEAsiento);
                    }
                }
                #endregion
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void BorrarAsientosAgrupados(/*int pCodigoAsiento*/)
        {
            try
            {
                Datos.Asiento.BorrarAsientosAgrupados(/*pCodigoAsiento*/);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
