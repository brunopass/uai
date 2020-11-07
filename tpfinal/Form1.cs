using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Services;

namespace tpfinal
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateVerticalCards()
        {
            Services.Dashboard dashboard = new Services.Dashboard();
            List<Casa> casas = dashboard.traerInmuebles(3);
            List<Card> cards = new List<Card>();

            foreach (Casa casa in casas)
            {
                cards.Add(new Card(casa.Uri,casa.Titulo, casa.Ambientes, casa.Descripcion, casa.Estrellas));
            }

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Height = cards.Count * 260;
            foreach (Control control in cards)
            {
                flowLayoutPanel1.Controls.Add(control);
            }
        }

        public void updateHorizontalCards()
        {
            Services.Dashboard dashboard = new Services.Dashboard();
            List<Casa> casas = dashboard.traerInmuebles(3);
            List<ImageCard> cards = new List<ImageCard>();

            foreach (Casa casa in casas)
            {
                cards.Add(new ImageCard(casa.Uri,casa.Titulo, casa.Ambientes, casa.Estrellas));
            }
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel2.WrapContents = false;
            foreach (Control control in cards)
            {
                flowLayoutPanel2.Controls.Add(control);
            }
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            updateVerticalCards();
            updateHorizontalCards();



            

            List<Recomendaciones> recomendaciones = new List<Recomendaciones>();
            recomendaciones.Add(new Recomendaciones("Argentina"));
            recomendaciones.Add(new Recomendaciones("Brasil"));
            recomendaciones.Add(new Recomendaciones("Chile"));
            recomendaciones.Add(new Recomendaciones("Uruguay"));
            recomendaciones.Add(new Recomendaciones("Colombia"));
            flowLayoutPanel3.AutoScroll = true;
            flowLayoutPanel3.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel3.WrapContents = false;
            foreach (Control control in recomendaciones)
            {
                flowLayoutPanel3.Controls.Add(control);
            }

            Session.sessionListener += Session_Listener;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                loggedTab.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrearCuenta crearCuenta = new CrearCuenta();
            crearCuenta.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Services.Usuario usuario = new Services.Usuario();
            try
            {
                if (usuario.isLogged())
                {
                    AlquilerForm alquiler = new AlquilerForm();
                    alquiler.ShowDialog();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
                SignIn signIn = new SignIn();
                signIn.ShowDialog();
            }
            
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Services.Usuario usuario = new Services.Usuario();
            try
            {
            string msg = usuario.CerrarSesion();
                MessageBox.Show(msg);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            AlquilerForm alquiler = new AlquilerForm();
            alquiler.ShowDialog();
        }
    }
}
