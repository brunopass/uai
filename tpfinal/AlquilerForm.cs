using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpfinal
{
    public partial class AlquilerForm : Form
    {
        public AlquilerForm()
        {
            InitializeComponent();
        }

        Bitmap bitmap;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)| *.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                bitmap = new Bitmap(open.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = bitmap;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AlquilerForm_Load(object sender, EventArgs e)
        {
            Services.Dashboard dashboard = new Services.Dashboard();
            try
            {
                ubicacion.Items.AddRange(dashboard.traerPaises().ToArray());
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services.Inmueble inmueble = new Services.Inmueble();

            try
            {
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Png);
                byte[] byteImg = ms.ToArray();
                string msg = inmueble.CrearAlquiler(
                    titulo.Text, 
                    descripcion.Text, 
                    direccion.Text, 
                    ubicacion.Text, 
                    float.Parse(precio.Text), 
                    Convert.ToBase64String(byteImg));
                MessageBox.Show(msg);
                this.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
    }
}
