namespace Presentacion
{
    partial class frmLocalidad
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
            this.cmsProvincia = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbProvincias = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPais = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cmsPais.SuspendLayout();
            this.cmsProvincia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsPais
            // 
            this.cmsPais.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.cmsPais.Name = "cmsPais";
            this.cmsPais.Size = new System.Drawing.Size(117, 26);
            this.cmsPais.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPais_Opening);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // cmsProvincia
            // 
            this.cmsProvincia.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem1});
            this.cmsProvincia.Name = "cmsProvincia";
            this.cmsProvincia.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem1
            // 
            this.agregarToolStripMenuItem1.Name = "agregarToolStripMenuItem1";
            this.agregarToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem1.Text = "Agregar";
            this.agregarToolStripMenuItem1.Click += new System.EventHandler(this.agregarToolStripMenuItem1_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(107, 234);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(392, 234);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbProvincias
            // 
            this.cbProvincias.ContextMenuStrip = this.cmsProvincia;
            this.cbProvincias.FormattingEnabled = true;
            this.cbProvincias.Location = new System.Drawing.Point(347, 91);
            this.cbProvincias.Name = "cbProvincias";
            this.cbProvincias.Size = new System.Drawing.Size(131, 21);
            this.cbProvincias.TabIndex = 20;
            this.cbProvincias.SelectedIndexChanged += new System.EventHandler(this.cbProvincias_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Localidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Provincia:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pais:";
            // 
            // cbPais
            // 
            this.cbPais.ContextMenuStrip = this.cmsPais;
            this.cbPais.FormattingEnabled = true;
            this.cbPais.Location = new System.Drawing.Point(347, 52);
            this.cbPais.Name = "cbPais";
            this.cbPais.Size = new System.Drawing.Size(131, 21);
            this.cbPais.TabIndex = 13;
            this.cbPais.SelectedIndexChanged += new System.EventHandler(this.cbPais_SelectedIndexChanged_1);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(347, 128);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(131, 20);
            this.txtDescripcion.TabIndex = 14;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(343, 21);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 12;
            this.lblCodigo.Text = "(Codigo)";
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripción,
            this.CodigoPais,
            this.CodigoProvincia,
            this.Estado});
            this.dgvDatos.Location = new System.Drawing.Point(9, 10);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(267, 197);
            this.dgvDatos.TabIndex = 11;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Descripción
            // 
            this.Descripción.DataPropertyName = "Localidad";
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.Name = "Descripción";
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
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(197, 234);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(16, 234);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmLocalidad
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(493, 269);
            this.Controls.Add(this.cbProvincias);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPais);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocalidad";
            this.ShowInTaskbar = false;
            this.Text = "frmBase";
            this.Activated += new System.EventHandler(this.frmLocalidad_Activated);
            this.Load += new System.EventHandler(this.frmLocalidad_Load);
            this.cmsPais.ResumeLayout(false);
            this.cmsProvincia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.Label lblCodigo;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbPais;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbProvincias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProvincia;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.ContextMenuStrip cmsPais;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsProvincia;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem1;
    }
}