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
    public partial class Form1 : Form
    {
        int Move;
        int Mouse_X;
        int Mouse_Y;


        public Form1()
        {
            InitializeComponent();
            SidePanell.Height = button1.Height;
            SidePanell.Top = button1.Top;
            home1.BringToFront();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = Login.kAdi;
            //label2.Text = Login.id.ToString();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            SidePanell.Height = button1.Height;
            SidePanell.Top = button1.Top;
            home1.BringToFront();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SidePanell.Height = button2.Height;
            SidePanell.Top = button2.Top;
            home21.BringToFront();
        }
        private void mycontent_Click(object sender, EventArgs e)
        {
            SidePanell.Height = mycontent.Height;
            SidePanell.Top = mycontent.Top;
            myContent1.BringToFront();
           
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SidePanell.Height = button4.Height;
            SidePanell.Top = button4.Top;
            Contents contents = new Contents();
            contents.Show();
            this.Hide();

        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            SidePanell.Height = btn_setting.Height;
            SidePanell.Top = btn_setting.Top;
            settings1.BringToFront();
        }

        //uygulamayı kapatır.
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
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
        //minimize işlemi
        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            getHelp gethelp = new getHelp();
            gethelp.Show();
            this.Hide();
            
        }
        /*Finish*/

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
