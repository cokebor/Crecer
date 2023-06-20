using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Logica
{
    public class LibreDisponibilidadAsociado
    {
        public void Agregar(Entidades.Concepto pConcepto)
        {
            try
            {
                Datos.LibreDisponibilidadAsociado.Agregar(pConcepto);
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
                return Datos.LibreDisponibilidadAsociado.ObtenerAsociaciones(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.LibreDisponibilidadAsociado pConceptoAsociado)
        {
            try
            {
                Datos.LibreDisponibilidadAsociado.Eliminar(pConceptoAsociado);
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
               return Datos.LibreDisponibilidadAsociado.ObtenerAsociacionesActivas(pConcepto);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
        }

        public Entidades.LibreDisponibilidadAsociado ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.LibreDisponibilidadAsociado.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
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
        }*/
        /*

       */
        /*
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
        }*/
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
