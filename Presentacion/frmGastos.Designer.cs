namespace Presentacion
{
    partial class frmGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGastos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcGastos = new System.Windows.Forms.TabControl();
            this.tpConceptos = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvGastos = new System.Windows.Forms.DataGridView();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarGasto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCuenta = new System.Windows.Forms.ComboBox();
            this.tpFormasDePago = new System.Windows.Forms.TabPage();
            this.ucFormasPagoCompras = new Presentacion.ucFormasPagoCompras(false);
            this.shapeContainer3 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.lblValores = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.shapeContainer4 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.tcGastos.SuspendLayout();
            this.tpConceptos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).BeginInit();
            this.tpFormasDePago.SuspendLayout();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(474, 522);
            this.shapeContainer1.TabIndex = 108;
            this.shapeContainer1.TabStop = false;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer1";
            this.shapeContainer2.Size = new System.Drawing.Size(474, 522);
            this.shapeContainer2.TabIndex = 108;
            this.shapeContainer2.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(406, 345);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 416;
            this.label14.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(461, 343);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 415;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(126, 197);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(355, 42);
            this.txtObservaciones.TabIndex = 413;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 414;
            this.label2.Text = "Observaciones:";
            // 
            // tcGastos
            // 
            this.tcGastos.Controls.Add(this.tpConceptos);
            this.tcGastos.Controls.Add(this.tpFormasDePago);
            this.tcGastos.Location = new System.Drawing.Point(12, 33);
            this.tcGastos.Name = "tcGastos";
            this.tcGastos.SelectedIndex = 0;
            this.tcGastos.Size = new System.Drawing.Size(559, 298);
            this.tcGastos.TabIndex = 406;
            this.tcGastos.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tcGastos_DrawItem);
            // 
            // tpConceptos
            // 
            this.tpConceptos.Controls.Add(this.label1);
            this.tpConceptos.Controls.Add(this.txtImporte);
            this.tpConceptos.Controls.Add(this.label2);
            this.tpConceptos.Controls.Add(this.txtObservaciones);
            this.tpConceptos.Controls.Add(this.btnEliminar);
            this.tpConceptos.Controls.Add(this.dgvGastos);
            this.tpConceptos.Controls.Add(this.btnAgregarGasto);
            this.tpConceptos.Controls.Add(this.label3);
            this.tpConceptos.Controls.Add(this.cbCuenta);
            this.tpConceptos.Location = new System.Drawing.Point(4, 22);
            this.tpConceptos.Name = "tpConceptos";
            this.tpConceptos.Padding = new System.Windows.Forms.Padding(3);
            this.tpConceptos.Size = new System.Drawing.Size(551, 272);
            this.tpConceptos.TabIndex = 0;
            this.tpConceptos.Text = "Conceptos";
            this.tpConceptos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 412;
            this.label1.Text = "Importe:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(413, 15);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(68, 20);
            this.txtImporte.TabIndex = 411;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(498, 58);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 25);
            this.btnEliminar.TabIndex = 409;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvGastos
            // 
            this.dgvGastos.AllowUserToAddRows = false;
            this.dgvGastos.AllowUserToDeleteRows = false;
            this.dgvGastos.AllowUserToResizeRows = false;
            this.dgvGastos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGastos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGastos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGastos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastos.ColumnHeadersVisible = false;
            this.dgvGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoCuentaContable,
            this.CuentaContable,
            this.Importe});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGastos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGastos.EnableHeadersVisualStyles = false;
            this.dgvGastos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvGastos.Location = new System.Drawing.Point(21, 58);
            this.dgvGastos.MultiSelect = false;
            this.dgvGastos.Name = "dgvGastos";
            this.dgvGastos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGastos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGastos.RowHeadersVisible = false;
            this.dgvGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGastos.Size = new System.Drawing.Size(460, 116);
            this.dgvGastos.TabIndex = 410;
            // 
            // CodigoCuentaContable
            // 
            this.CodigoCuentaContable.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.ReadOnly = true;
            this.CodigoCuentaContable.Visible = false;
            // 
            // CuentaContable
            // 
            this.CuentaContable.HeaderText = "Cuenta Contable";
            this.CuentaContable.Name = "CuentaContable";
            this.CuentaContable.ReadOnly = true;
            // 
            // Importe
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // btnAgregarGasto
            // 
            this.btnAgregarGasto.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregarGasto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarGasto.Location = new System.Drawing.Point(498, 13);
            this.btnAgregarGasto.Name = "btnAgregarGasto";
            this.btnAgregarGasto.Size = new System.Drawing.Size(25, 25);
            this.btnAgregarGasto.TabIndex = 408;
            this.btnAgregarGasto.UseVisualStyleBackColor = true;
            this.btnAgregarGasto.Click += new System.EventHandler(this.btnAgregarGasto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 407;
            this.label3.Text = "Cuenta Contable:";
            // 
            // cbCuenta
            // 
            this.cbCuenta.FormattingEnabled = true;
            this.cbCuenta.Location = new System.Drawing.Point(113, 15);
            this.cbCuenta.Name = "cbCuenta";
            this.cbCuenta.Size = new System.Drawing.Size(223, 21);
            this.cbCuenta.TabIndex = 406;
            // 
            // tpFormasDePago
            // 
            this.tpFormasDePago.Controls.Add(this.ucFormasPagoCompras);
            this.tpFormasDePago.Location = new System.Drawing.Point(4, 22);
            this.tpFormasDePago.Name = "tpFormasDePago";
            this.tpFormasDePago.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormasDePago.Size = new System.Drawing.Size(551, 272);
            this.tpFormasDePago.TabIndex = 1;
            this.tpFormasDePago.Text = "Formas de Pago";
            this.tpFormasDePago.UseVisualStyleBackColor = true;
            // 
            // ucFormasPagoCompras
            // 
            this.ucFormasPagoCompras.Cheques = ((System.Collections.Generic.List<Entidades.Cheque>)(resources.GetObject("ucFormasPagoCompras.Cheques")));
            this.ucFormasPagoCompras.ChequesPropios = ((System.Collections.Generic.List<Entidades.Cheque>)(resources.GetObject("ucFormasPagoCompras.ChequesPropios")));
            this.ucFormasPagoCompras.Efectivos = ((System.Collections.Generic.List<Entidades.Factura_Efectivo>)(resources.GetObject("ucFormasPagoCompras.Efectivos")));
            this.ucFormasPagoCompras.FormularioInicial = null;
            this.ucFormasPagoCompras.Location = new System.Drawing.Point(15, 3);
            this.ucFormasPagoCompras.Name = "ucFormasPagoCompras";
            this.ucFormasPagoCompras.Size = new System.Drawing.Size(521, 267);
            this.ucFormasPagoCompras.TabIndex = 1;
            this.ucFormasPagoCompras.Tranferencias = ((System.Collections.Generic.List<Entidades.Tranferencia>)(resources.GetObject("ucFormasPagoCompras.Tranferencias")));
            // 
            // shapeContainer3
            // 
            this.shapeContainer3.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer3.Name = "shapeContainer1";
            this.shapeContainer3.Size = new System.Drawing.Size(521, 429);
            this.shapeContainer3.TabIndex = 125;
            this.shapeContainer3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(406, 371);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 419;
            this.label5.Text = "Valores:";
            // 
            // lblValores
            // 
            this.lblValores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValores.ForeColor = System.Drawing.Color.Maroon;
            this.lblValores.Location = new System.Drawing.Point(461, 369);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(100, 17);
            this.lblValores.TabIndex = 418;
            this.lblValores.Text = "0.00";
            this.lblValores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(406, 400);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 421;
            this.label4.Text = "Saldo:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.Maroon;
            this.lblSaldo.Location = new System.Drawing.Point(461, 396);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(100, 17);
            this.lblSaldo.TabIndex = 420;
            this.lblSaldo.Text = "0.00";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(482, 426);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 423;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(464, 13);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 424;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(382, 426);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 422;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // shapeContainer4
            // 
            this.shapeContainer4.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer4.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer4.Name = "shapeContainer1";
            this.shapeContainer4.Size = new System.Drawing.Size(569, 573);
            this.shapeContainer4.TabIndex = 393;
            this.shapeContainer4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 425;
            this.label6.Text = "Fecha :";
            // 
            // frmGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(573, 462);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblValores);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.tcGastos);
            this.Controls.Add(this.dtpFecha);
            this.Name = "frmGastos";
            this.tcGastos.ResumeLayout(false);
            this.tpConceptos.ResumeLayout(false);
            this.tpConceptos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).EndInit();
            this.tpFormasDePago.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private System.Windows.Forms.TabControl tcGastos;
        private System.Windows.Forms.TabPage tpConceptos;
        private System.Windows.Forms.TabPage tpFormasDePago;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Button btnEliminar;
        internal System.Windows.Forms.DataGridView dgvGastos;
        private System.Windows.Forms.Button btnAgregarGasto;
        internal System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbCuenta;
        public System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer3;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblValores;
        private Presentacion.ucFormasPagoCompras ucFormasPagoCompras;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSaldo;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.Button btnConfirmar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer4;
        private System.Windows.Forms.Label label6;
    }
}
