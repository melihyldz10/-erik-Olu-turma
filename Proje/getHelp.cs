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
    public partial class getHelp : Form
    {

        int Move;
        int Mouse_X;
        int Mouse_Y;

        public getHelp()
        {
            InitializeComponent();
            getsideP.Height = btn_feedBack.Height;
            getsideP.Top = btn_feedBack.Top;
            feedBack1.BringToFront();
        }

        private void btn_feedBack_Click(object sender, EventArgs e)
        {
            getsideP.Height = btn_feedBack.Height;
            getsideP.Top = btn_feedBack.Top;
            feedBack1.BringToFront();
        }
        private void btn_getHelp_Click(object sender, EventArgs e)
        {
            getsideP.Height = btn_getHelp.Height;
            getsideP.Top = btn_getHelp.Top;
            getHelpS1.BringToFront();
        }
        private void btn_about_Click(object sender, EventArgs e)
        {
            getsideP.Height = btn_about.Height;
            getsideP.Top = btn_about.Top;
            getAbout1.BringToFront();
        }
        //uygulamayı kapatır.
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        //minimize işlemi
        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*panel hareket ettirme işlemleri*/
        private void panel_Hareket_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel_Hareket_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel_Hareket_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }


        //sosyal medya
        private void btn_Facebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/");
        }

        private void btn_Twitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/");
        }

        private void btn_İnstragram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/?hl=tr");
        }


    }
}
