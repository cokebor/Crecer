using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ConciliacionesProveedores
    {
        public void Agregar(Entidades.Caja objECaja, Entidades.Asiento objEAsientoCaja, Entidades.Pago objEPagoProveedor, Entidades.Asiento objEAsientoPago)
        {
            try
            {
                Datos.ConciliacionesProveedores.Agregar(objECaja, objEAsientoCaja, objEPagoProveedor, objEAsientoPago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
