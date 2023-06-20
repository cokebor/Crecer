namespace Presentacion
{
    partial class frmDocumentosDeCaja2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentosDeCaja2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTiposComprobantes = new System.Windows.Forms.ComboBox();
            this.pIngresos = new System.Windows.Forms.Panel();
            this.tcGastosIngresos = new System.Windows.Forms.TabControl();
            this.tpConceptosIngresos = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporteIngresos = new System.Windows.Forms.TextBox();
            this.txtObservacionesIngresos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminarIngreso = new System.Windows.Forms.Button();
            this.dgvGastosIngreso = new System.Windows.Forms.DataGridView();
            this.CodigoCuentaContableIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaContableIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarGastoIngreso = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCuentaIngresos = new System.Windows.Forms.ComboBox();
            this.tpFormasDePagoIngresos = new System.Windows.Forms.TabPage();
            this.ucFormasPagoIngresos = new Presentacion.ucFormasPagoIngresos();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblValores = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cbSucursal = new System.Windows.Forms.ComboBox();
            this.pIngresos.SuspendLayout();
            this.tcGastosIngresos.SuspendLayout();
            this.tpConceptosIngresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastosIngreso)).BeginInit();
            this.tpFormasDePagoIngresos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 427;
            this.label6.Text = "Fecha :";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(495, 10);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 429;
            this.label3.Text = "Tipo Comprobante:";
            // 
            // cbTiposComprobantes
            // 
            this.cbTiposComprobantes.FormattingEnabled = true;
            this.cbTiposComprobantes.Location = new System.Drawing.Point(124, 10);
            this.cbTiposComprobantes.Name = "cbTiposComprobantes";
            this.cbTiposComprobantes.Size = new System.Drawing.Size(170, 21);
            this.cbTiposComprobantes.TabIndex = 0;
            this.cbTiposComprobantes.SelectedIndexChanged += new System.EventHandler(this.cbTiposComprobantes_SelectedIndexChanged);
            // 
            // pIngresos
            // 
            this.pIngresos.Controls.Add(this.tcGastosIngresos);
            this.pIngresos.Location = new System.Drawing.Point(24, 85);
            this.pIngresos.Name = "pIngresos";
            this.pIngresos.Size = new System.Drawing.Size(576, 315);
            this.pIngresos.TabIndex = 430;
            // 
            // tcGastosIngresos
            // 
            this.tcGastosIngresos.Controls.Add(this.tpConceptosIngresos);
            this.tcGastosIngresos.Controls.Add(this.tpFormasDePagoIngresos);
            this.tcGastosIngresos.Location = new System.Drawing.Point(9, 8);
            this.tcGastosIngresos.Name = "tcGastosIngresos";
            this.tcGastosIngresos.SelectedIndex = 0;
            this.tcGastosIngresos.Size = new System.Drawing.Size(559, 298);
            this.tcGastosIngresos.TabIndex = 0;
            // 
            // tpConceptosIngresos
            // 
            this.tpConceptosIngresos.Controls.Add(this.label1);
            this.tpConceptosIngresos.Controls.Add(this.txtImporteIngresos);
            this.tpConceptosIngresos.Controls.Add(this.txtObservacionesIngresos);
            this.tpConceptosIngresos.Controls.Add(this.label2);
            this.tpConceptosIngresos.Controls.Add(this.btnEliminarIngreso);
            this.tpConceptosIngresos.Controls.Add(this.dgvGastosIngreso);
            this.tpConceptosIngresos.Controls.Add(this.btnAgregarGastoIngreso);
            this.tpConceptosIngresos.Controls.Add(this.label4);
            this.tpConceptosIngresos.Controls.Add(this.cbCuentaIngresos);
            this.tpConceptosIngresos.Location = new System.Drawing.Point(4, 22);
            this.tpConceptosIngresos.Name = "tpConceptosIngresos";
            this.tpConceptosIngresos.Padding = new System.Windows.Forms.Padding(3);
            this.tpConceptosIngresos.Size = new System.Drawing.Size(551, 272);
            this.tpConceptosIngresos.TabIndex = 0;
            this.tpConceptosIngresos.Text = "Conceptos";
            this.tpConceptosIngresos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 421;
            this.label1.Text = "Importe:";
            // 
            // txtImporteIngresos
            // 
            this.txtImporteIngresos.Location = new System.Drawing.Point(418, 25);
            this.txtImporteIngresos.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporteIngresos.Name = "txtImporteIngresos";
            this.txtImporteIngresos.Size = new System.Drawing.Size(68, 20);
            this.txtImporteIngresos.TabIndex = 1;
            this.txtImporteIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteIngresos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // txtObservacionesIngresos
            // 
            this.txtObservacionesIngresos.Location = new System.Drawing.Point(131, 207);
            this.txtObservacionesIngresos.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservacionesIngresos.Multiline = true;
            this.txtObservacionesIngresos.Name = "txtObservacionesIngresos";
            this.txtObservacionesIngresos.Size = new System.Drawing.Size(355, 42);
            this.txtObservacionesIngresos.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 423;
            this.label2.Text = "Observaciones:";
            // 
            // btnEliminarIngreso
            // 
            this.btnEliminarIngreso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarIngreso.BackgroundImage")));
            this.btnEliminarIngreso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarIngreso.Location = new System.Drawing.Point(503, 68);
            this.btnEliminarIngreso.Name = "btnEliminarIngreso";
            this.btnEliminarIngreso.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarIngreso.TabIndex = 3;
            this.btnEliminarIngreso.UseVisualStyleBackColor = true;
            this.btnEliminarIngreso.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvGastosIngreso
            // 
            this.dgvGastosIngreso.AllowUserToAddRows = false;
            this.dgvGastosIngreso.AllowUserToDeleteRows = false;
            this.dgvGastosIngreso.AllowUserToResizeRows = false;
            this.dgvGastosIngreso.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGastosIngreso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGastosIngreso.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGastosIngreso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGastosIngreso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGastosIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastosIngreso.ColumnHeadersVisible = false;
            this.dgvGastosIngreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoCuentaContableIngreso,
            this.CuentaContableIngreso,
            this.ImporteIngreso});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGastosIngreso.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGastosIngreso.EnableHeadersVisualStyles = false;
            this.dgvGastosIngreso.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvGastosIngreso.Location = new System.Drawing.Point(26, 68);
            this.dgvGastosIngreso.MultiSelect = false;
            this.dgvGastosIngreso.Name = "dgvGastosIngreso";
            this.dgvGastosIngreso.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGastosIngreso.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGastosIngreso.RowHeadersVisible = false;
            this.dgvGastosIngreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGastosIngreso.Size = new System.Drawing.Size(460, 116);
            this.dgvGastosIngreso.TabIndex = 4;
            // 
            // CodigoCuentaContableIngreso
            // 
            this.CodigoCuentaContableIngreso.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContableIngreso.Name = "CodigoCuentaContableIngreso";
            this.CodigoCuentaContableIngreso.ReadOnly = true;
            this.CodigoCuentaContableIngreso.Visible = false;
            // 
            // CuentaContableIngreso
            // 
            this.CuentaContableIngreso.HeaderText = "Cuenta Contable";
            this.CuentaContableIngreso.Name = "CuentaContableIngreso";
            this.CuentaContableIngreso.ReadOnly = true;
            // 
            // ImporteIngreso
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.ImporteIngreso.DefaultCellStyle = dataGridViewCellStyle2;
            this.ImporteIngreso.HeaderText = "Importe";
            this.ImporteIngreso.Name = "ImporteIngreso";
            this.ImporteIngreso.ReadOnly = true;
            // 
            // btnAgregarGastoIngreso
            // 
            this.btnAgregarGastoIngreso.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregarGastoIngreso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarGastoIngreso.Location = new System.Drawing.Point(503, 23);
            this.btnAgregarGastoIngreso.Name = "btnAgregarGastoIngreso";
            this.btnAgregarGastoIngreso.Size = new System.Drawing.Size(25, 25);
            this.btnAgregarGastoIngreso.TabIndex = 2;
            this.btnAgregarGastoIngreso.UseVisualStyleBackColor = true;
            this.btnAgregarGastoIngreso.Click += new System.EventHandler(this.btnAgregarGasto_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 416;
            this.label4.Text = "Cuenta Contable:";
            // 
            // cbCuentaIngresos
            // 
            this.cbCuentaIngresos.FormattingEnabled = true;
            this.cbCuentaIngresos.Location = new System.Drawing.Point(118, 25);
            this.cbCuentaIngresos.Name = "cbCuentaIngresos";
            this.cbCuentaIngresos.Size = new System.Drawing.Size(223, 21);
            this.cbCuentaIngresos.TabIndex = 0;
            // 
            // tpFormasDePagoIngresos
            // 
            this.tpFormasDePagoIngresos.Controls.Add(this.ucFormasPagoIngresos);
            this.tpFormasDePagoIngresos.Location = new System.Drawing.Point(4, 22);
            this.tpFormasDePagoIngresos.Name = "tpFormasDePagoIngresos";
            this.tpFormasDePagoIngresos.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormasDePagoIngresos.Size = new System.Drawing.Size(551, 272);
            this.tpFormasDePagoIngresos.TabIndex = 1;
            this.tpFormasDePagoIngresos.Text = "Formas de Pago";
            this.tpFormasDePagoIngresos.UseVisualStyleBackColor = true;
            // 
            // ucFormasPagoIngresos
            // 
            this.ucFormasPagoIngresos.Cheques = ((System.Collections.Generic.List<Entidades.Cheque>)(resources.GetObject("ucFormasPagoIngresos.Cheques")));
            this.ucFormasPagoIngresos.Efectivos = ((System.Collections.Generic.List<Entidades.Factura_Efectivo>)(resources.GetObject("ucFormasPagoIngresos.Efectivos")));
            this.ucFormasPagoIngresos.FormularioInicial = null;
            this.ucFormasPagoIngresos.Location = new System.Drawing.Point(17, 7);
            this.ucFormasPagoIngresos.Name = "ucFormasPagoIngresos";
            this.ucFormasPagoIngresos.Size = new System.Drawing.Size(521, 267);
            this.ucFormasPagoIngresos.TabIndex = 0;
            this.ucFormasPagoIngresos.Tranferencias = ((System.Collections.Generic.List<Entidades.Tranferencia>)(resources.GetObject("ucFormasPagoIngresos.Tranferencias")));
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(512, 443);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(412, 442);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(436, 416);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 436;
            this.label5.Text = "Saldo:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.Maroon;
            this.lblSaldo.Location = new System.Drawing.Point(491, 412);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(100, 17);
            this.lblSaldo.TabIndex = 435;
            this.lblSaldo.Text = "0.00";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(436, 387);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 434;
            this.label7.Text = "Valores:";
            // 
            // lblValores
            // 
            this.lblValores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValores.ForeColor = System.Drawing.Color.Maroon;
            this.lblValores.Location = new System.Drawing.Point(491, 385);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(100, 17);
            this.lblValores.TabIndex = 433;
            this.lblValores.Text = "0.00";
            this.lblValores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(436, 361);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 432;
            this.label14.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(491, 359);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 431;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSucursal
            // 
            this.cbSucursal.FormattingEnabled = true;
            this.cbSucursal.Location = new System.Drawing.Point(317, 10);
            this.cbSucursal.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursal.Name = "cbSucursal";
            this.cbSucursal.Size = new System.Drawing.Size(109, 21);
            this.cbSucursal.TabIndex = 1;
            // 
            // frmDocumentosDeCaja2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(608, 476);
            this.Controls.Add(this.cbSucursal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblValores);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.pIngresos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTiposComprobantes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFecha);
            this.Name = "frmDocumentosDeCaja2";
            this.pIngresos.ResumeLayout(false);
            this.tcGastosIngresos.ResumeLayout(false);
            this.tpConceptosIngresos.ResumeLayout(false);
            this.tpConceptosIngresos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastosIngreso)).EndInit();
            this.tpFormasDePagoIngresos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        internal System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbTiposComprobantes;
        private System.Windows.Forms.Panel pIngresos;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSaldo;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblValores;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TabControl tcGastosIngresos;
        private System.Windows.Forms.TabPage tpConceptosIngresos;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtImporteIngresos;
        public System.Windows.Forms.TextBox txtObservacionesIngresos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminarIngreso;
        internal System.Windows.Forms.DataGridView dgvGastosIngreso;
        private System.Windows.Forms.Button btnAgregarGastoIngreso;
        internal System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbCuentaIngresos;
        private System.Windows.Forms.TabPage tpFormasDePagoIngresos;
        private Presentacion.ucFormasPagoIngresos ucFormasPagoIngresos;
        private System.Windows.Forms.ComboBox cbSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContableIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaContableIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteIngreso;
        //  private ucFormasPagoExtraccion ucFormasPagoExtraccion;
    }
}
