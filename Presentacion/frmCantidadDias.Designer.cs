
namespace Presentacion
{
    partial class frmCantidadDias
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtCantidadDias = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(78, 58);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtCantidadDias
            // 
            this.txtCantidadDias.Location = new System.Drawing.Point(180, 20);
            this.txtCantidadDias.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidadDias.Name = "txtCantidadDias";
            this.txtCantidadDias.Size = new System.Drawing.Size(70, 20);
            this.txtCantidadDias.TabIndex = 0;
            this.txtCantidadDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidadDias.TextChanged += new System.EventHandler(this.txtCantidadDias_TextChanged);
            this.txtCantidadDias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadDias_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 549;
            this.label1.Text = "Dias Trabajados:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(171, 58);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCantidadDias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(342, 88);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidadDias);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "frmCantidadDias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.TextBox txtCantidadDias;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnCancelar;
    }
}
