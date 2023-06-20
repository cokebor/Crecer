namespace Presentacion
{
    partial class frmCargaSalarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbEmbargos = new System.Windows.Forms.CheckBox();
            this.cbAdelantos = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbTipoSalario = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtNoRem = new System.Windows.Forms.TextBox();
            this.cbNoRemu = new System.Windows.Forms.CheckBox();
            this.lblPorc = new System.Windows.Forms.Label();
            this.txtPorcentajeNoRemunerativo = new System.Windows.Forms.TextBox();
            this.cbNoRemunerativo = new System.Windows.Forms.CheckBox();
            this.cbFaltas = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbVacaciones = new System.Windows.Forms.CheckBox();
            this.cbTodos = new System.Windows.Forms.CheckBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cbPuestos = new System.Windows.Forms.CheckBox();
            this.Seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CodigoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SueldoBasico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasTrabajados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sueldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaltasJustificadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaltasInjustificadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inasistencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Licencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasVacaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRem2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jubilaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ley = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sindi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seguro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adelanto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Embargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlBasico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEmbargos
            // 
            this.cbEmbargos.AutoSize = true;
            this.cbEmbargos.Location = new System.Drawing.Point(648, 40);
            this.cbEmbargos.Name = "cbEmbargos";
            this.cbEmbargos.Size = new System.Drawing.Size(73, 17);
            this.cbEmbargos.TabIndex = 544;
            this.cbEmbargos.Text = "Embargos";
            this.cbEmbargos.UseVisualStyleBackColor = true;
            this.cbEmbargos.CheckedChanged += new System.EventHandler(this.cbEmbargos_CheckedChanged);
            // 
            // cbAdelantos
            // 
            this.cbAdelantos.AutoSize = true;
            this.cbAdelantos.Location = new System.Drawing.Point(569, 40);
            this.cbAdelantos.Name = "cbAdelantos";
            this.cbAdelantos.Size = new System.Drawing.Size(73, 17);
            this.cbAdelantos.TabIndex = 543;
            this.cbAdelantos.Text = "Adelantos";
            this.cbAdelantos.UseVisualStyleBackColor = true;
            this.cbAdelantos.CheckedChanged += new System.EventHandler(this.cbAdelantos_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 542;
            this.label3.Text = "Periodo:";
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Location = new System.Drawing.Point(239, 7);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(116, 21);
            this.cbPeriodo.TabIndex = 541;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(9, 10);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 540;
            this.lblTipo.Text = "Tipo:";
            // 
            // cbTipoSalario
            // 
            this.cbTipoSalario.FormattingEnabled = true;
            this.cbTipoSalario.Location = new System.Drawing.Point(46, 7);
            this.cbTipoSalario.Name = "cbTipoSalario";
            this.cbTipoSalario.Size = new System.Drawing.Size(116, 21);
            this.cbTipoSalario.TabIndex = 539;
            this.cbTipoSalario.SelectedIndexChanged += new System.EventHandler(this.cbTipoSalario_SelectedIndexChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(1022, 562);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 538;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtNoRem
            // 
            this.txtNoRem.Enabled = false;
            this.txtNoRem.Location = new System.Drawing.Point(505, 37);
            this.txtNoRem.Name = "txtNoRem";
            this.txtNoRem.Size = new System.Drawing.Size(58, 20);
            this.txtNoRem.TabIndex = 537;
            this.txtNoRem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoRem.TextChanged += new System.EventHandler(this.txtNoRem_TextChanged);
            this.txtNoRem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoRem_KeyPress);
            // 
            // cbNoRemu
            // 
            this.cbNoRemu.AutoSize = true;
            this.cbNoRemu.Location = new System.Drawing.Point(399, 40);
            this.cbNoRemu.Name = "cbNoRemu";
            this.cbNoRemu.Size = new System.Drawing.Size(109, 17);
            this.cbNoRemu.TabIndex = 536;
            this.cbNoRemu.Text = "No Remunerativo";
            this.cbNoRemu.UseVisualStyleBackColor = true;
            this.cbNoRemu.CheckedChanged += new System.EventHandler(this.cbNoRemu_CheckedChanged);
            // 
            // lblPorc
            // 
            this.lblPorc.AutoSize = true;
            this.lblPorc.Location = new System.Drawing.Point(378, 42);
            this.lblPorc.Name = "lblPorc";
            this.lblPorc.Size = new System.Drawing.Size(15, 13);
            this.lblPorc.TabIndex = 535;
            this.lblPorc.Text = "%";
            // 
            // txtPorcentajeNoRemunerativo
            // 
            this.txtPorcentajeNoRemunerativo.Enabled = false;
            this.txtPorcentajeNoRemunerativo.Location = new System.Drawing.Point(330, 37);
            this.txtPorcentajeNoRemunerativo.Name = "txtPorcentajeNoRemunerativo";
            this.txtPorcentajeNoRemunerativo.Size = new System.Drawing.Size(42, 20);
            this.txtPorcentajeNoRemunerativo.TabIndex = 534;
            this.txtPorcentajeNoRemunerativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcentajeNoRemunerativo.TextChanged += new System.EventHandler(this.txtPorcentajeNoRemunerativo_TextChanged);
            this.txtPorcentajeNoRemunerativo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentajeNoRemunerativo_KeyPress);
            // 
            // cbNoRemunerativo
            // 
            this.cbNoRemunerativo.AutoSize = true;
            this.cbNoRemunerativo.Location = new System.Drawing.Point(224, 40);
            this.cbNoRemunerativo.Name = "cbNoRemunerativo";
            this.cbNoRemunerativo.Size = new System.Drawing.Size(109, 17);
            this.cbNoRemunerativo.TabIndex = 533;
            this.cbNoRemunerativo.Text = "No Remunerativo";
            this.cbNoRemunerativo.UseVisualStyleBackColor = true;
            this.cbNoRemunerativo.CheckedChanged += new System.EventHandler(this.cbNoRemunerativo_CheckedChanged);
            // 
            // cbFaltas
            // 
            this.cbFaltas.AutoSize = true;
            this.cbFaltas.Location = new System.Drawing.Point(76, 40);
            this.cbFaltas.Name = "cbFaltas";
            this.cbFaltas.Size = new System.Drawing.Size(54, 17);
            this.cbFaltas.TabIndex = 532;
            this.cbFaltas.Text = "Faltas";
            this.cbFaltas.UseVisualStyleBackColor = true;
            this.cbFaltas.CheckedChanged += new System.EventHandler(this.cbFaltas_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(951, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 531;
            this.label6.Text = "Fecha :";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(999, 7);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 530;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // cbVacaciones
            // 
            this.cbVacaciones.AutoSize = true;
            this.cbVacaciones.Location = new System.Drawing.Point(136, 40);
            this.cbVacaciones.Name = "cbVacaciones";
            this.cbVacaciones.Size = new System.Drawing.Size(82, 17);
            this.cbVacaciones.TabIndex = 528;
            this.cbVacaciones.Text = "Vacaciones";
            this.cbVacaciones.UseVisualStyleBackColor = true;
            this.cbVacaciones.CheckedChanged += new System.EventHandler(this.cbVacaciones_CheckedChanged);
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Location = new System.Drawing.Point(12, 571);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.Size = new System.Drawing.Size(115, 17);
            this.cbTodos.TabIndex = 527;
            this.cbTodos.Text = "Seleccionar Todos";
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeight = 40;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionado,
            this.CodigoEmpleado,
            this.Empleado,
            this.Puestos,
            this.FechaIngreso,
            this.Anos,
            this.SueldoBasico,
            this.DiasTrabajados,
            this.Sueldo,
            this.FaltasJustificadas,
            this.FaltasInjustificadas,
            this.Inasistencias,
            this.Licencia,
            this.Ant,
            this.Pres,
            this.DiasVacaciones,
            this.Vac,
            this.NoRem,
            this.NoRem2,
            this.Jubilaciones,
            this.Ley,
            this.Obra,
            this.Sindi,
            this.Seguro,
            this.AOS,
            this.Adelanto,
            this.Embargo,
            this.Tot,
            this.ControlBasico});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.SkyBlue;
            this.dgvDatos.Location = new System.Drawing.Point(12, 63);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1088, 497);
            this.dgvDatos.TabIndex = 526;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            this.dgvDatos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDatos_EditingControlShowing);
            // 
            // cbPuestos
            // 
            this.cbPuestos.AutoSize = true;
            this.cbPuestos.Location = new System.Drawing.Point(12, 40);
            this.cbPuestos.Name = "cbPuestos";
            this.cbPuestos.Size = new System.Drawing.Size(64, 17);
            this.cbPuestos.TabIndex = 545;
            this.cbPuestos.Text = "Puestos";
            this.cbPuestos.UseVisualStyleBackColor = true;
            this.cbPuestos.CheckedChanged += new System.EventHandler(this.cbPuestos_CheckedChanged);
            // 
            // Seleccionado
            // 
            this.Seleccionado.HeaderText = "";
            this.Seleccionado.Name = "Seleccionado";
            this.Seleccionado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CodigoEmpleado
            // 
            this.CodigoEmpleado.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.CodigoEmpleado.DefaultCellStyle = dataGridViewCellStyle2;
            this.CodigoEmpleado.HeaderText = "CodigoEmpleado";
            this.CodigoEmpleado.Name = "CodigoEmpleado";
            this.CodigoEmpleado.Visible = false;
            // 
            // Empleado
            // 
            this.Empleado.DataPropertyName = "NombreCompleto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Empleado.DefaultCellStyle = dataGridViewCellStyle3;
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            this.Empleado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Puestos
            // 
            this.Puestos.DataPropertyName = "Puesto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Puestos.DefaultCellStyle = dataGridViewCellStyle4;
            this.Puestos.HeaderText = "Puestos";
            this.Puestos.Name = "Puestos";
            this.Puestos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Puestos.Visible = false;
            // 
            // FechaIngreso
            // 
            dataGridViewCellStyle5.Format = "d";
            this.FechaIngreso.DefaultCellStyle = dataGridViewCellStyle5;
            this.FechaIngreso.HeaderText = "FechaIngreso";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.Visible = false;
            // 
            // Anos
            // 
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.Anos.DefaultCellStyle = dataGridViewCellStyle6;
            this.Anos.HeaderText = "Años";
            this.Anos.Name = "Anos";
            this.Anos.Visible = false;
            // 
            // SueldoBasico
            // 
            this.SueldoBasico.DataPropertyName = "Sueldo";
            this.SueldoBasico.HeaderText = "Basico";
            this.SueldoBasico.Name = "SueldoBasico";
            this.SueldoBasico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DiasTrabajados
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N1";
            dataGridViewCellStyle7.NullValue = null;
            this.DiasTrabajados.DefaultCellStyle = dataGridViewCellStyle7;
            this.DiasTrabajados.HeaderText = "Dias Trab.";
            this.DiasTrabajados.Name = "DiasTrabajados";
            this.DiasTrabajados.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiasTrabajados.Visible = false;
            // 
            // Sueldo
            // 
            this.Sueldo.HeaderText = "Sueldo";
            this.Sueldo.Name = "Sueldo";
            this.Sueldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FaltasJustificadas
            // 
            this.FaltasJustificadas.HeaderText = "Faltas Just.";
            this.FaltasJustificadas.Name = "FaltasJustificadas";
            this.FaltasJustificadas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FaltasJustificadas.Visible = false;
            // 
            // FaltasInjustificadas
            // 
            this.FaltasInjustificadas.HeaderText = "Faltas Injus.";
            this.FaltasInjustificadas.Name = "FaltasInjustificadas";
            this.FaltasInjustificadas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FaltasInjustificadas.Visible = false;
            // 
            // Inasistencias
            // 
            this.Inasistencias.HeaderText = "Inasistencias";
            this.Inasistencias.Name = "Inasistencias";
            // 
            // Licencia
            // 
            this.Licencia.HeaderText = "Licencia";
            this.Licencia.Name = "Licencia";
            // 
            // Ant
            // 
            this.Ant.HeaderText = "Antiguedad";
            this.Ant.Name = "Ant";
            this.Ant.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pres
            // 
            this.Pres.HeaderText = "Presentismo";
            this.Pres.Name = "Pres";
            this.Pres.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DiasVacaciones
            // 
            this.DiasVacaciones.HeaderText = "Dias Vac.";
            this.DiasVacaciones.Name = "DiasVacaciones";
            this.DiasVacaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DiasVacaciones.Visible = false;
            // 
            // Vac
            // 
            this.Vac.HeaderText = "Vacaciones";
            this.Vac.Name = "Vac";
            this.Vac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NoRem
            // 
            this.NoRem.HeaderText = "No Remunerativo";
            this.NoRem.Name = "NoRem";
            this.NoRem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NoRem.Visible = false;
            // 
            // NoRem2
            // 
            this.NoRem2.HeaderText = "No Remunerativo";
            this.NoRem2.Name = "NoRem2";
            this.NoRem2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NoRem2.Visible = false;
            // 
            // Jubilaciones
            // 
            this.Jubilaciones.HeaderText = "Jubilación";
            this.Jubilaciones.Name = "Jubilaciones";
            this.Jubilaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Ley
            // 
            this.Ley.HeaderText = "Ley 19032";
            this.Ley.Name = "Ley";
            this.Ley.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Obra
            // 
            this.Obra.HeaderText = "Obra Social";
            this.Obra.Name = "Obra";
            this.Obra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sindi
            // 
            this.Sindi.HeaderText = "Sindicato";
            this.Sindi.Name = "Sindi";
            this.Sindi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Seguro
            // 
            this.Seguro.HeaderText = "Seguro Sepelio";
            this.Seguro.Name = "Seguro";
            this.Seguro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AOS
            // 
            this.AOS.HeaderText = "Adicional O.S.";
            this.AOS.Name = "AOS";
            // 
            // Adelanto
            // 
            this.Adelanto.HeaderText = "Adelantos";
            this.Adelanto.Name = "Adelanto";
            this.Adelanto.Visible = false;
            // 
            // Embargo
            // 
            this.Embargo.HeaderText = "Embargos";
            this.Embargo.Name = "Embargo";
            this.Embargo.Visible = false;
            // 
            // Tot
            // 
            this.Tot.HeaderText = "Total";
            this.Tot.Name = "Tot";
            this.Tot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ControlBasico
            // 
            this.ControlBasico.HeaderText = "ControlBasico";
            this.ControlBasico.Name = "ControlBasico";
            this.ControlBasico.Visible = false;
            // 
            // frmCargaSalarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1112, 600);
            this.Controls.Add(this.cbPuestos);
            this.Controls.Add(this.cbEmbargos);
            this.Controls.Add(this.cbAdelantos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPeriodo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cbTipoSalario);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtNoRem);
            this.Controls.Add(this.cbNoRemu);
            this.Controls.Add(this.lblPorc);
            this.Controls.Add(this.txtPorcentajeNoRemunerativo);
            this.Controls.Add(this.cbNoRemunerativo);
            this.Controls.Add(this.cbFaltas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cbVacaciones);
            this.Controls.Add(this.cbTodos);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmCargaSalarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargaSalarios_FormClosing);
            this.Load += new System.EventHandler(this.frmCargaSalarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.CheckBox cbTodos;
        private System.Windows.Forms.CheckBox cbVacaciones;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.CheckBox cbFaltas;
        private System.Windows.Forms.CheckBox cbNoRemunerativo;
        private System.Windows.Forms.TextBox txtPorcentajeNoRemunerativo;
        private System.Windows.Forms.Label lblPorc;
        private System.Windows.Forms.TextBox txtNoRem;
        private System.Windows.Forms.CheckBox cbNoRemu;
        public System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblTipo;
        internal System.Windows.Forms.ComboBox cbTipoSalario;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.CheckBox cbAdelantos;
        private System.Windows.Forms.CheckBox cbEmbargos;
        private System.Windows.Forms.CheckBox cbPuestos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SueldoBasico;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasTrabajados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sueldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaltasJustificadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaltasInjustificadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inasistencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Licencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pres;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasVacaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vac;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRem;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jubilaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ley;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sindi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seguro;
        private System.Windows.Forms.DataGridViewTextBoxColumn AOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adelanto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Embargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlBasico;
    }
}
