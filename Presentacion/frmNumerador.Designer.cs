namespace Presentacion
{
    partial class frmNumerador
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPuntoVenta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Letra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuntoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Numero:";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(480, 197);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(72, 22);
            this.txtNumero.TabIndex = 3;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "Pto de Venta:";
            // 
            // txtPuntoVenta
            // 
            this.txtPuntoVenta.Enabled = false;
            this.txtPuntoVenta.Location = new System.Drawing.Point(480, 151);
            this.txtPuntoVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPuntoVenta.Name = "txtPuntoVenta";
            this.txtPuntoVenta.Size = new System.Drawing.Size(40, 22);
            this.txtPuntoVenta.TabIndex = 2;
            this.txtPuntoVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuntoVenta_KeyPress);
            this.txtPuntoVenta.Leave += new System.EventHandler(this.txtPuntoVenta_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Letra:";
            // 
            // txtLetra
            // 
            this.txtLetra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLetra.Enabled = false;
            this.txtLetra.Location = new System.Drawing.Point(480, 110);
            this.txtLetra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(19, 22);
            this.txtLetra.TabIndex = 1;
            this.txtLetra.TextChanged += new System.EventHandler(this.txtLetra_TextChanged);
            this.txtLetra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLetra_KeyPress);
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(476, 228);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(0, 17);
            this.lblNombreUsuario.TabIndex = 37;
            this.lblNombreUsuario.Visible = false;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(400, 228);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(0, 17);
            this.lblGrupo.TabIndex = 36;
            this.lblGrupo.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Codigo:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(480, 68);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(159, 22);
            this.txtDescripcion.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(473, 27);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(62, 17);
            this.lblCodigo.TabIndex = 28;
            this.lblCodigo.Text = "(Codigo)";
            // 
            // dgvDatos
            // 
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Numerador,
            this.Estado,
            this.Letra,
            this.PuntoVenta,
            this.Numero});
            this.dgvDatos.Location = new System.Drawing.Point(15, 14);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(356, 242);
            this.dgvDatos.TabIndex = 27;
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
            this.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Numerador
            // 
            this.Numerador.DataPropertyName = "Descripcion";
            this.Numerador.HeaderText = "Numerador";
            this.Numerador.Name = "Numerador";
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Letra
            // 
            this.Letra.DataPropertyName = "Letra";
            this.Letra.HeaderText = "Letra";
            this.Letra.Name = "Letra";
            this.Letra.Visible = false;
            // 
            // PuntoVenta
            // 
            this.PuntoVenta.DataPropertyName = "PuntoVenta";
            this.PuntoVenta.HeaderText = "PuntoVenta";
            this.PuntoVenta.Name = "PuntoVenta";
            this.PuntoVenta.Visible = false;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(525, 303);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 32);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(265, 303);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(105, 32);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(145, 303);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(105, 32);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(24, 303);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(105, 32);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmNumerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(649, 348);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPuntoVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNuevo);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmNumerador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblNombreUsuario;
        public System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.Label lblCodigo;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtLetra;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtPuntoVenta;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numerador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Letra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuntoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
    }
}
