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
using Services;
using Entities;

namespace tpfinal
{
    public partial class inmuebleView : Form
    {
        private string _id;
        private Entities.Inmueble inmueble;
        public inmuebleView(string _id)
        {
            InitializeComponent();
            try
            {
                Services.Inmueble _inmueble= new Services.Inmueble();
                this.inmueble = _inmueble.TraerInmueble(_id);
                byte[] byteBuffer = Convert.FromBase64String(inmueble.Uri);
                MemoryStream memoryStream = new MemoryStream(byteBuffer);
                Bitmap bitmap = new Bitmap(Bitmap.FromStream(memoryStream));
                pictureBox2.Image = bitmap;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                titulo.Text = inmueble.Title;
                ubicacion.Text = inmueble.Ubication + " - " + inmueble.Address;
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
                this._id = _id;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void inmuebleView_Load(object sender, EventArgs e)
        {
            string[] calificaciones = {"1","2","3","4","5"};
            calificacion.Items.AddRange(calificaciones);
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

            try
            {
                Services.Inmueble inmueble = new Services.Inmueble();
                List<Entities.Comentario> comentarios = inmueble.TraerComentarios(_id);

                List<Comentario> componentesComentario = new List<Comentario>();

                foreach (Entities.Comentario _comentario in comentarios)
                {
                    componentesComentario.Add(new Comentario(_comentario));
                }

                flowLayoutPanel2.AutoScroll = true;
                flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel2.WrapContents = false;
                flowLayoutPanel2.Height = comentarios.Count * 160;
                foreach (Control control in componentesComentario)
                {
                    flowLayoutPanel2.Controls.Add(control);
                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
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
                loggedTab.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Services.Usuario user = new Services.Usuario();
                Entities.Usuario usuario = user.TraerUsuario(inmueble.Id);
                Contacto contacto = new Contacto(usuario.Nombre,usuario.Email,inmueble.Price);
                contacto.ShowDialog();
            }catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Services.Inmueble inmueble = new Services.Inmueble();
            try
            {
                string msg = inmueble.AgregarFavoritos(_id);
                MessageBox.Show(msg);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
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

        private void label14_Click(object sender, EventArgs e)
        {
            Services.Usuario usuario = new Services.Usuario();
            try
            {
                string msg = usuario.CerrarSesion();
                MessageBox.Show(msg);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Services.Inmueble inmueble = new Services.Inmueble();

            try
            {
                string msg = inmueble.AgregarComentario(new Entities.Comentario(_id, comentario.Text, int.Parse(calificacion.Text)));
                MessageBox.Show(msg);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            MisAlquileres misAlquileres = new MisAlquileres();
            misAlquileres.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Favoritos favoritos = new Favoritos();
            favoritos.ShowDialog();
        }
    }
}
