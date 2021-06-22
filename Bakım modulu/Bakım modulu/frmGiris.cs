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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand komut = new MySqlCommand();
        public DataSet ds = new DataSet();
        
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=bakımmodulu;UID=root;PWD='e9m915224';");
        bool login_durum;
        public static String hashSifre;
        public static String yetki,isim;
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SHA1 sha = new SHA1CryptoServiceProvider();
            hashSifre = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(txtSifre.Text)));
            MySqlCommand komut = new MySqlCommand("SELECT*FROM giris where BINARY  kullanici_adi='" + txtKullaniciAdi.Text + "' AND sifre= '"+hashSifre+"' AND sil_durumu=0",baglanti);     
            MySqlDataReader read = komut.ExecuteReader();
            if (read.Read())
            {
                
                yetki = read.GetValue(8).ToString();
                isim = read.GetValue(1).ToString()+" "+read.GetValue(2).ToString();

                hashSifre = read.GetValue(6).ToString();
                
                MessageBox.Show("Giriş Başarılı "+isim+"","Başarılı" ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                frmsecim ekle = new frmsecim();
                ekle.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Kullanıcı Bulunmadı");
            }
            baglanti.Close();
            
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            int min = txtKullaniciAdi.TextLength;
           
        }

        private void grpAdmin_Enter(object sender, EventArgs e)
        {
            int min_ = txtKullaniciAdi.TextLength;
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '•'; 
        }
        
        private void btnÇıkış_Click(object sender, EventArgs e)
        {          
            Application.Exit();
        }

    }
}
