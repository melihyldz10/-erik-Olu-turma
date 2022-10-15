using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Contents : Form
    {
        int Move;
        int Mouse_X;
        int Mouse_Y;



        public Contents()
        {
            InitializeComponent();
        }






        private void btn_Content_Click(object sender, EventArgs e)
        {
            getsideP.Height = btn_Content.Height;
            getsideP.Top = btn_Content.Top;
            getsideP.BackColor = Color.Brown;
            contentsNedir1.BringToFront();
        }

        private void btn_Seo_Click(object sender, EventArgs e)
        {
            getsideP.Height = btn_Seo.Height;
            getsideP.Top = btn_Seo.Top;
            getsideP.BackColor = Color.LightSeaGreen;
            contentSeo1.BringToFront();
        }


        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //********************************Uygulama hareket ettirme işlemi kodları***************************//
        private void panelHareket_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panelHareket_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panelHareket_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

      
        //******************************************bitiş**************************************************//







    }
}
