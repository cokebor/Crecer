using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Novedades
{
    public class CuentaBancaria
    {
        Entidades.CuentaBancaria objECuentaBancaria = new Entidades.CuentaBancaria();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.CuentaBancaria objLWCuentaBancaria = new LogicaWeb.CuentaBancaria();
        Logica.CuentaBancaria objLCuentaBancaria = new Logica.CuentaBancaria();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtCtaBancaria = objLCuentaBancaria.ObtenerNovedades();
                foreach (DataRow dr in dtCtaBancaria.Rows)
                {
                    objECuentaBancaria.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objECuentaBancaria.Banco.Codigo = Convert.ToInt32(dr["CodigoBanco"]);
                    objECuentaBancaria.NumeroCuenta = dr["NumeroCuenta"].ToString();
                    objECuentaBancaria.Moneda.Codigo = Convert.ToInt32(dr["CodigoMoneda"]);
                    objECuentaBancaria.Proveedor.Codigo = Convert.ToInt32(dr["CodigoProveedor"]);
                    objECuentaBancaria.CuentaContable.Codigo = (Convert.ToInt64(dr["CodigoCuentaContable"]));
                    objECuentaBancaria.CuentaContableTranferencias.Codigo = (Convert.ToInt64(dr["CodigoCuentaContableTranferencias"]));
                    objECuentaBancaria.CuentaContableValoresDiferidos.Codigo = (Convert.ToInt64(dr["CodigoCuentaContableValoresDiferidos"]));
                    objECuentaBancaria.CuentaContablePrestamos.Codigo = (Convert.ToInt64(dr["CodigoCuentaContablePrestamos"]));
                    objECuentaBancaria.CuentaContableDebitoCreditoCompras.Codigo = (Convert.ToInt64(dr["CodigoCuentaContableDebitoCreditoCompras"]));
                    objECuentaBancaria.FechaConciliacion = Convert.ToDateTime(dr["FechaConciliacion"]);
                    objECuentaBancaria.Tranferencia = Convert.ToBoolean(dr["Tranferencia"]);
                    objECuentaBancaria.DebitoCredito = Convert.ToBoolean(dr["DebitoCredito"]);
                    objECuentaBancaria.DebitoCreditoCompras = Convert.ToBoolean(dr["DebitoCreditoCompras"]);

                    objECuentaBancaria.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLWCuentaBancaria.Agregar(objECuentaBancaria, SingletonNovedad.Instancia.Empresa);
                    objLCuentaBancaria.CambiarEstadoNovedad(objECuentaBancaria);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Recibir()
        {
            try
            {
                objENovedad = objLNovedad.ObtenerUno("CuentasBancarias");

                DataTable dtCuentas = objLWCuentaBancaria.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);
                string datos = "";
                foreach (DataRow dr in dtCuentas.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objECuentaBancaria.Codigo = Convert.ToInt32(dr["CodigoCuentaBancaria"]);
                    objECuentaBancaria.Banco.Codigo = Convert.ToInt32(dr["CodigoBanco"]);
                    objECuentaBancaria.NumeroCuenta = dr["NumeroCuenta"].ToString();
                    objECuentaBancaria.Moneda.Codigo = Convert.ToInt32(dr["CodigoMoneda"]);
                    objECuentaBancaria.CuentaContable.Codigo = ObtenerCuenta(Convert.ToInt64(dr["CodigoCuentaContable"]));
                    objECuentaBancaria.CuentaContableTranferencias.Codigo = ObtenerCuenta(Convert.ToInt64(dr["CodigoCuentaContableTranferencias"]));
                    objECuentaBancaria.CuentaContableValoresDiferidos.Codigo = (Convert.ToInt64(dr["CodigoCuentaContableValoresDiferidos"]));
                    objECuentaBancaria.CuentaContablePrestamos.Codigo = (Convert.ToInt64(dr["CodigoCuentaContablePrestamos"]));
                    objECuentaBancaria.CuentaContableDebitoCreditoCompras.Codigo = (Convert.ToInt64(dr["CodigoCuentaContableDebitoCreditoCompras"]));
                    objECuentaBancaria.Proveedor.Codigo = Convert.ToInt32(dr["CodigoProveedor"]);
                    objECuentaBancaria.FechaConciliacion = Convert.ToDateTime(dr["FechaConciliacion"]);
                    objECuentaBancaria.Tranferencia = Convert.ToBoolean(dr["Tranferencia"]);
                    objECuentaBancaria.DebitoCredito = Convert.ToBoolean(dr["DebitoCredito"]);
                    objECuentaBancaria.DebitoCreditoCompras = Convert.ToBoolean(dr["DebitoCreditoCompras"]);

                    objECuentaBancaria.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLCuentaBancaria.AgregarDeWeb(objECuentaBancaria);
                    objLNovedad.Actualizar(objENovedad);
                    datos = objECuentaBancaria.ToString();
                    // objLPais.CambiarEstadoNovedad(objEPais);
                }
                return datos;
                //objLWPais.Update(Singleton.Instancia.Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Int64 ObtenerCuenta(Int64 pCodigoCuentaBancaria)
        {
            try
            {
                Int64 int64Cuenta = pCodigoCuentaBancaria;
                string strCuenta = int64Cuenta.ToString();
                int intValor = Convert.ToInt32(strCuenta.Substring(9, 2));
                if (intValor > 0)
                {
                    strCuenta = strCuenta.Remove(9, 2);
                    strCuenta += Numero().ToString("00");
                }
                else
                {
                    intValor = Convert.ToInt32(strCuenta.Substring(7, 2));
                    if (intValor > 0)
                    {
                        strCuenta = strCuenta.Remove(7, 4);
                        strCuenta += Numero().ToString("00") + "00";
                    }
                    else
                    {
                        intValor = Convert.ToInt32(strCuenta.Substring(5, 2));
                        if (intValor > 0)
                        {
                            strCuenta = strCuenta.Remove(5, 6);
                            strCuenta += Numero().ToString("00") + "0000";
                        }
                        else
                        {
                            intValor = Convert.ToInt32(strCuenta.Substring(3, 2));
                            if (intValor > 0)
                            {
                                strCuenta = strCuenta.Remove(3, 8);
                                strCuenta += Numero().ToString("00") + "000000";
                            }
                        }
                    }
                }
                return Convert.ToInt64(strCuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private int Numero()
        {
            int intValor = 0;
            switch (SingletonNovedad.Instancia.Empresa.Codigo)
            {
                case 2:
                    intValor = 7;
                    break;
                case 3:
                    intValor = 3;
                    break;
                case 4:
                    intValor = 4;
                    break;
                case 5:
                    intValor = 5;
                    break;
                case 7:
                    intValor = 6;
                    break;
            }
            return intValor;
        }
    }
}
