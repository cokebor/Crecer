namespace Presentacion
{
    partial class frmUsuario
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
            this.cmsEmpleado = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdGrupo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.cbGruposDeUsuarios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tvPuestosCaja = new System.Windows.Forms.TreeView();
            this.cmsEmpleado.SuspendLayout();
            this.cmdGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsEmpleado
            // 
            this.cmsEmpleado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.cmsEmpleado.Name = "cmsEmpleado";
            this.cmsEmpleado.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // cmdGrupo
            // 
            this.cmdGrupo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem1});
            this.cmdGrupo.Name = "cmdGrupo";
            this.cmdGrupo.Size = new System.Drawing.Size(117, 26);
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
            this.btnConfirmar.Location = new System.Drawing.Point(107, 245);
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
            this.btnCancelar.Location = new System.Drawing.Point(479, 245);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(369, 78);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(189, 20);
            this.txtApellido.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(369, 48);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(189, 20);
            this.txtNombre.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nombre:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(355, 184);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblNombreUsuario.TabIndex = 22;
            this.lblNombreUsuario.Visible = false;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(298, 184);
            this.lblGrupo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(0, 13);
            this.lblGrupo.TabIndex = 21;
            this.lblGrupo.Visible = false;
            // 
            // cbGruposDeUsuarios
            // 
            this.cbGruposDeUsuarios.ContextMenuStrip = this.cmdGrupo;
            this.cbGruposDeUsuarios.Enabled = false;
            this.cbGruposDeUsuarios.FormattingEnabled = true;
            this.cbGruposDeUsuarios.Location = new System.Drawing.Point(369, 107);
            this.cbGruposDeUsuarios.Name = "cbGruposDeUsuarios";
            this.cbGruposDeUsuarios.Size = new System.Drawing.Size(131, 21);
            this.cbGruposDeUsuarios.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Grupo:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(369, 137);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(131, 20);
            this.txtUsuario.TabIndex = 14;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(366, 21);
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
            this.CodigoUsuario,
            this.Empleado,
            this.Grupo,
            this.CodigoGrupo,
            this.Usuario,
            this.Estado,
            this.Nombre,
            this.Apellido});
            this.dgvDatos.Location = new System.Drawing.Point(9, 10);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(267, 197);
            this.dgvDatos.TabIndex = 11;
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // CodigoUsuario
            // 
            this.CodigoUsuario.DataPropertyName = "Codigo";
            this.CodigoUsuario.HeaderText = "CodigoEmpleado";
            this.CodigoUsuario.Name = "CodigoUsuario";
            this.CodigoUsuario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CodigoUsuario.Visible = false;
            // 
            // Empleado
            // 
            this.Empleado.DataPropertyName = "NombreCompleto";
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            // 
            // Grupo
            // 
            this.Grupo.DataPropertyName = "Grupo";
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            // 
            // CodigoGrupo
            // 
            this.CodigoGrupo.DataPropertyName = "CodigoGrupoDeUsuario";
            this.CodigoGrupo.HeaderText = "CodigoGrupo";
            this.CodigoGrupo.Name = "CodigoGrupo";
            this.CodigoGrupo.Visible = false;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.Visible = false;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Visible = false;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(197, 245);
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
            this.btnNuevo.Location = new System.Drawing.Point(16, 245);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Cajas:";
            // 
            // tvPuestosCaja
            // 
            this.tvPuestosCaja.CheckBoxes = true;
            this.tvPuestosCaja.Enabled = false;
            this.tvPuestosCaja.Location = new System.Drawing.Point(369, 171);
            this.tvPuestosCaja.Name = "tvPuestosCaja";
            this.tvPuestosCaja.Size = new System.Drawing.Size(89, 74);
            this.tvPuestosCaja.TabIndex = 28;
            // 
            // frmUsuario
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(575, 277);
            this.Controls.Add(this.tvPuestosCaja);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.cbGruposDeUsuarios);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuario";
            this.ShowInTaskbar = false;
            this.Text = "frmBase";
            this.Activated += new System.EventHandler(this.frmUsuario_Activated);
            this.cmsEmpleado.ResumeLayout(false);
            this.cmdGrupo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtUsuario;
        public System.Windows.Forms.Label lblCodigo;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbGruposDeUsuarios;
        private System.Windows.Forms.ContextMenuStrip cmsEmpleado;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmdGrupo;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem1;
        public System.Windows.Forms.Label lblGrupo;
        public System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView tvPuestosCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
    }
}