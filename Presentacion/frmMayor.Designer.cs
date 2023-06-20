namespace Presentacion
{
    partial class frmMayor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbCuentaContable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAsientos = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCuentaContable
            // 
            this.cbCuentaContable.FormattingEnabled = true;
            this.cbCuentaContable.Location = new System.Drawing.Point(66, 11);
            this.cbCuentaContable.Name = "cbCuentaContable";
            this.cbCuentaContable.Size = new System.Drawing.Size(314, 21);
            this.cbCuentaContable.TabIndex = 361;
            this.cbCuentaContable.SelectedIndexChanged += new System.EventHandler(this.cbCuentaContable_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 360;
            this.label1.Text = "Cuenta:";
            // 
            // dgvAsientos
            // 
            this.dgvAsientos.AllowUserToAddRows = false;
            this.dgvAsientos.AllowUserToDeleteRows = false;
            this.dgvAsientos.AllowUserToResizeRows = false;
            this.dgvAsientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAsientos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAsientos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Numero,
            this.Concepto,
            this.Debe,
            this.Haber,
            this.Saldo});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsientos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAsientos.EnableHeadersVisualStyles = false;
            this.dgvAsientos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvAsientos.Location = new System.Drawing.Point(10, 39);
            this.dgvAsientos.MultiSelect = false;
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsientos.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAsientos.RowHeadersVisible = false;
            this.dgvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientos.Size = new System.Drawing.Size(833, 436);
            this.dgvAsientos.TabIndex = 359;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 80;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle3;
            this.Numero.HeaderText = "N°";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 50;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "Descripcion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Concepto.DefaultCellStyle = dataGridViewCellStyle4;
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            this.Concepto.Width = 300;
            // 
            // Debe
            // 
            this.Debe.DataPropertyName = "Debe";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Debe.DefaultCellStyle = dataGridViewCellStyle5;
            this.Debe.HeaderText = "Debe";
            this.Debe.Name = "Debe";
            this.Debe.ReadOnly = true;
            this.Debe.Width = 125;
            // 
            // Haber
            // 
            this.Haber.DataPropertyName = "Haber";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.Haber.DefaultCellStyle = dataGridViewCellStyle6;
            this.Haber.HeaderText = "Haber";
            this.Haber.Name = "Haber";
            this.Haber.ReadOnly = true;
            this.Haber.Width = 125;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Total";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle7;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(765, 488);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 362;
            this.button1.Text = "EXPORTAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(638, 488);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 24);
            this.button2.TabIndex = 363;
            this.button2.Text = "MAYOR GENERAL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(847, 523);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbCuentaContable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAsientos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMayor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvAsientos;
        public System.Windows.Forms.ComboBox cbCuentaContable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.Button button2;
    }
}
