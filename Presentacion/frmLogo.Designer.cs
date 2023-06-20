namespace Presentacion
{
    partial class frmLogo
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
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscarArchivo = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 288);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(374, 332);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.Location = new System.Drawing.Point(426, 9);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarArchivo.TabIndex = 8;
            this.btnBuscarArchivo.Text = "...";
            this.btnBuscarArchivo.UseVisualStyleBackColor = true;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Enabled = false;
            this.txtRuta.Location = new System.Drawing.Point(12, 12);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(408, 20);
            this.txtRuta.TabIndex = 7;
            // 
            // frmLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(460, 362);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.txtRuta);
            this.Name = "frmLogo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscarArchivo;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.OpenFileDialog ofd;
    }
}
