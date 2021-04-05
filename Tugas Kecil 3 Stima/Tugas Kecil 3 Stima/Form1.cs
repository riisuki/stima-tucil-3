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
            shortestText.Text = "Shortest Path:";
            distanceText.Text = "Distance:";
            searchButton.Text = "Search";
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
            shortestText.Text = "Jalur Terpendek:";
            distanceText.Text = "Jarak:";
            searchButton.Text = "Cari";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        bool[,] createMatriksJalan(string[] isifile2)
        {
            int jumlahNode = Int32.Parse(isifile2[0]);
            bool[,] matriks = new bool[jumlahNode, jumlahNode];

            for (int i = 0; i < jumlahNode; i++)
            {
                string[] tempstring = isifile2[i+1].Split(' ');
                for(int j = 0; j<jumlahNode; j++)
                {
                    if(tempstring[j] == "0")
                    {
                        matriks[i, j] = false;
                    }
                    else
                    {
                        matriks[i, j] = true;
                    }
                }
            }
            return matriks;
        }

        float[,] createMatriksBobot(string[] isifile2)
        {
            int jumlahNode = Int32.Parse(isifile2[0]);
            float[,] matriks = new float[jumlahNode, jumlahNode];
            for(int i = 0; i<jumlahNode; i++)
            {
                for(int j = 0;j<jumlahNode;j++)
                {
                    matriks[i, j] = 0;
                }
            }

            for (int i = 0; i < jumlahNode; i++)
            {
                string[] pos1 = isifile2[i+1+jumlahNode].Split(' ');
                for (int j = i; j < jumlahNode; j++)
                {
                    string[] pos2 = isifile2[j + 1 + jumlahNode].Split(' ');
                    if (i!=j)
                    {
                        float lat1 = float.Parse(pos1[0], System.Globalization.CultureInfo.InvariantCulture);
                        float lon1 = float.Parse(pos1[1], System.Globalization.CultureInfo.InvariantCulture);
                        float lat2 = float.Parse(pos2[0], System.Globalization.CultureInfo.InvariantCulture);
                        float lon2 = float.Parse(pos2[1], System.Globalization.CultureInfo.InvariantCulture);

                        matriks[i, j] = haversine(lat1, lon1, lat2, lon2);
                        matriks[j, i] = matriks[i, j];
                    }
                }
            }
            return matriks;
        }

        float haversine(float lat1, float lon1, float lat2, float lon2)
        {
            var R = 6371;
            var dLat = (lat2 - lat1) * (Math.PI/180);
            var dLon = (lon2 - lon1) * (Math.PI/180);
            var a = Math.Sin(dLat/2) * Math.Sin(dLat/2) + Math.Cos(lat1 * (Math.PI/180)) * Math.Cos(lat2 * (Math.PI/180)) * Math.Sin(dLon/2) * Math.Sin(dLon/2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var result = R * c * 1000;
            return (float) result;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            // Terima input file, ubah jadi graf
            // Format file .txt:
            // Baris 1              : jumlah simpul (n)
            // Baris 2 sampai n+1   : matriks ketetanggan, 1 berarti ada jalan antara i dan j
            // Baris n+2 sampai 2n+1: matriks jarak, berisi semua jarak dari i ke j
            // Baris 2n+2 sampai 3n+1: nama simpul jika diberi nama
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
                string[] isifile2 = isifile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                // Buat daftar huruf/nama akun
                List<string> daftarHuruf = new List<string>();
                int jumlahNode = Int32.Parse(isifile2[0]);
                if(isifile2.Length == jumlahNode*2+1)
                {
                    // Tidak pakai nama
                    for(int i = 0; i<jumlahNode; i++)
                    {
                        daftarHuruf.Add((i+1).ToString());
                    }
                }
                else
                {
                    // Pakai nama
                    for(int i = 0; i<jumlahNode; i++)
                    {
                        daftarHuruf.Add(isifile2[jumlahNode*2+1+i]);
                    }
                }

                // Ubah dropdown list
                foreach (var huruf in daftarHuruf)
                {
                    comboBox1.Items.Add(huruf);
                    comboBox2.Items.Add(huruf);
                }

                // Ubah panjang combobox dropdown jika kurang
                int maxlength = 0;
                for(int i=0; i<jumlahNode; i++)
                {
                    if(comboBox1.Items[i].ToString().Length > maxlength)
                    {
                        maxlength = comboBox1.Items[i].ToString().Length;
                    }
                }


                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;

                // Buat graf
                bool[,] matriksJalan = new bool[jumlahNode, jumlahNode];
                matriksJalan = createMatriksJalan(isifile2);
                float[,] matriksBobot = new float[jumlahNode, jumlahNode];
                matriksBobot = createMatriksBobot(isifile2);

                Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

                // Tambah edge dan node graf
                for(int i = 0; i<jumlahNode; i++)
                {
                    for(int j = i; j<jumlahNode; j++)
                    {
                        if(matriksJalan[i,j]==true)
                        {
                            var edge = graph.AddEdge(comboBox1.Items[i].ToString(), comboBox1.Items[j].ToString());
                            edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                            edge.LabelText = matriksBobot[i, j].ToString();
                        }
                    }
                }  
                gViewer1.Graph = graph;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int dari = comboBox1.SelectedIndex;
            int ke = comboBox2.SelectedIndex;
            if (dari == ke)
            {
                // Gagal mencari
                MessageBox.Show("Harap pilih 2 simpul yang berbeda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Lakukan pencarian
                findPath(dari, ke);
            }
        }

        void findPath(int dari, int ke)
        {

            string isifile = System.IO.File.ReadAllText(textBox1.Text);
            string[] isifile2 = isifile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int jumlahNode = Int32.Parse(isifile2[0]);
            bool[,] matriksJalan = new bool[jumlahNode, jumlahNode];
            matriksJalan = createMatriksJalan(isifile2);
            float[,] matriksBobot = new float[jumlahNode, jumlahNode];
            matriksBobot = createMatriksBobot(isifile2);

            // Cari jalur terpendek dengan A*
            List<int> path = new List<int>();
            List<int> open = new List<int>();
            List<int> closed = new List<int>();
            float[] f = new float[jumlahNode];
            float[] g = new float[jumlahNode];
            int[] prev = new int[jumlahNode];
            float cekf, cekg, h;
            
            for (int i = 0; i < jumlahNode; i++)
            {
                f[i] = 999999;
                g[i] = 0;
                prev[i] = -1;
            }
            
            open.Add(dari);
            while (open.Count() > 0)
            {
                open.Sort(); //ngurut dari f(n) terkecil
                int curr = open[0];
                open.RemoveAt(0);
                closed.Add(curr);

                if (curr == ke)
                {
                    while (curr != dari)
                    {
                        path.Add(curr);
                        curr = prev[curr];
                    }
                    path.Add(curr);
                    path.Reverse();
                    return;
                }

                for (int i = 0; i < jumlahNode; i++)
                {
                    if (matriksJalan[curr, i] && !closed.Contains(i))
                    {
                        cekg = g[curr] + matriksBobot[curr, i];
                        h = matriksBobot[i, ke];
                        cekf = cekg + h;
                        if (cekf < f[i])
                        {
                            f[i] = cekf;
                            g[i] = cekg;
                            prev[i] = curr;
                            open.Add(i);
                        }
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg;
            if (eNToolStripMenuItem.Checked == true)
            {
                msg = "Tugas Kecil 3 Strategi Algoritma:\nShortest Path with A*\n\n13519063 Melita\n13519171 Fauzan Yubairi Indrayadi";
                MessageBox.Show(msg, "About", MessageBoxButtons.OK);
            }
            else
            {
                msg = "Tugas Kecil 3 Strategi Algoritma:\nLintasan Terpendek dengan A*\n\n13519063 Melita\n13519171 Fauzan Yubairi Indrayadi";
                MessageBox.Show(msg, "Tentang", MessageBoxButtons.OK);
            }
        }

        private void guideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg;
            if(eNToolStripMenuItem.Checked==true)
            {
                msg = "1. Choose input file with 'Browse'\n2. Pick a starting node and a goal node\n3. Click 'Search'";
                MessageBox.Show(msg, "Guide", MessageBoxButtons.OK);
            }
            else
            {
                msg = "1. Pilih berkas input dengan 'Telusuri'\n2. Pilih simpul awal dan simpul tujuan\n3. Tekan tombol 'Cari'";
                MessageBox.Show(msg, "Panduan", MessageBoxButtons.OK);
            }
            
            
        }
    }
}
