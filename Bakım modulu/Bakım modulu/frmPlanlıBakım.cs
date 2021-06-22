using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Bakım_modulu
{
    public partial class frmPlanlıBakım : Form
    {
        public frmPlanlıBakım()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=bakımmodulu;UID=root;PWD='e9m915224';");
        DataSet daset = new DataSet();
        String bolum;
        private void txtPeriyot_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtPTarih.Text=="")
            {
                MessageBox.Show("Planlanan Tarih Girilmedi");
            }
            else if (txtBakım.Text=="")
            {
                MessageBox.Show("Aciklama Girilmedi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("update planlibakim set ptarih=@ptarih,is_durumu=@is_durumu,aciklama=@aciklama,bakim_faaliyeti=@bakim_faaliyeti,tarih=@tarih where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);

                    if (rdYapıldı.Checked)
                    {
                        komut.Parameters.AddWithValue("@is_durumu", rdYapıldı.Text);
                    }

                    else if (rdYapılmadı.Checked)
                    {
                        komut.Parameters.AddWithValue("@is_durumu", rdYapılmadı.Text);
                    }
                    else
                    {
                        MessageBox.Show("Seçim Yapılmadı");
                        komut.Parameters.AddWithValue("@is_durumu", dataGridView1.CurrentRow.Cells["is_durumu"].Value.ToString());
                    }
                    komut.Parameters.AddWithValue("@ptarih", txtPTarih.Text);
                    komut.Parameters.AddWithValue("@aciklama", txtAçıklama.Text);
                    komut.Parameters.AddWithValue("@bakim_faaliyeti", txtBakım.Text);
                    komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);

                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    daset.Tables["planlibakim"].Clear();
                    listele();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void frmPlanlıBakım_Load(object sender, EventArgs e)
        {
            txtAçıklama.MaxLength = 2000;
            listele();
            Yetki();
        }
        private void Yetki()
        {
            frmGiris giris = new frmGiris();

            if (frmGiris.yetki == "Formen")
            {
                radioHepsi.Enabled = false;

                radioButton14.Enabled = false;

                radioButton16.Enabled = false;
                radioButton17.Enabled = false;
                radioButton18.Enabled = false;
                radioButton19.Enabled = false;

                radioButton8.Enabled = false;
                radioButton21.Enabled = false;

            }
            if (frmGiris.yetki == "Mühendis")
            {
                radioHepsi.Enabled = false;
                radioButton17.Enabled = false;
                radioButton18.Enabled = false;
                radioButton19.Enabled = false;

                radioButton21.Enabled = false;
            }
        }
        private void listele()
        {
            baglanti.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM planlibakim", baglanti);
            adtr.Fill(daset, "planlibakim");
            dataGridView1.DataSource = daset.Tables["planlibakim"];
            baglanti.Close();
        }

        private void BakimFaaliyeti()
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAçıklama.Text = dataGridView1.CurrentRow.Cells["aciklama"].Value.ToString();
            txtBakım.Text = dataGridView1.CurrentRow.Cells["bakim_faaliyeti"].Value.ToString();
            txtPTarih.Text = dataGridView1.CurrentRow.Cells["ptarih"].Value.ToString();
            txtBakım.Text = dataGridView1.CurrentRow.Cells["bakim_faaliyeti"].Value.ToString();
        }

        private void txtAçıklama_TextChanged(object sender, EventArgs e)
        {
            int u = txtAçıklama.TextLength;
            lblSınır.Text = (0 + txtAçıklama.TextLength).ToString()+"/2000";
        }

        private void frmPlanlıBakım_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmsecim ac = new frmsecim();
            ac.Show();
        }

        private void btnSorgulama_Click(object sender, EventArgs e)
        {

            foreach (Control item in groupBox1.Controls)
            {

                if (item is RadioButton)
                {
                    RadioButton rb = item as RadioButton;

                    if (rb.Checked == true)
                    {
                        bolum = rb.Text;
                    }
                }
            }

            if (radioHepsi.Checked)
            {
                try
                {
                    baglanti.Open();
                    DataTable tablo = new DataTable();
                    MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM planlibakim where bakim_faaliyeti like '%" + txtBakımFaaliyetiSor.Text + "%'", baglanti);
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();
                }
                catch (Exception)
                {
                    ;
                }
            }
            else
            {
                baglanti.Open();
                DataTable tablo = new DataTable();
                MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM planlibakim where bakim_faaliyeti like '%" + txtBakımFaaliyetiSor.Text + "%' && bolge='" + bolum + "'", baglanti);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }

        }

       
    }  
}
