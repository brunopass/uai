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
    public partial class ImageCard : UserControl
    {

        private string id;
        public ImageCard(string id,string uri, string title, string ambientes,int stars)
        {
            InitializeComponent();
            label1.Text = title;
            label2.Text = ambientes;
            
            byte[] imageBytes = Convert.FromBase64String(uri);
            MemoryStream memoryStream = new MemoryStream(imageBytes);
            pictureBox1.InitialImage = null;
            pictureBox1.Image = Image.FromStream(memoryStream);

            List<star> starsList = new List<star>();
            for (int i = 0; i < stars; i++)
            {
                star s = new star();
                s.BackColor = Color.WhiteSmoke;
                starsList.Add(s);
            }
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;
            foreach (Control control in starsList)
            {
                flowLayoutPanel1.Controls.Add(control);
            }
            this.id = id;
        }

        private void ImageCard_Load(object sender, EventArgs e)
        {

        }

        private void open()
        {
            inmuebleView inmuebleView = new inmuebleView(id);
            inmuebleView.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            open();
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            open();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            open();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            open();
        }
    }
}
