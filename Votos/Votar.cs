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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            RefreshVotantes();
            RefreshUsuarios();
        }
        #region HELPER
        private void RefreshVotantes()
        {
            using (VOTOSEntities db = new VOTOSEntities())
            {
                
                List<string> lista = db.Politicos.Select(item =>item.politico1).ToList();

                textBox1.Text = lista[0];
                textBox2.Text = lista[1];
                textBox3.Text = lista[2];
            }
        }
        #endregion

        #region HELPER
        private void RefreshUsuarios()
        {
            using (VOTOSEntities db = new VOTOSEntities())
            {

                List<string> lista = db.Usuarios.Select(e => e.nombres + " " + e.apellidos).ToList();
                
                
                foreach (var elem in lista)
                {
                    comboBox1.Items.Add(elem);
                }
                


            }
        }
        #endregion

        #region HELPER
        private void VotarP(string politica)
        {
            using (VOTOSEntities db = new VOTOSEntities())
            {
                int itemSelected = comboBox1.SelectedIndex;
                if(itemSelected >= 0 && itemSelected < comboBox1.Items.Count)
                {
                    var vota = db.Usuarios.Find(itemSelected + 1);
                    if(vota.ya_voto != true)
                    {
                        var politico = db.Politicos.FirstOrDefault(e => e.politico1 == politica);
                        if (politico != null)
                        {
                            politico.votos++;

                        }
                        if (vota != null)
                        {
                            vota.ya_voto = true;

                        }
                        MessageBox.Show("Se hizo el voto correctamente");

                    }
                    else
                    {
                        MessageBox.Show("Esta persona ya ha votado");
                    }
                    
                }
                    db.SaveChanges();



            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
          
            VotarP(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VotarP(textBox2.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            VotarP(textBox3.Text);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
