namespace Presentacion
{
    partial class ucFormasPagoCompras
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ucTranferenciasBancarias = new Presentacion.ucTranferenciasBancarias();
            this.ucChequesTerceros = new Presentacion.ucChequesTerceros();
            this.ucChequePropio = new Presentacion.ucChequePropio();
            this.ucCheque = new Presentacion.ucCheque();
            this.ucContado = new Presentacion.ucContado();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFormasDePago = new System.Windows.Forms.ComboBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.ucDebitoCredito = new Presentacion.ucDebitoCredito();
            this.FormaDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContable2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Librador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuotas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroCupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // ucTranferenciasBancarias
            // 
            this.ucTranferenciasBancarias.Location = new System.Drawing.Point(3, 52);
            this.ucTranferenciasBancarias.Name = "ucTranferenciasBancarias";
            this.ucTranferenciasBancarias.Size = new System.Drawing.Size(516, 64);
            this.ucTranferenciasBancarias.TabIndex = 148;
            // 
            // ucChequesTerceros
            // 
            this.ucChequesTerceros.Location = new System.Drawing.Point(240, 63);
            this.ucChequesTerceros.Margin = new System.Windows.Forms.Padding(2);
            this.ucChequesTerceros.Name = "ucChequesTerceros";
            this.ucChequesTerceros.Size = new System.Drawing.Size(38, 41);
            this.ucChequesTerceros.TabIndex = 147;
            // 
            // ucChequePropio
            // 
            this.ucChequePropio.Location = new System.Drawing.Point(3, 27);
            this.ucChequePropio.Margin = new System.Windows.Forms.Padding(4);
            this.ucChequePropio.Name = "ucChequePropio";
            this.ucChequePropio.Size = new System.Drawing.Size(509, 127);
            this.ucChequePropio.TabIndex = 146;
            // 
            // ucCheque
            // 
            this.ucCheque.Location = new System.Drawing.Point(3, 27);
            this.ucCheque.Margin = new System.Windows.Forms.Padding(4);
            this.ucCheque.Name = "ucCheque";
            this.ucCheque.Size = new System.Drawing.Size(516, 125);
            this.ucCheque.TabIndex = 141;
            // 
            // ucContado
            // 
            this.ucContado.Location = new System.Drawing.Point(3, 52);
            this.ucContado.Margin = new System.Windows.Forms.Padding(4);
            this.ucContado.Name = "ucContado";
            this.ucContado.Size = new System.Drawing.Size(516, 64);
            this.ucContado.TabIndex = 140;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FormaDePago,
            this.Tipo,
            this.CodigoMoneda,
            this.Descripcion,
            this.Cotizacion,
            this.Importe2,
            this.Importe3,
            this.CodigoCuentaContable2,
            this.CodigoBanco,
            this.FechaEmision,
            this.FechaPago,
            this.Librador,
            this.NumeroCheque,
            this.CUIT,
            this.CodigoCuentaBancaria,
            this.CodigoCheque,
            this.CodigoTipoTarjeta,
            this.Cuotas,
            this.NroCupon});
            this.dgvDatos.Location = new System.Drawing.Point(21, 161);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(446, 97);
            this.dgvDatos.TabIndex = 142;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 145;
            this.label4.Text = "Forma de Pago:";
            // 
            // cbFormasDePago
            // 
            this.cbFormasDePago.FormattingEnabled = true;
            this.cbFormasDePago.Location = new System.Drawing.Point(112, 6);
            this.cbFormasDePago.Margin = new System.Windows.Forms.Padding(2);
            this.cbFormasDePago.Name = "cbFormasDePago";
            this.cbFormasDePago.Size = new System.Drawing.Size(158, 21);
            this.cbFormasDePago.TabIndex = 139;
            this.cbFormasDePago.SelectedIndexChanged += new System.EventHandler(this.cbFormasDePago_SelectedIndexChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = global::Presentacion.Properties.Resources.pencil;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(484, 201);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(25, 25);
            this.btnEditar.TabIndex = 144;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = global::Presentacion.Properties.Resources.remove;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(484, 161);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 25);
            this.btnEliminar.TabIndex = 143;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ucDebitoCredito
            // 
            this.ucDebitoCredito.Location = new System.Drawing.Point(3, 32);
            this.ucDebitoCredito.Name = "ucDebitoCredito";
            this.ucDebitoCredito.Size = new System.Drawing.Size(523, 101);
            this.ucDebitoCredito.TabIndex = 150;
            this.ucDebitoCredito.Ventas = false;
            // 
            // FormaDePago
            // 
            this.FormaDePago.HeaderText = "FormaDePago";
            this.FormaDePago.Name = "FormaDePago";
            this.FormaDePago.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // CodigoMoneda
            // 
            this.CodigoMoneda.HeaderText = "CodigoMoneda";
            this.CodigoMoneda.Name = "CodigoMoneda";
            this.CodigoMoneda.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // Cotizacion
            // 
            this.Cotizacion.HeaderText = "Cotizacion";
            this.Cotizacion.Name = "Cotizacion";
            this.Cotizacion.Visible = false;
            // 
            // Importe2
            // 
            this.Importe2.HeaderText = "Importe2";
            this.Importe2.Name = "Importe2";
            this.Importe2.Visible = false;
            // 
            // Importe3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Importe3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Importe3.HeaderText = "Importe";
            this.Importe3.Name = "Importe3";
            // 
            // CodigoCuentaContable2
            // 
            this.CodigoCuentaContable2.DataPropertyName = "CuentaContable";
            this.CodigoCuentaContable2.HeaderText = "CuentaContable";
            this.CodigoCuentaContable2.Name = "CodigoCuentaContable2";
            this.CodigoCuentaContable2.Visible = false;
            // 
            // CodigoBanco
            // 
            this.CodigoBanco.HeaderText = "CodigoBanco";
            this.CodigoBanco.Name = "CodigoBanco";
            this.CodigoBanco.Visible = false;
            // 
            // FechaEmision
            // 
            dataGridViewCellStyle2.Format = "d";
            this.FechaEmision.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaEmision.HeaderText = "FechaEmision";
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.Visible = false;
            // 
            // FechaPago
            // 
            dataGridViewCellStyle3.Format = "d";
            this.FechaPago.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaPago.HeaderText = "FechaPago";
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.Visible = false;
            // 
            // Librador
            // 
            this.Librador.HeaderText = "Librador";
            this.Librador.Name = "Librador";
            this.Librador.Visible = false;
            // 
            // NumeroCheque
            // 
            this.NumeroCheque.HeaderText = "NumeroCheque";
            this.NumeroCheque.Name = "NumeroCheque";
            this.NumeroCheque.Visible = false;
            // 
            // CUIT
            // 
            this.CUIT.HeaderText = "CUIT";
            this.CUIT.Name = "CUIT";
            this.CUIT.Visible = false;
            // 
            // CodigoCuentaBancaria
            // 
            this.CodigoCuentaBancaria.DataPropertyName = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.HeaderText = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.Name = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.Visible = false;
            // 
            // CodigoCheque
            // 
            this.CodigoCheque.HeaderText = "CodigoCheque";
            this.CodigoCheque.Name = "CodigoCheque";
            this.CodigoCheque.Visible = false;
            // 
            // CodigoTipoTarjeta
            // 
            this.CodigoTipoTarjeta.HeaderText = "CodigoTipoTarjeta";
            this.CodigoTipoTarjeta.Name = "CodigoTipoTarjeta";
            this.CodigoTipoTarjeta.Visible = false;
            // 
            // Cuotas
            // 
            this.Cuotas.HeaderText = "Cuotas";
            this.Cuotas.Name = "Cuotas";
            this.Cuotas.Visible = false;
            // 
            // NroCupon
            // 
            this.NroCupon.HeaderText = "NroCupon";
            this.NroCupon.Name = "NroCupon";
            this.NroCupon.Visible = false;
            // 
            // ucFormasPagoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucDebitoCredito);
            this.Controls.Add(this.ucTranferenciasBancarias);
            this.Controls.Add(this.ucChequesTerceros);
            this.Controls.Add(this.ucChequePropio);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.ucCheque);
            this.Controls.Add(this.ucContado);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFormasDePago);
            this.Name = "ucFormasPagoCompras";
            this.Size = new System.Drawing.Size(521, 267);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public ucCheque ucCheque;
        private System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFormasDePago;
        public Presentacion.ucContado ucContado;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnEliminar;
        public ucChequesTerceros ucChequesTerceros;
        public ucChequePropio ucChequePropio;
        public ucTranferenciasBancarias ucTranferenciasBancarias;
        public ucDebitoCredito ucDebitoCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Librador;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoTarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCupon;
    }
}
