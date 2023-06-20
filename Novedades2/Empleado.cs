using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades2
{
    public class Empleado
    {
        Entidades.Empleado objEEmpleado = new Entidades.Empleado();
        Entidades.Novedad objENovedad = new Entidades.Novedad();

        LogicaWeb.Empleado objLWEmpleado = new LogicaWeb.Empleado();
        Logica.Empleado objLEmpleado = new Logica.Empleado();
        Logica.Novedad objLNovedad = new Logica.Novedad();

        public void Enviar()
        {
            try
            {
                DataTable dtEmpleados = objLEmpleado.ObtenerNovedades();
                foreach (DataRow dr in dtEmpleados.Rows)
                {
                    objEEmpleado.Codigo = Convert.ToInt32(dr["Codigo"]);
                    objEEmpleado.Legajo = dr["Legajo"].ToString();
                    objEEmpleado.Apellido=dr["Apellido"].ToString();
                    objEEmpleado.Nombres= dr["Nombres"].ToString();
                    objEEmpleado.TipoDeDocumento = (Enumeraciones.Enumeraciones.TiposDeDocumentos)Convert.ToInt32(dr["CodigoTipoDocumento"]);
                    objEEmpleado.NumeroDocumento = dr["NumeroDocumento"].ToString();
                    objEEmpleado.Sexo = (Enumeraciones.Enumeraciones.Sexos)Convert.ToChar(dr["Sexo"]);
                    objEEmpleado.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                    objEEmpleado.Domicilio.Direccion = dr["Direccion"].ToString();
                    objEEmpleado.Domicilio.Barrio = dr["Barrio"].ToString();
                    objEEmpleado.Domicilio.CodigoPostal = dr["CodigoPostal"].ToString();
                    objEEmpleado.Domicilio.Localidad.Codigo = Convert.ToInt32(dr["CodigoLocalidad"]);
                    objEEmpleado.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                    objEEmpleado.CUIL = dr["CUIL"].ToString();
                    objEEmpleado.Puesto.Codigo= Convert.ToInt32(dr["CodigoPuesto"]);
                    objEEmpleado.EstadoCivil= (Enumeraciones.Enumeraciones.EstadosCiviles)Convert.ToChar(dr["CodigoEstadoCivil"]);
                    objEEmpleado.CantidadHijos = Convert.ToInt32(dr["CantidadHijos"]);
                    objEEmpleado.ObraSocial.Codigo = Convert.ToInt32(dr["CodigoObraSocial"]);
                    objEEmpleado.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objEEmpleado.EsEmpleado = Convert.ToBoolean(dr["EsEmpleado"]);
                    //objEEmpleado.Sueldo = Convert.ToDouble(dr["Sueldo"]);
                    objEEmpleado.Banco.Codigo = Convert.ToInt32(dr["CodigoBanco"]);

                    objLWEmpleado.Agregar(objEEmpleado, SingletonNovedad.Instancia.Empresa);
                    objLEmpleado.CambiarEstadoNovedad(objEEmpleado);
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
                objENovedad = objLNovedad.ObtenerUno("Empleados");

                DataTable dtEmpleados = objLWEmpleado.ObtenerNovedades(objENovedad.CodigoNovedad, SingletonNovedad.Instancia.Empresa);

                foreach (DataRow dr in dtEmpleados.Rows)
                {
                    //codigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objENovedad.CodigoNovedad = Convert.ToInt32(dr["CodigoNovedad"]);
                    objEEmpleado.Codigo=Convert.ToInt32(dr["Codigo"]);
                    objEEmpleado.Legajo = dr["Legajo"].ToString();
                    objEEmpleado.Apellido = dr["Apellido"].ToString();
                    objEEmpleado.Nombres = dr["Nombres"].ToString();
                    objEEmpleado.TipoDeDocumento = (Enumeraciones.Enumeraciones.TiposDeDocumentos)Convert.ToInt32(dr["CodigoTipoDocumento"]);
                    objEEmpleado.NumeroDocumento = dr["NumeroDocumento"].ToString();
                    objEEmpleado.Sexo = (Enumeraciones.Enumeraciones.Sexos)Convert.ToChar(dr["Sexo"]);
                    objEEmpleado.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                    objEEmpleado.Domicilio.Direccion = dr["Direccion"].ToString();
                    objEEmpleado.Domicilio.Barrio = dr["Barrio"].ToString();
                    objEEmpleado.Domicilio.CodigoPostal = dr["CodigoPostal"].ToString();
                    objEEmpleado.Domicilio.Localidad.Codigo = Convert.ToInt32(dr["CodigoLocalidad"]);
                    objEEmpleado.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                    objEEmpleado.CUIL = dr["CUIL"].ToString();
                    objEEmpleado.Puesto.Codigo = Convert.ToInt32(dr["CodigoPuesto2"]);
                    objEEmpleado.EstadoCivil = (Enumeraciones.Enumeraciones.EstadosCiviles)Convert.ToChar(dr["CodigoEstadoCivil"]);
                    objEEmpleado.CantidadHijos = Convert.ToInt32(dr["CantidadHijos"]);
                    objEEmpleado.ObraSocial.Codigo = Convert.ToInt32(dr["CodigoObraSocial"]);

                    objEEmpleado.EsEmpleado = Convert.ToBoolean(dr["EsEmpleado"]);
                    objEEmpleado.Sueldo = Convert.ToDouble(dr["Sueldo"]);
                    objEEmpleado.Banco.Codigo = Convert.ToInt32(dr["CodigoBanco"]);
                    objEEmpleado.Estado = (Enumeraciones.Enumeraciones.Estados)Convert.ToInt32(dr["Estado"]);

                    objLEmpleado.AgregarDeWeb(objEEmpleado);
                    objLNovedad.Actualizar(objENovedad);
                    // objLPais.CambiarEstadoNovedad(objEPais);
                }
                //objLWPais.Update(Singleton.Instancia.Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
