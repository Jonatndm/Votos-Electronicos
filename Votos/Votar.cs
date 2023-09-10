using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Votos.Models;

namespace Votos
{
    public partial class Votar : Form
    {
        public Votar()
        {
            InitializeComponent();
        }

        private void Votar_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        #region HELPER
        private void Refresh()
        {
            using (VOTOSEntities db = new VOTOSEntities())
            {

                List<string> lista = db.Politicos.Select(item => item.politico1).ToList();

                textBox1.Text = lista[0];
                textBox2.Text = lista[1];
                textBox3.Text = lista[2];
            }
        }
        #endregion
    }
}
