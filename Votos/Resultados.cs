using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Votos.Models;

namespace Votos
{
    public partial class Resultados : Form
    {
        public Resultados()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Title = "Politicos";
            chart1.ChartAreas[0].AxisY.Title = "Votos";
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;


 
            Series serie = chart1.Series["Series1"];
            
       
           
            using(VOTOSEntities db = new VOTOSEntities())
            {
                List<int> listvotos = db.Politicos.Select(r => r.votos).ToList();
                List<string> politicos = db.Politicos.Select(p => p.politico1).ToList();
                for(int i = 0; i < politicos.Count && i<listvotos.Count; i++)
                {
                    serie.Points.AddXY(politicos[i], listvotos[i]);
                    
                }
            }
           

        }
    }
}
