using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpfinal
{
    public partial class MisAlquileres : Form
    {
        public MisAlquileres()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Favoritos favoritos = new Favoritos();
            favoritos.ShowDialog();
        }

        private void MisAlquileres_Load(object sender, EventArgs e)
        {
            Services.Inmueble inmueble = new Services.Inmueble();
            List<Entities.Inmueble> inmuebles = inmueble.TraerAlquileres();
            List<Card> cards = new List<Card>();

            foreach (Entities.Inmueble _inmueble in inmuebles)
            {
                cards.Add(new Card(_inmueble.Id, _inmueble.Uri, _inmueble.Title, _inmueble.Ubication, _inmueble.Description, _inmueble.Stars, false));
            }

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Height = cards.Count * 260;
            foreach (Control control in cards)
            {
                flowLayoutPanel1.Controls.Add(control);
            }

            if (cards.Count == 0)
            {
                panel1.Visible = true;
            }

            Entities.Session.sessionListener += Session_Listener;
            Services.Usuario usuario = new Services.Usuario();
            try
            {

                if (usuario.isLogged())
                {
                    loggedTab.Visible = true;
                    button1.Visible = false;
                    button2.Visible = false;
                }
                else
                {
                    loggedTab.Visible = false;
                    button1.Visible = true;
                    button2.Visible = true;
                }
            }
            catch
            {

            }
        }

        private void Session_Listener(bool isLogged)
        {
            if (isLogged)
            {
                loggedTab.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
            }
            else
            {
                this.Close();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Services.Usuario usuario = new Services.Usuario();
            try
            {
                string msg = usuario.CerrarSesion();
                MessageBox.Show(msg);
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AlquilerForm alquilerForm = new AlquilerForm();
            alquilerForm.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            AlquilerForm alquiler = new AlquilerForm();
            alquiler.ShowDialog();
        }
    }
}
