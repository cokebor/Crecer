namespace Presentacion
{
    partial class frmCambioClave
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnColorMDI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(123, 169);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.CausesValidation = false;
            this.btnAceptar.Location = new System.Drawing.Point(32, 169);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(79, 26);
            this.btnAceptar.TabIndex = 30;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Confirmar:";
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Location = new System.Drawing.Point(83, 61);
            this.txtConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmar.MaxLength = 50;
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.PasswordChar = '*';
            this.txtConfirmar.Size = new System.Drawing.Size(131, 20);
            this.txtConfirmar.TabIndex = 1;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(26, 99);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(188, 23);
            this.btnColor.TabIndex = 24;
            this.btnColor.Text = "Color Formularios";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(83, 22);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(131, 20);
            this.txtPassword.TabIndex = 0;
            // 
            // btnColorMDI
            // 
            this.btnColorMDI.Location = new System.Drawing.Point(25, 131);
            this.btnColorMDI.Name = "btnColorMDI";
            this.btnColorMDI.Size = new System.Drawing.Size(188, 23);
            this.btnColorMDI.TabIndex = 32;
            this.btnColorMDI.Text = "Color Fondo Formulario Principal";
            this.btnColorMDI.UseVisualStyleBackColor = true;
            this.btnColorMDI.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCambioClave
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(225, 206);
            this.Controls.Add(this.btnColorMDI);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Name = "frmCambioClave";
            this.Text = "Cambiar Clave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtConfirmar;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnColorMDI;
    }
}