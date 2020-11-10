namespace tpfinal
{
    partial class Card
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titulo = new System.Windows.Forms.Label();
            this.ambiente = new System.Windows.Forms.Label();
            this.desripcion = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(25, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(231, 51);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(93, 37);
            this.titulo.TabIndex = 1;
            this.titulo.Text = "Titulo";
            // 
            // ambiente
            // 
            this.ambiente.AutoSize = true;
            this.ambiente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiente.Location = new System.Drawing.Point(234, 88);
            this.ambiente.Name = "ambiente";
            this.ambiente.Size = new System.Drawing.Size(84, 21);
            this.ambiente.TabIndex = 2;
            this.ambiente.Text = "Ambientes";
            // 
            // desripcion
            // 
            this.desripcion.AutoSize = true;
            this.desripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desripcion.Location = new System.Drawing.Point(234, 118);
            this.desripcion.Name = "desripcion";
            this.desripcion.Size = new System.Drawing.Size(91, 21);
            this.desripcion.TabIndex = 3;
            this.desripcion.Text = "Descripcion";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(239, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(261, 30);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.desripcion);
            this.Controls.Add(this.ambiente);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Card";
            this.Size = new System.Drawing.Size(698, 248);
            this.Load += new System.EventHandler(this.Card_Load);
            this.MouseLeave += new System.EventHandler(this.Card_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Card_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Label ambiente;
        private System.Windows.Forms.Label desripcion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
