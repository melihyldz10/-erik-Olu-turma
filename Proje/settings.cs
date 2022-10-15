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
using System.Security.Cryptography;
namespace Proje
{
    public partial class settings : UserControl
    {
        public settings()
        {
            InitializeComponent();
        }

        Veritabani veri = new Veritabani();//db baglantisi
        String kullaniciAdi = Login.kAdi;
        int Kullaniciİd = Login.id;

        private void settings_Load(object sender, EventArgs e)
        {
                SqlConnection baglan = veri.BaglantiAc();
                SqlCommand kontrol = new SqlCommand("SELECT * FROM Kullanici where id=@K_id ", baglan);
                kontrol.Parameters.AddWithValue("@K_id", Kullaniciİd);
                SqlDataAdapter da = new SqlDataAdapter(kontrol);
                SqlDataReader okuma = kontrol.ExecuteReader();
            if (okuma.Read())
            {
                txt_Kad.Text = okuma["Kullanici_Ad"].ToString();
                txt_AdSoyad.Text = okuma["Ad_Soyad"].ToString();
                txt_Email.Text = okuma["Email"].ToString();
                txt_Telefon.Text = okuma["telefon"].ToString();
            }
            else {
                baglan.Close();
            }
                
        }

        string SifreCevir;
        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            SifreCevir = Sifreleme.MD5Sifrele(txt_Sifre.Text);
       
            int SifreDegistirmeDurumu;

            if ((txt_Kad.Text != "") && (txt_AdSoyad.Text != "") && (txt_Email.Text != "") && (txt_Telefon.Text != "") && (txt_Sifre.Text != "") && (txt_SifreTekrar.Text != ""))
            {
                if (txt_Sifre.Text != txt_SifreTekrar.Text){
                    MessageBox.Show("Uyuşmayan şifre");
                }
                else {
                    if (txt_Sifre.Text == "EskiSifre"){
                    SifreDegistirmeDurumu = 0;
                    }else{
                    SifreDegistirmeDurumu = 1;
                    }
                    
                    

                    if (kullaniciAdi != txt_Kad.Text) { 
                    SqlConnection baglan = veri.BaglantiAc();
                    SqlCommand kontrol = new SqlCommand("SELECT * FROM Kullanici where Kullanici_Ad=@K_ad ", baglan);
                    kontrol.Parameters.AddWithValue("@K_ad", txt_Kad.Text);
                    SqlDataReader okuma = kontrol.ExecuteReader();
                    if (okuma.Read())
                    {
                        MessageBox.Show("Kullanıcı adı kullanılmaktadır lütfen tekrar deneyiniz.");
                        baglan.Close();
                    }
                  }

                    if (SifreDegistirmeDurumu == 1){
                        try {
                            SqlConnection baglan = veri.BaglantiAc();
                            SqlCommand komut = new SqlCommand("update Kullanici set Kullanici_Ad=@K_ad, Ad_Soyad=@AdS, Email=@Email,telefon=@telefon, sifre=@sifre where id=@K_id ", baglan);
                            komut.Parameters.AddWithValue("@K_ad", txt_Kad.Text);
                            komut.Parameters.AddWithValue("@AdS", txt_AdSoyad.Text);
                            komut.Parameters.AddWithValue("@Email", txt_Email.Text);
                            komut.Parameters.AddWithValue("@telefon", txt_Telefon.Text);
                            komut.Parameters.AddWithValue("@sifre", SifreCevir);
                            komut.Parameters.AddWithValue("@K_id", Kullaniciİd);
                            komut.ExecuteNonQuery();
                            MessageBox.Show("Tebrikler bilgileriniz başarıyla güncellendi.");
                        }
                        catch (Exception) {
                            MessageBox.Show("Kullanıcı Güncelleme işlemi gerçekleşmedi lütfen tekrar deneyiniz.");
                        }
                        finally{
                            veri.BaglantiKapat();
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlConnection baglan = veri.BaglantiAc();
                            SqlCommand komut = new SqlCommand("update Kullanici set Kullanici_Ad=@K_ad ,Ad_Soyad=@Ad_Soyad,Email=@Email,telefon=@telefon where id=@K_id ", baglan);
                            komut.Parameters.AddWithValue("@K_ad", txt_Kad.Text);
                            komut.Parameters.AddWithValue("@Ad_Soyad", txt_AdSoyad.Text);
                            komut.Parameters.AddWithValue("@Email", txt_Email.Text);
                            komut.Parameters.AddWithValue("@telefon", txt_Telefon.Text);
                            komut.Parameters.AddWithValue("@K_id", Kullaniciİd);
                            komut.ExecuteNonQuery();
                            MessageBox.Show("Tebrikler bilgileriniz başarıyla güncellendi.");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Kullanıcı Güncelleme işlemis gerçekleşmedi lütfen tekrar deneyiniz.");
                        }
                        finally
                        {
                            veri.BaglantiKapat();
                        }

                    }




                }
            }
            else
            {
                MessageBox.Show("Lütfen Boş deger girmeyiniz.");
            }


        }

        public void color(TextBox a, Panel b) {
            a.BackColor = SystemColors.Control;
            b.BackColor = SystemColors.Control;
        }
        public void colorWhite(TextBox a, Panel b) {
            //a.Clear();
            a.BackColor = Color.White;
            b.BackColor = Color.White;
        }

        private void txt_Kad_Click(object sender, EventArgs e)
        {
            colorWhite(txt_Kad, panel1);
            color(txt_AdSoyad, panel2);
            color(txt_Email, panel3);
            color(txt_Telefon, panel4);
            color(txt_Sifre, panel5);
            color(txt_SifreTekrar, panel6);
        }

        private void txt_AdSoyad_Click(object sender, EventArgs e)
        {
            color(txt_Kad, panel1);
            colorWhite(txt_AdSoyad, panel2);
            color(txt_Email, panel3);
            color(txt_Telefon, panel4);
            color(txt_Sifre, panel5);
            color(txt_SifreTekrar, panel6);
        }

        private void txt_Email_Click(object sender, EventArgs e)
        {
            color(txt_Kad, panel1);
            color(txt_AdSoyad, panel2);
            colorWhite(txt_Email, panel3);
            color(txt_Telefon, panel4);
            color(txt_Sifre, panel5);
            color(txt_SifreTekrar, panel6);
        }

        private void txt_Telefon_Click(object sender, EventArgs e)
        {
            color(txt_Kad, panel1);
            color(txt_AdSoyad, panel2);
            color(txt_Email, panel3);
            colorWhite(txt_Telefon, panel4);
            color(txt_Sifre, panel5);
            color(txt_SifreTekrar, panel6);
        }

        private void txt_Sifre_Click(object sender, EventArgs e)
        {
            color(txt_Kad, panel1);
            color(txt_AdSoyad, panel2);
            color(txt_Email, panel3);
            color(txt_Telefon, panel4);
            colorWhite(txt_Sifre, panel5);
            color(txt_SifreTekrar, panel6);
        }

        private void txt_SifreTekrar_Click(object sender, EventArgs e)
        {
            color(txt_Kad, panel1);
            color(txt_AdSoyad, panel2);
            color(txt_Email, panel3);
            color(txt_Telefon, panel4);
            color(txt_Sifre, panel5);
            colorWhite(txt_SifreTekrar, panel6);
        }
    }
}
