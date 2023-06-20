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
    public static class AsientoTemp
    {
        private static SqlConnection objConexion = null;
        private static string strProc = string.Empty;
        private static SqlCommand objCommand = null;
        private static SqlDataAdapter objDataAdapter = null;

        static AsientoTemp()
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
        public static int Agregar(List<Entidades.AsientoTemp> pAsientoTemp, SqlConnection conexion, SqlTransaction transaccion)
        {
            //Creo objeto conexion
            strProc = "SP_ASIENTOSTEMP_INSERT";
            objCommand = new SqlCommand(strProc, conexion);

            objCommand.Transaction = transaccion;
            objCommand.CommandType = CommandType.StoredProcedure;
            
            DataTable dtAsientoT = new DataTable();
            DataColumn column;
            column = new DataColumn();

            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Fecha";
            dtAsientoT.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CodigoCuentaContable";
            dtAsientoT.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Debe";
            dtAsientoT.Columns.Add(column);

            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Haber";
            dtAsientoT.Columns.Add(column);

            
            column = new DataColumn(); ;
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Tipo";
            dtAsientoT.Columns.Add(column);

            
            foreach (Entidades.AsientoTemp ad in pAsientoTemp)
            {
                dtAsientoT.Rows.Add(ad.Fecha, ad.CuentaContable.Codigo, ad.Debe, ad.Haber, ad.Tipo);

            }


            SqlParameter paramItems = new SqlParameter();
            paramItems.ParameterName = "@Asientos";
            paramItems.Direction = ParameterDirection.Input;
            paramItems.Value = dtAsientoT;
            paramItems.SqlDbType = SqlDbType.Structured;
            objCommand.Parameters.Add(paramItems);
            try
            {
                //conexion.Open();
                //objCommand.ExecuteNonQuery();
                return Convert.ToInt32(objCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public static DataTable Agrupacion() {
            DataTable dt = new DataTable();
            strProc = "SP_ASIENTOSTEMP_AGRUPACION";
            objDataAdapter = new SqlDataAdapter(strProc, objConexion);
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objDataAdapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }
    }
}
