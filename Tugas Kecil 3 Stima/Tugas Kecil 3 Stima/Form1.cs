using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_Kecil_3_Stima
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void eNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iDToolStripMenuItem.Checked = false;
            eNToolStripMenuItem.Checked = true;
            fileToolStripMenuItem.Text = "File";
            exitToolStripMenuItem.Text = "Exit";
            languageToolStripMenuItem.Text = "Language";
            helpToolStripMenuItem.Text = "Help";
            guideToolStripMenuItem.Text = "Guide";
            aboutToolStripMenuItem.Text = "About";
            browseButton.Text = "Browse";
            fromText.Text = "From:";
            toText.Text = "To:";
        }

        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eNToolStripMenuItem.Checked = false;
            iDToolStripMenuItem.Checked = true;
            fileToolStripMenuItem.Text = "Berkas";
            exitToolStripMenuItem.Text = "Keluar";
            languageToolStripMenuItem.Text = "Bahasa";
            helpToolStripMenuItem.Text = "Bantuan";
            guideToolStripMenuItem.Text = "Panduan";
            aboutToolStripMenuItem.Text = "Tentang";
            browseButton.Text = "Telusuri";
            fromText.Text = "Dari:";
            toText.Text = "Ke:";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            // Terima input file, ubah jadi graf
            // Format file .txt:
            // Baris 1              : jumlah simpul (n)
            // Baris 2 sampai n+1   : matriks ketetanggan berbobot
            // Baris n+2 sampai 2n+1: nama simpul jika diberi nama
            // Jika tidak diberi nama, gunakan angka 1, 2, 3, ..., n

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text Files|*.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Clear combobox
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                // Ubah teks di sebelah browse button
                textBox1.Text = dialog.FileName;

                // Baca isi file
                string isifile = System.IO.File.ReadAllText(textBox1.Text);

                /*
                // Buat daftar huruf/nama akun
                List<string> daftarHuruf = new List<string>(createDaftarHuruf());

                // Ubah dropdown list
                foreach (var huruf in daftarHuruf)
                {
                    comboBox1.Items.Add(huruf);
                    comboBox2.Items.Add(huruf);
                }

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                */

                // Buat graf
                Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
                graph.AddEdge("A", "B");
                graph.AddEdge("B", "C");
                graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
                graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
                c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
                gViewer1.Graph = graph;
            }
        }
    }
}
