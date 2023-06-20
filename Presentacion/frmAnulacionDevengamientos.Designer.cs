namespace Presentacion
{
    partial class frmAnulacionDevengamientos
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbPagoDevengamientos = new System.Windows.Forms.RadioButton();
            this.rbDevengamientos = new System.Windows.Forms.RadioButton();
            this.pPagos = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ucNumeroComprobante = new Presentacion.ucNumeroComprobante();
            this.cbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pDevengamientos = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbTipoSalario = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbConcepto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pPagos.SuspendLayout();
            this.pDevengamientos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(239, 136);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 66;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(76, 136);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 65;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbPagoDevengamientos);
            this.panel1.Controls.Add(this.rbDevengamientos);
            this.panel1.Location = new System.Drawing.Point(59, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 30);
            this.panel1.TabIndex = 67;
            // 
            // rbPagoDevengamientos
            // 
            this.rbPagoDevengamientos.AutoSize = true;
            this.rbPagoDevengamientos.Location = new System.Drawing.Point(194, 6);
            this.rbPagoDevengamientos.Name = "rbPagoDevengamientos";
            this.rbPagoDevengamientos.Size = new System.Drawing.Size(55, 17);
            this.rbPagoDevengamientos.TabIndex = 1;
            this.rbPagoDevengamientos.TabStop = true;
            this.rbPagoDevengamientos.Text = "Pagos";
            this.rbPagoDevengamientos.UseVisualStyleBackColor = true;
            this.rbPagoDevengamientos.CheckedChanged += new System.EventHandler(this.rbPagoDevengamientos_CheckedChanged);
            // 
            // rbDevengamientos
            // 
            this.rbDevengamientos.AutoSize = true;
            this.rbDevengamientos.Checked = true;
            this.rbDevengamientos.Location = new System.Drawing.Point(25, 6);
            this.rbDevengamientos.Name = "rbDevengamientos";
            this.rbDevengamientos.Size = new System.Drawing.Size(105, 17);
            this.rbDevengamientos.TabIndex = 0;
            this.rbDevengamientos.TabStop = true;
            this.rbDevengamientos.Text = "Devengamientos";
            this.rbDevengamientos.UseVisualStyleBackColor = true;
            this.rbDevengamientos.CheckedChanged += new System.EventHandler(this.rbDevengamientos_CheckedChanged);
            // 
            // pPagos
            // 
            this.pPagos.Controls.Add(this.label1);
            this.pPagos.Controls.Add(this.ucNumeroComprobante);
            this.pPagos.Controls.Add(this.cbTipoComprobante);
            this.pPagos.Controls.Add(this.label4);
            this.pPagos.Location = new System.Drawing.Point(44, 48);
            this.pPagos.Name = "pPagos";
            this.pPagos.Size = new System.Drawing.Size(299, 83);
            this.pPagos.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Nro Comprobante:";
            // 
            // ucNumeroComprobante
            // 
            this.ucNumeroComprobante.Location = new System.Drawing.Point(96, 40);
            this.ucNumeroComprobante.Margin = new System.Windows.Forms.Padding(4);
            this.ucNumeroComprobante.Name = "ucNumeroComprobante";
            this.ucNumeroComprobante.Size = new System.Drawing.Size(118, 29);
            this.ucNumeroComprobante.TabIndex = 66;
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.FormattingEnabled = true;
            this.cbTipoComprobante.Location = new System.Drawing.Point(99, 8);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(194, 21);
            this.cbTipoComprobante.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Tipo Comprobante:";
            // 
            // pDevengamientos
            // 
            this.pDevengamientos.Controls.Add(this.lblCodigo);
            this.pDevengamientos.Controls.Add(this.label2);
            this.pDevengamientos.Controls.Add(this.label3);
            this.pDevengamientos.Controls.Add(this.cbPeriodo);
            this.pDevengamientos.Controls.Add(this.lblTipo);
            this.pDevengamientos.Controls.Add(this.cbTipoSalario);
            this.pDevengamientos.Controls.Add(this.label17);
            this.pDevengamientos.Controls.Add(this.cbConcepto);
            this.pDevengamientos.Location = new System.Drawing.Point(7, 48);
            this.pDevengamientos.Name = "pDevengamientos";
            this.pDevengamientos.Size = new System.Drawing.Size(384, 83);
            this.pDevengamientos.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 528;
            this.label3.Text = "Periodo:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Location = new System.Drawing.Point(75, 45);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(116, 21);
            this.cbPeriodo.TabIndex = 527;
            this.cbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cbPeriodo_SelectedIndexChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(197, 49);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 526;
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Click += new System.EventHandler(this.lblTipo_Click);
            // 
            // cbTipoSalario
            // 
            this.cbTipoSalario.FormattingEnabled = true;
            this.cbTipoSalario.Location = new System.Drawing.Point(258, 45);
            this.cbTipoSalario.Name = "cbTipoSalario";
            this.cbTipoSalario.Size = new System.Drawing.Size(116, 21);
            this.cbTipoSalario.TabIndex = 525;
            this.cbTipoSalario.SelectedIndexChanged += new System.EventHandler(this.cbTipoSalario_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 524;
            this.label17.Text = "Concepto:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // cbConcepto
            // 
            this.cbConcepto.FormattingEnabled = true;
            this.cbConcepto.Location = new System.Drawing.Point(75, 8);
            this.cbConcepto.Name = "cbConcepto";
            this.cbConcepto.Size = new System.Drawing.Size(162, 21);
            this.cbConcepto.TabIndex = 523;
            this.cbConcepto.SelectedIndexChanged += new System.EventHandler(this.cbConcepto_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 529;
            this.label2.Text = "Cod.:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(296, 69);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(54, 13);
            this.lblCodigo.TabIndex = 530;
            // 
            // frmAnulacionDevengamientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(395, 171);
            this.Controls.Add(this.pDevengamientos);
            this.Controls.Add(this.pPagos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "frmAnulacionDevengamientos";
            this.Load += new System.EventHandler(this.frmAnulacionDevengamientos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pPagos.ResumeLayout(false);
            this.pPagos.PerformLayout();
            this.pDevengamientos.ResumeLayout(false);
            this.pDevengamientos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbPagoDevengamientos;
        private System.Windows.Forms.RadioButton rbDevengamientos;
        private System.Windows.Forms.Panel pPagos;
        private System.Windows.Forms.Label label1;
        private ucNumeroComprobante ucNumeroComprobante;
        public System.Windows.Forms.ComboBox cbTipoComprobante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pDevengamientos;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.Label lblTipo;
        internal System.Windows.Forms.ComboBox cbTipoSalario;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cbConcepto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label2;
    }
}
