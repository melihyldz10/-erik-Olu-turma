using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
namespace Proje
{
    public partial class Login : Form
    {
        Veritabani veri = new Veritabani();
        int Move;
        int Mouse_X;
        int Mouse_Y;
        public static string kAdi;
        public static int id;
        MessageBoxButtons Ok = MessageBoxButtons.OK;//MessageBoxlar.

        public Login()
        {
            InitializeComponent();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }



        string SifreCoz;
        private void button1_Click(object sender, EventArgs e)
        {
            SifreCoz = Sifreleme.MD5Sifrele(txt_sifre.Text);

            if ((txt_Ad.Text != "") && (txt_sifre.Text != ""))
            {

                SqlConnection baglanti = veri.BaglantiAc();
                SqlCommand komut = new SqlCommand("SELECT * FROM Kullanici where Kullanici_Ad=@kAd and sifre=@sifre ", baglanti);
                komut.Parameters.AddWithValue("@kAd", txt_Ad.Text);
                komut.Parameters.AddWithValue("@sifre", SifreCoz);
                SqlDataReader okuyucu = komut.ExecuteReader();

                if (okuyucu.Read())
                {
                    MessageBox.Show("Tebrikler Başarıyla Giriş Yaptınız ","Creative Content Hoş Geldiniz ");
                    kAdi = okuyucu["Kullanici_Ad"].ToString();
                    id = Convert.ToInt32(okuyucu["id"]);
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Dikkat!!. Lütfen Kullanıcı Adınızı ve Şifrenizi Kontrol Ediniz!", "Creative Content", Ok, MessageBoxIcon.Warning);
                }
                veri.BaglantiKapat();
            }
            else {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre Alanlarını boş Bırakmayınız Kontrol Edip Tekrar Deneyiniz!!", "Creative Content", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void color(TextBox a, Panel b)
        {
            a.BackColor = SystemColors.Control;
            b.BackColor = SystemColors.Control;
        }
        public void colorWhite(TextBox a, Panel b)
        {
            a.Clear();
            a.BackColor = Color.White;
            b.BackColor = Color.White;
        }

        private void txt_Ad_Click(object sender, EventArgs e)
        {
             colorWhite(txt_Ad, panel4);
             color(txt_sifre, panel5);
        }

       

        private void txt_sifre_Click(object sender, EventArgs e)
        {
            color(txt_Ad, panel4);
            colorWhite(txt_sifre, panel5);
        }

        private void pictureBox_hide_MouseDown(object sender, MouseEventArgs e)
        { //şifre saklar
            txt_sifre.UseSystemPasswordChar = false;
        }

        private void pictureBox_hide_MouseUp(object sender, MouseEventArgs e)
        {  //şifre göster
            txt_sifre.UseSystemPasswordChar = true;
        }


        private void btn_LKayıt_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }


        /*panel hareket ettirme işlemleri*/
        private void panel6_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        //minimize işlemi
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    
        /*Finish*/

    }
}
