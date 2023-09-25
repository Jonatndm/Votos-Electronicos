using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Votos.Models;

namespace Votos
{
    public partial class NuevoUsuario : Form
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (VOTOSEntities db =  new VOTOSEntities())
            {
                Usuario usuario = new Usuario();

                usuario.nombres = textBox1.Text;
                usuario.apellidos = textBox2.Text;
                usuario.edad = int.Parse(textBox3.Text);

                if(usuario.edad >= 18)
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No es mayor de edad");
                }
                
            }
        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
