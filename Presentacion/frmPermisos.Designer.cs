namespace Presentacion
{
    partial class frmPermisos
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.cbGruposDeUsuarios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Menu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(208, 428);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(75, 428);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 31;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // cbGruposDeUsuarios
            // 
            this.cbGruposDeUsuarios.FormattingEnabled = true;
            this.cbGruposDeUsuarios.Location = new System.Drawing.Point(84, 22);
            this.cbGruposDeUsuarios.Name = "cbGruposDeUsuarios";
            this.cbGruposDeUsuarios.Size = new System.Drawing.Size(131, 21);
            this.cbGruposDeUsuarios.TabIndex = 34;
            this.cbGruposDeUsuarios.SelectedIndexChanged += new System.EventHandler(this.cbGruposDeUsuarios_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Grupo:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoGrupo,
            this.CodigoMenu,
            this.Seleccionado,
            this.Menu});
            this.dgvDatos.Location = new System.Drawing.Point(11, 58);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(331, 353);
            this.dgvDatos.TabIndex = 35;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // CodigoGrupo
            // 
            this.CodigoGrupo.HeaderText = "CodigoGrupo";
            this.CodigoGrupo.Name = "CodigoGrupo";
            this.CodigoGrupo.Visible = false;
            // 
            // CodigoMenu
            // 
            this.CodigoMenu.DataPropertyName = "CodigoMenu";
            this.CodigoMenu.HeaderText = "CodigoMenu";
            this.CodigoMenu.Name = "CodigoMenu";
            this.CodigoMenu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CodigoMenu.Visible = false;
            // 
            // Seleccionado
            // 
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            this.Seleccionado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Menu
            // 
            this.Menu.DataPropertyName = "Menu";
            this.Menu.HeaderText = "Menu";
            this.Menu.Name = "Menu";
            this.Menu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 465);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.cbGruposDeUsuarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "frmPermisos";
            this.Text = "frmPermisos";
            this.Load += new System.EventHandler(this.frmPermisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.ComboBox cbGruposDeUsuarios;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMenu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu;
    }
}