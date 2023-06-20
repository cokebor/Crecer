using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Logica
{
    public class RetencionAsociacion
    {
        public void Agregar(Entidades.Concepto pConcepto)
        {
            try
            {
                Datos.RetencionAsociacion.Agregar(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerAsociaciones(Entidades.Concepto pConcepto)
        {
            try
            {
                return Datos.RetencionAsociacion.ObtenerAsociaciones(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerAsociacionesActivas(Entidades.Concepto pConcepto)
        {
            try
            {
                return Datos.RetencionAsociacion.ObtenerAsociacionesActivas(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Entidades.RetencionAsociado pConceptoAsociado)
        {
            try
            {
                Datos.RetencionAsociacion.Eliminar(pConceptoAsociado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.RetencionAsociado ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.RetencionAsociacion.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double ObtenerMontoUno(int pCodigoSalario, int pCodigoConcepto)
        {
            try
            {
                return Datos.ConceptoAsociado.ObtenerMontoUno(pCodigoSalario, pCodigoConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
   
    }
}
