using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace tpfinal
{
    public partial class Card : UserControl
    {

        private string id;

        public Card(string id,string uri, string title, string ambientes, string description, int stars, bool isFav)
        {
            InitializeComponent();
            titulo.Text = title;
            ambiente.Text = ambientes;
            desripcion.Text = description;

            byte[] byteBuffer = Convert.FromBase64String(uri);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);
            Bitmap bitmap = new Bitmap(Bitmap.FromStream(memoryStream));
            pictureBox1.Image = bitmap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
            List<star> starsList = new List<star>();
            for (int i = 0; i < stars; i++)
            {
                starsList.Add(new star());
            }
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;
            foreach (Control control in starsList)
            {
                flowLayoutPanel1.Controls.Add(control);
            }

            if (isFav)
            {
                pictureBox2.Visible = true;
            }

            this.id = id;
        }

        private void open()
        {
            inmuebleView inmuebleView = new inmuebleView(id);
            inmuebleView.ShowDialog();
        }

        private void Card_Load(object sender, EventArgs e)
        {
            
        }

        private void Card_MouseHover(object sender, EventArgs e)
        {

        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {

        }

        private void desripcion_Click(object sender, EventArgs e)
        {
            open();
        }

        private void Card_Click(object sender, EventArgs e)
        {
            open();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            open();
        }

        private void titulo_Click(object sender, EventArgs e)
        {
            open();
        }

        private void ambiente_Click(object sender, EventArgs e)
        {
            open();
        }

       

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            open();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Services.Inmueble inmueble = new Services.Inmueble();
            try
            {
                string msg = inmueble.BorrarFavoritos(id);
                this.Hide();
                MessageBox.Show(msg);
            }catch(Exception error)
            {
                MessageBox.Show(error.Message, "Erro");
            }
        }
    }
}
