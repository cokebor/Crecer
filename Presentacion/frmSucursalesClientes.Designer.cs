namespace Presentacion
{
    partial class frmSucursalesClientes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLocalidades = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barrio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoLocalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbLocalidades);
            this.groupBox1.Controls.Add(this.txtNumero);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 119);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domicilio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(348, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Número:";
            // 
            // cbLocalidades
            // 
            this.cbLocalidades.Enabled = false;
            this.cbLocalidades.FormattingEnabled = true;
            this.cbLocalidades.Location = new System.Drawing.Point(272, 89);
            this.cbLocalidades.Name = "cbLocalidades";
            this.cbLocalidades.Size = new System.Drawing.Size(232, 21);
            this.cbLocalidades.TabIndex = 5;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(399, 27);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(105, 20);
            this.txtNumero.TabIndex = 68;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(218, 94);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "Localidad:";
            // 
            // cbProvincias
            // 
            this.cbProvincias.Enabled = false;
            this.cbProvincias.FormattingEnabled = true;
            this.cbProvincias.Location = new System.Drawing.Point(64, 89);
            this.cbProvincias.Name = "cbProvincias";
            this.cbProvincias.Size = new System.Drawing.Size(132, 21);
            this.cbProvincias.TabIndex = 4;
            this.cbProvincias.SelectedIndexChanged += new System.EventHandler(this.cbProvincias_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(185, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "C.P.:";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Enabled = false;
            this.txtCodigoPostal.Location = new System.Drawing.Point(237, 57);
            this.txtCodigoPostal.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(96, 20);
            this.txtCodigoPostal.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Barrio:";
            // 
            // txtBarrio
            // 
            this.txtBarrio.Enabled = false;
            this.txtBarrio.Location = new System.Drawing.Point(64, 57);
            this.txtBarrio.Margin = new System.Windows.Forms.Padding(2);
            this.txtBarrio.Name = "txtBarrio";
            this.txtBarrio.Size = new System.Drawing.Size(98, 20);
            this.txtBarrio.TabIndex = 1;
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
            // 
            // cbPais
            // 
            this.cbPais.Enabled = false;
            this.cbPais.FormattingEnabled = true;
            this.cbPais.Location = new System.Drawing.Point(399, 56);
            this.cbPais.Name = "cbPais";
            this.cbPais.Size = new System.Drawing.Size(105, 21);
            this.cbPais.TabIndex = 3;
            this.cbPais.SelectedIndexChanged += new System.EventHandler(this.cbPais_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pais:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Provincia:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoSucursal,
            this.NombreSucursal,
            this.Domicilio,
            this.Direccion,
            this.Numero,
            this.Barrio,
            this.CodigoPostal,
            this.CodigoPais,
            this.CodigoProvincia,
            this.CodigoLocalidad});
            this.dgvDatos.Location = new System.Drawing.Point(11, 11);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(517, 197);
            this.dgvDatos.TabIndex = 12;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // CodigoSucursal
            // 
            this.CodigoSucursal.DataPropertyName = "CodigoSucursal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CodigoSucursal.DefaultCellStyle = dataGridViewCellStyle1;
            this.CodigoSucursal.HeaderText = "CodigoSucursal";
            this.CodigoSucursal.Name = "CodigoSucursal";
            this.CodigoSucursal.Visible = false;
            // 
            // NombreSucursal
            // 
            this.NombreSucursal.DataPropertyName = "NombreSucursal";
            this.NombreSucursal.HeaderText = "Sucursal";
            this.NombreSucursal.Name = "NombreSucursal";
            // 
            // Domicilio
            // 
            this.Domicilio.DataPropertyName = "Domicilio";
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.Name = "Domicilio";
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.Visible = false;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.Visible = false;
            // 
            // Barrio
            // 
            this.Barrio.DataPropertyName = "Barrio";
            this.Barrio.HeaderText = "Barrio";
            this.Barrio.Name = "Barrio";
            this.Barrio.Visible = false;
            // 
            // CodigoPostal
            // 
            this.CodigoPostal.DataPropertyName = "CodigoPostal";
            this.CodigoPostal.HeaderText = "CodigoPostal";
            this.CodigoPostal.Name = "CodigoPostal";
            this.CodigoPostal.Visible = false;
            // 
            // CodigoPais
            // 
            this.CodigoPais.DataPropertyName = "CodigoPais";
            this.CodigoPais.HeaderText = "CodigoPais";
            this.CodigoPais.Name = "CodigoPais";
            this.CodigoPais.Visible = false;
            // 
            // CodigoProvincia
            // 
            this.CodigoProvincia.DataPropertyName = "CodigoProvincia";
            this.CodigoProvincia.HeaderText = "CodigoProvincia";
            this.CodigoProvincia.Name = "CodigoProvincia";
            this.CodigoProvincia.Visible = false;
            // 
            // CodigoLocalidad
            // 
            this.CodigoLocalidad.DataPropertyName = "CodigoLocalidad";
            this.CodigoLocalidad.HeaderText = "CodigoLocalidad";
            this.CodigoLocalidad.Name = "CodigoLocalidad";
            this.CodigoLocalidad.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Codigo:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(88, 226);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 34;
            this.lblCodigo.Text = "(Codigo)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Sucursal:";
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.Enabled = false;
            this.txtNombreSucursal.Location = new System.Drawing.Point(239, 223);
            this.txtNombreSucursal.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.Size = new System.Drawing.Size(221, 20);
            this.txtNombreSucursal.TabIndex = 36;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(449, 375);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(104, 375);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 39;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(13, 375);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 38;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmSucursalesClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(535, 406);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombreSucursal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSucursalesClientes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cbLocalidades;
        public System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.ComboBox cbProvincias;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtDireccion;
        public System.Windows.Forms.ComboBox cbPais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barrio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProvincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoLocalidad;
    }
}
