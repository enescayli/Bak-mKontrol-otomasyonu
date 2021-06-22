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
    public partial class frmPop_Up_Vardiya : Form
    {
        public frmPop_Up_Vardiya()
        {
            InitializeComponent();

        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=bakımmodulu;UID=root;PWD='e9m915224';");
        int result;
        Timer sayac;
      //  DateTime zaman;
        TimeSpan zaman;
        DataSet daset = new DataSet();
        private void frmPop_Up_Vardiya_Load(object sender, EventArgs e)
        {
            txtAçıklama_.MaxLength = 2000;
            txtAciklama_Var.MaxLength = 2000;

            TarihGetir();
            listele();
            personelgetir();
        }
        private void personelgetir()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select *from giris where sil_durumu=0", baglanti);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read()) // Kayıtlar okunduğu sürece...
            {
                comboPersonel.Items.Add(read["ad"].ToString()+" "+ read["soyad"].ToString());
            }
            baglanti.Close();
        }
        private void listele()
        {
            baglanti.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM varper where sil_durumu=0", baglanti);
            adtr.Fill(daset, "varper");
            dataGridView1.DataSource = daset.Tables["varper"];
            dataGridView1.Columns[8].Visible = false;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    result = DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value);
            //    zaman = (dateTimePicker1.Value.Subtract(dateTimePicker2.Value)).Duration();
            TimeSpan fark = (dateTimePicker2.Value.Subtract(dateTimePicker1.Value));
            if (comboPersonel.Text == "")
            {
                MessageBox.Show("Personel Seçimi yapılmadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            
            else if (fark.Hours < 0 || fark.Minutes<0) 
            {
                MessageBox.Show("Mesai Başlangıç Tarihinden\ndaha önce bir bitiş \ntarihi girdiniz");
            }
            else if (fark.Hours<5)
            {
                MessageBox.Show("5 saatten az bir mesai girdiniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (fark.Hours >14)
            {
                MessageBox.Show("Yüksek bir mesai süresi girdiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((((fark.Hours == 8 && fark.Minutes > 0) || fark.Hours > 8)) && txtAciklama_Var.Text == "")
            {
                MessageBox.Show("8 Saatten fazla mesai girilmesi durumunda \naçıklama girilmesi zorunludur"
                    , "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtAciklama_Var.Text == "")
                {
                    txtAciklama_Var.Text = "NORMAL MESAİ";
                }
                try
                {
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("INSERT INTO varper(personel,bas,bitis,aciklama,var_sur,var_bas,var_bit) VALUES(@personel,@bas,@bitis,@aciklama,@var_sur,@var_bas,@var_bit)", baglanti);

                    komut.Parameters.AddWithValue("@personel", comboPersonel.Text);
                    komut.Parameters.AddWithValue("@bas", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@bitis", dateTimePicker2.Text);
                    komut.Parameters.AddWithValue("@aciklama", txtAciklama_Var.Text);
                    komut.Parameters.AddWithValue("@var_sur", lblMesaiSuresi.Text);
                    komut.Parameters.AddWithValue("@var_bas", lblBasVardiya.Text);
                    komut.Parameters.AddWithValue("@var_bit", lblBitisVardiya.Text);

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    txtAciklama_Var.Text = "";
                    
                    MessageBox.Show("Kayıt Eklenmiştir", "Başarılı");
                    daset.Tables["varper"].Clear();
                    listele();
                }
                catch (Exception)
                {
                    throw;
                    // MessageBox.Show("Beklenmedik hata","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }                  
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TarihGetir();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            TarihGetir();
        }

        private void TarihGetir()
        {
            TimeSpan fark = (dateTimePicker2.Value.Subtract(dateTimePicker1.Value));
            if (fark.Hours<0)
            {
                MessageBox.Show("Mesai başlangıç tarihi\nBitiş Tarihinden büyük olamaz");
            }
            else
            {
                lblMesaiSuresi.Text = fark.Hours + "." + fark.Minutes;
            }
            
            lblBasVardiya.Text = dateTimePicker1.Value.ToLongDateString();
            lblBitisVardiya.Text = dateTimePicker2.Value.ToLongDateString();
 
        }

        private void lblVar_Sur_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAçıklama_.Text = dataGridView1.CurrentRow.Cells["aciklama"].Value.ToString();
            txtPersonel_.Text = dataGridView1.CurrentRow.Cells["personel"].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("update varper set sil_durumu=1 where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti); ;
                komut.ExecuteNonQuery();
                baglanti.Close();
                daset.Tables["varper"].Clear();
                listele();
                MessageBox.Show("Kayıt silindi");
            }
        }

        private void frmPop_Up_Vardiya_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmsecim ac = new frmsecim();
            ac.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("update varper set aciklama=@aciklama where id='"+dataGridView1.CurrentRow.Cells["id"].Value.ToString()+"'", baglanti);

                komut.Parameters.AddWithValue("@aciklama", txtAçıklama_.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Yapıldı");
                baglanti.Close();
                daset.Tables["varper"].Clear();
                listele();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtAciklama_Var_TextChanged(object sender, EventArgs e)
        {
            int u = txtAciklama_Var.TextLength;
            Lbl.Text = "2000/" + (0 + txtAciklama_Var.TextLength).ToString();

            if (u == 2000)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
            }
        }

        private void txtAçıklama__TextChanged(object sender, EventArgs e)
        {
            int u = txtAçıklama_.TextLength;
            Lbl2.Text = "2000/" + (0 + txtAçıklama_.TextLength).ToString();

            if (u == 2000)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
            }
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            TarihGetir();
        }
    }
}
