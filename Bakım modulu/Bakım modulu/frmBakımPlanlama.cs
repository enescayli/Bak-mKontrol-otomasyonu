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
    public partial class frmBakımPlanlama : Form
    {
        public frmBakımPlanlama()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=bakımmodulu;UID=root;PWD='e9m915224';");
        String bolum;
        DataSet daset = new DataSet();
        private void frmBakımPlanlama_Load(object sender, EventArgs e)
        {
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
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM bakimplanlama", baglanti);
            adtr.Fill(daset, "bakimplanlama");
            dataGridView1.DataSource = daset.Tables["bakimplanlama"];
            baglanti.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            if (radioHepsi.Checked)
            {
                MessageBox.Show("Bölüm Seçimi Yapılmadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           else if (bolum == "")
            {
                MessageBox.Show("Bölüm Seçimi Yapılmadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtBakım.Text == "")
            {
                MessageBox.Show("Bakım Faaliyeti Seçilmedi ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPeriyot.Text == "")
            {
                MessageBox.Show("Periyot Girilmedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtİlkBakım.Text=="")
            {
                MessageBox.Show("İlk Bakım Girilmedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("INSERT INTO bakimplanlama(bakim_faaliyeti,periyot,tarih,bolge,ilk_bakim) VALUES(@bakim_faaliyeti,@periyot,@tarih,@bolge,@ilk_bakim)", baglanti);
                    MySqlCommand komut2 = new MySqlCommand("INSERT INTO planlibakim(bakim_faaliyeti,is_durumu,bolge,tarih) VALUES(@bakim_faaliyeti,@is_durumu,@bolge,@tarih)", baglanti);


                    komut.Parameters.AddWithValue("@bakim_faaliyeti", txtBakım.Text);
                    komut.Parameters.AddWithValue("@periyot", txtPeriyot.Text);
                    komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@bolge", bolum);
                    komut.Parameters.AddWithValue("@ilk_bakim", txtİlkBakım.Text + ".Hafta");

                    komut2.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
                    komut2.Parameters.AddWithValue("@bakim_faaliyeti", txtBakım.Text);
                    komut2.Parameters.AddWithValue("@is_durumu", "Yapılmadı");
                    komut2.Parameters.AddWithValue("@bolge", bolum);

                    komut.ExecuteNonQuery();
                    komut2.ExecuteNonQuery();

                    baglanti.Close();

                    daset.Tables["bakimplanlama"].Clear();
                    listele();

                    foreach (Control item in this.Controls)
                    {

                        if (item is TextBox)
                        {
                            item.Text = "";
                        }

                    }
                }
                catch (Exception)
                {
                    //       MessageBox.Show("Beklenmedik Hata");
                    throw;
                }
            }
        }

        private void txtİlkBakım_KeyPress(object sender, KeyPressEventArgs e)
        {
          e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPeriyot_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }



        private void frmBakımPlanlama_FormClosed(object sender, FormClosedEventArgs e)
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
                    MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM bakimplanlama where bakim_faaliyeti like '%" + txtBakımFaaliyetiSor.Text + "%'", baglanti);
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
                MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM bakimplanlama where bakim_faaliyeti like '%" + txtBakımFaaliyetiSor.Text + "%' && bolge='" + bolum + "'", baglanti);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBakımFaaliyeti_g.Text = dataGridView1.CurrentRow.Cells["bakim_faaliyeti"].Value.ToString();
            txtPeriyot_g.Text = dataGridView1.CurrentRow.Cells["periyot"].Value.ToString();
            txtİlkBakım_g.Text = dataGridView1.CurrentRow.Cells["ilk_bakim"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("update bakimplanlama set bakim_faaliyeti=@bakim_faaliyeti,periyot=@periyot,ilk_bakim=@ilk_bakim,tarih=@tarih where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);

            komut.Parameters.AddWithValue("@bakim_faaliyeti", txtBakımFaaliyeti_g.Text);
            komut.Parameters.AddWithValue("@periyot", txtPeriyot_g.Text);
            komut.Parameters.AddWithValue("@ilk_bakim", txtİlkBakım_g.Text);
            komut.Parameters.AddWithValue("@tarih",dateTimePicker1.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Yapıldı");
            baglanti.Close();
            daset.Tables["bakimplanlama"].Clear();
            listele();
        }
    }
}

