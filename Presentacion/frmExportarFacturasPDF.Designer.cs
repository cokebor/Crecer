namespace Presentacion
{
    partial class frmExportarFacturasPDF
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
            this.rbUnicoArchivo = new System.Windows.Forms.RadioButton();
            this.rbArchivoPorComprobante = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbTriplicado = new System.Windows.Forms.CheckBox();
            this.cbSeleccionTodos = new System.Windows.Forms.CheckBox();
            this.cbDuplicado = new System.Windows.Forms.CheckBox();
            this.cbOriginal = new System.Windows.Forms.CheckBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtCodigoLote = new System.Windows.Forms.TextBox();
            this.lblNombreLote = new System.Windows.Forms.Label();
            this.cbLotes = new System.Windows.Forms.CheckBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.cbClientes = new System.Windows.Forms.CheckBox();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.cbFechas = new System.Windows.Forms.CheckBox();
            this.pnFecha = new System.Windows.Forms.Panel();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lvComprobantes = new System.Windows.Forms.ListView();
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmail = new System.Windows.Forms.ComboBox();
            this.pnFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbUnicoArchivo
            // 
            this.rbUnicoArchivo.AutoSize = true;
            this.rbUnicoArchivo.Location = new System.Drawing.Point(187, 146);
            this.rbUnicoArchivo.Name = "rbUnicoArchivo";
            this.rbUnicoArchivo.Size = new System.Drawing.Size(92, 17);
            this.rbUnicoArchivo.TabIndex = 539;
            this.rbUnicoArchivo.Text = "Unico Archivo";
            this.rbUnicoArchivo.UseVisualStyleBackColor = true;
            // 
            // rbArchivoPorComprobante
            // 
            this.rbArchivoPorComprobante.AutoSize = true;
            this.rbArchivoPorComprobante.Checked = true;
            this.rbArchivoPorComprobante.Location = new System.Drawing.Point(20, 146);
            this.rbArchivoPorComprobante.Name = "rbArchivoPorComprobante";
            this.rbArchivoPorComprobante.Size = new System.Drawing.Size(161, 17);
            this.rbArchivoPorComprobante.TabIndex = 538;
            this.rbArchivoPorComprobante.TabStop = true;
            this.rbArchivoPorComprobante.Text = "Un archivo por Comprobante";
            this.rbArchivoPorComprobante.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(421, 100);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 537;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbTriplicado
            // 
            this.cbTriplicado.AutoSize = true;
            this.cbTriplicado.Location = new System.Drawing.Point(310, 109);
            this.cbTriplicado.Name = "cbTriplicado";
            this.cbTriplicado.Size = new System.Drawing.Size(72, 17);
            this.cbTriplicado.TabIndex = 2;
            this.cbTriplicado.Text = "Triplicado";
            this.cbTriplicado.UseVisualStyleBackColor = true;
            // 
            // cbSeleccionTodos
            // 
            this.cbSeleccionTodos.AutoSize = true;
            this.cbSeleccionTodos.Location = new System.Drawing.Point(20, 109);
            this.cbSeleccionTodos.Name = "cbSeleccionTodos";
            this.cbSeleccionTodos.Size = new System.Drawing.Size(115, 17);
            this.cbSeleccionTodos.TabIndex = 536;
            this.cbSeleccionTodos.Text = "Seleccionar Todos";
            this.cbSeleccionTodos.UseVisualStyleBackColor = true;
            // 
            // cbDuplicado
            // 
            this.cbDuplicado.AutoSize = true;
            this.cbDuplicado.Location = new System.Drawing.Point(231, 109);
            this.cbDuplicado.Name = "cbDuplicado";
            this.cbDuplicado.Size = new System.Drawing.Size(74, 17);
            this.cbDuplicado.TabIndex = 1;
            this.cbDuplicado.Text = "Duplicado";
            this.cbDuplicado.UseVisualStyleBackColor = true;
            // 
            // cbOriginal
            // 
            this.cbOriginal.AutoSize = true;
            this.cbOriginal.Checked = true;
            this.cbOriginal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOriginal.Location = new System.Drawing.Point(164, 109);
            this.cbOriginal.Name = "cbOriginal";
            this.cbOriginal.Size = new System.Drawing.Size(61, 17);
            this.cbOriginal.TabIndex = 0;
            this.cbOriginal.Text = "Original";
            this.cbOriginal.UseVisualStyleBackColor = true;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Enabled = false;
            this.lblLote.Location = new System.Drawing.Point(142, 78);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(31, 13);
            this.lblLote.TabIndex = 534;
            this.lblLote.Text = "Lote:";
            // 
            // txtCodigoLote
            // 
            this.txtCodigoLote.Enabled = false;
            this.txtCodigoLote.Location = new System.Drawing.Point(220, 74);
            this.txtCodigoLote.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoLote.Name = "txtCodigoLote";
            this.txtCodigoLote.ShortcutsEnabled = false;
            this.txtCodigoLote.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoLote.TabIndex = 532;
            this.txtCodigoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoLote.TextChanged += new System.EventHandler(this.txtCodigoLote_TextChanged);
            this.txtCodigoLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoLote_KeyDown);
            this.txtCodigoLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoLote_KeyPress);
            // 
            // lblNombreLote
            // 
            this.lblNombreLote.AutoSize = true;
            this.lblNombreLote.Enabled = false;
            this.lblNombreLote.Location = new System.Drawing.Point(265, 78);
            this.lblNombreLote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreLote.Name = "lblNombreLote";
            this.lblNombreLote.Size = new System.Drawing.Size(0, 13);
            this.lblNombreLote.TabIndex = 533;
            // 
            // cbLotes
            // 
            this.cbLotes.AutoSize = true;
            this.cbLotes.Checked = true;
            this.cbLotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLotes.Location = new System.Drawing.Point(20, 76);
            this.cbLotes.Name = "cbLotes";
            this.cbLotes.Size = new System.Drawing.Size(101, 17);
            this.cbLotes.TabIndex = 531;
            this.cbLotes.Text = "Todos los Lotes";
            this.cbLotes.UseVisualStyleBackColor = true;
            this.cbLotes.CheckedChanged += new System.EventHandler(this.cbLotes_CheckedChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Enabled = false;
            this.lblCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCliente.Location = new System.Drawing.Point(142, 49);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(66, 13);
            this.lblCliente.TabIndex = 530;
            this.lblCliente.Text = "Cliente (F2) :";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Location = new System.Drawing.Point(220, 45);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.ShortcutsEnabled = false;
            this.txtCodigoCliente.Size = new System.Drawing.Size(39, 20);
            this.txtCodigoCliente.TabIndex = 528;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Enabled = false;
            this.lblNombreCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreCliente.Location = new System.Drawing.Point(265, 49);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 529;
            // 
            // cbClientes
            // 
            this.cbClientes.AutoSize = true;
            this.cbClientes.Checked = true;
            this.cbClientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClientes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbClientes.Location = new System.Drawing.Point(20, 47);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(112, 17);
            this.cbClientes.TabIndex = 527;
            this.cbClientes.Text = "Todos los Clientes";
            this.cbClientes.UseVisualStyleBackColor = true;
            this.cbClientes.CheckedChanged += new System.EventHandler(this.cbClientes_CheckedChanged);
            // 
            // lblSucursales
            // 
            this.lblSucursales.AutoSize = true;
            this.lblSucursales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSucursales.Location = new System.Drawing.Point(333, 18);
            this.lblSucursales.Name = "lblSucursales";
            this.lblSucursales.Size = new System.Drawing.Size(51, 13);
            this.lblSucursales.TabIndex = 526;
            this.lblSucursales.Text = "Sucursal:";
            this.lblSucursales.Visible = false;
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(389, 15);
            this.cbSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(94, 21);
            this.cbSucursales.TabIndex = 525;
            this.cbSucursales.Visible = false;
            // 
            // cbFechas
            // 
            this.cbFechas.AutoSize = true;
            this.cbFechas.Location = new System.Drawing.Point(20, 19);
            this.cbFechas.Name = "cbFechas";
            this.cbFechas.Size = new System.Drawing.Size(15, 14);
            this.cbFechas.TabIndex = 3;
            this.cbFechas.UseVisualStyleBackColor = true;
            this.cbFechas.CheckedChanged += new System.EventHandler(this.cbFechas_CheckedChanged);
            // 
            // pnFecha
            // 
            this.pnFecha.Controls.Add(this.dtHasta);
            this.pnFecha.Controls.Add(this.dtDesde);
            this.pnFecha.Controls.Add(this.label3);
            this.pnFecha.Controls.Add(this.label4);
            this.pnFecha.Enabled = false;
            this.pnFecha.Location = new System.Drawing.Point(35, 12);
            this.pnFecha.Name = "pnFecha";
            this.pnFecha.Size = new System.Drawing.Size(280, 25);
            this.pnFecha.TabIndex = 2;
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(195, 4);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(83, 20);
            this.dtHasta.TabIndex = 541;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(52, 4);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(87, 20);
            this.dtDesde.TabIndex = 540;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 539;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 538;
            this.label4.Text = "Desde:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 541;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvComprobantes
            // 
            this.lvComprobantes.CheckBoxes = true;
            this.lvComprobantes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Fecha,
            this.columnHeader2,
            this.columnHeader3});
            this.lvComprobantes.FullRowSelect = true;
            this.lvComprobantes.Location = new System.Drawing.Point(20, 174);
            this.lvComprobantes.Name = "lvComprobantes";
            this.lvComprobantes.Size = new System.Drawing.Size(453, 187);
            this.lvComprobantes.TabIndex = 542;
            this.lvComprobantes.UseCompatibleStateImageBehavior = false;
            this.lvComprobantes.View = System.Windows.Forms.View.Details;
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            this.Fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;// global::Presentacion.Properties.Settings.Default.df;
            this.Fecha.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(290, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 544;
            this.label1.Text = "Email:";
            // 
            // cbEmail
            // 
            this.cbEmail.FormattingEnabled = true;
            this.cbEmail.Location = new System.Drawing.Point(330, 145);
            this.cbEmail.Margin = new System.Windows.Forms.Padding(2);
            this.cbEmail.Name = "cbEmail";
            this.cbEmail.Size = new System.Drawing.Size(153, 21);
            this.cbEmail.TabIndex = 543;
            // 
            // frmExportarFacturasPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(501, 424);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEmail);
            this.Controls.Add(this.lvComprobantes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbUnicoArchivo);
            this.Controls.Add(this.rbArchivoPorComprobante);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbTriplicado);
            this.Controls.Add(this.cbSeleccionTodos);
            this.Controls.Add(this.cbDuplicado);
            this.Controls.Add(this.cbOriginal);
            this.Controls.Add(this.lblLote);
            this.Controls.Add(this.txtCodigoLote);
            this.Controls.Add(this.lblNombreLote);
            this.Controls.Add(this.cbLotes);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.cbFechas);
            this.Controls.Add(this.pnFecha);
            this.Name = "frmExportarFacturasPDF";
            this.Load += new System.EventHandler(this.frmExportarFacturasPDF_Load);
            this.pnFecha.ResumeLayout(false);
            this.pnFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnFecha;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbFechas;
        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.CheckBox cbClientes;
        private System.Windows.Forms.Label lblLote;
        public System.Windows.Forms.TextBox txtCodigoLote;
        public System.Windows.Forms.Label lblNombreLote;
        private System.Windows.Forms.CheckBox cbLotes;
        private System.Windows.Forms.CheckBox cbTriplicado;
        private System.Windows.Forms.CheckBox cbDuplicado;
        private System.Windows.Forms.CheckBox cbOriginal;
        private System.Windows.Forms.CheckBox cbSeleccionTodos;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.RadioButton rbArchivoPorComprobante;
        private System.Windows.Forms.RadioButton rbUnicoArchivo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvComprobantes;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbEmail;
    }
}
