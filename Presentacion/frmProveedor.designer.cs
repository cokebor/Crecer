using Controles2;

namespace Presentacion
{
    partial class frmProveedor
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
            this.cmsLocalidad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProvincia = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
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
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cbTipoInscripcion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCUIT = new Controles2.txtCUIT();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIngresosBrutos = new System.Windows.Forms.TextBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nupComision = new System.Windows.Forms.NumericUpDown();
            this.cbContado = new System.Windows.Forms.CheckBox();
            this.gfForma = new System.Windows.Forms.GroupBox();
            this.cbInscriptoEnGanancias = new System.Windows.Forms.CheckBox();
            this.cbRiesgoFiscal = new System.Windows.Forms.CheckBox();
            this.cbTipoContribuyente = new System.Windows.Forms.ComboBox();
            this.lblTipoContribuyente = new System.Windows.Forms.Label();
            this.cmsPais.SuspendLayout();
            this.cmsComunicacion.SuspendLayout();
            this.cmsLocalidad.SuspendLayout();
            this.cmsProvincia.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComunicaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupComision)).BeginInit();
            this.gfForma.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsPais
            // 
            this.cmsPais.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.cmsComunicacion.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsComunicacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem2});
            this.cmsComunicacion.Name = "cmsComunicacion";
            this.cmsComunicacion.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem2
            // 
            this.agregarToolStripMenuItem2.Name = "agregarToolStripMenuItem2";
            this.agregarToolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem2.Text = "Agregar";
            this.agregarToolStripMenuItem2.Click += new System.EventHandler(this.agregarToolStripMenuItem2_Click);
            // 
            // cmsLocalidad
            // 
            this.cmsLocalidad.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.cmsProvincia.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(122, 581);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            this.btnConfirmar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnConfirmar_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(407, 581);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(447, 19);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(5, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 107);
            this.groupBox2.TabIndex = 5;
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
            this.btnEliminarComunicacion.TabIndex = 3;
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
            this.dgvComunicaciones.Size = new System.Drawing.Size(232, 78);
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
            this.label23.Location = new System.Drawing.Point(9, 65);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 13);
            this.label23.TabIndex = 31;
            this.label23.Text = "Dato:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 26);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtNumero);
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
            this.groupBox1.Location = new System.Drawing.Point(5, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 125);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domicilio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(347, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(402, 27);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(98, 20);
            this.txtNumero.TabIndex = 30;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // cbLocalidades
            // 
            this.cbLocalidades.ContextMenuStrip = this.cmsLocalidad;
            this.cbLocalidades.Enabled = false;
            this.cbLocalidades.FormattingEnabled = true;
            this.cbLocalidades.Location = new System.Drawing.Point(296, 90);
            this.cbLocalidades.Name = "cbLocalidades";
            this.cbLocalidades.Size = new System.Drawing.Size(204, 21);
            this.cbLocalidades.TabIndex = 5;
            this.cbLocalidades.SelectedIndexChanged += new System.EventHandler(this.cbLocalidades_SelectedIndexChanged);
            this.cbLocalidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLocalidades_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(234, 93);
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
            this.cbProvincias.Location = new System.Drawing.Point(64, 90);
            this.cbProvincias.Name = "cbProvincias";
            this.cbProvincias.Size = new System.Drawing.Size(151, 21);
            this.cbProvincias.TabIndex = 4;
            this.cbProvincias.SelectedIndexChanged += new System.EventHandler(this.cbProvincias_SelectedIndexChanged);
            this.cbProvincias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbProvincias_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(185, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "C.P.:";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Enabled = false;
            this.txtCodigoPostal.Location = new System.Drawing.Point(237, 58);
            this.txtCodigoPostal.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(96, 20);
            this.txtCodigoPostal.TabIndex = 2;
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Barrio:";
            // 
            // txtBarrio
            // 
            this.txtBarrio.Enabled = false;
            this.txtBarrio.Location = new System.Drawing.Point(64, 58);
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
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Calle:";
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
            this.cbPais.Location = new System.Drawing.Point(402, 57);
            this.cbPais.Name = "cbPais";
            this.cbPais.Size = new System.Drawing.Size(98, 21);
            this.cbPais.TabIndex = 3;
            this.cbPais.SelectedIndexChanged += new System.EventHandler(this.cbPais_SelectedIndexChanged);
            this.cbPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPais_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pais:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Provincia:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "CUIT:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(69, 59);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(219, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
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
            this.btnEliminar.Location = new System.Drawing.Point(212, 581);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(31, 581);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cbTipoInscripcion
            // 
            this.cbTipoInscripcion.Enabled = false;
            this.cbTipoInscripcion.FormattingEnabled = true;
            this.cbTipoInscripcion.Location = new System.Drawing.Point(387, 59);
            this.cbTipoInscripcion.Name = "cbTipoInscripcion";
            this.cbTipoInscripcion.Size = new System.Drawing.Size(121, 21);
            this.cbTipoInscripcion.TabIndex = 1;
            this.cbTipoInscripcion.SelectedIndexChanged += new System.EventHandler(this.cbTipoInscripcion_SelectedIndexChanged);
            this.cbTipoInscripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTipoInscripcion_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Tipo Inscripción:";
            // 
            // txtCUIT
            // 
            this.txtCUIT.AutoSize = true;
            this.txtCUIT.Location = new System.Drawing.Point(69, 94);
            this.txtCUIT.Margin = new System.Windows.Forms.Padding(4);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(102, 23);
            this.txtCUIT.TabIndex = 2;
            this.txtCUIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIT_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Ing. Brutos:";
            // 
            // txtIngresosBrutos
            // 
            this.txtIngresosBrutos.Enabled = false;
            this.txtIngresosBrutos.Location = new System.Drawing.Point(292, 94);
            this.txtIngresosBrutos.Margin = new System.Windows.Forms.Padding(2);
            this.txtIngresosBrutos.Name = "txtIngresosBrutos";
            this.txtIngresosBrutos.Size = new System.Drawing.Size(121, 20);
            this.txtIngresosBrutos.TabIndex = 3;
            this.txtIngresosBrutos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIngresosBrutos_KeyPress);
            // 
            // cbCategoria
            // 
            this.cbCategoria.ContextMenuStrip = this.cmsPais;
            this.cbCategoria.Enabled = false;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(69, 442);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(270, 21);
            this.cbCategoria.TabIndex = 6;
            this.cbCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCategoria_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 445);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Categoria:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Enabled = false;
            this.txtObservaciones.Location = new System.Drawing.Point(69, 508);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(440, 64);
            this.txtObservaciones.TabIndex = 7;
            this.txtObservaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservaciones_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 484);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Observaciones:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 412);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Comisión:";
            // 
            // nupComision
            // 
            this.nupComision.DecimalPlaces = 2;
            this.nupComision.Enabled = false;
            this.nupComision.Location = new System.Drawing.Point(69, 408);
            this.nupComision.Name = "nupComision";
            this.nupComision.Size = new System.Drawing.Size(63, 20);
            this.nupComision.TabIndex = 57;
            this.nupComision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupComision_KeyPress);
            // 
            // cbContado
            // 
            this.cbContado.AutoSize = true;
            this.cbContado.Enabled = false;
            this.cbContado.Location = new System.Drawing.Point(51, 19);
            this.cbContado.Name = "cbContado";
            this.cbContado.Size = new System.Drawing.Size(66, 17);
            this.cbContado.TabIndex = 58;
            this.cbContado.Text = "Contado";
            this.cbContado.UseVisualStyleBackColor = true;
            // 
            // gfForma
            // 
            this.gfForma.Controls.Add(this.cbContado);
            this.gfForma.Location = new System.Drawing.Point(393, 417);
            this.gfForma.Name = "gfForma";
            this.gfForma.Size = new System.Drawing.Size(126, 46);
            this.gfForma.TabIndex = 59;
            this.gfForma.TabStop = false;
            this.gfForma.Text = "Forma de Pago";
            // 
            // cbInscriptoEnGanancias
            // 
            this.cbInscriptoEnGanancias.AutoSize = true;
            this.cbInscriptoEnGanancias.Enabled = false;
            this.cbInscriptoEnGanancias.Location = new System.Drawing.Point(154, 409);
            this.cbInscriptoEnGanancias.Name = "cbInscriptoEnGanancias";
            this.cbInscriptoEnGanancias.Size = new System.Drawing.Size(135, 17);
            this.cbInscriptoEnGanancias.TabIndex = 59;
            this.cbInscriptoEnGanancias.Text = "Inscripto en Ganancias";
            this.cbInscriptoEnGanancias.UseVisualStyleBackColor = true;
            // 
            // cbRiesgoFiscal
            // 
            this.cbRiesgoFiscal.AutoSize = true;
            this.cbRiesgoFiscal.Location = new System.Drawing.Point(307, 127);
            this.cbRiesgoFiscal.Name = "cbRiesgoFiscal";
            this.cbRiesgoFiscal.Size = new System.Drawing.Size(89, 17);
            this.cbRiesgoFiscal.TabIndex = 70;
            this.cbRiesgoFiscal.Text = "Riesgo Fiscal";
            this.cbRiesgoFiscal.UseVisualStyleBackColor = true;
            // 
            // cbTipoContribuyente
            // 
            this.cbTipoContribuyente.FormattingEnabled = true;
            this.cbTipoContribuyente.Location = new System.Drawing.Point(122, 124);
            this.cbTipoContribuyente.Name = "cbTipoContribuyente";
            this.cbTipoContribuyente.Size = new System.Drawing.Size(155, 21);
            this.cbTipoContribuyente.TabIndex = 68;
            // 
            // lblTipoContribuyente
            // 
            this.lblTipoContribuyente.AutoSize = true;
            this.lblTipoContribuyente.Location = new System.Drawing.Point(11, 127);
            this.lblTipoContribuyente.Name = "lblTipoContribuyente";
            this.lblTipoContribuyente.Size = new System.Drawing.Size(114, 13);
            this.lblTipoContribuyente.TabIndex = 69;
            this.lblTipoContribuyente.Text = "Tipo de Contribuyente:";
            // 
            // frmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(524, 612);
            this.Controls.Add(this.cbRiesgoFiscal);
            this.Controls.Add(this.cbTipoContribuyente);
            this.Controls.Add(this.lblTipoContribuyente);
            this.Controls.Add(this.cbInscriptoEnGanancias);
            this.Controls.Add(this.gfForma);
            this.Controls.Add(this.nupComision);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIngresosBrutos);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.cbTipoInscripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProveedor";
            this.ShowInTaskbar = false;
            this.Text = "frmBase";
            this.Activated += new System.EventHandler(this.frmEmpleado_Activated);
            this.Load += new System.EventHandler(this.frmProveedor_Load);
            this.cmsPais.ResumeLayout(false);
            this.cmsComunicacion.ResumeLayout(false);
            this.cmsLocalidad.ResumeLayout(false);
            this.cmsProvincia.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComunicaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupComision)).EndInit();
            this.gfForma.ResumeLayout(false);
            this.gfForma.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtCodigoPostal;
        public System.Windows.Forms.ComboBox cbProvincias;
        public System.Windows.Forms.ComboBox cbLocalidades;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.ComboBox cbComunicaciones;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.TextBox txtComunicacion;
        private System.Windows.Forms.DataGridView dgvComunicaciones;
        public System.Windows.Forms.Button btnAgregarComunicacion;
        public System.Windows.Forms.Button btnEliminarComunicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoComunicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRenglon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ContextMenuStrip cmsProvincia;
        private System.Windows.Forms.ContextMenuStrip cmsLocalidad;
        private System.Windows.Forms.ContextMenuStrip cmsComunicacion;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem2;
        public System.Windows.Forms.ComboBox cbTipoInscripcion;
        private System.Windows.Forms.Label label4;
        private txtCUIT txtCUIT;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtIngresosBrutos;
        public System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nupComision;
        private System.Windows.Forms.CheckBox cbContado;
        private System.Windows.Forms.GroupBox gfForma;
        private System.Windows.Forms.CheckBox cbInscriptoEnGanancias;
        private System.Windows.Forms.CheckBox cbRiesgoFiscal;
        public System.Windows.Forms.ComboBox cbTipoContribuyente;
        private System.Windows.Forms.Label lblTipoContribuyente;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtNumero;
    }
}