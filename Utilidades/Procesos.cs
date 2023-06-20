using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Utilidades
{
    public static class Procesos
    {
        public static void Iniciar(string pNombreProceso) {
            try
            {
                Process proceso = new Process();
                proceso.StartInfo.FileName = pNombreProceso;
                proceso.Start();
            }
            catch (Exception ex) {
                throw new Exception("Error al iniciar el proceso: " + ex.Message);
            }
        }


        public static void Detener(string pNombreProceso) {
            try
            {

                Process[] todosLosLocales = Process.GetProcesses();
                foreach (Process proceso in todosLosLocales) {
                    if (proceso.ProcessName.Equals(pNombreProceso)) {
                        proceso.CloseMainWindow();
                        if (!proceso.HasExited)
                        {
                            proceso.Kill();
                            proceso.Close();
                        }
                    }
                }

                /*
                Process[] procesos = Process.GetProcessesByName(pNombreProceso);
                procesos[0].CloseMainWindow();
                if (!procesos[0].HasExited)
                {
                    procesos[0].Kill();
                    procesos[0].Close();
                }*/
            }
            catch (Exception ex) {
                throw new Exception("Error al detener el proceso: " + ex.Message);
            }
        }
    }
}
