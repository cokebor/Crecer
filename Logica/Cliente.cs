using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class Cliente
    {
        public DataTable ObtenerTodos(Entidades.Sucursal pSucursal = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (pSucursal == null)
                    dt= Datos.Cliente.ObtenerTodos();
                else
                {
                    switch (pSucursal.Codigo)
                    {
                        case 1:
                            dt = Datos.Cliente.ObtenerTodos();
                            break;
                        case 2:
                            dt = DatosWiki.Cliente.ObtenerTodos();
                            break;
                        case 3:
                            dt = DatosNave7.Cliente.ObtenerTodos();
                            break;
                        case 4:
                            dt = DatosVillaMaria.Cliente.ObtenerTodos();
                            break;
                        case 5:
                            dt = DatosRioCuarto.Cliente.ObtenerTodos();
                            break;
                        case 7:
                            dt = DatosSucursal6.Cliente.ObtenerTodos();
                            break;
                        case 0:
                            dt = DatosIntegracion.Cliente.ObtenerTodos();
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

        public DataTable ObtenerActivos()
        {
            try
            {
                return Datos.Cliente.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerComunicaciones(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.Cliente.ObtenerComunicaciones(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerEmails(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.Cliente.ObtenerEmails(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerDescuentos(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.Cliente.ObtenerDescuentos(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.Cliente ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Cliente.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Cliente ObtenerUnoActivo(int pCodigo)
        {
            try
            {
                return Datos.Cliente.ObtenerUnoActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Cliente pCliente, DataTable pComunicaciones, DataTable pDescuentos)
        {
            try
            {
                Datos.Cliente.Agregar(pCliente, pComunicaciones, pDescuentos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Entidades.Cliente pCliente)
        {
            try
            {
                Datos.Cliente.Eliminar(pCliente);
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
                return Datos.Cliente.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Cliente pCliente)
        {
            try
            {
                Datos.Cliente.CambiarEstadoNovedad(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Cliente pCliente)
        {
            try
            {
                Datos.Cliente.AgregarDeWeb(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entidades.SucursalCliente> ObtenerSucursales(Entidades.Cliente objECliente)
        {
            try
            {
                return Datos.Cliente.ObtenerSucursales(objECliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
