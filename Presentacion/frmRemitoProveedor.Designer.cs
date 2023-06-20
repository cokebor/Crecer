using Controles2;

namespace Presentacion
{
    partial class frmRemitoProveedor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaEmbarque = new System.Windows.Forms.DateTimePicker();
            this.cbRemito = new System.Windows.Forms.CheckBox();
            this.lblCantidadVieja = new System.Windows.Forms.Label();
            this.lblMovStock = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblLote = new System.Windows.Forms.Label();
            this.lblRenglon = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
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
            this.CantidadVieja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoMovStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNumeroComprobante1 = new Controles2.txtNumeroComprobante();
            this.label17 = new System.Windows.Forms.Label();
            this.cbCanal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbTransportes = new System.Windows.Forms.ComboBox();
            this.cmsTransportes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.nudPallets = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.cmsTransportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPallets)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Fecha Embarque:";
            this.label4.Visible = false;
            // 
            // dtpFechaEmbarque
            // 
            this.dtpFechaEmbarque.Enabled = false;
            this.dtpFechaEmbarque.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmbarque.Location = new System.Drawing.Point(420, 12);
            this.dtpFechaEmbarque.Name = "dtpFechaEmbarque";
            this.dtpFechaEmbarque.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaEmbarque.TabIndex = 1;
            this.dtpFechaEmbarque.Visible = false;
            // 
            // cbRemito
            // 
            this.cbRemito.AutoSize = true;
            this.cbRemito.Enabled = false;
            this.cbRemito.Location = new System.Drawing.Point(98, 83);
            this.cbRemito.Margin = new System.Windows.Forms.Padding(2);
            this.cbRemito.Name = "cbRemito";
            this.cbRemito.Size = new System.Drawing.Size(15, 14);
            this.cbRemito.TabIndex = 3;
            this.cbRemito.UseVisualStyleBackColor = true;
            this.cbRemito.CheckedChanged += new System.EventHandler(this.cbRemito_CheckedChanged);
            // 
            // lblCantidadVieja
            // 
            this.lblCantidadVieja.AutoSize = true;
            this.lblCantidadVieja.Location = new System.Drawing.Point(303, 409);
            this.lblCantidadVieja.Name = "lblCantidadVieja";
            this.lblCantidadVieja.Size = new System.Drawing.Size(13, 13);
            this.lblCantidadVieja.TabIndex = 65;
            this.lblCantidadVieja.Text = "0";
            this.lblCantidadVieja.Visible = false;
            // 
            // lblMovStock
            // 
            this.lblMovStock.AutoSize = true;
            this.lblMovStock.Location = new System.Drawing.Point(145, 410);
            this.lblMovStock.Name = "lblMovStock";
            this.lblMovStock.Size = new System.Drawing.Size(13, 13);
            this.lblMovStock.TabIndex = 64;
            this.lblMovStock.Text = "0";
            this.lblMovStock.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.CausesValidation = false;
            this.btnNuevo.Location = new System.Drawing.Point(11, 428);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(79, 26);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(253, 409);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(13, 13);
            this.lblLote.TabIndex = 62;
            this.lblLote.Text = "0";
            this.lblLote.Visible = false;
            // 
            // lblRenglon
            // 
            this.lblRenglon.AutoSize = true;
            this.lblRenglon.Location = new System.Drawing.Point(214, 409);
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
            this.btnBuscar.Location = new System.Drawing.Point(452, 45);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(62, 26);
            this.btnBuscar.TabIndex = 60;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = global::Presentacion.Properties.Resources.pencil;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(489, 241);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(25, 25);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = global::Presentacion.Properties.Resources.remove;
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(489, 201);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 11;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.plus;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(489, 161);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Enabled = false;
            this.txtCodigoProveedor.Location = new System.Drawing.Point(95, 46);
            this.txtCodigoProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoProveedor.TabIndex = 2;
            this.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProveedor.TextChanged += new System.EventHandler(this.txtCodigoProveedor_TextChanged);
            this.txtCodigoProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoProveedor_KeyDown);
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(435, 428);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancelar_KeyDown);
            // 
            // btnEliminar
            // 
            this.btnEliminar.CausesValidation = false;
            this.btnEliminar.Location = new System.Drawing.Point(190, 428);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 26);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEliminar_KeyDown);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(100, 428);
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
            this.label2.Location = new System.Drawing.Point(405, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Location = new System.Drawing.Point(475, 112);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(39, 20);
            this.txtCantidad.TabIndex = 9;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.lblProducto.Click += new System.EventHandler(this.lblProducto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Producto (F5):";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(95, 112);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(32, 20);
            this.txtProducto.TabIndex = 8;
            this.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.CantidadVieja,
            this.CodigoMovStock});
            this.dgvDatos.Location = new System.Drawing.Point(11, 151);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(473, 247);
            this.dgvDatos.TabIndex = 15;
            this.dgvDatos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDatos_CurrentCellDirtyStateChanged);
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
            // CantidadVieja
            // 
            this.CantidadVieja.HeaderText = "CantidadVieja";
            this.CantidadVieja.Name = "CantidadVieja";
            this.CantidadVieja.Visible = false;
            // 
            // CodigoMovStock
            // 
            this.CodigoMovStock.HeaderText = "CodigoMovStock";
            this.CodigoMovStock.Name = "CodigoMovStock";
            this.CodigoMovStock.Visible = false;
            // 
            // txtNumeroComprobante1
            // 
            this.txtNumeroComprobante1.Enabled = false;
            this.txtNumeroComprobante1.Location = new System.Drawing.Point(112, 76);
            this.txtNumeroComprobante1.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroComprobante1.Name = "txtNumeroComprobante1";
            this.txtNumeroComprobante1.Size = new System.Drawing.Size(118, 25);
            this.txtNumeroComprobante1.TabIndex = 4;
            this.txtNumeroComprobante1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroComprobante1_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(363, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 52;
            this.label17.Text = "Canal:";
            // 
            // cbCanal
            // 
            this.cbCanal.Enabled = false;
            this.cbCanal.FormattingEnabled = true;
            this.cbCanal.Location = new System.Drawing.Point(403, 79);
            this.cbCanal.Name = "cbCanal";
            this.cbCanal.Size = new System.Drawing.Size(111, 21);
            this.cbCanal.TabIndex = 7;
            this.cbCanal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCanal_KeyDown);
            this.cbCanal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCanal_KeyPress);
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
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Location = new System.Drawing.Point(132, 51);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreProveedor.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Proveedor (F6):";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 44;
            this.label18.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(74, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(98, 20);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpIngreso_KeyDown);
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpIngreso_KeyPress);
            // 
            // cbTransportes
            // 
            this.cbTransportes.ContextMenuStrip = this.cmsTransportes;
            this.cbTransportes.Enabled = false;
            this.cbTransportes.FormattingEnabled = true;
            this.cbTransportes.Location = new System.Drawing.Point(298, 48);
            this.cbTransportes.Name = "cbTransportes";
            this.cbTransportes.Size = new System.Drawing.Size(149, 21);
            this.cbTransportes.TabIndex = 71;
            // 
            // cmsTransportes
            // 
            this.cmsTransportes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.cmsTransportes.Name = "cmsTransportes";
            this.cmsTransportes.Size = new System.Drawing.Size(117, 26);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "Pallets:";
            // 
            // nudPallets
            // 
            this.nudPallets.Enabled = false;
            this.nudPallets.Location = new System.Drawing.Point(292, 79);
            this.nudPallets.Name = "nudPallets";
            this.nudPallets.Size = new System.Drawing.Size(63, 20);
            this.nudPallets.TabIndex = 73;
            // 
            // frmRemitoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(522, 465);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudPallets);
            this.Controls.Add(this.cbTransportes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaEmbarque);
            this.Controls.Add(this.cbRemito);
            this.Controls.Add(this.lblCantidadVieja);
            this.Controls.Add(this.lblMovStock);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblLote);
            this.Controls.Add(this.lblRenglon);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCodigoProveedor);
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
            this.Controls.Add(this.cbCanal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dtpFecha);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRemitoProveedor";
            this.Activated += new System.EventHandler(this.frmRemitoProveedor_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.cmsTransportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPallets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblNombreProveedor;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cbCanal;
        public System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtProducto;
        public System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.TextBox txtCodigoProveedor;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnBuscar;
        public txtNumeroComprobante txtNumeroComprobante1;
        private System.Windows.Forms.Label lblRenglon;
        private System.Windows.Forms.Label lblLote;
        public System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblMovStock;
        private System.Windows.Forms.Label lblCantidadVieja;
        private System.Windows.Forms.CheckBox cbRemito;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaEmbarque;
        private System.Windows.Forms.ComboBox cbTransportes;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudPallets;
        private System.Windows.Forms.DataGridViewTextBoxColumn Renglon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadVieja;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoMovStock;
        private System.Windows.Forms.ContextMenuStrip cmsTransportes;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
    }
}
