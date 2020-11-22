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
        public Search(string busqueda)
        {
            InitializeComponent();
            if (String.IsNullOrEmpty(busqueda))
            {
                throw new Exception("La busqueda no puede estar vacía");
            }
            textBox2.Text = busqueda;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
    }
}
