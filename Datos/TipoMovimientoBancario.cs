using Servidor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public static class TipoMovimientoBancario
    {
        private static SqlConnection objConexion = null;
        private static SqlDataAdapter objDataAdapter = null;
        private static SqlCommand objCommand = null;
        private static SqlDataReader objDataReader = null;
        private static string strProc=string.Empty;
        static TipoMovimientoBancario()
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
        public static DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSMOVIMIENTOSBANCARIOS_SELECT";
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
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            
            return dt;
        }

        public static DataTable ObtenerAlgunos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSMOVIMIENTOSBANCARIOSALGUNOS_SELECT";
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
        public static void Agregar(Entidades.TipoMovimientoBancario pTipo)
        {
            //Creo objeto conexion
            strProc = "SP_TIPOSMOVIMIENTOSBANCARIOS_INSERT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pTipo.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pTipo.Descripcion);
            objCommand.Parameters.AddWithValue("@AfectaCuenta", pTipo.AfectaCuenta);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Tipo Movimiento Bancario, ya existe!!");
                }
                throw new Exception(sqlex.Message);
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

        public static Entidades.TipoMovimientoBancario ObtenerUno(int pCodigo)
        {
            Entidades.TipoMovimientoBancario objTipoMovimiento = new Entidades.TipoMovimientoBancario();
            strProc = "SP_TIPOMOVIMIENTOBANCARIO_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigo);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objTipoMovimiento.Codigo = Convert.ToInt32(objDataReader["Codigo"]);
                objTipoMovimiento.Descripcion = objDataReader["Descripcion"].ToString();
                objTipoMovimiento.AfectaCuenta= Convert.ToChar(objDataReader["AfectaCuenta"].ToString());
                objTipoMovimiento.ComportamientoPredeterminado= Convert.ToInt32(objDataReader["ComportamientoPredeterminado"]);

                Enumeraciones.Enumeraciones.Estados estado;

                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objTipoMovimiento.Estado = estado;

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);

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
            return objTipoMovimiento;
        }

        public static void Eliminar(Entidades.TipoMovimientoBancario pTipo)
        {
            //Creo objeto conexion
            strProc = "SP_TIPOSMOVIMIENTOSBANCARIOS_DELETE";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pTipo.Codigo);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
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

        public static DataTable ObtenerNovedades()
        {
            DataTable dt = new DataTable();
            strProc = "SP_TIPOSMOVIMIENTOSBANCARIOS_SELECT_NOVEDADES";
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

        public static void CambiarEstadoNovedad(Entidades.TipoMovimientoBancario PTipoMovimientoBancario)
        {
            strProc = "SP_TIPOSMOVIMIENTOSBANCARIOS_UPDATE_NOVEDAD";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", PTipoMovimientoBancario.Codigo);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
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

        public static void AgregarDeWeb(Entidades.TipoMovimientoBancario pTipoMovimientoBancario)
        {
            //Creo objeto conexion
            strProc = "SP_TIPOSMOVIMIENTOSBANCARIOS_INSERT_WEB";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pTipoMovimientoBancario.Codigo);
            objCommand.Parameters.AddWithValue("@Descripcion", pTipoMovimientoBancario.Descripcion);
            objCommand.Parameters.AddWithValue("@AfectaCuenta", pTipoMovimientoBancario.AfectaCuenta);
            objCommand.Parameters.AddWithValue("@Estado", pTipoMovimientoBancario.Estado);
            try
            {
                objConexion.Open();
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2601)
                {
                    throw new Exception("No se pude agregar Tipo Movimiento Bancario, ya existe!!");
                }
                throw new Exception(sqlex.Message);
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



        public static DataTable ObtenerActivos()
        {
            DataTable dt = new DataTable();
            strProc = "SP_PAISES_SELECT_ACTIVOS";
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
        public static Entidades.Pais ObtenerUno(int pCodigoPais)
        {
            Entidades.Pais objPais = new Entidades.Pais();
            strProc = "SP_PAISES_SELECT_UNO";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Codigo", pCodigoPais);
            try
            {
                objConexion.Open();
                objDataReader = objCommand.ExecuteReader();
                objDataReader.Read();
                objPais.Codigo= Convert.ToInt32(objDataReader["Codigo"]);
                objPais.Descripcion = objDataReader["Descripcion"].ToString();
                Enumeraciones.Enumeraciones.Estados estado;
                
                Enum.TryParse(Convert.ToInt32(objDataReader["Estado"]).ToString(), out estado);
                objPais.Estado = estado;

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);

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
            return objPais;
        }

       
        

       */
    }
}
