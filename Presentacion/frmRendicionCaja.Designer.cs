namespace Presentacion
{
    partial class frmRendicionCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCajas = new System.Windows.Forms.ComboBox();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.FormaDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Librador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFormasDePago = new System.Windows.Forms.ComboBox();
            this.ucChequesTerceros = new Presentacion.ucChequesTerceros();
            this.ucContado = new Presentacion.ucContado();
            this.btnCajas = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbFecha = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(316, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 397;
            this.label4.Text = "Caja N°:";
            this.label4.Visible = false;
            // 
            // cbCajas
            // 
            this.cbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCajas.FormattingEnabled = true;
            this.cbCajas.Location = new System.Drawing.Point(367, 37);
            this.cbCajas.Margin = new System.Windows.Forms.Padding(2);
            this.cbCajas.Name = "cbCajas";
            this.cbCajas.Size = new System.Drawing.Size(109, 21);
            this.cbCajas.TabIndex = 396;
            this.cbCajas.Visible = false;
            this.cbCajas.SelectedIndexChanged += new System.EventHandler(this.cbCajas_SelectedIndexChanged);
            // 
            // lblSucursales
            // 
            this.lblSucursales.AutoSize = true;
            this.lblSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSucursales.Location = new System.Drawing.Point(16, 40);
            this.lblSucursales.Name = "lblSucursales";
            this.lblSucursales.Size = new System.Drawing.Size(51, 13);
            this.lblSucursales.TabIndex = 395;
            this.lblSucursales.Text = "Sucursal:";
            this.lblSucursales.Visible = false;
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(110, 37);
            this.cbSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(123, 21);
            this.cbSucursales.TabIndex = 394;
            this.cbSucursales.Visible = false;
            this.cbSucursales.SelectedIndexChanged += new System.EventHandler(this.cbSucursales_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(428, 443);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 128;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 415);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "Total:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(329, 443);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 118;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(407, 413);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 115;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = global::Presentacion.Properties.Resources.pencil;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(482, 217);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(25, 25);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = global::Presentacion.Properties.Resources.remove;
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(482, 177);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 4;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
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
            this.Importe,
            this.CuentaContable,
            this.CodigoBanco,
            this.FechaEmision,
            this.FechaPago,
            this.Librador,
            this.NumeroCheque,
            this.CUIT,
            this.CodigoCuentaBancaria,
            this.CodigoCheque});
            this.dgvDatos.Location = new System.Drawing.Point(19, 177);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(446, 215);
            this.dgvDatos.TabIndex = 3;
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
            // Importe
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle1;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // CuentaContable
            // 
            this.CuentaContable.DataPropertyName = "CuentaContable";
            this.CuentaContable.HeaderText = "CuentaContable";
            this.CuentaContable.Name = "CuentaContable";
            this.CuentaContable.Visible = false;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Forma de Pago:";
            // 
            // cbFormasDePago
            // 
            this.cbFormasDePago.FormattingEnabled = true;
            this.cbFormasDePago.Location = new System.Drawing.Point(110, 67);
            this.cbFormasDePago.Margin = new System.Windows.Forms.Padding(2);
            this.cbFormasDePago.Name = "cbFormasDePago";
            this.cbFormasDePago.Size = new System.Drawing.Size(158, 21);
            this.cbFormasDePago.TabIndex = 0;
            this.cbFormasDePago.SelectedIndexChanged += new System.EventHandler(this.cbFormasDePago_SelectedIndexChanged);
            this.cbFormasDePago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFormasDePago_KeyPress);
            // 
            // ucChequesTerceros
            // 
            this.ucChequesTerceros.Location = new System.Drawing.Point(238, 101);
            this.ucChequesTerceros.Margin = new System.Windows.Forms.Padding(2);
            this.ucChequesTerceros.Name = "ucChequesTerceros";
            this.ucChequesTerceros.Size = new System.Drawing.Size(38, 41);
            this.ucChequesTerceros.TabIndex = 127;
            // 
            // ucContado
            // 
            this.ucContado.Location = new System.Drawing.Point(1, 90);
            this.ucContado.Margin = new System.Windows.Forms.Padding(4);
            this.ucContado.Name = "ucContado";
            this.ucContado.Size = new System.Drawing.Size(516, 68);
            this.ucContado.TabIndex = 1;
            this.ucContado.Load += new System.EventHandler(this.ucContado_Load);
            // 
            // btnCajas
            // 
            this.btnCajas.BackgroundImage = global::Presentacion.Properties.Resources.yes;
            this.btnCajas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCajas.Location = new System.Drawing.Point(482, 36);
            this.btnCajas.Name = "btnCajas";
            this.btnCajas.Size = new System.Drawing.Size(25, 25);
            this.btnCajas.TabIndex = 398;
            this.btnCajas.UseVisualStyleBackColor = true;
            this.btnCajas.Click += new System.EventHandler(this.btnCajas_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(367, 7);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(109, 20);
            this.dtpFecha.TabIndex = 399;
            this.dtpFecha.Value = new System.DateTime(2018, 7, 5, 14, 1, 0, 0);
            // 
            // cbFecha
            // 
            this.cbFecha.AutoSize = true;
            this.cbFecha.Checked = true;
            this.cbFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFecha.Location = new System.Drawing.Point(305, 9);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(56, 17);
            this.cbFecha.TabIndex = 401;
            this.cbFecha.Text = "Fecha";
            this.cbFecha.UseVisualStyleBackColor = true;
            this.cbFecha.CheckedChanged += new System.EventHandler(this.cbFecha_CheckedChanged);
            // 
            // frmRendicionCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(521, 479);
            this.Controls.Add(this.cbFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnCajas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCajas);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.ucChequesTerceros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.ucContado);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFormasDePago);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmRendicionCaja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRendicionCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFormasDePago;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgvDatos;
        private Presentacion.ucContado ucContado;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminarProducto;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Label label1;
        private Presentacion.ucChequesTerceros ucChequesTerceros;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox /*Utilidades.ComboBoxCustom*/ cbCajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Librador;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCheque;
        private System.Windows.Forms.Button btnCajas;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.CheckBox cbFecha;
    }
}
