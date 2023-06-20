namespace Presentacion
{
    partial class frmRubroProducto
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIncluirEnInforme = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(365, 50);
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(362, 20);
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
            this.btnCancelar.Location = new System.Drawing.Point(417, 198);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Codigo:";
            // 
            // cbIncluirEnInforme
            // 
            this.cbIncluirEnInforme.AutoSize = true;
            this.cbIncluirEnInforme.Enabled = false;
            this.cbIncluirEnInforme.Location = new System.Drawing.Point(297, 86);
            this.cbIncluirEnInforme.Name = "cbIncluirEnInforme";
            this.cbIncluirEnInforme.Size = new System.Drawing.Size(107, 17);
            this.cbIncluirEnInforme.TabIndex = 20;
            this.cbIncluirEnInforme.Text = "Incluir en Informe";
            this.cbIncluirEnInforme.UseVisualStyleBackColor = true;
            // 
            // frmRubroProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(505, 237);
            this.Controls.Add(this.cbIncluirEnInforme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRubroProducto";
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnConfirmar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbIncluirEnInforme, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbIncluirEnInforme;
    }
}
