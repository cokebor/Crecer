using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmColor : Form
    {
        static Color color;
        
        public frmColor()
        {
            InitializeComponent();

            //this.AutoScaleMode = AutoScaleMode.Dpi;

            //Color c = ColorTranslator.FromHtml("ActiveCaption");
            this.BackColor = color;
            
            // this.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }

       /* public static void Color() {
            color = ColorTranslator.FromHtml(value);
        }*/
        public static Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }
    }
}
