using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades
{
    public class RemitoSucursal
    {
        Entidades.RemitoSucursal_M objERemito = null;// new Entidades.RemitoSucursal_M();

        //Entidades.Provincia objEProvincia = new Entidades.Provincia();
        //Entidades.Novedad objENovedad = new Entidades.Novedad();
        

        Logica.RemitoSucursal objLRemitoSucursal = new Logica.RemitoSucursal();
        //  LogicaWeb.Provincia objLWProvincia = new LogicaWeb.Provincia();
        //Logica.Provincia objLProvincia = new Logica.Provincia();
        //  Logica.Novedad objLNovedad = new Logica.Novedad();
        LogicaWeb.RemitoSucursal objLWRemitoSucursal = new LogicaWeb.RemitoSucursal();
        public void Enviar()
        {
            try
            {
                objERemito = new Entidades.RemitoSucursal_M();

                DataTable dtRemitos = objLRemitoSucursal.ObtenerNovedades();
                foreach (DataRow dr in dtRemitos.Rows)
                {
                    objERemito.Codigo= Convert.ToInt32(dr["Codigo"]);
                    objERemito.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                    objERemito.SucursalOrigen.Codigo = Convert.ToInt32(dr["CodigoSucursalOrigen"]);
                    objERemito.SucursalDestino.Codigo = Convert.ToInt32(dr["CodigoSucursalDestino"]);
                    objERemito.NumRemito = dr["NumRemito"].ToString();

                    //Aca obtener RemitoSucursal_D_Productos List 
                    objERemito.Productos = objLRemitoSucursal.ObtenerTodos(objERemito.Codigo);

                    objLWRemitoSucursal.Agregar(objERemito);


                    objLRemitoSucursal.CambiarEstadoNovedad(objERemito);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void Recibir()
        {
            
            try
            {
                //objENovedad = objLNovedad.ObtenerUno("Provincias");

                objERemito = objLWRemitoSucursal.ObtenerNovedades(SingletonNovedad.Instancia.Empresa);

                if (objERemito != null) { 
                     objERemito.Productos = objLWRemitoSucursal.ObtenerNovedades(objERemito.Codigo);
                    objLRemitoSucursal.AgregarDeWeb(objERemito);
                    objLWRemitoSucursal.PasarABajado(objERemito.NumRemito);
                }
                
                /*

            objLNovedad.Actualizar(objENovedad);
            */

                //objLWPais.Update(Singleton.Instancia.Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
