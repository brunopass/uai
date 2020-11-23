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
    public partial class Contacto : Form
    {
        public Contacto(string name, string email, float price)
        {
            InitializeComponent();
            this.name.Text = name;
            this.email.Text = email;
            this.price.Text = $"${price}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Contacto_Load(object sender, EventArgs e)
        {

        }
    }
}
