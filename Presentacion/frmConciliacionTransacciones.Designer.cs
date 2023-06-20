namespace Presentacion
{
    partial class frmConciliacionTransacciones
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
            this.label11 = new System.Windows.Forms.Label();
            this.txtRetGanancias = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtFechaContable = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRetIVA = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRetIIBB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGastosBancarios = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFormasDePago = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CodigoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Renglon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoMovimientoBancario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoFormaDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoMovimientoBancario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroCupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBancoCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Librador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMonedaCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CotizacionCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 506);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 13);
            this.label11.TabIndex = 451;
            this.label11.Text = "Retención Ganancias:";
            // 
            // txtRetGanancias
            // 
            this.txtRetGanancias.Location = new System.Drawing.Point(126, 503);
            this.txtRetGanancias.Margin = new System.Windows.Forms.Padding(2);
            this.txtRetGanancias.Name = "txtRetGanancias";
            this.txtRetGanancias.Size = new System.Drawing.Size(70, 20);
            this.txtRetGanancias.TabIndex = 12;
            this.txtRetGanancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetGanancias.TextChanged += new System.EventHandler(this.txtRetGanancias_TextChanged);
            this.txtRetGanancias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtRetGanancias.Leave += new System.EventHandler(this.txtRetGanancias_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 450;
            this.label10.Text = "Fecha Contable:";
            // 
            // dtFechaContable
            // 
            this.dtFechaContable.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaContable.Location = new System.Drawing.Point(91, 7);
            this.dtFechaContable.Name = "dtFechaContable";
            this.dtFechaContable.Size = new System.Drawing.Size(101, 20);
            this.dtFechaContable.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 474);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 447;
            this.label7.Text = "Retención IVA:";
            // 
            // txtRetIVA
            // 
            this.txtRetIVA.Location = new System.Drawing.Point(305, 471);
            this.txtRetIVA.Margin = new System.Windows.Forms.Padding(2);
            this.txtRetIVA.Name = "txtRetIVA";
            this.txtRetIVA.Size = new System.Drawing.Size(64, 20);
            this.txtRetIVA.TabIndex = 11;
            this.txtRetIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetIVA.TextChanged += new System.EventHandler(this.txtRetIVA_TextChanged);
            this.txtRetIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetIVA_KeyPress);
            this.txtRetIVA.Leave += new System.EventHandler(this.txtRetIVA_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 474);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 445;
            this.label8.Text = "Retención IIBB:";
            // 
            // txtRetIIBB
            // 
            this.txtRetIIBB.Location = new System.Drawing.Point(126, 471);
            this.txtRetIIBB.Margin = new System.Windows.Forms.Padding(2);
            this.txtRetIIBB.Name = "txtRetIIBB";
            this.txtRetIIBB.Size = new System.Drawing.Size(70, 20);
            this.txtRetIIBB.TabIndex = 10;
            this.txtRetIIBB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetIIBB.TextChanged += new System.EventHandler(this.txtRetIIBB_TextChanged);
            this.txtRetIIBB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetIIBB_KeyPress);
            this.txtRetIIBB.Leave += new System.EventHandler(this.txtRetIIBB_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 443;
            this.label5.Text = "IVA 21%:";
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(305, 439);
            this.txtIVA.Margin = new System.Windows.Forms.Padding(2);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(64, 20);
            this.txtIVA.TabIndex = 9;
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIVA.TextChanged += new System.EventHandler(this.txtIVA_TextChanged);
            this.txtIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIVA_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 442);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 441;
            this.label9.Text = "Gastos Bancarios:";
            // 
            // txtGastosBancarios
            // 
            this.txtGastosBancarios.Location = new System.Drawing.Point(126, 439);
            this.txtGastosBancarios.Margin = new System.Windows.Forms.Padding(2);
            this.txtGastosBancarios.Name = "txtGastosBancarios";
            this.txtGastosBancarios.Size = new System.Drawing.Size(70, 20);
            this.txtGastosBancarios.TabIndex = 8;
            this.txtGastosBancarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastosBancarios.TextChanged += new System.EventHandler(this.txtGastosBancarios_TextChanged);
            this.txtGastosBancarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGastosBancarios_KeyPress);
            this.txtGastosBancarios.Leave += new System.EventHandler(this.txtGastosBancarios_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 440;
            this.label3.Text = "Tipo:";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(352, 64);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(123, 21);
            this.cbTipo.TabIndex = 5;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged_1);
            // 
            // lblSucursales
            // 
            this.lblSucursales.AutoSize = true;
            this.lblSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSucursales.Location = new System.Drawing.Point(507, 68);
            this.lblSucursales.Name = "lblSucursales";
            this.lblSucursales.Size = new System.Drawing.Size(51, 13);
            this.lblSucursales.TabIndex = 438;
            this.lblSucursales.Text = "Sucursal:";
            this.lblSucursales.Visible = false;
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(563, 65);
            this.cbSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(101, 21);
            this.cbSucursales.TabIndex = 6;
            this.cbSucursales.Visible = false;
            this.cbSucursales.SelectedIndexChanged += new System.EventHandler(this.cbSucursales_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 436;
            this.label2.Text = "Forma de Pago:";
            // 
            // cbFormasDePago
            // 
            this.cbFormasDePago.FormattingEnabled = true;
            this.cbFormasDePago.Location = new System.Drawing.Point(91, 64);
            this.cbFormasDePago.Name = "cbFormasDePago";
            this.cbFormasDePago.Size = new System.Drawing.Size(154, 21);
            this.cbFormasDePago.TabIndex = 4;
            this.cbFormasDePago.SelectedIndexChanged += new System.EventHandler(this.cbFormasDePago_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(655, 537);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(556, 537);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 13;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(540, 503);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 430;
            this.label14.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(603, 501);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(127, 15);
            this.lblTotal.TabIndex = 429;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.CodigoPago,
            this.CodigoCaja,
            this.Renglon,
            this.CodigoTipoMovimientoBancario,
            this.CodigoFormaDePago,
            this.Fecha,
            this.FormaDePago,
            this.TipoMovimientoBancario,
            this.Cliente,
            this.CodigoTipoTarjeta,
            this.Tipo,
            this.CodigoCheque,
            this.Cheque,
            this.NroCupon,
            this.CodigoBancoCheque,
            this.NroCheque,
            this.FechaEmision,
            this.FechaPago,
            this.Librador,
            this.CUIT,
            this.CodigoMonedaCheque,
            this.CotizacionCheque,
            this.Numero,
            this.Importe,
            this.CodigoCuentaContable,
            this.CodigoTipoDoc});
            this.dgvDatos.Location = new System.Drawing.Point(11, 99);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(725, 321);
            this.dgvDatos.TabIndex = 7;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 427;
            this.label6.Text = "Fecha :";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(563, 35);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Nro de Cuenta:";
            // 
            // cbCuentaBancaria
            // 
            this.cbCuentaBancaria.FormattingEnabled = true;
            this.cbCuentaBancaria.Location = new System.Drawing.Point(352, 35);
            this.cbCuentaBancaria.Name = "cbCuentaBancaria";
            this.cbCuentaBancaria.Size = new System.Drawing.Size(123, 21);
            this.cbCuentaBancaria.TabIndex = 2;
            this.cbCuentaBancaria.SelectedIndexChanged += new System.EventHandler(this.cbCuentaBancaria_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(91, 35);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(154, 21);
            this.cbBancos.TabIndex = 1;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Seleccionar.Width = 86;
            // 
            // CodigoPago
            // 
            this.CodigoPago.DataPropertyName = "CodigoPago";
            this.CodigoPago.HeaderText = "CodigoPago";
            this.CodigoPago.Name = "CodigoPago";
            this.CodigoPago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CodigoPago.Visible = false;
            // 
            // CodigoCaja
            // 
            this.CodigoCaja.DataPropertyName = "CodigoCaja";
            this.CodigoCaja.HeaderText = "CodigoCaja";
            this.CodigoCaja.Name = "CodigoCaja";
            this.CodigoCaja.Visible = false;
            // 
            // Renglon
            // 
            this.Renglon.DataPropertyName = "Renglon";
            this.Renglon.HeaderText = "Renglon";
            this.Renglon.Name = "Renglon";
            this.Renglon.Visible = false;
            // 
            // CodigoTipoMovimientoBancario
            // 
            this.CodigoTipoMovimientoBancario.DataPropertyName = "CodigoTipoMovimientoBancario";
            this.CodigoTipoMovimientoBancario.HeaderText = "CodigoTipoMovimientoBancario";
            this.CodigoTipoMovimientoBancario.Name = "CodigoTipoMovimientoBancario";
            this.CodigoTipoMovimientoBancario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CodigoTipoMovimientoBancario.Visible = false;
            // 
            // CodigoFormaDePago
            // 
            this.CodigoFormaDePago.DataPropertyName = "CodigoFormaDePago";
            this.CodigoFormaDePago.HeaderText = "CodigoFormaDePago";
            this.CodigoFormaDePago.Name = "CodigoFormaDePago";
            this.CodigoFormaDePago.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 87;
            // 
            // FormaDePago
            // 
            this.FormaDePago.DataPropertyName = "FormaDePago";
            this.FormaDePago.HeaderText = "Forma De Pago";
            this.FormaDePago.Name = "FormaDePago";
            this.FormaDePago.Width = 86;
            // 
            // TipoMovimientoBancario
            // 
            this.TipoMovimientoBancario.DataPropertyName = "TipoMovimientoBancario";
            this.TipoMovimientoBancario.HeaderText = "Tipo Movimiento Bancario";
            this.TipoMovimientoBancario.Name = "TipoMovimientoBancario";
            this.TipoMovimientoBancario.Width = 86;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente (CUIT)";
            this.Cliente.Name = "Cliente";
            this.Cliente.Width = 86;
            // 
            // CodigoTipoTarjeta
            // 
            this.CodigoTipoTarjeta.DataPropertyName = "CodigoTipoTarjeta";
            this.CodigoTipoTarjeta.HeaderText = "CodigoTipoTarjeta";
            this.CodigoTipoTarjeta.Name = "CodigoTipoTarjeta";
            this.CodigoTipoTarjeta.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "TipoDeTarjetas";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // CodigoCheque
            // 
            this.CodigoCheque.DataPropertyName = "CodigoCheque";
            this.CodigoCheque.HeaderText = "CodigoCheque";
            this.CodigoCheque.Name = "CodigoCheque";
            this.CodigoCheque.Visible = false;
            // 
            // Cheque
            // 
            this.Cheque.DataPropertyName = "Cheque";
            this.Cheque.HeaderText = "Cheque";
            this.Cheque.Name = "Cheque";
            this.Cheque.Visible = false;
            // 
            // NroCupon
            // 
            this.NroCupon.DataPropertyName = "NroCupon";
            this.NroCupon.HeaderText = "Nro Cupon";
            this.NroCupon.Name = "NroCupon";
            this.NroCupon.Width = 87;
            // 
            // CodigoBancoCheque
            // 
            this.CodigoBancoCheque.DataPropertyName = "CodigoBancoCheque";
            this.CodigoBancoCheque.HeaderText = "CodigoBancoCheque";
            this.CodigoBancoCheque.Name = "CodigoBancoCheque";
            this.CodigoBancoCheque.Visible = false;
            // 
            // NroCheque
            // 
            this.NroCheque.DataPropertyName = "NroCheque";
            this.NroCheque.HeaderText = "NroCheque";
            this.NroCheque.Name = "NroCheque";
            this.NroCheque.Visible = false;
            // 
            // FechaEmision
            // 
            this.FechaEmision.DataPropertyName = "FechaEmision";
            this.FechaEmision.HeaderText = "FechaEmision";
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.Visible = false;
            // 
            // FechaPago
            // 
            this.FechaPago.DataPropertyName = "FechaPago";
            this.FechaPago.HeaderText = "FechaPago";
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.Visible = false;
            // 
            // Librador
            // 
            this.Librador.DataPropertyName = "Librador";
            this.Librador.HeaderText = "Librador";
            this.Librador.Name = "Librador";
            this.Librador.Visible = false;
            // 
            // CUIT
            // 
            this.CUIT.DataPropertyName = "CUIT";
            this.CUIT.HeaderText = "CUIT";
            this.CUIT.Name = "CUIT";
            this.CUIT.Visible = false;
            // 
            // CodigoMonedaCheque
            // 
            this.CodigoMonedaCheque.DataPropertyName = "CodigoMonedaCheque";
            this.CodigoMonedaCheque.HeaderText = "CodigoMonedaCheque";
            this.CodigoMonedaCheque.Name = "CodigoMonedaCheque";
            this.CodigoMonedaCheque.Visible = false;
            // 
            // CotizacionCheque
            // 
            this.CotizacionCheque.DataPropertyName = "CotizacionCheque";
            this.CotizacionCheque.HeaderText = "CotizacionCheque";
            this.CotizacionCheque.Name = "CotizacionCheque";
            this.CotizacionCheque.Visible = false;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.Numero.HeaderText = "Nro. Recibo";
            this.Numero.Name = "Numero";
            this.Numero.Width = 200;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle3;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.Width = 86;
            // 
            // CodigoCuentaContable
            // 
            this.CodigoCuentaContable.DataPropertyName = "CodigoCuentaContableTranferencias";
            this.CodigoCuentaContable.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.Visible = false;
            // 
            // CodigoTipoDoc
            // 
            this.CodigoTipoDoc.DataPropertyName = "CodigoTipoDoc";
            this.CodigoTipoDoc.HeaderText = "CodigoTipoDoc";
            this.CodigoTipoDoc.Name = "CodigoTipoDoc";
            this.CodigoTipoDoc.Visible = false;
            // 
            // frmConciliacionTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(748, 576);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRetGanancias);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtFechaContable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRetIVA);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRetIIBB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtGastosBancarios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFormasDePago);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCuentaBancaria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBancos);
            this.Name = "frmConciliacionTransacciones";
            this.Load += new System.EventHandler(this.frmConciliacionTransacciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbFormasDePago;
        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtGastosBancarios;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtRetIVA;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtRetIIBB;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.DateTimePicker dtFechaContable;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtRetGanancias;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Renglon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoMovimientoBancario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoFormaDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoMovimientoBancario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoTarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCupon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBancoCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Librador;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMonedaCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotizacionCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoDoc;
    }
}
