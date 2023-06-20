using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public static class ListView
    {
        public static void Formato(System.Windows.Forms.ListView list, bool CheckBox)
        {
            list.CheckBoxes = CheckBox;
            list.GridLines = true;
            list.View = System.Windows.Forms.View.Details;
        } 
    }
}
