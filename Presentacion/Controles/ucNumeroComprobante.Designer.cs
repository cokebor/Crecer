namespace Presentacion
{
    partial class ucNumeroComprobante
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtPuntoVenta = new System.Windows.Forms.TextBox();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(61, 3);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(54, 20);
            this.txtNumero.TabIndex = 6;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIL3_KeyPress);
            this.txtNumero.Leave += new System.EventHandler(this.txtCUIL3_Leave);
            // 
            // txtPuntoVenta
            // 
            this.txtPuntoVenta.Location = new System.Drawing.Point(25, 3);
            this.txtPuntoVenta.MaxLength = 4;
            this.txtPuntoVenta.Name = "txtPuntoVenta";
            this.txtPuntoVenta.Size = new System.Drawing.Size(30, 20);
            this.txtPuntoVenta.TabIndex = 5;
            this.txtPuntoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPuntoVenta.TextChanged += new System.EventHandler(this.txtCUIL2_TextChanged);
            this.txtPuntoVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIL2_KeyPress);
            this.txtPuntoVenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCUIL2_KeyUp);
            this.txtPuntoVenta.Leave += new System.EventHandler(this.txtCUIL2_Leave);
            // 
            // txtLetra
            // 
            this.txtLetra.Location = new System.Drawing.Point(4, 3);
            this.txtLetra.MaxLength = 1;
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(15, 20);
            this.txtLetra.TabIndex = 4;
            this.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLetra.TextChanged += new System.EventHandler(this.txtCUIL1_TextChanged);
            this.txtLetra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCUIL1_KeyDown);
            this.txtLetra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIL1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "-";
            // 
            // txtNumeroComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtPuntoVenta);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "txtNumeroComprobante";
            this.Size = new System.Drawing.Size(118, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtNumero;
        public System.Windows.Forms.TextBox txtPuntoVenta;
        public System.Windows.Forms.TextBox txtLetra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
