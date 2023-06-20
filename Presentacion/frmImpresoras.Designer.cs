namespace Presentacion
{
    partial class frmImpresoras
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
            this.cbImpresorasComprobantes = new System.Windows.Forms.ComboBox();
            this.lblLabel1 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbImpresorasInformes = new System.Windows.Forms.ComboBox();
            this.cbTermica = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbImpresorasComprobantes
            // 
            this.cbImpresorasComprobantes.FormattingEnabled = true;
            this.cbImpresorasComprobantes.Location = new System.Drawing.Point(102, 22);
            this.cbImpresorasComprobantes.Name = "cbImpresorasComprobantes";
            this.cbImpresorasComprobantes.Size = new System.Drawing.Size(183, 21);
            this.cbImpresorasComprobantes.TabIndex = 0;
            // 
            // lblLabel1
            // 
            this.lblLabel1.AutoSize = true;
            this.lblLabel1.Location = new System.Drawing.Point(22, 25);
            this.lblLabel1.Name = "lblLabel1";
            this.lblLabel1.Size = new System.Drawing.Size(78, 13);
            this.lblLabel1.TabIndex = 2;
            this.lblLabel1.Text = "Comprobantes:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(296, 101);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 18;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Informes:";
            // 
            // cbImpresorasInformes
            // 
            this.cbImpresorasInformes.FormattingEnabled = true;
            this.cbImpresorasInformes.Location = new System.Drawing.Point(102, 60);
            this.cbImpresorasInformes.Name = "cbImpresorasInformes";
            this.cbImpresorasInformes.Size = new System.Drawing.Size(183, 21);
            this.cbImpresorasInformes.TabIndex = 21;
            // 
            // cbTermica
            // 
            this.cbTermica.AutoSize = true;
            this.cbTermica.Location = new System.Drawing.Point(292, 25);
            this.cbTermica.Name = "cbTermica";
            this.cbTermica.Size = new System.Drawing.Size(64, 17);
            this.cbTermica.TabIndex = 22;
            this.cbTermica.Text = "Termica";
            this.cbTermica.UseVisualStyleBackColor = true;
            // 
            // frmImpresoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(391, 140);
            this.Controls.Add(this.cbTermica);
            this.Controls.Add(this.cbImpresorasInformes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblLabel1);
            this.Controls.Add(this.cbImpresorasComprobantes);
            this.Name = "frmImpresoras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbImpresorasComprobantes;
        private System.Windows.Forms.Label lblLabel1;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbImpresorasInformes;
        private System.Windows.Forms.CheckBox cbTermica;
    }
}
