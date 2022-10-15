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
    public partial class myContent : UserControl
    {


        public static string konu;
        public static string anahtarKelime;
        public static string baslikh1;
        public static string girisBolumu;
        public static string baslikh2;
        public static string icerikh2;
        public static string baslikh3;
        public static string icerikh3;
        public static string sonuc; 


        Veritabani veri = new Veritabani();//db baglantisi
        public myContent()
        {
            InitializeComponent();
        }


        public void icerikGet() {
            String Kullanici_id= Login.id.ToString();

            SqlConnection baglanti = veri.BaglantiAc();
            
            SqlCommand komut = new SqlCommand("SELECT * FROM İcerikler WHERE K_id =@K_id; ", baglanti);
            komut.Parameters.AddWithValue("@K_id", Kullanici_id);

            SqlDataAdapter okuyucu = new SqlDataAdapter(komut);

            DataTable tablo = new DataTable();
            okuyucu.Fill(tablo);

            dataGridView1.DataSource = tablo;

            baglanti.Close();
        }

        private void myContent_Load(object sender, EventArgs e)
        {
            icerikGet();
        }

        public void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
             String dataİd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
             String dataKid = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }


        private void btn_İcerikSil_Click(object sender, EventArgs e)
        {
            String dataİd = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            SqlConnection baglanti = veri.BaglantiAc();

            SqlCommand komut = new SqlCommand("Delete FROM İcerikler WHERE id=@id; ", baglanti);
            komut.Parameters.AddWithValue("@id",dataİd);

            komut.ExecuteNonQuery();
            baglanti.Close();
            icerikGet();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            icerikGet();
        }

        private void btn_indir_Click(object sender, EventArgs e)
        {
   


            String dataİd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlConnection baglanti = veri.BaglantiAc();
            SqlCommand komut = new SqlCommand("SELECT * FROM İcerikler where id=@id",baglanti);
            komut.Parameters.AddWithValue("@id",dataİd);
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read()) {
                konu             = okuyucu["konu"].ToString();
                anahtarKelime    = okuyucu["anahtarKelime"].ToString();
                baslikh1         = okuyucu["baslikh1"].ToString();
                girisBolumu      = okuyucu["girisBolumu"].ToString();
                baslikh2         = okuyucu["baslikh2"].ToString();
                icerikh2         = okuyucu["icerikh2"].ToString();
                baslikh3         = okuyucu["baslikh3"].ToString();
                icerikh3         = okuyucu["icerikh3"].ToString();
                sonuc            = okuyucu["sonuc"].ToString();
            }
            baglanti.Close();






            if ((konu != "") && (anahtarKelime != "") && (baslikh1 != "") && (girisBolumu != "") && (baslikh2 != "") && (icerikh2 != "") && (baslikh3 != "") && (icerikh3 != "") && (sonuc != ""))
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
                paragraph2.Range.Text = anahtarKelime;
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
                paragraph3.Range.Text = baslikh1;
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
                paragraph4.Range.Text = girisBolumu;
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
                paragraph5.Range.Text = baslikh2;
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
                paragraph6.Range.Text = icerikh2;
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
                paragraph7.Range.Text = baslikh3;
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
                paragraph8.Range.Text = icerikh3;
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
                paragraph9.Range.Text = sonuc;
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
