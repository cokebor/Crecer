using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class Devengamiento
    {
        public void Agregar(Entidades.Devengamiento pDevengamiento, Entidades.Caja pCaja)
        {
            try
            {
                Datos.Devengamiento.Agregar(pDevengamiento, pCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerAlgunos(int pCodigoDevengamiento)
        {
            try
            {
                return Datos.Devengamiento.ObtenerAlgunos(pCodigoDevengamiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public int ObtenerUno(int pCodigoSalario, int pCodigoConcepto)
        {
            try
            {
                return Datos.Devengamiento.ObtenerUno(pCodigoSalario, pCodigoConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.Devengamiento ObtenerUno(int pCodigoDevengamiento)
        {
            try
            {
                return Datos.Devengamiento.ObtenerUno(pCodigoDevengamiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable Obtener(Entidades.Concepto objEConcepto, DateTime pDesde, DateTime pHasta, bool pSoloPendientesDePago)
        {
            try
            {
                return Datos.Devengamiento.Obtener(objEConcepto, pDesde, pHasta, pSoloPendientesDePago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDetalle(int pCodigoDevengamiento)
        {
            try
            {
                return Datos.Devengamiento.ObtenerDetalle(pCodigoDevengamiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Anular(Entidades.Devengamiento pDevengamiento)
        {
            try
            {
                Datos.Devengamiento.Anular(pDevengamiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ValidarExistencia(Entidades.Devengamiento pDevengamiento)
        {
            try
            {
                return Datos.Devengamiento.ValidarExistencia(pDevengamiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
