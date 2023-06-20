namespace Presentacion
{
    partial class frmGastosTranferencia
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tranferencias";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Banco,
            this.NroCuenta,
            this.Importe});
            this.dgvDetalle.Location = new System.Drawing.Point(13, 32);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(374, 91);
            this.dgvDetalle.TabIndex = 0;
            // 
            // Banco
            // 
            this.Banco.DataPropertyName = "Banco";
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            // 
            // NroCuenta
            // 
            this.NroCuenta.DataPropertyName = "NumeroCuenta";
            this.NroCuenta.HeaderText = "Nro Cuenta";
            this.NroCuenta.Name = "NroCuenta";
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Total";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle1;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // frmGastosTranferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(398, 189);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetalle);
            this.Name = "frmGastosTranferencia";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
    }
}
