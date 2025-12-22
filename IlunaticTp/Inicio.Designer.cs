namespace IlunaticTp
{
    partial class Inicio
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.MenuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMantenedor = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProveedor = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.contenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.Gainsboro;
            this.menu.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.GripMargin = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menu.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuCompra,
            this.ventasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.menuMantenedor,
            this.menuProveedor});
            this.menu.Location = new System.Drawing.Point(0, 51);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(1306, 87);
            this.menu.TabIndex = 0;
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // MenuTitulo
            // 
            this.MenuTitulo.AutoSize = false;
            this.MenuTitulo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuTitulo.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuTitulo.Location = new System.Drawing.Point(0, 0);
            this.MenuTitulo.Name = "MenuTitulo";
            this.MenuTitulo.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MenuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MenuTitulo.Size = new System.Drawing.Size(1306, 51);
            this.MenuTitulo.TabIndex = 1;
            this.MenuTitulo.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(34, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Apple Shop";
            // 
            // contenedor
            // 
            this.contenedor.BackColor = System.Drawing.Color.White;
            this.contenedor.Controls.Add(this.image);
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 138);
            this.contenedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1306, 636);
            this.contenedor.TabIndex = 3;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.contenedor_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1058, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(1158, 21);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(72, 24);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "usuario";
            // 
            // image
            // 
            this.image.Image = global::IlunaticTp.Properties.Resources.LogoLN;
            this.image.Location = new System.Drawing.Point(473, 85);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(338, 338);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.AutoSize = false;
            this.menuUsuarios.Image = global::IlunaticTp.Properties.Resources.agregar_usuario;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(169, 78);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuCompra
            // 
            this.menuCompra.Checked = true;
            this.menuCompra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuCompra.Image = global::IlunaticTp.Properties.Resources.carrito_de_compras;
            this.menuCompra.Name = "menuCompra";
            this.menuCompra.Size = new System.Drawing.Size(130, 83);
            this.menuCompra.Text = "Compras";
            this.menuCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuCompra.Click += new System.EventHandler(this.menuCompras_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Image = global::IlunaticTp.Properties.Resources.etiqueta_de_precio;
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(114, 83);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Image = global::IlunaticTp.Properties.Resources.customer_review;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(120, 83);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // menuMantenedor
            // 
            this.menuMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriaToolStripMenuItem,
            this.productoToolStripMenuItem});
            this.menuMantenedor.Image = global::IlunaticTp.Properties.Resources.mantenimiento;
            this.menuMantenedor.Name = "menuMantenedor";
            this.menuMantenedor.Size = new System.Drawing.Size(181, 83);
            this.menuMantenedor.Text = "Mantenimiento";
            this.menuMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.categoriaToolStripMenuItem.Text = "Categoria";
            this.categoriaToolStripMenuItem.Click += new System.EventHandler(this.categoriaToolStripMenuItem_Click);
            // 
            // productoToolStripMenuItem
            // 
            this.productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            this.productoToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.productoToolStripMenuItem.Text = "Producto";
            this.productoToolStripMenuItem.Click += new System.EventHandler(this.productoToolStripMenuItem_Click);
            // 
            // menuProveedor
            // 
            this.menuProveedor.Image = global::IlunaticTp.Properties.Resources.proveedor;
            this.menuProveedor.Name = "menuProveedor";
            this.menuProveedor.Size = new System.Drawing.Size(159, 83);
            this.menuProveedor.Text = "Proveedores";
            this.menuProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuProveedor.Click += new System.EventHandler(this.menuProveedor_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 774);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.MenuTitulo);
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Inicio";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.contenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip MenuTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuProveedor;
        private System.Windows.Forms.ToolStripMenuItem menuCompra;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuMantenedor;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoToolStripMenuItem;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
    }
}

