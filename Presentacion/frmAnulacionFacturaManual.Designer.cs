namespace Presentacion
{
    partial class frmAnulacionFacturaManual
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Nro Comprobante:";
            // 
            // ucNumeroComprobante
            // 
            this.ucNumeroComprobante.Location = new System.Drawing.Point(103, 60);
            this.ucNumeroComprobante.Margin = new System.Windows.Forms.Padding(4);
            this.ucNumeroComprobante.Name = "ucNumeroComprobante";
            this.ucNumeroComprobante.Size = new System.Drawing.Size(118, 29);
            this.ucNumeroComprobante.TabIndex = 62;
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.FormattingEnabled = true;
            this.cbTipoComprobante.Location = new System.Drawing.Point(106, 22);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(194, 21);
            this.cbTipoComprobante.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Tipo Comprobante:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(207, 109);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 66;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(44, 109);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 65;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmAnulacionFacturaManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(323, 159);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucNumeroComprobante);
            this.Controls.Add(this.cbTipoComprobante);
            this.Controls.Add(this.label4);
            this.Name = "frmAnulacionFacturaManual";
            this.Load += new System.EventHandler(this.frmAnulacionFacturaManual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Presentacion.ucNumeroComprobante ucNumeroComprobante;
        public System.Windows.Forms.ComboBox cbTipoComprobante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
    }
}
