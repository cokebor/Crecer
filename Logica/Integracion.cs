using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Integracion
    {
        public void EliminarDatos(Entidades.Integracion pIntegracion)
        {
            try
            {
                DatosIntegracion.Integracion.EliminarDatos(pIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarDatosDeposito(Entidades.Integracion pIntegracion)
        {
            try
            {
                Datos.Integracion.InsertarDatos(pIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarDatosNave7(Entidades.Integracion pIntegracion)
        {
            try
            {
                DatosNave7.Integracion.InsertarDatos(pIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarDatosVillaMaria(Entidades.Integracion pIntegracion)
        {
            try
            {
                DatosVillaMaria.Integracion.InsertarDatos(pIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarDatosRioCuarto(Entidades.Integracion pIntegracion)
        {
            try
            {
                DatosRioCuarto.Integracion.InsertarDatos(pIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarDatosSucursal6(Entidades.Integracion pIntegracion)
        {
            try
            {
                DatosSucursal6.Integracion.InsertarDatos(pIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarDatosWiki(Entidades.Integracion pIntegracion)
        {
            try
            {
                DatosWiki.Integracion.InsertarDatos(pIntegracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
