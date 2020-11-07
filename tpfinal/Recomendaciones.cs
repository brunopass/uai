using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpfinal
{
    public partial class Recomendaciones : UserControl
    {
        public Recomendaciones(string des)
        {
            InitializeComponent();
            destino.Text = des;
        }

        private void Recomendaciones_Load(object sender, EventArgs e)
        {

        }
    }
}
