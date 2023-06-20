namespace Presentacion
{
    partial class frmSumasYSaldo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSumas = new System.Windows.Forms.DataGridView();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deudor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acreedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSumas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSumas
            // 
            this.dgvSumas.AllowUserToAddRows = false;
            this.dgvSumas.AllowUserToDeleteRows = false;
            this.dgvSumas.AllowUserToResizeRows = false;
            this.dgvSumas.BackgroundColor = System.Drawing.Color.White;
            this.dgvSumas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSumas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSumas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSumas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSumas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSumas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cuenta,
            this.Debe,
            this.Haber,
            this.Deudor,
            this.Acreedor});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSumas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSumas.EnableHeadersVisualStyles = false;
            this.dgvSumas.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvSumas.Location = new System.Drawing.Point(10, 11);
            this.dgvSumas.MultiSelect = false;
            this.dgvSumas.Name = "dgvSumas";
            this.dgvSumas.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSumas.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSumas.RowHeadersVisible = false;
            this.dgvSumas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSumas.Size = new System.Drawing.Size(738, 462);
            this.dgvSumas.TabIndex = 359;
            // 
            // Cuenta
            // 
            this.Cuenta.DataPropertyName = "Cuenta";
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.ReadOnly = true;
            this.Cuenta.Width = 200;
            // 
            // Debe
            // 
            this.Debe.DataPropertyName = "Debe";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Debe.DefaultCellStyle = dataGridViewCellStyle2;
            this.Debe.HeaderText = "Debe";
            this.Debe.Name = "Debe";
            this.Debe.ReadOnly = true;
            this.Debe.Width = 130;
            // 
            // Haber
            // 
            this.Haber.DataPropertyName = "Haber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.Haber.DefaultCellStyle = dataGridViewCellStyle3;
            this.Haber.HeaderText = "Haber";
            this.Haber.Name = "Haber";
            this.Haber.ReadOnly = true;
            this.Haber.Width = 130;
            // 
            // Deudor
            // 
            this.Deudor.DataPropertyName = "Deudor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Deudor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Deudor.HeaderText = "Deudor";
            this.Deudor.Name = "Deudor";
            this.Deudor.ReadOnly = true;
            this.Deudor.Width = 130;
            // 
            // Acreedor
            // 
            this.Acreedor.DataPropertyName = "Acreedor";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Acreedor.DefaultCellStyle = dataGridViewCellStyle5;
            this.Acreedor.HeaderText = "Acreedor";
            this.Acreedor.Name = "Acreedor";
            this.Acreedor.ReadOnly = true;
            this.Acreedor.Width = 130;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(673, 489);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 24);
            this.btnExportar.TabIndex = 363;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSumasYSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(757, 518);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvSumas);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmSumasYSaldo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSumas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvSumas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deudor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acreedor;
        private System.Windows.Forms.Button btnExportar;
    }
}
