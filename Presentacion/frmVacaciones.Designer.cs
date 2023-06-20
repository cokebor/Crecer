
namespace Presentacion
{
    partial class frmVacaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.txtCodigoEmpleado = new System.Windows.Forms.TextBox();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDiasCorresponden = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancelar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblDiasPendientes = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Location = new System.Drawing.Point(551, 11);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(87, 21);
            this.cbPeriodo.TabIndex = 0;
            this.cbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cbPeriodo_SelectedIndexChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 406;
            this.label1.Text = "Periodo:";
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(237, 45);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(106, 20);
            this.dtHasta.TabIndex = 410;
            this.dtHasta.ValueChanged += new System.EventHandler(this.dtHasta_ValueChanged);
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
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 408;
            this.label2.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(13, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 407;
            this.label4.Text = "Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(359, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 411;
            this.label5.Text = "Dias Corresponden:";
            // 
            // lblDiasCorresponden
            // 
            this.lblDiasCorresponden.AutoSize = true;
            this.lblDiasCorresponden.Location = new System.Drawing.Point(460, 48);
            this.lblDiasCorresponden.Name = "lblDiasCorresponden";
            this.lblDiasCorresponden.Size = new System.Drawing.Size(0, 13);
            this.lblDiasCorresponden.TabIndex = 412;
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoEmpleado,
            this.Legajo,
            this.Empleado,
            this.Periodo,
            this.Desde,
            this.Hasta,
            this.Dias,
            this.DiasPendientes,
            this.Cancelar});
            this.dgvDatos.Location = new System.Drawing.Point(12, 80);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(628, 197);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Legajo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            // 
            // Empleado
            // 
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            // 
            // Periodo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Periodo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Periodo.HeaderText = "Periodo";
            this.Periodo.Name = "Periodo";
            // 
            // Desde
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Desde.DefaultCellStyle = dataGridViewCellStyle3;
            this.Desde.HeaderText = "Desde";
            this.Desde.Name = "Desde";
            // 
            // Hasta
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            this.Hasta.DefaultCellStyle = dataGridViewCellStyle4;
            this.Hasta.HeaderText = "Hasta";
            this.Hasta.Name = "Hasta";
            // 
            // Dias
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Dias.DefaultCellStyle = dataGridViewCellStyle5;
            this.Dias.HeaderText = "Dias ";
            this.Dias.Name = "Dias";
            // 
            // DiasPendientes
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DiasPendientes.DefaultCellStyle = dataGridViewCellStyle6;
            this.DiasPendientes.HeaderText = "Dias Pendientes";
            this.DiasPendientes.Name = "DiasPendientes";
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
            this.btnCancelar.Location = new System.Drawing.Point(562, 286);
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
            this.btnConfirmar.Location = new System.Drawing.Point(467, 286);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 415;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblDiasPendientes
            // 
            this.lblDiasPendientes.AutoSize = true;
            this.lblDiasPendientes.Location = new System.Drawing.Point(580, 48);
            this.lblDiasPendientes.Name = "lblDiasPendientes";
            this.lblDiasPendientes.Size = new System.Drawing.Size(0, 13);
            this.lblDiasPendientes.TabIndex = 418;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(491, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 417;
            this.label7.Text = "Dias Pendientes:";
            // 
            // frmVacaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(652, 321);
            this.Controls.Add(this.lblDiasPendientes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.lblDiasCorresponden);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoEmpleado);
            this.Controls.Add(this.lblNombreEmpleado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPeriodo);
            this.Name = "frmVacaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPeriodo;
        public System.Windows.Forms.TextBox txtCodigoEmpleado;
        public System.Windows.Forms.Label lblNombreEmpleado;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDiasCorresponden;
        private System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasPendientes;
        private System.Windows.Forms.DataGridViewLinkColumn Cancelar;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblDiasPendientes;
        private System.Windows.Forms.Label label7;
    }
}
