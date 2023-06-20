namespace Presentacion
{
    partial class frmTipoDocumentoProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoDocumentoProveedor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabTipoDocumentoCliente = new System.Windows.Forms.TabControl();
            this.tpConfiguracion = new System.Windows.Forms.TabPage();
            this.cbLetra = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumerador = new System.Windows.Forms.Label();
            this.grTipoDiscriminacionIVA = new System.Windows.Forms.GroupBox();
            this.rbNoDiscrimina = new System.Windows.Forms.RadioButton();
            this.rbPie = new System.Windows.Forms.RadioButton();
            this.rbLinea = new System.Windows.Forms.RadioButton();
            this.txtCodigoNumerador = new System.Windows.Forms.TextBox();
            this.gbAfectaIVA = new System.Windows.Forms.GroupBox();
            this.rbAINoDiscrimina = new System.Windows.Forms.RadioButton();
            this.rbAICredito = new System.Windows.Forms.RadioButton();
            this.rbAIDebito = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gbAfectaCaja = new System.Windows.Forms.GroupBox();
            this.rbACNoAfecta = new System.Windows.Forms.RadioButton();
            this.rbACEgreso = new System.Windows.Forms.RadioButton();
            this.rbACIngreso = new System.Windows.Forms.RadioButton();
            this.gbAfectaCtaCte = new System.Windows.Forms.GroupBox();
            this.rbACCNoAfecta = new System.Windows.Forms.RadioButton();
            this.rbACCCredito = new System.Windows.Forms.RadioButton();
            this.rbACCDebito = new System.Windows.Forms.RadioButton();
            this.tpTipoIVAAsociado = new System.Windows.Forms.TabPage();
            this.cblTipoIVAAsociados = new System.Windows.Forms.CheckedListBox();
            this.tpRetenciones = new System.Windows.Forms.TabPage();
            this.cbRegimenes = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.rbIVA = new System.Windows.Forms.RadioButton();
            this.rbTotal = new System.Windows.Forms.RadioButton();
            this.rbNeto = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRetenciones = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.CodigoImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Del = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Del2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoRegimen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTipoDocumentoCliente.SuspendLayout();
            this.tpConfiguracion.SuspendLayout();
            this.grTipoDiscriminacionIVA.SuspendLayout();
            this.gbAfectaIVA.SuspendLayout();
            this.gbAfectaCaja.SuspendLayout();
            this.gbAfectaCtaCte.SuspendLayout();
            this.tpTipoIVAAsociado.SuspendLayout();
            this.tpRetenciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabTipoDocumentoCliente
            // 
            this.tabTipoDocumentoCliente.Controls.Add(this.tpConfiguracion);
            this.tabTipoDocumentoCliente.Controls.Add(this.tpTipoIVAAsociado);
            this.tabTipoDocumentoCliente.Controls.Add(this.tpRetenciones);
            this.tabTipoDocumentoCliente.Location = new System.Drawing.Point(17, 91);
            this.tabTipoDocumentoCliente.Multiline = true;
            this.tabTipoDocumentoCliente.Name = "tabTipoDocumentoCliente";
            this.tabTipoDocumentoCliente.SelectedIndex = 0;
            this.tabTipoDocumentoCliente.Size = new System.Drawing.Size(388, 334);
            this.tabTipoDocumentoCliente.TabIndex = 2;
            // 
            // tpConfiguracion
            // 
            this.tpConfiguracion.Controls.Add(this.cbLetra);
            this.tpConfiguracion.Controls.Add(this.label4);
            this.tpConfiguracion.Controls.Add(this.lblNumerador);
            this.tpConfiguracion.Controls.Add(this.grTipoDiscriminacionIVA);
            this.tpConfiguracion.Controls.Add(this.txtCodigoNumerador);
            this.tpConfiguracion.Controls.Add(this.gbAfectaIVA);
            this.tpConfiguracion.Controls.Add(this.label2);
            this.tpConfiguracion.Controls.Add(this.gbAfectaCaja);
            this.tpConfiguracion.Controls.Add(this.gbAfectaCtaCte);
            this.tpConfiguracion.Location = new System.Drawing.Point(4, 22);
            this.tpConfiguracion.Name = "tpConfiguracion";
            this.tpConfiguracion.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfiguracion.Size = new System.Drawing.Size(380, 308);
            this.tpConfiguracion.TabIndex = 0;
            this.tpConfiguracion.Text = "Configuración";
            this.tpConfiguracion.UseVisualStyleBackColor = true;
            // 
            // cbLetra
            // 
            this.cbLetra.Enabled = false;
            this.cbLetra.FormattingEnabled = true;
            this.cbLetra.Items.AddRange(new object[] {
            "",
            "A",
            "B",
            "C",
            "M"});
            this.cbLetra.Location = new System.Drawing.Point(103, 46);
            this.cbLetra.Name = "cbLetra";
            this.cbLetra.Size = new System.Drawing.Size(32, 21);
            this.cbLetra.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Letra:";
            // 
            // lblNumerador
            // 
            this.lblNumerador.AutoSize = true;
            this.lblNumerador.Location = new System.Drawing.Point(140, 19);
            this.lblNumerador.Name = "lblNumerador";
            this.lblNumerador.Size = new System.Drawing.Size(0, 13);
            this.lblNumerador.TabIndex = 10;
            // 
            // grTipoDiscriminacionIVA
            // 
            this.grTipoDiscriminacionIVA.Controls.Add(this.rbNoDiscrimina);
            this.grTipoDiscriminacionIVA.Controls.Add(this.rbPie);
            this.grTipoDiscriminacionIVA.Controls.Add(this.rbLinea);
            this.grTipoDiscriminacionIVA.Location = new System.Drawing.Point(17, 252);
            this.grTipoDiscriminacionIVA.Name = "grTipoDiscriminacionIVA";
            this.grTipoDiscriminacionIVA.Size = new System.Drawing.Size(300, 50);
            this.grTipoDiscriminacionIVA.TabIndex = 4;
            this.grTipoDiscriminacionIVA.TabStop = false;
            this.grTipoDiscriminacionIVA.Text = "Tipo Discriminación IVA";
            // 
            // rbNoDiscrimina
            // 
            this.rbNoDiscrimina.AutoSize = true;
            this.rbNoDiscrimina.Checked = true;
            this.rbNoDiscrimina.Location = new System.Drawing.Point(208, 19);
            this.rbNoDiscrimina.Name = "rbNoDiscrimina";
            this.rbNoDiscrimina.Size = new System.Drawing.Size(90, 17);
            this.rbNoDiscrimina.TabIndex = 2;
            this.rbNoDiscrimina.TabStop = true;
            this.rbNoDiscrimina.Text = "No Discrimina";
            this.rbNoDiscrimina.UseVisualStyleBackColor = true;
            this.rbNoDiscrimina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbNoDiscrimina_KeyDown);
            // 
            // rbPie
            // 
            this.rbPie.AutoSize = true;
            this.rbPie.Location = new System.Drawing.Point(122, 19);
            this.rbPie.Name = "rbPie";
            this.rbPie.Size = new System.Drawing.Size(40, 17);
            this.rbPie.TabIndex = 1;
            this.rbPie.Text = "Pié";
            this.rbPie.UseVisualStyleBackColor = true;
            this.rbPie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbPie_KeyDown);
            // 
            // rbLinea
            // 
            this.rbLinea.AutoSize = true;
            this.rbLinea.Location = new System.Drawing.Point(24, 19);
            this.rbLinea.Name = "rbLinea";
            this.rbLinea.Size = new System.Drawing.Size(51, 17);
            this.rbLinea.TabIndex = 0;
            this.rbLinea.Text = "Linea";
            this.rbLinea.UseVisualStyleBackColor = true;
            this.rbLinea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbLinea_KeyDown);
            // 
            // txtCodigoNumerador
            // 
            this.txtCodigoNumerador.Enabled = false;
            this.txtCodigoNumerador.Location = new System.Drawing.Point(103, 15);
            this.txtCodigoNumerador.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoNumerador.Name = "txtCodigoNumerador";
            this.txtCodigoNumerador.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoNumerador.TabIndex = 0;
            this.txtCodigoNumerador.TextChanged += new System.EventHandler(this.txtCodigoNumerador_TextChanged);
            this.txtCodigoNumerador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoNumerador_KeyDown);
            this.txtCodigoNumerador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoNumerador_KeyPress);
            // 
            // gbAfectaIVA
            // 
            this.gbAfectaIVA.Controls.Add(this.rbAINoDiscrimina);
            this.gbAfectaIVA.Controls.Add(this.rbAICredito);
            this.gbAfectaIVA.Controls.Add(this.rbAIDebito);
            this.gbAfectaIVA.Location = new System.Drawing.Point(17, 196);
            this.gbAfectaIVA.Name = "gbAfectaIVA";
            this.gbAfectaIVA.Size = new System.Drawing.Size(300, 50);
            this.gbAfectaIVA.TabIndex = 3;
            this.gbAfectaIVA.TabStop = false;
            this.gbAfectaIVA.Text = "Afecta IVA";
            // 
            // rbAINoDiscrimina
            // 
            this.rbAINoDiscrimina.AutoSize = true;
            this.rbAINoDiscrimina.Checked = true;
            this.rbAINoDiscrimina.Location = new System.Drawing.Point(208, 19);
            this.rbAINoDiscrimina.Name = "rbAINoDiscrimina";
            this.rbAINoDiscrimina.Size = new System.Drawing.Size(90, 17);
            this.rbAINoDiscrimina.TabIndex = 2;
            this.rbAINoDiscrimina.TabStop = true;
            this.rbAINoDiscrimina.Text = "No Discrimina";
            this.rbAINoDiscrimina.UseVisualStyleBackColor = true;
            this.rbAINoDiscrimina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAINoDiscrimina_KeyDown);
            // 
            // rbAICredito
            // 
            this.rbAICredito.AutoSize = true;
            this.rbAICredito.Location = new System.Drawing.Point(122, 19);
            this.rbAICredito.Name = "rbAICredito";
            this.rbAICredito.Size = new System.Drawing.Size(88, 17);
            this.rbAICredito.TabIndex = 1;
            this.rbAICredito.Text = "Crédito Fiscal";
            this.rbAICredito.UseVisualStyleBackColor = true;
            this.rbAICredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAICredito_KeyDown);
            // 
            // rbAIDebito
            // 
            this.rbAIDebito.AutoSize = true;
            this.rbAIDebito.Location = new System.Drawing.Point(24, 19);
            this.rbAIDebito.Name = "rbAIDebito";
            this.rbAIDebito.Size = new System.Drawing.Size(86, 17);
            this.rbAIDebito.TabIndex = 0;
            this.rbAIDebito.Text = "Débito Fiscal";
            this.rbAIDebito.UseVisualStyleBackColor = true;
            this.rbAIDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAIDebito_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Numerador (F4):";
            // 
            // gbAfectaCaja
            // 
            this.gbAfectaCaja.Controls.Add(this.rbACNoAfecta);
            this.gbAfectaCaja.Controls.Add(this.rbACEgreso);
            this.gbAfectaCaja.Controls.Add(this.rbACIngreso);
            this.gbAfectaCaja.Location = new System.Drawing.Point(17, 140);
            this.gbAfectaCaja.Name = "gbAfectaCaja";
            this.gbAfectaCaja.Size = new System.Drawing.Size(300, 50);
            this.gbAfectaCaja.TabIndex = 2;
            this.gbAfectaCaja.TabStop = false;
            this.gbAfectaCaja.Text = "Afecta Caja";
            // 
            // rbACNoAfecta
            // 
            this.rbACNoAfecta.AutoSize = true;
            this.rbACNoAfecta.Checked = true;
            this.rbACNoAfecta.Location = new System.Drawing.Point(208, 19);
            this.rbACNoAfecta.Name = "rbACNoAfecta";
            this.rbACNoAfecta.Size = new System.Drawing.Size(73, 17);
            this.rbACNoAfecta.TabIndex = 2;
            this.rbACNoAfecta.TabStop = true;
            this.rbACNoAfecta.Text = "No Afecta";
            this.rbACNoAfecta.UseVisualStyleBackColor = true;
            this.rbACNoAfecta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbACNoAfecta_KeyDown);
            // 
            // rbACEgreso
            // 
            this.rbACEgreso.AutoSize = true;
            this.rbACEgreso.Location = new System.Drawing.Point(122, 19);
            this.rbACEgreso.Name = "rbACEgreso";
            this.rbACEgreso.Size = new System.Drawing.Size(58, 17);
            this.rbACEgreso.TabIndex = 1;
            this.rbACEgreso.Text = "Egreso";
            this.rbACEgreso.UseVisualStyleBackColor = true;
            this.rbACEgreso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbACEgreso_KeyDown);
            // 
            // rbACIngreso
            // 
            this.rbACIngreso.AutoSize = true;
            this.rbACIngreso.Location = new System.Drawing.Point(24, 19);
            this.rbACIngreso.Name = "rbACIngreso";
            this.rbACIngreso.Size = new System.Drawing.Size(60, 17);
            this.rbACIngreso.TabIndex = 0;
            this.rbACIngreso.Text = "Ingreso";
            this.rbACIngreso.UseVisualStyleBackColor = true;
            this.rbACIngreso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbACIngreso_KeyDown);
            // 
            // gbAfectaCtaCte
            // 
            this.gbAfectaCtaCte.Controls.Add(this.rbACCNoAfecta);
            this.gbAfectaCtaCte.Controls.Add(this.rbACCCredito);
            this.gbAfectaCtaCte.Controls.Add(this.rbACCDebito);
            this.gbAfectaCtaCte.Location = new System.Drawing.Point(17, 84);
            this.gbAfectaCtaCte.Name = "gbAfectaCtaCte";
            this.gbAfectaCtaCte.Size = new System.Drawing.Size(300, 50);
            this.gbAfectaCtaCte.TabIndex = 1;
            this.gbAfectaCtaCte.TabStop = false;
            this.gbAfectaCtaCte.Text = "Afecta Cuenta Corriente";
            // 
            // rbACCNoAfecta
            // 
            this.rbACCNoAfecta.AutoSize = true;
            this.rbACCNoAfecta.Checked = true;
            this.rbACCNoAfecta.Location = new System.Drawing.Point(208, 19);
            this.rbACCNoAfecta.Name = "rbACCNoAfecta";
            this.rbACCNoAfecta.Size = new System.Drawing.Size(73, 17);
            this.rbACCNoAfecta.TabIndex = 2;
            this.rbACCNoAfecta.TabStop = true;
            this.rbACCNoAfecta.Text = "No Afecta";
            this.rbACCNoAfecta.UseVisualStyleBackColor = true;
            this.rbACCNoAfecta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbACCNoAfecta_KeyDown);
            // 
            // rbACCCredito
            // 
            this.rbACCCredito.AutoSize = true;
            this.rbACCCredito.Location = new System.Drawing.Point(122, 19);
            this.rbACCCredito.Name = "rbACCCredito";
            this.rbACCCredito.Size = new System.Drawing.Size(58, 17);
            this.rbACCCredito.TabIndex = 1;
            this.rbACCCredito.Text = "Crédito";
            this.rbACCCredito.UseVisualStyleBackColor = true;
            this.rbACCCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbACCCredito_KeyDown);
            // 
            // rbACCDebito
            // 
            this.rbACCDebito.AutoSize = true;
            this.rbACCDebito.Location = new System.Drawing.Point(24, 19);
            this.rbACCDebito.Name = "rbACCDebito";
            this.rbACCDebito.Size = new System.Drawing.Size(56, 17);
            this.rbACCDebito.TabIndex = 0;
            this.rbACCDebito.Text = "Débito";
            this.rbACCDebito.UseVisualStyleBackColor = true;
            this.rbACCDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbACCDebito_KeyDown);
            // 
            // tpTipoIVAAsociado
            // 
            this.tpTipoIVAAsociado.Controls.Add(this.cblTipoIVAAsociados);
            this.tpTipoIVAAsociado.Location = new System.Drawing.Point(4, 22);
            this.tpTipoIVAAsociado.Name = "tpTipoIVAAsociado";
            this.tpTipoIVAAsociado.Padding = new System.Windows.Forms.Padding(3);
            this.tpTipoIVAAsociado.Size = new System.Drawing.Size(380, 308);
            this.tpTipoIVAAsociado.TabIndex = 1;
            this.tpTipoIVAAsociado.Text = "Tipos de IVA asociados";
            this.tpTipoIVAAsociado.UseVisualStyleBackColor = true;
            // 
            // cblTipoIVAAsociados
            // 
            this.cblTipoIVAAsociados.FormattingEnabled = true;
            this.cblTipoIVAAsociados.Location = new System.Drawing.Point(31, 23);
            this.cblTipoIVAAsociados.Name = "cblTipoIVAAsociados";
            this.cblTipoIVAAsociados.Size = new System.Drawing.Size(307, 259);
            this.cblTipoIVAAsociados.TabIndex = 0;
            // 
            // tpRetenciones
            // 
            this.tpRetenciones.Controls.Add(this.cbRegimenes);
            this.tpRetenciones.Controls.Add(this.label10);
            this.tpRetenciones.Controls.Add(this.txtPorcentaje);
            this.tpRetenciones.Controls.Add(this.btnEliminarProducto);
            this.tpRetenciones.Controls.Add(this.btnAgregar);
            this.tpRetenciones.Controls.Add(this.dgvDatos);
            this.tpRetenciones.Controls.Add(this.rbIVA);
            this.tpRetenciones.Controls.Add(this.rbTotal);
            this.tpRetenciones.Controls.Add(this.rbNeto);
            this.tpRetenciones.Controls.Add(this.label9);
            this.tpRetenciones.Controls.Add(this.label8);
            this.tpRetenciones.Controls.Add(this.label7);
            this.tpRetenciones.Controls.Add(this.cbRetenciones);
            this.tpRetenciones.Controls.Add(this.label6);
            this.tpRetenciones.Location = new System.Drawing.Point(4, 22);
            this.tpRetenciones.Name = "tpRetenciones";
            this.tpRetenciones.Padding = new System.Windows.Forms.Padding(3);
            this.tpRetenciones.Size = new System.Drawing.Size(380, 308);
            this.tpRetenciones.TabIndex = 2;
            this.tpRetenciones.Text = "Retenciones";
            this.tpRetenciones.UseVisualStyleBackColor = true;
            this.tpRetenciones.Click += new System.EventHandler(this.tpRetenciones_Click);
            // 
            // cbRegimenes
            // 
            this.cbRegimenes.Enabled = false;
            this.cbRegimenes.FormattingEnabled = true;
            this.cbRegimenes.Location = new System.Drawing.Point(83, 88);
            this.cbRegimenes.Name = "cbRegimenes";
            this.cbRegimenes.Size = new System.Drawing.Size(256, 21);
            this.cbRegimenes.TabIndex = 58;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Regimen:";
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(83, 56);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(47, 20);
            this.txtPorcentaje.TabIndex = 57;
            this.txtPorcentaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPorcentaje_KeyDown);
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress_1);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarProducto.BackgroundImage")));
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(345, 125);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 56;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(345, 84);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 55;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoImpuesto,
            this.Impuesto,
            this.Porcentaje,
            this.Del,
            this.Del2,
            this.CodigoRegimen});
            this.dgvDatos.Location = new System.Drawing.Point(17, 125);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(322, 143);
            this.dgvDatos.TabIndex = 54;
            // 
            // rbIVA
            // 
            this.rbIVA.AutoSize = true;
            this.rbIVA.Location = new System.Drawing.Point(236, 59);
            this.rbIVA.Name = "rbIVA";
            this.rbIVA.Size = new System.Drawing.Size(42, 17);
            this.rbIVA.TabIndex = 53;
            this.rbIVA.Tag = "I";
            this.rbIVA.Text = "IVA";
            this.rbIVA.UseVisualStyleBackColor = true;
            // 
            // rbTotal
            // 
            this.rbTotal.AutoSize = true;
            this.rbTotal.Location = new System.Drawing.Point(290, 59);
            this.rbTotal.Name = "rbTotal";
            this.rbTotal.Size = new System.Drawing.Size(49, 17);
            this.rbTotal.TabIndex = 52;
            this.rbTotal.Tag = "T";
            this.rbTotal.Text = "Total";
            this.rbTotal.UseVisualStyleBackColor = true;
            // 
            // rbNeto
            // 
            this.rbNeto.AutoSize = true;
            this.rbNeto.Checked = true;
            this.rbNeto.Location = new System.Drawing.Point(182, 59);
            this.rbNeto.Name = "rbNeto";
            this.rbNeto.Size = new System.Drawing.Size(48, 17);
            this.rbNeto.TabIndex = 51;
            this.rbNeto.TabStop = true;
            this.rbNeto.Tag = "N";
            this.rbNeto.Text = "Neto";
            this.rbNeto.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(154, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "del";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Porcentaje:";
            // 
            // cbRetenciones
            // 
            this.cbRetenciones.Enabled = false;
            this.cbRetenciones.FormattingEnabled = true;
            this.cbRetenciones.Location = new System.Drawing.Point(83, 21);
            this.cbRetenciones.Name = "cbRetenciones";
            this.cbRetenciones.Size = new System.Drawing.Size(287, 21);
            this.cbRetenciones.TabIndex = 44;
            this.cbRetenciones.SelectedIndexChanged += new System.EventHandler(this.cbRetenciones_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Impuesto:";
            // 
            // cbTipo
            // 
            this.cbTipo.Enabled = false;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(295, 56);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(112, 21);
            this.cbTipo.TabIndex = 1;
            this.cbTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTipo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Tipo Documento:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(345, 14);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 39;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(80, 57);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(112, 20);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Codigo:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(77, 20);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 36;
            this.lblCodigo.Text = "(Codigo)";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(328, 439);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(203, 439);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(113, 439);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(22, 439);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // CodigoImpuesto
            // 
            this.CodigoImpuesto.HeaderText = "CodigoImpuesto";
            this.CodigoImpuesto.Name = "CodigoImpuesto";
            this.CodigoImpuesto.Visible = false;
            // 
            // Impuesto
            // 
            this.Impuesto.HeaderText = "Impuesto";
            this.Impuesto.Name = "Impuesto";
            this.Impuesto.Width = 170;
            // 
            // Porcentaje
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Porcentaje.DefaultCellStyle = dataGridViewCellStyle1;
            this.Porcentaje.FillWeight = 30F;
            this.Porcentaje.HeaderText = "Porcentaje";
            this.Porcentaje.Name = "Porcentaje";
            this.Porcentaje.Width = 70;
            // 
            // Del
            // 
            this.Del.HeaderText = "Del";
            this.Del.Name = "Del";
            this.Del.Width = 65;
            // 
            // Del2
            // 
            this.Del2.HeaderText = "Del2";
            this.Del2.Name = "Del2";
            this.Del2.Visible = false;
            // 
            // CodigoRegimen
            // 
            this.CodigoRegimen.HeaderText = "CodigoRegimen";
            this.CodigoRegimen.Name = "CodigoRegimen";
            this.CodigoRegimen.Visible = false;
            // 
            // frmTipoDocumentoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(417, 471);
            this.Controls.Add(this.tabTipoDocumentoCliente);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTipoDocumentoProveedor";
            this.tabTipoDocumentoCliente.ResumeLayout(false);
            this.tpConfiguracion.ResumeLayout(false);
            this.tpConfiguracion.PerformLayout();
            this.grTipoDiscriminacionIVA.ResumeLayout(false);
            this.grTipoDiscriminacionIVA.PerformLayout();
            this.gbAfectaIVA.ResumeLayout(false);
            this.gbAfectaIVA.PerformLayout();
            this.gbAfectaCaja.ResumeLayout(false);
            this.gbAfectaCaja.PerformLayout();
            this.gbAfectaCtaCte.ResumeLayout(false);
            this.gbAfectaCtaCte.PerformLayout();
            this.tpTipoIVAAsociado.ResumeLayout(false);
            this.tpRetenciones.ResumeLayout(false);
            this.tpRetenciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnNuevo;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblCodigo;
        public System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpConfiguracion;
        private System.Windows.Forms.TabControl tabTipoDocumentoCliente;
        private System.Windows.Forms.GroupBox gbAfectaCtaCte;
        private System.Windows.Forms.RadioButton rbACCNoAfecta;
        private System.Windows.Forms.RadioButton rbACCCredito;
        private System.Windows.Forms.RadioButton rbACCDebito;
        private System.Windows.Forms.GroupBox gbAfectaCaja;
        private System.Windows.Forms.RadioButton rbACNoAfecta;
        private System.Windows.Forms.RadioButton rbACEgreso;
        private System.Windows.Forms.RadioButton rbACIngreso;
        private System.Windows.Forms.GroupBox gbAfectaIVA;
        private System.Windows.Forms.RadioButton rbAINoDiscrimina;
        private System.Windows.Forms.RadioButton rbAICredito;
        private System.Windows.Forms.RadioButton rbAIDebito;
        private System.Windows.Forms.GroupBox grTipoDiscriminacionIVA;
        private System.Windows.Forms.RadioButton rbNoDiscrimina;
        private System.Windows.Forms.RadioButton rbPie;
        private System.Windows.Forms.RadioButton rbLinea;
        private System.Windows.Forms.TabPage tpTipoIVAAsociado;
        private System.Windows.Forms.CheckedListBox cblTipoIVAAsociados;
        private System.Windows.Forms.Label lblNumerador;
        public System.Windows.Forms.TextBox txtCodigoNumerador;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbLetra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tpRetenciones;
        public System.Windows.Forms.ComboBox cbRetenciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbIVA;
        private System.Windows.Forms.RadioButton rbTotal;
        private System.Windows.Forms.RadioButton rbNeto;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtPorcentaje;
        public System.Windows.Forms.ComboBox cbRegimenes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Del;
        private System.Windows.Forms.DataGridViewTextBoxColumn Del2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoRegimen;
    }
}
