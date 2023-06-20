using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilidades
{
    public static class Grilla
    {
        public static void Formato(DataGridView dg) {
        //Apariencia
            //Color de fondo
            dg.BackgroundColor = SystemColors.AppWorkspace;
            //Tipo de Borde
            dg.BorderStyle = BorderStyle.FixedSingle;
            //Color de lineas de cuadricola
            dg.GridColor = SystemColors.ControlDark;
            //dg.GridColor = Color.SkyBlue;
            //Indica si se muestran los encabezados de las filas
            dg.RowHeadersVisible = false;

            
            //Color de fila seleccionada
            //dg.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dg.DefaultCellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;


            //Color de Letra seleccionada
            // dg.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dg.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
            //Comportamiento
            //Indica si mostramos al usuario la opcion agregar fias
            dg.AllowUserToAddRows = false;
            //Indica si el usuario puede eliminar filas
            dg.AllowUserToDeleteRows = false;
            //Indica si el usuario puede cambiar el orden de las columnas
            dg.AllowUserToOrderColumns = true;
            //Indica si los usuarios pueden cambiar el tamaño de la columna
            dg.AllowUserToResizeColumns = false;
            //Indica si los usuarios pueden cambiar el tamaño de las filas
            dg.AllowUserToResizeRows = false;
            //Indica si se pueden seleccionar mas de una celda, fila o columna
            dg.MultiSelect = false;
            //Indica si se pueden modificar los valores de las celdas
            //dg.ReadOnly = true;
            foreach (DataGridViewColumn dgvr in dg.Columns) {
                dgvr.ReadOnly = true;
            }
            //Forma de seleccion de filas
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Diseño
            //Modo de ajuste automatico de las columnas


            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }

        public static void Formato(DataGridView dg,Color c)
        {
            //Apariencia
            //Color de fondo
            dg.BackgroundColor = SystemColors.AppWorkspace;
            //Tipo de Borde
            dg.BorderStyle = BorderStyle.FixedSingle;
            //Color de lineas de cuadricola
            dg.GridColor = SystemColors.ControlDark;
            //Indica si se muestran los encabezados de las filas
            dg.RowHeadersVisible = false;


            //Color de fila seleccionada
            dg.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            //Color de Letra seleccionada
            dg.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            //Comportamiento
            //Indica si mostramos al usuario la opcion agregar fias
            dg.AllowUserToAddRows = false;
            //Indica si el usuario puede eliminar filas
            dg.AllowUserToDeleteRows = false;
            //Indica si el usuario puede cambiar el orden de las columnas
            dg.AllowUserToOrderColumns = true;
            //Indica si los usuarios pueden cambiar el tamaño de la columna
            dg.AllowUserToResizeColumns = true;
            //Indica si los usuarios pueden cambiar el tamaño de las filas
            dg.AllowUserToResizeRows = false;
            //Indica si se pueden seleccionar mas de una celda, fila o columna
            dg.MultiSelect = false;
            //Indica si se pueden modificar los valores de las celdas
            dg.ReadOnly = true;
            //Forma de seleccion de filas
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Diseño
            //Modo de ajuste automatico de las columnas
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            

            dg.BackgroundColor = c;


            dg.BorderStyle = BorderStyle.None;
            dg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dg.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Highlight;
            dg.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Transparent;
            dg.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Transparent;
            dg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dg.EnableHeadersVisualStyles = false;

            dg.RowHeadersDefaultCellStyle.BackColor = Color.Red;
            dg.RowHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            dg.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dg.RowHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dg.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.RowHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            




            dg.GridColor = Color.SkyBlue;

            /*Highlight*/
        }
        public static void DataGridView_Inahabilitar(DataGridView dg) {
            dg.Enabled = false;
            dg.ClearSelection();
        }

        public static void DataGridView_Habilitar(DataGridView dg)
        {
            dg.Enabled = true;
        }

        public static DataTable ObtenerDataTable(DataGridView grilla) {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn columna in grilla.Columns)
            {
                //dt.Columns.Add(columna.HeaderText);
                dt.Columns.Add(columna.Name);
            }
            foreach (DataGridViewRow fila in grilla.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    // string a = celda.ValueType.ToString();
                    
                        dRow[celda.ColumnIndex] = celda.Value;

                }
                dt.Rows.Add(dRow);
            }
            return dt;
        }
    }
}
