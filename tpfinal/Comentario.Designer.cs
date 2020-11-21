namespace tpfinal
{
    partial class Comentario
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
            this.descripcion = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // descripcion
            // 
            this.descripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.descripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(117)))), ((int)(((byte)(127)))));
            this.descripcion.Location = new System.Drawing.Point(12, 44);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(692, 95);
            this.descripcion.TabIndex = 23;
            this.descripcion.Text = "descripcion";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 11);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(214, 30);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // Comentario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.descripcion);
            this.Name = "Comentario";
            this.Size = new System.Drawing.Size(718, 148);
            this.Load += new System.EventHandler(this.Comentario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label descripcion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
