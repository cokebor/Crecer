namespace Presentacion
{
    partial class frmCambioDeCheques
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioDeCheques));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRechazados = new System.Windows.Forms.RadioButton();
            this.rbProveedor = new System.Windows.Forms.RadioButton();
            this.rbCartera = new System.Windows.Forms.RadioButton();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.Label16 = new System.Windows.Forms.Label();
            this.pProveedor = new System.Windows.Forms.Panel();
            this.lblRecibo = new System.Windows.Forms.Label();
            this.cbRecibos = new System.Windows.Forms.ComboBox();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.tcChequesProveedor = new System.Windows.Forms.TabControl();
            this.tpCheques = new System.Windows.Forms.TabPage();
            this.dgvCheques = new System.Windows.Forms.DataGridView();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpFormaDePago = new System.Windows.Forms.TabPage();
            this.tpChequesCartera = new System.Windows.Forms.TabPage();
            this.ucFormasPagoCompras = new Presentacion.ucFormasPagoCompras(false);
            this.tcChequesCartera = new System.Windows.Forms.TabControl();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblValores = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pProveedor.SuspendLayout();
            this.tcChequesProveedor.SuspendLayout();
            this.tpCheques.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheques)).BeginInit();
            this.tpFormaDePago.SuspendLayout();
            this.tcChequesCartera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRechazados);
            this.groupBox1.Controls.Add(this.rbProveedor);
            this.groupBox1.Controls.Add(this.rbCartera);
            this.groupBox1.Location = new System.Drawing.Point(6, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado de Cheques";
            // 
            // rbRechazados
            // 
            this.rbRechazados.AutoSize = true;
            this.rbRechazados.Location = new System.Drawing.Point(7, 65);
            this.rbRechazados.Name = "rbRechazados";
            this.rbRechazados.Size = new System.Drawing.Size(85, 17);
            this.rbRechazados.TabIndex = 2;
            this.rbRechazados.Text = "Rechazados";
            this.rbRechazados.UseVisualStyleBackColor = true;
            // 
            // rbProveedor
            // 
            this.rbProveedor.AutoSize = true;
            this.rbProveedor.Location = new System.Drawing.Point(7, 43);
            this.rbProveedor.Name = "rbProveedor";
            this.rbProveedor.Size = new System.Drawing.Size(74, 17);
            this.rbProveedor.TabIndex = 1;
            this.rbProveedor.Text = "Proveedor";
            this.rbProveedor.UseVisualStyleBackColor = true;
            // 
            // rbCartera
            // 
            this.rbCartera.AutoSize = true;
            this.rbCartera.Checked = true;
            this.rbCartera.Location = new System.Drawing.Point(7, 20);
            this.rbCartera.Name = "rbCartera";
            this.rbCartera.Size = new System.Drawing.Size(59, 17);
            this.rbCartera.TabIndex = 0;
            this.rbCartera.TabStop = true;
            this.rbCartera.Text = "Cartera";
            this.rbCartera.UseVisualStyleBackColor = true;
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(447, 12);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(88, 20);
            this.dtFecha.TabIndex = 56;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(401, 15);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(40, 13);
            this.Label16.TabIndex = 57;
            this.Label16.Text = "Fecha:";
            // 
            // pProveedor
            // 
            this.pProveedor.Controls.Add(this.lblRecibo);
            this.pProveedor.Controls.Add(this.cbRecibos);
            this.pProveedor.Controls.Add(this.txtCodigoProveedor);
            this.pProveedor.Controls.Add(this.lblNombreProveedor);
            this.pProveedor.Controls.Add(this.label3);
            this.pProveedor.Location = new System.Drawing.Point(168, 45);
            this.pProveedor.Name = "pProveedor";
            this.pProveedor.Size = new System.Drawing.Size(370, 60);
            this.pProveedor.TabIndex = 58;
            this.pProveedor.Visible = false;
            // 
            // lblRecibo
            // 
            this.lblRecibo.AutoSize = true;
            this.lblRecibo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRecibo.Location = new System.Drawing.Point(9, 39);
            this.lblRecibo.Name = "lblRecibo";
            this.lblRecibo.Size = new System.Drawing.Size(44, 13);
            this.lblRecibo.TabIndex = 405;
            this.lblRecibo.Text = "Recibo:";
            // 
            // cbRecibos
            // 
            this.cbRecibos.FormattingEnabled = true;
            this.cbRecibos.Location = new System.Drawing.Point(89, 36);
            this.cbRecibos.Name = "cbRecibos";
            this.cbRecibos.Size = new System.Drawing.Size(177, 21);
            this.cbRecibos.TabIndex = 404;
            
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(89, 7);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.MaxLength = 4;
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoProveedor.TabIndex = 51;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Location = new System.Drawing.Point(122, 10);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Proveedor (F6):";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(474, 522);
            this.shapeContainer1.TabIndex = 108;
            this.shapeContainer1.TabStop = false;
            // 
            // tcChequesProveedor
            // 
            this.tcChequesProveedor.Controls.Add(this.tpCheques);
            this.tcChequesProveedor.Controls.Add(this.tpFormaDePago);
            this.tcChequesProveedor.Location = new System.Drawing.Point(6, 113);
            this.tcChequesProveedor.Name = "tcChequesProveedor";
            this.tcChequesProveedor.SelectedIndex = 0;
            this.tcChequesProveedor.Size = new System.Drawing.Size(532, 310);
            this.tcChequesProveedor.TabIndex = 59;
            // 
            // tpCheques
            // 
            this.tpCheques.Controls.Add(this.dgvCheques);
            this.tpCheques.Location = new System.Drawing.Point(4, 22);
            this.tpCheques.Name = "tpCheques";
            this.tpCheques.Padding = new System.Windows.Forms.Padding(3);
            this.tpCheques.Size = new System.Drawing.Size(524, 284);
            this.tpCheques.TabIndex = 0;
            this.tpCheques.Text = "Cheques";
            this.tpCheques.UseVisualStyleBackColor = true;
            // 
            // dgvCheques
            // 
            this.dgvCheques.AllowUserToAddRows = false;
            this.dgvCheques.AllowUserToDeleteRows = false;
            this.dgvCheques.AllowUserToResizeRows = false;
            this.dgvCheques.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCheques.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCheques.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCheques.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.Codigo,
            this.Banco,
            this.CodigoCuentaBancaria,
            this.NroCheque,
            this.CodigoMoneda,
            this.FechaEmision,
            this.FechaPago,
            this.Importe});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCheques.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheques.EnableHeadersVisualStyles = false;
            this.dgvCheques.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvCheques.Location = new System.Drawing.Point(3, 3);
            this.dgvCheques.MultiSelect = false;
            this.dgvCheques.Name = "dgvCheques";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCheques.RowHeadersVisible = false;
            this.dgvCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheques.Size = new System.Drawing.Size(518, 278);
            this.dgvCheques.TabIndex = 539;
            // 
            // Seleccionado
            // 
            this.Seleccionado.DataPropertyName = "Seleccionado";
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            this.Seleccionado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // Banco
            // 
            this.Banco.DataPropertyName = "Banco";
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            // 
            // CodigoCuentaBancaria
            // 
            this.CodigoCuentaBancaria.DataPropertyName = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.HeaderText = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.Name = "CodigoCuentaBancaria";
            this.CodigoCuentaBancaria.Visible = false;
            // 
            // NroCheque
            // 
            this.NroCheque.DataPropertyName = "NroCheque";
            this.NroCheque.HeaderText = "Nro. Cheque";
            this.NroCheque.Name = "NroCheque";
            // 
            // CodigoMoneda
            // 
            this.CodigoMoneda.DataPropertyName = "CodigoMoneda";
            this.CodigoMoneda.HeaderText = "CodigoMoneda";
            this.CodigoMoneda.Name = "CodigoMoneda";
            this.CodigoMoneda.Visible = false;
            // 
            // FechaEmision
            // 
            this.FechaEmision.DataPropertyName = "FechaEmision";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.FechaEmision.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaEmision.HeaderText = "Fecha Emision";
            this.FechaEmision.Name = "FechaEmision";
            // 
            // FechaPago
            // 
            this.FechaPago.DataPropertyName = "FechaPago";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.FechaPago.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaPago.HeaderText = "Fecha Pago";
            this.FechaPago.Name = "FechaPago";
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Total";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle4;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // tpFormaDePago
            // 
            this.tpFormaDePago.Controls.Add(this.ucFormasPagoCompras);
            this.tpFormaDePago.Location = new System.Drawing.Point(4, 22);
            this.tpFormaDePago.Name = "tpFormaDePago";
            this.tpFormaDePago.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormaDePago.Size = new System.Drawing.Size(524, 284);
            this.tpFormaDePago.TabIndex = 1;
            this.tpFormaDePago.Text = "Formas De Pago";
            this.tpFormaDePago.UseVisualStyleBackColor = true;
            // 
            // ucFormasPagoCompras
            // 
            this.ucFormasPagoCompras.Cheques = ((System.Collections.Generic.List<Entidades.Cheque>)(resources.GetObject("ucFormasPagoCompras.Cheques")));
            this.ucFormasPagoCompras.ChequesPropios = ((System.Collections.Generic.List<Entidades.Cheque>)(resources.GetObject("ucFormasPagoCompras.ChequesPropios")));
            this.ucFormasPagoCompras.CodigoRecibo = 0;
            this.ucFormasPagoCompras.CreditosDebitos = ((System.Collections.Generic.List<Entidades.CreditoDebito>)(resources.GetObject("ucFormasPagoCompras.CreditosDebitos")));
            this.ucFormasPagoCompras.Dolares = 0D;
            this.ucFormasPagoCompras.Efectivo = 0D;
            this.ucFormasPagoCompras.Efectivos = ((System.Collections.Generic.List<Entidades.Factura_Efectivo>)(resources.GetObject("ucFormasPagoCompras.Efectivos")));
            this.ucFormasPagoCompras.FormularioInicial = null;
            this.ucFormasPagoCompras.Location = new System.Drawing.Point(3, 3);
            this.ucFormasPagoCompras.Name = "ucFormasPagoCompras";
            
            this.ucFormasPagoCompras.Size = new System.Drawing.Size(519, 276);
            this.ucFormasPagoCompras.TabIndex = 0;
            this.ucFormasPagoCompras.TipoDoc = "RC";
            this.ucFormasPagoCompras.Tranferencias = ((System.Collections.Generic.List<Entidades.Tranferencia>)(resources.GetObject("ucFormasPagoCompras.Tranferencias")));
            this.ucFormasPagoCompras.valores = 0D;
            // 
            // tpChequesCartera
            // 
            this.tpChequesCartera.Location = new System.Drawing.Point(4, 22);
            this.tpChequesCartera.Name = "tpChequesCartera";
            this.tpChequesCartera.Padding = new System.Windows.Forms.Padding(3);
            this.tpChequesCartera.Size = new System.Drawing.Size(524, 284);
            this.tpChequesCartera.TabIndex = 0;
            this.tpChequesCartera.Text = "Cheques en Cartera";
            this.tpChequesCartera.UseVisualStyleBackColor = true;
            // 
            // tcChequesCartera
            // 
            this.tcChequesCartera.Controls.Add(this.tpChequesCartera);
            this.tcChequesCartera.Location = new System.Drawing.Point(6, 113);
            this.tcChequesCartera.Name = "tcChequesCartera";
            this.tcChequesCartera.SelectedIndex = 0;
            this.tcChequesCartera.Size = new System.Drawing.Size(532, 310);
            this.tcChequesCartera.TabIndex = 60;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(456, 484);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 542;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(363, 484);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 541;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 431);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 13);
            this.label14.TabIndex = 544;
            this.label14.Text = "Cheques Rechazados:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(157, 429);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 543;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaldo
            // 
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.Maroon;
            this.lblSaldo.Location = new System.Drawing.Point(157, 472);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(100, 17);
            this.lblSaldo.TabIndex = 547;
            this.lblSaldo.Text = "0.00";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 474);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 548;
            this.label5.Text = "Saldo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 453);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 546;
            this.label7.Text = "Valores:";
            // 
            // lblValores
            // 
            this.lblValores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValores.ForeColor = System.Drawing.Color.Maroon;
            this.lblValores.Location = new System.Drawing.Point(157, 451);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(100, 17);
            this.lblValores.TabIndex = 545;
            this.lblValores.Text = "0.00";
            this.lblValores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCambioDeCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(539, 516);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblValores);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.tcChequesCartera);
            this.Controls.Add(this.tcChequesProveedor);
            this.Controls.Add(this.pProveedor);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCambioDeCheques";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pProveedor.ResumeLayout(false);
            this.pProveedor.PerformLayout();
            this.tcChequesProveedor.ResumeLayout(false);
            this.tpCheques.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheques)).EndInit();
            this.tpFormaDePago.ResumeLayout(false);
            this.tcChequesCartera.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbProveedor;
        private System.Windows.Forms.RadioButton rbCartera;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        internal System.Windows.Forms.Label Label16;
        private System.Windows.Forms.Panel pProveedor;
        public System.Windows.Forms.TextBox txtCodigoProveedor;
        public System.Windows.Forms.Label lblNombreProveedor;
        public System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label lblRecibo;
        public System.Windows.Forms.ComboBox cbRecibos;
        private System.Windows.Forms.TabControl tcChequesProveedor;
        private System.Windows.Forms.TabPage tpCheques;
        private System.Windows.Forms.TabPage tpFormaDePago;
        private System.Windows.Forms.TabPage tpChequesCartera;
        private System.Windows.Forms.TabControl tcChequesCartera;
        internal System.Windows.Forms.DataGridView dgvCheques;
        private ucFormasPagoCompras ucFormasPagoCompras;
        private System.Windows.Forms.RadioButton rbRechazados;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblValores;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
    }
}
