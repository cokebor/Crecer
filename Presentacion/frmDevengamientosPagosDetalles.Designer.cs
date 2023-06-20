namespace Presentacion
{
    partial class frmDevengamientosPagosDetalles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvLibreDisponibilidad = new System.Windows.Forms.DataGridView();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEfectivo = new System.Windows.Forms.DataGridView();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cotización = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTranferencias = new System.Windows.Forms.DataGridView();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibreDisponibilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEfectivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTranferencias)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Libre Disponibilidad";
            // 
            // dgvLibreDisponibilidad
            // 
            this.dgvLibreDisponibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibreDisponibilidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cuenta,
            this.dataGridViewTextBoxColumn4});
            this.dgvLibreDisponibilidad.Location = new System.Drawing.Point(13, 254);
            this.dgvLibreDisponibilidad.Name = "dgvLibreDisponibilidad";
            this.dgvLibreDisponibilidad.Size = new System.Drawing.Size(374, 88);
            this.dgvLibreDisponibilidad.TabIndex = 6;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblObservaciones.Location = new System.Drawing.Point(14, 368);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(373, 34);
            this.lblObservaciones.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Observaciones:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Efectivo";
            // 
            // dgvEfectivo
            // 
            this.dgvEfectivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEfectivo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Moneda,
            this.Cotización,
            this.dataGridViewTextBoxColumn3});
            this.dgvEfectivo.Location = new System.Drawing.Point(12, 28);
            this.dgvEfectivo.Name = "dgvEfectivo";
            this.dgvEfectivo.Size = new System.Drawing.Size(374, 88);
            this.dgvEfectivo.TabIndex = 2;
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "Moneda";
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            // 
            // Cotización
            // 
            this.Cotización.DataPropertyName = "Cotizacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Cotización.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cotización.HeaderText = "Cotización";
            this.Cotización.Name = "Cotización";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tranferencias";
            // 
            // dgvTranferencias
            // 
            this.dgvTranferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTranferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Banco,
            this.NroCuenta,
            this.Importe});
            this.dgvTranferencias.Location = new System.Drawing.Point(12, 138);
            this.dgvTranferencias.Name = "dgvTranferencias";
            this.dgvTranferencias.Size = new System.Drawing.Size(374, 88);
            this.dgvTranferencias.TabIndex = 0;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle4;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // Cuenta
            // 
            this.Cuenta.DataPropertyName = "Descripcion";
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Monto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // frmDevengamientosPagosDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(398, 410);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvLibreDisponibilidad);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvEfectivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTranferencias);
            this.Name = "frmDevengamientosPagosDetalles";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibreDisponibilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEfectivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTranferencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTranferencias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEfectivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cotización;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvLibreDisponibilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
