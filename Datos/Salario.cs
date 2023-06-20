using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class Salario
    {
        private static SqlConnection objConexion = null;
        //private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        //private static SqlDataReader objDataReader = null;
        static Salario()
        {
            try
            {
                objConexion = new SqlConnection(BaseDatos.StringConexion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int Agregar(List<Entidades.Salario> listaSalarios, Entidades.Caja objECaja, Entidades.Asiento objEAsiento)
        {
            strProc = "SP_SALARIOSNUEVO_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@Fecha", objEAsiento.Fecha);
            objCommand.Parameters.AddWithValue("@Descripcion", objEAsiento.Descripcion);
            objCommand.Parameters.AddWithValue("@Sucursal", objEAsiento.Sucursal);

            objCommand.Parameters.AddWithValue("@CodigoTipoDocumentoCaja", objECaja.TipoDocumentoCaja.Codigo);
            objCommand.Parameters.AddWithValue("@Letra", objECaja.Letra);
            objCommand.Parameters.AddWithValue("@PuntoDeVenta", objECaja.PuntoDeVenta);
            objCommand.Parameters.AddWithValue("@Numero", objECaja.Numero);
            objCommand.Parameters.AddWithValue("@Observaciones", objECaja.Observaciones);
            objCommand.Parameters.AddWithValue("@CodigoUsuario", objECaja.Usuario.Codigo);
            objCommand.Parameters.AddWithValue("@CodigoPuestoCaja", objECaja.PuestoCaja.Codigo);



            #region Detalle
            DataTable dtDetalle = new DataTable();
            DataColumn column;

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Renglon";
            dtDetalle.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "CodigoCuentaContable";
            dtDetalle.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Debe";
            dtDetalle.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Haber";
            dtDetalle.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoCheque";
            dtDetalle.Columns.Add(column);

            int contador = 1;
            foreach (Entidades.Asiento_Detalle ad in objEAsiento.Detalle)
            {
                dtDetalle.Rows.Add(contador++, ad.CuentaContable.Codigo, ad.Debe, ad.Haber,0);

            }

            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@AsientosDetalle";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtDetalle;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);

            #endregion

            #region Efectivo

            if (objECaja.FacturaEfectivo.Count > 0)
            {
                DataTable dtEfectivo = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtEfectivo.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoMoneda";
                dtEfectivo.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Cotizacion";
                dtEfectivo.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtEfectivo.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Factura_Efectivo fe in objECaja    .FacturaEfectivo)
                {
                    dtEfectivo.Rows.Add(contador++, fe.Moneda.Codigo, fe.Moneda.Cotizacion, -fe.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Efectivo";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtEfectivo;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            #region Tranferencias
            if (objECaja.Tranferencias.Count > 0)
            {
                DataTable dtTranferencias = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoBanco";
                dtTranferencias.Columns.Add(column);


                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoCuentaBancaria";
                dtTranferencias.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtTranferencias.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Tranferencia tra in objECaja.Tranferencias)
                {
                    dtTranferencias.Rows.Add(contador++, tra.Banco.Codigo, tra.CuentaBancaria.Codigo, tra.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Transferencias";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtTranferencias;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            #region Salarios
            if (listaSalarios.Count > 0)
            {
                DataTable dtSalarios = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "CodigoTipoSalario";
                dtSalarios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Periodo";
                dtSalarios.Columns.Add(column);


                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "CodigoEmpleado";
                dtSalarios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int16");
                column.ColumnName = "CodigoFormaPago";
                dtSalarios.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "Fecha";
                dtSalarios.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Monto";
                dtSalarios.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Salario sal in listaSalarios)
                {
                    dtSalarios.Rows.Add(sal.TipoSalario.Codigo, sal.Periodo, sal.Empleado.Codigo,sal.FormaDePago.Codigo, sal.Fecha, sal.Monto);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Salarios";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtSalarios;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion

            #region Detalle
            if (objECaja.Detalle.Count > 0)
            {
                DataTable dtDetalle2 = new DataTable();

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Renglon";
                dtDetalle2.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Int64");
                column.ColumnName = "CodigoCuentaContable";
                dtDetalle2.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Descripcion";
                dtDetalle2.Columns.Add(column);

                column = new DataColumn(); ;
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Importe";
                dtDetalle2.Columns.Add(column);

                contador = 1;
                foreach (Entidades.Caja_Detalle cd in objECaja.Detalle)
                {
                    dtDetalle2.Rows.Add(contador++,cd.CodigoCuentaContable, cd.Descripcion, cd.Importe);
                }

                paramItems = new SqlParameter();
                paramItems.ParameterName = "@Detalle";
                paramItems.Direction = ParameterDirection.Input;
                paramItems.Value = dtDetalle2;
                paramItems.SqlDbType = SqlDbType.Structured;
                objCommand.Parameters.Add(paramItems);
            }
            #endregion
            try
            {
                objConexion.Open();
                //objCommand.ExecuteNonQuery();
                return Convert.ToInt32(objCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }

        /*
        public static int Agregar(Entidades.Salario pSalario)
        {
            //Creo objeto conexion
            strProc = "SP_SALARIOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Fecha", pSalario.Fecha);
            objCommand.Parameters.AddWithValue("@CodigoTipoSalario", pSalario.TipoSalario.Codigo);
            objCommand.Parameters.AddWithValue("@Periodo", pSalario.Periodo);
            objCommand.Parameters.AddWithValue("@CodigoEmpleado", pSalario.Empleado.Codigo);
            objCommand.Parameters.AddWithValue("@Monto", pSalario.Monto);



            DataTable dtProductos = new DataTable();
            DataColumn column;
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoConceptoSalario";
            dtProductos.Columns.Add(column);
            
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Descripcion";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Unidades";
            dtProductos.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Monto";
            dtProductos.Columns.Add(column);

            foreach (Entidades.SalarioDetalle sd in pSalario.SalarioDetalle)
            {
                dtProductos.Rows.Add(sd.ConceptoSalario.Codigo, sd.Descripcion, sd.Unidades, sd.Monto);
            }


            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Detalle";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtProductos;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);


            try
            {
                objConexion.Open();
                //objCommand.ExecuteNonQuery();
                return Convert.ToInt32(objCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }
        */
    }
}
