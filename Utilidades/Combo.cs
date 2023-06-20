using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{
    public static class Combo
    {
        public static void Formato(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public static void Llenar(ComboBox combo, DataTable dt, string valor, string mostrar, string itemAgregar="", bool fecha=false)
        {
            if (dt.Rows.Count>0) { 
            
            if (!itemAgregar.Equals("")) {
                    if(fecha==false)
                        dt.Rows.Add(0, itemAgregar);
                    else
                        dt.Rows.Add("02-2200", itemAgregar);
                }
            }
            combo.DisplayMember = mostrar;
            combo.ValueMember = valor;
            combo.DataSource = dt;
        }


        public static void SeleccionarPrimerValor(ComboBox combo)
        {
            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }



        public static void SeleccionarSegundoValor(ComboBox combo)
        {
            if (combo.Items.Count > 1)
            {
                combo.SelectedIndex = 1;
            }
        }

        public static void LLenarSucursales(ComboBox combo) {

        }
    }
}