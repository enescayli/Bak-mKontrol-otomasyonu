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
    public partial class frmDevreKontrol : Form
    {
        public frmDevreKontrol()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=bakımmodulu;UID=root;PWD='e9m915224';");
        String nokta;
        private void frmDevreKontrol_Load(object sender, EventArgs e)
        {
            ekipmanGetir();
            listele();
            Renklendir();
        }

        private void listele()
        {
            baglanti.Open();
            DataTable tablo = new DataTable();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM devre_kontrol where sil_durumu=0", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[4].Visible = false;
            baglanti.Close();
        }

        private void Renklendir()
        {

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                double val = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());

                if ((String.Compare(dataGridView1.Rows[i].Cells[2].Value.ToString(), "CP701 1 NOLU EŞANJÖR SU GİRİŞ SICAKLIĞI - 1<x<2") == 0) && (val>2.0 || val < 1.0))
                {
 
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(231, 76, 60);
                    

                }

                if ((String.Compare(dataGridView1.Rows[i].Cells[2].Value.ToString(), "KESİCİ NUMARATÖRÜ   (x<3000)") == 0) && val > 3000)
                {

                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(231, 76, 60);

                }

                if ((String.Compare(dataGridView1.Rows[i].Cells[2].Value.ToString(), "KADEME DEĞİŞTİRİCİ NUMARATÖRÜ- x< 55400") == 0) && val> 55400)
                {

                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(231, 76, 60);

                }
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

        private void frmDevreKontrol_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmsecim ac = new frmsecim();
            ac.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("INSERT INTO kontrol_ekipman(kontrol_ekipmani) VALUES(@kontrol_ekipmani)", baglanti);

            komut.Parameters.AddWithValue("@kontrol_ekipmani", textBox1.Text);
         
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            baglanti.Close();

           
            listele();
            Renklendir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("INSERT INTO kontrol_nokta(ekipman_id,kontrol_noktasi) VALUES(@ekipman_id,@kontrol_noktasi)", baglanti);

            komut.Parameters.AddWithValue("@ekipman_id", textBox2.Text);
            komut.Parameters.AddWithValue("@kontrol_noktasi", textBox3.Text);

            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboEkipman.Text=="" || comboKontrol.Text=="" || txtDeger.Text=="")
            {
                MessageBox.Show("Boş alanlar var", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("INSERT INTO devre_kontrol(ekipman,nokta,deger) VALUES(@ekipman,@nokta,@deger)", baglanti);

                    komut.Parameters.AddWithValue("@ekipman", comboEkipman.Text);
                    komut.Parameters.AddWithValue("@nokta", comboKontrol.Text);
                    komut.Parameters.AddWithValue("@deger", Convert.ToDouble(txtDeger.Text));

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    baglanti.Close();
                    listele();
                    Renklendir();
                }
                catch (Exception)
                {
                    throw;
                }
            }
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

        private void txtDeger_KeyPress(object sender, KeyPressEventArgs e)
        {
         //  e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                
                MySqlCommand komut = new MySqlCommand("update devre_kontrol set deger=@deger where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);

                komut.Parameters.AddWithValue("@deger", Convert.ToDouble(txtDeger_.Text));
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Yapıldı");
                baglanti.Close();
             
                listele();
                Renklendir();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı değer girdiniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKontrolEkipmanı_.Text = dataGridView1.CurrentRow.Cells["ekipman"].Value.ToString();
            txtKontrolNoktası_.Text = dataGridView1.CurrentRow.Cells["nokta"].Value.ToString();
            txtDeger_.Text = dataGridView1.CurrentRow.Cells["deger"].Value.ToString();
        }

        private void comboKontrol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Emin misiniz?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("update  devre_kontrol set sil_durumu=1 where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti); ;
                komut.ExecuteNonQuery();
                baglanti.Close();
              
                listele();
                Renklendir();
                MessageBox.Show("Kayıt silindi");
            }
            else if (secenek == DialogResult.No)
            {

            }
        }
    }
}
