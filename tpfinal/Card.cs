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
        public Card(string uri, string title, string ambientes, string description, int stars)
        {
            InitializeComponent();
            titulo.Text = title;
            ambiente.Text = ambientes;
            desripcion.Text = description;
            byte[] imageBytes = Convert.FromBase64String(uri);
            MemoryStream memoryStream = new MemoryStream(imageBytes);
            pictureBox1.InitialImage = null;
            pictureBox1.Image = Image.FromStream(memoryStream);
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
    }
}
