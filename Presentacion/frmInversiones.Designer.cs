namespace Presentacion
{
    partial class frmInversiones
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
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOperaciones = new System.Windows.Forms.ComboBox();
            this.ucPlazoFijoConstitucion = new Presentacion.Controles.ucPlazoFijo();
            this.rbConstitucion = new System.Windows.Forms.RadioButton();
            this.rbVencimiento = new System.Windows.Forms.RadioButton();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucPlazoFijoVencimiento = new Presentacion.Controles.ucPlazoFijoVencimiento();
            this.ucFondoComunSuscripcion = new Presentacion.Controles.ucFondoComunSuscripcion();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtNroReferencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(377, 12);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 1;
            this.dtFecha.ValueChanged += new System.EventHandler(this.dtFecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 407;
            this.label1.Text = "Fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 416;
            this.label3.Text = "Operación:";
            // 
            // cbOperaciones
            // 
            this.cbOperaciones.FormattingEnabled = true;
            this.cbOperaciones.Location = new System.Drawing.Point(83, 11);
            this.cbOperaciones.Name = "cbOperaciones";
            this.cbOperaciones.Size = new System.Drawing.Size(155, 21);
            this.cbOperaciones.TabIndex = 0;
            this.cbOperaciones.SelectedIndexChanged += new System.EventHandler(this.cbOperaciones_SelectedIndexChanged);
            // 
            // ucPlazoFijoConstitucion
            // 
            this.ucPlazoFijoConstitucion.Location = new System.Drawing.Point(5, 68);
            this.ucPlazoFijoConstitucion.Name = "ucPlazoFijoConstitucion";
            this.ucPlazoFijoConstitucion.Size = new System.Drawing.Size(469, 113);
            this.ucPlazoFijoConstitucion.TabIndex = 417;
            // 
            // rbConstitucion
            // 
            this.rbConstitucion.AutoSize = true;
            this.rbConstitucion.Checked = true;
            this.rbConstitucion.Location = new System.Drawing.Point(12, 45);
            this.rbConstitucion.Name = "rbConstitucion";
            this.rbConstitucion.Size = new System.Drawing.Size(83, 17);
            this.rbConstitucion.TabIndex = 2;
            this.rbConstitucion.TabStop = true;
            this.rbConstitucion.Text = "Constitución";
            this.rbConstitucion.UseVisualStyleBackColor = true;
            this.rbConstitucion.CheckedChanged += new System.EventHandler(this.rbConstitucion_CheckedChanged);
            // 
            // rbVencimiento
            // 
            this.rbVencimiento.AutoSize = true;
            this.rbVencimiento.Location = new System.Drawing.Point(101, 45);
            this.rbVencimiento.Name = "rbVencimiento";
            this.rbVencimiento.Size = new System.Drawing.Size(83, 17);
            this.rbVencimiento.TabIndex = 3;
            this.rbVencimiento.Text = "Vencimiento";
            this.rbVencimiento.UseVisualStyleBackColor = true;
            this.rbVencimiento.CheckedChanged += new System.EventHandler(this.rbVencimiento_CheckedChanged);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(13, 198);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(450, 45);
            this.txtObservaciones.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 182);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Observaciones:";
            // 
            // ucPlazoFijoVencimiento
            // 
            this.ucPlazoFijoVencimiento.Location = new System.Drawing.Point(5, 68);
            this.ucPlazoFijoVencimiento.Name = "ucPlazoFijoVencimiento";
            this.ucPlazoFijoVencimiento.Size = new System.Drawing.Size(469, 110);
            this.ucPlazoFijoVencimiento.TabIndex = 422;
            // 
            // ucFondoComunSuscripcion
            // 
            this.ucFondoComunSuscripcion.Location = new System.Drawing.Point(5, 68);
            this.ucFondoComunSuscripcion.Name = "ucFondoComunSuscripcion";
            this.ucFondoComunSuscripcion.Size = new System.Drawing.Size(469, 110);
            this.ucFondoComunSuscripcion.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(384, 254);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(285, 254);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtNroReferencia
            // 
            this.txtNroReferencia.Location = new System.Drawing.Point(345, 43);
            this.txtNroReferencia.Name = "txtNroReferencia";
            this.txtNroReferencia.Size = new System.Drawing.Size(118, 20);
            this.txtNroReferencia.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 429;
            this.label4.Text = "Nro Referencia:";
            // 
            // frmInversiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(473, 291);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNroReferencia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.ucFondoComunSuscripcion);
            this.Controls.Add(this.ucPlazoFijoVencimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.rbVencimiento);
            this.Controls.Add(this.rbConstitucion);
            this.Controls.Add(this.ucPlazoFijoConstitucion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbOperaciones);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label1);
            this.Name = "frmInversiones";
            this.Activated += new System.EventHandler(this.frmInversiones_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbOperaciones;
        private Controles.ucPlazoFijo ucPlazoFijoConstitucion;
        private System.Windows.Forms.RadioButton rbConstitucion;
        private System.Windows.Forms.RadioButton rbVencimiento;
        private System.Windows.Forms.TextBox txtObservaciones;
        public System.Windows.Forms.Label label2;
        private Controles.ucPlazoFijoVencimiento ucPlazoFijoVencimiento;
        private Controles.ucFondoComunSuscripcion ucFondoComunSuscripcion;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtNroReferencia;
        private System.Windows.Forms.Label label4;
    }
}
