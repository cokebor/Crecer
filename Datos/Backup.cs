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
    public static class Backup
    {
        private static SqlConnection objConexion = null;

        private static SqlCommand objCommand = null;
        private static string strProc = string.Empty;
        static Backup()
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

        public static string CrearBackups(string direccion)
        {
            strProc = "SP_BACKUPS_CREAR";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Direccion", direccion);
            try
            {
                objConexion.Open();
                //objCommand.ExecuteNonQuery();
                string res = objCommand.ExecuteScalar().ToString();
                return res;
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

        public static string ObtenerNombre()
        {
            strProc = "SP_BASEDEDATOSNOMBRE_SELECT";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objConexion.Open();
                //objCommand.ExecuteNonQuery();
                string res = objCommand.ExecuteScalar().ToString();
                return res;
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
        
        public static void CrearBackups2(string nombreBase, string direccion)
        {
            strProc = "BACKUP DATABASE " + nombreBase + " TO DISK = N'" + direccion + "' WITH NOFORMAT, NOINIT, NAME=N'" + nombreBase + " - Copia de Seguridad Completa', SKIP, STATS = 10";
            objCommand = new SqlCommand(strProc, objConexion);
            objCommand.CommandType = CommandType.Text;
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

        private static string strProc2 = string.Empty;
        private static string strProc3 = string.Empty;
        private static string strProc4 = string.Empty;
        public static void Restaurar(string nombreBase, string direccion)
        {
            strProc = "ALTER DATABASE " + nombreBase + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            strProc2 = "USE master RESTORE DATABASE " + nombreBase + " FROM DISK = N'" + direccion + "' WITH REPLACE";
            strProc3 = "ALTER DATABASE " + nombreBase + " SET MULTI_USER";
            strProc4 = "SELECT COUNT(*) FROM DBO.SYSDATABASES WHERE NAME = '" + nombreBase +"'";

            objCommand = new SqlCommand(strProc4, objConexion);
            objCommand.CommandType = CommandType.Text;

            try
            {
                objConexion.Open();

                if (Convert.ToInt32(objCommand.ExecuteScalar()) > 0)
                {
                    objCommand = new SqlCommand(strProc, objConexion);
                    objCommand.CommandType = CommandType.Text;
                    objCommand.ExecuteNonQuery();
                    objCommand = new SqlCommand(strProc2, objConexion);
                    objCommand.CommandType = CommandType.Text;
                    objCommand.ExecuteNonQuery();
                    objCommand = new SqlCommand(strProc3, objConexion);
                    objCommand.CommandType = CommandType.Text;
                    objCommand.ExecuteNonQuery();
                }
                else {
                    objCommand = new SqlCommand(strProc2, objConexion);
                    objCommand.CommandType = CommandType.Text;
                    objCommand.ExecuteNonQuery();
                }
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
        public static void CrearBackups2(string nombreBase, string direccion)
        {
            try
            {
                Server dbServer = new Server(new ServerConnection(@"COKE-NOT\SQL2012", "sa", "030302"));
                Microsoft.SqlServer.Management.Smo.Backup dbBackup = new Microsoft.SqlServer.Management.Smo.Backup() { Action = BackupActionType.Database, Database = nombreBase };
                dbBackup.Devices.AddDevice(direccion, DeviceType.File);
                dbBackup.Initialize = true;
                dbBackup.SqlBackup(dbServer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/
        /*

        public static void Restaurar(string nombreBase, string direccion)
        {
            try
            {
                Server dbServer = new Server(new ServerConnection(objConexion.DataSource, "sa", "030302"));
                Microsoft.SqlServer.Management.Smo.Restore dbRestore = new Microsoft.SqlServer.Management.Smo.Restore() { Database = nombreBase, Action = RestoreActionType.Database, ReplaceDatabase = true, NoRecovery = false };
                
                dbRestore.Devices.AddDevice(direccion, DeviceType.File);
                dbRestore.SqlRestore(dbServer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }*/
    }

}