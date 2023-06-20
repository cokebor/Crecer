using Controles2;

namespace Presentacion
{
    partial class frmEmpleado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsPais = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsComunicacion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPuesto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalidad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProvincia = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsObraSocial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.cbObraSocial = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarComunicacion = new System.Windows.Forms.Button();
            this.btnAgregarComunicacion = new System.Windows.Forms.Button();
            this.dgvComunicaciones = new System.Windows.Forms.DataGridView();
            this.CodigoComunicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRenglon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtComunicacion = new System.Windows.Forms.TextBox();
            this.cbComunicaciones = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCausa = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpEgreso = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpIngreso = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.cbPuestos = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLocalidades = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbProvincias = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBarrio = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cbPais = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nupHijos = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbEstadosCiviles = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCUIL = new Controles2.txtCUIL();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbFueraDeConvenio = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmsPais.SuspendLayout();
            this.cmsComunicacion.SuspendLayout();
            this.cmsPuesto.SuspendLayout();
            this.cmsLocalidad.SuspendLayout();
            this.cmsProvincia.SuspendLayout();
            this.cmsObraSocial.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComunicaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupHijos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsPais
            // 
            this.cmsPais.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.cmsPais.Name = "cmsPais";
            this.cmsPais.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // cmsComunicacion
            // 
            this.cmsComunicacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem2});
            this.cmsComunicacion.Name = "cmsComunicacion";
            this.cmsComunicacion.Size = new System.Drawing.Size(117, 26);
            this.cmsComunicacion.Opening += new System.ComponentModel.CancelEventHandler(this.cmsComunicacion_Opening);
            // 
            // agregarToolStripMenuItem2
            // 
            this.agregarToolStripMenuItem2.Name = "agregarToolStripMenuItem2";
            this.agregarToolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem2.Text = "Agregar";
            this.agregarToolStripMenuItem2.Click += new System.EventHandler(this.agregarToolStripMenuItem2_Click);
            // 
            // cmsPuesto
            // 
            this.cmsPuesto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem1});
            this.cmsPuesto.Name = "cmsPuesto";
            this.cmsPuesto.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem1
            // 
            this.agregarToolStripMenuItem1.Name = "agregarToolStripMenuItem1";
            this.agregarToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem1.Text = "Agregar";
            this.agregarToolStripMenuItem1.Click += new System.EventHandler(this.agregarToolStripMenuItem1_Click);
            // 
            // cmsLocalidad
            // 
            this.cmsLocalidad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem3});
            this.cmsLocalidad.Name = "cmsLocalidad";
            this.cmsLocalidad.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem3
            // 
            this.agregarToolStripMenuItem3.Name = "agregarToolStripMenuItem3";
            this.agregarToolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem3.Text = "Agregar";
            this.agregarToolStripMenuItem3.Click += new System.EventHandler(this.agregarToolStripMenuItem3_Click);
            // 
            // cmsProvincia
            // 
            this.cmsProvincia.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem5});
            this.cmsProvincia.Name = "cmsProvincia";
            this.cmsProvincia.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem5
            // 
            this.agregarToolStripMenuItem5.Name = "agregarToolStripMenuItem5";
            this.agregarToolStripMenuItem5.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem5.Text = "Agregar";
            this.agregarToolStripMenuItem5.Click += new System.EventHandler(this.agregarToolStripMenuItem5_Click);
            // 
            // cmsObraSocial
            // 
            this.cmsObraSocial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem4});
            this.cmsObraSocial.Name = "cmsObraSocial";
            this.cmsObraSocial.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem4
            // 
            this.agregarToolStripMenuItem4.Name = "agregarToolStripMenuItem4";
            this.agregarToolStripMenuItem4.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem4.Text = "Agregar";
            this.agregarToolStripMenuItem4.Click += new System.EventHandler(this.agregarToolStripMenuItem4_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(122, 551);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 17;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(407, 551);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(475, 16);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(11, 404);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 13);
            this.label24.TabIndex = 49;
            this.label24.Text = "O. Social.:";
            // 
            // cbObraSocial
            // 
            this.cbObraSocial.ContextMenuStrip = this.cmsObraSocial;
            this.cbObraSocial.Enabled = false;
            this.cbObraSocial.FormattingEnabled = true;
            this.cbObraSocial.Location = new System.Drawing.Point(69, 401);
            this.cbObraSocial.Name = "cbObraSocial";
            this.cbObraSocial.Size = new System.Drawing.Size(98, 21);
            this.cbObraSocial.TabIndex = 14;
            this.cbObraSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbObraSocial_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarComunicacion);
            this.groupBox2.Controls.Add(this.btnAgregarComunicacion);
            this.groupBox2.Controls.Add(this.dgvComunicaciones);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.txtComunicacion);
            this.groupBox2.Controls.Add(this.cbComunicaciones);
            this.groupBox2.Location = new System.Drawing.Point(5, 434);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 107);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comunicación";
            // 
            // btnEliminarComunicacion
            // 
            this.btnEliminarComunicacion.CausesValidation = false;
            this.btnEliminarComunicacion.Enabled = false;
            this.btnEliminarComunicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarComunicacion.Location = new System.Drawing.Point(188, 61);
            this.btnEliminarComunicacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarComunicacion.Name = "btnEliminarComunicacion";
            this.btnEliminarComunicacion.Size = new System.Drawing.Size(62, 26);
            this.btnEliminarComunicacion.TabIndex = 33;
            this.btnEliminarComunicacion.Text = "ELIMINAR";
            this.btnEliminarComunicacion.UseVisualStyleBackColor = true;
            this.btnEliminarComunicacion.Click += new System.EventHandler(this.btnEliminarComunicacion_Click);
            // 
            // btnAgregarComunicacion
            // 
            this.btnAgregarComunicacion.CausesValidation = false;
            this.btnAgregarComunicacion.Enabled = false;
            this.btnAgregarComunicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarComunicacion.Location = new System.Drawing.Point(188, 19);
            this.btnAgregarComunicacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarComunicacion.Name = "btnAgregarComunicacion";
            this.btnAgregarComunicacion.Size = new System.Drawing.Size(62, 26);
            this.btnAgregarComunicacion.TabIndex = 2;
            this.btnAgregarComunicacion.Text = "AGREGAR";
            this.btnAgregarComunicacion.UseVisualStyleBackColor = true;
            this.btnAgregarComunicacion.Click += new System.EventHandler(this.btnAgregarComunicacion_Click);
            this.btnAgregarComunicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnAgregarComunicacion_KeyPress);
            // 
            // dgvComunicaciones
            // 
            this.dgvComunicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComunicaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoComunicacion,
            this.Tipo,
            this.IdRenglon,
            this.Descripcion});
            this.dgvComunicaciones.Enabled = false;
            this.dgvComunicaciones.Location = new System.Drawing.Point(272, 19);
            this.dgvComunicaciones.Name = "dgvComunicaciones";
            this.dgvComunicaciones.Size = new System.Drawing.Size(260, 78);
            this.dgvComunicaciones.TabIndex = 26;
            // 
            // CodigoComunicacion
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodigoComunicacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.CodigoComunicacion.HeaderText = "CodigoComunicacion";
            this.CodigoComunicacion.Name = "CodigoComunicacion";
            this.CodigoComunicacion.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // IdRenglon
            // 
            this.IdRenglon.HeaderText = "IdRenglon";
            this.IdRenglon.Name = "IdRenglon";
            this.IdRenglon.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 65);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 13);
            this.label23.TabIndex = 31;
            this.label23.Text = "Dato:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 13);
            this.label22.TabIndex = 27;
            this.label22.Text = "Tipo:";
            // 
            // txtComunicacion
            // 
            this.txtComunicacion.Enabled = false;
            this.txtComunicacion.Location = new System.Drawing.Point(64, 62);
            this.txtComunicacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtComunicacion.Name = "txtComunicacion";
            this.txtComunicacion.Size = new System.Drawing.Size(98, 20);
            this.txtComunicacion.TabIndex = 1;
            this.txtComunicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComunicacion_KeyPress);
            // 
            // cbComunicaciones
            // 
            this.cbComunicaciones.ContextMenuStrip = this.cmsComunicacion;
            this.cbComunicaciones.Enabled = false;
            this.cbComunicaciones.FormattingEnabled = true;
            this.cbComunicaciones.Location = new System.Drawing.Point(64, 23);
            this.cbComunicaciones.Name = "cbComunicaciones";
            this.cbComunicaciones.Size = new System.Drawing.Size(98, 21);
            this.cbComunicaciones.TabIndex = 0;
            this.cbComunicaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbComunicaciones_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(354, 138);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 46;
            this.label20.Text = "Causa:";
            // 
            // txtCausa
            // 
            this.txtCausa.Enabled = false;
            this.txtCausa.Location = new System.Drawing.Point(408, 135);
            this.txtCausa.Margin = new System.Windows.Forms.Padding(2);
            this.txtCausa.Name = "txtCausa";
            this.txtCausa.Size = new System.Drawing.Size(129, 20);
            this.txtCausa.TabIndex = 9;
            this.txtCausa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCausa_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(185, 138);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "Egreso:";
            // 
            // dtpEgreso
            // 
            this.dtpEgreso.Checked = false;
            this.dtpEgreso.Enabled = false;
            this.dtpEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEgreso.Location = new System.Drawing.Point(242, 136);
            this.dtpEgreso.Name = "dtpEgreso";
            this.dtpEgreso.ShowCheckBox = true;
            this.dtpEgreso.Size = new System.Drawing.Size(97, 20);
            this.dtpEgreso.TabIndex = 8;
            this.dtpEgreso.ValueChanged += new System.EventHandler(this.dtpEgreso_ValueChanged);
            this.dtpEgreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpEgreso_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Ingreso:";
            // 
            // dtpIngreso
            // 
            this.dtpIngreso.Enabled = false;
            this.dtpIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIngreso.Location = new System.Drawing.Point(69, 136);
            this.dtpIngreso.Name = "dtpIngreso";
            this.dtpIngreso.Size = new System.Drawing.Size(98, 20);
            this.dtpIngreso.TabIndex = 7;
            this.dtpIngreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpIngreso_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(354, 62);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Puesto:";
            // 
            // cbPuestos
            // 
            this.cbPuestos.ContextMenuStrip = this.cmsPuesto;
            this.cbPuestos.Enabled = false;
            this.cbPuestos.FormattingEnabled = true;
            this.cbPuestos.Location = new System.Drawing.Point(407, 59);
            this.cbPuestos.Name = "cbPuestos";
            this.cbPuestos.Size = new System.Drawing.Size(130, 21);
            this.cbPuestos.TabIndex = 3;
            this.cbPuestos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPuestos_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSucursales);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.cbLocalidades);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cbProvincias);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtCodigoPostal);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtBarrio);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.cbPais);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 138);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domicilio";
            // 
            // cbLocalidades
            // 
            this.cbLocalidades.ContextMenuStrip = this.cmsLocalidad;
            this.cbLocalidades.Enabled = false;
            this.cbLocalidades.FormattingEnabled = true;
            this.cbLocalidades.Location = new System.Drawing.Point(406, 102);
            this.cbLocalidades.Name = "cbLocalidades";
            this.cbLocalidades.Size = new System.Drawing.Size(135, 21);
            this.cbLocalidades.TabIndex = 5;
            this.cbLocalidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLocalidades_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(352, 105);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "Localidad:";
            // 
            // cbProvincias
            // 
            this.cbProvincias.ContextMenuStrip = this.cmsProvincia;
            this.cbProvincias.Enabled = false;
            this.cbProvincias.FormattingEnabled = true;
            this.cbProvincias.Location = new System.Drawing.Point(236, 102);
            this.cbProvincias.Name = "cbProvincias";
            this.cbProvincias.Size = new System.Drawing.Size(98, 21);
            this.cbProvincias.TabIndex = 4;
            this.cbProvincias.SelectedIndexChanged += new System.EventHandler(this.cbProvincias_SelectedIndexChanged);
            this.cbProvincias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbProvincias_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(185, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "C.P.:";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Enabled = false;
            this.txtCodigoPostal.Location = new System.Drawing.Point(237, 64);
            this.txtCodigoPostal.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(96, 20);
            this.txtCodigoPostal.TabIndex = 2;
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Barrio:";
            // 
            // txtBarrio
            // 
            this.txtBarrio.Enabled = false;
            this.txtBarrio.Location = new System.Drawing.Point(64, 64);
            this.txtBarrio.Margin = new System.Windows.Forms.Padding(2);
            this.txtBarrio.Name = "txtBarrio";
            this.txtBarrio.Size = new System.Drawing.Size(98, 20);
            this.txtBarrio.TabIndex = 1;
            this.txtBarrio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarrio_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(64, 27);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(269, 20);
            this.txtDireccion.TabIndex = 0;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // cbPais
            // 
            this.cbPais.ContextMenuStrip = this.cmsPais;
            this.cbPais.Enabled = false;
            this.cbPais.FormattingEnabled = true;
            this.cbPais.Location = new System.Drawing.Point(64, 102);
            this.cbPais.Name = "cbPais";
            this.cbPais.Size = new System.Drawing.Size(98, 21);
            this.cbPais.TabIndex = 3;
            this.cbPais.SelectedIndexChanged += new System.EventHandler(this.cbPais_SelectedIndexChanged);
            this.cbPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPais_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pais:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Provincia:";
            // 
            // nupHijos
            // 
            this.nupHijos.Enabled = false;
            this.nupHijos.Location = new System.Drawing.Point(411, 325);
            this.nupHijos.Name = "nupHijos";
            this.nupHijos.Size = new System.Drawing.Size(64, 20);
            this.nupHijos.TabIndex = 12;
            this.nupHijos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupHijos_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(354, 328);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Hijos:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(185, 328);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "E. Civil:";
            // 
            // cbEstadosCiviles
            // 
            this.cbEstadosCiviles.Enabled = false;
            this.cbEstadosCiviles.FormattingEnabled = true;
            this.cbEstadosCiviles.Location = new System.Drawing.Point(240, 325);
            this.cbEstadosCiviles.Name = "cbEstadosCiviles";
            this.cbEstadosCiviles.Size = new System.Drawing.Size(99, 21);
            this.cbEstadosCiviles.TabIndex = 11;
            this.cbEstadosCiviles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEstadosCiviles_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(354, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "CUIL:";
            // 
            // txtCUIL
            // 
            this.txtCUIL.AutoSize = true;
            this.txtCUIL.Enabled = false;
            this.txtCUIL.Location = new System.Drawing.Point(408, 95);
            this.txtCUIL.Name = "txtCUIL";
            this.txtCUIL.Size = new System.Drawing.Size(102, 23);
            this.txtCUIL.TabIndex = 6;
            this.txtCUIL.Load += new System.EventHandler(this.txtCUIL_Load);
            this.txtCUIL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIL_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(185, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Número:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Enabled = false;
            this.txtDocumento.Location = new System.Drawing.Point(242, 95);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ShortcutsEnabled = false;
            this.txtDocumento.Size = new System.Drawing.Size(98, 20);
            this.txtDocumento.TabIndex = 5;
            this.txtDocumento.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.Enabled = false;
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Location = new System.Drawing.Point(69, 94);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(99, 21);
            this.cbTipoDocumento.TabIndex = 4;
            this.cbTipoDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTipoDocumento_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Fec. Nac:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Enabled = false;
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(69, 363);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaNacimiento.TabIndex = 13;
            this.dtpFechaNacimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaNacimiento_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Sexo:";
            // 
            // cbSexo
            // 
            this.cbSexo.Enabled = false;
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Location = new System.Drawing.Point(69, 325);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(98, 21);
            this.cbSexo.TabIndex = 10;
            this.cbSexo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSexo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Nombres:";
            // 
            // txtNombres
            // 
            this.txtNombres.Enabled = false;
            this.txtNombres.Location = new System.Drawing.Point(242, 59);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(97, 20);
            this.txtNombres.TabIndex = 2;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(69, 59);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(98, 20);
            this.txtApellido.TabIndex = 1;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Legajo:";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Enabled = false;
            this.txtLegajo.Location = new System.Drawing.Point(242, 19);
            this.txtLegajo.Margin = new System.Windows.Forms.Padding(2);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(59, 20);
            this.txtLegajo.TabIndex = 0;
            this.txtLegajo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLegajo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Codigo:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(66, 22);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 12;
            this.lblCodigo.Text = "(Codigo)";
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(212, 551);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(31, 551);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 27;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Tipo Doc.:";
            // 
            // cbFueraDeConvenio
            // 
            this.cbFueraDeConvenio.AutoSize = true;
            this.cbFueraDeConvenio.Enabled = false;
            this.cbFueraDeConvenio.Location = new System.Drawing.Point(436, 403);
            this.cbFueraDeConvenio.Name = "cbFueraDeConvenio";
            this.cbFueraDeConvenio.Size = new System.Drawing.Size(116, 17);
            this.cbFueraDeConvenio.TabIndex = 16;
            this.cbFueraDeConvenio.Text = "Fuera de Convenio";
            this.cbFueraDeConvenio.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(186, 406);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 109;
            this.label25.Text = "Banco:";
            // 
            // cbBancos
            // 
            this.cbBancos.Enabled = false;
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(242, 401);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(182, 21);
            this.cbBancos.TabIndex = 15;
            // 
            // cbSucursales
            // 
            this.cbSucursales.ContextMenuStrip = this.cmsLocalidad;
            this.cbSucursales.Enabled = false;
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(406, 26);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(135, 21);
            this.cbSucursales.TabIndex = 30;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(352, 29);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 13);
            this.label26.TabIndex = 31;
            this.label26.Text = "Sucursal:";
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(564, 588);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.cbBancos);
            this.Controls.Add(this.cbFueraDeConvenio);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cbObraSocial);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtCausa);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dtpEgreso);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dtpIngreso);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbPuestos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nupHijos);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbEstadosCiviles);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCUIL);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.cbTipoDocumento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSexo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLegajo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpleado";
            this.ShowInTaskbar = false;
            this.Text = "frmBase";
            this.Activated += new System.EventHandler(this.frmEmpleado_Activated);
            this.Load += new System.EventHandler(this.frmEmpleado_Load);
            this.cmsPais.ResumeLayout(false);
            this.cmsComunicacion.ResumeLayout(false);
            this.cmsPuesto.ResumeLayout(false);
            this.cmsLocalidad.ResumeLayout(false);
            this.cmsProvincia.ResumeLayout(false);
            this.cmsObraSocial.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComunicaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupHijos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblCodigo;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbPais;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsPais;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtDocumento;
        private txtCUIL txtCUIL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cbEstadosCiviles;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nupHijos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cbPuestos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpIngreso;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtpEgreso;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txtCausa;
        public System.Windows.Forms.ComboBox cbProvincias;
        public System.Windows.Forms.ComboBox cbLocalidades;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.ComboBox cbComunicaciones;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.TextBox txtComunicacion;
        private System.Windows.Forms.DataGridView dgvComunicaciones;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.ComboBox cbObraSocial;
        public System.Windows.Forms.Button btnAgregarComunicacion;
        public System.Windows.Forms.Button btnEliminarComunicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoComunicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRenglon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ContextMenuStrip cmsPuesto;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsProvincia;
        private System.Windows.Forms.ContextMenuStrip cmsLocalidad;
        private System.Windows.Forms.ContextMenuStrip cmsObraSocial;
        private System.Windows.Forms.ContextMenuStrip cmsComunicacion;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem2;
        private System.Windows.Forms.CheckBox cbFueraDeConvenio;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.ComboBox cbBancos;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label label26;
    }
}