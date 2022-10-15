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
using wordeaktar = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace Proje
{
   
    public partial class home2 : UserControl
    {

        Veritabani veri = new Veritabani();//db baglantisi
        MessageBoxButtons Ok = MessageBoxButtons.OK;//MessageBoxlar.
        public void cizgim(Label a) {
            a.AutoSize = false;
            a.Width = 1078;
            a.Height = 2;
            a.BorderStyle = BorderStyle.Fixed3D;
        }
        public void gecis(TabPage a)
        {
            tabControl1.SelectedTab = a;
        }

        public void sayac(Label a ,TextBox b) {
            int txt = b.TextLength;
            a.Text = b.TextLength.ToString();
            if (txt== 100)
            {
                MessageBox.Show("Maksimum Sınıra Ulaştınız");
            }
        }
        public void sınır(TextBox s,int sayi) {
            s.MaxLength = sayi;
        }

        public home2()
        {
            InitializeComponent();
        }
        private void home2_Load(object sender, EventArgs e)
        {


            lbl_hata.Visible = false;//eger tüm alanlar dolu degilde hata mesajını göster.

            cizgim(cizgi1);
            cizgim(cizgi2);
            cizgim(cizgi3);
            cizgim(cizgi4);
            cizgim(cizgi5);
            cizgim(cizgi6);
            cizgim(cizgi7);
            cizgim(cizgi8);
            cizgim(cizgi9);
            cizgim(cizgi10);


            //textbox sınırlarını method ile ayarlar.
            sınır(txt_Konu,150);
            sınır(txt_Anahtar, 50);
            sınır(txt_Baslik,100);
            sınır(txt_GirisBolum,800);
            sınır(txt_İkinciBaslik,100);
            sınır(txt_h2İçerigi,800);
            sınır(txt_h3Baslik,100);
            sınır(txt_h3İçerigi,800);
            sınır(txt_Sonuc,1000);
        }


        private void txt_Konu_TextChanged(object sender, EventArgs e)
        {
            sayac(lbl_sayac,txt_Konu);//maksimum sınır ve kelime sayacı.
        }

        private void txt_Anahtar_TextChanged(object sender, EventArgs e)
        {
          
            sayac(lbl_AnahtarSayac, txt_Anahtar);
        }

        private void txt_Baslik_TextChanged(object sender, EventArgs e)
        {
            sayac(lbl_BaslikSayac,txt_Baslik);
        }

        private void txt_GirisBolum_TextChanged(object sender, EventArgs e)
        {
            sayac(lbl_GirisSayac,txt_GirisBolum);
        }

        private void txt_İkinciBaslik_TextChanged(object sender, EventArgs e)
        {
            sayac(lbl_İkinciBaslik,txt_İkinciBaslik);
        }

        private void txt_h2İçerigi_TextChanged(object sender, EventArgs e)
        {
            sayac(lbl_h2İçerik,txt_h2İçerigi);
        }

        private void txt_h3Baslik_TextChanged(object sender, EventArgs e)
        {
            sayac(lbl_h3Sayac,txt_h3Baslik);
        }

        private void txt_h3İçerigi_TextChanged(object sender, EventArgs e)
        {
            sayac(lbl_h3İçerikSayac,txt_h3İçerigi);
        }

        private void txt_Sonuc_TextChanged(object sender, EventArgs e)
        {
            sayac(lbl_SonucSayac,txt_Sonuc);
        }

        private void olustur_Click(object sender, EventArgs e)
        {
            String konu = txt_Konu.Text;
            String anahtarKelime = txt_Anahtar.Text;
            String h1Baslik = txt_Baslik.Text;
            String girisBolum = txt_GirisBolum.Text;
            String h2Baslik = txt_İkinciBaslik.Text;
            String h2İcerik = txt_h2İçerigi.Text;
            String h3Baslik = txt_h3Baslik.Text;
            String h3İcerik = txt_h3İçerigi.Text;
            String sonuc = txt_Sonuc.Text;



            if (konu != "" && anahtarKelime != "" && h1Baslik != "" && girisBolum != "" && h2Baslik != "" && h2İcerik != "" && h3Baslik != "" && h3İcerik != "" && sonuc != "")
            {
                lbl_KonuBs.Text = "Konu";
                lbl_konu1.Text = konu;

                lbl_AnahtarBs.Text = "Anahtar Kelime";
                lbl_Anahtar1.Text = anahtarKelime;

                lbl_Baslıkbs.Text = "Başlık(H1)";
                lbl_Baslık1.Text = h1Baslik;

                lbl_GirisBolumubs.Text = "Giriş Bölümü";
                lbl_GirisBolumu1.Text = girisBolum;

                lbl_İkinciBaslikbs.Text = "Başlık(h2)";
                lbl_İkinciBaslik1.Text = h2Baslik;

                lbl_İcerikh2bs.Text = "İçerik(H2)";
                lbl_İcerikh21.Text = h2İcerik;

                lbl_İcerikh3bs.Text = "Başlık(H3)";
                lbl_İcerikh31.Text = h3Baslik;

                lbl_icerikh3bs.Text = "İçerik(H3)";
                lbl_icerikh31.Text = h3İcerik;

                lbl_SonucBs.Text = "Sonuç";
                lbl_Sonuc1.Text = sonuc;



                lbl_hata.Visible = false;
            }
            else
            {
                lbl_hata.Visible = true;
            }

        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            String kullanici_İd     = Login.id.ToString();
            String konu             = txt_Konu.Text;
            String anahtarKelime    = txt_Anahtar.Text;
            String h1Baslik         = txt_Baslik.Text;
            String girisBolum       = txt_GirisBolum.Text;
            String h2Baslik         = txt_İkinciBaslik.Text;
            String h2İcerik         = txt_h2İçerigi.Text;
            String h3Baslik         = txt_h3Baslik.Text;
            String h3İcerik         = txt_h3İçerigi.Text;
            String sonuc            = txt_Sonuc.Text;

            if ((konu!="") && (anahtarKelime !="") && (h1Baslik != "") && (girisBolum != "") && (h2Baslik != "") && (h2İcerik != "") && (h3Baslik !="") && (h3İcerik !="") && (sonuc !=""))
            {
                
                try
                    {
                        SqlConnection baglanti = veri.BaglantiAc();
                        SqlCommand komut = new SqlCommand("INSERT INTO  İcerikler(K_id,konu,anahtarKelime,baslikh1,girisBolumu,baslikh2,icerikh2,baslikh3,icerikh3,sonuc) " +
                            "VALUES(@K_id,@konu,@anahtar,@baslikh1,@girisBolum,@h2Baslik,@h2İcerik,@h3Baslik,@h3İcerik,@sonuc);", baglanti);
                        komut.Parameters.AddWithValue("@K_id", kullanici_İd);
                        komut.Parameters.AddWithValue("@konu", konu);
                        komut.Parameters.AddWithValue("@anahtar", anahtarKelime);
                        komut.Parameters.AddWithValue("@baslikh1", h1Baslik);
                        komut.Parameters.AddWithValue("@girisBolum", girisBolum);
                        komut.Parameters.AddWithValue("@h2Baslik", h2Baslik);
                        komut.Parameters.AddWithValue("@h2İcerik", h2İcerik);
                        komut.Parameters.AddWithValue("@h3Baslik", h3Baslik);
                        komut.Parameters.AddWithValue("@h3İcerik", h3İcerik);
                        komut.Parameters.AddWithValue("@sonuc", sonuc);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tebrikler başarıyla kayıt edildi.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("İcerik kayıt işlemi gerçekleşmedi lütfen tekrar deneyiniz.");
                    }
                    finally
                    {
                        veri.BaglantiKapat();
                    }
            }
            else
            {
                MessageBox.Show("Lütfen Boş Değer Girmeyiniz.!!", "Hata", Ok,MessageBoxIcon.Error);
            }



        }

        private void btn_indir_Click(object sender, EventArgs e)
        {
            String kullanici_İd = Login.id.ToString();
            String konu = txt_Konu.Text;
            String anahtarKelime = txt_Anahtar.Text;
            String h1Baslik = txt_Baslik.Text;
            String girisBolum = txt_GirisBolum.Text;
            String h2Baslik = txt_İkinciBaslik.Text;
            String h2İcerik = txt_h2İçerigi.Text;
            String h3Baslik = txt_h3Baslik.Text;
            String h3İcerik = txt_h3İçerigi.Text;
            String sonuc = txt_Sonuc.Text;

            if ((konu != "") && (anahtarKelime != "") && (h1Baslik != "") && (girisBolum != "") && (h2Baslik != "") && (h2İcerik != "") && (h3Baslik != "") && (h3İcerik != "") && (sonuc != ""))
            {



                object omissing = System.Reflection.Missing.Value;
                object dokumansonu = "\\endofdoc";

                wordeaktar.Application olustur;
                wordeaktar.Document icerik;
                olustur = new wordeaktar.Application();
                olustur.Visible = true;
                icerik = olustur.Documents.Add(ref omissing);

                wordeaktar.Paragraph paragraph10;
                paragraph10 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph10.Range.Text = "KONU";
                paragraph10.Range.Font.Bold = 1;
                paragraph10.Format.SpaceAfter = 20;
                paragraph10.Range.InsertParagraphAfter();


                wordeaktar.Paragraph paragraph1;
                paragraph1 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph1.Range.Text = konu;
                paragraph1.Range.Font.Bold = 0;
                paragraph1.Format.SpaceAfter = 20;
                paragraph1.Range.InsertParagraphAfter();



                wordeaktar.Paragraph paragraph11;
                paragraph11 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph11.Range.Text = "ANAHTAR KELİMELER";
                paragraph11.Range.Font.Bold = 1;
                paragraph11.Format.SpaceAfter = 20;
                paragraph11.Range.InsertParagraphAfter();



                wordeaktar.Paragraph paragraph2;
                object hedef = icerik.Bookmarks.get_Item(ref dokumansonu).Range;
                paragraph2 = icerik.Content.Paragraphs.Add(ref hedef);
                paragraph2.Range.Text = txt_Anahtar.Text;
                paragraph11.Range.Font.Bold = 0;
                paragraph2.Format.SpaceAfter = 25;
                paragraph2.Range.InsertParagraphAfter();

                wordeaktar.Paragraph paragraph12;
                paragraph12 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph12.Range.Text = "BAŞLIK H1";
                paragraph12.Range.Font.Bold = 1;
                paragraph12.Format.SpaceAfter = 20;
                paragraph12.Range.InsertParagraphAfter();

                wordeaktar.Paragraph paragraph3;
                hedef = icerik.Bookmarks.get_Item(ref dokumansonu).Range;
                paragraph3 = icerik.Content.Paragraphs.Add(hedef);
                paragraph3.Range.Text = txt_Baslik.Text;
                paragraph3.Range.Font.Bold = 0;
                paragraph3.Format.SpaceAfter = 20;
                paragraph3.Range.InsertParagraphAfter();

                wordeaktar.Paragraph paragraph13;
                paragraph13 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph13.Range.Text = "GİRİŞ BÖLÜMÜ";
                paragraph13.Range.Font.Bold = 1;
                paragraph13.Format.SpaceAfter = 20;
                paragraph13.Range.InsertParagraphAfter();


                wordeaktar.Paragraph paragraph4;
                hedef = icerik.Bookmarks.get_Item(ref dokumansonu).Range;
                paragraph4 = icerik.Content.Paragraphs.Add(hedef);
                paragraph4.Range.Text = txt_GirisBolum.Text;
                paragraph13.Range.Font.Bold = 0;
                paragraph4.Format.SpaceAfter = 20;
                paragraph4.Range.InsertParagraphAfter();


                wordeaktar.Paragraph paragraph14;
                paragraph14 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph14.Range.Text = "İKİNCİ BAŞLIK H2";
                paragraph14.Range.Font.Bold = 1;
                paragraph14.Format.SpaceAfter = 20;
                paragraph14.Range.InsertParagraphAfter();

                wordeaktar.Paragraph paragraph5;
                hedef = icerik.Bookmarks.get_Item(ref dokumansonu).Range;
                paragraph5 = icerik.Content.Paragraphs.Add(hedef);
                paragraph5.Range.Text = txt_İkinciBaslik.Text;
                paragraph5.Range.Font.Bold = 0;
                paragraph5.Format.SpaceAfter = 20;
                paragraph5.Range.InsertParagraphAfter();

                wordeaktar.Paragraph paragraph15;
                paragraph15 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph15.Range.Text = "H2 İÇERİĞİ (GELİŞME BÖLÜMÜ)";
                paragraph15.Range.Font.Bold = 1;
                paragraph15.Format.SpaceAfter = 20;
                paragraph15.Range.InsertParagraphAfter();


                wordeaktar.Paragraph paragraph6;
                hedef = icerik.Bookmarks.get_Item(ref dokumansonu).Range;
                paragraph6 = icerik.Content.Paragraphs.Add(hedef);
                paragraph6.Range.Text = txt_h2İçerigi.Text;
                paragraph6.Range.Font.Bold = 0;
                paragraph6.Format.SpaceAfter = 20;
                paragraph6.Range.InsertParagraphAfter();

                wordeaktar.Paragraph paragraph16;
                paragraph16 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph16.Range.Text = "ÜÇÜNCÜ BAŞLIK(H3)";
                paragraph16.Range.Font.Bold = 1;
                paragraph16.Format.SpaceAfter = 20;
                paragraph16.Range.InsertParagraphAfter();

                wordeaktar.Paragraph paragraph7;
                hedef = icerik.Bookmarks.get_Item(ref dokumansonu).Range;
                paragraph7 = icerik.Content.Paragraphs.Add(hedef);
                paragraph7.Range.Text = txt_h3Baslik.Text;
                paragraph7.Range.Font.Bold = 0;
                paragraph7.Format.SpaceAfter = 20;
                paragraph7.Range.InsertParagraphAfter();


                wordeaktar.Paragraph paragraph17;
                paragraph17 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph17.Range.Text = "H3 İÇERİĞİ";
                paragraph17.Range.Font.Bold = 1;
                paragraph17.Format.SpaceAfter = 20;
                paragraph17.Range.InsertParagraphAfter();

                wordeaktar.Paragraph paragraph8;
                hedef = icerik.Bookmarks.get_Item(ref dokumansonu).Range;
                paragraph8 = icerik.Content.Paragraphs.Add(hedef);
                paragraph8.Range.Text = txt_h3İçerigi.Text;
                paragraph8.Range.Font.Bold = 0;
                paragraph8.Format.SpaceAfter = 20;
                paragraph8.Range.InsertParagraphAfter();


                wordeaktar.Paragraph paragraph18;
                paragraph18 = icerik.Content.Paragraphs.Add(ref omissing);
                paragraph18.Range.Text = "SONUÇ";
                paragraph18.Range.Font.Bold = 1;
                paragraph18.Format.SpaceAfter = 20;
                paragraph18.Range.InsertParagraphAfter();


                wordeaktar.Paragraph paragraph9;
                hedef = icerik.Bookmarks.get_Item(ref dokumansonu).Range;
                paragraph9 = icerik.Content.Paragraphs.Add(hedef);
                paragraph9.Range.Text = txt_Sonuc.Text;
                paragraph9.Range.Font.Bold = 0;
                paragraph9.Format.SpaceAfter = 20;
                paragraph9.Range.InsertParagraphAfter();

            }
            else
            {
                MessageBox.Show("Lütfen Boş deger girmeyiniz.");
            }

        }
    }
}
