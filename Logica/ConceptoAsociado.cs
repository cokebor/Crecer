using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Logica
{
    public class ConceptoAsociado
    {
        public void Agregar(Entidades.Concepto pConcepto)
        {
            try
            {
                Datos.ConceptoAsociado.Agregar(pConcepto);
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
                return Datos.ConceptoAsociado.ObtenerAsociaciones(pConcepto);
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
                return Datos.ConceptoAsociado.ObtenerAsociacionesActivas(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerAsociacionesActivasParaPagos(Entidades.Concepto pConcepto)
        {
            try
            {
                return Datos.ConceptoAsociado.ObtenerAsociacionesActivasParaPagos(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Entidades.ConceptoAsociado pConceptoAsociado)
        {
            try
            {
                Datos.ConceptoAsociado.Eliminar(pConceptoAsociado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.ConceptoAsociado ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.ConceptoAsociado.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double ObtenerMontoUno(int pCodigoDevengamiento, int pCodigoConcepto)
        {
            try
            {
                return Datos.ConceptoAsociado.ObtenerMontoUno(pCodigoDevengamiento, pCodigoConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /* public void Agregar(Entidades.ConceptoAsociadoASueldo pConcepto)
         {
             try
             {
                 Datos.ConceptoAsociadoASueldo.Agregar(pConcepto);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

         public DataTable ObtenerTodos()
         {
             try
             {
                 return Datos.ConceptoAsociadoASueldo.ObtenerTodos();
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

         public void Eliminar(Entidades.ConceptoAsociadoASueldo pConcepto)
         {
             try
             {
                 Datos.ConceptoAsociadoASueldo.Eliminar(pConcepto);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }
         public Entidades.ConceptoAsociadoASueldo ObtenerUno(int pCodigo)
         {
             try
             {
                 return Datos.ConceptoAsociadoASueldo.ObtenerUno(pCodigo);
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
                 return Datos.ConceptoAsociadoASueldo.ObtenerUno(pCodigoSalario,pCodigoConcepto);
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
                 return Datos.ConceptoAsociadoASueldo.ObtenerMontoUno(pCodigoSalario, pCodigoConcepto);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }*/
    }
}
