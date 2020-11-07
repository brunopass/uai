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
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services.Usuario usuario = new Usuario();
            try
            {
                string msg = usuario.crearUsuario(name.Text, email.Text, password.Text);
                MessageBox.Show(msg);
                this.Close();
            }catch(Exception error)
            {
                MessageBox.Show(error.Message, "error");
            }
        }
    }
}
