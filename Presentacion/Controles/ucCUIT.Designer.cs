namespace Presentacion

{
    partial class ucCUIT
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
            this.txtCUIL1 = new System.Windows.Forms.TextBox();
            this.txtCUIL2 = new System.Windows.Forms.TextBox();
            this.txtCUIL3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCUIL1
            // 
            this.txtCUIL1.Enabled = false;
            this.txtCUIL1.Location = new System.Drawing.Point(0, 0);
            this.txtCUIL1.Margin = new System.Windows.Forms.Padding(4);
            this.txtCUIL1.MaxLength = 2;
            this.txtCUIL1.Name = "txtCUIL1";
            this.txtCUIL1.ShortcutsEnabled = false;
            this.txtCUIL1.Size = new System.Drawing.Size(23, 22);
            this.txtCUIL1.TabIndex = 1;
            this.txtCUIL1.TextChanged += new System.EventHandler(this.txtCUIL1_TextChanged);
            this.txtCUIL1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIL1_KeyPress);
            // 
            // txtCUIL2
            // 
            this.txtCUIL2.Enabled = false;
            this.txtCUIL2.Location = new System.Drawing.Point(32, 0);
            this.txtCUIL2.Margin = new System.Windows.Forms.Padding(4);
            this.txtCUIL2.MaxLength = 8;
            this.txtCUIL2.Name = "txtCUIL2";
            this.txtCUIL2.ShortcutsEnabled = false;
            this.txtCUIL2.Size = new System.Drawing.Size(73, 22);
            this.txtCUIL2.TabIndex = 2;
            this.txtCUIL2.TextChanged += new System.EventHandler(this.txtCUIL2_TextChanged);
            this.txtCUIL2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIL2_KeyPress);
            // 
            // txtCUIL3
            // 
            this.txtCUIL3.Enabled = false;
            this.txtCUIL3.Location = new System.Drawing.Point(115, 0);
            this.txtCUIL3.Margin = new System.Windows.Forms.Padding(4);
            this.txtCUIL3.MaxLength = 1;
            this.txtCUIL3.Name = "txtCUIL3";
            this.txtCUIL3.ShortcutsEnabled = false;
            this.txtCUIL3.Size = new System.Drawing.Size(16, 22);
            this.txtCUIL3.TabIndex = 3;
            this.txtCUIL3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIL3_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // ucCUIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtCUIL3);
            this.Controls.Add(this.txtCUIL2);
            this.Controls.Add(this.txtCUIL1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucCUIT";
            this.Size = new System.Drawing.Size(135, 26);
            this.Load += new System.EventHandler(this.ucCUIT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCUIL3;
        public System.Windows.Forms.TextBox txtCUIL1;
        public System.Windows.Forms.TextBox txtCUIL2;
    }
}
