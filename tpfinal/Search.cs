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
    public partial class Search : Form
    {
        private string busqueda;
        public Search(string busqueda)
        {
            InitializeComponent();
            if (String.IsNullOrEmpty(busqueda))
            {
                throw new Exception("La busqueda no puede estar vacía");
            }
            textBox2.Text = busqueda;
            this.busqueda = busqueda;
        }

        private void buscar(string busqueda)
        {
            Services.Inmueble inmueble = new Services.Inmueble();
            List<Entities.Inmueble> inmuebles = inmueble.TraerInmuebles(busqueda);
            List<Card> cards = new List<Card>();

            if (inmuebles.Count == 0)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

            foreach (Entities.Inmueble _inmueble in inmuebles)
            {
                cards.Add(new Card(_inmueble.Id, _inmueble.Uri, _inmueble.Title, _inmueble.Ubication, _inmueble.Description, _inmueble.Stars, false));
            }

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Height = cards.Count * 270;
            foreach (Control control in cards)
            {
                flowLayoutPanel1.Controls.Add(control);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buscar(textBox2.Text);
        }

        private void Search_Load(object sender, EventArgs e)
        {
            buscar(busqueda);
        }
    }
}
