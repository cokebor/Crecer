using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{
    public static class TabControl
    {
        public static void Formato(System.Windows.Forms.TabControl tabControl,Color pColor )
        {
            foreach (TabPage item in tabControl.TabPages)
            {
                item.BackColor = pColor;
            }
            
        }
       
       

       
    }
}