namespace Presentacion
{
    partial class frmDescuentos
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtCodigoVendedor = new System.Windows.Forms.TextBox();
            this.lblNombreVendedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 408;
            this.label8.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(19, 132);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(304, 64);
            this.txtObservaciones.TabIndex = 3;
            this.txtObservaciones.Text = "Factura Nro: ";
            // 
            // txtCodigoVendedor
            // 
            this.txtCodigoVendedor.Location = new System.Drawing.Point(96, 41);
            this.txtCodigoVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoVendedor.Name = "txtCodigoVendedor";
            this.txtCodigoVendedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoVendedor.TabIndex = 1;
            this.txtCodigoVendedor.TextChanged += new System.EventHandler(this.txtCodigoVendedor_TextChanged);
            this.txtCodigoVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoVendedor_KeyDown);
            this.txtCodigoVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoVendedor_KeyPress);
            // 
            // lblNombreVendedor
            // 
            this.lblNombreVendedor.AutoSize = true;
            this.lblNombreVendedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreVendedor.Location = new System.Drawing.Point(133, 46);
            this.lblNombreVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreVendedor.Name = "lblNombreVendedor";
            this.lblNombreVendedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreVendedor.TabIndex = 406;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(16, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 405;
            this.label3.Text = "Vendedor (F1):";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(244, 270);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(145, 270);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(195, 210);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(128, 20);
            this.txtImporte.TabIndex = 4;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 213);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 401;
            this.label2.Text = "Importe:";
            // 
            // dtFecha
            // 
            this.dtFecha.Enabled = false;
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(237, 6);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 0;
            this.dtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFecha_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 396;
            this.label1.Text = "Fecha:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(96, 73);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoCliente.TabIndex = 2;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(133, 77);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Cliente (F2):";
            // 
            // frmDescuentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(334, 307);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtCodigoVendedor);
            this.Controls.Add(this.lblNombreVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label4);
            this.Name = "frmDescuentos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        public System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtImporte;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.TextBox txtCodigoVendedor;
        public System.Windows.Forms.Label lblNombreVendedor;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObservaciones;
    }
}
