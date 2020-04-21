using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _187102004_KemalYavuzİmer
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        #region Buton İşlemi
        private void btn_ögrenciler_MouseMove(object sender, MouseEventArgs e)
        {
            btn_ögrenciler.BackColor = Color.DarkRed;
            btn_ögrenciler.FlatStyle = FlatStyle.Popup;
        }

        private void btn_ögrenciler_MouseLeave(object sender, EventArgs e)
        {
            btn_ögrenciler.BackColor = Color.FromArgb(220, 53, 69);
            btn_ögrenciler.FlatStyle = FlatStyle.Flat;
        }
        
        private void btn_move(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;

            btn.BackColor = Color.DarkRed;
            btn.FlatStyle = FlatStyle.Popup;
        }

        private void btn_leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(220, 53, 69);
            btn.FlatStyle = FlatStyle.Flat;
        }
        

        private void cikis(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış Yapıldı");
            Form1 giris = new Form1();
            giris.Show();
            this.Hide();
        }


    }
}





