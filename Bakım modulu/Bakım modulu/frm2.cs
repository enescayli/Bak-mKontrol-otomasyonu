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
using System.Security.Cryptography;

namespace Bakım_modulu
{
    public partial class frm2 : Form
    {
        public frm2()
        {
            InitializeComponent();
        }
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand komut = new MySqlCommand();
        public DataSet ds = new DataSet();
        DataSet daset = new DataSet();

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=bakımmodulu;UID=root;PWD='e9m915224';");
        bool durum,login_durum;
        String agacBolum,hashSifre;



        private void frm2_Load(object sender, EventArgs e)
        {
            txtSifre_.PasswordChar = '•';
            txtTekrarSifre_.PasswordChar = '•';

            txtSifre__.PasswordChar = '•';
            txtTekrarSifre__.PasswordChar = '•';

            listele();
        }
        private void listele()
        {
            baglanti.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*From giris where sil_durumu=0 ", baglanti);
            adtr.Fill(daset, "giris");
            dataGridView1.DataSource = daset.Tables["giris"];
            dataGridView1.Columns[7].Visible = false;
            baglanti.Close(); 
        }
                
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   

        }

        private void txtNumara_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PersonelKontrol();

            if (txtKullanicAdi_.TextLength >3 && txtKullanicAdi_.TextLength < 11 && txtSifre_.TextLength > 3 && txtSifre_.TextLength <11 && login_durum && String.Compare(txtSifre_.Text, txtTekrarSifre_.Text) == 0)
            {
                foreach (Control item in groupBox1.Controls)
                {

                    if (item is RadioButton)
                    {
                        RadioButton rb = item as RadioButton;

                        if (rb.Checked == true)
                        {
                            agacBolum = rb.Text;
                            break;
                        }
                    }
                }

                try
                {
                    baglanti.Open();

                    MySqlCommand komut = new MySqlCommand("INSERT INTO giris(ad,soyad,telefon,email,kullanici_adi,sifre,yetki) VALUES(@ad,@soyad,@telefon,@email,@kullanici_adi,@sifre,@yetki)", baglanti);
                    SHA1 sha = new SHA1CryptoServiceProvider();
                    hashSifre = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(txtSifre_.Text)));




                    komut.Parameters.AddWithValue("@ad", txtAd_.Text);
                    komut.Parameters.AddWithValue("@soyad", txtSoyad_.Text);
                    komut.Parameters.AddWithValue("@telefon", txtTelNo_.Text);
                    komut.Parameters.AddWithValue("@email", txteMail_.Text);
                    komut.Parameters.AddWithValue("@kullanici_adi", txtKullanicAdi_.Text);
                    komut.Parameters.AddWithValue("@sifre", hashSifre);
                    komut.Parameters.AddWithValue("@yetki", agacBolum);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kullanıcı Eklendi", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (Control item in groupBox1.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = "";
                        }
                    }
                    baglanti.Close();
                     daset.Tables["giris"].Clear();
                    listele(); 
                }
                catch (Exception)
                {
                    MessageBox.Show("Beklenmedik Hata", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (login_durum == false)
            {
                MessageBox.Show("Bu kullanıcı adı daha önce kullanılmış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (String.Compare(txtSifre_.Text, txtTekrarSifre_.Text) != 0)
            {
                MessageBox.Show("Şifreler uyuşmuyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (txtSifre_.TextLength < 4 || txtSifre_.TextLength > 10)
            {
                MessageBox.Show("Şifre 4 karakterden küçük\n 10 karakterden büyük olamaz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtKullanicAdi_.TextLength < 4 || txtKullanicAdi_.TextLength > 10)
            {
                MessageBox.Show("Kullanıcı adı 4 karakterden küçük\n 10 karakterden büyük olamaz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Beklenmedik Durum");
                
            }
        }

        private void PersonelKontrol()
        {
            login_durum = true;
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("SELECT *FROM giris ", baglanti);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtKullanicAdi_.Text == read["kullanici_adi"].ToString())
                {
                    login_durum = false;
                }
                else if (txtTelNo_.Text == read["telefon"].ToString())
                {
                    MessageBox.Show("Bu Telefon Numrası Sistemde Kayıtlı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (txteMail_.Text == read["email"].ToString())
                {
                    MessageBox.Show("Bu email Sistemde Kayıtlı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            baglanti.Close();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKullanciadi__.Text = dataGridView1.CurrentRow.Cells["kullanici_adi"].Value.ToString();
            txtSifre__.Text = dataGridView1.CurrentRow.Cells["sifre"].Value.ToString();
            txtTekrarSifre__.Text = dataGridView1.CurrentRow.Cells["sifre"].Value.ToString();
            txtAd__.Text = dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
            txtSoyad__.Text = dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
            txtTel__.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtEmail__.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
            txtYetki__.Text = dataGridView1.CurrentRow.Cells["yetki"].Value.ToString();
        }

       bool engelle=false;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox && item.Text=="")
                {
                    engelle = true;
                    break;
                }
            }
            if (engelle)
            {
                MessageBox.Show("Boş alan var","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            else
            {
                try
                {
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("update giris set ad=@ad,soyad=@soyad,telefon=@telefon,email=@email,yetki=@yetki where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);

                    SHA1 sha = new SHA1CryptoServiceProvider();
                    hashSifre = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(txtSifre__.Text)));

                   
                    komut.Parameters.AddWithValue("@Ad", txtAd__.Text);
                    komut.Parameters.AddWithValue("@Soyad", txtSoyad__.Text);
                    komut.Parameters.AddWithValue("@Telefon", txtTel__.Text);
                    komut.Parameters.AddWithValue("@email", txtEmail__.Text);
                    komut.Parameters.AddWithValue("@yetki", txtYetki__.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme Yapıldı");
                    baglanti.Close();
                    daset.Tables["giris"].Clear();
                    listele();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }



        private void radioMuhendis_CheckedChanged(object sender, EventArgs e)
        {
            txtYetki__.Text = radioMuhendis.Text;
        }

        private void radioYonetici_CheckedChanged(object sender, EventArgs e)
        {
            txtYetki__.Text = radioYonetici.Text;
        }

        private void radioFormen_CheckedChanged(object sender, EventArgs e)
        {
            txtYetki__.Text = radioFormen.Text;
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            if ((txtKullanciadi__.TextLength < 4 || txtKullanciadi__.TextLength > 10) || (txtSifre__.TextLength < 4 || txtSifre__.TextLength > 10))
            {
                MessageBox.Show("Kullanıcı adı ve Şifre 4 karakterden küçük\n 10 karakterden büyük olamaz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.Compare(txtSifre__.Text, txtTekrarSifre__.Text) != 0)
            {
                MessageBox.Show("Şifreler uyuşmuyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("update giris set sifre=@sifre where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);

                    SHA1 sha = new SHA1CryptoServiceProvider();
                    hashSifre = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(txtSifre__.Text)));

                    komut.Parameters.AddWithValue("@sifre", hashSifre);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme Yapıldı");
                    baglanti.Close();
                    daset.Tables["giris"].Clear();
                    listele();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("update giris set sil_durumu=1 where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti); ;
                komut.ExecuteNonQuery();
                baglanti.Close();
                daset.Tables["giris"].Clear();
                listele();
                MessageBox.Show("Kayıt silindi");
            }
        }

        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmsecim ac = new frmsecim();
            ac.Show();
        }

    }
}
