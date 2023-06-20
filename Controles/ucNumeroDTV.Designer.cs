namespace Controles2
{
    partial class ucNumeroDTV
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
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(2, 3);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(54, 20);
            this.txtNumero.TabIndex = 6;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // txtNumero2
            // 
            this.txtNumero2.Location = new System.Drawing.Point(64, 3);
            this.txtNumero2.MaxLength = 1;
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(15, 20);
            this.txtNumero2.TabIndex = 4;
            this.txtNumero2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumero2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            this.txtNumero2.Leave += new System.EventHandler(this.txtNumero2_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "-";
            // 
            // ucNumeroDTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtNumero2);
            this.Controls.Add(this.label1);
            this.Name = "ucNumeroDTV";
            this.Size = new System.Drawing.Size(83, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtNumero;
        public System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.Label label1;
    }
}
