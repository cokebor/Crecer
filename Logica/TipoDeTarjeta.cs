using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoDeTarjeta
    {
        public DataTable ObtenerTodosActivos()
        {
            try
            {
                return Datos.TipoDeTarjeta.ObtenerTodosActivos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        public Entidades.TipoDeTarjetas ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.TipoDeTarjeta.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        public Entidades.TipoDeTarjetas ObtenerUno(int pCodigo, Entidades.Banco pBanco)
        {
            try
            {
                return Datos.TipoDeTarjeta.ObtenerUno(pCodigo, pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
