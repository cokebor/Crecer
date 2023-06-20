using Controles2;

namespace Presentacion
{
    partial class frmCuentaContable
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
            this.cbCuentasPadres = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCuentaContable = new System.Windows.Forms.TextBox();
            this.cbEsPadre = new System.Windows.Forms.CheckBox();
            this.txtCodigoJerarquico1 = new txtCodigoJerarquico();
            this.SuspendLayout();
            // 
            // cbCuentasPadres
            // 
            this.cbCuentasPadres.Enabled = false;
            this.cbCuentasPadres.FormattingEnabled = true;
            this.cbCuentasPadres.Location = new System.Drawing.Point(114, 22);
            this.cbCuentasPadres.Name = "cbCuentasPadres";
            this.cbCuentasPadres.Size = new System.Drawing.Size(204, 21);
            this.cbCuentasPadres.TabIndex = 0;
            this.cbCuentasPadres.SelectedIndexChanged += new System.EventHandler(this.cbCuentasPadres_SelectedIndexChanged);
            this.cbCuentasPadres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCuentasPadres_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Cuenta Padre:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(249, 178);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(98, 178);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(7, 178);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 23;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Codigo Jerarquico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Cuenta Contable:";
            // 
            // txtCuentaContable
            // 
            this.txtCuentaContable.Enabled = false;
            this.txtCuentaContable.Location = new System.Drawing.Point(112, 98);
            this.txtCuentaContable.Margin = new System.Windows.Forms.Padding(2);
            this.txtCuentaContable.MaxLength = 50;
            this.txtCuentaContable.Name = "txtCuentaContable";
            this.txtCuentaContable.Size = new System.Drawing.Size(206, 20);
            this.txtCuentaContable.TabIndex = 2;
            this.txtCuentaContable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuentaContable_KeyPress);
            // 
            // cbEsPadre
            // 
            this.cbEsPadre.AutoSize = true;
            this.cbEsPadre.Enabled = false;
            this.cbEsPadre.Location = new System.Drawing.Point(19, 140);
            this.cbEsPadre.Name = "cbEsPadre";
            this.cbEsPadre.Size = new System.Drawing.Size(69, 17);
            this.cbEsPadre.TabIndex = 3;
            this.cbEsPadre.Text = "Es Padre";
            this.cbEsPadre.UseVisualStyleBackColor = true;
            this.cbEsPadre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEsPadre_KeyPress);
            // 
            // txtCodigoJerarquico1
            // 
            this.txtCodigoJerarquico1.Enabled = false;
            this.txtCodigoJerarquico1.Location = new System.Drawing.Point(112, 57);
            this.txtCodigoJerarquico1.Name = "txtCodigoJerarquico1";
            this.txtCodigoJerarquico1.Size = new System.Drawing.Size(145, 27);
            this.txtCodigoJerarquico1.TabIndex = 1;
            this.txtCodigoJerarquico1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoJerarquico1_KeyPress);
            // 
            // frmCuentaContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(338, 220);
            this.Controls.Add(this.cbEsPadre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCuentaContable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoJerarquico1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cbCuentasPadres);
            this.Controls.Add(this.label2);
            this.Name = "frmCuentaContable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbCuentasPadres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnNuevo;
        private txtCodigoJerarquico txtCodigoJerarquico1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCuentaContable;
        private System.Windows.Forms.CheckBox cbEsPadre;
    }
}
