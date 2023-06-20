namespace Presentacion
{
    partial class frmVentasPorLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasPorLote));
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
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtCodigoLote = new System.Windows.Forms.TextBox();
            this.lblNombreLote = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.lblSucursales = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCantidadVendida = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCantidadMerma = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPromedioSinMerma = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPromedioConMerma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
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
            this.Fecha,
            this.Comprobante,
            this.Numero,
            this.Cliente,
            this.Cantidad,
            this.PrecioUnitario,
            this.Total});
            resources.ApplyResources(this.dgvDatos, "dgvDatos");
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            // 
            // CodigoSucursal
            // 
            this.CodigoSucursal.DataPropertyName = "CodigoSucursal";
            resources.ApplyResources(this.CodigoSucursal, "CodigoSucursal");
            this.CodigoSucursal.Name = "CodigoSucursal";
            this.CodigoSucursal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.Fecha, "Fecha");
            this.Fecha.Name = "Fecha";
            // 
            // Comprobante
            // 
            this.Comprobante.DataPropertyName = "TipoDocumento";
            resources.ApplyResources(this.Comprobante, "Comprobante");
            this.Comprobante.Name = "Comprobante";
            this.Comprobante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.Numero, "Numero");
            this.Numero.Name = "Numero";
            this.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            resources.ApplyResources(this.Cliente, "Cliente");
            this.Cliente.Name = "Cliente";
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.Cantidad, "Cantidad");
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.PrecioUnitario.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.PrecioUnitario, "PrecioUnitario");
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.Total, "Total");
            this.Total.Name = "Total";
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // lblLote
            // 
            resources.ApplyResources(this.lblLote, "lblLote");
            this.lblLote.Name = "lblLote";
            // 
            // txtCodigoLote
            // 
            resources.ApplyResources(this.txtCodigoLote, "txtCodigoLote");
            this.txtCodigoLote.Name = "txtCodigoLote";
            this.txtCodigoLote.ShortcutsEnabled = false;
            this.txtCodigoLote.TextChanged += new System.EventHandler(this.txtCodigoLote_TextChanged);
            this.txtCodigoLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoLote_KeyPress);
            // 
            // lblNombreLote
            // 
            resources.ApplyResources(this.lblNombreLote, "lblNombreLote");
            this.lblNombreLote.Name = "lblNombreLote";
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtHasta, "dtHasta");
            this.dtHasta.Name = "dtHasta";
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtDesde, "dtDesde");
            this.dtDesde.Name = "dtDesde";
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblCantidadVendida
            // 
            resources.ApplyResources(this.lblCantidadVendida, "lblCantidadVendida");
            this.lblCantidadVendida.ForeColor = System.Drawing.Color.Maroon;
            this.lblCantidadVendida.Name = "lblCantidadVendida";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lblCantidadMerma
            // 
            resources.ApplyResources(this.lblCantidadMerma, "lblCantidadMerma");
            this.lblCantidadMerma.ForeColor = System.Drawing.Color.Maroon;
            this.lblCantidadMerma.Name = "lblCantidadMerma";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblPromedioSinMerma
            // 
            resources.ApplyResources(this.lblPromedioSinMerma, "lblPromedioSinMerma");
            this.lblPromedioSinMerma.ForeColor = System.Drawing.Color.Maroon;
            this.lblPromedioSinMerma.Name = "lblPromedioSinMerma";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lblPromedioConMerma
            // 
            resources.ApplyResources(this.lblPromedioConMerma, "lblPromedioConMerma");
            this.lblPromedioConMerma.ForeColor = System.Drawing.Color.Maroon;
            this.lblPromedioConMerma.Name = "lblPromedioConMerma";
            // 
            // frmVentasPorLote
            // 
            this.AcceptButton = this.btnBuscar;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPromedioConMerma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPromedioSinMerma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCantidadMerma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCantidadVendida);
            this.Controls.Add(this.lblSucursales);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblLote);
            this.Controls.Add(this.txtCodigoLote);
            this.Controls.Add(this.lblNombreLote);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmVentasPorLote";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCodigoLote;
        public System.Windows.Forms.Label lblNombreLote;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnExportar;
        public System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label lblSucursales;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCantidadVendida;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCantidadMerma;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPromedioSinMerma;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPromedioConMerma;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}
