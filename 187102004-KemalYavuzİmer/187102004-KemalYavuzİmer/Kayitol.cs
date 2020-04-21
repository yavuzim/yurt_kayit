using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
namespace _187102004_KemalYavuzİmer
{
    public partial class Kayitol : Form
    {
        public Kayitol()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();

        #region Güvenlik Soruları
        void güvenlik_sorusu()
        {
            SqlDataAdapter listele = new SqlDataAdapter("Select *from GUVENLIK_SORUSU", bgl.baglanti());
            DataTable dt = new DataTable();
            listele.Fill(dt);
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "GUVENLIKSORU";
            comboBox1.DataSource = dt;
        }
        #endregion
        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.DarkRed;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show(); this.Hide();
        }

        private void Kayitol_Load(object sender, EventArgs e)
        {
            güvenlik_sorusu();
        }
        bool durum = false;
        void kullanici_kontrol()
        {
            SqlCommand kontrol = new SqlCommand("Select *from ADMIN where KULLANICI=@p", bgl.baglanti());
            kontrol.Parameters.AddWithValue("@p", txt_kullanici.Text);
            SqlDataReader oku = kontrol.ExecuteReader();
            if (oku.Read())
                durum = true;
            else
                durum = false;
        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (txt_soyad.Text.Trim() == "" || txt_cevap.Text.Trim() == "" || txt_kullanici.Text.Trim() == "" || txt_sifre.Text.Trim() == "" || comboBox1.SelectedIndex < 0 || txt_ad.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız");
                txt_ad.Text = ""; txt_cevap.Text = ""; txt_kullanici.Text = ""; txt_sifre.Text = ""; txt_soyad.Text = ""; txt_ad.Focus();
            }
            else
            {

                kullanici_kontrol();
                if (durum == true)
                {
                    MessageBox.Show("Bu Kullanıcı Adı Zaten Alındı");
                    txt_kullanici.Text = "";
                }
                else
                {

                    string isim,cevap;
                    isim = txt_ad.Text;
                    cevap = txt_cevap.Text;
                    isim = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(isim);
                    cevap = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cevap);
                    SqlCommand kaydol = new SqlCommand("insert into ADMIN (PERSONELAD,PERSONELSOYAD,GUVENLIKSORUID,GUVENLIKCEVAP,KULLANICI,SIFRE) values (@ad,@soyad,@soru,@cevap,@kullanici,@sifre)", bgl.baglanti());
                    kaydol.Parameters.AddWithValue("@ad", isim);
                    kaydol.Parameters.AddWithValue("@soyad", txt_soyad.Text.ToUpper());
                    kaydol.Parameters.AddWithValue("@soru", comboBox1.SelectedValue);
                    kaydol.Parameters.AddWithValue("@cevap", cevap);
                    kaydol.Parameters.AddWithValue("@kullanici", txt_kullanici.Text);
                    kaydol.Parameters.AddWithValue("@sifre", txt_sifre.Text);
                    kaydol.ExecuteNonQuery();
                    MessageBox.Show("Sisteme Giriş Yapabilirsiniz");
                    Form1 giris = new Form1();
                    giris.Show(); this.Hide();
                }
                
                                  
            }
        }

        private void txt_ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
           
        }

        private void txt_soyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
            
        }
    }
}
