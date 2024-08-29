using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gravidade
{
    public partial class ParticleList : Form
    {
        public ParticleList()
        {
            InitializeComponent();
        }

        private void ParticleList_Load(object sender, EventArgs e)
        {
            Settings.pFormOpened = true;
            refreshToolStripMenuItem_Click(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void listView1_Click(object sender, EventArgs e)
        {
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            int i = -1;
            foreach (var particle in M.simulation.particles)
            {
                i++;
                listView1.Items.Add($"P #{i}: {particle.ToString()}");
            }
        }

        private void ParticleList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.pFormOpened = false;
        }
    }
}
