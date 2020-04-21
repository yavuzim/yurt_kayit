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

namespace _187102004_KemalYavuzİmer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Sqlbaglantisi baglan = new Sqlbaglantisi();
        int hak = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_kullanici.Text == "" || txt_sifre.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adınızı veya Şifrenizi Girin");
                txt_kullanici.Focus();
                txt_kullanici.Text = ""; txt_sifre.Text = "";
            }
               
            else
            {
               
                SqlCommand giris = new SqlCommand("Select *from ADMIN where KULLANICI=@kullanici and SIFRE=@sifre", baglan.baglanti());
                giris.Parameters.AddWithValue("@kullanici", txt_kullanici.Text);
                giris.Parameters.AddWithValue("@sifre", txt_sifre.Text);
                SqlDataReader oku = giris.ExecuteReader();
                if (oku.Read())
                {
                    Anasayfa anasayfa = new Anasayfa();
                    anasayfa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Şifre yada kullanıcı adınız yanlış", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_kullanici.Focus();
                    txt_kullanici.Text = ""; txt_sifre.Text = "";
                    hak--;
                    if (hak == 0)
                    {
                        MessageBox.Show("Sisteme 3 kere yanlış girdiniz", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Sifre_degistirme sfr = new Sifre_degistirme();
                        sfr.Show(); this.Hide();
                    }
                }
                baglan.baglanti().Close();
            }
                  
        }

        private void pictureBox1_Click(object sender, EventArgs e) //Çıkış Yap
        {
            this.Close();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.DarkRed;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(220, 53, 69);
            button1.ForeColor = Color.White;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.ForeColor = Color.DarkRed;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.DarkRed;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e) // Şifremi Unuttum
        {
            Sifre_degistirme sifre = new Sifre_degistirme();
            sifre.Show();
            this.Hide();
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            label6.ForeColor = Color.DarkRed;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Kayitol kayit = new Kayitol();
            kayit.Show(); this.Hide();
        }
    }
}
