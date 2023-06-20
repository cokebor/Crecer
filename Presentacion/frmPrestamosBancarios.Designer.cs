namespace Presentacion
{
    partial class frmPrestamosBancarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCuentaBancaria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.dtFechaOtorgamiento = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSistemasAmortizacion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorPrestamo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFrencuenciaPago = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nupCuotas = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTNA = new System.Windows.Forms.TextBox();
            this.cbPeriodoDeGracia = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tcPrestamos = new System.Windows.Forms.TabControl();
            this.tpPrestamo = new System.Windows.Forms.TabPage();
            this.dtpFechaPrimerCuota = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cbInteresPeriodoDeGracia = new System.Windows.Forms.CheckBox();
            this.btnSimular = new System.Windows.Forms.Button();
            this.tpTablaAmortizacion = new System.Windows.Forms.TabPage();
            this.dgvTablaAmortizacion = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CapitalAmortizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaAPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CapitalPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupCuotas)).BeginInit();
            this.tcPrestamos.SuspendLayout();
            this.tpPrestamo.SuspendLayout();
            this.tpTablaAmortizacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaAmortizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 408;
            this.label4.Text = "Nro de Cuenta:";
            // 
            // cbCuentaBancaria
            // 
            this.cbCuentaBancaria.FormattingEnabled = true;
            this.cbCuentaBancaria.Location = new System.Drawing.Point(365, 16);
            this.cbCuentaBancaria.Name = "cbCuentaBancaria";
            this.cbCuentaBancaria.Size = new System.Drawing.Size(143, 21);
            this.cbCuentaBancaria.TabIndex = 406;
            this.cbCuentaBancaria.SelectedIndexChanged += new System.EventHandler(this.cbCuentaBancaria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 407;
            this.label2.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(74, 16);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(200, 21);
            this.cbBancos.TabIndex = 405;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            // 
            // dtFechaOtorgamiento
            // 
            this.dtFechaOtorgamiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaOtorgamiento.Location = new System.Drawing.Point(464, 12);
            this.dtFechaOtorgamiento.Name = "dtFechaOtorgamiento";
            this.dtFechaOtorgamiento.Size = new System.Drawing.Size(86, 20);
            this.dtFechaOtorgamiento.TabIndex = 404;
            this.dtFechaOtorgamiento.ValueChanged += new System.EventHandler(this.dtFechaOtorgamiento_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 403;
            this.label1.Text = "Fecha Otorgamiento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 410;
            this.label3.Text = "Sistema de Amortización:";
            // 
            // cbSistemasAmortizacion
            // 
            this.cbSistemasAmortizacion.FormattingEnabled = true;
            this.cbSistemasAmortizacion.Location = new System.Drawing.Point(158, 49);
            this.cbSistemasAmortizacion.Name = "cbSistemasAmortizacion";
            this.cbSistemasAmortizacion.Size = new System.Drawing.Size(116, 21);
            this.cbSistemasAmortizacion.TabIndex = 409;
            this.cbSistemasAmortizacion.SelectedIndexChanged += new System.EventHandler(this.cbSistemasAmortizacion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 411;
            this.label5.Text = "Valor del Préstamo:";
            // 
            // txtValorPrestamo
            // 
            this.txtValorPrestamo.Location = new System.Drawing.Point(387, 49);
            this.txtValorPrestamo.Name = "txtValorPrestamo";
            this.txtValorPrestamo.ShortcutsEnabled = false;
            this.txtValorPrestamo.Size = new System.Drawing.Size(121, 20);
            this.txtValorPrestamo.TabIndex = 412;
            this.txtValorPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorPrestamo.TextChanged += new System.EventHandler(this.txtValorPrestamo_TextChanged);
            this.txtValorPrestamo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPrestamo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 413;
            this.label6.Text = "Frecuencia de Pago:";
            // 
            // cbFrencuenciaPago
            // 
            this.cbFrencuenciaPago.FormattingEnabled = true;
            this.cbFrencuenciaPago.Location = new System.Drawing.Point(158, 80);
            this.cbFrencuenciaPago.Name = "cbFrencuenciaPago";
            this.cbFrencuenciaPago.Size = new System.Drawing.Size(116, 21);
            this.cbFrencuenciaPago.TabIndex = 414;
            this.cbFrencuenciaPago.SelectedIndexChanged += new System.EventHandler(this.cbFrencuenciaPago_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 415;
            this.label7.Text = "Cantidad de Cuotas:";
            // 
            // nupCuotas
            // 
            this.nupCuotas.Location = new System.Drawing.Point(389, 80);
            this.nupCuotas.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.nupCuotas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupCuotas.Name = "nupCuotas";
            this.nupCuotas.Size = new System.Drawing.Size(46, 20);
            this.nupCuotas.TabIndex = 416;
            this.nupCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupCuotas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupCuotas.ValueChanged += new System.EventHandler(this.nupCuotas_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 417;
            this.label8.Text = "TNA:";
            // 
            // txtTNA
            // 
            this.txtTNA.Location = new System.Drawing.Point(472, 79);
            this.txtTNA.Name = "txtTNA";
            this.txtTNA.ShortcutsEnabled = false;
            this.txtTNA.Size = new System.Drawing.Size(36, 20);
            this.txtTNA.TabIndex = 418;
            this.txtTNA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTNA.TextChanged += new System.EventHandler(this.txtTNA_TextChanged);
            this.txtTNA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTNA_KeyPress);
            // 
            // cbPeriodoDeGracia
            // 
            this.cbPeriodoDeGracia.FormattingEnabled = true;
            this.cbPeriodoDeGracia.Location = new System.Drawing.Point(158, 111);
            this.cbPeriodoDeGracia.Name = "cbPeriodoDeGracia";
            this.cbPeriodoDeGracia.Size = new System.Drawing.Size(116, 21);
            this.cbPeriodoDeGracia.TabIndex = 420;
            this.cbPeriodoDeGracia.SelectedIndexChanged += new System.EventHandler(this.cbPeriodoDeGracia_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 419;
            this.label9.Text = "Periodo de Gracia:";
            // 
            // tcPrestamos
            // 
            this.tcPrestamos.Controls.Add(this.tpPrestamo);
            this.tcPrestamos.Controls.Add(this.tpTablaAmortizacion);
            this.tcPrestamos.Location = new System.Drawing.Point(12, 43);
            this.tcPrestamos.Name = "tcPrestamos";
            this.tcPrestamos.SelectedIndex = 0;
            this.tcPrestamos.Size = new System.Drawing.Size(542, 303);
            this.tcPrestamos.TabIndex = 423;
            // 
            // tpPrestamo
            // 
            this.tpPrestamo.Controls.Add(this.dtpFechaPrimerCuota);
            this.tpPrestamo.Controls.Add(this.label11);
            this.tpPrestamo.Controls.Add(this.cbInteresPeriodoDeGracia);
            this.tpPrestamo.Controls.Add(this.btnSimular);
            this.tpPrestamo.Controls.Add(this.label9);
            this.tpPrestamo.Controls.Add(this.cbBancos);
            this.tpPrestamo.Controls.Add(this.label2);
            this.tpPrestamo.Controls.Add(this.cbPeriodoDeGracia);
            this.tpPrestamo.Controls.Add(this.cbCuentaBancaria);
            this.tpPrestamo.Controls.Add(this.label4);
            this.tpPrestamo.Controls.Add(this.txtTNA);
            this.tpPrestamo.Controls.Add(this.cbSistemasAmortizacion);
            this.tpPrestamo.Controls.Add(this.label8);
            this.tpPrestamo.Controls.Add(this.label3);
            this.tpPrestamo.Controls.Add(this.nupCuotas);
            this.tpPrestamo.Controls.Add(this.label5);
            this.tpPrestamo.Controls.Add(this.label7);
            this.tpPrestamo.Controls.Add(this.txtValorPrestamo);
            this.tpPrestamo.Controls.Add(this.cbFrencuenciaPago);
            this.tpPrestamo.Controls.Add(this.label6);
            this.tpPrestamo.Location = new System.Drawing.Point(4, 22);
            this.tpPrestamo.Name = "tpPrestamo";
            this.tpPrestamo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPrestamo.Size = new System.Drawing.Size(534, 277);
            this.tpPrestamo.TabIndex = 0;
            this.tpPrestamo.Text = "Prestamo";
            this.tpPrestamo.UseVisualStyleBackColor = true;
            // 
            // dtpFechaPrimerCuota
            // 
            this.dtpFechaPrimerCuota.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPrimerCuota.Location = new System.Drawing.Point(424, 112);
            this.dtpFechaPrimerCuota.Name = "dtpFechaPrimerCuota";
            this.dtpFechaPrimerCuota.Size = new System.Drawing.Size(86, 20);
            this.dtpFechaPrimerCuota.TabIndex = 426;
            this.dtpFechaPrimerCuota.ValueChanged += new System.EventHandler(this.dtpFechaPrimerCuota_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(284, 117);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 425;
            this.label11.Text = "Fecha primer cuota:";
            // 
            // cbInteresPeriodoDeGracia
            // 
            this.cbInteresPeriodoDeGracia.AutoSize = true;
            this.cbInteresPeriodoDeGracia.Checked = true;
            this.cbInteresPeriodoDeGracia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInteresPeriodoDeGracia.Enabled = false;
            this.cbInteresPeriodoDeGracia.Location = new System.Drawing.Point(30, 147);
            this.cbInteresPeriodoDeGracia.Name = "cbInteresPeriodoDeGracia";
            this.cbInteresPeriodoDeGracia.Size = new System.Drawing.Size(232, 17);
            this.cbInteresPeriodoDeGracia.TabIndex = 424;
            this.cbInteresPeriodoDeGracia.Text = "Pagar Interes Periodo de Gracia en Cuota 1";
            this.cbInteresPeriodoDeGracia.UseVisualStyleBackColor = true;
            this.cbInteresPeriodoDeGracia.CheckedChanged += new System.EventHandler(this.cbInteresPeriodoDeGracia_CheckedChanged);
            // 
            // btnSimular
            // 
            this.btnSimular.Location = new System.Drawing.Point(389, 202);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(121, 23);
            this.btnSimular.TabIndex = 423;
            this.btnSimular.Text = "Simular Prestamo";
            this.btnSimular.UseVisualStyleBackColor = true;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // tpTablaAmortizacion
            // 
            this.tpTablaAmortizacion.Controls.Add(this.dgvTablaAmortizacion);
            this.tpTablaAmortizacion.Location = new System.Drawing.Point(4, 22);
            this.tpTablaAmortizacion.Name = "tpTablaAmortizacion";
            this.tpTablaAmortizacion.Padding = new System.Windows.Forms.Padding(3);
            this.tpTablaAmortizacion.Size = new System.Drawing.Size(534, 277);
            this.tpTablaAmortizacion.TabIndex = 1;
            this.tpTablaAmortizacion.Text = "Tabla Amortización";
            this.tpTablaAmortizacion.UseVisualStyleBackColor = true;
            // 
            // dgvTablaAmortizacion
            // 
            this.dgvTablaAmortizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaAmortizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.Cuota,
            this.Fecha,
            this.CapitalAmortizado,
            this.Interes,
            this.IVA,
            this.CuotaAPagar,
            this.CapitalPendiente});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTablaAmortizacion.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTablaAmortizacion.Location = new System.Drawing.Point(7, 7);
            this.dgvTablaAmortizacion.Name = "dgvTablaAmortizacion";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaAmortizacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTablaAmortizacion.Size = new System.Drawing.Size(521, 264);
            this.dgvTablaAmortizacion.TabIndex = 0;
            this.dgvTablaAmortizacion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablaAmortizacion_CellEndEdit);
            this.dgvTablaAmortizacion.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTablaAmortizacion_DataError);
            this.dgvTablaAmortizacion.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTablaAmortizacion_EditingControlShowing);
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tipo.Visible = false;
            // 
            // Cuota
            // 
            this.Cuota.DataPropertyName = "Cuota";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cuota.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cuota.HeaderText = "Cuota";
            this.Cuota.Name = "Cuota";
            this.Cuota.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cuota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CapitalAmortizado
            // 
            this.CapitalAmortizado.DataPropertyName = "CapitalAmortizado";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0";
            this.CapitalAmortizado.DefaultCellStyle = dataGridViewCellStyle3;
            this.CapitalAmortizado.HeaderText = "Capital Amortizado";
            this.CapitalAmortizado.Name = "CapitalAmortizado";
            this.CapitalAmortizado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CapitalAmortizado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Interes
            // 
            this.Interes.DataPropertyName = "Interes";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "0";
            this.Interes.DefaultCellStyle = dataGridViewCellStyle4;
            this.Interes.HeaderText = "Interes";
            this.Interes.Name = "Interes";
            this.Interes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Interes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IVA
            // 
            this.IVA.DataPropertyName = "IVA";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = "0";
            this.IVA.DefaultCellStyle = dataGridViewCellStyle5;
            this.IVA.HeaderText = "IVA";
            this.IVA.Name = "IVA";
            this.IVA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IVA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CuotaAPagar
            // 
            this.CuotaAPagar.DataPropertyName = "CuotaAPagar";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = "0";
            this.CuotaAPagar.DefaultCellStyle = dataGridViewCellStyle6;
            this.CuotaAPagar.HeaderText = "Cuota a Pagar";
            this.CuotaAPagar.Name = "CuotaAPagar";
            this.CuotaAPagar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CuotaAPagar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CapitalPendiente
            // 
            this.CapitalPendiente.DataPropertyName = "CapitalPendiente";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = "0";
            this.CapitalPendiente.DefaultCellStyle = dataGridViewCellStyle7;
            this.CapitalPendiente.HeaderText = "Capital Pendiente";
            this.CapitalPendiente.Name = "CapitalPendiente";
            this.CapitalPendiente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CapitalPendiente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(471, 353);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 547;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(378, 353);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 546;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmPrestamosBancarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(565, 390);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.tcPrestamos);
            this.Controls.Add(this.dtFechaOtorgamiento);
            this.Controls.Add(this.label1);
            this.Name = "frmPrestamosBancarios";
            ((System.ComponentModel.ISupportInitialize)(this.nupCuotas)).EndInit();
            this.tcPrestamos.ResumeLayout(false);
            this.tpPrestamo.ResumeLayout(false);
            this.tpPrestamo.PerformLayout();
            this.tpTablaAmortizacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaAmortizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbCuentaBancaria;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbBancos;
        internal System.Windows.Forms.DateTimePicker dtFechaOtorgamiento;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbSistemasAmortizacion;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtValorPrestamo;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbFrencuenciaPago;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nupCuotas;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtTNA;
        public System.Windows.Forms.ComboBox cbPeriodoDeGracia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tcPrestamos;
        private System.Windows.Forms.TabPage tpPrestamo;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.TabPage tpTablaAmortizacion;
        private System.Windows.Forms.DataGridView dgvTablaAmortizacion;
        private System.Windows.Forms.CheckBox cbInteresPeriodoDeGracia;
        internal System.Windows.Forms.DateTimePicker dtpFechaPrimerCuota;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CapitalAmortizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interes;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaAPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CapitalPendiente;
    }
}
