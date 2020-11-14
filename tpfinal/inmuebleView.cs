using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace tpfinal
{
    public partial class inmuebleView : Form
    {
        public inmuebleView(string _id)
        {
            InitializeComponent();
            try
            {
                Services.Inmueble _inmueble= new Services.Inmueble();
                Entities.Inmueble inmueble = _inmueble.TraerInmueblePorId(_id);
                byte[] byteBuffer = Convert.FromBase64String(inmueble.Uri);
                MemoryStream memoryStream = new MemoryStream(byteBuffer);
                Bitmap bitmap = new Bitmap(Bitmap.FromStream(memoryStream));
                pictureBox2.Image = bitmap;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                titulo.Text = inmueble.Title;
                ubicacion.Text = inmueble.Ubication + " " + inmueble.Address;
                descripcion.Text = inmueble.Description;

                List<star> starsList = new List<star>();
                for (int i = 0; i < inmueble.Stars; i++)
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
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void inmuebleView_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
