namespace Presentacion
{
    partial class frmPagodeImpuestos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagodeImpuestos));
            this.tcPagos = new System.Windows.Forms.TabControl();
            this.tpConceptos = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.cbImpuesto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCuentaContable = new System.Windows.Forms.ComboBox();
            this.tpFormasDePago = new System.Windows.Forms.TabPage();
            this.ucFormasPagoSueldos = new Presentacion.ucFormasPagoSueldos();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tcPagos.SuspendLayout();
            this.tpConceptos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.tpFormasDePago.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPagos
            // 
            this.tcPagos.Controls.Add(this.tpConceptos);
            this.tcPagos.Controls.Add(this.tpFormasDePago);
            this.tcPagos.Location = new System.Drawing.Point(12, 50);
            this.tcPagos.Name = "tcPagos";
            this.tcPagos.SelectedIndex = 0;
            this.tcPagos.Size = new System.Drawing.Size(578, 286);
            this.tcPagos.TabIndex = 1;
            // 
            // tpConceptos
            // 
            this.tpConceptos.Controls.Add(this.label4);
            this.tpConceptos.Controls.Add(this.cbImpuesto);
            this.tpConceptos.Controls.Add(this.label3);
            this.tpConceptos.Controls.Add(this.cbPeriodo);
            this.tpConceptos.Controls.Add(this.dgvDatos);
            this.tpConceptos.Controls.Add(this.btnEliminar);
            this.tpConceptos.Controls.Add(this.btnAgregar);
            this.tpConceptos.Controls.Add(this.txtMonto);
            this.tpConceptos.Controls.Add(this.label2);
            this.tpConceptos.Controls.Add(this.label1);
            this.tpConceptos.Controls.Add(this.cbCuentaContable);
            this.tpConceptos.Location = new System.Drawing.Point(4, 22);
            this.tpConceptos.Name = "tpConceptos";
            this.tpConceptos.Padding = new System.Windows.Forms.Padding(3);
            this.tpConceptos.Size = new System.Drawing.Size(570, 260);
            this.tpConceptos.TabIndex = 0;
            this.tpConceptos.Text = "Conceptos";
            this.tpConceptos.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 531;
            this.label4.Text = "Impuesto:";
            // 
            // cbImpuesto
            // 
            this.cbImpuesto.FormattingEnabled = true;
            this.cbImpuesto.Location = new System.Drawing.Point(88, 19);
            this.cbImpuesto.Name = "cbImpuesto";
            this.cbImpuesto.Size = new System.Drawing.Size(116, 21);
            this.cbImpuesto.TabIndex = 530;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 529;
            this.label3.Text = "Periodo:";
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Location = new System.Drawing.Point(388, 19);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(116, 21);
            this.cbPeriodo.TabIndex = 528;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoCuentaContable,
            this.CodigoConcepto,
            this.Descripcion,
            this.Monto,
            this.ren});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvDatos.Location = new System.Drawing.Point(24, 104);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(480, 140);
            this.dgvDatos.TabIndex = 525;
            // 
            // CodigoCuentaContable
            // 
            this.CodigoCuentaContable.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.ReadOnly = true;
            this.CodigoCuentaContable.Visible = false;
            // 
            // CodigoConcepto
            // 
            this.CodigoConcepto.HeaderText = "CodigoConcepto";
            this.CodigoConcepto.Name = "CodigoConcepto";
            this.CodigoConcepto.ReadOnly = true;
            this.CodigoConcepto.Visible = false;
            // 
            // Descripcion
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle10;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 300;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 150;
            // 
            // ren
            // 
            this.ren.Name = "ren";
            this.ren.ReadOnly = true;
            this.ren.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(525, 105);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 25);
            this.btnEliminar.TabIndex = 524;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(525, 54);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 523;
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(388, 56);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(2);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(116, 20);
            this.txtMonto.TabIndex = 521;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 522;
            this.label2.Text = "Monto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 520;
            this.label1.Text = "Concepto:";
            // 
            // cbCuentaContable
            // 
            this.cbCuentaContable.FormattingEnabled = true;
            this.cbCuentaContable.Location = new System.Drawing.Point(88, 56);
            this.cbCuentaContable.Name = "cbCuentaContable";
            this.cbCuentaContable.Size = new System.Drawing.Size(221, 21);
            this.cbCuentaContable.TabIndex = 519;
            // 
            // tpFormasDePago
            // 
            this.tpFormasDePago.Controls.Add(this.ucFormasPagoSueldos);
            this.tpFormasDePago.Location = new System.Drawing.Point(4, 22);
            this.tpFormasDePago.Name = "tpFormasDePago";
            this.tpFormasDePago.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormasDePago.Size = new System.Drawing.Size(570, 260);
            this.tpFormasDePago.TabIndex = 1;
            this.tpFormasDePago.Text = "Formas de Pago";
            this.tpFormasDePago.UseVisualStyleBackColor = true;
            // 
            // ucFormasPagoSueldos
            // 
            this.ucFormasPagoSueldos.Efectivos = ((System.Collections.Generic.List<Entidades.Factura_Efectivo>)(resources.GetObject("ucFormasPagoSueldos.Efectivos")));
            this.ucFormasPagoSueldos.Location = new System.Drawing.Point(7, 7);
            this.ucFormasPagoSueldos.Name = "ucFormasPagoSueldos";
            this.ucFormasPagoSueldos.Size = new System.Drawing.Size(554, 253);
            this.ucFormasPagoSueldos.TabIndex = 0;
            this.ucFormasPagoSueldos.Tranferencias = ((System.Collections.Generic.List<Entidades.Tranferencia>)(resources.GetObject("ucFormasPagoSueldos.Tranferencias")));
            this.ucFormasPagoSueldos.Valores = 0D;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 528;
            this.label6.Text = "Fecha :";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(485, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 527;
            // 
            // frmPagodeImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(596, 398);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.tcPagos);
            this.Name = "frmPagodeImpuestos";
            this.tcPagos.ResumeLayout(false);
            this.tpConceptos.ResumeLayout(false);
            this.tpConceptos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.tpFormasDePago.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcPagos;
        private System.Windows.Forms.TabPage tpConceptos;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cbImpuesto;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cbPeriodo;
        internal System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ren;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.TextBox txtMonto;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbCuentaContable;
        private System.Windows.Forms.TabPage tpFormasDePago;
        private ucFormasPagoSueldos ucFormasPagoSueldos;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DateTimePicker dtpFecha;
    }
}
