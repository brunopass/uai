using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace tpfinal
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services.Usuario usuario = new Usuario();
            try
            {
                string msg = usuario.iniciarSesion(email.Text, password.Text);
                MessageBox.Show(msg);
                this.Close();
            }catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
    }
}
