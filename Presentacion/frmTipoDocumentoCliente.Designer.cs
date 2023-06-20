namespace Presentacion
{
    partial class frmTipoDocumentoCliente
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
            this.tabTipoDocumentoCliente = new System.Windows.Forms.TabControl();
            this.tpConfiguracion = new System.Windows.Forms.TabPage();
            this.cbElectronico = new System.Windows.Forms.CheckBox();
            this.grTipoDiscriminacionIVA = new System.Windows.Forms.GroupBox();
            this.rbNoDiscrimina = new System.Windows.Forms.RadioButton();
            this.rbPie = new System.Windows.Forms.RadioButton();
            this.rbLinea = new System.Windows.Forms.RadioButton();
            this.gbAfectaIVA = new System.Windows.Forms.GroupBox();
            this.rbAINoDiscrimina = new System.Windows.Forms.RadioButton();
            this.rbAICredito = new System.Windows.Forms.RadioButton();
            this.rbAIDebito = new System.Windows.Forms.RadioButton();
            this.gbAfectaCaja = new System.Windows.Forms.GroupBox();
            this.rbACNoAfecta = new System.Windows.Forms.RadioButton();
            this.rbACEgreso = new System.Windows.Forms.RadioButton();
            this.rbACIngreso = new System.Windows.Forms.RadioButton();
            this.gbAfectaCtaCte = new System.Windows.Forms.GroupBox();
            this.rbACCNoAfecta = new System.Windows.Forms.RadioButton();
            this.rbACCCredito = new System.Windows.Forms.RadioButton();
            this.rbACCDebito = new System.Windows.Forms.RadioButton();
            this.lblNumerador = new System.Windows.Forms.Label();
            this.txtCodigoNumerador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpTipoIVAAsociado = new System.Windows.Forms.TabPage();
            this.cblTipoIVAAsociados = new System.Windows.Forms.CheckedListBox();
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
            this.cbFacturasM = new System.Windows.Forms.CheckBox();
            this.tabTipoDocumentoCliente.SuspendLayout();
            this.tpConfiguracion.SuspendLayout();
            this.grTipoDiscriminacionIVA.SuspendLayout();
            this.gbAfectaIVA.SuspendLayout();
            this.gbAfectaCaja.SuspendLayout();
            this.gbAfectaCtaCte.SuspendLayout();
            this.tpTipoIVAAsociado.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTipoDocumentoCliente
            // 
            this.tabTipoDocumentoCliente.Controls.Add(this.tpConfiguracion);
            this.tabTipoDocumentoCliente.Controls.Add(this.tpTipoIVAAsociado);
            this.tabTipoDocumentoCliente.Location = new System.Drawing.Point(17, 91);
            this.tabTipoDocumentoCliente.Multiline = true;
            this.tabTipoDocumentoCliente.Name = "tabTipoDocumentoCliente";
            this.tabTipoDocumentoCliente.SelectedIndex = 0;
            this.tabTipoDocumentoCliente.Size = new System.Drawing.Size(388, 333);
            this.tabTipoDocumentoCliente.TabIndex = 42;
            // 
            // tpConfiguracion
            // 
            this.tpConfiguracion.Controls.Add(this.cbFacturasM);
            this.tpConfiguracion.Controls.Add(this.cbElectronico);
            this.tpConfiguracion.Controls.Add(this.grTipoDiscriminacionIVA);
            this.tpConfiguracion.Controls.Add(this.gbAfectaIVA);
            this.tpConfiguracion.Controls.Add(this.gbAfectaCaja);
            this.tpConfiguracion.Controls.Add(this.gbAfectaCtaCte);
            this.tpConfiguracion.Controls.Add(this.lblNumerador);
            this.tpConfiguracion.Controls.Add(this.txtCodigoNumerador);
            this.tpConfiguracion.Controls.Add(this.label2);
            this.tpConfiguracion.Location = new System.Drawing.Point(4, 22);
            this.tpConfiguracion.Name = "tpConfiguracion";
            this.tpConfiguracion.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfiguracion.Size = new System.Drawing.Size(380, 307);
            this.tpConfiguracion.TabIndex = 0;
            this.tpConfiguracion.Text = "Configuración";
            this.tpConfiguracion.UseVisualStyleBackColor = true;
            // 
            // cbElectronico
            // 
            this.cbElectronico.AutoSize = true;
            this.cbElectronico.Location = new System.Drawing.Point(41, 272);
            this.cbElectronico.Name = "cbElectronico";
            this.cbElectronico.Size = new System.Drawing.Size(79, 17);
            this.cbElectronico.TabIndex = 11;
            this.cbElectronico.Text = "Electronico";
            this.cbElectronico.UseVisualStyleBackColor = true;
            // 
            // grTipoDiscriminacionIVA
            // 
            this.grTipoDiscriminacionIVA.Controls.Add(this.rbNoDiscrimina);
            this.grTipoDiscriminacionIVA.Controls.Add(this.rbPie);
            this.grTipoDiscriminacionIVA.Controls.Add(this.rbLinea);
            this.grTipoDiscriminacionIVA.Location = new System.Drawing.Point(17, 215);
            this.grTipoDiscriminacionIVA.Name = "grTipoDiscriminacionIVA";
            this.grTipoDiscriminacionIVA.Size = new System.Drawing.Size(300, 50);
            this.grTipoDiscriminacionIVA.TabIndex = 10;
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
            this.rbNoDiscrimina.TabIndex = 7;
            this.rbNoDiscrimina.TabStop = true;
            this.rbNoDiscrimina.Text = "No Discrimina";
            this.rbNoDiscrimina.UseVisualStyleBackColor = true;
            this.rbNoDiscrimina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioButton1_KeyDown);
            // 
            // rbPie
            // 
            this.rbPie.AutoSize = true;
            this.rbPie.Location = new System.Drawing.Point(122, 19);
            this.rbPie.Name = "rbPie";
            this.rbPie.Size = new System.Drawing.Size(40, 17);
            this.rbPie.TabIndex = 6;
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
            this.rbLinea.TabIndex = 5;
            this.rbLinea.Text = "Linea";
            this.rbLinea.UseVisualStyleBackColor = true;
            this.rbLinea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbLinea_KeyDown);
            // 
            // gbAfectaIVA
            // 
            this.gbAfectaIVA.Controls.Add(this.rbAINoDiscrimina);
            this.gbAfectaIVA.Controls.Add(this.rbAICredito);
            this.gbAfectaIVA.Controls.Add(this.rbAIDebito);
            this.gbAfectaIVA.Location = new System.Drawing.Point(17, 159);
            this.gbAfectaIVA.Name = "gbAfectaIVA";
            this.gbAfectaIVA.Size = new System.Drawing.Size(300, 50);
            this.gbAfectaIVA.TabIndex = 9;
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
            this.rbAINoDiscrimina.TabIndex = 7;
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
            this.rbAICredito.TabIndex = 6;
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
            this.rbAIDebito.TabIndex = 5;
            this.rbAIDebito.Text = "Débito Fiscal";
            this.rbAIDebito.UseVisualStyleBackColor = true;
            this.rbAIDebito.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rbAIDebito_KeyUp);
            // 
            // gbAfectaCaja
            // 
            this.gbAfectaCaja.Controls.Add(this.rbACNoAfecta);
            this.gbAfectaCaja.Controls.Add(this.rbACEgreso);
            this.gbAfectaCaja.Controls.Add(this.rbACIngreso);
            this.gbAfectaCaja.Location = new System.Drawing.Point(17, 103);
            this.gbAfectaCaja.Name = "gbAfectaCaja";
            this.gbAfectaCaja.Size = new System.Drawing.Size(300, 50);
            this.gbAfectaCaja.TabIndex = 8;
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
            this.rbACNoAfecta.TabIndex = 7;
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
            this.rbACEgreso.TabIndex = 6;
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
            this.rbACIngreso.TabIndex = 5;
            this.rbACIngreso.Text = "Ingreso";
            this.rbACIngreso.UseVisualStyleBackColor = true;
            this.rbACIngreso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbACIngreso_KeyDown);
            // 
            // gbAfectaCtaCte
            // 
            this.gbAfectaCtaCte.Controls.Add(this.rbACCNoAfecta);
            this.gbAfectaCtaCte.Controls.Add(this.rbACCCredito);
            this.gbAfectaCtaCte.Controls.Add(this.rbACCDebito);
            this.gbAfectaCtaCte.Location = new System.Drawing.Point(17, 47);
            this.gbAfectaCtaCte.Name = "gbAfectaCtaCte";
            this.gbAfectaCtaCte.Size = new System.Drawing.Size(300, 50);
            this.gbAfectaCtaCte.TabIndex = 6;
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
            this.rbACCNoAfecta.TabIndex = 7;
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
            this.rbACCCredito.TabIndex = 6;
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
            this.rbACCDebito.TabIndex = 5;
            this.rbACCDebito.Text = "Débito";
            this.rbACCDebito.UseVisualStyleBackColor = true;
            this.rbACCDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbACCDebito_KeyDown);
            // 
            // lblNumerador
            // 
            this.lblNumerador.AutoSize = true;
            this.lblNumerador.Location = new System.Drawing.Point(132, 16);
            this.lblNumerador.Name = "lblNumerador";
            this.lblNumerador.Size = new System.Drawing.Size(0, 13);
            this.lblNumerador.TabIndex = 3;
            // 
            // txtCodigoNumerador
            // 
            this.txtCodigoNumerador.Enabled = false;
            this.txtCodigoNumerador.Location = new System.Drawing.Point(98, 13);
            this.txtCodigoNumerador.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoNumerador.Name = "txtCodigoNumerador";
            this.txtCodigoNumerador.Size = new System.Drawing.Size(29, 20);
            this.txtCodigoNumerador.TabIndex = 2;
            this.txtCodigoNumerador.TextChanged += new System.EventHandler(this.txtCodigoNumerador_TextChanged);
            this.txtCodigoNumerador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoNumerador_KeyDown);
            this.txtCodigoNumerador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoNumerador_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Numerador (F4):";
            // 
            // tpTipoIVAAsociado
            // 
            this.tpTipoIVAAsociado.Controls.Add(this.cblTipoIVAAsociados);
            this.tpTipoIVAAsociado.Location = new System.Drawing.Point(4, 22);
            this.tpTipoIVAAsociado.Name = "tpTipoIVAAsociado";
            this.tpTipoIVAAsociado.Padding = new System.Windows.Forms.Padding(3);
            this.tpTipoIVAAsociado.Size = new System.Drawing.Size(380, 307);
            this.tpTipoIVAAsociado.TabIndex = 1;
            this.tpTipoIVAAsociado.Text = "Tipos de IVA asociados";
            this.tpTipoIVAAsociado.UseVisualStyleBackColor = true;
            // 
            // cblTipoIVAAsociados
            // 
            this.cblTipoIVAAsociados.FormattingEnabled = true;
            this.cblTipoIVAAsociados.Location = new System.Drawing.Point(34, 22);
            this.cblTipoIVAAsociados.Name = "cblTipoIVAAsociados";
            this.cblTipoIVAAsociados.Size = new System.Drawing.Size(307, 274);
            this.cblTipoIVAAsociados.TabIndex = 0;
            // 
            // cbTipo
            // 
            this.cbTipo.Enabled = false;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(295, 56);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(112, 21);
            this.cbTipo.TabIndex = 40;
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
            this.txtDescripcion.TabIndex = 35;
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
            this.btnCancelar.Location = new System.Drawing.Point(328, 448);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(203, 448);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 33;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(113, 448);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 32;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(22, 448);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 31;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cbFacturasM
            // 
            this.cbFacturasM.AutoSize = true;
            this.cbFacturasM.Location = new System.Drawing.Point(126, 272);
            this.cbFacturasM.Name = "cbFacturasM";
            this.cbFacturasM.Size = new System.Drawing.Size(79, 17);
            this.cbFacturasM.TabIndex = 12;
            this.cbFacturasM.Text = "Facturas M";
            this.cbFacturasM.UseVisualStyleBackColor = true;
            // 
            // frmTipoDocumentoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(417, 484);
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
            this.Name = "frmTipoDocumentoCliente";
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
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCodigoNumerador;
        private System.Windows.Forms.Label lblNumerador;
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
        private System.Windows.Forms.CheckBox cbElectronico;
        private System.Windows.Forms.CheckBox cbFacturasM;
    }
}
