using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Salario
    {
        /*
        public int Agregar(Entidades.Salario pSalario)
        {
            try
            {
                return Datos.Salario.Agregar(pSalario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/
        public int Agregar(List<Entidades.Salario> listaSalarios, Entidades.Caja objECaja, Entidades.Asiento objEAsiento)
        {
            try
            {
                return Datos.Salario.Agregar(listaSalarios, objECaja, objEAsiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
