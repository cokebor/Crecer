using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class SucursalCliente
    {
        public DataTable ObtenerNovedades()
        {
            try
            {
                return Datos.SucursalCliente.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.SucursalCliente pSCliente)
        {
            try
            {
                Datos.SucursalCliente.CambiarEstadoNovedad(pSCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AgregarDeWeb(Entidades.SucursalCliente pSCliente)
        {
            try
            {
                Datos.SucursalCliente.AgregarDeWeb(pSCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Agregar(Entidades.SucursalCliente pSCliente)
        {
            try
            {
                Datos.SucursalCliente.Agregar(pSCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
