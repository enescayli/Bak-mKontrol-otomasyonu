using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakım_modulu
{
    public partial class frmsecim : Form
    {
        public frmsecim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ekle = new Form1();
            ekle.ShowDialog();           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm2 ekle = new frm2();
            ekle.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRaporlama ekle = new frmRaporlama();
            ekle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPlanlıBakım ekle = new frmPlanlıBakım();
            ekle.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBakımPlanlama ekle = new frmBakımPlanlama();
            ekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDevreKontrol ekle = new frmDevreKontrol();
            ekle.ShowDialog();
        }

        private void frmsecim_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGiris ac = new frmGiris();
            ac.Show();
        }

        private void frmsecim_Load(object sender, EventArgs e)
        {
            if (frmGiris.yetki == "Yönetici")
            {
                button6.Enabled = true;
                button4.Enabled = true;
            }
            if (frmGiris.yetki=="Mühendis")
            {
                button4.Enabled = true;
            }
        }
    }
}
