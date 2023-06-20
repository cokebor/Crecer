using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaWeb
{
    public class Prueba
    {
        public bool Resultado()
        {
            try
            {
                return DatosWeb.Prueba.Resultado();
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
                return DatosWeb.Prueba.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
