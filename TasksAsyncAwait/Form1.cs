using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TasksAsyncAwait
{
    public partial class Form1 : Form
    {
        public static TextBox TextBox;
        public static RichTextBox RichTextBox;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox = textBox1;
            RichTextBox = richTextBox1;

            //downloadSincrono();
            downloadAssincrono();

            textBox1 = TextBox;
            richTextBox1 = RichTextBox;
        }


        static void downloadSincrono()
        {
            string endereco = TextBox.Text;

            WebClient webClient = new WebClient();

            string html = webClient.DownloadString(endereco);

            RichTextBox.Text = html;

            MessageBox.Show("Método finalizado!");
        }

        static async void downloadAssincrono()
        {
            string endereco = TextBox.Text;

            WebClient webClient = new WebClient();

            string html = await webClient.DownloadStringTaskAsync(new Uri(endereco));//webClient.DownloadString(endereco);

            RichTextBox.Text = html;

            MessageBox.Show("Método finalizado!");
        }

    }
}
