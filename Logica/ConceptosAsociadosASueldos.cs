using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ConceptosAsociadosASueldos
    {
        public void Agregar(Entidades.ConceptoAsociadoASueldo pConcepto)
        {
            try
            {
                Datos.ConceptosAsociadosASueldos.Agregar(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(Entidades.ConceptoAsociadoASueldo pConcepto) {
            try
            {
                Datos.ConceptosAsociadosASueldos.Eliminar(pConcepto);
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
                return Datos.ConceptosAsociadosASueldos.ObtenerTodos();
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
                return Datos.ConceptosAsociadosASueldos.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.ConceptoAsociadoASueldo ObtenerUno(int pCodigoConcepto)
        {
            try
            {
                return Datos.ConceptosAsociadosASueldos.ObtenerUno(pCodigoConcepto);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public void NoRemunerativoActualizar(Entidades.ConceptoAsociadoASueldo pConcepto)
        {
            try
            {
                Datos.ConceptosAsociadosASueldos.NoRemunerativoActualizar(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
