using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer2
{
    public partial class Form1 : Form
    {
        [System.ComponentModel.Bindable(true)]
        
        public Form1()
        {
            InitializeComponent();

            string[] fileNames = Directory.GetFiles(@"c:\Users\elkan\Downloads\Soulseek Downloads\complete\vortex1394");

            foreach (string fn in fileNames)
            {
                if (Path.GetFileName(fn).Contains(textBox1.Text))
                {
                    //do something with fn
                }
            }
        }

        public void ChangeThemeDark(Form form)
        {
            form.BackColor = Color.FromArgb(26, 27, 22);

            foreach(Control panel in form.Controls)
            {
                if(panel.GetType() == typeof(Panel))
                {
                    panel.BackColor = Color.FromArgb(43, 64, 53);
                }
            }
            foreach (Control menuStrip in form.Controls)
            {
                if (menuStrip.GetType() == typeof(MenuStrip))
                {
                    menuStrip.BackColor = Color.FromArgb(26, 27, 22);
                    menuStrip.ForeColor = Color.White;
                }
            }
            foreach (Control listbox in form.Controls)
            {
                if (listbox.GetType() == typeof(ListBox))
                {
                    listbox.ForeColor = Color.White;
                    listbox.BackColor = Color.FromArgb(43, 64, 53);
                }
            }
        }
        public void ChangeThemeLight(Form form)
        {
            form.BackColor = Color.FromArgb(237, 255, 255);

            foreach (Control panel in form.Controls)
            {
                if (panel.GetType() == typeof(Panel))
                {
                    panel.BackColor = Color.White;
                }
            }
            foreach (Control menuStrip in form.Controls)
            {
                if (menuStrip.GetType() == typeof(MenuStrip))
                {
                    menuStrip.BackColor = Color.FromArgb(237, 234, 246);
                    menuStrip.ForeColor = Color.Black;
                }
            }
            foreach (Control listbox in form.Controls)
            {
                if (listbox.GetType() == typeof(ListBox))
                {
                    listbox.ForeColor = Color.Black;
                    listbox.BackColor = Color.FromArgb(237, 234, 246);
                }
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd=new OpenFileDialog() { Multiselect = true, Filter = "MP3|*.mp3|WNV|*.wnv|WAV|*.wav|MP4|*.mp4|MKV|*mkv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> files = new List<MediaFile>();
                    foreach(string fileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        files.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), Path = fileName });
                    }
                    FileList.DataSource = files;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileList.ValueMember = "Path";
            FileList.DisplayMember = "FileName";
        }
        private void FileList_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd=new OpenFileDialog() { Multiselect = true, Filter = "WNV|*.wnv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*mkv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> files = new List<MediaFile>();
                    foreach(string fileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        files.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), Path = fileName });
                    }
                    FileList.DataSource = files;
                }
            }
        }
        private void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = FileList.SelectedItem as MediaFile;
            if (file != null)
            {
                axWindowsMediaPlayer.URL = file.Path;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
        }
        private void FileList_SelectedItem(object sender, EventArgs e)
        {
            MediaFile file = FileList.SelectedItem as MediaFile;
            if (file != null)
            {
                axWindowsMediaPlayer.URL = file.Path;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (darkToolStripMenuItem.Text == "Dark")
            {
                ChangeThemeDark(ActiveForm);
            }
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lightToolStripMenuItem.Text == "Light")
            {
                ChangeThemeLight(ActiveForm);
            }       
        }

        private void pictureBox1Event(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.inkedpsyHole;
        }
    }
}
