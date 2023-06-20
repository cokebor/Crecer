using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{
    public static class Permisos
    {
        public static void Deshabilitar(MenuStrip menuStrip)
        {
            foreach (ToolStripMenuItem menu in menuStrip.Items)
            {
                menu.Enabled = false;

                /*
                foreach (ToolStripMenuItem submenu in menu.DropDownItems)
                {
                    submenu.Enabled = false;
                }*/
                if (menu.GetType().ToString().Equals("System.Windows.Forms.ToolStripMenuItem"))
                {
                    foreach (ToolStripItem submenu in menu.DropDownItems)
                    {
                        ToolStripMenuItem submenus;
                        if (submenu.GetType().ToString().Equals("System.Windows.Forms.ToolStripMenuItem"))
                        {
                            submenus = (ToolStripMenuItem)submenu;
                            submenus.Enabled = false;
                            foreach (ToolStripMenuItem submenu2 in submenus.DropDownItems)
                            {


                                if (submenu2.GetType().ToString().Equals("System.Windows.Forms.ToolStripMenuItem"))
                                {
                                    submenu2.Enabled = false;
                                }
                            }

                        }
                    }
                }
            }
        }
        
        public static void Habilitar(DataTable dataTable, MenuStrip menuStrip)
        {
            String menus = string.Empty;


            foreach (DataRow drPermisos in dataTable.Rows)
            {
                foreach (ToolStripMenuItem menu in menuStrip.Items)
                {
                    menus = menu.ToString().Substring(0, menu.ToString().Length);

                    if (menus.Substring(0, 1).Equals("&"))
                    {
                        menus = menus.Substring(1, menus.Length - 1);
                    }
                    if (menus.Equals(drPermisos["GrupoMenu"]))
                    {
                        menu.Enabled = true;
                    }
                    foreach (ToolStripItem submenu in menu.DropDownItems)
                    {
                        if (submenu.GetType().ToString().Equals("System.Windows.Forms.ToolStripMenuItem"))
                        {

                            menus = submenu.ToString().Substring(0, submenu.ToString().Length);

                            if (menus.Substring(0, 1).Equals("&"))
                            {
                                menus = menus.Substring(1, menus.Length - 1);
                            }
                            if (menus.Equals(drPermisos["Menu"]))
                            {
                                submenu.Enabled = true;
                            }
                            //desde aca

                            //hasta aca
                        }
                    }
                }
            }
        }


        /*
        public static void HabilitarMenu(DataTable dataTable, MenuStrip menuStrip) {
            String menus = string.Empty;
            foreach (DataRow drPermisos in dataTable.Rows)
            {
                foreach (ToolStripMenuItem menu in menuStrip.Items)
                {
                    menus = menu.ToString().Substring(0, menu.ToString().Length);

                    if (menus.Substring(0, 1).Equals("&"))
                    {
                        menus = menus.Substring(1, menus.Length - 1);
                    }
                    if (menus.Equals(drPermisos["GrupoMenu"]))
                    {
                        menu.Enabled = true;
                    }
                    if (menu.DropDownItems.Count > 0)
                    {
                        RecorrerSubMenu(menu.DropDownItems, drPermisos);
                    }
                }
            }
        }*/
        
        public static void HabilitarMenu(DataTable dataTable, MenuStrip menuStrip)
        {
            String menus = string.Empty;
            foreach (DataRow drPermisos in dataTable.Rows)
            {
                foreach (ToolStripMenuItem menu in menuStrip.Items)
                {
                    menus = menu.ToString().Substring(0, menu.ToString().Length);

                    if (menus.Substring(0, 1).Equals("&"))
                    {
                        menus = menus.Substring(1, menus.Length - 1);
                    }
                    if (menus.Equals(drPermisos["GrupoMenu"]))
                    {
                        menu.Enabled = true;
                    }
                    if (menu.DropDownItems.Count > 0)
                    {
                        RecorrerSubMenu(menu.DropDownItems, drPermisos);
                    }
                }
            }
        }
        private static void RecorrerSubMenu(ToolStripItemCollection submenu, DataRow drPermisos)
        {
            String menus = string.Empty;
            foreach (ToolStripItem sub in submenu)
            {
                if (sub.GetType().ToString().Equals("System.Windows.Forms.ToolStripMenuItem"))
                {
                    menus = sub.ToString().Substring(0, sub.ToString().Length);

                    if (menus.Substring(0, 1).Equals("&"))
                    {
                        menus = menus.Substring(1, menus.Length - 1);
                    }
                    if (menus.Equals(drPermisos["Menu"]))
                    {
                        sub.Enabled = true;
                    }
                    if (((ToolStripMenuItem)sub).DropDownItems.Count > 0) {
                        RecorrerSubMenu(((ToolStripMenuItem)sub).DropDownItems, drPermisos);
                    }
                }
            }
        }


        public static void HabilitarVer(DataTable dataTable, MenuStrip menuStrip,Button botonComprobantes)
        {
            String menus = string.Empty;
            String menus2 = string.Empty;
            String grupoMenu = string.Empty;

            //    foreach (DataRow drPermisos in dataTable.Rows)
            //   {
            foreach (ToolStripMenuItem menu in menuStrip.Items)
                {
                    grupoMenu = menu.ToString().Substring(0, menu.ToString().Length);
                    //MessageBox.Show(menus);                    

                    if (grupoMenu.Substring(0, 1).Equals("&"))
                    {
                        grupoMenu = grupoMenu.Substring(1, grupoMenu.Length - 1);
                    }
                    foreach (ToolStripItem submenu in menu.DropDownItems)
                    {
                        ToolStripMenuItem submenus;
                       if (submenu.GetType().ToString().Equals("System.Windows.Forms.ToolStripMenuItem"))
                        {
                        submenus = (ToolStripMenuItem)submenu;
                        menus = submenu.ToString().Substring(0, submenu.ToString().Length);
                        if (menus.Substring(0, 1).Equals("&"))
                        {
                            menus = menus.Substring(1, menus.Length - 1);
                        }

                        foreach (DataRow drPermisos in dataTable.Rows)
                        {


                            if (menus.Equals(drPermisos["Menu"]) && grupoMenu.Equals(drPermisos["GrupoMenu"]))
                            {
                                menu.Enabled = true;
                                submenu.Enabled = true;
                                //  submenu2.Enabled = true;
                                if (submenu.Text.Equals("Comprobantes de Venta Manuales")) {
                                    botonComprobantes.Enabled = true;
                                    botonComprobantes.Visible = true;
                                }
                            }
                        }


                        foreach (ToolStripItem submenu2 in submenus.DropDownItems) {
                            if (submenu2.GetType().ToString().Equals("System.Windows.Forms.ToolStripMenuItem"))
                            {
                                menus2 = submenu2.ToString().Substring(0, submenu2.ToString().Length);
                                if (menus2.Substring(0, 1).Equals("&"))
                                {
                                    menus2 = menus2.Substring(1, menus2.Length - 1);
                                }
                                foreach (DataRow drPermisos in dataTable.Rows)
                                {


                                    if (menus2.Equals(drPermisos["Menu"]) && grupoMenu.Equals(drPermisos["GrupoMenu"]))
                                    {
                                        menu.Enabled = true;
                                        submenu.Enabled = true;
                                        submenu2.Enabled = true;
                                        if (submenu2.Text.Equals("Comprobantes de Venta Manuales"))
                                        {
                                            botonComprobantes.Enabled = true;
                                            botonComprobantes.Visible = true;
                                        }
                                    }
                                }
                            }
                            }

                    }
                    }

                    /*  if (grupoMenu.Equals(drPermisos["GrupoMenu"]))
                      {
                          menu.Enabled = true;
                          foreach (ToolStripItem submenu in menu.DropDownItems)
                          {
                              if (submenu.GetType().ToString().Equals("System.Windows.Forms.ToolStripMenuItem"))
                              {

                                  menus = submenu.ToString().Substring(0, submenu.ToString().Length);

                                  if (menus.Substring(0, 1).Equals("&"))
                                  {
                                      menus = menus.Substring(1, menus.Length - 1);
                                  }

                                  if (menus.Equals(drPermisos["Menu"]) && grupoMenu.Equals(drPermisos["GrupoMenu"]))
                                  {
                                      submenu.Enabled = true;

                                  }

                              }
            //              }
                      }


                  }*/
                }
        }
    }
}
