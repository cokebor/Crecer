using Controles2;

namespace Presentacion
{
    partial class frmRemitoCliente
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
            this.label4 = new System.Windows.Forms.Label();
            this.cbLote = new System.Windows.Forms.ComboBox();
            this.lblMovStock = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblRenglon = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Renglon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMovStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoteViejo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadVieja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNumeroComprobante1 = new Controles2.txtNumeroComprobante();
            this.label17 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblLoteViejo = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Lote:";
            // 
            // cbLote
            // 
            this.cbLote.Enabled = false;
            this.cbLote.FormattingEnabled = true;
            this.cbLote.Location = new System.Drawing.Point(95, 145);
            this.cbLote.Name = "cbLote";
            this.cbLote.Size = new System.Drawing.Size(63, 21);
            this.cbLote.TabIndex = 6;
            this.cbLote.SelectedIndexChanged += new System.EventHandler(this.cbLote_SelectedIndexChanged);
            this.cbLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLote_KeyDown);
            this.cbLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLote_KeyPress);
            // 
            // lblMovStock
            // 
            this.lblMovStock.AutoSize = true;
            this.lblMovStock.Location = new System.Drawing.Point(145, 438);
            this.lblMovStock.Name = "lblMovStock";
            this.lblMovStock.Size = new System.Drawing.Size(13, 13);
            this.lblMovStock.TabIndex = 64;
            this.lblMovStock.Text = "0";
            this.lblMovStock.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(11, 456);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblRenglon
            // 
            this.lblRenglon.AutoSize = true;
            this.lblRenglon.Location = new System.Drawing.Point(214, 437);
            this.lblRenglon.Name = "lblRenglon";
            this.lblRenglon.Size = new System.Drawing.Size(13, 13);
            this.lblRenglon.TabIndex = 61;
            this.lblRenglon.Text = "0";
            this.lblRenglon.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.CausesValidation = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(380, 42);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 60;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Location = new System.Drawing.Point(95, 46);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoCliente.TabIndex = 1;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(306, 456);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancelar_KeyDown);
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(190, 456);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEliminar_KeyDown);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(100, 456);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 11;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            this.btnConfirmar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnConfirmar_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Location = new System.Drawing.Point(403, 112);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(39, 20);
            this.txtCantidad.TabIndex = 5;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(132, 115);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(0, 13);
            this.lblProducto.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Producto (F5):";
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(95, 112);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(32, 20);
            this.txtProducto.TabIndex = 4;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            this.txtProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProducto_KeyDown);
            this.txtProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducto_KeyPress);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Renglon,
            this.Codigo,
            this.Descripción,
            this.Lote,
            this.Cantidad,
            this.CodigoMovStock,
            this.LoteViejo,
            this.CantidadVieja});
            this.dgvDatos.Location = new System.Drawing.Point(11, 179);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(406, 247);
            this.dgvDatos.TabIndex = 9;
            this.dgvDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDatos_KeyDown);
            // 
            // Renglon
            // 
            this.Renglon.HeaderText = "Renglon";
            this.Renglon.Name = "Renglon";
            this.Renglon.Visible = false;
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
            this.Descripción.DataPropertyName = "Descripcion";
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.Name = "Descripción";
            // 
            // Lote
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lote.DefaultCellStyle = dataGridViewCellStyle2;
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            // 
            // Cantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // CodigoMovStock
            // 
            this.CodigoMovStock.HeaderText = "CodigoMovStock";
            this.CodigoMovStock.Name = "CodigoMovStock";
            this.CodigoMovStock.Visible = false;
            // 
            // LoteViejo
            // 
            this.LoteViejo.HeaderText = "LoteViejo";
            this.LoteViejo.Name = "LoteViejo";
            this.LoteViejo.Visible = false;
            // 
            // CantidadVieja
            // 
            this.CantidadVieja.HeaderText = "CantidadVieja";
            this.CantidadVieja.Name = "CantidadVieja";
            this.CantidadVieja.Visible = false;
            // 
            // txtNumeroComprobante1
            // 
            this.txtNumeroComprobante1.Enabled = false;
            this.txtNumeroComprobante1.Location = new System.Drawing.Point(91, 76);
            this.txtNumeroComprobante1.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroComprobante1.Name = "txtNumeroComprobante1";
            this.txtNumeroComprobante1.Size = new System.Drawing.Size(118, 25);
            this.txtNumeroComprobante1.TabIndex = 2;
            this.txtNumeroComprobante1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroComprobante1_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(286, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 52;
            this.label17.Text = "Tipo:";
            // 
            // cbTipo
            // 
            this.cbTipo.Enabled = false;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(331, 79);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(111, 21);
            this.cbTipo.TabIndex = 3;
            this.cbTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCanal_KeyDown);
            this.cbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCanal_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Remito:";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(132, 51);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Cliente (F2):";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(286, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 44;
            this.label18.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(344, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(98, 20);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpIngreso_KeyDown);
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpIngreso_KeyPress);
            // 
            // lblLoteViejo
            // 
            this.lblLoteViejo.AutoSize = true;
            this.lblLoteViejo.Location = new System.Drawing.Point(272, 437);
            this.lblLoteViejo.Name = "lblLoteViejo";
            this.lblLoteViejo.Size = new System.Drawing.Size(13, 13);
            this.lblLoteViejo.TabIndex = 67;
            this.lblLoteViejo.Text = "0";
            this.lblLoteViejo.Visible = false;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(328, 437);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(13, 13);
            this.lblCantidad.TabIndex = 68;
            this.lblCantidad.Text = "0";
            this.lblCantidad.Visible = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = global::Presentacion.Properties.Resources.Edit;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(422, 269);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(25, 25);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = global::Presentacion.Properties.Resources.remove;
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(422, 229);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 8;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(422, 189);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblStock
            // 
            this.lblStock.Location = new System.Drawing.Point(208, 148);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(34, 13);
            this.lblStock.TabIndex = 397;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 396;
            this.label6.Text = "Stock:";
            // 
            // lblProveedor
            // 
            this.lblProveedor.Location = new System.Drawing.Point(250, 147);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(139, 14);
            this.lblProveedor.TabIndex = 399;
            // 
            // frmRemitoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(452, 493);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblLoteViejo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbLote);
            this.Controls.Add(this.lblMovStock);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblRenglon);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtNumeroComprobante1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dtpFecha);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRemitoCliente";
            this.Activated += new System.EventHandler(this.frmRemitoProveedor_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblNombreCliente;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cbTipo;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtProducto;
        public System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnBuscar;
        public txtNumeroComprobante txtNumeroComprobante1;
        private System.Windows.Forms.Label lblRenglon;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblMovStock;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbLote;
        private System.Windows.Forms.Label lblLoteViejo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Renglon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMovStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoteViejo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadVieja;
    }
}
