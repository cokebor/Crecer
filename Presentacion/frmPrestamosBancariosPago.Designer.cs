namespace Presentacion
{
    partial class frmPrestamosBancariosPago
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
            this.dtpFechaContable = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValorCuota = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCapitalAmortizado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCuotas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNroPrestamo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpFechaContable
            // 
            this.dtpFechaContable.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaContable.Location = new System.Drawing.Point(363, 12);
            this.dtpFechaContable.Name = "dtpFechaContable";
            this.dtpFechaContable.Size = new System.Drawing.Size(86, 20);
            this.dtpFechaContable.TabIndex = 428;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(278, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 427;
            this.label10.Text = "Fecha Contable:";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(107, 12);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 426;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 425;
            this.label9.Text = "Fecha:";
            // 
            // txtValorCuota
            // 
            this.txtValorCuota.Location = new System.Drawing.Point(363, 149);
            this.txtValorCuota.Name = "txtValorCuota";
            this.txtValorCuota.ReadOnly = true;
            this.txtValorCuota.ShortcutsEnabled = false;
            this.txtValorCuota.Size = new System.Drawing.Size(110, 20);
            this.txtValorCuota.TabIndex = 424;
            this.txtValorCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 423;
            this.label8.Text = "Valor Cuota:";
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(107, 150);
            this.txtIva.Name = "txtIva";
            this.txtIva.ShortcutsEnabled = false;
            this.txtIva.Size = new System.Drawing.Size(123, 20);
            this.txtIva.TabIndex = 422;
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva.TextChanged += new System.EventHandler(this.txtIva_TextChanged);
            this.txtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIva_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 421;
            this.label7.Text = "IVA:";
            // 
            // txtInteres
            // 
            this.txtInteres.Location = new System.Drawing.Point(363, 116);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.ShortcutsEnabled = false;
            this.txtInteres.Size = new System.Drawing.Size(110, 20);
            this.txtInteres.TabIndex = 420;
            this.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInteres.TextChanged += new System.EventHandler(this.txtInteres_TextChanged);
            this.txtInteres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteres_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 419;
            this.label6.Text = "Interes:";
            // 
            // txtCapitalAmortizado
            // 
            this.txtCapitalAmortizado.Location = new System.Drawing.Point(107, 116);
            this.txtCapitalAmortizado.Name = "txtCapitalAmortizado";
            this.txtCapitalAmortizado.ShortcutsEnabled = false;
            this.txtCapitalAmortizado.Size = new System.Drawing.Size(123, 20);
            this.txtCapitalAmortizado.TabIndex = 418;
            this.txtCapitalAmortizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCapitalAmortizado.TextChanged += new System.EventHandler(this.txtCapitalAmortizado_TextChanged);
            this.txtCapitalAmortizado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCapitalAmortizado_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 417;
            this.label5.Text = "Capital Amortizado:";
            // 
            // cbCuotas
            // 
            this.cbCuotas.FormattingEnabled = true;
            this.cbCuotas.Location = new System.Drawing.Point(363, 82);
            this.cbCuotas.Name = "cbCuotas";
            this.cbCuotas.Size = new System.Drawing.Size(110, 21);
            this.cbCuotas.TabIndex = 416;
            this.cbCuotas.SelectedIndexChanged += new System.EventHandler(this.cbCuotas_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 415;
            this.label3.Text = "Cuota:";
            // 
            // cbNroPrestamo
            // 
            this.cbNroPrestamo.FormattingEnabled = true;
            this.cbNroPrestamo.Location = new System.Drawing.Point(107, 81);
            this.cbNroPrestamo.Name = "cbNroPrestamo";
            this.cbNroPrestamo.Size = new System.Drawing.Size(123, 21);
            this.cbNroPrestamo.TabIndex = 413;
            this.cbNroPrestamo.SelectedIndexChanged += new System.EventHandler(this.cbNroPrestamo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 414;
            this.label1.Text = "Nro de Prestamo:";
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(107, 46);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(138, 21);
            this.cbBancos.TabIndex = 409;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 411;
            this.label2.Text = "Banco:";
            // 
            // cbCuentaBancaria
            // 
            this.cbCuentaBancaria.FormattingEnabled = true;
            this.cbCuentaBancaria.Location = new System.Drawing.Point(363, 46);
            this.cbCuentaBancaria.Name = "cbCuentaBancaria";
            this.cbCuentaBancaria.Size = new System.Drawing.Size(117, 21);
            this.cbCuentaBancaria.TabIndex = 410;
            this.cbCuentaBancaria.SelectedIndexChanged += new System.EventHandler(this.cbCuentaBancaria_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 412;
            this.label4.Text = "Nro de Cuenta:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(394, 189);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 549;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(301, 189);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 548;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmPrestamosBancariosPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(495, 230);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dtpFechaContable);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtValorCuota);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIva);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInteres);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCapitalAmortizado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbCuotas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbNroPrestamo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBancos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCuentaBancaria);
            this.Controls.Add(this.label4);
            this.Name = "frmPrestamosBancariosPago";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbNroPrestamo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbCuotas;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCapitalAmortizado;
        public System.Windows.Forms.TextBox txtInteres;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtValorCuota;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.Label label9;
        internal System.Windows.Forms.DateTimePicker dtpFechaContable;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
    }
}
