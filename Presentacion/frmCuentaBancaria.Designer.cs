namespace Presentacion
{
    partial class frmCuentaBancaria
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsBanco = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCuentaContableValoresDiferidos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCuentaContable = new System.Windows.Forms.ComboBox();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCuentaBancaria = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cbCuentaContableTranferencias = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtFechaConcialiacion = new System.Windows.Forms.DateTimePicker();
            this.cbCuentaContablePrestamos = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTranferencias = new System.Windows.Forms.CheckBox();
            this.cbDebitoCredito = new System.Windows.Forms.CheckBox();
            this.cbDebitoCreditoCompras = new System.Windows.Forms.CheckBox();
            this.cbCuentaContableDebitoCreditoCompras = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbCuentaContablePayWay = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbPayWay = new System.Windows.Forms.CheckBox();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CodigoBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContableValoresDiferidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContableTranferencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContablePrestamos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContableDebitoCreditoCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuentaContablePayWay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaConciliacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tranferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebitoCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebitoCreditoCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayWay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsBanco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsBanco
            // 
            this.cmsBanco.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBanco.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.cmsBanco.Name = "cmsBanco";
            this.cmsBanco.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // cbCuentaContableValoresDiferidos
            // 
            this.cbCuentaContableValoresDiferidos.Enabled = false;
            this.cbCuentaContableValoresDiferidos.FormattingEnabled = true;
            this.cbCuentaContableValoresDiferidos.Location = new System.Drawing.Point(444, 168);
            this.cbCuentaContableValoresDiferidos.Name = "cbCuentaContableValoresDiferidos";
            this.cbCuentaContableValoresDiferidos.Size = new System.Drawing.Size(285, 21);
            this.cbCuentaContableValoresDiferidos.TabIndex = 111;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 110;
            this.label6.Text = "Cuenta:";
            // 
            // cbCuentaContable
            // 
            this.cbCuentaContable.Enabled = false;
            this.cbCuentaContable.FormattingEnabled = true;
            this.cbCuentaContable.Location = new System.Drawing.Point(444, 140);
            this.cbCuentaContable.Name = "cbCuentaContable";
            this.cbCuentaContable.Size = new System.Drawing.Size(285, 21);
            this.cbCuentaContable.TabIndex = 109;
            // 
            // cbMoneda
            // 
            this.cbMoneda.Enabled = false;
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(444, 111);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(95, 21);
            this.cbMoneda.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.ContextMenuStrip = this.cmsBanco;
            this.cbBancos.Enabled = false;
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(444, 81);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(285, 21);
            this.cbBancos.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Cuenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Moneda:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(228, 233);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblNombreUsuario.TabIndex = 37;
            this.lblNombreUsuario.Visible = false;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(170, 233);
            this.lblGrupo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(0, 13);
            this.lblGrupo.TabIndex = 36;
            this.lblGrupo.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Número:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Codigo:";
            // 
            // txtCuentaBancaria
            // 
            this.txtCuentaBancaria.Enabled = false;
            this.txtCuentaBancaria.Location = new System.Drawing.Point(444, 55);
            this.txtCuentaBancaria.Margin = new System.Windows.Forms.Padding(2);
            this.txtCuentaBancaria.Name = "txtCuentaBancaria";
            this.txtCuentaBancaria.Size = new System.Drawing.Size(286, 20);
            this.txtCuentaBancaria.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(401, 22);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 28;
            this.lblCodigo.Text = "(Codigo)";
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Banco,
            this.NumeroCuenta,
            this.Estado,
            this.CodigoBanco,
            this.CodigoCuentaContable,
            this.CodigoCuentaContableValoresDiferidos,
            this.CodigoMoneda,
            this.CodigoCuentaContableTranferencias,
            this.CodigoCuentaContablePrestamos,
            this.CodigoCuentaContableDebitoCreditoCompras,
            this.CodigoCuentaContablePayWay,
            this.FechaConciliacion,
            this.Tranferencia,
            this.DebitoCredito,
            this.DebitoCreditoCompras,
            this.PayWay});
            this.dgvDatos.Location = new System.Drawing.Point(11, 11);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(313, 295);
            this.dgvDatos.TabIndex = 27;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(650, 336);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(199, 336);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(109, 336);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(18, 336);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cbCuentaContableTranferencias
            // 
            this.cbCuentaContableTranferencias.Enabled = false;
            this.cbCuentaContableTranferencias.FormattingEnabled = true;
            this.cbCuentaContableTranferencias.Location = new System.Drawing.Point(444, 197);
            this.cbCuentaContableTranferencias.Name = "cbCuentaContableTranferencias";
            this.cbCuentaContableTranferencias.Size = new System.Drawing.Size(285, 21);
            this.cbCuentaContableTranferencias.TabIndex = 113;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 112;
            this.label7.Text = "Transferencias:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(553, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 114;
            this.label8.Text = "Fecha Conc.:";
            // 
            // dtFechaConcialiacion
            // 
            this.dtFechaConcialiacion.Enabled = false;
            this.dtFechaConcialiacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaConcialiacion.Location = new System.Drawing.Point(629, 18);
            this.dtFechaConcialiacion.Name = "dtFechaConcialiacion";
            this.dtFechaConcialiacion.Size = new System.Drawing.Size(101, 20);
            this.dtFechaConcialiacion.TabIndex = 450;
            // 
            // cbCuentaContablePrestamos
            // 
            this.cbCuentaContablePrestamos.Enabled = false;
            this.cbCuentaContablePrestamos.FormattingEnabled = true;
            this.cbCuentaContablePrestamos.Location = new System.Drawing.Point(444, 225);
            this.cbCuentaContablePrestamos.Name = "cbCuentaContablePrestamos";
            this.cbCuentaContablePrestamos.Size = new System.Drawing.Size(285, 21);
            this.cbCuentaContablePrestamos.TabIndex = 452;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(335, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 451;
            this.label9.Text = "Prestamos:";
            // 
            // cbTranferencias
            // 
            this.cbTranferencias.AutoSize = true;
            this.cbTranferencias.Location = new System.Drawing.Point(339, 310);
            this.cbTranferencias.Name = "cbTranferencias";
            this.cbTranferencias.Size = new System.Drawing.Size(141, 17);
            this.cbTranferencias.TabIndex = 453;
            this.cbTranferencias.Text = "Tranferencias Recibidas";
            this.cbTranferencias.UseVisualStyleBackColor = true;
            // 
            // cbDebitoCredito
            // 
            this.cbDebitoCredito.AutoSize = true;
            this.cbDebitoCredito.Location = new System.Drawing.Point(486, 310);
            this.cbDebitoCredito.Name = "cbDebitoCredito";
            this.cbDebitoCredito.Size = new System.Drawing.Size(131, 17);
            this.cbDebitoCredito.TabIndex = 454;
            this.cbDebitoCredito.Text = "Debito/Credito Ventas";
            this.cbDebitoCredito.UseVisualStyleBackColor = true;
            // 
            // cbDebitoCreditoCompras
            // 
            this.cbDebitoCreditoCompras.AutoSize = true;
            this.cbDebitoCreditoCompras.Location = new System.Drawing.Point(629, 310);
            this.cbDebitoCreditoCompras.Name = "cbDebitoCreditoCompras";
            this.cbDebitoCreditoCompras.Size = new System.Drawing.Size(103, 17);
            this.cbDebitoCreditoCompras.TabIndex = 455;
            this.cbDebitoCreditoCompras.Text = "Credito Compras";
            this.cbDebitoCreditoCompras.UseVisualStyleBackColor = true;
            // 
            // cbCuentaContableDebitoCreditoCompras
            // 
            this.cbCuentaContableDebitoCreditoCompras.Enabled = false;
            this.cbCuentaContableDebitoCreditoCompras.FormattingEnabled = true;
            this.cbCuentaContableDebitoCreditoCompras.Location = new System.Drawing.Point(444, 252);
            this.cbCuentaContableDebitoCreditoCompras.Name = "cbCuentaContableDebitoCreditoCompras";
            this.cbCuentaContableDebitoCreditoCompras.Size = new System.Drawing.Size(285, 21);
            this.cbCuentaContableDebitoCreditoCompras.TabIndex = 457;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 456;
            this.label10.Text = "Tarjeta Credito:";
            // 
            // cbCuentaContablePayWay
            // 
            this.cbCuentaContablePayWay.Enabled = false;
            this.cbCuentaContablePayWay.FormattingEnabled = true;
            this.cbCuentaContablePayWay.Location = new System.Drawing.Point(444, 279);
            this.cbCuentaContablePayWay.Name = "cbCuentaContablePayWay";
            this.cbCuentaContablePayWay.Size = new System.Drawing.Size(285, 21);
            this.cbCuentaContablePayWay.TabIndex = 459;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(335, 283);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 458;
            this.label11.Text = "PayWay:";
            // 
            // cbPayWay
            // 
            this.cbPayWay.AutoSize = true;
            this.cbPayWay.Location = new System.Drawing.Point(338, 342);
            this.cbPayWay.Name = "cbPayWay";
            this.cbPayWay.Size = new System.Drawing.Size(66, 17);
            this.cbPayWay.TabIndex = 460;
            this.cbPayWay.Text = "PayWay";
            this.cbPayWay.UseVisualStyleBackColor = true;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Banco
            // 
            this.Banco.DataPropertyName = "Banco";
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            // 
            // NumeroCuenta
            // 
            this.NumeroCuenta.DataPropertyName = "NumeroCuenta";
            this.NumeroCuenta.HeaderText = "Cuenta";
            this.NumeroCuenta.Name = "NumeroCuenta";
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CodigoBanco
            // 
            this.CodigoBanco.DataPropertyName = "CodigoBanco";
            this.CodigoBanco.HeaderText = "CodigoBanco";
            this.CodigoBanco.Name = "CodigoBanco";
            this.CodigoBanco.Visible = false;
            // 
            // CodigoCuentaContable
            // 
            this.CodigoCuentaContable.DataPropertyName = "CodigoCuentaContable";
            this.CodigoCuentaContable.HeaderText = "CodigoCuentaContable";
            this.CodigoCuentaContable.Name = "CodigoCuentaContable";
            this.CodigoCuentaContable.Visible = false;
            // 
            // CodigoCuentaContableValoresDiferidos
            // 
            this.CodigoCuentaContableValoresDiferidos.DataPropertyName = "CodigoCuentaContableValoresDiferidos";
            this.CodigoCuentaContableValoresDiferidos.HeaderText = "CodigoCuentaContableValoresDiferidos";
            this.CodigoCuentaContableValoresDiferidos.Name = "CodigoCuentaContableValoresDiferidos";
            this.CodigoCuentaContableValoresDiferidos.Visible = false;
            // 
            // CodigoMoneda
            // 
            this.CodigoMoneda.DataPropertyName = "CodigoMoneda";
            this.CodigoMoneda.HeaderText = "CodigoMoneda";
            this.CodigoMoneda.Name = "CodigoMoneda";
            this.CodigoMoneda.Visible = false;
            // 
            // CodigoCuentaContableTranferencias
            // 
            this.CodigoCuentaContableTranferencias.DataPropertyName = "CodigoCuentaContableTranferencias";
            this.CodigoCuentaContableTranferencias.HeaderText = "CodigoCuentaContableTranferencias";
            this.CodigoCuentaContableTranferencias.Name = "CodigoCuentaContableTranferencias";
            this.CodigoCuentaContableTranferencias.Visible = false;
            // 
            // CodigoCuentaContablePrestamos
            // 
            this.CodigoCuentaContablePrestamos.DataPropertyName = "CodigoCuentaContablePrestamos";
            this.CodigoCuentaContablePrestamos.HeaderText = "CodigoCuentaContablePrestamos";
            this.CodigoCuentaContablePrestamos.Name = "CodigoCuentaContablePrestamos";
            this.CodigoCuentaContablePrestamos.Visible = false;
            // 
            // CodigoCuentaContableDebitoCreditoCompras
            // 
            this.CodigoCuentaContableDebitoCreditoCompras.DataPropertyName = "CodigoCuentaContableDebitoCreditoCompras";
            this.CodigoCuentaContableDebitoCreditoCompras.HeaderText = "CodigoCuentaContableDebitoCreditoCompras";
            this.CodigoCuentaContableDebitoCreditoCompras.Name = "CodigoCuentaContableDebitoCreditoCompras";
            this.CodigoCuentaContableDebitoCreditoCompras.Visible = false;
            // 
            // CodigoCuentaContablePayWay
            // 
            this.CodigoCuentaContablePayWay.DataPropertyName = "CodigoCuentaContablePayWay";
            this.CodigoCuentaContablePayWay.HeaderText = "CodigoCuentaContablePayWay";
            this.CodigoCuentaContablePayWay.Name = "CodigoCuentaContablePayWay";
            this.CodigoCuentaContablePayWay.Visible = false;
            // 
            // FechaConciliacion
            // 
            this.FechaConciliacion.DataPropertyName = "FechaConciliacion";
            this.FechaConciliacion.HeaderText = "FechaConciliacion";
            this.FechaConciliacion.Name = "FechaConciliacion";
            this.FechaConciliacion.Visible = false;
            // 
            // Tranferencia
            // 
            this.Tranferencia.DataPropertyName = "Tranferencia";
            this.Tranferencia.HeaderText = "Tranferencia";
            this.Tranferencia.Name = "Tranferencia";
            this.Tranferencia.Visible = false;
            // 
            // DebitoCredito
            // 
            this.DebitoCredito.DataPropertyName = "DebitoCredito";
            this.DebitoCredito.HeaderText = "DebitoCredito";
            this.DebitoCredito.Name = "DebitoCredito";
            this.DebitoCredito.Visible = false;
            // 
            // DebitoCreditoCompras
            // 
            this.DebitoCreditoCompras.DataPropertyName = "DebitoCreditoCompras";
            this.DebitoCreditoCompras.HeaderText = "DebitoCreditoCompras";
            this.DebitoCreditoCompras.Name = "DebitoCreditoCompras";
            this.DebitoCreditoCompras.Visible = false;
            // 
            // PayWay
            // 
            this.PayWay.DataPropertyName = "PayWay";
            this.PayWay.HeaderText = "PayWay";
            this.PayWay.Name = "PayWay";
            this.PayWay.Visible = false;
            // 
            // frmCuentaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(749, 387);
            this.Controls.Add(this.cbPayWay);
            this.Controls.Add(this.cbCuentaContablePayWay);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbCuentaContableDebitoCreditoCompras);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbDebitoCreditoCompras);
            this.Controls.Add(this.cbDebitoCredito);
            this.Controls.Add(this.cbTranferencias);
            this.Controls.Add(this.cbCuentaContablePrestamos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtFechaConcialiacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbCuentaContableTranferencias);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbCuentaContableValoresDiferidos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbCuentaContable);
            this.Controls.Add(this.cbMoneda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBancos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCuentaBancaria);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCuentaBancaria";
            this.Activated += new System.EventHandler(this.frmCuentaBancaria_Activated);
            this.Load += new System.EventHandler(this.frmCuentaBancaria_Load);
            this.cmsBanco.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblNombreUsuario;
        public System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCuentaBancaria;
        public System.Windows.Forms.Label lblCodigo;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbBancos;
        public System.Windows.Forms.ComboBox cbMoneda;
        public System.Windows.Forms.ComboBox cbCuentaContable;
        public System.Windows.Forms.ContextMenuStrip cmsBanco;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        public System.Windows.Forms.ComboBox cbCuentaContableValoresDiferidos;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbCuentaContableTranferencias;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.DateTimePicker dtFechaConcialiacion;
        public System.Windows.Forms.ComboBox cbCuentaContablePrestamos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbTranferencias;
        private System.Windows.Forms.CheckBox cbDebitoCredito;
        private System.Windows.Forms.CheckBox cbDebitoCreditoCompras;
        public System.Windows.Forms.ComboBox cbCuentaContableDebitoCreditoCompras;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cbCuentaContablePayWay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbPayWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCuenta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContableValoresDiferidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContableTranferencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContablePrestamos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContableDebitoCreditoCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuentaContablePayWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaConciliacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tranferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebitoCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebitoCreditoCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayWay;
    }
}
