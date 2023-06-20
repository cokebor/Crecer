
namespace Presentacion
{
    partial class frmNCVacios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNCVacios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCodigoVendedor = new System.Windows.Forms.TextBox();
            this.lblNombreVendedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTipoComprobanteCliente = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.cbDevolucionEfectivo = new System.Windows.Forms.CheckBox();
            this.panelPorUnidad = new System.Windows.Forms.Panel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLote = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblPercepcionMunicipal = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblNeto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ivas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPorUnidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigoVendedor
            // 
            this.txtCodigoVendedor.Location = new System.Drawing.Point(90, 11);
            this.txtCodigoVendedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoVendedor.Name = "txtCodigoVendedor";
            this.txtCodigoVendedor.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoVendedor.TabIndex = 400;
            this.txtCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoVendedor.TextChanged += new System.EventHandler(this.txtCodigoVendedor_TextChanged);
            this.txtCodigoVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoVendedor_KeyDown);
            this.txtCodigoVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoVendedor_KeyPress);
            // 
            // lblNombreVendedor
            // 
            this.lblNombreVendedor.AutoSize = true;
            this.lblNombreVendedor.Location = new System.Drawing.Point(127, 16);
            this.lblNombreVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreVendedor.Name = "lblNombreVendedor";
            this.lblNombreVendedor.Size = new System.Drawing.Size(0, 13);
            this.lblNombreVendedor.TabIndex = 408;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 407;
            this.label3.Text = "Vendedor (F1):";
            // 
            // lblTipoComprobanteCliente
            // 
            this.lblTipoComprobanteCliente.AutoSize = true;
            this.lblTipoComprobanteCliente.Location = new System.Drawing.Point(326, 16);
            this.lblTipoComprobanteCliente.Name = "lblTipoComprobanteCliente";
            this.lblTipoComprobanteCliente.Size = new System.Drawing.Size(0, 13);
            this.lblTipoComprobanteCliente.TabIndex = 406;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(484, 16);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 405;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 404;
            this.label1.Text = "Fecha:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(90, 46);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(32, 20);
            this.txtCodigoCliente.TabIndex = 401;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(127, 51);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCliente.TabIndex = 403;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 402;
            this.label4.Text = "Cliente (F2):";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(747, 542);
            this.shapeContainer1.TabIndex = 61;
            this.shapeContainer1.TabStop = false;
            // 
            // cbDevolucionEfectivo
            // 
            this.cbDevolucionEfectivo.AutoSize = true;
            this.cbDevolucionEfectivo.Location = new System.Drawing.Point(14, 359);
            this.cbDevolucionEfectivo.Name = "cbDevolucionEfectivo";
            this.cbDevolucionEfectivo.Size = new System.Drawing.Size(179, 17);
            this.cbDevolucionEfectivo.TabIndex = 409;
            this.cbDevolucionEfectivo.Text = "Registrar devolución de efectivo";
            this.cbDevolucionEfectivo.UseVisualStyleBackColor = true;
            this.cbDevolucionEfectivo.CheckedChanged += new System.EventHandler(this.cbDevolucionEfectivo_CheckedChanged);
            // 
            // panelPorUnidad
            // 
            this.panelPorUnidad.Controls.Add(this.dgvDatos);
            this.panelPorUnidad.Controls.Add(this.btnEditar);
            this.panelPorUnidad.Controls.Add(this.btnEliminarProducto);
            this.panelPorUnidad.Controls.Add(this.btnAgregar);
            this.panelPorUnidad.Controls.Add(this.label5);
            this.panelPorUnidad.Controls.Add(this.txtPrecio);
            this.panelPorUnidad.Controls.Add(this.label6);
            this.panelPorUnidad.Controls.Add(this.cbLote);
            this.panelPorUnidad.Controls.Add(this.label7);
            this.panelPorUnidad.Controls.Add(this.txtCantidad);
            this.panelPorUnidad.Controls.Add(this.lblProducto);
            this.panelPorUnidad.Controls.Add(this.label8);
            this.panelPorUnidad.Controls.Add(this.txtProducto);
            this.panelPorUnidad.Location = new System.Drawing.Point(0, 80);
            this.panelPorUnidad.Name = "panelPorUnidad";
            this.panelPorUnidad.Size = new System.Drawing.Size(568, 268);
            this.panelPorUnidad.TabIndex = 410;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.CausesValidation = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripción,
            this.Lote,
            this.Cantidad,
            this.PUnitario,
            this.Total,
            this.Ivas,
            this.PorcIva});
            this.dgvDatos.Location = new System.Drawing.Point(9, 37);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(522, 228);
            this.dgvDatos.TabIndex = 89;
            this.dgvDatos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellLeave);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Location = new System.Drawing.Point(538, 117);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(25, 25);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarProducto.BackgroundImage")));
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(538, 77);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 5;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(538, 37);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 25);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "P. Unit.:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(512, 1);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(51, 20);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecio_KeyDown);
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Lote:";
            // 
            // cbLote
            // 
            this.cbLote.FormattingEnabled = true;
            this.cbLote.Location = new System.Drawing.Point(393, 0);
            this.cbLote.Name = "cbLote";
            this.cbLote.Size = new System.Drawing.Size(65, 21);
            this.cbLote.TabIndex = 2;
            this.cbLote.SelectedIndexChanged += new System.EventHandler(this.cbLote_SelectedIndexChanged);
            this.cbLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLote_KeyDown);
            this.cbLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLote_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(316, 1);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(39, 20);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(128, 4);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(0, 13);
            this.lblProducto.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Producto (F5):";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(91, 1);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(32, 20);
            this.txtProducto.TabIndex = 0;
            this.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            this.txtProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProducto_KeyDown);
            this.txtProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducto_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(239, 405);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 13);
            this.label21.TabIndex = 426;
            this.label21.Text = "Perc. Munic.:";
            // 
            // lblPercepcionMunicipal
            // 
            this.lblPercepcionMunicipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercepcionMunicipal.ForeColor = System.Drawing.Color.Maroon;
            this.lblPercepcionMunicipal.Location = new System.Drawing.Point(289, 403);
            this.lblPercepcionMunicipal.Name = "lblPercepcionMunicipal";
            this.lblPercepcionMunicipal.Size = new System.Drawing.Size(100, 17);
            this.lblPercepcionMunicipal.TabIndex = 425;
            this.lblPercepcionMunicipal.Text = "0.0000";
            this.lblPercepcionMunicipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(401, 359);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 420;
            this.label16.Text = "Neto:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(401, 382);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 419;
            this.label17.Text = "IVA:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(401, 405);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 418;
            this.label18.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(445, 402);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTotal.TabIndex = 417;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIva
            // 
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.ForeColor = System.Drawing.Color.Maroon;
            this.lblIva.Location = new System.Drawing.Point(445, 380);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(100, 17);
            this.lblIva.TabIndex = 416;
            this.lblIva.Text = "0.0000";
            this.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNeto
            // 
            this.lblNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeto.ForeColor = System.Drawing.Color.Maroon;
            this.lblNeto.Location = new System.Drawing.Point(445, 357);
            this.lblNeto.Name = "lblNeto";
            this.lblNeto.Size = new System.Drawing.Size(100, 17);
            this.lblNeto.TabIndex = 415;
            this.lblNeto.Text = "0.0000";
            this.lblNeto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(484, 431);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 26);
            this.btnCancelar.TabIndex = 428;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AccessibleDescription = "aasdasdas";
            this.btnConfirmar.Location = new System.Drawing.Point(385, 431);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(79, 26);
            this.btnConfirmar.TabIndex = 427;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(368, 50);
            this.lblSucursal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(51, 13);
            this.lblSucursal.TabIndex = 430;
            this.lblSucursal.Text = "Sucursal:";
            this.lblSucursal.Visible = false;
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(436, 45);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(132, 21);
            this.cbSucursales.TabIndex = 429;
            this.cbSucursales.Visible = false;
            // 
            // Codigo
            // 
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
            // PUnitario
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C4";
            dataGridViewCellStyle4.NullValue = null;
            this.PUnitario.DefaultCellStyle = dataGridViewCellStyle4;
            this.PUnitario.HeaderText = "P. Unitario";
            this.PUnitario.Name = "PUnitario";
            // 
            // Total
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C4";
            dataGridViewCellStyle5.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // Ivas
            // 
            this.Ivas.HeaderText = "Ivas";
            this.Ivas.Name = "Ivas";
            this.Ivas.Visible = false;
            // 
            // PorcIva
            // 
            this.PorcIva.HeaderText = "PorcIva";
            this.PorcIva.Name = "PorcIva";
            this.PorcIva.Visible = false;
            // 
            // frmNCVacios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(571, 468);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblPercepcionMunicipal);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIva);
            this.Controls.Add(this.lblNeto);
            this.Controls.Add(this.panelPorUnidad);
            this.Controls.Add(this.cbDevolucionEfectivo);
            this.Controls.Add(this.txtCodigoVendedor);
            this.Controls.Add(this.lblNombreVendedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTipoComprobanteCliente);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label4);
            this.Name = "frmNCVacios";
            this.panelPorUnidad.ResumeLayout(false);
            this.panelPorUnidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoVendedor;
        public System.Windows.Forms.Label lblNombreVendedor;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTipoComprobanteCliente;
        private System.Windows.Forms.Label lblFecha;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCodigoCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        public System.Windows.Forms.Label label4;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.CheckBox cbDevolucionEfectivo;
        public System.Windows.Forms.Panel panelPorUnidad;
        public System.Windows.Forms.DataGridView dgvDatos;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnEliminarProducto;
        public System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbLote;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtCantidad;
        public System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtProducto;
        public System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblPercepcionMunicipal;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblNeto;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ivas;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcIva;
    }
}
