namespace Presentacion
{
    partial class frmNDChequesRechazadosProveedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.txtGastos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTipoComprobanteProveedor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dtFechaCont = new System.Windows.Forms.DateTimePicker();
            this.Label16 = new System.Windows.Forms.Label();
            this.cbTiempo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ucNumeroComprobante = new Presentacion.ucNumeroComprobante();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(747, 542);
            this.shapeContainer1.TabIndex = 61;
            this.shapeContainer1.TabStop = false;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer1";
            this.shapeContainer2.Size = new System.Drawing.Size(747, 542);
            this.shapeContainer2.TabIndex = 61;
            this.shapeContainer2.TabStop = false;
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(188, 7);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(368, 497);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(269, 497);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Location = new System.Drawing.Point(13, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 69);
            this.groupBox1.TabIndex = 415;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motivo de Rechazo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(5, 18);
            this.txtMotivo.Margin = new System.Windows.Forms.Padding(2);
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(421, 46);
            this.txtMotivo.TabIndex = 0;
            // 
            // txtGastos
            // 
            this.txtGastos.Location = new System.Drawing.Point(52, 370);
            this.txtGastos.Margin = new System.Windows.Forms.Padding(2);
            this.txtGastos.Name = "txtGastos";
            this.txtGastos.Size = new System.Drawing.Size(92, 20);
            this.txtGastos.TabIndex = 5;
            this.txtGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastos.TextChanged += new System.EventHandler(this.txtGastos_TextChanged);
            this.txtGastos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGastos_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 373);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 413;
            this.label2.Text = "Gastos:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(386, 61);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.Codigo,
            this.CodigoBanco,
            this.Banco,
            this.Numero,
            this.Importe,
            this.CodigoCuentaBancaria});
            this.dgvDatos.Location = new System.Drawing.Point(10, 106);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(437, 256);
            this.dgvDatos.TabIndex = 4;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // Seleccionado
            // 
            this.Seleccionado.DataPropertyName = "Seleccionado";
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // CodigoBanco
            // 
            this.CodigoBanco.DataPropertyName = "CodigoBanco";
            this.CodigoBanco.HeaderText = "CodigoBanco";
            this.CodigoBanco.Name = "CodigoBanco";
            this.CodigoBanco.Visible = false;
            // 
            // Banco
            // 
            this.Banco.DataPropertyName = "Banco";
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "NroCheque";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle4;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // CodigoCuentaBancaria
            // 
            this.CodigoCuentaBancaria.DataPropertyName = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.HeaderText = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.Name = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.Visible = false;
            // 
            // lblTipoComprobanteProveedor
            // 
            this.lblTipoComprobanteProveedor.AutoSize = true;
            this.lblTipoComprobanteProveedor.Location = new System.Drawing.Point(313, 39);
            this.lblTipoComprobanteProveedor.Name = "lblTipoComprobanteProveedor";
            this.lblTipoComprobanteProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblTipoComprobanteProveedor.TabIndex = 406;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 404;
            this.label1.Text = "Fecha:";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(87, 32);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoProveedor.TabIndex = 1;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.Location = new System.Drawing.Point(124, 37);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(175, 15);
            this.lblNombreProveedor.TabIndex = 403;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 402;
            this.label4.Text = "Proveedor (F6):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 373);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 421;
            this.label5.Text = "IVA 21%.:";
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(221, 370);
            this.txtIVA.Margin = new System.Windows.Forms.Padding(2);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(63, 20);
            this.txtIVA.TabIndex = 422;
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(292, 475);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 424;
            this.label14.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(347, 473);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 423;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtFechaCont
            // 
            this.dtFechaCont.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaCont.Location = new System.Drawing.Point(359, 7);
            this.dtFechaCont.Name = "dtFechaCont";
            this.dtFechaCont.Size = new System.Drawing.Size(88, 20);
            this.dtFechaCont.TabIndex = 425;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(276, 10);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(85, 13);
            this.Label16.TabIndex = 426;
            this.Label16.Text = "Fecha Contable:";
            // 
            // cbTiempo
            // 
            this.cbTiempo.AutoSize = true;
            this.cbTiempo.Checked = true;
            this.cbTiempo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTiempo.Location = new System.Drawing.Point(269, 66);
            this.cbTiempo.Margin = new System.Windows.Forms.Padding(2);
            this.cbTiempo.Name = "cbTiempo";
            this.cbTiempo.Size = new System.Drawing.Size(113, 17);
            this.cbTiempo.TabIndex = 427;
            this.cbTiempo.Text = "Ultimos tres meses";
            this.cbTiempo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 429;
            this.label3.Text = "Número:";
            // 
            // ucNumeroComprobante
            // 
            this.ucNumeroComprobante.Location = new System.Drawing.Point(85, 61);
            this.ucNumeroComprobante.Margin = new System.Windows.Forms.Padding(4);
            this.ucNumeroComprobante.Name = "ucNumeroComprobante";
            this.ucNumeroComprobante.Size = new System.Drawing.Size(118, 30);
            this.ucNumeroComprobante.TabIndex = 428;
            // 
            // frmNDChequesRechazadosProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(456, 528);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ucNumeroComprobante);
            this.Controls.Add(this.cbTiempo);
            this.Controls.Add(this.dtFechaCont);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGastos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.lblTipoComprobanteProveedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.label4);
            this.Name = "frmNDChequesRechazadosProveedores";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTipoComprobanteProveedor;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        public System.Windows.Forms.Label label4;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtGastos;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtMotivo;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtIVA;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.DateTimePicker dtFechaCont;
        internal System.Windows.Forms.Label Label16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaBancaria;
        private System.Windows.Forms.CheckBox cbTiempo;
        private System.Windows.Forms.Label label3;
        private ucNumeroComprobante ucNumeroComprobante;
    }
}
