namespace Presentacion
{
    partial class frmPuesto
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtBasico = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(360, 50);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(412, 198);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Básico:";
            // 
            // txtBasico
            // 
            this.txtBasico.Enabled = false;
            this.txtBasico.Location = new System.Drawing.Point(360, 84);
            this.txtBasico.Margin = new System.Windows.Forms.Padding(2);
            this.txtBasico.Name = "txtBasico";
            this.txtBasico.Size = new System.Drawing.Size(131, 20);
            this.txtBasico.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Descripción:";
            // 
            // frmPuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(502, 237);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBasico);
            this.Name = "frmPuesto";
            this.Load += new System.EventHandler(this.frmPuesto_Load);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnConfirmar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.txtBasico, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtBasico;
        private System.Windows.Forms.Label label1;
    }
}
