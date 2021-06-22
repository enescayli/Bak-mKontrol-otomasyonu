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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=bakımmodulu;UID=root;PWD='e9m915224';");
        bool durum;
        String isTuru,agacBolum="bölüm";
        String gelenYetki;
        String sorgu;
        List<String> Liste = new List<String>();
        List<String> Liste_2 = new List<String>();
        DataSet daset = new DataSet();
        
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm2 ekle = new frm2();
            ekle.ShowDialog();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int u = txt_rich_aciklama.TextLength;
            Lbl.Text = "2000/" + (0+txt_rich_aciklama.TextLength).ToString();
            
            if (u == 2000)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
            }
        }
        private void durumkontrol()
        {
            durum = true;
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("SELECT *FROM vararza", baglanti);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (/*textBox1.Text == read["personel"].ToString() || */ txt_rich_aciklama.Text == "")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void personelgetir()
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select *from giris where sil_durumu=0", baglanti);
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read()) // Kayıtlar okunduğu sürece...
            {
                comboPersonel.Items.Add(read["ad"].ToString()+" "+read["soyad"].ToString());
            }
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_rich_aciklama.MaxLength = 2000;
            txtAçıklama.MaxLength = 2000;
            personelgetir();
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
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM vararza where sil_durumu=0", baglanti);
            adtr.Fill(daset, "vararza");
            dataGridView1.DataSource = daset.Tables["vararza"];
            dataGridView1.Columns[7].Visible = false;
            baglanti.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (radioHepsi.Checked)
            {
                MessageBox.Show("Bölge Seçilmedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtdurusSuresi.Text=="")
            {
                MessageBox.Show("Duruş Süresi Girilmedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (comboPersonel.Text=="")
            {
                MessageBox.Show("Personel Seçilmedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (txt_rich_aciklama.Text=="")
            {
                MessageBox.Show("Açıklama Girilmedş", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (radioButton1.Checked==false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("İş Türü Seçimi Yapılmadı..","Uyarı", MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }

            else
            {
                foreach (Control item in groupBox1.Controls)
                {

                    if (item is RadioButton)
                    {
                        RadioButton rb = item as RadioButton;

                       if (rb.Checked==true)
                        {
                            agacBolum = rb.Text;
                            break;
                        }
                    }
                }

                if (agacBolum == "Bölüm")
                {
                    {
                        MessageBox.Show("Bölüm Seçimi Yapılmadı..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
              

                else
                {
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("INSERT INTO vararza(personel,aciklama,is_turu,durus_suresi,tarih,bolum) VALUES(@personel,@aciklama,@is_turu,@durus_suresi,@tarih,@bolum)", baglanti);

                    komut.Parameters.AddWithValue("@personel", comboPersonel.Text);
                    komut.Parameters.AddWithValue("@aciklama", txt_rich_aciklama.Text);
                    komut.Parameters.AddWithValue("@is_turu", isTuru);
                    komut.Parameters.AddWithValue("@durus_suresi", txtdurusSuresi.Text);
                    komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToString());
                    komut.Parameters.AddWithValue("@bolum", agacBolum);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Eklendi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    baglanti.Close();

                    daset.Tables["vararza"].Clear();
                    listele();

                    foreach (Control item in this.Controls)
                    {

                        if (item is RichTextBox && item != txtAçıklama || item is ComboBox)
                        {
                            item.Text = "";
                        }

                    }
                } 
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isTuru = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            isTuru = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            isTuru = radioButton3.Text;
        }

        private void txtdurusSuresi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAçıklama.Text = dataGridView1.CurrentRow.Cells["aciklama"].Value.ToString();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAçıklama.Text = dataGridView1.CurrentRow.Cells["aciklama"].Value.ToString();
            txtPersonel.Text = dataGridView1.CurrentRow.Cells["personel"].Value.ToString();
            txtİşTürü_txt.Text = dataGridView1.CurrentRow.Cells["is_turu"].Value.ToString();
            txtDuruş_Süresi_txt.Text = dataGridView1.CurrentRow.Cells["durus_suresi"].Value.ToString();
            txtTarih.Text = dataGridView1.CurrentRow.Cells["tarih"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          DialogResult secenek =  MessageBox.Show("Emin misiniz?","DİKKAT",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            
            if (secenek==DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("update  vararza  set sil_durumu=1 where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti); ;
                komut.ExecuteNonQuery();
                baglanti.Close();
                daset.Tables["vararza"].Clear();
                listele();
                MessageBox.Show("Kayıt silindi");
            }
            else if (secenek==DialogResult.No)
            {

            }

        }

        private void txtPersonel__TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_Açıklama_Filtre_TextChanged(object sender, EventArgs e)
        {
        }

        private void btDetaylıArama_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            btnFiltrele.Visible = true;

        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {

            Liste.Clear();

            foreach (Control item in groupBox2.Controls)
            {
                CheckBox cb = item as CheckBox;
                
                if (item is CheckBox && cb.Checked)
                {
                    Liste.Add("'"+item.Text+"'");
                   sorgu = String.Join(",",Liste);                  
                }
            }

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
            try
              {
                if (radioHepsi.Checked==true)
                {
                    baglanti.Open();
                    DataTable tablomn = new DataTable();                                                 
                    MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM vararza WHERE is_turu in(" + sorgu + ") && personel like '%"+txtPersonel_.Text+ "%' && aciklama like '%" + txt_Açıklama_Filtre.Text + "%'", baglanti);
                    adtr.Fill(tablomn);
                    dataGridView1.DataSource = tablomn;
                    dataGridView1.Columns[7].Visible = false;
                    baglanti.Close();
                }
                else
                {
                    baglanti.Open();
                    DataTable tablomn = new DataTable();                                                  
                    MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM vararza WHERE is_turu in(" + sorgu + ") && bolum='" + bolum + "' && personel like '%" + txtPersonel_.Text + "%' && aciklama like '%" + txt_Açıklama_Filtre.Text + "%'", baglanti);
                    adtr.Fill(tablomn);
                    dataGridView1.DataSource = tablomn;
                    dataGridView1.Columns[7].Visible = false;
                    baglanti.Close();
                }

              }
            catch (Exception)
              {
                ;
                //  MessageBox.Show("Beklenmedk Hata");
              }          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
       //     groupBox3.Visible = false;
            btnFiltrele.Visible = false;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txt_rich_aciklama.Text != "")
            {
                e.Cancel = true;
                DialogResult seceneek = MessageBox.Show("Açıklama Alanı Dolu", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmPop_Up_Vardiya pop = new frmPop_Up_Vardiya();
            pop.ShowDialog();
        }

        String bolum;

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmsecim ac = new frmsecim();
            ac.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("update vararza set aciklama=@aciklama where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);

                komut.Parameters.AddWithValue("@aciklama", txtAçıklama.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Yapıldı");
                baglanti.Close();
                daset.Tables["vararza"].Clear();
                listele();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtAçıklama_TextChanged(object sender, EventArgs e)
        {
            int u = txtAçıklama.TextLength;
            Lbl2.Text = "2000/" + (0 + txtAçıklama.TextLength).ToString();

            if (u == 2000)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox1.Controls)
            {

                if (item is RadioButton)
                {
                    RadioButton rb = item as RadioButton;

                    if (rb.Checked == true)
                    {
                        if (rb==radioHepsi)
                        {
                            bolum ="";
                            break;
                        }
                        else
                        {
                            bolum = rb.Text;
                            break;
                        }

                    }
                }
            }

            try
            {
                baglanti.Open();
                DataTable tablom = new DataTable();                                                  
                MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT*FROM vararza WHERE bolum like '%"+bolum+"%'", baglanti);
                adtr.Fill(tablom);
                dataGridView1.DataSource = tablom;
                dataGridView1.Columns[7].Visible = false;
                baglanti.Close();
                
            }
            catch (Exception)
            {
                ;
                //  MessageBox.Show("Beklenmedk Hata");
            }
        }
    }
}
