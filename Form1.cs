using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace yt_dlp_Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = Clipboard.GetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            
            string format, text;
            text = null;
            format = comboBox1.Text;
            switch (format)
            {
                case "MP3 Max":
                    format = "-f bestaudio -x --extract-audio --embed-thumbnail --add-metadata --audio-format mp3 --no-overwrites --no-post-overwrites -o \"%(title)s.%(ext)s\" ";
                    break;

                case "MP4 Max":
                    format = "-f \"bestvideo+bestaudio\" --merge-output-format mp4 --no-overwrites --no-post-overwrites ";
                    break;

                case "MP3":
                    format = "-f bestaudio -x --extract-audio --embed-thumbnail --audio-format mp3 --audio-quality 5 --no-overwrites --no-post-overwrites -o \"%(title)s [CALIDAD_NORMAL].%(ext)s\" ";
                    break;

                case "MP4":
                    format = "-f \"bestvideo[height<=720]+bestaudio/best\" --merge-output-format mp4 -o \"%(title)s [720p].%(ext)s\" --no-overwrites --no-post-overwrites ";
                    break;

                case "WAV":
                    format = "-f bestaudio --extract-audio --embed-thumbnail --add-metadata --audio-format wav --no-overwrites --no-post-overwrites ";
                    break;

                default:
                    format = null;
                    break;


            }
            if (format == null)
                MessageBox.Show("Porfavor coloque un formato!");
            else
            {
                string directorio = $"\"{textBox2.Text}\"";
                text = "yt-dlp " + format + "-P " + directorio + " --rate-limit 7M " + textBox1.Text;
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe","/c "+ text);
                { 
                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = false;

                }
                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    this.button5.Enabled = false;
                    if (button1.Text == "Paste")
                        this.button5.Text = "Wait...";
                    else
                        this.button5.Text = "Espere...";
                    await Task.Delay(7000);
                    this.button5.Enabled = true;
                    if (button1.Text == "Paste")
                        this.button5.Text = "DOWNLOAD";
                    else
                        this.button5.Text = "DESCARGAR";
                    
                }

            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ajustesToolStripMenuItem.Text = "Settings";
            this.button1.Text = "Paste";
            this.button2.Text = "Delete";
            this.button4.Text = "Paste";
            this.button3.Text = "Delete";
            this.button5.Text = "DOWNLOAD";
            this.label1.Text = "Link Url:";
            this.label2.Text = "Format: ";
            this.label3.Text = "Download path: ";
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ajustesToolStripMenuItem.Text = "Ajustes";
            this.button1.Text = "Pegar";
            this.button2.Text = "Borrar";
            this.button4.Text = "Pegar";
            this.button3.Text = "Borrar";
            this.button5.Text = "DESCARGAR";
            this.label1.Text = "Enlace Url:";
            this.label2.Text = "Formato: ";
            this.label3.Text = "Ruta de descarga: ";

        }

        private void githubYtdlpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/yt-dlp/yt-dlp");
        }
    }
}
