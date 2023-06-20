namespace Presentacion
{
    partial class frmAsientos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvAsientos = new System.Windows.Forms.DataGridView();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(710, 521);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(79, 24);
            this.btnExportar.TabIndex = 364;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.button1_Click);
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
            this.Concepto,
            this.Debe,
            this.Haber});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsientos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAsientos.EnableHeadersVisualStyles = false;
            this.dgvAsientos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvAsientos.Location = new System.Drawing.Point(10, 11);
            this.dgvAsientos.MultiSelect = false;
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsientos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAsientos.RowHeadersVisible = false;
            this.dgvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientos.Size = new System.Drawing.Size(779, 486);
            this.dgvAsientos.TabIndex = 359;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "Concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            this.Concepto.Width = 450;
            // 
            // Debe
            // 
            this.Debe.DataPropertyName = "Debe";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.Debe.DefaultCellStyle = dataGridViewCellStyle2;
            this.Debe.HeaderText = "Debe";
            this.Debe.Name = "Debe";
            this.Debe.ReadOnly = true;
            this.Debe.Width = 150;
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
            this.Haber.Width = 150;
            // 
            // frmAsientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(797, 556);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvAsientos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAsientos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvAsientos;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber;
    }
}
