using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpfinal
{
    public partial class Comentario : UserControl
    {
        private string id;

        public Comentario(Entities.Comentario comentario)
        {
            InitializeComponent();
            this.id = comentario.Id;
            descripcion.Text = comentario.Value;

            List<star> starsList = new List<star>();
            for (int i = 0; i < comentario.Calificacion; i++)
            {
                star s = new star();
                s.BackColor = Color.White;
                starsList.Add(s);
            }
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;
            foreach (Control control in starsList)
            {
                flowLayoutPanel1.Controls.Add(control);
            }
        }

        private void Comentario_Load(object sender, EventArgs e)
        {

        }
    }
}
