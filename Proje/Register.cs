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
namespace Proje
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        Veritabani veri = new Veritabani();//db baglantisi
        int Move;
        int Mouse_X;
        int Mouse_Y;

        //btn close ve minimize
        private void btn_Registerclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //finish

        private void Register_Load(object sender, EventArgs e)
        {
         
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


        private void txt_AdSoyad_Click(object sender, EventArgs e)
        {
      
            colorWhite(txt_AdSoyad, panel7);
            color(txt_RegisterKad, panel4);
            color(txt_Email, panel6);
            color(txt_Registersifre, panel5);
        }

        private void txt_RegisterKad_Click(object sender, EventArgs e)
        {
            color(txt_AdSoyad, panel7);
            colorWhite(txt_RegisterKad, panel4);
            color(txt_Email, panel6);
            color(txt_Registersifre, panel5);
        }

        private void txt_Email_Click(object sender, EventArgs e)
        {
            color(txt_AdSoyad, panel7);
            color(txt_RegisterKad, panel4);
            colorWhite(txt_Email, panel6);
            color(txt_Registersifre, panel5);
        }

        private void txt_Registersifre_Click(object sender, EventArgs e)
        {
            color(txt_AdSoyad, panel7);
            color(txt_RegisterKad, panel4);
            color(txt_Email, panel6);
            colorWhite(txt_Registersifre, panel5);
        }

        private void pictureBox_hide_MouseDown(object sender, MouseEventArgs e)
        {
            txt_Registersifre.UseSystemPasswordChar = false;

        }

        private void pictureBox_hide_MouseUp(object sender, MouseEventArgs e)
        {
            txt_Registersifre.UseSystemPasswordChar = true;
        }

        private void btn_Rgiris_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        string SifreCevir;

        private void btn_Kayıt_Click(object sender, EventArgs e)
        {
            SifreCevir = Sifreleme.MD5Sifrele(txt_Registersifre.Text);
            if ((txt_AdSoyad.Text != "") && (txt_RegisterKad.Text != "") && (txt_Email.Text != "") && (txt_Registersifre.Text != ""))
            {
                SqlConnection baglan = veri.BaglantiAc();
                SqlCommand kontrol = new SqlCommand("SELECT * FROM Kullanici where Kullanici_Ad=@K_ad ", baglan);
                kontrol.Parameters.AddWithValue("@K_ad", txt_RegisterKad.Text);
                SqlDataReader okuma = kontrol.ExecuteReader();
                if (okuma.Read()){
                    MessageBox.Show("Kullanıcı adı kullanılmaktadır lütfen tekrar deneyiniz.");
                    baglan.Close();
                }
                else {
                    try
                    {
                        SqlConnection baglanti = veri.BaglantiAc();
                        SqlCommand komut = new SqlCommand("insert into Kullanici(Kullanici_Ad,Ad_Soyad,Email,sifre) values(@K_ad,@AdSoyad,@Email,@sifre)", baglanti);
                        komut.Parameters.AddWithValue("@K_ad", txt_RegisterKad.Text);
                        komut.Parameters.AddWithValue("@AdSoyad", txt_AdSoyad.Text);
                        komut.Parameters.AddWithValue("@Email", txt_Email.Text);
                        komut.Parameters.AddWithValue("@sifre", SifreCevir);

                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Kullanıcı kayıt işlemi gerçekleşmedi lütfen tekrar deneyiniz.");
                    }
                    finally {
                        veri.BaglantiKapat();
                        Login login = new Login();
                        login.Show();
                        this.Hide();
                    }
              }
            }
            else {
                MessageBox.Show("Lütfen Boş deger girmeyiniz.");
            }
        }


        private void panel8_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel8_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel8_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }




     
    }
}
