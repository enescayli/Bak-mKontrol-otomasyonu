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
    public partial class frmRaporlama : Form
    {
        public frmRaporlama()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=bakımmodulu;UID=root;PWD='e9m915224';");
        DataSet daset = new DataSet();
        String bolum;
        private void frmRaporlama_Load(object sender, EventArgs e)
        {
            ekipmanGetir();
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
        private void ekipmanGetir()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select *from kontrol_ekipman", baglanti);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read()) // Kayıtlar okunduğu sürece...
            {
                comboEkipman.Items.Add(read["kontrol_ekipmani"].ToString());

            }
            baglanti.Close();
        }
        private void FazlaMesaiRapor()
        {
            try
            {
              
                baglanti.Open();
                DataTable tablom = new DataTable();
                MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM varper WHERE var_sur>8 &&  personel like '%" + txtAd.Text + "%' && aciklama like '%" + txtAciklama_Var.Text + "%'&& sil_durumu=0", baglanti);
                adtr.Fill(tablom);
                dataGridView1.DataSource = tablom;
                dataGridView1.Columns[8].Visible = false;
                baglanti.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnFezlaMesai_Click(object sender, EventArgs e)
        {
            txtAd.Visible = true;
            txtAciklama_Var.Visible = true;
            lblAdSoyad.Visible = true;
            lblToplamDurustext.Visible = false;
            lblToplamDuruş.Visible = false;
            dataGridView1.Visible = true;
            chart1.Visible = false;
            grupSorgu.Visible = false;

            FazlaMesaiRapor();
        }

        private void btnVardiya_Click(object sender, EventArgs e)
        {
            VardiyaDefteriRapor();
        }

        private void VardiyaDefteriRapor()
        {
            foreach (Control item in groupBox1.Controls)
            {

                if (item is RadioButton)
                {
                    RadioButton rb = item as RadioButton;

                    if (rb.Checked == true)
                    {
                            bolum = rb.Text;
                            break;
                    }
                }
            }

            if (radioHepsi.Checked == true)
            {
                try
                {
                    baglanti.Open();
                    DataTable tablomn = new DataTable();
                    MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM vararza WHERE personel like '%" + txtAd.Text + "%' && aciklama like '%" + txtAciklama_Var.Text + "%' && sil_durumu=0", baglanti);
                    
                    MySqlCommand komut = new MySqlCommand("SELECT SUM(durus_suresi) FROM vararza WHERE personel like '%" + txtAd.Text + "%' && aciklama like '%" + txtAciklama_Var.Text + "%' && sil_durumu=0 ", baglanti);
                    lblToplamDuruş.Text = komut.ExecuteScalar() + " Dakika";

                    adtr.Fill(tablomn);
                    dataGridView1.DataSource = tablomn;
                    dataGridView1.Columns[7].Visible = false;
                    baglanti.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Beklenmedik Hata","DİKKAT",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    txtAd.Visible = true;
                    txtAciklama_Var.Visible = true;
                    lblAdSoyad.Visible = true;
                    lblToplamDurustext.Visible = true;
                    lblToplamDuruş.Visible = true;
                    dataGridView1.Visible = true;
                    chart1.Visible = false;
                    grupSorgu.Visible = false;

                    baglanti.Open();
                    DataTable tablom = new DataTable();
                    MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM vararza where personel like '%" + txtAd.Text + "%' && aciklama like '%" + txtAciklama_Var.Text + "%' && bolum='"+bolum+"' && sil_durumu=0", baglanti);
                    
                    MySqlCommand komut = new MySqlCommand("SELECT SUM(durus_suresi) FROM vararza where personel like '%" + txtAd.Text + "%' && aciklama like '%" + txtAciklama_Var.Text + "%' && bolum='" + bolum + "' && sil_durumu=0", baglanti);

                    lblToplamDuruş.Text = komut.ExecuteScalar()+" Dakika";
                                      
                    adtr.Fill(tablom);
                    dataGridView1.DataSource = tablom;
                    dataGridView1.Columns[7].Visible = false;
                    baglanti.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDevreKontrol_Click(object sender, EventArgs e)
        {
            txtAd.Visible = false;
            txtAciklama_Var.Visible = false;
            lblAdSoyad.Visible = false;
            lblToplamDurustext.Visible = false;
            lblToplamDuruş.Visible = false;
            dataGridView1.Visible = false;
            chart1.Visible = true;
            grupSorgu.Visible = true;
        }

        private void btnPlanlıBakım_Click(object sender, EventArgs e)
        {
            txtAd.Visible = false;
            txtAciklama_Var.Visible = false;
            lblAdSoyad.Visible = false;
            lblToplamDurustext.Visible = false;
            lblToplamDuruş.Visible = false;
            dataGridView1.Visible = true;
            chart1.Visible = false;
            grupSorgu.Visible = false;

            baglanti.Open();
            DataTable tablo = new DataTable();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*From planlibakim ", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnAdSoyadFitreMesai_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAciklama_Var.Text = dataGridView1.CurrentRow.Cells["aciklama"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime tarih1 = dateTimePicker1.Value;
            DateTime tarih2 = dateTimePicker2.Value;
        }

        private void frmRaporlama_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmsecim ac = new frmsecim();
            ac.Show();
        }

        private void comboEkipman_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboKontrol.Items.Clear();
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select *from kontrol_nokta where ekipman_id='" + comboEkipman.SelectedItem + "'", baglanti);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read()) // Kayıtlar okunduğu sürece...
            {
                comboKontrol.Items.Add(read["kontrol_noktasi"].ToString());

            }
            baglanti.Close();
        }

        String sorgu;
        private void btnSorgu_Click(object sender, EventArgs e)
        {
            chart1.Series["değer"].Points.Clear();
            
            baglanti.Open();
           sorgu = comboKontrol.Text;
           MySqlCommand komut = new MySqlCommand("select *from devre_kontrol where nokta='" + sorgu + "'", baglanti);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read()) // Kayıtlar okunduğu sürece...
            {
                this.chart1.Series["değer"].Points.AddXY("değer", read["deger"].ToString());

            }
            
            baglanti.Close();
        }
    }
}
