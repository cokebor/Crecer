using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Sucursal
    {
        public DataTable ObtenerTodos()
        {
            try
            {
                return Datos.Sucursal.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerLocalidades()
        {
            try
            {
                return Datos.Sucursal.ObtenerLocalidades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Sucursal.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Sucursal ObtenerSucursal(int pCodigoSucursal, int pCodigoSucursalEnviar)
        {
            try
            {
                return Datos.Sucursal.ObtenerSucursal(pCodigoSucursal, pCodigoSucursalEnviar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Sucursal ObtenerSucursal(int pCodigoSucursal)
        {
            try
            {
                return Datos.Sucursal.ObtenerSucursal(pCodigoSucursal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerSucursales()
        {
            try
            {
                return Datos.Sucursal.ObtenerSucursales();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
