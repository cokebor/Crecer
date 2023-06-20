using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Empresa
    {
        public Entidades.Empresa Obtener()
        {
            try
            {
                return Datos.Empresa.Obtener();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDataTable(Entidades.Sucursal pSucursal = null) {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt= Datos.Empresa.ObtenerDataTable();
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Empresa.ObtenerDataTable();
                            break;
                        case 2:
                            dt = DatosWiki.Empresa.ObtenerDataTable();
                            break;
                        case 3:
                            dt = DatosNave7.Empresa.ObtenerDataTable();
                            break;
                        case 4:
                            dt = DatosVillaMaria.Empresa.ObtenerDataTable();
                            break;
                        case 5:
                            dt = DatosRioCuarto.Empresa.ObtenerDataTable();
                            break;
                        case 7:
                            dt = DatosSucursal6.Empresa.ObtenerDataTable();
                            break;
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizaLogo(byte[] pImagen)
        {
            try
            {
                Datos.Empresa.ActualizaLogo(pImagen);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarImpresoras(int pCodigoUsuario,string pImpresoraComprobantes,bool pTermica ,string pImpresoraInformes)
        {
            try
            {
                Datos.Empresa.ActualizarImpresoras(pCodigoUsuario, pImpresoraComprobantes,pTermica, pImpresoraInformes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
