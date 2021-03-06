using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Http;

namespace Padawans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            principalBox.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            HttpClient user = new HttpClient();
            user.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            HttpResponseMessage response = user.GetAsync("users").Result;

            var usuario = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            principalBox.Visible = false;
            dataGrid.DataSource = usuario;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HttpClient todo = new HttpClient();
            todo.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            HttpResponseMessage response = todo.GetAsync("todos").Result;

            var td = response.Content.ReadAsAsync<IEnumerable<Todos>>().Result;
            principalBox.Visible = false;
            dataGrid.DataSource = td;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            HttpClient post = new HttpClient();
            post.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            HttpResponseMessage response = post.GetAsync("posts").Result;

            var pt = response.Content.ReadAsAsync<IEnumerable<Posts>>().Result;
            principalBox.Visible = false;
            dataGrid.DataSource = pt;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            HttpClient album = new HttpClient();
            album.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            HttpResponseMessage response = album.GetAsync("albums").Result;

            var alb = response.Content.ReadAsAsync<IEnumerable<Albums>>().Result;
            principalBox.Visible = false;
            dataGrid.DataSource = alb;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            HttpClient photo = new HttpClient();
            photo.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            HttpResponseMessage response = photo.GetAsync("photos").Result;

            var ph = response.Content.ReadAsAsync<IEnumerable<Photos>>().Result;
            principalBox.Visible = false;
            dataGrid.DataSource = ph;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            HttpClient comment = new HttpClient();
            comment.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            HttpResponseMessage response = comment.GetAsync("comments").Result;

            var cm = response.Content.ReadAsAsync<IEnumerable<Comments>>().Result;
            principalBox.Visible = false;
            dataGrid.DataSource = cm;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            principalBox.Visible = true;
            dataGrid.DataSource = null;
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }
    }
}
