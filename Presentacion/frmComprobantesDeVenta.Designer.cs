namespace Presentacion
{
    partial class frmComprobantesDeVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComprobantesDeVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.CodigoSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoTipoDocumentoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.cbClientes = new System.Windows.Forms.CheckBox();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbTriplicado = new System.Windows.Forms.RadioButton();
            this.rbDuplicado = new System.Windows.Forms.RadioButton();
            this.rbOriginal = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            resources.ApplyResources(this.btnExportar, "btnExportar");
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // lblTotal
            // 
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Name = "lblTotal";
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            resources.ApplyResources(this.btnBuscar, "btnBuscar");
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoSucursal,
            this.Codigo,
            this.CodigoTipoDocumentoCliente,
            this.Tipo,
            this.Fecha,
            this.TipoDocumento,
            this.Numero,
            this.FormaPago,
            this.Cliente,
            this.Total,
            this.Total2});
            resources.ApplyResources(this.dgvDatos, "dgvDatos");
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // CodigoSucursal
            // 
            this.CodigoSucursal.DataPropertyName = "CodigoSucursal";
            resources.ApplyResources(this.CodigoSucursal, "CodigoSucursal");
            this.CodigoSucursal.Name = "CodigoSucursal";
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.Codigo, "Codigo");
            this.Codigo.Name = "Codigo";
            // 
            // CodigoTipoDocumentoCliente
            // 
            this.CodigoTipoDocumentoCliente.DataPropertyName = "CodigoTipoDocumentoCliente";
            resources.ApplyResources(this.CodigoTipoDocumentoCliente, "CodigoTipoDocumentoCliente");
            this.CodigoTipoDocumentoCliente.Name = "CodigoTipoDocumentoCliente";
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tipo.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.Tipo, "Tipo");
            this.Tipo.Name = "Tipo";
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.Fecha, "Fecha");
            this.Fecha.Name = "Fecha";
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.DataPropertyName = "TipoDocumento";
            resources.ApplyResources(this.TipoDocumento, "TipoDocumento");
            this.TipoDocumento.Name = "TipoDocumento";
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.Numero, "Numero");
            this.Numero.Name = "Numero";
            // 
            // FormaPago
            // 
            this.FormaPago.DataPropertyName = "FormaPago";
            resources.ApplyResources(this.FormaPago, "FormaPago");
            this.FormaPago.Name = "FormaPago";
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            resources.ApplyResources(this.Cliente, "Cliente");
            this.Cliente.Name = "Cliente";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = "0";
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.Total, "Total");
            this.Total.Name = "Total";
            // 
            // Total2
            // 
            this.Total2.DataPropertyName = "Total";
            resources.ApplyResources(this.Total2, "Total2");
            this.Total2.Name = "Total2";
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCliente
            // 
            resources.ApplyResources(this.lblCliente, "lblCliente");
            this.lblCliente.Name = "lblCliente";
            // 
            // txtCodigoCliente
            // 
            resources.ApplyResources(this.txtCodigoCliente, "txtCodigoCliente");
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.ShortcutsEnabled = false;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            resources.ApplyResources(this.lblNombreCliente, "lblNombreCliente");
            this.lblNombreCliente.Name = "lblNombreCliente";
            // 
            // cbClientes
            // 
            resources.ApplyResources(this.cbClientes, "cbClientes");
            this.cbClientes.Checked = true;
            this.cbClientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.UseVisualStyleBackColor = true;
            this.cbClientes.CheckedChanged += new System.EventHandler(this.cbClientes_CheckedChanged);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtHasta, "dtHasta");
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.ValueChanged += new System.EventHandler(this.dtHasta_ValueChanged);
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtDesde, "dtDesde");
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            resources.ApplyResources(this.cbSucursales, "cbSucursales");
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.SelectedIndexChanged += new System.EventHandler(this.cbSucursales_SelectedIndexChanged);
            // 
            // lblSucursales
            // 
            resources.ApplyResources(this.lblSucursales, "lblSucursales");
            this.lblSucursales.Name = "lblSucursales";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbTriplicado);
            this.panel1.Controls.Add(this.rbDuplicado);
            this.panel1.Controls.Add(this.rbOriginal);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // rbTriplicado
            // 
            resources.ApplyResources(this.rbTriplicado, "rbTriplicado");
            this.rbTriplicado.Name = "rbTriplicado";
            this.rbTriplicado.TabStop = true;
            this.rbTriplicado.UseVisualStyleBackColor = true;
            // 
            // rbDuplicado
            // 
            resources.ApplyResources(this.rbDuplicado, "rbDuplicado");
            this.rbDuplicado.Checked = true;
            this.rbDuplicado.Name = "rbDuplicado";
            this.rbDuplicado.TabStop = true;
            this.rbDuplicado.UseVisualStyleBackColor = true;
            // 
            // rbOriginal
            // 
            resources.ApplyResources(this.rbOriginal, "rbOriginal");
            this.rbOriginal.Name = "rbOriginal";
            this.rbOriginal.TabStop = true;
            this.rbOriginal.UseVisualStyleBackColor = true;
            // 
            // frmComprobantesDeVenta
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmComprobantesDeVenta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbClientes;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnExportar;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label lblSucursales;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTipoDocumentoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbTriplicado;
        private System.Windows.Forms.RadioButton rbDuplicado;
        private System.Windows.Forms.RadioButton rbOriginal;
    }
}
