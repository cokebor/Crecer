
namespace Presentacion
{
    partial class frmCuentasCorrientesClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.cbClientes = new System.Windows.Forms.CheckBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTiposComprobantes = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalSinSaldoAnterior = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.CodigoTipoDocumentoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSucursales
            // 
            this.lblSucursales.AutoSize = true;
            this.lblSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSucursales.Location = new System.Drawing.Point(617, 15);
            this.lblSucursales.Name = "lblSucursales";
            this.lblSucursales.Size = new System.Drawing.Size(51, 13);
            this.lblSucursales.TabIndex = 399;
            this.lblSucursales.Text = "Sucursal:";
            this.lblSucursales.Visible = false;
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(673, 12);
            this.cbSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(94, 21);
            this.cbSucursales.TabIndex = 398;
            this.cbSucursales.Visible = false;
            this.cbSucursales.SelectedIndexChanged += new System.EventHandler(this.cbSucursales_SelectedIndexChanged);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(226, 12);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 397;
            this.dtHasta.ValueChanged += new System.EventHandler(this.dtHasta_ValueChanged);
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(53, 12);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 396;
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(181, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 395;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 394;
            this.label1.Text = "Desde";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Enabled = false;
            this.lblCliente.Location = new System.Drawing.Point(155, 47);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(60, 13);
            this.lblCliente.TabIndex = 422;
            this.lblCliente.Text = "Cliente (F2)";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Location = new System.Drawing.Point(241, 44);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.ShortcutsEnabled = false;
            this.txtCodigoCliente.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoCliente.TabIndex = 420;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(286, 48);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 421;
            // 
            // cbClientes
            // 
            this.cbClientes.AutoSize = true;
            this.cbClientes.Checked = true;
            this.cbClientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClientes.Location = new System.Drawing.Point(14, 46);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(112, 17);
            this.cbClientes.TabIndex = 419;
            this.cbClientes.Text = "Todos los Clientes";
            this.cbClientes.UseVisualStyleBackColor = true;
            this.cbClientes.CheckedChanged += new System.EventHandler(this.cbClientes_CheckedChanged);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoTipoDocumentoCliente,
            this.Codigo,
            this.Fecha,
            this.Tipo,
            this.Comprobante,
            this.Numero,
            this.CodigoCliente,
            this.Cliente,
            this.Debito,
            this.Credito,
            this.Total});
            this.dgvDatos.Location = new System.Drawing.Point(11, 78);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(758, 407);
            this.dgvDatos.TabIndex = 423;
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(346, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 425;
            this.label3.Text = "Tipos de Comprobantes:";
            // 
            // cbTiposComprobantes
            // 
            this.cbTiposComprobantes.FormattingEnabled = true;
            this.cbTiposComprobantes.Location = new System.Drawing.Point(468, 12);
            this.cbTiposComprobantes.Margin = new System.Windows.Forms.Padding(2);
            this.cbTiposComprobantes.Name = "cbTiposComprobantes";
            this.cbTiposComprobantes.Size = new System.Drawing.Size(132, 21);
            this.cbTiposComprobantes.TabIndex = 424;
            this.cbTiposComprobantes.SelectedIndexChanged += new System.EventHandler(this.cbTiposComprobantes_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(705, 41);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 426;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(545, 501);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 428;
            this.label12.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotal.Location = new System.Drawing.Point(601, 499);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(166, 16);
            this.lblTotal.TabIndex = 427;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(213, 501);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 430;
            this.label4.Text = "Total sin Saldo Anterior:";
            // 
            // lblTotalSinSaldoAnterior
            // 
            this.lblTotalSinSaldoAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalSinSaldoAnterior.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalSinSaldoAnterior.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalSinSaldoAnterior.Location = new System.Drawing.Point(362, 499);
            this.lblTotalSinSaldoAnterior.Name = "lblTotalSinSaldoAnterior";
            this.lblTotalSinSaldoAnterior.Size = new System.Drawing.Size(166, 16);
            this.lblTotalSinSaldoAnterior.TabIndex = 429;
            this.lblTotalSinSaldoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExportar
            // 
            this.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExportar.Location = new System.Drawing.Point(592, 528);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(79, 26);
            this.btnExportar.TabIndex = 432;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(686, 528);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 431;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CodigoTipoDocumentoCliente
            // 
            this.CodigoTipoDocumentoCliente.DataPropertyName = "CodigoTipoDocumentoCliente";
            this.CodigoTipoDocumentoCliente.HeaderText = "CodigoTipoDocumentoCliente";
            this.CodigoTipoDocumentoCliente.Name = "CodigoTipoDocumentoCliente";
            this.CodigoTipoDocumentoCliente.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Visible = false;
            // 
            // Comprobante
            // 
            this.Comprobante.DataPropertyName = "TipoDocumento";
            this.Comprobante.HeaderText = "Comprobante";
            this.Comprobante.Name = "Comprobante";
            this.Comprobante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Numero.Width = 120;
            // 
            // CodigoCliente
            // 
            this.CodigoCliente.DataPropertyName = "CodigoCliente";
            this.CodigoCliente.HeaderText = "CodigoCliente";
            this.CodigoCliente.Name = "CodigoCliente";
            this.CodigoCliente.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            // 
            // Debito
            // 
            this.Debito.DataPropertyName = "Debito";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.Debito.DefaultCellStyle = dataGridViewCellStyle3;
            this.Debito.HeaderText = "Debito";
            this.Debito.Name = "Debito";
            this.Debito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Credito
            // 
            this.Credito.DataPropertyName = "Credito";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Credito.DefaultCellStyle = dataGridViewCellStyle4;
            this.Credito.HeaderText = "Credito";
            this.Credito.Name = "Credito";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Total.Visible = false;
            // 
            // frmCuentasCorrientesClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(776, 571);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalSinSaldoAnterior);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTiposComprobantes);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCuentasCorrientesClientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.CheckBox cbClientes;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbTiposComprobantes;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalSinSaldoAnterior;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoDocumentoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}
