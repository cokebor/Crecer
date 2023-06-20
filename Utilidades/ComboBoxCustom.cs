using System.Drawing;
using System.Windows.Forms;

namespace Utilidades
{
    public class ComboBoxCustom : ComboBox
    {
        public ComboBoxCustom()
        {
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            base.OnDrawItem(e);
            if (e.Index < 0) { return; }
            e.DrawBackground();
            ComboBoxItem item = (ComboBoxItem)this.Items[e.Index];
            Brush brush = new SolidBrush(item.ForeColor);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { brush = Brushes.White; }
            e.Graphics.DrawString(item.Text,
                this.Font, brush, e.Bounds.X, e.Bounds.Y);

        }
        object selectedValue = null;
        public new object SelectedValue
        {
            get
            {
                object ret = null;
                if (this.SelectedIndex >= 0)
                {
                    ret = ((ComboBoxItem)this.selectedValue).Value;
                }
                return ret;
            }
            set { selectedValue = value; }
        }/*
        string selectedText = "";
        public new string SelectedText
        {
            get
            {
                return ((ComboBoxItem)this.SelectedItem).Text;
            }
            set { selectedText = value; }
        }*/
    }
    public class ComboBoxItem
    {
        public ComboBoxItem() { }

        public ComboBoxItem(string pText, object pValue)
        {
            text = pText; val = pValue;
        }

        public ComboBoxItem(string pText, object pValue, Color pColor)
        {
            text = pText; val = pValue; foreColor = pColor;
        }

        public void CambiarColor(Color pColor)
        {
            foreColor = pColor;
        }

        string text = "";
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        object val;
        public object Value
        {
            get { return val; }
            set { val = value; }
        }

        Color foreColor = Color.Black;
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        public override string ToString()
        {
            return text;
        }
    }

}
