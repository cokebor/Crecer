namespace Presentacion
{
    partial class frmDevengamientoDetalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.CodigoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComprobanteNro = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblComprobanteCaja = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPagos
            // 
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoPago,
            this.Fecha,
            this.ComprobanteNro,
            this.Monto});
            this.dgvPagos.Location = new System.Drawing.Point(13, 195);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.Size = new System.Drawing.Size(374, 113);
            this.dgvPagos.TabIndex = 4;
            this.dgvPagos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagos_CellContentClick);
            // 
            // CodigoPago
            // 
            this.CodigoPago.DataPropertyName = "Codigo";
            this.CodigoPago.HeaderText = "CodigoPago";
            this.CodigoPago.Name = "CodigoPago";
            this.CodigoPago.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ComprobanteNro
            // 
            this.ComprobanteNro.DataPropertyName = "Numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ComprobanteNro.DefaultCellStyle = dataGridViewCellStyle2;
            this.ComprobanteNro.HeaderText = "Comp. Nro.";
            this.ComprobanteNro.Name = "ComprobanteNro";
            this.ComprobanteNro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ComprobanteNro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle3;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // lblComprobanteCaja
            // 
            this.lblComprobanteCaja.AutoSize = true;
            this.lblComprobanteCaja.Location = new System.Drawing.Point(13, 177);
            this.lblComprobanteCaja.Name = "lblComprobanteCaja";
            this.lblComprobanteCaja.Size = new System.Drawing.Size(37, 13);
            this.lblComprobanteCaja.TabIndex = 3;
            this.lblComprobanteCaja.Text = "Pagos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detalle";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Debe,
            this.Haber});
            this.dgvDetalle.Location = new System.Drawing.Point(13, 32);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(374, 126);
            this.dgvDetalle.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Descripcion";
            this.Nombre.HeaderText = "Descripcion";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 250;
            // 
            // Debe
            // 
            this.Debe.DataPropertyName = "Debe";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Debe.DefaultCellStyle = dataGridViewCellStyle4;
            this.Debe.HeaderText = "Debe";
            this.Debe.Name = "Debe";
            // 
            // Haber
            // 
            this.Haber.DataPropertyName = "Haber";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Haber.DefaultCellStyle = dataGridViewCellStyle5;
            this.Haber.HeaderText = "Haber";
            this.Haber.Name = "Haber";
            // 
            // frmDevengamientoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(399, 320);
            this.Controls.Add(this.dgvPagos);
            this.Controls.Add(this.lblComprobanteCaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetalle);
            this.Name = "frmDevengamientoDetalle";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblComprobanteCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewLinkColumn ComprobanteNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
    }
}
