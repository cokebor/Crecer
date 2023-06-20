
namespace Presentacion
{
    partial class frmLicencias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCodigoEmpleado = new System.Windows.Forms.TextBox();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesdeL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HastaL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoLicencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Licencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancelar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.cbTiposLicencias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblArchivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigoEmpleado
            // 
            this.txtCodigoEmpleado.Location = new System.Drawing.Point(92, 11);
            this.txtCodigoEmpleado.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoEmpleado.Name = "txtCodigoEmpleado";
            this.txtCodigoEmpleado.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoEmpleado.TabIndex = 403;
            this.txtCodigoEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoEmpleado.TextChanged += new System.EventHandler(this.txtCodigoEmpleado_TextChanged);
            this.txtCodigoEmpleado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoEmpleado_KeyDown);
            this.txtCodigoEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoEmpleado_KeyPress);
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.AutoSize = true;
            this.lblNombreEmpleado.Location = new System.Drawing.Point(129, 16);
            this.lblNombreEmpleado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(0, 13);
            this.lblNombreEmpleado.TabIndex = 405;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 404;
            this.label3.Text = "Empleado (F1):";
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(234, 45);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 410;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(57, 45);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 20);
            this.dtDesde.TabIndex = 409;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(192, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 408;
            this.label2.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(13, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 407;
            this.label4.Text = "Desde:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoEmpleado,
            this.Legajo,
            this.Empleado,
            this.DesdeL,
            this.HastaL,
            this.Dias,
            this.CodigoTipoLicencia,
            this.Licencia,
            this.Archivo,
            this.Observaciones,
            this.Cancelar});
            this.dgvDatos.Location = new System.Drawing.Point(12, 111);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(674, 197);
            this.dgvDatos.TabIndex = 413;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // CodigoEmpleado
            // 
            this.CodigoEmpleado.HeaderText = "CodigoEmpleado";
            this.CodigoEmpleado.Name = "CodigoEmpleado";
            this.CodigoEmpleado.Visible = false;
            // 
            // Legajo
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Legajo.DefaultCellStyle = dataGridViewCellStyle5;
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            // 
            // Empleado
            // 
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            // 
            // DesdeL
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.DesdeL.DefaultCellStyle = dataGridViewCellStyle6;
            this.DesdeL.HeaderText = "Desde";
            this.DesdeL.Name = "DesdeL";
            // 
            // HastaL
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "d";
            this.HastaL.DefaultCellStyle = dataGridViewCellStyle7;
            this.HastaL.HeaderText = "Hasta";
            this.HastaL.Name = "HastaL";
            // 
            // Dias
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Dias.DefaultCellStyle = dataGridViewCellStyle8;
            this.Dias.HeaderText = "Dias ";
            this.Dias.Name = "Dias";
            // 
            // CodigoTipoLicencia
            // 
            this.CodigoTipoLicencia.HeaderText = "CodigoTipoLicencia";
            this.CodigoTipoLicencia.Name = "CodigoTipoLicencia";
            this.CodigoTipoLicencia.Visible = false;
            // 
            // Licencia
            // 
            this.Licencia.HeaderText = "Licencia";
            this.Licencia.Name = "Licencia";
            // 
            // Archivo
            // 
            this.Archivo.HeaderText = "Archivo";
            this.Archivo.Name = "Archivo";
            // 
            // Observaciones
            // 
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Visible = false;
            // 
            // Cancelar
            // 
            this.Cancelar.HeaderText = "";
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseColumnTextForLinkValue = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.CausesValidation = false;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(614, 42);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 26);
            this.btnAgregar.TabIndex = 414;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(607, 313);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 416;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(512, 313);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 415;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // cbTiposLicencias
            // 
            this.cbTiposLicencias.FormattingEnabled = true;
            this.cbTiposLicencias.Location = new System.Drawing.Point(467, 44);
            this.cbTiposLicencias.Name = "cbTiposLicencias";
            this.cbTiposLicencias.Size = new System.Drawing.Size(121, 21);
            this.cbTiposLicencias.TabIndex = 417;
            this.cbTiposLicencias.SelectedIndexChanged += new System.EventHandler(this.cbTiposLicencias_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(376, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 418;
            this.label1.Text = "Tipo de Licencia:";
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.BackgroundImage = global::Presentacion.Properties.Resources.pngwing_com;
            this.btnAdjuntar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdjuntar.CausesValidation = false;
            this.btnAdjuntar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjuntar.Location = new System.Drawing.Point(498, 78);
            this.btnAdjuntar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(25, 26);
            this.btnAdjuntar.TabIndex = 419;
            this.btnAdjuntar.UseVisualStyleBackColor = true;
            this.btnAdjuntar.Visible = false;
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(92, 81);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(391, 21);
            this.txtObservaciones.TabIndex = 544;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 545;
            this.label8.Text = "Observaciones:";
            // 
            // lblArchivo
            // 
            this.lblArchivo.Location = new System.Drawing.Point(528, 84);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(111, 18);
            this.lblArchivo.TabIndex = 546;
            // 
            // frmLicencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(698, 350);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAdjuntar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTiposLicencias);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodigoEmpleado);
            this.Controls.Add(this.lblNombreEmpleado);
            this.Controls.Add(this.label3);
            this.Name = "frmLicencias";
            this.Load += new System.EventHandler(this.frmLicencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtCodigoEmpleado;
        public System.Windows.Forms.Label lblNombreEmpleado;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ComboBox cbTiposLicencias;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnAdjuntar;
        private System.Windows.Forms.OpenFileDialog ofd;
        public System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesdeL;
        private System.Windows.Forms.DataGridViewTextBoxColumn HastaL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoLicencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Licencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Archivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewLinkColumn Cancelar;
    }
}
