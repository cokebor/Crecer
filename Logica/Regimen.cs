using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Regimen
    {
        public DataTable ObtenerTodos() {
            try
            {
                return Datos.Regimen.ObtenerTodos();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

/*        public DataTable ObtenerActivosDeCuentasActivas()
        {
            try
            {
                return Datos.Banco.ObtenerActivosDeCuentasActivas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        /*
        public DataTable ObtenerCuentaDebitoCredito()
        {
            try
            {
                return Datos.Banco.ObtenerCuentaDebitoCredito();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        /*
        public Entidades.Banco ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.Banco.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        *//*
        public Entidades.Banco ObtenerUnoActivo(int pCodigo)
        {
            try
            {
                return Datos.Banco.ObtenerUnoActivo(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/
        /*
        public void Agregar(Entidades.Banco pBanco) {
            try
            {
                Datos.Banco.Agregar(pBanco);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        *//*
        public void Eliminar(Entidades.Banco pBanco)
        {
            try
            {
                Datos.Banco.Eliminar(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerNovedades()
        {
            try
            {
                return Datos.Banco.ObtenerNovedades();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CambiarEstadoNovedad(Entidades.Banco pBanco)
        {
            try
            {
                Datos.Banco.CambiarEstadoNovedad(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarDeWeb(Entidades.Banco pBanco)
        {
            try
            {
                Datos.Banco.AgregarDeWeb(pBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
    }
}
