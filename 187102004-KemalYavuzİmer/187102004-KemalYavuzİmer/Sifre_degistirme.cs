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
    public partial class Sifre_degistirme : Form
    {
        public Sifre_degistirme()
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show(); this.Hide();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            btn_sifredegistir.BackColor = Color.DarkRed;
            btn_sifredegistir.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btn_sifredegistir.BackColor = Color.FromArgb(220, 53, 69);
            btn_sifredegistir.ForeColor = Color.White;
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.DarkRed;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sifre_degistirme_Load(object sender, EventArgs e)
        {
            güvenlik_sorusu();
        }
       
        private void btn_sifredegistir_Click(object sender, EventArgs e)
        {
                //if ((txt_sifre.Text == "" && materialSingleLineTextField2.Text == "") || comboBox1.SelectedIndex < 0 || txt_kullanici.Text == "" || txt_cevap.Text == "")
                //{
                //    MessageBox.Show("Boş olan yerleri doldurunuz");
                //    txt_cevap.Text = "";
                //    txt_kullanici.Text = ""; txt_sifre.Text = ""; materialSingleLineTextField2.Text = "";
                //    comboBox1.SelectedIndex = 0;
                //}
                //if (txt_sifre.Text != materialSingleLineTextField2.Text) MessageBox.Show("Farklı Şifreler Girdiniz, Lütfen Aynı Şifreleri Giriniz");
                //else
                //{
                //    SqlCommand sifre_degistir = new SqlCommand("update ADMIN set SIFRE=@sifre where  GUVENLIKSORUID=@soru and GUVENLIKCEVAP=@cevap", bgl.baglanti());
                //    sifre_degistir.Parameters.AddWithValue("@soru", comboBox1.SelectedValue);
                //    sifre_degistir.Parameters.AddWithValue("@cevap", txt_cevap.Text);
                //    sifre_degistir.Parameters.AddWithValue("@sifre", txt_sifre.Text);
                //    sifre_degistir.ExecuteNonQuery();
                //    bgl.baglanti().Close();
                //    MessageBox.Show("Şifreniz Değiştirilimiştir Giriş Yapabilirsiniz");
                //    Form1 giris = new Form1();
                //    giris.Show();
                //    this.Hide();
                //}
            
        }

       
    }
}
