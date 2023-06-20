namespace Presentacion
{
    partial class frmAnulacionFacturaCompra
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
            this.label1 = new System.Windows.Forms.Label();
            this.ucNumeroComprobante = new Presentacion.ucNumeroComprobante();
            this.cbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Factura:";
            // 
            // ucNumeroComprobante
            // 
            this.ucNumeroComprobante.Location = new System.Drawing.Point(103, 86);
            this.ucNumeroComprobante.Margin = new System.Windows.Forms.Padding(4);
            this.ucNumeroComprobante.Name = "ucNumeroComprobante";
            this.ucNumeroComprobante.Size = new System.Drawing.Size(118, 29);
            this.ucNumeroComprobante.TabIndex = 2;
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.FormattingEnabled = true;
            this.cbTipoComprobante.Location = new System.Drawing.Point(106, 49);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(194, 21);
            this.cbTipoComprobante.TabIndex = 1;
            this.cbTipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cbTipoComprobante_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Tipo Comprobante:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(207, 136);
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
            this.btnConfirmar.Location = new System.Drawing.Point(44, 136);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(107, 13);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoProveedor.TabIndex = 0;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Location = new System.Drawing.Point(140, 16);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Proveedor (F6):";
            // 
            // frmAnulacionFacturaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(323, 169);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucNumeroComprobante);
            this.Controls.Add(this.cbTipoComprobante);
            this.Controls.Add(this.label4);
            this.Name = "frmAnulacionFacturaCompra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ucNumeroComprobante ucNumeroComprobante;
        public System.Windows.Forms.ComboBox cbTipoComprobante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        public System.Windows.Forms.Label label3;
    }
}
