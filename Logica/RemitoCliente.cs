using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class RemitoCliente
    {
        public int Agregar(Entidades.RemitoCliente_M pRemito)
        {
            try
            {
                return Datos.RemitoCliente.Agregar(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodos(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.RemitoCliente.ObtenerTodos(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosSinLiquidar(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.RemitoCliente.ObtenerTodosSinLiquidar(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodosPorFecha(Entidades.Cliente pCliente, DateTime pDesde, DateTime pHasta) {
            try
            {
                return Datos.RemitoCliente.ObtenerTodosPorFecha(pCliente, pDesde, pHasta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Entidades.RemitoCliente_M ObtenerUno(int pCodigo)
        {
            try
            {
                return Datos.RemitoCliente.ObtenerUno(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entidades.RemitoCliente_M ObtenerUnoParaLiquidar(int pCodigo)
        {
            try
            {
                return Datos.RemitoCliente.ObtenerUnoParaLiquidar(pCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerDataTable(int pCodigoRemito) {
            try
            {
                return Datos.RemitoCliente.ObtenerDataTable(pCodigoRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDataTableDetalle(int pCodigoRemito) {
            try
            {
                return Datos.RemitoCliente_D_Productos.ObtenerDataTable(pCodigoRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Entidades.RemitoCliente_M pRemito) {
            try
            {
                Datos.RemitoCliente.Eliminar(pRemito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerTodosDataTable(DateTime desde, DateTime hasta, Entidades.Cliente pCliente, Entidades.RubroProducto pRubro, Entidades.Producto pProducto, Entidades.Lote pLote)
        {
            try
            {
                return Datos.RemitoCliente.ObtenerTodosDataTable(desde, hasta, pCliente, pRubro, pProducto, pLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerTodosPorClienteParaLiquidar(Entidades.Cliente pCliente)
        {
            try
            {
                return Datos.RemitoCliente.ObtenerTodosPorClienteParaLiquidar(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
