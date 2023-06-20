using System;
using System.Data;

namespace Logica
{
    public class Concepto
    {
        public DataTable ObtenerTodos() {
            try
            {
                return Datos.Concepto.ObtenerTodos();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerActivos()
        {
            try
            {
                return Datos.Concepto.ObtenerActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.Concepto ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Concepto.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Agregar(Entidades.Concepto pConcepto) {
            try
            {
                Datos.Concepto.Agregar(pConcepto);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        
        public void Eliminar(Entidades.Concepto pConcepto)
        {
            try
            {
                Datos.Concepto.Eliminar(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*public int Asociar(Entidades.Concepto pConcepto)
        {
            try
            {
                return Datos.Concepto.Asociar(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/
        public void EliminarCuentasAsociadas(Entidades.Concepto pConcepto)
        {
            try
            {
                Datos.Concepto.EliminarCuentasAsociadas(pConcepto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
