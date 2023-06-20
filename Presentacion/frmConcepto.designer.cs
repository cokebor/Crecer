namespace Presentacion
{
    partial class frmConcepto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbImpuesto = new System.Windows.Forms.CheckBox();
            this.cmsAsociar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asociarACuentaContableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAsociar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(378, 50);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(380, 20);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(192, 227);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(11, 227);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(102, 227);
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(430, 228);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Descripción:";
            // 
            // cbImpuesto
            // 
            this.cbImpuesto.AutoSize = true;
            this.cbImpuesto.Enabled = false;
            this.cbImpuesto.Location = new System.Drawing.Point(299, 87);
            this.cbImpuesto.Margin = new System.Windows.Forms.Padding(2);
            this.cbImpuesto.Name = "cbImpuesto";
            this.cbImpuesto.Size = new System.Drawing.Size(69, 17);
            this.cbImpuesto.TabIndex = 16;
            this.cbImpuesto.Text = "Impuesto";
            this.cbImpuesto.UseVisualStyleBackColor = true;
            // 
            // cmsAsociar
            // 
            this.cmsAsociar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAsociar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asociarACuentaContableToolStripMenuItem});
            this.cmsAsociar.Name = "cmsAsociar";
            this.cmsAsociar.Size = new System.Drawing.Size(215, 26);
            // 
            // asociarACuentaContableToolStripMenuItem
            // 
            this.asociarACuentaContableToolStripMenuItem.Name = "asociarACuentaContableToolStripMenuItem";
            this.asociarACuentaContableToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.asociarACuentaContableToolStripMenuItem.Text = "Asociar a Cuenta Contable";
            this.asociarACuentaContableToolStripMenuItem.Click += new System.EventHandler(this.asociarACuentaContableToolStripMenuItem_Click);
            // 
            // frmConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 264);
            this.Controls.Add(this.cbImpuesto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmConcepto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConcepto";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnConfirmar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbImpuesto, 0);
            this.cmsAsociar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbImpuesto;
        private System.Windows.Forms.ContextMenuStrip cmsAsociar;
        private System.Windows.Forms.ToolStripMenuItem asociarACuentaContableToolStripMenuItem;
    }
}